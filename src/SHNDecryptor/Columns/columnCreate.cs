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
    public partial class columnCreate : Form
    {
        frmMain mainfrm;
        public columnCreate(frmMain main)
        {
            mainfrm = main;
            InitializeComponent();
        }

        public void init()
        {
            if (mainfrm.file.table == null) return;
            txtInfo.Text = mainfrm.file.table.Rows.Count - 1 + " cell(s) will be created.";
            // 26 = string (non fixed len)
            // 3 = uint
            // 1 = byte
            // 2 = ushort
            // 13 = short
            // 24 = string (fixed len)
            cmbTypes.Items.Clear();
            cmbTypes.Items.Add("24: String (Enter Length)");
            cmbTypes.Items.Add("13: Short");
            cmbTypes.Items.Add("03: uInt");
            cmbTypes.Items.Add("02: uShort");
            cmbTypes.Items.Add("01: Byte");
            cmbTypes.SelectedIndex = cmbTypes.Items.Count - 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int len = int.Parse(txtLen.Text);
                if (len < 0)
                {
                    MessageBox.Show("Please enter a valid length");
                    return;
                }
                mainfrm.file.CreateColumn(txtColName.Text, len, uint.Parse(cmbTypes.Text.Substring(0, 2)), txtDefault.Text);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }         
        }

        public int GetDefLen(int type)
        {
            switch (type)
            {
                default:
                    return -1;
                case 13:
                    return 2;
                case 3:
                    return 4;
                case 2:
                    return 2;
                case 1:
                    return 1;    
            }
        }

        private void cmbTypes_TextChanged(object sender, EventArgs e)
        {
            byte type = byte.Parse(cmbTypes.Text.Substring(0, 2));
            txtLen.Text = GetDefLen(type).ToString();
        }
    }
}
