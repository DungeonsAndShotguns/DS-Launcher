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
    public partial class DownloadWindow : Form
    {
        private Addon CurrentAddon { get; set; }
        private string TempDir { get; set; }
        private string CurrentDir { get; set; }
        WebClient webClient = new WebClient();

        public DownloadWindow()
        {
            CurrentAddon = Program.CurrentAddon;
            InitializeComponent();
        }

        private void DownloadWindow_Load(object sender, EventArgs e)
        {

            TempDir = Directory.GetCurrentDirectory() + "\\Cache\\" + System.DateTime.Now.Month + System.DateTime.Now.Day + System.DateTime.Now.Year + System.DateTime.Now.Hour + System.DateTime.Now.Minute;
            Directory.CreateDirectory(TempDir);

            webClient = new WebClient();
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            webClient.DownloadFileAsync(new Uri(CurrentAddon.URL), TempDir + "\\" + CurrentAddon.Exe);
        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            UpdateCurrentProgress("Downloading .. " + e.ProgressPercentage.ToString() + "% Done");
        }
        private void UpdateCurrentProgress(string status)
        {
            lbl_Status.Text = status;
            lbl_Status.Invalidate();
            lbl_Status.Update();
            lbl_Status.Refresh();
            Application.DoEvents();
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled == false)
            {
                Process RunInstaller = new Process();
                RunInstaller.StartInfo.FileName = TempDir + "\\" + CurrentAddon.Exe;
                RunInstaller.StartInfo.Arguments = "/S /D=" + Directory.GetCurrentDirectory();
                RunInstaller.Start();
                RunInstaller.WaitForExit();
                this.Close();
            }
        }
    }
}
