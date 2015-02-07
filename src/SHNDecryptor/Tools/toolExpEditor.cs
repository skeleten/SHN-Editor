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
    public partial class ExpEditor : Form
    {
        frmMain form;
        decimal savedExp = 0;
        int expCol = 9;

        public ExpEditor(frmMain frm)
        {
            form = frm;
            InitializeComponent();

            if (frm.file == null)
                this.Close();
           
            expCol = GetExpColNum();
            //normal 1st one is 20
            if (expCol == -1) return;
            int curExp = Convert.ToInt32(frm.file.table.Rows[0][expCol]);
            expNumeric.Value = decimal.Divide(curExp, 20);
            savedExp = expNumeric.Value;
        }

        private void ExpEditor_Load(object sender, EventArgs e)
        {

        }

        public int GetExpColNum()
        {
            int toret = -1;
            for (int i = 0; i < form.file.table.Columns.Count; i++)
            {
                if (form.file.table.Columns[i].ToString() == "MonEXP")
                {
                    toret = i;
                    break;
                }
            }
            return toret;
        }

        void FixPrevious()
        {
            for (int i = 0; i < form.file.table.Rows.Count; i++)
            {
              int normal = (int)(Convert.ToInt32(form.file.table.Rows[i][expCol]) / savedExp);
              long newOne =(long)(normal * expNumeric.Value);
                if(newOne > int.MaxValue) newOne = int.MaxValue;
                form.file.table.Rows[i][expCol] = Convert.ToInt32(newOne);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                FixPrevious();
                form.SQLStatus.Text = "New mob rate: " + expNumeric.Value + "x.";
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
