namespace SHNDecrypt
{
    partial class ItemEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemEditor));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.chkNoTradeOnly = new System.Windows.Forms.CheckBox();
            this.lstItems = new System.Windows.Forms.ListBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.txtStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtitemName = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.nmrMaxLot = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.nmrFamePrice = new System.Windows.Forms.NumericUpDown();
            this.nmrBuyPrice = new System.Windows.Forms.NumericUpDown();
            this.nmrSellPrice = new System.Windows.Forms.NumericUpDown();
            this.cmbCanTrade = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nmrLevel = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrMaxLot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrFamePrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrBuyPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrSellPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtSearch);
            this.groupBox1.Controls.Add(this.chkNoTradeOnly);
            this.groupBox1.Controls.Add(this.lstItems);
            this.groupBox1.Location = new System.Drawing.Point(7, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(189, 432);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Items";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(148, 18);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(27, 24);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "...";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(13, 19);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(127, 20);
            this.txtSearch.TabIndex = 4;
            // 
            // chkNoTradeOnly
            // 
            this.chkNoTradeOnly.AutoSize = true;
            this.chkNoTradeOnly.Location = new System.Drawing.Point(11, 409);
            this.chkNoTradeOnly.Name = "chkNoTradeOnly";
            this.chkNoTradeOnly.Size = new System.Drawing.Size(150, 17);
            this.chkNoTradeOnly.TabIndex = 3;
            this.chkNoTradeOnly.Text = "Show NoTrade Items Only";
            this.chkNoTradeOnly.UseVisualStyleBackColor = true;
            // 
            // lstItems
            // 
            this.lstItems.FormattingEnabled = true;
            this.lstItems.Location = new System.Drawing.Point(11, 45);
            this.lstItems.Name = "lstItems";
            this.lstItems.Size = new System.Drawing.Size(165, 355);
            this.lstItems.TabIndex = 0;
            this.lstItems.SelectedIndexChanged += new System.EventHandler(this.lstItems_SelectedIndexChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 449);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(544, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // txtStatus
            // 
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(122, 17);
            this.txtStatus.Text = "Ready to server you :3";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtitemName);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.nmrMaxLot);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.nmrFamePrice);
            this.groupBox2.Controls.Add(this.nmrBuyPrice);
            this.groupBox2.Controls.Add(this.nmrSellPrice);
            this.groupBox2.Controls.Add(this.cmbCanTrade);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.nmrLevel);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtFullName);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(210, 17);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(320, 364);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Info";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // txtitemName
            // 
            this.txtitemName.AutoSize = true;
            this.txtitemName.Location = new System.Drawing.Point(121, 331);
            this.txtitemName.Name = "txtitemName";
            this.txtitemName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtitemName.Size = new System.Drawing.Size(12, 13);
            this.txtitemName.TabIndex = 15;
            this.txtitemName.Text = "/";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(20, 321);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 33);
            this.button1.TabIndex = 14;
            this.button1.Text = "Apply Changes";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // nmrMaxLot
            // 
            this.nmrMaxLot.Location = new System.Drawing.Point(94, 94);
            this.nmrMaxLot.Name = "nmrMaxLot";
            this.nmrMaxLot.Size = new System.Drawing.Size(50, 20);
            this.nmrMaxLot.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Max Lot:";
            // 
            // nmrFamePrice
            // 
            this.nmrFamePrice.Location = new System.Drawing.Point(94, 174);
            this.nmrFamePrice.Name = "nmrFamePrice";
            this.nmrFamePrice.Size = new System.Drawing.Size(84, 20);
            this.nmrFamePrice.TabIndex = 11;
            // 
            // nmrBuyPrice
            // 
            this.nmrBuyPrice.Location = new System.Drawing.Point(94, 148);
            this.nmrBuyPrice.Name = "nmrBuyPrice";
            this.nmrBuyPrice.Size = new System.Drawing.Size(84, 20);
            this.nmrBuyPrice.TabIndex = 10;
            // 
            // nmrSellPrice
            // 
            this.nmrSellPrice.Location = new System.Drawing.Point(94, 120);
            this.nmrSellPrice.Name = "nmrSellPrice";
            this.nmrSellPrice.Size = new System.Drawing.Size(84, 20);
            this.nmrSellPrice.TabIndex = 9;
            // 
            // cmbCanTrade
            // 
            this.cmbCanTrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCanTrade.FormattingEnabled = true;
            this.cmbCanTrade.Location = new System.Drawing.Point(94, 232);
            this.cmbCanTrade.Name = "cmbCanTrade";
            this.cmbCanTrade.Size = new System.Drawing.Size(50, 21);
            this.cmbCanTrade.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 236);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "NoTrade";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Fame price:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Buy Price:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Sell Price:";
            // 
            // nmrLevel
            // 
            this.nmrLevel.Location = new System.Drawing.Point(59, 52);
            this.nmrLevel.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.nmrLevel.Name = "nmrLevel";
            this.nmrLevel.Size = new System.Drawing.Size(43, 20);
            this.nmrLevel.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Level:";
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(77, 23);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(217, 20);
            this.txtFullName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Full Name:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(214, 386);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(317, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Multitip: Enter a value int the box & press \"...\" to search for a value.";
            // 
            // ItemEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 471);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ItemEditor";
            this.Text = "ItemEditor";
            this.Load += new System.EventHandler(this.ItemEditor_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrMaxLot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrFamePrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrBuyPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrSellPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrLevel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lstItems;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel txtStatus;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCanTrade;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nmrLevel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.NumericUpDown nmrFamePrice;
        private System.Windows.Forms.NumericUpDown nmrBuyPrice;
        private System.Windows.Forms.NumericUpDown nmrSellPrice;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nmrMaxLot;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.CheckBox chkNoTradeOnly;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label txtitemName;
        private System.Windows.Forms.Label label8;
    }
}