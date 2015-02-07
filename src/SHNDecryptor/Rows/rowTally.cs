using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SHNDecrypt
{
    public partial class rowTally : Form
    {
        SHNFile original;
        frmMain mainRT;

        public rowTally(frmMain main)
        {
            InitializeComponent();
            this.mainRT = main;
            if (main.file == null)
            {
                this.Close();
                return;
            }
            original = main.file;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void rowTally_Load(object sender, EventArgs e)
        {            
            columnsCB.Items.Clear();
            for (int i = 0; i < original.table.Columns.Count; i++)
            {
                columnsCB.Items.Add(original.table.Columns[i].ColumnName);
            }
            columnsCB.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            if (original == null) return;
            if (columnsCB.SelectedItem == null) { MessageBox.Show("Please select a column."); return; }
            String RowCount = (original.table.Rows.Count - 1).ToString();
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to recount the rows in this column? (" + textBox1.Text + " - " + RowCount + ")", "Row Recount", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dialogResult == DialogResult.Yes)
            {
                if (original.table.Rows.Count > 0)
                {
                    try
                    {
                        if (original.table.Columns[columnsCB.SelectedItem.ToString()].ToString().Equals(columnsCB.SelectedItem.ToString()))
                        {
                            for (int i = Convert.ToInt32(textBox1.Text); i < original.table.Rows.Count; i++)
                            {
                                DataRow row = original.table.Rows[i];
                                row[columnsCB.SelectedItem.ToString()] = i;
                            }
                        }
                    }
                    catch (NullReferenceException)
                    {
                        MessageBox.Show("Could not find the selected column.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An unknown error occured: " + Environment.NewLine + ex.Message);
                    }
                }
            }
        }
    }
}
