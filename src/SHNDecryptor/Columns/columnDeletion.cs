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
    public partial class columnDeletion : Form
    {
        frmMain mainfrm;
        public columnDeletion(frmMain main)
        {
            this.mainfrm = main;
            InitializeComponent();
        }

        public void init()
        {
            if (mainfrm.file.table == null) return;
            comboBox1.Items.Clear();
            
            for (int i = 0; i < mainfrm.file.table.Columns.Count; i++)
            {
                comboBox1.Items.Add(mainfrm.file.table.Columns[i].ColumnName);
                txtList.Text += mainfrm.file.table.Columns[i].ColumnName + "\r\n";
            }

            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this column? It can't be undone!", "SHN", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes) mainfrm.file.DeleteColumn(comboBox1.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //this.Close();
        }
    }
}
