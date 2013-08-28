namespace LaunchDS
{
    partial class UpdateProgress
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateProgress));
            this.lbl_UpdateStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_UpdateStatus
            // 
            this.lbl_UpdateStatus.AutoSize = true;
            this.lbl_UpdateStatus.Location = new System.Drawing.Point(13, 13);
            this.lbl_UpdateStatus.Name = "lbl_UpdateStatus";
            this.lbl_UpdateStatus.Size = new System.Drawing.Size(92, 13);
            this.lbl_UpdateStatus.TabIndex = 0;
            this.lbl_UpdateStatus.Text = "Click here to start.";
            this.lbl_UpdateStatus.Click += new System.EventHandler(this.UpdateProgress_Click);
            // 
            // UpdateProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 48);
            this.Controls.Add(this.lbl_UpdateStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateProgress";
            this.Text = "Updating DS Minecraft";
            this.Activated += new System.EventHandler(this.UpdateProgress_Activated);
            this.Load += new System.EventHandler(this.UpdateProgress_Load);
            this.Shown += new System.EventHandler(this.UpdateProgress_Shown);
            this.Click += new System.EventHandler(this.UpdateProgress_Click);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UpdateProgress_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_UpdateStatus;
    }
}