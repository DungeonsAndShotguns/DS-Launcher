using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSLPackager
{
    
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Form1 PackageScreen = new Form1();
            System.Windows.Forms.Application.Run(PackageScreen);
        }
    }
}
