using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DS
{
    public enum GameType
    {
        Minecraft, Information, Other
    }

    public enum LoginType
    {
        Minecraft, PHPBB, None
    }

    public class Profile
    {
        public string GameName { get; set; }
        public string GameDir { get; set; }
        public string CurrentVersion { get; set; }
        public string UpdateURL { get; set; }
        public string DescriptionURL { get; set; }
        public GameType Type { get; set; }
        public string CommandLineArgs { get; set; }
        public LoginType Typelogin { get; set; }

        // Minecraft Settings
        int MaxMem { get; set; }
        int MinMem { get; set; }
        string UserName { get; set; }
        string JavaExe { get; set; }

        public Profile() { }

        public Profile LoadProfile(string ProfileDir)
        {
            if (System.IO.Directory.Exists(ProfileDir) == true)
            {
                if (System.IO.File.Exists(ProfileDir + "\\profile.cfg") == true)
                {
                    using (System.IO.StreamReader ReadConfig = new System.IO.StreamReader(ProfileDir + "\\profile.cfg"))
                    {
                        string TempString = string.Empty;
                        string[] TempPair = null;

                        while (ReadConfig.EndOfStream == false)
                        {
                            //TempString = ReadConfig.ReadLine();

                            if (TempString.StartsWith("#") == true)
                            {
                                continue;// Skip line this is a comment
                            }
                            else
                            {
                                TempPair = ReadConfig.ReadLine().Split('=');

                                switch (TempPair[0])
                                {
                                    case "GameName":
                                        GameName = TempPair[1];
                                        break;
                                    case "GameDir":
                                        GameDir = TempPair[1];
                                        break;
                                    case "CurrentVersion":
                                        CurrentVersion = TempPair[1];
                                        break;
                                    case "UpdateURL":
                                        UpdateURL = TempPair[1];
                                        break;
                                    case "DescriptionURL":
                                        DescriptionURL = TempPair[1];
                                        break;
                                    case "GameType":
                                        if (TempPair[1] == "Minecraft")
                                        {
                                            Type = GameType.Minecraft;
                                        }
                                        else if (TempPair[1] == "Information")
                                        {
                                            Type = GameType.Information;
                                        }
                                        else
                                        {
                                            Type = GameType.Other;
                                        }
                                        break;
                                    case "CommandLineArgs":
                                        CommandLineArgs = TempPair[1];
                                        break;
                                    case "LoginType":
                                        if (TempPair[1] == "Minecraft")
                                        {
                                            Typelogin = LoginType.Minecraft;
                                        }
                                        else if (TempPair[1] == "phpbb")
                                        {
                                            Typelogin = LoginType.PHPBB;
                                        }
                                        else
                                        {
                                            Typelogin = LoginType.None;
                                        }
                                        break;
                                    default:
                                        // Line not included
                                        break;
                                }
                            }

                            TempPair = new string[2];
                        }
                    }
                }
            }

            return this;
        }

        public override string ToString()
        {
            return GameName;
        }
    }

    public class Package
    {
        public string Name { get; set; }
        public string Preparer { get; set; }
        public DateTime CreationDate { get; set; }
        public Mod[] ListOfMods { get; set; }
        public bool Manditory { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public long TotalSize { get; set; }

        public Package()
        {
        }
    }

    public class Mod
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string File { get; set; }
        public string Hash { get; set; }
        public string Identifier { get; set; }
        public string Description { get; set; }
        public string MinecraftVersion { get; set; }
        //public string[] PostDownload { get; set; }
        public long Size { get; set; }
        //public byte[] Contents { get; set; }
        public bool Optional { get; set; }
        public Uri DownloadLocation { get; set; }
        public string InsallLocation { get; set; }
        public List<string> Requires { get; set; }
        public List<Mod> RequiredBy { get; set; }

        public Mod() { }


        /// <summary>
        /// Takes the output from a mod file request and turns it in to a mod object
        /// </summary>
        /// <param name="ModFile"></param>
        public Mod(string ModFile)
        {
            // split the file to find each row
            string[] LinesInFile = ModFile.Split(new char[1] { ';' });

            // a reusable variable for row storage
            string[] KeyVal = new string[2];

            // iterate though each row of the mod return and parse it out
            foreach (string Row in LinesInFile)
            {
                // split the row in to two parts Key / Value
                KeyVal = Row.Split(new char[1] { '=' });

                switch (KeyVal[0])
                {
                    case "Name":
                        Name = KeyVal[1];
                        break;
                    case "Author":
                        Author = KeyVal[1];
                        break;
                    case "File":
                        File = KeyVal[1];
                        break;
                    case "Hash":

                    default:
                        // junk so toss it out
                        break;
                }
            }
        }
    }
}
