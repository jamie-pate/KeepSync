using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace KeepSync {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
        }

        private void btn_newSync_Click(object sender, EventArgs e) {
            SyncSettings ss = new SyncSettings();
            tc_syncs.TabPages.Add("<New Sync>");
            tc_syncs.TabPages[tc_syncs.TabPages.Count-1].Controls.Add(ss);
            linkSyncSettings(ss);
            ss.Dock = DockStyle.Top;
        }
        private void linkSyncSettings(SyncSettings ss) {
            ss.Dock = DockStyle.Fill;
            ss.BringToFront();
            ss.SrcChanged += new EventHandler<EventArgs>(ss_SrcChanged);
            ss.CloseClicked += new EventHandler<EventArgs>(ss_CloseClicked);
            ss.Status += new EventHandler<SyncSettings.StatusEventArgs>(ss_Status);
            ss.NeedScpPath += new EventHandler<SyncSettings.GetPathEventArgs>(ss_NeedScpPath);
        }

        void ss_SrcChanged(object sender,EventArgs args) {
            SyncSettings ss = sender as SyncSettings;
            foreach (TabPage page in tc_syncs.TabPages.OfType<TabPage>().Where(tp => tp.Controls.Contains(ss))) {
                page.Text = ss.src;
            }
        }
        private string _scpPath = "";
        void ss_NeedScpPath(object sender, SyncSettings.GetPathEventArgs e) {
            if (File.Exists(_scpPath)) {
                e.path = _scpPath;
            } else {
                e.path = Environment.ExpandEnvironmentVariables("%programfiles(x86)%\\putty\\pscp.exe");
                if (!File.Exists(e.path)) {
                    e.path=Environment.ExpandEnvironmentVariables("%programfiles%\\putty\\pscp.exe");
                    if (!File.Exists(e.path)) {
                        e.path = null;
                    }
                }
                
            }
        }
        class StatusMessage {
            public string reason { get; private set; }
            public string message { get; private set; }
            public StatusMessage(string reason, string message) {
                this.reason = reason;
                this.message = message;
            }
        }
        private void MainForm_Load(object sender, EventArgs e) {
            dgv_output.AutoGenerateColumns = false;
            dgv_output.DataSource = new BindingList<StatusMessage>();
            if (!String.IsNullOrWhiteSpace(KeepSync.Properties.Settings.Default.settings)) {
                try {
                    XElement root = XDocument.Parse(KeepSync.Properties.Settings.Default.settings).Root;
                    foreach(SyncSettings ss in root.Elements("Syncs").Elements().Select(el => new SyncSettings(el))) {
                        tc_syncs.TabPages.Add(ss.src);
                        tc_syncs.TabPages[tc_syncs.TabPages.Count-1].Controls.Add(ss);
                    }
                    if (root.Attribute("lastSync") != null) {
                        TabPage page = tc_syncs.TabPages.OfType<TabPage>().FirstOrDefault(tp => tp.Controls.OfType<SyncSettings>().FirstOrDefault(ss => ss.src == root.Attribute("lastSync").Value) != null);
                        if (page != null) {
                            tc_syncs.SelectedTab = page;
                        }
                    }
                    if (root.Attribute("scpPath") != null) {
                        _scpPath = root.Attribute("scpPath").Value;
                    }
                } catch (Exception ex) {
                    StatusOut(ex.GetType().Name,ex.Message);
                }
            }
            foreach (SyncSettings ss in tc_syncs.TabPages.OfType<TabPage>().SelectMany(tp=>tp.Controls.OfType<SyncSettings>())) {
                linkSyncSettings(ss);
            }
            
            
        }

        void StatusOut(string reason, string message) {
            ((BindingList<StatusMessage>)dgv_output.DataSource).Add(new StatusMessage(reason, message));

            dgv_output.FirstDisplayedScrollingRowIndex = Math.Max(0, dgv_output.Rows.Count - dgv_output.DisplayedRowCount(false));
        }

        void ss_Status(object sender, SyncSettings.StatusEventArgs e) {
            StatusOut(((SyncSettings)sender).src, e.status);
            
        }

        void ss_CloseClicked(object sender, EventArgs e) {
            SyncSettings ss = sender as SyncSettings;
            TabPage[] remove = tc_syncs.TabPages.OfType<TabPage>().Where(tp => tp.Controls.Contains(ss)).ToArray();
            foreach (TabPage tp in remove) { tc_syncs.TabPages.Remove(tp); tp.Controls.Clear(); }
            ss.active = false;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            try {
                KeepSync.Properties.Settings.Default.settings = new XDocument(
                    new XElement("MainForm",
                        new XAttribute("scpPath",_scpPath??""),
                        new XAttribute("lastSync",tc_syncs.SelectedTab.Controls.OfType<SyncSettings>().Select(ss=>ss.src).FirstOrDefault()??""),
                        new XElement("Syncs", tc_syncs.TabPages.OfType<TabPage>().SelectMany(tp=>tp.Controls.OfType<SyncSettings>()).Select(ss => ss.SaveXml()))
                        )).ToString();
                KeepSync.Properties.Settings.Default.Save();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, ex.GetType().Name);
            }
        }

        
        protected override void WndProc(ref Message m) {
            int WM_PARENTNOTIFY = 0x0210;
            if (!this.Focused && m.Msg == WM_PARENTNOTIFY) {
                // Make this form auto-grab the focus when menu/controls are clicked
                this.Activate();
            }
            base.WndProc(ref m);
        }
    }
}
