namespace LaunchDS
{
    partial class MainLite
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainLite));
            this.btn_launch = new System.Windows.Forms.Button();
            this.txt_Username = new System.Windows.Forms.TextBox();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.btn_Update = new System.Windows.Forms.Button();
            this.txt_Status = new System.Windows.Forms.TextBox();
            this.btn_Settings = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.CB_Config = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btn_launch
            // 
            this.btn_launch.Location = new System.Drawing.Point(658, 357);
            this.btn_launch.Name = "btn_launch";
            this.btn_launch.Size = new System.Drawing.Size(75, 23);
            this.btn_launch.TabIndex = 0;
            this.btn_launch.Text = "Launch";
            this.btn_launch.UseVisualStyleBackColor = true;
            this.btn_launch.Click += new System.EventHandler(this.btn_launch_Click);
            // 
            // txt_Username
            // 
            this.txt_Username.Location = new System.Drawing.Point(13, 360);
            this.txt_Username.Name = "txt_Username";
            this.txt_Username.Size = new System.Drawing.Size(100, 20);
            this.txt_Username.TabIndex = 1;
            this.txt_Username.Text = "User Name";
            this.txt_Username.Click += new System.EventHandler(this.txt_Username_Click);
            // 
            // txt_Password
            // 
            this.txt_Password.Location = new System.Drawing.Point(119, 360);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.PasswordChar = '*';
            this.txt_Password.Size = new System.Drawing.Size(100, 20);
            this.txt_Password.TabIndex = 2;
            this.txt_Password.Text = "Password";
            this.txt_Password.Click += new System.EventHandler(this.txt_Password_Click);
            this.txt_Password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Password_KeyDown);
            // 
            // btn_Update
            // 
            this.btn_Update.Location = new System.Drawing.Point(577, 357);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(75, 23);
            this.btn_Update.TabIndex = 3;
            this.btn_Update.Text = "Update";
            this.btn_Update.UseVisualStyleBackColor = true;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // txt_Status
            // 
            this.txt_Status.Location = new System.Drawing.Point(369, 358);
            this.txt_Status.Name = "txt_Status";
            this.txt_Status.ReadOnly = true;
            this.txt_Status.Size = new System.Drawing.Size(121, 20);
            this.txt_Status.TabIndex = 5;
            this.txt_Status.Text = "Status: Client Good";
            this.txt_Status.TextChanged += new System.EventHandler(this.txt_Status_TextChanged);
            // 
            // btn_Settings
            // 
            this.btn_Settings.Location = new System.Drawing.Point(496, 357);
            this.btn_Settings.Name = "btn_Settings";
            this.btn_Settings.Size = new System.Drawing.Size(75, 23);
            this.btn_Settings.TabIndex = 7;
            this.btn_Settings.Text = "Settings";
            this.btn_Settings.UseVisualStyleBackColor = true;
            this.btn_Settings.Click += new System.EventHandler(this.btn_Settings_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(13, 12);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(720, 339);
            this.webBrowser1.TabIndex = 8;
            this.webBrowser1.Url = new System.Uri("http://google.com", System.UriKind.Absolute);
            // 
            // CB_Config
            // 
            this.CB_Config.FormattingEnabled = true;
            this.CB_Config.Location = new System.Drawing.Point(226, 360);
            this.CB_Config.Name = "CB_Config";
            this.CB_Config.Size = new System.Drawing.Size(121, 21);
            this.CB_Config.TabIndex = 9;
            // 
            // MainLite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 390);
            this.Controls.Add(this.CB_Config);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.btn_Settings);
            this.Controls.Add(this.txt_Status);
            this.Controls.Add(this.btn_Update);
            this.Controls.Add(this.txt_Password);
            this.Controls.Add(this.txt_Username);
            this.Controls.Add(this.btn_launch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainLite";
            this.Text = "DS Launcher Lite";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainLite_FormClosing);
            this.Load += new System.EventHandler(this.MainLite_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_launch;
        private System.Windows.Forms.TextBox txt_Username;
        private System.Windows.Forms.TextBox txt_Password;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.TextBox txt_Status;
        private System.Windows.Forms.Button btn_Settings;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.ComboBox CB_Config;
    }
}