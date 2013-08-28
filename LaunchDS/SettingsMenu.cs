using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Diagnostics;
using MinecraftHelper;

namespace LaunchDS
{
    public partial class SettingsMenu : Form
    {
        List<Addon> AddonsList = new List<Addon>();
        public string TempDir = string.Empty;

        public SettingsMenu()
        {
            InitializeComponent();

            if (Program.AppSettings.GetSetting("MemMin") != string.Empty)
            {
                txt_Min.Text = Program.AppSettings.GetSetting("MemMin");
            }
            else
            {
                txt_Min.Text = "512";
            }

            if (Program.AppSettings.GetSetting("MemMax") != string.Empty)
            {
                txt_Max.Text = Program.AppSettings.GetSetting("MemMax");
            }
            else
            {
                txt_Max.Text = "1024";
            }

            if (Program.AppSettings.GetSetting("JavaPath") != string.Empty)
            {
                txt_JavaPath.Text = Program.AppSettings.GetSetting("JavaPath");
            }

            if (Program.AppSettings.GetSetting("CloseOnLaunch") != string.Empty)
            {
                if (Program.AppSettings.GetSetting("CloseOnLaunch") == "True")
                {
                    chk_CloseOnLaunch.Checked = true;
                }
            }

            if (Program.AppSettings.GetSetting("ClassicLaunch") != string.Empty)
            {
                if (Program.AppSettings.GetSetting("ClassicLaunch") == "True")
                {
                    chk_ClassicLaunch.Checked = true;
                }
            }

            //txt_Min.Text = Program.AppSettings.MinMemory.ToString();
            //txt_Max.Text = Program.AppSettings.MaxMemory.ToString();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            //Program.AppSettings.MinMemory = Convert.ToInt32(txt_Min.Text);
            //Program.AppSettings.MaxMemory = Convert.ToInt32(txt_Max.Text);

            if (txt_Min.Text != string.Empty)
            {
                Program.AppSettings.UpdateSetting("MemMin", txt_Min.Text);
            }

            if (txt_Max.Text != string.Empty)
            {
                Program.AppSettings.UpdateSetting("MemMax", txt_Max.Text);
            }

            Program.AppSettings.SaveSettingsFile();
            this.Close();
        }

        private void btn_Cancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SettingsMenu_Load(object sender, EventArgs e)
        {
            NetHelper.DownloadFile(Program.AddonsURL, System.IO.Directory.GetCurrentDirectory() + "\\addons.txt");

            using (StreamReader ReadAddons = new StreamReader("addons.txt"))
            {
                while (ReadAddons.EndOfStream != true)
                {
                    Addon TempItem = new Addon(ReadAddons.ReadLine());
                    AddonsList.Add(TempItem);
                    lst_Addons.Items.Add(TempItem.ToString());
                }
            }
        }

        private void btn_JavaPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog FindPath = new OpenFileDialog();


            if (FindPath.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Program.AppSettings.UpdateSetting("JavaPath", FindPath.FileName);
            }

            txt_JavaPath.Text = Program.AppSettings.GetSetting("JavaPath");

        }

        private void chk_CloseOnLaunch_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_CloseOnLaunch.Checked == true)
            {
                Program.AppSettings.UpdateSetting("CloseOnLaunch", "True");
            }
            else
            {
                Program.AppSettings.UpdateSetting("CloseOnLaunch", "False");
            }
        }

        private void chk_ClassicLaunch_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_ClassicLaunch.Checked == true)
            {
                Program.AppSettings.UpdateSetting("ClassicLaunch", "True");
            }
            else
            {
                Program.AppSettings.UpdateSetting("ClassicLaunch", "False");
            }
        }

        private void btn_InstallAddon_Click(object sender, EventArgs e)
        {
            foreach (int Index in lst_Addons.SelectedIndices)
            {
                Program.CurrentAddon = AddonsList[Index];

                DownloadWindow DownloadFile = new DownloadWindow();
                
                DownloadFile.Show();
            }

            
        }

       
    }
}
