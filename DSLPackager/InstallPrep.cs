using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DSLPackager
{
    public class InstallPrep
    {
        public DirectoryInfo InstallLocation { get; set; }
        public DirectoryInfo FileLocation { get; set; }
        public string CleanUpScript { get; set; }
        public string FileName { get; set; }

        public InstallPrep() { }

        public InstallPrep(DirectoryInfo fileLocation, string fileName)
        {
            FileName = fileName;
            FileLocation = fileLocation;
        }
    }
}
