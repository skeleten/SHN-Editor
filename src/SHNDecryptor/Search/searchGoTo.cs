using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SHNDecrypt.Search
{
    public partial class searchGoTo : Form
    {
        frmMain GoTo;
        public searchGoTo(frmMain main)
        {
            this.GoTo = main;
            InitializeComponent();
        }

        private void searchGoTo_Load(object sender, EventArgs e)
        {
            txtCurrentPos.Text = GoTo.dataGrid.CurrentCell.RowIndex.ToString();
            txtPosLimit.Text = (GoTo.dataGrid.Rows.Count - 1).ToString();
            txtGoToPos.Text = "0";
        }

        private void txtGoToPos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGo.PerformClick();
                e.SuppressKeyPress = true;
            }

            if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true;
                Close();
            }
        }

        private void txtGoToPos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            try
            {
                GoTo.dataGrid.CurrentCell = GoTo.dataGrid.Rows[Convert.ToInt32(txtGoToPos.Text)].Cells[0];
                txtCurrentPos.Text = GoTo.dataGrid.CurrentCell.RowIndex.ToString();
            }
            catch (Exception ex) { MessageBox.Show("An error occured: " + ex.Message); }
        }
    }
}
