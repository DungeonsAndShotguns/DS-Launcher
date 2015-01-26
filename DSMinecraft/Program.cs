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
            Minecraft.StartInfo.FileName = "MultiMC.exe";
            Minecraft.Start();
        }
    }
}
