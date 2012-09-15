using System;   
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace KeepSync {
    public partial class SyncSettings : UserControl {
        public SyncSettings(XElement element = null) {
            InitializeComponent();
            if (element != null) {
                LoadXml(element);
            }
            dgv_files.AutoGenerateColumns = false;
            dgv_files.DataSource = _modifiedFiles;
        }
        public class StatusEventArgs:EventArgs {
            public string status { get;private set;}
            public StatusEventArgs(string status) {
                this.status = status;
            }
        }
        public event EventHandler<EventArgs> CloseClicked;
        public event EventHandler<StatusEventArgs> Status;
        public event EventHandler<EventArgs> SrcChanged;

        private void btn_close_Click(object sender, EventArgs e) {
            if (CloseClicked != null) {
                CloseClicked(this, e);
            }
        }
        public string src { get { return _sourceFolder; } }
        public XElement SaveXml() {
            return new XElement("KeepSync",
                new XAttribute("src", _sourceFolder??""),
                new XAttribute("dest", _destFolder??""),
                new XAttribute("remote",_remoteFolder??""),
                new XElement("ignore", _ignoreList??""),
                new XAttribute("active", active),
                new XElement("remoteHistory",_remoteHistory.Distinct().Select(s=>new XElement("remote",s)).ToArray()),
                new XElement("modifiedFiles", _modifiedFiles.OfType<ModifiedFile>().Select(f => f.SaveXml())),
                new XAttribute("autoPublish", btn_autoPublish.Checked)
            );
        }

        public void LoadXml(XElement element) {
            if ((element != null) && (element.Name == "KeepSync")) {
                _sourceFolder = element.Attribute("src").Value;
                _destFolder = element.Attribute("dest").Value;
                if (element.Attribute("remote") != null) {
                    _remoteFolder = element.Attribute("remote").Value;
                }
                _ignoreList = element.Element("ignore").Value;
                if (element.Element("remoteHistory")!= null) {
                    _remoteHistory.AddRange(element.Element("remoteHistory").Elements("remote").Select(e => e.Value));
                }
                if (element.Element("modifiedFiles") != null) {
                    foreach (ModifiedFile mf in element.Element("modifiedFiles").Elements().Select(e => new ModifiedFile(e))) {
                        _modifiedFiles.Add(mf);
                    }
                }
                if (!String.IsNullOrWhiteSpace(_sourceFolder)) {
                    lbl_sourceFolder.Text = _sourceFolder;
                }
                if (!String.IsNullOrWhiteSpace(_destFolder)) {
                    lbl_destFolder.Text = _destFolder;
                }
                if (!String.IsNullOrWhiteSpace(_remoteFolder)) {
                    lbl_remoteSite.Text = _remoteFolder;
                }
                txt_ignoreList.Text = _ignoreList;

                this.active = bool.Parse(element.Attribute("active").Value);
                if (SrcChanged != null) {
                    SrcChanged(this, new EventArgs());
                }
                if (element.Attribute("autoPublish") != null) {
                    btn_autoPublish.Checked = bool.Parse(element.Attribute("autoPublish").Value);
                }
            }
        }

        private bool _active;
        private string _sourceFolder;
        private string _destFolder;
        private string _ignoreList; 
        private string _remoteFolder;
        private BindingSource _modifiedFiles = new BindingSource();
        private List<string> _remoteHistory = new List<string>();
        private FileSystemWatcher watcher;
        public bool active {
            get { return _active; }
            set {
                if (watcher != null) {
                    watcher.Dispose();
                }
                watcher = null;
                try {
                    if (value) {
                        watcher = new FileSystemWatcher(_sourceFolder);

                        watcher.IncludeSubdirectories = true;
                        watcher.Changed += new FileSystemEventHandler(watcher_FileChanged);
                        watcher.Created += new FileSystemEventHandler(watcher_FileCreated);
                        watcher.Renamed += new RenamedEventHandler(watcher_FileRenamed);
                        watcher.Deleted += new FileSystemEventHandler(watcher_FileDeleted);
                        watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName;
                        watcher.EnableRaisingEvents = true;
                    }
                    _active = value;
                } catch (Exception e) {
                    MessageBox.Show(e.Message, e.GetType().Name);
                    log(0, "{0}:{1}", e.GetType().Name, e.Message);
                }
                chk_active.Checked = _active;
            }
        }

        private Queue<string> _log = new Queue<string>();
        private bool _logupdating;
        private void log(int debuglevel, string message, params object[] values) {
            if (debuglevel <= KeepSync.Properties.Settings.Default.debugLevel) {
                lock (_log) {
                    _log.Enqueue(String.Format(message, values));
                    if (_log.Count > 100) {
                        _log.Dequeue();
                    }
                }
                if (!_logupdating) {
                    _logupdating = true;
                    try {
                            BeginInvoke(new MethodInvoker(
                            delegate {
                                _logupdating = false;
                                lock (_log) {
                                    while (_log.Count > 0) {
                                        string status = _log.Dequeue();
                                        EventHandler<StatusEventArgs> h = Status;
                                        if (h != null) {
                                            h(this, new StatusEventArgs(status));
                                        }
                                    }
                                }
                            }
                        ));
                    } catch (InvalidOperationException e) {
                        System.Diagnostics.Debug.Print(e.Message);
                    }
                }
            }
        }

        bool ignoreFile(string fileName) {
            string[] ignoreList = (_ignoreList??"").Split(',');
            return fileName.Split('/', '\\').Where(path => ignoreList.Contains(path)).FirstOrDefault() != null;
        }

        Regex rxRemote = new Regex(@"^((scp|ftp|file):\/\/)(.*)$");
        TimeSpan timeout = TimeSpan.FromSeconds(10);
        void PublishFile(ModifiedFile mf) {
            DateTime startTime = DateTime.Now;
            if (String.IsNullOrWhiteSpace(_sourceFolder)) {
                log(0, "Please choose a source folder");
                return;
            }
            Match remoteMatch = rxRemote.Match(_remoteFolder);
            if (remoteMatch.Groups.Count < 4) {
                log(0, "Remote path does not contain a recognized protocol. ", _remoteFolder);
            } else {
                string protocol = remoteMatch.Groups[2].Value;
                string path = remoteMatch.Groups[3].Value;
                string destPath = mf.name;
                if (protocol == "scp") {
                    destPath = destPath.Replace(Path.DirectorySeparatorChar, '/');
                }
                if ((path.EndsWith("/") || path.EndsWith(Path.DirectorySeparatorChar.ToString())) && (mf.name.StartsWith(Path.DirectorySeparatorChar.ToString()))) {
                    destPath = destPath.Substring(1);
                }
                destPath = path + destPath;
                bool success = false;
                switch (protocol) {
                    case "scp":
                        ConsoleExec ce = new ConsoleExec();
                        ce.Start(GetScpPath(), "-batch -q " + ce.QuoteArg(_sourceFolder + mf.name) + " " + destPath, _sourceFolder);
                        while ((!ce.GetCompleted()) && (DateTime.Now-startTime < timeout))  {
                            ce.Pump((output)=>{log(0,"SCP:{0}",output);},
                                    (output)=>{log(0,"SCP ERROR:{0}",output);});
                            System.Threading.Thread.Sleep(100);
                            Application.DoEvents();
                        }
                        
                        ce.Pump((output)=>{log(0,"SCP:{0}",output);},
                                (output)=>{log(0,"SCP ERROR:{0}",output);});

                        mf.publish = false;
                        if (!ce.GetCompleted()) {
                            //send this into a background worker
                            //BackgroundWorker bgw = new BackgroundWorker();
                            //bgw.DoWork += (sender,e) => {
                                bool reported = false;
                                TimeSpan longTimeout = TimeSpan.FromMilliseconds(timeout.TotalMilliseconds* 3);
                                while (!ce.GetCompleted()) {
                                    if ((!reported) && (DateTime.Now - startTime > longTimeout)) {
                                        log(0, "SCP Timed out after {0} {1}", longTimeout,destPath);
                                        reported = true;
                                    }
                                    ce.Pump((output) => { log(0, "SCP:{0}", output); },
                                            (output) => { log(0, "SCP ERROR:{0}", output); });

                                    Application.DoEvents();
                                    System.Threading.Thread.Sleep(100);
                                }
                            //};
                            //bgw.RunWorkerCompleted += (sender, e) => {

                                log(ce.GetExitCode() == 0 ? -1 : 0, "scp exited with code {0}", ce.GetExitCode());
                                success = ce.GetExitCode() == 0;
                                log(0, " {1} File {0}", mf.name, success ? "Published" : "Failed to Publish");
                                log(ce.GetExitCode() == 0 ? -1 : 0, "scp exited with code {0}", ce.GetExitCode());
                                success = ce.GetExitCode() == 0;
                                mf.status = success ? ModifiedFile.Status.Success : ModifiedFile.Status.Failure;
                                //bgw = null;
                                ce = null;
                                mf = null;
                            //};
                            //bgw.RunWorkerAsync();
                                Application.DoEvents();
                            return;
                        } else {
                            log(ce.GetExitCode()==0?-1:0, "scp exited with code {0}", ce.GetExitCode());
                            success = ce.GetExitCode() == 0;

                            mf.status = success ? ModifiedFile.Status.Success : ModifiedFile.Status.Failure;
                            Application.DoEvents();
                        }
                    break;
                    default:
                        log(0, "Only scp protocol is supported at this time");
                        break;
                }
            }
        }
        public class GetPathEventArgs:EventArgs{
            public string path{get; set;}
        }
        public event EventHandler<GetPathEventArgs> NeedScpPath;
        string GetScpPath() {
            EventHandler<GetPathEventArgs> h = NeedScpPath;
            if (h != null) {
                GetPathEventArgs a = new GetPathEventArgs();
                h(this, a);
                return a.path;
            } else {
                return null;
            }
        }

        void CopyFile(string fileName) {
            try {
                string destPath = Path.Combine(_destFolder??"", fileName);
                string sourcePath = Path.Combine(_sourceFolder??"", fileName);
                if (File.Exists(sourcePath)) {
                    if (!ignoreFile(fileName)) {
                        try {
                            BeginInvoke(new MethodInvoker(delegate{
                               AddModifiedFile(_sourceFolder,Path.DirectorySeparatorChar+ fileName);
                            }));
                            if (Directory.Exists(_destFolder)) {
                                File.Copy(sourcePath, destPath, true);
                                log(0, "Copied {0}", fileName);
                            } else {
                                log(0, "File {0} changed but destfolder is invalid, not copied", fileName);
                            }
                        } catch (Exception e) {
                            log(0, "{0}: {1} [{2}]", e.GetType().Name, e.Message, fileName);
                        }
                    } else {
                        //log(1, "Ignored {0}", fileName);
                    }
                }
            } catch (Exception e) {
                log(0, "{0}: {1} [{2}]", e.GetType().Name, e.Message, fileName);
            }
        }


        void watcher_FileDeleted(object sender, FileSystemEventArgs e) {
            if (!ignoreFile(e.Name)) {
                log(1, "File Deleted {0}", e.Name);
            }
        }

        void watcher_FileCreated(object sender, FileSystemEventArgs e) {
            CopyFile(e.Name);
        }

        void watcher_FileChanged(object sender, FileSystemEventArgs e) {

            CopyFile(e.Name);
        }

        void watcher_FileRenamed(object sender, RenamedEventArgs e) {
            log(1, "Renamed {0} to {1}", e.OldName, e.Name);
            try {
                if (!ignoreFile(e.Name)) {
                    File.Delete(Path.Combine(_destFolder, e.OldName));
                }
            } catch (Exception ex) {
                log(0, "{0}: {1} [{2}]", ex.GetType().Name, ex.Message, e.OldName);
            }
            CopyFile(e.Name);
        }

      

        private bool PickFolder(LinkLabel label, ref string path) {

            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.SelectedPath = path;
            if (dlg.ShowDialog() == DialogResult.OK) {
                label.Text = dlg.SelectedPath;
                path = dlg.SelectedPath;
                return true;
            } else {
                return false;
            }
        }

        private void lbl_sourceFolder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            string path = _sourceFolder;
            if (PickFolder(sender as LinkLabel, ref path)) {
                _sourceFolder = path;
                active = active;
                if (SrcChanged != null) {
                    SrcChanged(this, new EventArgs());
                }
            }
        }

        private void lbl_destFolder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            string path = _destFolder;
            if (PickFolder(sender as LinkLabel, ref path)) {
                _destFolder = path;
                active = active;
            } else {
                _destFolder = "";
                ((LinkLabel)sender).Text = "";
                active = active;
            }
        }

        private void chk_active_CheckedChanged(object sender, EventArgs e) {
            if (chk_active.Checked != active) {
                active = chk_active.Checked;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {
        }

        private void txt_ignoreList_TextChanged(object sender, EventArgs e)
        {
            _ignoreList = txt_ignoreList.Text;
        }

        private void lbl_remote_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            StringChooserDialog dlg = new StringChooserDialog();
            dlg.history = _remoteHistory.Distinct();
            if (dlg.ShowDialog() == DialogResult.OK) {
                lbl_remoteSite.Text = _remoteFolder = dlg.result;
                _remoteHistory.Add(_remoteFolder);
            }
        }

    

        private void toolStripButton3_Click(object sender, EventArgs e) {
            IEnumerable<string> files = null;
            if (Clipboard.ContainsFileDropList()) {
                files = Clipboard.GetFileDropList().OfType<string>();
            } else if (Clipboard.ContainsText()) {
                files = Clipboard.GetText().Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            }
            if (files != null) {
                try {
                    foreach (string f in files.Select(fs => Path.GetFullPath(fs))) {
                        if (f.StartsWith(_sourceFolder)) {
                            AddModifiedFile(_sourceFolder, f.Substring(_sourceFolder.Length));
                        } if (File.Exists(Path.Combine(_sourceFolder,f))) {
                            AddModifiedFile(_sourceFolder,f);
                        }else {
                            log(0, "Could Not paste {0}, not contained in source folder", f);
                        }
                    }
                } catch (Exception ex) {
                    log(0, "Could Not paste {0}, {1}", String.Join(", ", files), ex.Message);
                }
            }
        }
        public bool AddModifiedFile(string path,string filename) {
            if (File.Exists(path+filename)) {
                ModifiedFile mf = _modifiedFiles.OfType<ModifiedFile>().FirstOrDefault(f => f.name == filename);
                if (mf != null) {
                    mf.Modified();
                } else {
                    _modifiedFiles.Add(mf = new ModifiedFile(filename));
                }
                try {
                    _modifiedFiles.ResetBindings(false);
                } catch {
                }
                if (btn_autoPublish.Checked) {
                    publishFiles(mf);
                }
                return true;
            }
            return false;
        }

        
        private void btn_clearPublished_Click(object sender, EventArgs e) {
            ModifiedFile[] remove = _modifiedFiles.OfType<ModifiedFile>().Where(mf => !mf.publish).ToArray();
            foreach (ModifiedFile mf in remove) {
                _modifiedFiles.Remove(mf);
            }
        }

        private void btn_publishChanges_Click(object sender, EventArgs e) {
            publishFiles(_modifiedFiles.OfType<ModifiedFile>().ToArray());
        }
        private void publishFiles(params ModifiedFile[] files) {
            ParallelOptions po = new ParallelOptions();
            po.MaxDegreeOfParallelism = 5;
            //todo: place this in a backgroundworker and add a progress bar
            btn_publishChanges.Enabled = false;
            pb_publishing.Visible = true;
            files = files.OfType<ModifiedFile>().Where(f=>f.publish).ToArray();
            if (pb_publishing.Maximum == pb_publishing.Value) {
                pb_publishing.Value = 0;
                pb_publishing.Maximum = 0;
            }
            pb_publishing.Maximum += files.Length;
            //pb_publishing.Value = 0;
            try {
                Parallel.ForEach<ModifiedFile>(files, po, new Action<ModifiedFile>(delegate(ModifiedFile mf) {
                    PublishFile(mf);
                    BeginInvoke(new MethodInvoker(delegate() { 
                        ++pb_publishing.Value;
                        pb_publishing.Visible = pb_publishing.Value == pb_publishing.Maximum;
                    }));
                }));
            } finally {
                btn_publishChanges.Enabled = true;
                pb_publishing.Visible = pb_publishing.Value != pb_publishing.Maximum;
            }
            //_modifiedFiles.ResetBindings(false);
        }

        protected override void OnLayout(LayoutEventArgs e) {

            base.OnLayout(e);
            //Height = pnl_layout.Height + Height - ClientSize.Height;
       }
        private Point ssResizeLastPoint = Point.Empty;
        private void statusStrip1_MouseDown(object sender, MouseEventArgs e) {
            ssResizeLastPoint = e.Location;
        }

        private void statusStrip1_MouseMove(object sender, MouseEventArgs e) {
            if (ssResizeLastPoint != Point.Empty) {
                pnl_layout.Height += e.Location.Y - ssResizeLastPoint.Y;
                ssResizeLastPoint = e.Location;
            }
        }

        private void statusStrip1_MouseUp(object sender, MouseEventArgs e) {
            ssResizeLastPoint = Point.Empty;
        }

        private void SyncSettings_Resize(object sender, EventArgs e) {
        }

        private void dgv_files_KeyPress(object sender, KeyPressEventArgs e) {
        
        }

        private void dgv_files_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Space) {
                foreach (DataGridViewCheckBoxCell cell in dgv_files.SelectedCells.OfType<DataGridViewCheckBoxCell>().Where(c => (c.OwningColumn.DataPropertyName == col_publish.DataPropertyName) && (c != dgv_files.CurrentCell))) {
                    cell.Value = !(bool)cell.Value;
                }
            }

            dgv_files.EndEdit();
        }

        

        private void dgv_files_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            dgv_files.EndEdit();
        } 
    }

    class ModifiedFile: INotifyPropertyChanged {
        public enum Status { Changed,Success,Failure,Unknown};
        public string name { get;private set;}
        private bool _publish;
        public bool publish { get { return _publish;} set {
            _publish = value;
            DoNotify("publish");
        } }
        public DateTime lastModified { get;private set;}
        public void Modified() { lastModified = DateTime.Now; publish = true; status = Status.Changed; DoNotify("lastModified"); }
        public Image statusImg { get; private set; }
        private Status _status;
        public Status status {
            get { return _status; }
            set {
                _status = value;
                switch (_status) {
                    case Status.Changed:
                        statusImg = KeepSync.Properties.Resources.document_out;
                        break;
                    case Status.Success:
                        statusImg = KeepSync.Properties.Resources.check2;
                        break;
                    case Status.Failure:
                        statusImg = KeepSync.Properties.Resources.error;
                        break;
                    default:
                        statusImg = KeepSync.Properties.Resources.check2;
                        break;
                }
                DoNotify("status");
                DoNotify("statusImg");
            }
        }
        public ModifiedFile(XElement element) {
            LoadXml(element);
        }
        public ModifiedFile(string aname) {
            this.name = aname;
            this.publish = true;
            Modified();
        }
        public XElement SaveXml() {
            return new XElement(this.GetType().Name,
                new XAttribute("name",name??""),
                new XAttribute("publish",publish),
                new XAttribute("lastModified",lastModified),
                new XAttribute("status",status)
                );
           
        }

        public void LoadXml(XElement element) {
            if (element.Name == this.GetType().Name) {
                this.name = element.Attribute("name").Value;
                this.publish = bool.Parse(element.Attribute("publish").Value);
                this.lastModified = DateTime.Parse(element.Attribute("lastModified").Value);
                this.status = (Status)Enum.Parse(typeof(Status),(element.Attribute("status")??new XAttribute("status",Status.Unknown)).Value);
            }
        }

        void DoNotify(string propertyName) {
            PropertyChangedEventHandler h = this.PropertyChanged;
            if (h != null) {
                h.BeginInvoke(this, new PropertyChangedEventArgs(propertyName), null, null);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
