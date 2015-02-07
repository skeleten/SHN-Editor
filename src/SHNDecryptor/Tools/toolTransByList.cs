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
    public partial class TransByList : Form
    {
        frmMain form;
        public TransByList(frmMain main)
        {
            InitializeComponent();
            form = main;
        }

        private void TransByList_Load(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText()) textBox1.Text = Clipboard.GetText();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (form.file == null) return;
            for (int i = 0; i < textBox1.Lines.Length; i++)
            {
                string[] line = textBox1.Lines[i].Split('@');
                int rowIndex = form.file.GetRowByIndex(1, line[0]);
                if(rowIndex > -1)
                    form.file.table.Rows[rowIndex][2] = line[1];
            }
        }
    }
}
