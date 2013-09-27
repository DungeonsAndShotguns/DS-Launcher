using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

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

    public class Package
    {
        public string GameName { get; set; }
        public string GameDir { get; set; }
        public string VersionNumber { get; set; }
        public Uri UpdateURL { get; set; }
        public Uri DescURL { get; set; }
        public GameType TypeGame { get; set; }
        public LoginType TypeLogin { get; set; }
        public string CommandLine { get; set; }

        public Package() { }

        public Package(string gameName, string gameDir, string versionNumber, Uri updateURL, Uri descURL, GameType typeGame, LoginType typeLogin, string commandLine)
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
}
