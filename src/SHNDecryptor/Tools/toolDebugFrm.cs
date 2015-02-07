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
    public partial class DebugFrm : Form
    {
        frmMain mainfrm;
        public DebugFrm(frmMain main)
        {
            this.mainfrm = main;
            InitializeComponent();
        }

        private void DebugFrm_Load(object sender, EventArgs e)
        {

        }

        void doActions(int num1, int num2)
        {
            try
            {
                txtDebug.Text = string.Empty;
                for (int i = 0; i < mainfrm.file.table.Rows.Count; i++)
                {
                    txtDebug.Text += mainfrm.file.table.Rows[i][num1].ToString() + " - " + mainfrm.file.table.Rows[i][num2].ToString() + "\r\n";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                int col1 = int.Parse(txt1.Text);
                int col2 = int.Parse(txt2.Text);
                doActions(col1, col2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
