using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using SevenZip;

namespace DSLPackager
{
    public class CratePackage
    {
        Package PackageFile { get; set; }
        InstallPrep InstallPerpParms { get; set; }

        public CratePackage() { }

        public CratePackage(Package package, InstallPrep installPrep)
        {
            PackageFile = package;
            InstallPerpParms = installPrep;
        }

        public string CreatePackage()
        {
            // Create the package file
            if (File.Exists(InstallPerpParms.FileLocation.ToString() + "\\profile.cfg") == true)
            {
                File.Delete(InstallPerpParms.FileLocation.ToString() + "\\profile.cfg");
            }

            File.Create(InstallPerpParms.FileLocation.ToString() + "\\profile.cfg").Close();

            using( StreamWriter ProfileStream = new StreamWriter(InstallPerpParms.FileLocation.ToString() + "\\profile.cfg"))
            {
                ProfileStream.WriteLine("GameName=" + PackageFile.GameName);
                ProfileStream.WriteLine("GameDir=" + PackageFile.GameDir.ToString());
                ProfileStream.WriteLine("CurrentVersion=" + PackageFile.VersionNumber);
                ProfileStream.WriteLine("UpdateURL=" + PackageFile.UpdateURL.ToString());
                ProfileStream.WriteLine("DescriptionURL=" + PackageFile.DescURL.ToString());
                ProfileStream.WriteLine("GameType=" + PackageFile.TypeGame.ToString());
                ProfileStream.WriteLine("LoginType=" + PackageFile.TypeLogin.ToString());
                ProfileStream.WriteLine("CommandLineArgs=" + PackageFile.CommandLine);

                ProfileStream.Flush();
                ProfileStream.Close();
            }

            // create installer
            SevenZipSfx Installer = new SevenZipSfx();
            SevenZipCompressor Compress = new SevenZipCompressor("C:\\Temp\\Compress");

            // installer settings
            Dictionary<string, string> Settings = new Dictionary<string, string> 
                    { 
                        { "Title", PackageFile.GameName + " " + PackageFile.VersionNumber }, 
                        { "InstallPath", PackageFile.GameDir },
                        { "BeginPrompt", "Yükleme işlemi başlatılsın mı?" },
                        { "CancelPrompt", "Yükleme işlemi iptal edilecek?" },
                        { "OverwriteMode", "2" },
                        { "GUIMode", "1" },
                        { "ExtractDialogText", "Dosyalar ayıklanıyor" },
                        { "ExtractTitle", "Ayıklama İşlemi" },
                        { "ErrorTitle", "Hata!" }
                    };

             Compress.CompressDirectory(InstallPerpParms.FileLocation.ToString(), "c:\\temp\\compress.7zip");
             Installer.ModuleFileName = Directory.GetCurrentDirectory() + "\\7zxSD_LZMA.sfx";
             Installer.MakeSfx("c:\\temp\\compress.7zip", Settings, Directory.GetCurrentDirectory() + "\\" + InstallPerpParms.FileName);
            

            return "Done";
        }
    }
}
