using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Data;
using MinecraftHelper;
using System.Collections;

namespace LaunchDS
{

    class Program
    {
        public static MinecraftInfo MCInfo = new MinecraftInfo();
        public static Settings AppSettings = new Settings();
        public static bool BypassLoginCheck = false;
        public static DataTable Releases = new DataTable();
        public static string CurrentVersion = string.Empty;
        public static Addon CurrentAddon = new Addon();

        public static List<MCHelper.Profile> Profiles = new List<MCHelper.Profile>();

        public static string VersionFileURL = null;
        public static string AddonsURL = null;
        public static string NewsURL = null;
        public static string DonateURL = null;

        [STAThread]
        static void Main(string[] args)
        {
            // Test
            //args = new string[1] { "bypass" };

            //Load the profiles
            LoadProfiles();

            // constuct datatable
            Releases.Columns.Add(new DataColumn("ReleaseNumber", typeof(string)));
            Releases.Columns.Add(new DataColumn("DownloadLocation", typeof(string)));
            Releases.Columns.Add(new DataColumn("ExeToRun", typeof(string)));

            if (args.Length > 0 && args[0] == "bypass")
            {
                BypassLoginCheck = true;
            }

            AppSettings.LoadSettingsFile();

            LoadURL();

            MainLite LauncherWindow = new MainLite();
            System.Windows.Forms.Application.Run(LauncherWindow);
           
            AppSettings.SaveSettingsFile();

        }

        public static string CheckVersion(string ProfileDir)
        {
            MCHelper.Profile CurrentProfile = new MCHelper.Profile();
            CurrentProfile.LoadProfile(Directory.GetCurrentDirectory() + "\\Data\\" + ProfileDir);


            //string CurrentVersion = string.Empty;
            string RemoteVersion = string.Empty;

            //try
            //{
                //using (StreamReader VersionFile = new StreamReader(ProfileDir + "\\Version.txt"))
                //{
            CurrentVersion = CurrentProfile.CurrentVersion;
                //}
            //}
            //catch (Exception e)
            //{
             //   if (e.ToString().Contains("zzz"))
              //  {
                    //do soemthing
               // }
                //TODO: Handle Exception
            //}

            Releases.Clear();

            //string Versions = NetHelper.Download(VersionFileURL);
            string Versions = NetHelper.Download(CurrentProfile.UpdateURL);

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
                LatestVersion = CurrentRow[ "ReleaseNumber" ].ToString();
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







        public static void LoadURL()
        {
            ArrayList URLs = new ArrayList();

            if (File.Exists("path.cfg") == true)
            {
                using (StreamReader ReadConfigFile = new StreamReader("path.cfg"))
                {
                    while (ReadConfigFile.EndOfStream != true)
                    {
                        URLs.Add(ReadConfigFile.ReadLine());
                    }
                }

                string[] TempConfigPair = new string[2];

                foreach (string Row in URLs)
                {
                    if (Row.Contains("VersionFileURL") == true)
                    {
                        VersionFileURL = Row.Split('=')[1];
                    }

                    if (Row.Contains("AddonsURL") == true)
                    {
                        AddonsURL = Row.Split('=')[1];
                    }

                    if (Row.Contains("NewsURL") == true)
                    {
                        NewsURL = Row.Split('=')[1];
                    }

                    if (Row.Contains("DonateURL") == true)
                    {
                        DonateURL = Row.Split('=')[1];
                    }
                }
            }
            else
            {

            }

            
            
        }

        public static void LoadProfiles()
        {
            //MCHelper.Profile TempProfile = null;
            try
            {
                foreach( string CurrentDir in Directory.GetDirectories( Directory.GetCurrentDirectory() + "\\data" ) )
                {
                    //TempProfile = new MCHelper.Profile();

                    Program.Profiles.Add( new MCHelper.Profile().LoadProfile( CurrentDir ) );
                }
            }
            catch( Exception e )
            {
                //whaaat?
            }
        }
    }
}
