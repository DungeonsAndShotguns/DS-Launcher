using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace LaunchDS
{
    public partial class Tools : Form
    {
        public Tools()
        {
            InitializeComponent();
        }

        private void btn_rhelp_Click(object sender, EventArgs e)
        {
            //Process Help = new Process();
            ProcessStartInfo TeamViewerInfo = new ProcessStartInfo();
            TeamViewerInfo.FileName = System.IO.Directory.GetCurrentDirectory() + "\\bin\\TeamViewerPortable\\TeamViewerPortable.exe";
            Process.Start(TeamViewerInfo);
        }

        private void btn_mcedit_Click(object sender, EventArgs e)
        {
            ProcessStartInfo McEdit = new ProcessStartInfo();
            McEdit.FileName = System.IO.Directory.GetCurrentDirectory() + "\\bin\\mcedit.exe";
            Process.Start(McEdit);
        }
    }
}
