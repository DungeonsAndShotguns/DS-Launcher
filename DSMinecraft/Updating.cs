using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DSMinecraft
{
    public partial class Updating : Form
    {
        public bool MultiMC = true;

        public Updating()
        {
            //BackColor = Color.LimeGreen;
            //TransparencyKey = Color.LimeGreen;
            //FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            InitializeComponent();
        }

        private void Lbl_Status_Click(object sender, EventArgs e)
        {

        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //empty implementation<
            if(MultiMC == false)
            {
                PicMMC.Visible = false;
                PicOther.Visible = true;
            }
            else
            {
                PicMMC.Visible = true;
                PicOther.Visible = false;
            }
        }

        private void PicOther_Click(object sender, EventArgs e)
        {

        }
    }
}
