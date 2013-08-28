namespace LaunchDS
{
    partial class Tools
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tools));
            this.btn_mcedit = new System.Windows.Forms.Button();
            this.btn_rhelp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_mcedit
            // 
            this.btn_mcedit.Location = new System.Drawing.Point(106, 12);
            this.btn_mcedit.Name = "btn_mcedit";
            this.btn_mcedit.Size = new System.Drawing.Size(75, 23);
            this.btn_mcedit.TabIndex = 0;
            this.btn_mcedit.Text = "McEdit";
            this.btn_mcedit.UseVisualStyleBackColor = true;
            this.btn_mcedit.Click += new System.EventHandler(this.btn_mcedit_Click);
            // 
            // btn_rhelp
            // 
            this.btn_rhelp.Location = new System.Drawing.Point(12, 12);
            this.btn_rhelp.Name = "btn_rhelp";
            this.btn_rhelp.Size = new System.Drawing.Size(88, 23);
            this.btn_rhelp.TabIndex = 1;
            this.btn_rhelp.Text = "Remote Help";
            this.btn_rhelp.UseVisualStyleBackColor = true;
            this.btn_rhelp.Click += new System.EventHandler(this.btn_rhelp_Click);
            // 
            // Tools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(191, 44);
            this.Controls.Add(this.btn_rhelp);
            this.Controls.Add(this.btn_mcedit);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Tools";
            this.Text = "Tools";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_mcedit;
        private System.Windows.Forms.Button btn_rhelp;
    }
}