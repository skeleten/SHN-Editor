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
    public partial class editHeaderInfo : Form
    {
        frmMain main;
        public editHeaderInfo(frmMain frmmain)
        {
            InitializeComponent();
            main = frmmain;
            if (frmmain.file == null) this.Close();
            LoadInfo();
        }

        void LoadInfo()
        {
            txtCryptHeader.Text = main.file.GetCryptString();
            txtHeader.Text = main.file.Header.ToString();
            try
            {
               lblAttempt.Text = "Decryption: " + ToStringFromAscii(main.file.CryptHeader);
            }
            catch { }
        }

        private static String ToStringFromAscii(byte[] bytes)
        {
            char[] ret = new char[bytes.Length];
            for (int x = 0; x < bytes.Length; x++)
            {
                if (bytes[x] < 32 && bytes[x] >= 0)
                {
                    ret[x] = '.';
                }
                else
                {
                    int chr = ((short)bytes[x]) & 0xFF;
                    ret[x] = (char)chr;
                }
            }
            return new String(ret);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEditFileProps_Load(object sender, EventArgs e)
        {
            
        }

        private void btnEditCrypt_Click(object sender, EventArgs e)
        {
            try
            {
                main.file.SetCryptHeader(txtCryptHeader.Text);
                LoadInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnChangeHeader_Click(object sender, EventArgs e)
        {
            try
            {
                main.file.Header = uint.Parse(txtHeader.Text);
                main.SQLStatus.Text = "Header changed!";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
