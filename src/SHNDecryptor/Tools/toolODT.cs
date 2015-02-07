using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SHNDecrypt
{
    public partial class OPToolEditor : Form
    {
        string extension = "";
        public OPToolEditor(frmMain frm, byte[] data, string ext)
        {
            InitializeComponent();
            if (data.Length < 10) return;
            txtSettings.Text = System.Text.Encoding.ASCII.GetString(data);
            extension = ext;
            this.Text = extension.ToUpper() + " Editor";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog x = new SaveFileDialog();
            x.Filter = "File (*" + extension+ ")|*" + extension + "|Any file(*.*)|*.*";
            x.Title = "Save file";
            if (!(x.ShowDialog() == DialogResult.OK)) return;
            byte[] newdata = System.Text.Encoding.ASCII.GetBytes(txtSettings.Text);
            Decrypt(newdata, 0, newdata.Length);
             BinaryWriter w = new BinaryWriter(File.Create(x.FileName));
             w.Write(newdata);
             w.Close();
        }


        private void Decrypt(byte[] data, int index, int length)
        {
            if (((index < 0) | (length < 1)) | ((index + length) > data.Length))
            {
                throw new IndexOutOfRangeException();
            }
            byte num = (byte)length;
            for (int i = length - 1; i >= 0; i--)
            {
                data[i] = (byte)(data[i] ^ num);
                byte num3 = (byte)i;
                num3 = (byte)(num3 & 15);
                num3 = (byte)(num3 + 0x55);
                num3 = (byte)(num3 ^ ((byte)(((byte)i) * 11)));
                num3 = (byte)(num3 ^ num);
                num3 = (byte)(num3 ^ 170);
                num = num3;
            }
        }

        private void btnReplc_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you would like to complete this action?\r\nReplace ' " + txtFrom.Text + " ' with ' " + txtWith.Text + " '", "SHN", MessageBoxButtons.YesNo);
            if (result == DialogResult.No) return;
            String NewText = txtSettings.Text.Replace(txtFrom.Text, txtWith.Text);
            txtSettings.Text = NewText;
        }

        private void openTXTToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog x = new OpenFileDialog();
            x.Title = "Open file";
            if (!(x.ShowDialog() == DialogResult.OK)) return;
            StreamReader streamReader = new StreamReader(x.FileName);
            txtSettings.Text = streamReader.ReadToEnd();
            streamReader.Close();

        }

        private void saveTXTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog lol = new SaveFileDialog();
            lol.Title = "Save file";
            lol.Filter = "Text (*.txt)|*.txt";
            if (!(lol.ShowDialog() == DialogResult.OK)) return;
            TextWriter tw = new StreamWriter(lol.FileName);
            tw.Write(txtSettings.Text);
            tw.Close();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtWith_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnReplc.PerformClick();
                e.SuppressKeyPress = true;
            }
        }
    }
}
