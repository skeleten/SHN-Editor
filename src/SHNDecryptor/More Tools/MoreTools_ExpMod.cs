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
    public partial class MoreTools_ExpMod : Form
    {
        bool[] loadedMonLvls;
        UInt32[] monLvls;
        DataGridViewRowCollection rows;
        String filename = "";
        public MoreTools_ExpMod()
        {
            InitializeComponent();
        }
        public MoreTools_ExpMod(bool[] loadedBool, UInt32[] lvls, DataGridViewRowCollection dataRows, String fname)
        {
            loadedMonLvls = loadedBool;
            monLvls = lvls;
            rows = dataRows;
            filename = fname;
            InitializeComponent();
        }

        private void MoreTools_ExpMod_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = "Adv. Exp Mod opened!";
                if (loadedMonLvls[0]){
                   label1.ForeColor = Color.Green;
                   label1.Text = "Monster levels were grabbed";
                   log("Monster levels grabbed. Ready to execute expressions.");
                }else{
                   label1.ForeColor = Color.Red;
                   label1.Text = "Monster levels not grabbed";
                   log("Monster levels not grabbed yet; need to grab before executing expressions. Open MobInfo.shn and click 'Grab Monster Levels'.");
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // open help about exp mod
            MoreTools_help mtHelp = new MoreTools_help(1);
            mtHelp.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // clear expression
            textBox1.Text = "";
            textBox1.Focus();
            log("Expression cleared.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // execute expression
            if (filename == "MobInfoServer.shn")
            {
                if (loadedMonLvls[0])
                {
                    executeExpression();
                    textBox1.Focus();
                }
                else
                {
                    MessageBox.Show("You must grab monster levels from MobInfo.shn first.\nTo do this, just open MobInfo.shn and click Tools -> More Tools -> Adv. Exp Mod -> Grab Monster Levels.");
                    log("Cannot execute yet, need to grab monster levels from MobInfo.shn.");
                }
            }
            else
            {
                MessageBox.Show("This can only be done while 'MobInfoServer.shn' is open.");
                log("MobInfoServer.shn must be open in order to execute expressions (it has the EXP data). Please open it and select it as current tab.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // grab monster levels
            if (filename == "MobInfo.shn")
            {
                //monLvls = new UInt32[65536];
                log("Attempting to grab levels of " + rows.Count + " monsters...");
                int set = 0;
                foreach (DataGridViewRow row in rows)
                {
                    try
                    {
                        if (row.Cells[0].Value == null) continue;
                        monLvls[int.Parse(row.Cells[0].Value.ToString())] = UInt32.Parse(row.Cells[3].Value.ToString());
                        set++;
                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show("problem?\n" + ee);
                    }
                }
                loadedMonLvls[0] = true;
                MessageBox.Show("Done! Set the Level record for " + set + " monsters!");
                log("Successfully grabbed the level record for " + set + " monsters!");
                label1.ForeColor = Color.Green;
                label1.Text = "Monster levels were grabbed";
            }
            else
            {
                MessageBox.Show("This can only be done while 'MobInfo.shn' is open.");
                log("MobInfo.shn must be open -- please open it and select it as current tab.");
            }
        }
        private void log(String str)
        {
            richTextBox1.Text += "\n";
            richTextBox1.Text += str;
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();
        }
        private void executeExpression()
        {
            String str = textBox1.Text;
            if (str == "")
            {
                log("Expression was empty -- could not execute.");
            }
            else
            {
                log("\nExecuting expression...");
                string explanation = "Proper input: [Lvl(s)] [optype] [opvalue]\ndelimited by space\nLvl(s) can be '4' to specify the lvl 4, or '2~4' to inclusively specify all levels 2, 3, and 4. can also be something like '>4' to mean all lvls greater than 4, or '<100', for less than lvl 100\nOpcodes acceptable: '=' '+' '-' '*' '/'\nOpvalue is the amount to add / multiply / etc, and this value can be float (ex. 9, 2.1, 0.5, etc)\n\nThis function changes all exp in mobInfoServer.shn by the specified optype to the specified opvalue where the level is within the specified lvl range";
                string examples = "\n\nExamples:\n1 = 10000000 set exp for lvl 1s (slime only?) to 10,000,000\n>100 * 50    multiply exp by 50 for monsters lvls 101+\n1~150 = 1    set exp for all monsters (lvls 1-150) to 1\n>4 * 1515\t\tMultiply exp of all monsters lvl 5+ by 1515\n75~90  * 2.5\t\tMultiply exp of all monsters lvls 75-90 by 2.5";
                explanation += examples;
                // set row[x]exp to value *,+,etc opvalue
                int changed = 0;
                char optype = '=';
                float opvalue = 1.0f;
                int minLvl = 0;
                int maxLvl = 500;

                //use helper for extra functions shared between More Tools features
                helper ineedhelp = new helper();


                /**     ////////////
             //         now get input
             **/
                /////////////

                // the input for this: [Lvl(s)] [optype] [opvalue]
                // delimited by a space
                // example: 80~90 * 5
                // the above example multiplies exp for all lvls 80-90 (inclusive) by 5
                // other examples:
                // 1 = 10000000 set exp for lvl 1s (slime only?) to 10,000,000
                // >100 * 50    multiply exp by 50 for monsters lvls 101+
                // 1~150 = 1    set exp for all monsters (lvls 1-150) to 1
                List<string> data = ineedhelp.parseDatas(str, ' ');

                // need 3 arguments
                if (data.Count != 3)
                {
                    MessageBox.Show("Incorrect number of arguments; you need 3 arguments and only " + data.Count + " were found.\n" + explanation);
                    log("Execution failed.");
                    log("Incorrect number of arguments; you need 3 arguments and only " + data.Count + " were found.");
                    return;
                }

                // now check that the level parameter is OK and get lvl range
                if (data[0].IndexOf("~") != -1)
                {
                    if (data[0].IndexOf(">") != -1 || data[0].IndexOf("<") != -1)
                    {
                        MessageBox.Show("Problem in syntax: cannot have both '~' and either '>' or '<' in level parameter\n\n" + explanation);
                        log("Execution failed.");
                        log("Syntax error: cannot use both '~' and '<' / '<'");
                        return;
                    }
                    string strmin = "";
                    string strmax = "";
                    bool fulcrumReached = false;
                    int l = data[0].Length;
                    for (int xint = 0; xint < l; xint++)
                    {
                        if (data[0][xint] == '~')
                        {
                            fulcrumReached = true;
                        }
                        else
                        {
                            if (fulcrumReached)
                            {
                                strmax += data[0][xint];
                            }
                            else
                            {
                                strmin += data[0][xint];
                            }
                        }
                    }
                    if (strmin == "")
                    {
                        MessageBox.Show("The minimum level was invalid!\nYou entered '" + strmin + "' before '~'");
                        log("Execution failed.");
                        log("Minimum level invalid; you entered '" + strmin + "' before '~'");
                        return;
                    }
                    else if (strmax == "")
                    {
                        MessageBox.Show("The maximum level was invalid!\nYou entered '" + strmax + "' after '~'");
                        log("Execution failed.");
                        log("Maximum level invalid; you entered '" + strmax + "' before '~'");
                        return;
                    }
                    try
                    {
                        minLvl = int.Parse(strmin);
                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show("The minimum level you entered seemed be in an unaccaptable format (included some non-numerical characters?)\nYour minLvl: '" + strmin + "'");
                        log("Execution failed.");
                        log("Minimum level invalid: Excpetion triggered. The number you entered was in an unacceptable format (included non-numerical characters?)\nYour minLvl: '" + strmin + "'");
                        return;
                    }
                    try
                    {
                        maxLvl = int.Parse(strmax);
                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show("The maximum level you entered seemed be in an unaccaptable format (included some non-numerical characters?)\nYour maxLvl: '" + strmax + "'");
                        log("Execution failed.");
                        log("Maximum level invalid: Excpetion triggered. The number you entered was in an unacceptable format (included non-numerical characters?)\nYour maxLvl: '" + strmax + "'");
                        return;
                    }
                }
                else if (data[0].IndexOf(">") != -1)
                {
                    try
                    {
                        string newint = "";
                        int l = data[0].Length;
                        for (int xint = 1; xint < l; xint++)
                        {
                            newint += data[0][xint];
                        }
                        minLvl = int.Parse(newint);
                        minLvl += 1; // so > this lvl
                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show("The level you specified contained illegal / non-numerical characters and was therefore invalid\nYour specified level: '" + data[0] + "'");
                        log("Execution failed.");
                        log("Invalid level specified; level contained illegal / non-numerical characters\nYour specified level: '" + data[0] + "'");
                        return;
                    }
                }
                else if (data[0].IndexOf("<") != -1)
                {
                    try
                    {
                        string newint = "";
                        int l = data[0].Length;
                        for (int xint = 1; xint < l; xint++)
                        {
                            newint += data[0][xint];
                        }
                        maxLvl = int.Parse(newint);
                        maxLvl -= 1; // so < this lvl
                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show("The level you specified contained illegal / non-numerical characters and was therefore invalid\nYour specified level: '" + data[0] + "'");
                        log("Execution failed.");
                        log("Invalid level specified; level contained illegal / non-numerical characters\nYour specified level: '" + data[0] + "'");
                        return;
                    }
                }
                else
                {
                    try
                    {
                        minLvl = int.Parse(data[0]);
                        maxLvl = int.Parse(data[0]);
                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show("The level you specified contained illegal / non-numerical characters and was therefore invalid\nYour specified level: '" + data[0] + "'");
                        log("Execution failed.");
                        log("Invalid level specified; level contained illegal / non-numerical characters\nYour specified level: '" + data[0] + "'");
                        return;
                    }
                }
                if (data[1].Length == 0)
                {
                    MessageBox.Show("You must specify an optype! (currently optype is empty!)\n" + explanation);
                    log("Execution failed.");
                    log("You must specify an operator/optype! You may see Help for more information.");
                    return;
                }
                optype = data[1][0];
                try
                {
                    opvalue = float.Parse(data[2]);
                }
                catch (Exception ee)
                {
                    MessageBox.Show("The opvalue you specified contained illegal / non-numerical characters and was therefore invalid\nYour specified opvalue: '" + data[2] + "'");
                    log("Execution failed.");
                    log("The operation value you specified contained illegal / non-numerical characters and was therefore invalid.\nYour specified value: '" + data[2] + "'");
                    return;
                }



                /**     so now
                 *          actually do the modification
                 * **/

                if (rows.Count < 1)
                {
                    MessageBox.Show("Error: no rows in datagrid");
                    log("Execution failed.");
                    log("Error: no rows in datagrid; you must not have any .shn files open?");
                    return;
                }
                if (optype == '=')
                {
                    foreach (DataGridViewRow row in this.rows)
                    {
                        try
                        {
                            if (row.Cells[0].Value == null) continue;
                            int id = int.Parse(row.Cells[0].Value.ToString());
                            if (monLvls[id] >= minLvl & monLvls[id] <= maxLvl)
                            {
                                row.Cells[9].Value = (UInt32)opvalue;
                                changed++;
                            }
                        }
                        catch (Exception ee)
                        {
                            MessageBox.Show("Problem performing exp modification (setting equal to)...\n" + ee.StackTrace);
                            log("Execution failed.");
                            log("Exception: Failed to perform exp modification for optype '=' (set equal to)");
                        }
                    }
                }
                else if (optype == '+')
                {
                    foreach (DataGridViewRow row in this.rows)
                    {
                        try
                        {
                            if (row.Cells[0].Value == null) continue;
                            int id = int.Parse(row.Cells[0].Value.ToString());
                            if (monLvls[id] >= minLvl & monLvls[id] <= maxLvl)
                            {
                                row.Cells[9].Value = UInt32.Parse(row.Cells[9].Value.ToString()) + (UInt32)opvalue;
                                changed++;
                            }
                        }
                        catch (Exception ee)
                        {
                            MessageBox.Show("Problem performing exp modification for addition...\n" + ee.StackTrace);
                            log("Execution failed.");
                            log("Exception: Failed to perform exp modification for optype '+' (addition)");
                        }
                    }
                }
                else if (optype == '-')
                {
                    foreach (DataGridViewRow row in this.rows)
                    {
                        try
                        {
                            if (row.Cells[0].Value == null) continue;
                            int id = int.Parse(row.Cells[0].Value.ToString());
                            if (monLvls[id] >= minLvl & monLvls[id] <= maxLvl)
                            {
                                row.Cells[9].Value = UInt32.Parse(row.Cells[9].Value.ToString()) - (UInt32)opvalue;
                                changed++;
                            }
                        }
                        catch (Exception ee)
                        {
                            MessageBox.Show("Problem performing exp modification for subtraction...\n" + ee.StackTrace);
                            log("Execution failed.");
                            log("Exception: Failed to perform exp modification for optype '-' (subtraction)");
                        }
                    }
                }
                else if (optype == '*')
                {
                    foreach (DataGridViewRow row in this.rows)
                    {
                        try
                        {
                            if (row.Cells[0].Value == null) continue;
                            int id = int.Parse(row.Cells[0].Value.ToString());
                            if (monLvls[id] >= minLvl & monLvls[id] <= maxLvl)
                            {
                                row.Cells[9].Value = (UInt32)(float.Parse(row.Cells[9].Value.ToString()) * opvalue);
                                changed++;
                            }
                        }
                        catch (Exception ee)
                        {
                            MessageBox.Show("Problem performing exp modification for multiplication...\n" + ee.StackTrace);
                            log("Execution failed.");
                            log("Exception: Failed to perform exp modification for optype '*' (multiplication)");
                        }
                    }
                }
                else if (optype == '/')
                {
                    foreach (DataGridViewRow row in this.rows)
                    {
                        try
                        {
                            if (row.Cells[0].Value == null) continue;
                            int id = int.Parse(row.Cells[0].Value.ToString());
                            if (monLvls[id] >= minLvl & monLvls[id] <= maxLvl)
                            {
                                row.Cells[9].Value = (UInt32)(float.Parse(row.Cells[9].Value.ToString()) / opvalue);
                                changed++;
                            }
                        }
                        catch (Exception ee)
                        {
                            MessageBox.Show("Problem performing exp modification for division...\n" + ee.StackTrace);
                            log("Execution failed.");
                            log("Exception: Failed to perform exp modification for optype '/' (division)");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Opcode unknown! Acceptable values:\n=\n+\n-\n*\n/");
                    log("Execution failed.");
                    log("Unkown operator; you entered an invalid operator: '" + data[1] + "'");
                    return;
                }
                MessageBox.Show("Done! Changed exp for " + changed + " monsters!\n\nRan with these parameters:\nminLvl = " + minLvl + "\nmaxLvl = " + maxLvl + "\noptype = " + optype + "\nopvalue = " + opvalue + "\t (UInt32: " + (UInt32)opvalue + " )");
                log("Execution succeeded!");
                log("Changed exp for " + changed + " monsters!\nExpression log: " + str);
            }
        }
    }
}
