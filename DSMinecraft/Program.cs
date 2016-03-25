using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ICSharpCode.SharpZipLib.Zip;

namespace DSMinecraft
{
    class Program
    {
        public static Updating window = new Updating();

        static void Main(string[] args)
        {
            BGOperations bg = new BGOperations();

            window.Show();

            if (!File.Exists("MultiMC.exe"))
            {
                window.MultiMC = false;
                Thread addFiles = new Thread(bg.DLMMC);
                addFiles.Start();
                while (addFiles.IsAlive)
                {
                    window.Update();
                }
            }

            if(File.Exists("files.dl"))
            {
                window.MultiMC = false;
                Thread addFiles = new Thread(bg.DLADD);
                addFiles.Start();
                while (addFiles.IsAlive)
                {
                    window.Update();
                }
            }

            DirectoryInfo root = new DirectoryInfo(Directory.GetCurrentDirectory() + "\\instances");

            foreach(DirectoryInfo currentInstance in root.GetDirectories())
            {
                //bool foundUpdater = false;

                foreach(FileInfo currentFile in currentInstance.GetFiles())
                {
                    if(currentFile.Name == "DSUpdater.jar")
                    {
                        Process DsUpdate = new Process();
                        DsUpdate.StartInfo.FileName = "java";
                        DsUpdate.StartInfo.Arguments = @"-jar " + currentFile.FullName;
                        DsUpdate.StartInfo.UseShellExecute = false;
                        DsUpdate.StartInfo.WorkingDirectory = currentInstance.FullName + "\\minecraft";
                        DsUpdate.Start();
                        DsUpdate.WaitForExit();

                        
                    }
                }
            }



            Process Minecraft = new Process();
            Minecraft.StartInfo.FileName = "MultiMC.exe";
            Minecraft.Start();
        }

        public static void DownloadMultiMCDS()
        {
            Download("https://dl.dropboxusercontent.com/u/5921811/DSMMC.zip", "MultiMC.zip");
            Unzip("MultiMC.zip");            
        }

        public static void Download(string url, string file)
        {
            using (WebClient clinet = new WebClient())
            {
                clinet.DownloadFile(url, file);
            }
        }

        public static void Unzip(string file)
        {
            // ripped from: https://github.com/icsharpcode/SharpZipLib/blob/master/samples/cs/unzipfile/UnZipFile.cs
            // thanks guys
            using (ZipInputStream stream = new ZipInputStream(File.OpenRead(file)))
            {

                ZipEntry theEntry;
                while ((theEntry = stream.GetNextEntry()) != null)
                {

                    Console.WriteLine(theEntry.Name);

                    string directoryName = Path.GetDirectoryName(theEntry.Name);
                    string fileName = Path.GetFileName(theEntry.Name);

                    // create directory
                    if (directoryName.Length > 0)
                    {
                        Directory.CreateDirectory(directoryName);
                    }

                    if (fileName != String.Empty)
                    {
                        using (FileStream streamWriter = File.Create(theEntry.Name))
                        {

                            int size = 2048;
                            byte[] data = new byte[2048];
                            while (true)
                            {
                                size = stream.Read(data, 0, data.Length);
                                if (size > 0)
                                {
                                    streamWriter.Write(data, 0, size);
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            File.Delete(file);
        }

        public static void DownloadAddedFiles(string urlFile)
        {
            using (StreamReader dlLinks = new StreamReader(urlFile))
            {
                int fileCount = 0;
                while (!dlLinks.EndOfStream)
                {
                    string currentLink = dlLinks.ReadLine();
                    Download(currentLink, "temp" + fileCount + ".zip");
                    Unzip("temp" + fileCount + ".zip");
                    fileCount++;
                    window.Update();
                }
            }

            File.Delete(urlFile);
        }

        
    }

    

}
