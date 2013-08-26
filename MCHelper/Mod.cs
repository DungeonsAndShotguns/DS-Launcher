using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LaunchDS
{
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

        public Mod () { }


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
