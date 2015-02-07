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
    public partial class createRow : Form
    {
        frmMain main;
        public createRow(frmMain form)
        {
            InitializeComponent();
            main = form;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.TextLength >= 1)
            {
                textBox2.Enabled = false;
            }
            else
            {
                textBox2.Enabled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.TextLength > 0)
            {
                textBox1.Enabled = false;
            }
            else
            {
                textBox1.Enabled = true;
            }
        }

        private void AddARow(DataTable table)
        {
            DataRow newRow = table.NewRow();
            table.Rows.Add(newRow);
        }

        private void CopyRows(DataGridView dataGrid, int SourceRowID, int DestinationRowID)
        {
            for (int x = 0; x < dataGrid.Rows[SourceRowID].Cells.Count; x++)
            {
                dataGrid.Rows[DestinationRowID].Cells[x].Value = dataGrid.Rows[SourceRowID].Cells[x].Value;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (main.file == null) return;
            if (main.dataGrid == null) return;

            if (textBox1.TextLength == 0 & textBox2.TextLength == 0)
            {
                AddARow(main.file.table);
                main.dataGrid.CurrentCell = main.dataGrid[0, main.file.table.Rows.Count - 1];
                main.dataGrid.Rows[main.file.table.Rows.Count - 1].Selected = true;
            }
            else if (textBox1.TextLength > 0)
            {
                DataRow row = main.file.table.NewRow();
                if (main.dataGrid.Rows[main.dataGrid.NewRowIndex].Selected == true)
                {
                    main.dataGrid.CurrentCell = main.dataGrid.Rows[main.file.table.Rows.Count - 1].Cells[0];
                }
                for (int iw = 0; iw < main.file.table.Columns.Count; iw++)
                {
                    string internalName = main.file.table.Columns[iw].ColumnName;
                    try
                    {
                            row[iw] = textBox1.Text;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An unknown error occured: " + Environment.NewLine + ex.Message);
                        main.SQLStatus.Text = "Clipboard has wrong type of data.";
                        break;
                    }

                }
                main.file.table.Rows.Add(row);
                main.dataGrid.CurrentCell = main.dataGrid[0, main.file.table.Rows.Count - 1];
                main.dataGrid.Rows[main.file.table.Rows.Count - 1].Selected = true;
            }
            else if (textBox2.TextLength > 0)
            {
                int selectedRow = Convert.ToInt32(textBox2.Text);

                if (selectedRow < main.file.table.Rows.Count)
                {
                    AddARow(main.file.table);
                    CopyRows(main.dataGrid, selectedRow, main.file.table.Rows.Count - 1);
                    main.dataGrid.CurrentCell = main.dataGrid[0, main.file.table.Rows.Count - 1];
                    main.dataGrid.Rows[main.file.table.Rows.Count - 1].Selected = true;
                }
            }
        }
    }
}
