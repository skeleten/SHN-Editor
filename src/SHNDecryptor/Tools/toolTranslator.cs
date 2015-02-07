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
    public partial class Translator : Form
    {
        SHNFile language;
        SHNFile original;
        frmMain Fmain;
        public Translator(frmMain main)
        {
            InitializeComponent();
            this.Fmain = main;
            if(main.file == null){
                this.Close();
                return;
            }
            original = main.file;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "SHN File (*.shn)|*.shn";
            open.Title = "Open language file";
            if (!(open.ShowDialog() == DialogResult.OK)) return;
            language = new SHNFile(open.FileName);
            RefreshColumns();
        }

        void RefreshColumns()
        {
            cmbOrIndex.Items.Clear();
            cmbOrTrans.Items.Clear();
            cmbLanTrans.Items.Clear();
            cmbLanIndex.Items.Clear();
            for (int i = 0; i < original.table.Columns.Count; i++)
            {
                cmbOrIndex.Items.Add(original.table.Columns[i].ColumnName);
                cmbOrTrans.Items.Add(original.table.Columns[i].ColumnName);
            }
            for (int i = 0; i < language.table.Columns.Count; i++)
            {
                cmbLanIndex.Items.Add(language.table.Columns[i].ColumnName);
                cmbLanTrans.Items.Add(language.table.Columns[i].ColumnName);
            }
            cmbLanIndex.SelectedIndex = 0;
            cmbLanTrans.SelectedIndex = 0;
            cmbOrIndex.SelectedIndex = 0;
            cmbOrTrans.SelectedIndex = 0;
        }

        private void btnDo_Click(object sender, EventArgs e)
        {
                //row indexes
                int orIndex = getColIndex(cmbOrIndex.Items[cmbOrIndex.SelectedIndex].ToString(), original);
                int lanIndex = getColIndex(cmbLanIndex.Items[cmbLanIndex.SelectedIndex].ToString(), language);
                
                //text columns
                int orTrans = getColIndex(cmbOrTrans.Items[cmbOrTrans.SelectedIndex].ToString(), original);
                int lanTrans = getColIndex(cmbLanTrans.Items[cmbLanTrans.SelectedIndex].ToString(), language);
                txtInfo.Text = "Original sorting by: " + orIndex + ", trans sorting by: " + lanIndex + " toTrans index: " + orTrans;
                Dictionary<string, string> LanList = new Dictionary<string, string>();
                List<string> nonTranslated = new List<string>();
                lock (language)
                {
                    for (int i = 0; i < language.table.Rows.Count; i++)
                    {
                        try
                        {
                            LanList.Add(language.table.Rows[i][lanIndex].ToString(), language.table.Rows[i][lanTrans].ToString());
                        }
                        catch (Exception exe) { Debug.WriteLine(exe.Message + original.table.Rows[orIndex].ToString()); };
                    }
                    foreach (DataRow x in original.table.Rows)
                    {
                        string indexText = x[orIndex].ToString();
                        if (LanList.ContainsKey(indexText))
                        {
                            x[orTrans] = LanList[indexText];
                        }
                        else
                        {
                            nonTranslated.Add(indexText);
                            if(txtDefault.Text.ToLower() != "donothing")
                            x[orTrans] = txtDefault.Text;
                        }
                    }
                }
                /*
                for (int i = 0; i < original.table.Rows.Count; i++) //checks each row
                {
                    string RowID = original.table.Rows[i][orIndex].ToString(); //gets the rowID
                    int lanRowIndex = GetRowByIndex(lanIndex, RowID, language); //gets the table index
                    if (lanRowIndex > -1) //exists
                    {
                        original.table.Rows[i][orTrans] = language.table.Rows[lanRowIndex][lanTrans];
                    }
                }
                

                foreach (DataRow row in original.table.Rows)
                {
                    string originalIndexText = row[orIndex].ToString(); //original indexing text
                    int lanRowID = language.GetRowByIndex(lanIndex, originalIndexText); // language indexing
                    if(lanRowID > -1){
                        row[orTrans] = language.table.Rows[lanRowID][lanTrans];
                    }
                } */
                string toClip = "";
                for (int i = 0; i < nonTranslated.Count; i++)
                {
                    toClip += nonTranslated[i] + "\r\n";
                }
                Clipboard.SetText(toClip);
                Fmain.SQLStatus.Text = "Done translating! " + nonTranslated.Count + " untranslated set to clipboard";
            //    this.Close();
        }

        private int GetRowByIndex(int ColIndex, string RowID, SHNFile file)
        {
            for (int i = 0; i < file.table.Rows.Count; i++)
            {
                if (file.table.Rows[i][ColIndex].ToString() == RowID) return i;
            }
            return -1;
        }

        private int getColIndex(string name, SHNFile file)
        {
            for (int i = 0; i < file.table.Columns.Count; i++)
            {
                if (file.table.Columns[i].ColumnName == name) return i;
            }
            return -1;
        }

        private void Translator_Load(object sender, EventArgs e)
        {

        }

        private void cmbOrIndex_SelectedIndexChanged(object sender, EventArgs e)
        {



        }
    }
}
