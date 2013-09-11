using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Net;

namespace LaunchDS
{
    public partial class Update : Form
    {
        //bool DownloadDone = false;
        string CurrentDir = Directory.GetCurrentDirectory();
        string RawReponse = string.Empty;
        string TempDir = Directory.GetCurrentDirectory() + "\\Cache\\" + System.DateTime.Now.Month + System.DateTime.Now.Day + System.DateTime.Now.Year + System.DateTime.Now.Hour + System.DateTime.Now.Minute;
        string BackUpDir = string.Empty;
        string Contents = null;
        //bool Stop = false;
        WebClient webClient = new WebClient();
        
        public Update()
        {
            InitializeComponent();
        }

        private void btn_Continue_Click(object sender, EventArgs e)
        {
            try
            {
                DoUpdate();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
             UpdateProgress("Downloading .. " + e.ProgressPercentage.ToString() + "% Done");
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                return;
            }

            

            //MessageBox.Show("Download completed!");
            //DownloadDone = true;
            BackUpDir = TempDir + "\\backup";

            UpdateProgress("Checking for previous Install");
            if (Directory.Exists(Directory.GetCurrentDirectory() + "\\data\\.minecraft") == true)
            {
                UpdateProgress("Previous install found, backing up important files.");
                Directory.CreateDirectory(BackUpDir);

                // backup MC settings
                if (File.Exists(CurrentDir + "\\data\\.minecraft\\options.txt") == true && File.Exists(BackUpDir + "\\options.txt") == false)
                {
                    File.Move(CurrentDir + "\\data\\.minecraft\\options.txt", BackUpDir + "\\options.txt");
                }

                // Backup waypoints
                if (Directory.Exists(CurrentDir + "\\data\\.minecraft\\mods\\rei_minimap") == true && Directory.Exists(BackUpDir + "\\rei_minimap") == false)
                {
                    Directory.Move(CurrentDir + "\\data\\.minecraft\\mods\\rei_minimap", BackUpDir + "\\rei_minimap");
                }

                // Remove the old install
                //Directory.Delete(CurrentDir + "\\data\\.minecraft", true);
            }
            else
            {
                UpdateProgress("No install found, doing a clean setup.");
            }

            btn_Stop.Enabled = false;

            // install new files
            UpdateProgress("Installing files, one moment.");

            Process RunInstaller = new Process();
            RunInstaller.StartInfo.FileName = TempDir + "\\" + Contents;
            RunInstaller.StartInfo.Arguments = "/S /D=" + CurrentDir;
            RunInstaller.Start();
            RunInstaller.WaitForExit();

            // restore any backed up files
            if (File.Exists(BackUpDir + "options.txt") == true)
            {
                File.Move(BackUpDir + "options.txt", CurrentDir + "\\data\\.minecraft\\options.txt");
            }

            if (Directory.Exists(BackUpDir + "\\rei_minimap") == true)
            {
                Directory.Move(BackUpDir + "\\rei_minimap", CurrentDir + "\\data\\.minecraft\\rei_minimap");
            }

            //clean up
            UpdateProgress("Removing unneeded files, backups will still remain.");
            File.Delete(TempDir + "\\" + Contents[1]);

            Program.CheckVersion(ProfileDir);

            DoUpdate();
        }

        private void DoUpdate()
        {
            btn_Continue.Enabled = false;
            btn_Stop.Enabled = true;
            UpdateProgress("Getting Update Info");

            

            //bool FoundCurrentVersion = false;
            int CurrentVersionLocation = 0;
            for (int i = 0; i < Program.Releases.Rows.Count; i++)
            {
                if (Program.CurrentVersion == Program.Releases.Rows[i]["ReleaseNumber"].ToString())
                {
                    //FoundCurrentVersion = true;
                    CurrentVersionLocation = i;
                    break;
                }
            }

            if (CurrentVersionLocation > 0)
            {
                if (CurrentVersionLocation == Program.Releases.Rows.Count - 1)
                {
                    // done
                    UpdateProgress("Done");

                    btn_Continue.Enabled = true;

                    return;
                }
            }
            else
            {
                if (CurrentVersionLocation == Program.Releases.Rows.Count)
                {
                    // done
                    UpdateProgress("Done");

                    btn_Continue.Enabled = true;

                    return;
                }
            }
            
            UpdateProgress("Downloading update....");
            Directory.CreateDirectory(TempDir);

            Contents = Program.Releases.Rows[CurrentVersionLocation + 1]["ExeToRun"].ToString();

            this.Text = Contents;

            //NetHelper.DownloadFile(Contents[0], TempDir + "\\" + Contents[1]);
            webClient = new WebClient();
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            webClient.DownloadFileAsync(new Uri(Program.Releases.Rows[CurrentVersionLocation + 1]["DownloadLocation"].ToString()), TempDir + "\\" + Program.Releases.Rows[CurrentVersionLocation + 1]["ExeToRun"].ToString());
        }

        private void UpdateProgress(string status)
        {
            lbl_Status.Text = status;
            lbl_Status.Invalidate();
            lbl_Status.Update();
            lbl_Status.Refresh();
            Application.DoEvents();
        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            if (webClient.IsBusy == true)
            {
                webClient.CancelAsync();
            }

            UpdateProgress("Operation Cancled");
        }
    }
}
