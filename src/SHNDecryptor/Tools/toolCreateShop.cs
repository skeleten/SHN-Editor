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
    public partial class createShop : Form
    {
        frmMain main;
        int rowIndex = 0;
        int I = -1;
        bool MatchFound = false;
        bool Searching = false;
        bool ItemInfo = true;

        public createShop(frmMain form)
        {            
            InitializeComponent();
            main = form;
            init();
        }

        private void createShop_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            txtInput.Text = "Example_1\r\nExample_2\r\nExample_3";
            button1.PerformClick();
        }

        void init()
        {
            string[] message = { "Please open ItemInfo.shn to use this." };
            var lvim = new ListViewItem(message);

            if (main.FileTab.TabPages.Count > 0)
            {
                if (main.FileTab.SelectedTab.Text.ToString().Contains("ItemInfo") == false)
                {
                    listView1.Items.Add(lvim);
                    listView1.Columns[0].Width = -1;
                    ItemInfo = false;
                }
                else
                {
                    foreach (DataGridViewRow row in main.dataGrid.Rows)
                    {
                        if (row.Index < row.DataGridView.Rows.Count - 1)
                        {
                            string[] data = { row.DataGridView[1, row.Index].Value.ToString(), row.DataGridView[2, row.Index].Value.ToString() };
                            var listViewItem = new ListViewItem(data);
                            listView1.Items.Add(listViewItem);
                            listView1.Columns[0].Width = -1;
                            listView1.Columns[1].Width = -1;
                            //listBox1.Items.Add(row.DataGridView[1, row.Index].Value.ToString() + "\t" + row.DataGridView[2, row.Index].Value.ToString());
                        }
                    }
                }
            }
            else
            {
                listView1.Items.Add(lvim);
                listView1.Columns[0].Width = -1;
                ItemInfo = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtOutput.TextLength > 1) { txtOutput.Text = ""; }

            rowIndex = (int)nmrStart.Value;
            double totalRowsWillBe = Math.Ceiling((double)txtInput.Lines.Length / 6);
            int currentLine = 0;
            txtOutput.Text += ";    NPC Item List created with Shop Creator" + "\r\n" + "#ignore	\\o042			;Ignore quotes" + "\r\n" + "#exchange	#	\\x20		; # => space" + "\r\n;		" + DateTime.Today.ToShortDateString() + "\r\n\r\n";
            for (int i = 0; i < totalRowsWillBe; i++)
            {
                string toOut = "#Record	" + rowIndex.ToString();
                int localindex = 1;
                while (localindex < 7)
                {
                    if (txtInput.Lines.Length - currentLine == 0) //fill with -
                    {
                        toOut += " 	-";
                        localindex++;
                    }
                    else if (localindex == 7)
                    {
                        toOut += "				";
                        localindex++;
                    }
                    else //still items available
                    {
                        if (txtInput.Lines[currentLine].Length == 0)
                        {
                            toOut += " 	-";
                        }
                        else
                        {
                            toOut += " 	" + txtInput.Lines[currentLine];
                        }
                        currentLine++;
                        localindex++;
                    }
                }
                txtOutput.Text += toOut + "\r\n";
                rowIndex++;
            }
            txtOutput.Text += "\r\n#END";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtOutput.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtInput.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtInput.Text = "";
            txtOutput.Text = "";
        }

        #region Search in Listbox
       /* private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (txtInput.Lines.Length == 0)
            {
                string[] splitItem = listBox1.SelectedItem.ToString().Split('\t');                
                txtInput.Text += splitItem[0];
            }
            else
            {
                string[] splitItem = listBox1.SelectedItem.ToString().Split('\t');              
                txtInput.Text += "\r\n" + splitItem[0];
            }
        
            MatchFound = false;
            do
            {                
                try
                {
                    //MessageBox.Show(listBox1.Items[I].ToString().IndexOf(searchString.Text).ToString());
                    if (I >= listBox1.Items.Count)
                    {
                        if (listBox1.SelectedIndex >= 1)
                        {
                            MessageBox.Show("There are no more items found containing '" + searchString.Text + "'");
                        }
                        else if (listBox1.SelectedIndex <= 0)
                        {
                            MessageBox.Show("There were no items which contain '" + searchString.Text + "'");
                        }
                        I = 0;
                        listBox1.SelectedIndex = 0;
                        listBox1.SelectedIndex = -1;
                        break; // TODO: might not be correct. Was : Exit Do
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An exception occurred:" + "\r\n" + ex.Message);
                    break; // TODO: might not be correct. Was : Exit Do
                }
                if (listBox1.Items[I].ToString().ToLower().IndexOf(searchString.Text.ToLower()) >= 0)
                {
                    MatchFound = true;
                    listBox1.SelectedIndex = I;
                }
                I += 1;
            } while (!MatchFound);
            
           }*/
    #endregion

        void resetListView()
        {
            MatchFound = true;
            listView1.Items[I].Selected = true;
            listView1.Items[I].Focused = true;
            listView1.EnsureVisible(I);
            listView1.Focus();
            Searching = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MatchFound = false;
            Searching = true;
            if (ItemInfo == true)
            {
                do
                {
                    if (searchString.Text.Length == 0)
                    {
                        MessageBox.Show("Please enter a search phrase.");
                        break;
                    }
                    I += 1;
                    try
                    {
                        if (I >= listView1.Items.Count)
                        {
                            if (getItemIndex >= 1)
                            {
                                MessageBox.Show("There are no more items found containing '" + searchString.Text + "'");
                            }
                            else if (getItemIndex <= 0)
                            {
                                MessageBox.Show("There were no items which contain '" + searchString.Text + "'");
                            }
                            I = 0;
                            listView1.Items[0].Selected = true;
                            listView1.Items[0].Focused = true;
                            listView1.EnsureVisible(0);
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An exception occurred:" + "\r\n" + ex.Message);
                        break;
                    }
                    if (comboBox1.SelectedIndex == 0)
                    {
                        if (listView1.Items[I].SubItems[0].Text.ToString().ToLower().Contains(searchString.Text.ToLower()))
                        {
                            resetListView();
                            break;
                        }
                    }
                    else
                    {
                        if (listView1.Items[I].SubItems[1].Text.ToString().ToLower().Contains(searchString.Text.ToLower()))
                        {
                            resetListView();
                            break;
                        }
                    }
                }
                while (!MatchFound);
            }
            else { MessageBox.Show("Please open ItemInfo.shn before using the search feature."); }
        }

        public int getItemIndex
        {
            get
            {
                if (listView1.FocusedItem != null)
                {
                    return (listView1.FocusedItem.Index);
                }
                else
                {
                    return (0);
                }
            }
        }

        private void searchString_TextChanged(object sender, EventArgs e)
        {
            if (ItemInfo != false)
            {
                I = 0;
                listView1.Items[0].Selected = true;
                listView1.Items[0].Focused = true;
                listView1.EnsureVisible(0);
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (txtInput.Lines.Length == 0)
            {
                txtInput.Text += listView1.SelectedItems[0].Text;
            }
            else
            {
                txtInput.Text += "\r\n" + listView1.SelectedItems[0].Text;
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.FocusedItem != null & Searching == false)
            {
                I = listView1.FocusedItem.Index;
            }
        }

        private void searchString_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button5.PerformClick();
                e.SuppressKeyPress = true;
            }
        }
    }
}
