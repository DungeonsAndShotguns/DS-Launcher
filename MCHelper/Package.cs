using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LaunchDS
{
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
}
