using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSLPackager
{
    public class Tests
    {
        public static void TestDSMC()
        {
            Package DSProfile = new Package("DS Minecraft", "DS Minecraft", "1.4.7.13", new Uri("https://dl.dropboxusercontent.com/u/5921811/update.txt"),
                new Uri("https://dl.dropboxusercontent.com/u/5921811/dsdownload.html"), GameType.Minecraft, LoginType.Minecraft, null);

            InstallPrep Prep = new InstallPrep(new System.IO.DirectoryInfo(System.IO.Directory.GetCurrentDirectory().ToString() + "\\DS Minecraft"), "DS12713U.exe");

            CratePackage Create = new CratePackage(DSProfile, Prep);

            System.Console.WriteLine( Create.CreatePackage() );
            System.Console.ReadKey();
        }
    }
}
