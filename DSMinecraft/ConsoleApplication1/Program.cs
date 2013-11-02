using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSMinecraft
{
    class Program
    {
        static void Main(string[] args)
        {
            Process Minecraft = new Process();
            Minecraft.StartInfo.UseShellExecute = false;
            Minecraft.StartInfo.EnvironmentVariables.Remove("APPDATA");
            Minecraft.StartInfo.EnvironmentVariables.Add("APPDATA", System.IO.Directory.GetCurrentDirectory() + "\\data");
            Minecraft.StartInfo.FileName = "bin\\minecraft.exe";
            Minecraft.Start();
        }
    }
}
