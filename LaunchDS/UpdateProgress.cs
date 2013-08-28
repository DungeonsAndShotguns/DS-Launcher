using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace LaunchDS
{
    public partial class UpdateProgress : Form
    {
        string CurrentDir = Directory.GetCurrentDirectory();
        string RawReponse = string.Empty;
        string TempDir = Directory.GetCurrentDirectory() + "\\Cache\\" + System.DateTime.Now.Month + System.DateTime.Now.Day + System.DateTime.Now.Year + System.DateTime.Now.Hour + System.DateTime.Now.Minute;
        string BackUpDir = string.Empty;
        string Contents = null;
        WebClient webClient = new WebClient();

        public UpdateProgress()
        {
            InitializeComponent();
        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            UpdateCurrentProgress("Downloading .. " + e.ProgressPercentage.ToString() + "% Done");
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

            UpdateCurrentProgress("Checking for previous Install");
            if (Directory.Exists(Directory.GetCurrentDirectory() + "\\data\\.minecraft") == true)
            {
                UpdateCurrentProgress("Previous install found, backing up important files.");
                Directory.CreateDirectory(BackUpDir);

                // backup MC settings
                if (File.Exists(CurrentDir + "\\data\\.minecraft\\options.txt") == true && File.Exists(BackUpDir + "\\options.txt") == false)
                {
                    File.Copy(CurrentDir + "\\data\\.minecraft\\options.txt", BackUpDir + "\\options.txt");
                }

                // Backup waypoints
                if (Directory.Exists(CurrentDir + "\\data\\.minecraft\\mods\\rei_minimap") == true && Directory.Exists(BackUpDir + "\\rei_minimap") == false)
                {
                    DirectoryInfo Dir = new DirectoryInfo(CurrentDir + "\\data\\.minecraft\\mods\\rei_minimap");
                    FileInfo[] Files = Dir.GetFiles(); //Directory  Move(CurrentDir + "\\data\\.minecraft\\mods\\rei_minimap", BackUpDir + "\\rei_minimap");

                    foreach (FileInfo CurrentFile in Files)
                    {
                        CurrentFile.CopyTo(BackUpDir + CurrentFile.Name);
                    }
                }

                // Remove the old install
                //Directory.Delete(CurrentDir + "\\data\\.minecraft", true);
            }
            else
            {
                UpdateCurrentProgress("No install found, doing a clean setup.");
            }

            // install new files
            UpdateCurrentProgress("Installing files, one moment.");

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
            UpdateCurrentProgress("Removing unneeded files, backups will still remain.");
            File.Delete(TempDir + "\\" + Contents[1]);

            Program.CheckVersion();

            DoUpdate();
        }

        private void DoUpdate()
        {
            UpdateCurrentProgress("Getting Update Info");

            //RawReponse = NetHelper.Download("http://dungeonsandshotguns.org/dsmember/DownloadFile.txt");
            //Contents = RawReponse.Split(new char[1] { ';' });

            //bool FoundCurrentVersion = false;
            int CurrentVersionLocation = 0;
            for (int i = 0; i < Program.Releases.Rows.Count; i++)
            {
                if (Program.CurrentVersion == Program.Releases.Rows[i]["ReleaseNumber"].ToString())
                {
                    //FoundCurrentVersion = true;
                    CurrentVersionLocation = i;
                    //this.Close();
                    break;
                }
            }

            if (CurrentVersionLocation > 0)
            {
                if (CurrentVersionLocation == Program.Releases.Rows.Count - 1)
                {
                    // done
                    UpdateCurrentProgress("Done");
                    this.Close();
                    return;
                }
            }
            else
            {
                if (CurrentVersionLocation == Program.Releases.Rows.Count)
                {
                    // done
                    UpdateCurrentProgress("Done");
                    this.Close();
                    return;
                }
            }

            UpdateCurrentProgress("Downloading update....");
            Directory.CreateDirectory(TempDir);

            Contents = Program.Releases.Rows[CurrentVersionLocation + 1]["ExeToRun"].ToString();

            this.Text = Contents;

            //NetHelper.DownloadFile(Contents[0], TempDir + "\\" + Contents[1]);
                webClient = new WebClient();
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                webClient.DownloadFileAsync(new Uri(Program.Releases.Rows[CurrentVersionLocation + 1]["DownloadLocation"].ToString()), TempDir + "\\" + Program.Releases.Rows[CurrentVersionLocation + 1]["ExeToRun"].ToString());
        }

        private void UpdateCurrentProgress(string status)
        {
            lbl_UpdateStatus.Text = status;
            lbl_UpdateStatus.Invalidate();
            lbl_UpdateStatus.Update();
            lbl_UpdateStatus.Refresh();
            Application.DoEvents();
        }

        private void UpdateProgress_Load(object sender, EventArgs e)
        {
            lbl_UpdateStatus.Text = Program.CheckVersion();
        }

        private void UpdateProgress_Activated(object sender, EventArgs e)
        {
            
        }

        private void UpdateProgress_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void UpdateProgress_Click(object sender, EventArgs e)
        {
            try
            {
                //lbl_UpdateStatus.Text = Program.CheckVersion();
                DoUpdate();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        private void UpdateProgress_Shown(object sender, EventArgs e)
        {
            lbl_UpdateStatus.Text = "Click here to start. " + Program.CheckVersion();
        }
    }
}
