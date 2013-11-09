namespace DSLPackager
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbx_VersionNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbx_UpdateURL = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbx_RootDir = new System.Windows.Forms.TextBox();
            this.btn_BrowseRoot = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tbx_UpdateList = new System.Windows.Forms.TextBox();
            this.btn_BrowseUpdateList = new System.Windows.Forms.Button();
            this.btn_Compile = new System.Windows.Forms.Button();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Version Number";
            // 
            // tbx_VersionNumber
            // 
            this.tbx_VersionNumber.Location = new System.Drawing.Point(100, 10);
            this.tbx_VersionNumber.Name = "tbx_VersionNumber";
            this.tbx_VersionNumber.Size = new System.Drawing.Size(135, 20);
            this.tbx_VersionNumber.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "UpdateURL";
            // 
            // tbx_UpdateURL
            // 
            this.tbx_UpdateURL.Location = new System.Drawing.Point(101, 36);
            this.tbx_UpdateURL.Name = "tbx_UpdateURL";
            this.tbx_UpdateURL.Size = new System.Drawing.Size(286, 20);
            this.tbx_UpdateURL.TabIndex = 3;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 134);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(375, 115);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "File Black List";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Updated Folder";
            // 
            // tbx_RootDir
            // 
            this.tbx_RootDir.Location = new System.Drawing.Point(101, 62);
            this.tbx_RootDir.Name = "tbx_RootDir";
            this.tbx_RootDir.Size = new System.Drawing.Size(207, 20);
            this.tbx_RootDir.TabIndex = 7;
            // 
            // btn_BrowseRoot
            // 
            this.btn_BrowseRoot.Location = new System.Drawing.Point(314, 60);
            this.btn_BrowseRoot.Name = "btn_BrowseRoot";
            this.btn_BrowseRoot.Size = new System.Drawing.Size(75, 23);
            this.btn_BrowseRoot.TabIndex = 8;
            this.btn_BrowseRoot.Text = "Browse";
            this.btn_BrowseRoot.UseVisualStyleBackColor = true;
            this.btn_BrowseRoot.Click += new System.EventHandler(this.btn_BrowseRoot_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Update List";
            // 
            // tbx_UpdateList
            // 
            this.tbx_UpdateList.Location = new System.Drawing.Point(101, 89);
            this.tbx_UpdateList.Name = "tbx_UpdateList";
            this.tbx_UpdateList.Size = new System.Drawing.Size(207, 20);
            this.tbx_UpdateList.TabIndex = 10;
            // 
            // btn_BrowseUpdateList
            // 
            this.btn_BrowseUpdateList.Location = new System.Drawing.Point(314, 87);
            this.btn_BrowseUpdateList.Name = "btn_BrowseUpdateList";
            this.btn_BrowseUpdateList.Size = new System.Drawing.Size(75, 23);
            this.btn_BrowseUpdateList.TabIndex = 11;
            this.btn_BrowseUpdateList.Text = "Browse";
            this.btn_BrowseUpdateList.UseVisualStyleBackColor = true;
            this.btn_BrowseUpdateList.Click += new System.EventHandler(this.btn_BrowseUpdateList_Click);
            // 
            // btn_Compile
            // 
            this.btn_Compile.Location = new System.Drawing.Point(312, 7);
            this.btn_Compile.Name = "btn_Compile";
            this.btn_Compile.Size = new System.Drawing.Size(75, 23);
            this.btn_Compile.TabIndex = 12;
            this.btn_Compile.Text = "Compile";
            this.btn_Compile.UseVisualStyleBackColor = true;
            // 
            // btn_Clear
            // 
            this.btn_Clear.Location = new System.Drawing.Point(250, 8);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(58, 23);
            this.btn_Clear.TabIndex = 13;
            this.btn_Clear.Text = "Clear";
            this.btn_Clear.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 264);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.btn_Compile);
            this.Controls.Add(this.btn_BrowseUpdateList);
            this.Controls.Add(this.tbx_UpdateList);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_BrowseRoot);
            this.Controls.Add(this.tbx_RootDir);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.tbx_UpdateURL);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbx_VersionNumber);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Create DS Package";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbx_VersionNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbx_UpdateURL;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbx_RootDir;
        private System.Windows.Forms.Button btn_BrowseRoot;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbx_UpdateList;
        private System.Windows.Forms.Button btn_BrowseUpdateList;
        private System.Windows.Forms.Button btn_Compile;
        private System.Windows.Forms.Button btn_Clear;
    }
}