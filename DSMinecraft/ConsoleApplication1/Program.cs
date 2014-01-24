using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinecraftHelper;

namespace DSMinecraft
{
    class Program
    {
        public static string CurrentVersion = string.Empty;
        public static DataTable Releases = new DataTable();
        public static string VersionFileURL = null;

        static void Main(string[] args)
        {
            if (File.Exists("DSUpdater.jar"))
            {
                Process Update = new Process();
                Update.StartInfo.FileName = "java";
                Update.StartInfo.Arguments = "-jar DSUpdater.jar";
                Update.Start();
                Update.WaitForExit();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("No Updater found, skipping updating.", "No Updater", System.Windows.Forms.MessageBoxButtons.OK);
            }



            Process Minecraft = new Process();
            Minecraft.StartInfo.UseShellExecute = false;
            Minecraft.StartInfo.EnvironmentVariables.Remove("APPDATA");
            Minecraft.StartInfo.EnvironmentVariables.Add("APPDATA", System.IO.Directory.GetCurrentDirectory() + "\\data");
            Minecraft.StartInfo.FileName = "bin\\minecraft.exe";
            Minecraft.Start();
        }

        public static string CheckVersion(string VersionFileDir)
        {
            string RemoteVersion = string.Empty;

            CurrentVersion = "";

            Releases.Clear();

            string Versions = NetHelper.Download("https://dl.dropboxusercontent.com/u/5921811/update.txt");

            string[] Releasesx = Versions.Split(new string[] { "\n" }, StringSplitOptions.None);

            foreach (string VerItem in Releasesx)
            {
                Releases.Rows.Add(VerItem.Split(new char[] { ';' }));
            }

            int CurrentVersionNum = 0;
            bool FoundCurrentVersion = false;
            string LatestVersion = "";

            foreach (DataRow CurrentRow in Releases.Rows)
            {
                if (FoundCurrentVersion == false)
                {
                    CurrentVersionNum++;
                }
                if (CurrentRow["ReleaseNumber"].ToString() == CurrentVersion)
                {
                    FoundCurrentVersion = true;
                    break;
                }
                LatestVersion = CurrentRow["ReleaseNumber"].ToString();
            }

            if (CurrentVersionNum != Releases.Rows.Count)
            {
                //return latest version
                return LatestVersion;
            }
            else
            {
                return "Version Good: " + LatestVersion;
            }
        }
    }
}
