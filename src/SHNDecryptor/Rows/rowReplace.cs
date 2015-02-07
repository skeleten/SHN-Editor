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
    public partial class rowReplace : Form
    {
        frmMain mainfrm;
        public rowReplace(frmMain form)
        {
            mainfrm = form;
            InitializeComponent();
        }

        private void ColMultiplier_Load(object sender, EventArgs e)
        {
            if (mainfrm.file == null)
            {
                this.Close();
                return;
            }
            init();
        }

        public void init()
        {
            if (mainfrm.file.table == null) return;
            comboBox1.Items.Clear();
            cmbSearcher.Items.Clear();
            for (int i = 0; i < mainfrm.file.table.Columns.Count; i++)
            {
                comboBox1.Items.Add(mainfrm.file.table.Columns[i].ColumnName);
                cmbSearcher.Items.Add(mainfrm.file.table.Columns[i].ColumnName);
            }
            comboBox1.SelectedIndex = 0;
            cmbSearcher.SelectedIndex = 0;
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            int colIndexToChange = mainfrm.file.getColIndex(comboBox1.Items[comboBox1.SelectedIndex].ToString());
            int colIndexSearch = mainfrm.file.getColIndex(cmbSearcher.Items[cmbSearcher.SelectedIndex].ToString());
            if (colIndexToChange < 0 || colIndexSearch < 0) return;
            int changed = 0;
            for (int i = 0; i < txtForItems.Lines.Length; i++)
            {
                int rowIndex = mainfrm.file.GetRowByIndex(colIndexSearch, txtForItems.Lines[i].ToLower().Replace(" ", ""));
                if (rowIndex >= 0)
                {
                    mainfrm.file.table.Rows[rowIndex][colIndexToChange] = txtValue.Text;
                    changed++;
                }
            }
            mainfrm.SQLStatus.Text = changed.ToString() + " values changed to " + txtValue.Text;
        }


    }
}
