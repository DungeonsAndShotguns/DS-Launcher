using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using SevenZip;

namespace DSLPackager
{
    public enum GameType
    {
        Minecraft, Information, Other
    }

    public enum LoginType
    {
        Minecraft, PHPBB, None
    }

    public class PackageAdvanced
    {
        public string GameName { get; set; }
        public string GameDir { get; set; }
        public string VersionNumber { get; set; }
        public Uri UpdateURL { get; set; }
        public Uri DescURL { get; set; }
        public GameType TypeGame { get; set; }
        public LoginType TypeLogin { get; set; }
        public string CommandLine { get; set; }

        public PackageAdvanced() { }

        public PackageAdvanced(string gameName, string gameDir, string versionNumber, Uri updateURL, Uri descURL, GameType typeGame, LoginType typeLogin, string commandLine)
        {
            GameName = gameName;
            GameDir = gameDir;
            VersionNumber = versionNumber;
            UpdateURL = updateURL;
            DescURL = descURL;
            TypeGame = typeGame;
            TypeLogin = typeLogin;
            CommandLine = commandLine;
        }
    }

    public class Package
    {
        public string VersionNumber { get; set; }
        public string RootPath { get; set; }
        public string UpdateListLocation { get; set; }
        public List<string> FileBlackList { get; set; }
        public string BlackListFileName { get; set; }
        public string UpdateURL { get; set; }
        public string FileToDownload { get; set; }

        public Package(string versionNumber, string rootPath, string updateListLocation, List<string> fileBlackList, string blackListFileName, string updateURL, string fileToDownload)
        {
            VersionNumber = versionNumber;
            // double check this location
            RootPath = rootPath;
            UpdateListLocation = updateListLocation;
            FileBlackList = fileBlackList;
            BlackListFileName = blackListFileName;
            UpdateURL = updateURL;
            FileToDownload = fileToDownload;
        }

        public void Create()
        {
            System.Console.WriteLine("Creating Version File");
            CreateVersionFile();

            System.Console.WriteLine("Creating Black List File");
            CreateBlackList();

            System.Console.WriteLine("Compressing the Update");
            CompressUpdate();

            System.Console.WriteLine("Creating Version List File");
            ConstuctVersionList();
        }

        private void CreateVersionFile()
        {
            if (File.Exists(RootPath + "\\Version.txt") == true)
            {
                File.Delete(RootPath + "\\Version.txt");
            }

            using (StreamWriter versionSteam = new StreamWriter(RootPath + "\\Version.txt"))
            {
                versionSteam.WriteLine(VersionNumber);
                versionSteam.Flush();
            }
        }

        private void ConstuctVersionList()
        {
            StreamWriter versionSteam = null;

            if (File.Exists(UpdateListLocation) == true)
            {
                versionSteam = new StreamWriter(UpdateListLocation, true);
            }
            else
            {
                versionSteam = new StreamWriter("update.txt");
            }

            versionSteam.WriteLine(VersionNumber + ";" + UpdateURL + ";" + FileToDownload);
            versionSteam.Flush();
            versionSteam.Dispose();
        }

        private void CreateBlackList()
        {
            if (File.Exists(RootPath + "\\.file.blacklist") == true)
            {
                File.Delete(RootPath + "\\.file.blacklist");
            }

            using (StreamWriter blackListStream = new StreamWriter(RootPath + "\\.file.blacklist"))
            {
                foreach (string currentLine in FileBlackList)
                {
                    blackListStream.WriteLine(currentLine);
                }
                blackListStream.Flush();
            }
        }

        private void CompressUpdate()
        {
            SevenZipCompressor Compress = new SevenZipCompressor(FileToDownload);

            Compress.CompressDirectory(RootPath, "DS" + VersionNumber.Replace(".", "") + ".7zip");
        }
    }
}
