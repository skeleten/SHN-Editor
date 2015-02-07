using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace SHNDecrypt
{
    public partial class columnBulkEdit : Form
    {
        frmMain frmColBulkEdit;
        public columnBulkEdit(frmMain form)
        {
            frmColBulkEdit = form;
            InitializeComponent();
        }

        private void ColMultiplier_Load(object sender, EventArgs e)
        {
            if (frmColBulkEdit.file == null)
            {
                this.Close();
                return;
            }
            init();
        }

        public void init()
        {
            if (frmColBulkEdit.file.table == null) return;
            comboBox1.Items.Clear();
            for (int i = 0; i < frmColBulkEdit.file.table.Columns.Count; i++)
            {
                comboBox1.Items.Add(frmColBulkEdit.file.table.Columns[i].ColumnName);
            }
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int colIndex = frmColBulkEdit.file.getColIndex(comboBox1.Items[comboBox1.SelectedIndex].ToString());
            if (colIndex < 0) return;

            if (checkBox1.Checked != true)
            {
                for (int i = 0; i < frmColBulkEdit.file.table.Rows.Count; i++)
                {
                    try
                    {
                        frmColBulkEdit.file.table.Rows[i][colIndex] = txtBulk.Text;
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); break; }
                }
            }
            else
            {
                if (frmColBulkEdit.dataGrid.SelectedRows.Count != 0)
                {
                    foreach (DataGridViewRow r in frmColBulkEdit.dataGrid.SelectedRows)
                    {
                        try
                        {
                            frmColBulkEdit.file.table.Rows[r.Index][colIndex] = txtBulk.Text;
                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message); break; }
                    }
                }
                else 
                {
                    MessageBox.Show("Please select the appropriate rows to modify.");
                    frmColBulkEdit.SQLStatus.Text = "Please select the appropriate rows to modify."; 
                }
            }
            //this.Close();
            frmColBulkEdit.SQLStatus.Text = comboBox1.SelectedItem.ToString() + " column values have been set to \"" + txtBulk.Text + "\".";
        }

    }
}
