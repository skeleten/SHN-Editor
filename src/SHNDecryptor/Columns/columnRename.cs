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
    public partial class columnRename : Form
    {
        frmMain mainfrm;
        public columnRename(frmMain main)
        {
            mainfrm = main;
            InitializeComponent();
        }

        private void RenameBox_Load(object sender, EventArgs e)
        {

        }

        public void init()
        {
            if (mainfrm.file.table == null) return;
            comboBox1.Items.Clear();
            for (int i = 0; i < mainfrm.file.table.Columns.Count; i++)
            {
                comboBox1.Items.Add(mainfrm.file.table.Columns[i].ColumnName);
            }
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                mainfrm.file.EditColumnName(comboBox1.Text, textBox1.Text);
                mainfrm.SQLStatus.Text = "Changed '" + comboBox1.Text + "' to '" + textBox1.Text + "'";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //this.Close();
        }


    }
}
