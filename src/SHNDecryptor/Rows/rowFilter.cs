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
    public partial class rowFilter : Form
    {
        //this is far from completion, please do manually for now
        frmMain main;
        public rowFilter(frmMain mainfrm)
        {
            main = mainfrm;
            InitializeComponent();
            init(); 
        }

        public void init()
        {
            if (main.file.table == null) return;
            cmbToMove.Items.Clear();
            for (int i = 0; i < main.file.table.Columns.Count; i++)
            {
                cmbToMove.Items.Add(main.file.table.Columns[i].ColumnName);
                cmbMoveAfter.Items.Add(main.file.table.Columns[i].ColumnName);
            }
            cmbToMove.SelectedIndex = 0;
            cmbMoveAfter.SelectedIndex = 0;
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            txtOutput.Text = "";
            int toListID = main.file.getColIndex(cmbToMove.Text);
            int toSearchID = main.file.getColIndex(cmbMoveAfter.Text);
            progressBar1.Value = 0;
            progressBar1.Maximum = main.file.table.Rows.Count - 1;

            for (int i = 0; i < main.file.table.Rows.Count; i++)
            {
                if (main.file.table.Rows[i][toSearchID].ToString().Contains(txtSearch.Text))
                    txtOutput.Text += main.file.table.Rows[i][toListID].ToString() + "\r\n";
                progressBar1.Value = i;
            }
            main.SQLStatus.Text = "Output list done.";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtOutput.Text = "";
        }
    }
}
