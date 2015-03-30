using System.Windows.Forms;
namespace DSMinecraft
{
    partial class Updating
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

        //protected override void OnPaintBackground(PaintEventArgs e)
        //{
        //    //empty implementation<
        //}

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Updating));
            this.PicMMC = new System.Windows.Forms.PictureBox();
            this.PicOther = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PicMMC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicOther)).BeginInit();
            this.SuspendLayout();
            // 
            // PicMMC
            // 
            this.PicMMC.BackColor = System.Drawing.SystemColors.Control;
            this.PicMMC.Image = ((System.Drawing.Image)(resources.GetObject("PicMMC.Image")));
            this.PicMMC.Location = new System.Drawing.Point(12, 12);
            this.PicMMC.Name = "PicMMC";
            this.PicMMC.Size = new System.Drawing.Size(600, 200);
            this.PicMMC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PicMMC.TabIndex = 0;
            this.PicMMC.TabStop = false;
            // 
            // PicOther
            // 
            this.PicOther.Image = ((System.Drawing.Image)(resources.GetObject("PicOther.Image")));
            this.PicOther.Location = new System.Drawing.Point(13, 13);
            this.PicOther.Name = "PicOther";
            this.PicOther.Size = new System.Drawing.Size(599, 199);
            this.PicOther.TabIndex = 1;
            this.PicOther.TabStop = false;
            this.PicOther.Click += new System.EventHandler(this.PicOther_Click);
            // 
            // Updating
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 218);
            this.Controls.Add(this.PicOther);
            this.Controls.Add(this.PicMMC);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Updating";
            this.Text = "Updating";
            ((System.ComponentModel.ISupportInitialize)(this.PicMMC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicOther)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PicMMC;
        private PictureBox PicOther;
    }
}