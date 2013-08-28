namespace LaunchDS
{
    partial class SettingsMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsMenu));
            this.txt_Min = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Max = new System.Windows.Forms.TextBox();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Cancle = new System.Windows.Forms.Button();
            this.txt_JavaPath = new System.Windows.Forms.TextBox();
            this.lbl_JavaPath = new System.Windows.Forms.Label();
            this.btn_JavaPath = new System.Windows.Forms.Button();
            this.chk_CloseOnLaunch = new System.Windows.Forms.CheckBox();
            this.chk_ClassicLaunch = new System.Windows.Forms.CheckBox();
            this.lbl_addons = new System.Windows.Forms.Label();
            this.lst_Addons = new System.Windows.Forms.ListView();
            this.btn_InstallAddon = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_Min
            // 
            this.txt_Min.Location = new System.Drawing.Point(73, 6);
            this.txt_Min.Name = "txt_Min";
            this.txt_Min.Size = new System.Drawing.Size(48, 20);
            this.txt_Min.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Min Memory";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(138, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Max Memory";
            // 
            // txt_Max
            // 
            this.txt_Max.Location = new System.Drawing.Point(211, 6);
            this.txt_Max.Name = "txt_Max";
            this.txt_Max.Size = new System.Drawing.Size(61, 20);
            this.txt_Max.TabIndex = 3;
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(197, 227);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 4;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Cancle
            // 
            this.btn_Cancle.Location = new System.Drawing.Point(116, 227);
            this.btn_Cancle.Name = "btn_Cancle";
            this.btn_Cancle.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancle.TabIndex = 5;
            this.btn_Cancle.Text = "Cancel";
            this.btn_Cancle.UseVisualStyleBackColor = true;
            this.btn_Cancle.Click += new System.EventHandler(this.btn_Cancle_Click);
            // 
            // txt_JavaPath
            // 
            this.txt_JavaPath.Location = new System.Drawing.Point(64, 32);
            this.txt_JavaPath.Name = "txt_JavaPath";
            this.txt_JavaPath.Size = new System.Drawing.Size(127, 20);
            this.txt_JavaPath.TabIndex = 6;
            // 
            // lbl_JavaPath
            // 
            this.lbl_JavaPath.AutoSize = true;
            this.lbl_JavaPath.Location = new System.Drawing.Point(3, 35);
            this.lbl_JavaPath.Name = "lbl_JavaPath";
            this.lbl_JavaPath.Size = new System.Drawing.Size(55, 13);
            this.lbl_JavaPath.TabIndex = 7;
            this.lbl_JavaPath.Text = "Java Path";
            // 
            // btn_JavaPath
            // 
            this.btn_JavaPath.Location = new System.Drawing.Point(197, 30);
            this.btn_JavaPath.Name = "btn_JavaPath";
            this.btn_JavaPath.Size = new System.Drawing.Size(75, 23);
            this.btn_JavaPath.TabIndex = 8;
            this.btn_JavaPath.Text = "Find Path";
            this.btn_JavaPath.UseVisualStyleBackColor = true;
            this.btn_JavaPath.Click += new System.EventHandler(this.btn_JavaPath_Click);
            // 
            // chk_CloseOnLaunch
            // 
            this.chk_CloseOnLaunch.AutoSize = true;
            this.chk_CloseOnLaunch.Location = new System.Drawing.Point(6, 58);
            this.chk_CloseOnLaunch.Name = "chk_CloseOnLaunch";
            this.chk_CloseOnLaunch.Size = new System.Drawing.Size(108, 17);
            this.chk_CloseOnLaunch.TabIndex = 10;
            this.chk_CloseOnLaunch.Text = "Close On Launch";
            this.chk_CloseOnLaunch.UseVisualStyleBackColor = true;
            this.chk_CloseOnLaunch.CheckedChanged += new System.EventHandler(this.chk_CloseOnLaunch_CheckedChanged);
            // 
            // chk_ClassicLaunch
            // 
            this.chk_ClassicLaunch.AutoSize = true;
            this.chk_ClassicLaunch.Location = new System.Drawing.Point(121, 58);
            this.chk_ClassicLaunch.Name = "chk_ClassicLaunch";
            this.chk_ClassicLaunch.Size = new System.Drawing.Size(98, 17);
            this.chk_ClassicLaunch.TabIndex = 11;
            this.chk_ClassicLaunch.Text = "Classic Launch";
            this.chk_ClassicLaunch.UseVisualStyleBackColor = true;
            this.chk_ClassicLaunch.CheckedChanged += new System.EventHandler(this.chk_ClassicLaunch_CheckedChanged);
            // 
            // lbl_addons
            // 
            this.lbl_addons.AutoSize = true;
            this.lbl_addons.Location = new System.Drawing.Point(6, 82);
            this.lbl_addons.Name = "lbl_addons";
            this.lbl_addons.Size = new System.Drawing.Size(43, 13);
            this.lbl_addons.TabIndex = 14;
            this.lbl_addons.Text = "Addons";
            // 
            // lst_Addons
            // 
            this.lst_Addons.Location = new System.Drawing.Point(6, 99);
            this.lst_Addons.Name = "lst_Addons";
            this.lst_Addons.Size = new System.Drawing.Size(266, 122);
            this.lst_Addons.TabIndex = 15;
            this.lst_Addons.UseCompatibleStateImageBehavior = false;
            // 
            // btn_InstallAddon
            // 
            this.btn_InstallAddon.Location = new System.Drawing.Point(6, 227);
            this.btn_InstallAddon.Name = "btn_InstallAddon";
            this.btn_InstallAddon.Size = new System.Drawing.Size(97, 23);
            this.btn_InstallAddon.TabIndex = 16;
            this.btn_InstallAddon.Text = "Install Addon";
            this.btn_InstallAddon.UseVisualStyleBackColor = true;
            this.btn_InstallAddon.Click += new System.EventHandler(this.btn_InstallAddon_Click);
            // 
            // SettingsMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.ControlBox = false;
            this.Controls.Add(this.btn_InstallAddon);
            this.Controls.Add(this.lst_Addons);
            this.Controls.Add(this.lbl_addons);
            this.Controls.Add(this.chk_ClassicLaunch);
            this.Controls.Add(this.chk_CloseOnLaunch);
            this.Controls.Add(this.btn_JavaPath);
            this.Controls.Add(this.lbl_JavaPath);
            this.Controls.Add(this.txt_JavaPath);
            this.Controls.Add(this.btn_Cancle);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.txt_Max);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_Min);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsMenu";
            this.Load += new System.EventHandler(this.SettingsMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Min;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Max;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Cancle;
        private System.Windows.Forms.TextBox txt_JavaPath;
        private System.Windows.Forms.Label lbl_JavaPath;
        private System.Windows.Forms.Button btn_JavaPath;
        private System.Windows.Forms.CheckBox chk_CloseOnLaunch;
        private System.Windows.Forms.CheckBox chk_ClassicLaunch;
        private System.Windows.Forms.Label lbl_addons;
        private System.Windows.Forms.ListView lst_Addons;
        private System.Windows.Forms.Button btn_InstallAddon;
    }
}