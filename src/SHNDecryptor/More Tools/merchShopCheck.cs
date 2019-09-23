using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace SHNDecrypt.More_Tools
{
    public partial class merchShopCheck : Form
    {
        DataGridViewRowCollection rows;
        String filename = "";
        public merchShopCheck()
        {
            InitializeComponent();
        }
        public merchShopCheck(DataGridViewRowCollection dataRows, String fname)
        {
            rows = dataRows;
            filename = fname;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MoreTools_help mtHelp = new MoreTools_help(2);
            mtHelp.ShowDialog();
        }

        private void merchShopCheck_Load(object sender, EventArgs e)
        {
            label1.Text = "Ready.";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            doItemCheck(0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            doItemCheck(1);
        }
        void doItemCheck(int method)
        {
            if (filename != "ItemInfo.shn")
            {
                MessageBox.Show("ItemInfo.shn is not open; please open it and select it as the current tab before opening the Item Validator");
            }
            else
            {
                String input = "";
                if (method == 1) // get text from clipboard
                {
                    if (!Clipboard.ContainsText(TextDataFormat.UnicodeText))
                    {
                        MessageBox.Show("Your clipboard is empty; is should be filled with records of a merchant file. Example:\n#Record 0  ShortSword bla one -   - -\n#record 3 blabla two   -   -   -");
                    }
                    else
                    {
                        input = Clipboard.GetText(TextDataFormat.UnicodeText);
                    }
                }
                else // get text from textbox
                {
                    input = richTextBox1.Text;
                }
                if (input == "")
                {
                    MessageBox.Show("Input appears to be empty (empty textbox or clipboard)\nFunction aborted.");
                }
                else
                {
                    richTextBox2.Text = ""; // clear output log

                    //use helper for extra functions shared between More Tools features
                    helper myLittleHelper = new helper();

                    List<String> parsed = myLittleHelper.parseDatas(input, '\n');
                    List<SHNDecrypt.More_Tools.helper.merchantRow> m = myLittleHelper.parseMerchantDatas(parsed);
                    String outstr = "";
                    int wrongItems = 0;
                    String wrongList = "";
                    int rownum = m.Count;
                    for (int xint = 0; xint < rownum; xint++)
                    {
                        for (int xint2 = 0; xint2 < 6; xint2++)
                        {
                            // if item slot == '-' then skip this item
                            // that should really save time for empty item slots
                            if (m[xint].items[xint2] == "-") continue;
                            bool found = false;
                            foreach (DataGridViewRow row in rows)
                            {
                                String compareString = "";
                                try
                                {
                                    compareString = rows[row.Index].Cells[1].Value.ToString();
                                }
                                catch (Exception ee)
                                {
                                    String wrongStr = "[ " + (wrongItems + 1) + " ] Record # " + m[xint].rowID + ", item slot " + xint2 + " => item name '" + m[xint].items[xint2] + "'";
                                    wrongList += wrongStr + "\n";
                                    break;
                                }
                                if (compareString == m[xint].items[xint2])
                                {
                                    found = true;
                                    break;
                                }
                            }
                            if (!found)
                            {
                                m[xint].items[xint2] = "-";
                                wrongItems++;
                            }
                        }
                    }
                    outstr = myLittleHelper.writeMerchantRowsToClipboard(m);
                    if (method == 1) // copy back to clipboard
                    {
                        Clipboard.SetText(outstr, TextDataFormat.UnicodeText);
                    }
                    else // display in form's textbox
                    {
                        richTextBox1.Text = outstr;
                    }
                    String logstr = "Done.";
                    String txtstr = "Done.";
                    if (method == 1)
                    {
                        txtstr += " New merchant data has been copied to your clipboard";
                        logstr += " Clipboard has been modified.";
                    }
                    logstr += "\n";
                    txtstr += "\n";
                    if (wrongItems == 0)
                    {
                        txtstr += "There were no invalid items in the shop.\n";
                        logstr += "There were no invalid items in the shop.\n";
                    }
                    else
                    {
                        txtstr += "There were " + wrongItems + " invalid items that were removed.";
                        logstr += "There were " + wrongItems + " invalid items that were removed.";
                        logstr += "\n\nThe following items were removed:\n";
                        logstr += wrongList;
                    }
                    label1.Text = "Done! " + wrongItems + " invalid items removed!";
                    richTextBox2.Text = logstr;
                }
            }
        }
        void sortItems(int method)
        {
            String input = "";
            if (method == 1) // get text from clipboard
            {
                if (!Clipboard.ContainsText(TextDataFormat.UnicodeText))
                {
                    MessageBox.Show("Your clipboard is empty; is should be filled with records of a merchant file. Example:\n#Record 0  ShortSword bla one -   - -\n#record 3 blabla two   -   -   -");
                }
                else
                {
                    input = Clipboard.GetText(TextDataFormat.UnicodeText);
                }
            }
            else // get text from textbox
            {
                input = richTextBox1.Text;
            }
            if (input == "")
            {
                MessageBox.Show("Input appears to be empty (empty textbox or clipboard)\nFunction aborted.");
                return;
            }

            //use helper for extra functions shared between More Tools features
            helper cantHelpMyself = new helper();

            // get items as a list
            List<String> lines = cantHelpMyself.parseDatas(input, '\n');
            List<String> myItems = new List<String>();
            List<String> rowNums = new List<String>(); // preserve row nums
            for (int xint = 0, l = lines.Count; xint < l; xint++)
            {
                List<String> merchParts = cantHelpMyself.parseDatas(lines[xint], '\t');
                if (merchParts.Count > 1) rowNums.Add(merchParts[1]);
                for(int zint = 2, l2 = merchParts.Count;zint < l2;zint++){
                    if (merchParts[zint] != "" && merchParts[zint] != "-" && merchParts[zint] != "\r")
                    {
                        myItems.Add(merchParts[zint]);
                    }
                }
            }

            // write items out in the order they were picked up
            int l3 = rowNums.Count;
            int l4 = myItems.Count;
            int yint = 0;
            String outstr = "";
            int failsafe = 1000; // after adding 1000 items to list, break out of while loop
            int itemsAdded = 0;
            List<SHNDecrypt.More_Tools.helper.merchantRow> outRows = new List<SHNDecrypt.More_Tools.helper.merchantRow>();
            while (yint < l3 && itemsAdded < failsafe)
            {
                SHNDecrypt.More_Tools.helper.merchantRow newRow = new SHNDecrypt.More_Tools.helper.merchantRow();
                newRow.rowID = int.Parse(rowNums[yint]);
                newRow.items = new String[6];
                for (int xint = 0, max = (l4 - itemsAdded < 6 ? (l4 - itemsAdded) : (6)); xint < max; xint++)
                {
                    newRow.items[xint] = myItems[itemsAdded];
                    itemsAdded++;
                }
                    outRows.Add(newRow);
                    yint++;
            }

            outstr = cantHelpMyself.writeMerchantRowsToClipboard(outRows);
            String outstr2 = "Text sorted.";
            if (method == 1) // copy back to clipboard
            {
                Clipboard.SetText(outstr, TextDataFormat.UnicodeText);
                outstr2 += "\nOutput: Clipboard";
            }
            else // display in form's textbox
            {
                richTextBox1.Text = outstr;
                outstr2 += "\nOutput: Textbox";
            }
            richTextBox2.Text = outstr2;
            label1.Text = outstr2;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            sortItems(0);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            sortItems(1);
        }
    }
}
