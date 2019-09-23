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
    public partial class MoreTools_help : Form
    {
        int mySubject = 0;
        public MoreTools_help()
        {
            InitializeComponent();
        }
        public MoreTools_help(int subject)
        {
            mySubject = subject;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MoreTools_about mtAbout = new MoreTools_about();
            mtAbout.ShowDialog();
        }

        private void MoreTools_help_Load(object sender, EventArgs e)
        {
            String tmp = "";
            switch (mySubject)
            {
                case 1:
                    {
                        label1.Text = "Help Subject: Advanced Experience Modifier";
                        tmp = "This is for changing exp in ways that the Bulk Edit and the Exp Rate Editor wouldn't allow. This lets you perform a plethora of operations on a user-defined selection of monsters determined by level.\n\n";
                        tmp += "Its format is pretty intuitive:\n[Level(s) affected] [operation] [operation value]\nThey must be separated by a space. ";
                        tmp += "There MUST be a space and there must be ONLY ONE space between each argument. If there is no space between the arguments or there is more than one space between them, it will be incorrect and prompt an error message.\n\n";
                        tmp += "[Level(s) affected] is obviously the levels of the monsters whose exp you wanna change. This can be, for example, '4' (without quotes) to change the exp of all monsters that are lvl 4. Or this can be used with < or > in front to become <4 to ";
                        tmp += "represent all monsters below lvl 4 (1, 2, & 3). Or this could be used to specify a range via a tilde (~) like so: 1~150 to specify all lvls from 1 to 150 -- this is inclusive, so lvls 1 and 150 are included and also changed with the other numbers.\n\n";
                        tmp += "[Operation] is the type of mathmatical operation to perform. Valid operators include:\n";
                        tmp += "= : set the levels equal to x\n+ : add x to the levels\n- : subtract x from the levels\n* : multiply the levels by (can be floating point number)\n/ - divide the levels by x\n\n";
                        tmp += "[Operation value] is the amount to add or multiply or set the levels equal to, etc. This can be an integer or a floating point number.\n\n";
                        tmp += "So putting it all together (examples):\n";
                        tmp += "1~3 * 10   will multiply the exp of all monsters lvls 1, 2, & 3 by 10\n";
                        tmp += "<5 + 1000   will add 1000 exp to all monsters less than lvl 5 (lvls 1,2,3,4 & 5)\n";
                        tmp += "2 = 0   will set the exp all monsters level 2 to 0 EXP.\n";
                        tmp += "76~100 * 1.25   will increase exp of monsters lvls 76-100 by 25%";
                        tmp += "1~150 / 10  will divide the exp of all monsters (1-150, assuming NPCs/mobs can't be over 150) by 10\n";
                        tmp += "1 = 10000000    will set the exp of all lvl 1 monsters (just Slimes?) to 10,000,000\n\n";
                        tmp += "Note: you need the monster levels in order to use this (obviously), so you will need to open MobInfo.shn and click 'Grab Monster Levels' to get that info. Then you open 'MobInfoServer.shn' and use the expressions.\nHope this helped to clarify its use~";
                        break;
                    }
                case 2:
                    {
                        label1.Text = "Help Subject: Shop Item Valiidator";
                        tmp = "This checks all the item records entered into the texbox / copied to clipboard and searches for an item in ItemInfo.shn with the same InxName as the name given in the record. If the InxName is not found, ";
                        tmp += "the index name in the record will be changed to '-' to represent an empty shop slot.\n\n";
                        tmp += "To use, just copy the #Records from your merchant file (not the stuff before or after the #Record lines)\n";
                        tmp += "Format expected in textbox or clipboard (just copy the entire #Record lines you want from the text file) :\n";
                        tmp += "#Record	0 	ShortSword	LongSword	BroadSword	-	-	-\n";
                        tmp += "#Record	1 	ShortMace	LongMace	SpikedClub	-	-	-\n";
                        tmp += "#Record	2 	ShortBow	LongBow	LightBow	-	-	-\n\n";
                        tmp += "Text obtained by clipboard will be copied back to clipboard after removing invalid items; and if the textbox was used as input, it will be updated.\n\n";
                        tmp += "This is particularly useful for copying a merchant .text from one server to another.\n";
                        tmp += "Although... I'm pretty sure the Zones will just leave a merchant slot empty if the item is invalid, so this seems kinda unnecessary in regards to compatability and not-crash-ability.\n";
                        tmp += "But it's still good for when you want to get rid of the invalid (absent in new server's ItemInfo.shn) items in the text file for organizational purposes and whatnot.\n\n";
                        tmp += "Also comes with a 'sorting' feature that moves all empty shop slots behind the occupied shop slots... example below.\n";
                        tmp += "ShortSword  -    Buckler\n";
                        tmp += "changed to...\n";
                        tmp += "ShortSword  Buckler -";
                        break;
                    }
                default:
                    {
                        tmp = "This is the default text. How did you open this?! o.o";
                        break;
                    }
            }
            richTextBox1.Text = tmp;
        }
    }
}
