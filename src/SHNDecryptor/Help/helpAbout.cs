using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SHNDecrypt
{
    public partial class helpAbout : Form
    {
        public helpAbout()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {
            textBox2.Text = "® " + System.DateTime.Now.Year;
            textBox3.Text = Application.ProductVersion;
        }

    }
}
