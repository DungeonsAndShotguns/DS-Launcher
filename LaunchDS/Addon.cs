using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LaunchDS
{
    class Addon
    {
        public string Name { get; set; }
        public string URL { get; set; }
        public string Exe { get; set; }

        public Addon() { }

        public Addon(string NameToSet, string URLToSet, string EXEToSet)
        {
            Name = NameToSet;
            URL = URLToSet;
            Exe = EXEToSet;
        }

        public Addon(string LineFromFile)
        {
            string[] SplitLine = new string[3];

            SplitLine = LineFromFile.Split(';');

            Name = SplitLine[0];
            URL = SplitLine[1];
            Exe = SplitLine[2];
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
