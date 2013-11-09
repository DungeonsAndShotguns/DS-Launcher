using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DSLPackager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_BrowseRoot_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog findFolder = new FolderBrowserDialog();
            if (findFolder.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tbx_RootDir.Text = findFolder.SelectedPath;
            }
        }

        private void btn_BrowseUpdateList_Click(object sender, EventArgs e)
        {
            OpenFileDialog findFile = new OpenFileDialog();
            if (findFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tbx_UpdateList.Text = findFile.FileName;
            }
        }

        private void btn_Compile_Click(object sender, EventArgs e)
        {
            List<string> blackListItems = new List<string>(rtb_BlackList.Lines);

            string fileName = string.Empty;
            if(tbx_VersionNumber.Text.Contains('.') == true)
            {
                fileName = "DS" + tbx_VersionNumber.Text.Replace(".", "") + ".7zip";
            }
            else
            {
                fileName = "DS" + tbx_VersionNumber.Text + ".7zip";
            }

            Package packageCreation = new Package(tbx_VersionNumber.Text, tbx_RootDir.Text, tbx_UpdateList.Text, blackListItems, ".files.blacklist", tbx_UpdateURL.Text, fileName);
            packageCreation.Create();
        }
    }
}
