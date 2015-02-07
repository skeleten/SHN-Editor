using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace SHNDecrypt
{
    public partial class searchReplace : Form
    {
        frmMain searchRep;
        bool MatchFound = false;
        int I = -1;
        string currentTab;
        public searchReplace(frmMain form)
        {
            searchRep = form;
            InitializeComponent();
        }

        private void searchReplace_Load(object sender, EventArgs e)
        {
            if (searchRep.file == null)
            {
                this.Close();
                return;
            }
            currentTab = searchRep.FileTab.SelectedTab.Text;
            init();
        }

        public void init()
        {
            if (searchRep.file.table == null) return;
            cmbColumn.Items.Clear();
            for (int i = 0; i < searchRep.file.table.Columns.Count; i++)
            {
                cmbColumn.Items.Add(searchRep.file.table.Columns[i].ColumnName);
            }
            cmbColumn.SelectedIndex = 0;
        }

        public void replace()
        {
            try
            {
                if (searchRep.dataGrid.Rows[I].Cells[cmbColumn.SelectedIndex].Value.ToString().ToLower().Contains(txtFind.Text.ToLower()))
                {
                    string cellText = searchRep.dataGrid.CurrentCell.Value.ToString();
                    searchRep.dataGrid.CurrentCell.Value = Regex.Replace(cellText, txtFind.Text, txtReplaceWith.Text, RegexOptions.IgnoreCase);
                }
            }
            catch (IndexOutOfRangeException) { }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void searchReplace_Activated(object sender, EventArgs e)
        {
            this.Opacity = 1.0;
            if (searchRep.FileTab.SelectedTab.Text != currentTab)
            {
                init();
            }
        }

        private void searchReplace_Deactivate(object sender, EventArgs e)
        {
            this.Opacity = 0.7;
        }

        private void btnFindNext_Click(object sender, EventArgs e)
        {
            MatchFound = false;
            if (I != -1) { I = searchRep.dataGrid.CurrentCell.RowIndex; }
            do
            {
                if (txtFind.Text.Length == 0)
                {
                    MessageBox.Show("Please enter a search phrase.");
                    break;
                }
                I += 1;
                try
                {
                    if (I >= searchRep.dataGrid.Rows.Count - 1)
                    {
                        if (searchRep.dataGrid.CurrentCell.RowIndex >= 1)
                        {
                            MessageBox.Show("There are no more items found containing '" + txtFind.Text + "'");
                        }
                        else if (searchRep.dataGrid.CurrentCell.RowIndex <= 0)
                        {
                            MessageBox.Show("There were no items which contain '" + txtFind.Text + "'");
                        }
                        I = -1;
                        searchRep.dataGrid.CurrentCell = searchRep.dataGrid.Rows[0].Cells[0];
                        break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An exception occurred:" + "\r\n" + ex.Message);
                    break;
                }
                if (searchRep.dataGrid.Rows[I].Cells[cmbColumn.SelectedIndex].Value.ToString().ToLower().Contains(txtFind.Text.ToLower()))
                {
                    searchRep.dataGrid.CurrentCell = searchRep.dataGrid.Rows[I].Cells[cmbColumn.SelectedIndex];
                    MatchFound = true;
                    break;
                }
            }
            while (!MatchFound);
        }

        private void txtFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnFindNext.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            if (I != -1)
            {
                replace();
                btnFindNext.PerformClick();
            }
            else
            {
                btnFindNext.PerformClick();
                replace();
            }
        }

        private void cmbColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentTab = searchRep.FileTab.SelectedTab.Text;
        }

        private void btnReplaceAll_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked != true)
            {
                searchRep.dataGrid.CurrentCell = searchRep.dataGrid.Rows[0].Cells[0];

                for (int currentRow = 0; currentRow < searchRep.file.table.Rows.Count - 1; currentRow++)
                {
                    if (searchRep.dataGridError == false)
                    {
                        if (searchRep.dataGrid.Rows[currentRow].Cells[cmbColumn.SelectedIndex].Value.ToString().ToLower().Contains(txtFind.Text.ToLower()))
                        {
                            string theCellValue = searchRep.dataGrid.Rows[currentRow].Cells[cmbColumn.SelectedIndex].Value.ToString();
                            string newValue = Regex.Replace(theCellValue, txtFind.Text, txtReplaceWith.Text, RegexOptions.IgnoreCase);
                            searchRep.dataGrid.Rows[currentRow].Cells[cmbColumn.SelectedIndex].Value = newValue;
                        }
                    }
                    else { break; }
                }
            }
            else
            {
                if (searchRep.dataGrid.SelectedRows.Count != 0)
                {
                    foreach (DataGridViewRow r in searchRep.dataGrid.SelectedRows)
                    {
                        if (searchRep.dataGridError == false)
                        {
                            if (searchRep.dataGrid.Rows[r.Index].Cells[cmbColumn.SelectedIndex].Value.ToString().ToLower().Contains(txtFind.Text.ToLower()))
                            {
                                string theCellValue = searchRep.dataGrid.Rows[r.Index].Cells[cmbColumn.SelectedIndex].Value.ToString();
                                string newValue = Regex.Replace(theCellValue, txtFind.Text, txtReplaceWith.Text, RegexOptions.IgnoreCase);
                                searchRep.dataGrid.Rows[r.Index].Cells[cmbColumn.SelectedIndex].Value = newValue;
                            }
                        }
                        else { break; }
                    }
                }
                else
                {
                    MessageBox.Show("Please select the appropriate rows to replace all values in.");
                    searchRep.SQLStatus.Text = "Please select the appropriate rows to replace all values in.";
                }
            }
            searchRep.SQLStatus.Text = "Replace completed.";
        }
    }
}
