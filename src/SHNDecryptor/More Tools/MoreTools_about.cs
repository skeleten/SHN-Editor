using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SHNDecrypt.More_Tools
{
    public partial class MoreTools_about : Form
    {
        public MoreTools_about()
        {
            InitializeComponent();
        }

        private void MoreTools_about_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = "More Tools was made by tikai @ ragezone.com\n\n";
            richTextBox1.Text += "Feel free to PM me if anything's acting funny or if there are new features I could add.\n\n";
            richTextBox1.Text += "Thanks CSharp, Skeleten, MrFarbodD, & others for the work put into this program and for making it open source.\n\n";
            richTextBox1.Text += "All those years of me being spoonfed by the community, now maybe I can give a little something back, starting today.";
            label1.Text = "To make the experience building your own Isya\njust a little bit easier~";
        }
    }
}
