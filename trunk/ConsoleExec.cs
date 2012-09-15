using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
namespace KeepSync {
    
    public class ConsoleExec {
        Process p;
        private Thread rt;
        private Thread wt;
        private AutoResetEvent terminate = new AutoResetEvent(false);
        private string output = "";
        private string error = "";
        private System.IO.Stream inStream;
        private System.IO.Stream outStream;
        public bool hasOutput { get { return !String.IsNullOrWhiteSpace(output); } }
        public bool hasError { get { return !String.IsNullOrWhiteSpace(error); } }
        public ConsoleExec() {
        }
        public void Start(string command, string args,string workingDirectory,System.IO.Stream inStream = null,System.IO.Stream outStream = null) {
            output = "";
            error = "";
            this.inStream = inStream;
            this.outStream = outStream;
            ProcessStartInfo si = new ProcessStartInfo(command, args);
            si.WorkingDirectory = workingDirectory;
            si.CreateNoWindow = true;
            si.RedirectStandardError = true;
            si.RedirectStandardInput = true;
            si.UseShellExecute = false;
            si.RedirectStandardOutput = true;
            if (outStream != null) {
                si.StandardOutputEncoding = Encoding.UTF8;
            }
            si.StandardErrorEncoding = Encoding.UTF8;
            p = Process.Start(si);
            p.ErrorDataReceived += new DataReceivedEventHandler(p_ErrorDataReceived);
            if (outStream == null) {
                p.OutputDataReceived += new DataReceivedEventHandler(p_OutputDataReceived);
                p.BeginOutputReadLine();
            } else {
                rt = new Thread(rtStart);
                rt.Start();
            }
            if (inStream != null) {
                wt = new Thread(wtStart);
                wt.Start();
            }
            p.BeginErrorReadLine();
        }

        public void rtStart() {
            int bytesRead = 0;
            int tbr = 0;
            byte[] buff = new byte[1024*1024];
            try {
                while (p.StandardOutput.Peek() == -1) {
                    System.Threading.Thread.Sleep(1000);
                    Debug.WriteLine("Peek -1, sleeping");
                }
                while ((bytesRead = p.StandardOutput.BaseStream.Read(buff, 0, buff.Length)) > 0) {
                    Debug.WriteLine("read " + bytesRead);
                    tbr += bytesRead;
                    outStream.Write(buff, 0, bytesRead); 
                }
                Debug.WriteLine("finished reading last: " + bytesRead + " total: " + tbr);
                
            } catch (System.IO.IOException ex) {
                Debug.WriteLine("ReadThread Error: "+ex.Message);
            }
        }
        public void wtStart() {
            byte[] buff = new byte[inStream.Length];
            int bytesRead = 0;
            int tbr = 0;
            while ((bytesRead = inStream.Read(buff, 0, buff.Length )) > 0) {
                tbr += bytesRead;
                Debug.WriteLine("writing " + bytesRead);
                p.StandardInput.BaseStream.Write(buff, 0,bytesRead);
            }
            Debug.WriteLine("finished Writing " + tbr + " bytes total");
            p.StandardInput.BaseStream.Close();
        }
        void p_ErrorDataReceived(object sender, DataReceivedEventArgs e) {
            lock (this) {
                error += e.Data+"\n";
            }
        }

        void p_OutputDataReceived(object sender, DataReceivedEventArgs e) {
            lock (this) {
                output += e.Data + "\n";
                
            }
        }
        public bool GetCompleted() {
            if (p.HasExited) {
               //wait for io threads to finish reading/writing
                if ((rt != null) && (rt.ThreadState != System.Threading.ThreadState.Stopped)) {
                    rt.Join(10000);
                    if (rt.ThreadState != System.Threading.ThreadState.Stopped) {
                        Debug.WriteLine("Read Thread did not join after 10 seconds, aborting");
                        rt.Abort();
                    }
                    rt = null;
                }
                if ((wt != null) && (wt.ThreadState != System.Threading.ThreadState.Stopped)) {
                    wt.Join(10000);
                    if (wt.ThreadState != System.Threading.ThreadState.Stopped) {
                        Debug.WriteLine("Write Thread did not join after 10 seconds, aborting");
                        wt.Abort();
                    }
                    rt = null;
                }
            }
            return p.HasExited;
        }
        public int GetExitCode() {
            return p.ExitCode;
        }
        public string GetOutput() {
	        string result;
            lock(this) {
                result = output;
		        output = "";
            }
	        return result;
        }
        public string GetError() {
	    string result;
            lock (this) {
		        result = error;
                error = "";
            }
	        return result;
        }
        public void SetInput(string input) {
            p.StandardInput.Write(input);
        }
        public string QuoteArg(string arg) {
            return "\"" + arg + "\"";
        }

        internal void Pump(Action<string> output, Action<string> error) {
            string outstr = this.GetOutput();
            if (!String.IsNullOrWhiteSpace(outstr)) {
                output(outstr);
            }
            string errstr = this.GetError();
            if (!String.IsNullOrWhiteSpace(errstr)) {
                error(errstr);
            }
        }
    }
}
