using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace LaunchDS
{
    public static class DSHelpper
    {
        public class FileStuctureCheck
        {

            public DirectoryInfo Bin { get; set; }
            

            public DirectoryInfo DataDir { get; set; }
            public DirectoryInfo DotMinecraft { get; set; }
            public FileInfo MCJar { get; set; }

            public FileStuctureCheck()
            {
                Bin = new DirectoryInfo(Directory.GetCurrentDirectory() + "\\bin");
                DataDir = new DirectoryInfo(Directory.GetCurrentDirectory() + "\\data");
                DotMinecraft = new DirectoryInfo(DataDir.FullName + "\\.minecraft");
                MCJar = new FileInfo(DotMinecraft.FullName + "\\bin\\minecraft.jar");
            }

            public bool Check()
            {
                if (Bin.Exists != true)
                {
                    return false;
                }

                if (DataDir.Exists != true)
                {
                    return false;
                }

                if (DotMinecraft.Exists != true)
                {
                    return false;
                }

                if (MCJar.Exists != true)
                {
                    return false;
                }

                return true;
            }
        }

    }
}
