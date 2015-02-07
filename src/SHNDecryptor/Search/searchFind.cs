using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace SHNDecrypt
{
    public partial class searchFind : Form
    {
        frmMain frmParent;
        Dictionary<int, int> originIndex = new Dictionary<int, int>(); //this, other
        int horizontalScrollOffset;
        int verticalScrollOffset;
        int previouslySelectedRow;
        int previouslySelectedColumn;

        public searchFind(frmMain Handle)
        {
            frmParent = Handle;
            InitializeComponent();
            dataGrid.DoubleBuffered(true);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        private void loadSettings()
        {
            if (frmParent.file == null) return;

            cmbIn.Items.Clear();
            originIndex.Clear();
            radioContains.Checked = true;

            for (int i = 0; i < frmParent.file.table.Columns.Count; i++)
            {
                DataColumn lol = frmParent.file.table.Columns[i];
                cmbIn.Items.Add(i.ToString("00") + ": " + lol.ToString());
            }
            cmbIn.SelectedIndex = 0;
            
            bindingSource1.DataSource = frmParent.file.table.DefaultView;
            dataGrid.DataSource = bindingSource1;
            frmParent.dataGrid.DataSource = frmParent.file.table.Copy();
        }

        private void resetRadioChecks(bool checkToF = false)
        {
            Program.radioContains = checkToF;
            Program.radioEndsWith = checkToF;
            Program.radioEquals = checkToF;
            Program.radioStartsWith = checkToF;
        }

        private void setCellViewPosition()
        {
            if (previouslySelectedColumn == 0)
            {
                frmParent.dataGrid.CurrentCell = frmParent.dataGrid.Rows[previouslySelectedRow].Cells[previouslySelectedColumn];
                frmParent.dataGrid.Rows[previouslySelectedRow].Selected = true;
                frmParent.dataGrid.FirstDisplayedScrollingColumnIndex = horizontalScrollOffset;
                frmParent.dataGrid.FirstDisplayedScrollingRowIndex = verticalScrollOffset;
            }
            else
            {
                frmParent.dataGrid.CurrentCell = frmParent.dataGrid.Rows[previouslySelectedRow].Cells[previouslySelectedColumn];
                frmParent.dataGrid.FirstDisplayedScrollingColumnIndex = horizontalScrollOffset;
                frmParent.dataGrid.FirstDisplayedScrollingRowIndex = verticalScrollOffset;
            }
        }

        private void searchFind_Shown(Object Sender, EventArgs Args)
        {
            horizontalScrollOffset = frmParent.dataGrid.FirstDisplayedScrollingColumnIndex;
            verticalScrollOffset = frmParent.dataGrid.FirstDisplayedScrollingRowIndex;
            previouslySelectedRow = frmParent.dataGrid.CurrentCell.RowIndex;
            previouslySelectedColumn = frmParent.dataGrid.CurrentCell.ColumnIndex;

            loadSettings();

            if (frmParent.FileTab.SelectedTab.Text == Program.searchFile)
            {
                if (Program.searchParam0 != null)
                {
                    txtFor.Text = Program.searchParam0;
                    cmbIn.SelectedIndex = Program.searchParam1;

                    if (Program.radioEndsWith == true) { radioEndsWith.Checked = true; }
                    else if (Program.radioEquals == true) { radioEquals.Checked = true; }
                    else if (Program.radioStartsWith == true) { radioStartsWith.Checked = true; }
                    else { radioContains.Checked = true; }
                    btnSearch.PerformClick();
                    txtFor.Select(txtFor.Text.Length, 0);
                }
            }
            setCellViewPosition();
        }

        private void searchFind_Closing(Object Sender, FormClosingEventArgs e)
        {
            try
            {
                horizontalScrollOffset = frmParent.dataGrid.FirstDisplayedScrollingColumnIndex;
                verticalScrollOffset = frmParent.dataGrid.FirstDisplayedScrollingRowIndex;
                previouslySelectedRow = frmParent.dataGrid.CurrentCell.RowIndex;
                previouslySelectedColumn = frmParent.dataGrid.CurrentCell.ColumnIndex;

                if (dataGrid.DataSource != null)
                {
                    frmParent.file.table.DefaultView.RowFilter = null;
                    frmParent.dataGrid.DataSource = frmParent.file.table;
                    frmParent.file.table.DefaultView.Sort = String.Empty;
                    setCellViewPosition();
                }
                e.Cancel = true;
                this.Hide();
            }
            catch
            {
                DialogResult result = MessageBox.Show("Error saving edits, would you still like to close the form?", "SHN", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes) e.Cancel = true; this.Hide();
                frmParent.SQLStatus.Text = "Error saving search form edits.";
            }
        }

        private void btnSearch_Click(Object Sender, EventArgs Args)
        {
            Program.searchParam0 = txtFor.Text;
            Program.searchParam1 = cmbIn.SelectedIndex;
            Program.searchFile = frmParent.FileTab.SelectedTab.Text;

            string[] comboText = cmbIn.Text.Split(':');

            try
            {
                bindingSource1.RaiseListChangedEvents = true;
                bindingSource1.ResetBindings(false);

                if (String.IsNullOrEmpty(txtFor.Text))
                {
                    frmParent.file.table.DefaultView.RowFilter = null;
                }
                else
                {
                    if (radioContains.Checked) 
                    { 
                        frmParent.file.table.DefaultView.RowFilter = String.Format("Convert({0}, 'System.String') LIKE '%{1}%'", comboText[1], txtFor.Text);
                        resetRadioChecks();
                        Program.radioContains = true;
                    }
                    else if (radioEquals.Checked) 
                    { 
                        frmParent.file.table.DefaultView.RowFilter = String.Format("Convert({0}, 'System.String') = '{1}'", comboText[1], txtFor.Text);
                        resetRadioChecks();
                        Program.radioEquals = true;
                    }
                    else if (radioStartsWith.Checked) 
                    { 
                        frmParent.file.table.DefaultView.RowFilter = String.Format("Convert({0}, 'System.String') LIKE '{1}*'", comboText[1], txtFor.Text);
                        resetRadioChecks();
                        Program.radioStartsWith = true;
                    }
                    else if (radioEndsWith.Checked) 
                    { 
                        frmParent.file.table.DefaultView.RowFilter = String.Format("Convert({0}, 'System.String') LIKE '*{1}'", comboText[1], txtFor.Text);
                        resetRadioChecks();
                        Program.radioEndsWith = true;
                    }
                }

                bindingSource1.RaiseListChangedEvents = false;

                tStatus.Text = "Found " + (dataGrid.Rows.Count - 1).ToString() + " Rows.";
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnEnter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch.PerformClick();
                e.SuppressKeyPress = true;
            }

            if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true;
                this.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (frmParent.file == null) return;
            if (dataGrid == null) return;
            dataGrid.AllowUserToAddRows = false;
            MemoryStream stream = new MemoryStream();
            BinaryWriter writor = new BinaryWriter(stream);
            DataTable toCopyTo = new DataTable();
            toCopyTo = frmParent.file.table.Clone();
            var orderedRows = dataGrid.SelectedRows.Cast<DataGridViewRow>().OrderBy(row => row.Index);
            writor.Write((int)dataGrid.SelectedRows.Count);
            foreach (DataGridViewRow row in orderedRows)
            {
                try
                {
                    DataRow myRow = (row.DataBoundItem as DataRowView).Row;
                    object[] EachColumn = myRow.ItemArray;
                    writor.Write((int)EachColumn.Length);

                    for (int i = 0; i < EachColumn.Length; i++)
                    {
                        writor.Write(frmParent.file.table.Columns[i].ColumnName);
                        writor.Write(EachColumn[i].ToString());
                    }
                    writor.Write((byte)0x00);
                }
                catch (NullReferenceException NullEx)
                {
                    MessageBox.Show("You have selected an invalid row: " + Environment.NewLine + NullEx.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An unknown error has occured: " + Environment.NewLine + ex.Message);
                }
            }
            stream.Position = 0;
            byte[] toCop = new byte[stream.Length];
            stream.Read(toCop, 0, (int)stream.Length);
            Clipboard.SetData("Bytes", toCop);
            writor.Close();
            tStatus.Text = "Copied to clipboard.";
            dataGrid.AllowUserToAddRows = true;
        }

        private void dataGrid_SelectionChanged(object sender, EventArgs e)
        {
            //frmParent.dataGrid.CurrentCell = frmParent.dataGrid.Rows[dataGrid.CurrentCell.RowIndex].Cells[dataGrid.CurrentCell.ColumnIndex];
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (dataGrid.SelectedRows.Count == 1)
            {
                try
                {
                    foreach (DataGridViewRow row in frmParent.dataGrid.Rows)
                    {
                        string mainForm = frmParent.dataGrid.Rows[row.Index].Cells[0].Value.ToString();
                        string thisForm = dataGrid.Rows[dataGrid.CurrentCell.RowIndex].Cells[0].Value.ToString();
                        if (mainForm == thisForm)
                        {
                            frmParent.dataGrid.CurrentCell = frmParent.dataGrid.Rows[row.Index].Cells[0];
                            frmParent.dataGrid.Rows[row.Index].Selected = true;
                            break;
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show("Could not locate row. " + ex.Message); }
            }
            else if (dataGrid.SelectedCells.Count == 1)
            {
                try
                {
                    foreach (DataGridViewRow row in frmParent.dataGrid.Rows)
                    {
                        string mainForm = frmParent.dataGrid.Rows[row.Index].Cells[0].Value.ToString();
                        string thisForm = dataGrid.Rows[dataGrid.CurrentCell.RowIndex].Cells[0].Value.ToString();
                        if (mainForm == thisForm)
                        {
                            frmParent.dataGrid.Rows[row.Index].Selected = false;
                            frmParent.dataGrid.CurrentCell = frmParent.dataGrid.Rows[row.Index].Cells[dataGrid.CurrentCell.ColumnIndex];
                            break;
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show("Could not locate cell. " + ex.Message); }
            }
            else { MessageBox.Show("Please select a row or cell to find."); }
        }
    }
}
