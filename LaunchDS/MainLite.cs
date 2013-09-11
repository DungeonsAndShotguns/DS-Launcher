using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using MinecraftHelper;

namespace LaunchDS
{
    public partial class MainLite : Form
    {
        //string CurrentDir = Directory.GetCurrentDirectory();
        //string RawReponse = string.Empty;
        //string TempDir = Directory.GetCurrentDirectory() + "\\Cache\\" + System.DateTime.Now.Month + System.DateTime.Now.Day + System.DateTime.Now.Year + System.DateTime.Now.Hour + System.DateTime.Now.Minute;
        //string BackUpDir = string.Empty;
        //string Contents = null;
        //WebClient webClient = new WebClient();

        SettingsMenu Configure = null;

        public MainLite()
        {
            InitializeComponent();
        }

        private void btn_launch_Click(object sender, EventArgs e)
        {
            
            Application.DoEvents();

            MojangLogin LoginStatus = new MojangLogin();

            LoginStatus.Show();
            Application.DoEvents();

            if (Program.MCInfo.LoginPassed == false)
            {
                Program.MCInfo = MinecraftStatic.LoginCheck(txt_Username.Text, txt_Password.Text);
            }

            if (Program.MCInfo.LoginPassed == true)
            {
                LoginStatus.Close();
                //lbl_Status.Text = "Passed";
                //MessageBox.Show("Passed");
                Program.AppSettings.UpdateSetting("LastLogin", txt_Username.Text);



                if( !Program.CheckVersion().ToLower().Contains( "version good" ) )
                {
                    //Update Required
                    UpdateProgress Progress = new UpdateProgress();
                    Progress.ShowDialog();
                }
                //else, no update required, continue with launch.












                string DSMinecraftDir = "\"" + Directory.GetCurrentDirectory() + "\\data\\";

                if (File.Exists(Directory.GetCurrentDirectory() + "\\data\\.minecraft\\bin\\minecraft.jar") == true)
                {
                    if (Program.AppSettings.GetSetting("ClassicLaunch") == "True")
                    {
                        Process Minecraft = new Process();
                        Minecraft.StartInfo.FileName = "minecraftp.bat";
                        //Minecraft.StartInfo.Arguments = "--username=" + Program.MCInfo.UserName + " --password=" + Program.MCInfo.Password;
                        Minecraft.StartInfo.Arguments = Program.MCInfo.UserName + " " + Program.MCInfo.Password;
                        Minecraft.StartInfo.RedirectStandardOutput = true;
                        //Minecraft.StartInfo.CreateNoWindow = true;
                        Minecraft.StartInfo.UseShellExecute = false;
                        Minecraft.Start();
                    }
                    else
                    {
                        try
                        {
                            Program.AppSettings.MaxMemory = Convert.ToInt32(Program.AppSettings.GetSetting("MemMax"));
                            Program.AppSettings.MinMemory = Convert.ToInt32(Program.AppSettings.GetSetting("MemMin"));
                        }
                        catch
                        {
                            Program.AppSettings.MaxMemory = 2046;
                            Program.AppSettings.MinMemory =2046;
                        }

                        Process Minecraft = new Process();

                        if (Program.AppSettings.GetSetting("JavaPath") != string.Empty)
                        {
                            Minecraft.StartInfo.FileName = Program.AppSettings.GetSetting("JavaPath");
                        }
                        else
                        {
                            Minecraft.StartInfo.FileName = "java";
                        }



                        //string args = "-Xincgc -Xmx1024m -cp \"%APPDATA%\\.minecraft\\bin\\minecraft.jar;%APPDATA%\\.minecraft\\bin\\lwjgl.jar;%APPDATA%\\.minecraft\\bin\\lwjgl_util.jar;%APPDATA%\\.minecraft\\bin\\jinput.jar\" -Djava.library.path=\"%APPDATA%\\.minecraft\\bin\\natives\" net.minecraft.client.Minecraft \"NAME\"";
                        //string args = "-Xincgc -Xmx1024m -cp \"" + DSMinecraftDir + "\\.minecraft\\bin\\minecraft.jar;" + DSMinecraftDir + "\\.minecraft\\bin\\lwjgl.jar;" + DSMinecraftDir + "\\.minecraft\\bin\\lwjgl_util.jar;" + DSMinecraftDir + "\\.minecraft\\bin\\jinput.jar\" -Djava.library.path=\"" + DSMinecraftDir + "\\.minecraft\\bin\\natives\" net.minecraft.client.Minecraft \"NAME\"";
                        Minecraft.StartInfo.Arguments = "-Xms" + Program.AppSettings.MinMemory + "M -Xmx" + Program.AppSettings.MaxMemory + "M -Djava.library.path=" + DSMinecraftDir + ".minecraft/bin/natives\" -cp " + DSMinecraftDir + ".minecraft/bin/minecraft.jar\";" + DSMinecraftDir + ".minecraft/bin/jinput.jar\";" + DSMinecraftDir + ".minecraft/bin/lwjgl.jar\";" + DSMinecraftDir + ".minecraft/bin/lwjgl_util.jar\" net.minecraft.client.Minecraft " + Program.MCInfo.UserName + " " + Program.MCInfo.SessionID;
                        Console.WriteLine(Minecraft.StartInfo.Arguments);
                        Minecraft.StartInfo.RedirectStandardOutput = false;
                        //Minecraft.StartInfo.Arguments = Environment.ExpandEnvironmentVariables(args);
                        //Minecraft.StartInfo.CreateNoWindow = true;
                        //Minecraft.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        Minecraft.StartInfo.UseShellExecute = false;
                        //Minecraft.StartInfo.RedirectStandardOutput = false;
                        Minecraft.StartInfo.EnvironmentVariables.Remove("APPDATA");
                        Minecraft.StartInfo.EnvironmentVariables.Add("APPDATA", Directory.GetCurrentDirectory() + "\\data\\");

                        //do
                        //{
                        //    Thread.Sleep(500);
                        //    //Console.Out.Write( Minecraft.StandardOutput.ReadToEnd() );
                       //}
                       //while (!Minecraft.HasExited);
                        //catch any leftovers in redirected stdout
                        //Console.Out.Write( Minecraft.StandardOutput.ReadToEnd() );

                        try
                        {
                            Minecraft.Start();
                        }
                        catch (Exception ex)
                        {
                            if (ex.ToString().Contains("The system cannot find the file specified") == true)
                            {
                                // add titles
                            }
                        }

                        //ConsoleRedirect.Close();
                        //ConsoleRedirect.Dispose();
                    }

                    if (Program.AppSettings.GetSetting("CloseOnLaunch") != string.Empty)
                    {
                        if (Program.AppSettings.GetSetting("CloseOnLaunch") == "True")
                        {
                            this.Close();
                        }

                        // skipping close
                    }
                }
                else
                {
                    //txt_Status.Text = "Status: Client has not been installed. Please use the update button.";
                }
            }
            else
            {
                //txt_Status.Text = "Status: Login faild plaese try again.";
            }

            LoginStatus.Close();
        }

        private void txt_Username_Click(object sender, EventArgs e)
        {
            if (txt_Username.Text == "User Name")
            {
                txt_Username.Clear();
            }

            if (Program.MCInfo.UserName != this.Text)
            {
                Program.MCInfo.LoginPassed = false;
            }
        }

        private void txt_Password_Click(object sender, EventArgs e)
        {
            if (txt_Password.Text == "Password")
            {
                txt_Password.Clear();
            }
        }

        private void MainLite_Load(object sender, EventArgs e)
        {
            // bind the profile box to the profil selector
            CB_Config.Items.AddRange(Program.Profiles.ToArray());

            DSHelpper.FileStuctureCheck CheckFiles = new DSHelpper.FileStuctureCheck();

            if (Program.CurrentVersion != Program.CheckVersion())
            {
                this.Text = "DS Launcher - Client is out of date";
            }

            if (CheckFiles.Check() == false)
            {
                this.Text = "DS Launcher - not been installed correclty.";

            }

            if (string.IsNullOrEmpty(Program.AppSettings.GetSetting("LastLogin")) == false)
            {
                txt_Username.Text = Program.AppSettings.GetSetting("LastLogin");
                txt_Password.Clear();
            }

            webBrowser1.Url = new Uri(Program.NewsURL);
        }

        private void MainLite_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.AppSettings.SaveSettingsFile();
        }

        private void btn_Settings_Click(object sender, EventArgs e)
        {
            //if (Configure == null)
            {
                Configure = new SettingsMenu();
                Configure.ShowDialog();
                
            }
        }

        private void txt_Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && string.IsNullOrEmpty(txt_Username.Text) == false)
            {
                btn_launch_Click(sender, null);
            }
        }

        private void txt_Status_TextChanged(object sender, EventArgs e)
        {

        }

        private void CB_Config_SelectedIndexChanged(object sender, EventArgs e)
        {
            MCHelper.Profile CurrentProfile = (MCHelper.Profile)CB_Config.SelectedItem;

            if (CurrentProfile.Type == MCHelper.GameType.Minecraft)
            {
                btn_Settings.Enabled = true;
            }
            else
            {
                btn_Settings.Enabled = false;
            }

            if (CurrentProfile.Type == MCHelper.GameType.Information)
            {
                btn_launch.Enabled = false;
            }
            else
            {
                btn_launch.Enabled = true;
            }

            if (CurrentProfile.DescriptionURL != null)
            {
                webBrowser1.Navigate(CurrentProfile.DescriptionURL);
            }
        }
    }
}
