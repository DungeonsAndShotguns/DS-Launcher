using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DSMinecraft
{
    public class BGOperations
    {
        public void DLMMC()
        {
            Program.Download("https://dl.dropboxusercontent.com/u/5921811/DSMMC.zip", "MultiMC.zip");
            Program.Unzip("MultiMC.zip");        
        }

        public void DLADD()
        {
            using (StreamReader dlLinks = new StreamReader("files.dl"))
            {
                int fileCount = 0;
                while (!dlLinks.EndOfStream)
                {
                    string currentLink = dlLinks.ReadLine();
                    Program.Download(currentLink, "temp" + fileCount + ".zip");
                    Program.Unzip("temp" + fileCount + ".zip");
                    fileCount++;
                }
            }

            File.Delete("files.dl");
        }
    }
}
