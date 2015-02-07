using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace SHNDecrypt
{
    public partial class ItemEditor : Form
    {
        frmMain main;
        Dictionary<string, Item> items = new Dictionary<string, Item>();

        int lnxNameIndex;
        int NameIndex;
        int LevelIndex;
        int BuyIndex;
        int SellIndex;
        int FameIndex;
        int canTradeIndex;
        int maxLotIndex;

        public ItemEditor(frmMain form)
        {
            InitializeComponent();
            main = form;
            init();
        }

        public void ShowList(int errors)
        {
            foreach (KeyValuePair<string, Item> it in items)
            {
                lstItems.Items.Add(it.Key);
            }
            nmrSellPrice.Maximum = int.MaxValue;
            nmrBuyPrice.Maximum = int.MaxValue;
            nmrFamePrice.Maximum = int.MaxValue;
            nmrMaxLot.Maximum = int.MaxValue;
            cmbCanTrade.Items.Clear();
            cmbCanTrade.Items.Add("False");
            cmbCanTrade.Items.Add("True");
            txtStatus.Text = items.Count + " items loaded! Outspark fucked up " + errors + " duplicate items";
        }

        void init()
        {
            if (main.file == null) return;
            lnxNameIndex = main.file.getColIndex("InxName");
            NameIndex = main.file.getColIndex("Name");
            LevelIndex = main.file.getColIndex("DemandLv");
            BuyIndex = main.file.getColIndex("BuyPrice");
            SellIndex = main.file.getColIndex("SellPrice");
            FameIndex = main.file.getColIndex("BuyFame");
            canTradeIndex = main.file.getColIndex("NoTrade"); //0 = can trade
            maxLotIndex = main.file.getColIndex("MaxLot");
            int errors = 0;
            for (int i = 0; i < main.file.table.Rows.Count; i++)
            {
                try
                {
                    Item item = new Item();
                    item.rowIndex = i;
                    item.ID = Convert.ToUInt16(main.file.table.Rows[i][0]);
                    item.InxName = main.file.table.Rows[i][lnxNameIndex].ToString();
                    item.name = main.file.table.Rows[i][NameIndex].ToString();
                    item.level = Convert.ToByte(main.file.table.Rows[i][LevelIndex]);
                    item.buyPrice = Convert.ToInt32(main.file.table.Rows[i][BuyIndex]);
                    item.sellPrice = Convert.ToInt32(main.file.table.Rows[i][SellIndex]);
                    item.famePrice = Convert.ToInt32(main.file.table.Rows[i][FameIndex]);
                    item.noTrade = Convert.ToBoolean(main.file.table.Rows[i][canTradeIndex]);
                    item.maxLot = Convert.ToInt32(main.file.table.Rows[i][maxLotIndex]);
                    items.Add(item.InxName, item);
                }
                catch { errors++; }
            }
            this.ShowList(errors);
        }

        private void ItemEditor_Load(object sender, EventArgs e)
        {

        }

        private void chkNoTradeOnly_CheckedChanged(object sender, EventArgs e)
        {
            lstItems.Items.Clear();
            if (chkNoTradeOnly.Checked)
            {
                foreach (KeyValuePair<string, Item> it in items)
                {
                    if(it.Value.noTrade)
                    lstItems.Items.Add(it.Key);
                }
            }
            else
            {
                foreach (KeyValuePair<string, Item> it in items)
                {
                    lstItems.Items.Add(it.Key);
                }
            }
            txtStatus.Text = lstItems.Items.Count + " items";
        }

        private void lstItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstItems.Items.Count == 0) return;
            try
            {
                Item item = items[lstItems.Items[lstItems.SelectedIndex].ToString()];
                cmbCanTrade.SelectedIndex = item.noTrade ? 1 : 0;
                txtFullName.Text = item.name;
                nmrLevel.Value = item.level;
                nmrBuyPrice.Value = item.buyPrice;
                nmrSellPrice.Value = item.sellPrice;
                nmrFamePrice.Value = item.famePrice;
                nmrMaxLot.Value = item.maxLot;
                txtitemName.Text = item.InxName;
                
            }
            catch { }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (items.Count == 0) return;
            lstItems.Items.Clear();
            foreach (KeyValuePair<string, Item> item in items)
            {
                if (item.Value.InxName.ToLower().Contains(txtSearch.Text.ToLower()))
                    lstItems.Items.Add(item.Key);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!items.ContainsKey(txtitemName.Text))
            {
                MessageBox.Show(txtitemName.Text + " not found in item dictionary");
                return;
            }
            try
            {
                int rowIndex = items[txtitemName.Text].rowIndex;
                main.file.table.Rows[rowIndex][lnxNameIndex] = txtFullName.Text;
                main.file.table.Rows[rowIndex][LevelIndex] = (int)nmrLevel.Value;
                main.file.table.Rows[rowIndex][SellIndex] = (int)nmrSellPrice.Value;
                main.file.table.Rows[rowIndex][BuyIndex] = (int)nmrBuyPrice.Value;
                main.file.table.Rows[rowIndex][FameIndex] = (int)nmrFamePrice.Value;
                main.file.table.Rows[rowIndex][maxLotIndex] = (int)nmrMaxLot.Value;
                main.file.table.Rows[rowIndex][canTradeIndex] = (byte)cmbCanTrade.SelectedIndex;
                txtStatus.Text = txtitemName.Text + " saved!";
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }


    }

    public class Item
    {
       public int rowIndex;
       public ushort ID;
       public bool noTrade;
       public string name;
       public string InxName;
       public int buyPrice;
       public int sellPrice;
       public int famePrice;
       public byte level;
       public int maxLot;
    }
}
