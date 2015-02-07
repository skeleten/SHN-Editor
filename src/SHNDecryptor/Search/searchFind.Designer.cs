namespace SHNDecrypt
{
    partial class searchFind
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(searchFind));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCopy = new System.Windows.Forms.Button();
            this.radioEndsWith = new System.Windows.Forms.RadioButton();
            this.radioStartsWith = new System.Windows.Forms.RadioButton();
            this.radioEquals = new System.Windows.Forms.RadioButton();
            this.radioContains = new System.Windows.Forms.RadioButton();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cmbIn = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFor = new System.Windows.Forms.TextBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.menuStrip1);
            this.groupBox1.Controls.Add(this.btnCopy);
            this.groupBox1.Controls.Add(this.radioEndsWith);
            this.groupBox1.Controls.Add(this.radioStartsWith);
            this.groupBox1.Controls.Add(this.radioEquals);
            this.groupBox1.Controls.Add(this.radioContains);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.cmbIn);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtFor);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(743, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(662, 41);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Paste";
            this.toolTip1.SetToolTip(this.button2, "Paste the copied row(s) - Ctrl + Shift + V");
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnEnter_KeyDown);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(662, 70);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Select";
            this.toolTip1.SetToolTip(this.button1, "Go to the selected row/cell on main grid - Ctrl + Shift + S");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            this.button1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnEnter_KeyDown);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(422, 16);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(45, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.selectToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.button1_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            // 
            // selectToolStripMenuItem
            // 
            this.selectToolStripMenuItem.Name = "selectToolStripMenuItem";
            this.selectToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.selectToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.selectToolStripMenuItem.Text = "Select";
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(662, 12);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(75, 23);
            this.btnCopy.TabIndex = 7;
            this.btnCopy.Text = "Copy";
            this.toolTip1.SetToolTip(this.btnCopy, "Copy the selected row(s) - Ctrl + Shift + C");
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.button1_Click);
            this.btnCopy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnEnter_KeyDown);
            // 
            // radioEndsWith
            // 
            this.radioEndsWith.AutoSize = true;
            this.radioEndsWith.Location = new System.Drawing.Point(281, 70);
            this.radioEndsWith.Name = "radioEndsWith";
            this.radioEndsWith.Size = new System.Drawing.Size(74, 17);
            this.radioEndsWith.TabIndex = 6;
            this.radioEndsWith.TabStop = true;
            this.radioEndsWith.Text = "Ends With";
            this.radioEndsWith.UseVisualStyleBackColor = true;
            this.radioEndsWith.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnEnter_KeyDown);
            // 
            // radioStartsWith
            // 
            this.radioStartsWith.AutoSize = true;
            this.radioStartsWith.Location = new System.Drawing.Point(281, 53);
            this.radioStartsWith.Name = "radioStartsWith";
            this.radioStartsWith.Size = new System.Drawing.Size(77, 17);
            this.radioStartsWith.TabIndex = 5;
            this.radioStartsWith.TabStop = true;
            this.radioStartsWith.Text = "Starts With";
            this.radioStartsWith.UseVisualStyleBackColor = true;
            this.radioStartsWith.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnEnter_KeyDown);
            // 
            // radioEquals
            // 
            this.radioEquals.AutoSize = true;
            this.radioEquals.Location = new System.Drawing.Point(281, 36);
            this.radioEquals.Name = "radioEquals";
            this.radioEquals.Size = new System.Drawing.Size(57, 17);
            this.radioEquals.TabIndex = 4;
            this.radioEquals.TabStop = true;
            this.radioEquals.Text = "Equals";
            this.radioEquals.UseVisualStyleBackColor = true;
            this.radioEquals.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnEnter_KeyDown);
            // 
            // radioContains
            // 
            this.radioContains.AutoSize = true;
            this.radioContains.Location = new System.Drawing.Point(281, 19);
            this.radioContains.Name = "radioContains";
            this.radioContains.Size = new System.Drawing.Size(66, 17);
            this.radioContains.TabIndex = 3;
            this.radioContains.TabStop = true;
            this.radioContains.Text = "Contains";
            this.radioContains.UseVisualStyleBackColor = true;
            this.radioContains.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnEnter_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(80, 68);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(194, 24);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            this.btnSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnEnter_KeyDown);
            // 
            // cmbIn
            // 
            this.cmbIn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIn.FormattingEnabled = true;
            this.cmbIn.Location = new System.Drawing.Point(80, 42);
            this.cmbIn.Name = "cmbIn";
            this.cmbIn.Size = new System.Drawing.Size(194, 21);
            this.cmbIn.TabIndex = 1;
            this.cmbIn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnEnter_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Search in:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Search for:";
            // 
            // txtFor
            // 
            this.txtFor.Location = new System.Drawing.Point(80, 16);
            this.txtFor.Name = "txtFor";
            this.txtFor.Size = new System.Drawing.Size(194, 20);
            this.txtFor.TabIndex = 0;
            this.txtFor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnEnter_KeyDown);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 537);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(743, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tStatus
            // 
            this.tStatus.Name = "tStatus";
            this.tStatus.Size = new System.Drawing.Size(42, 17);
            this.tStatus.Text = "Ready.";
            // 
            // dataGrid
            // 
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid.Location = new System.Drawing.Point(0, 100);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.Size = new System.Drawing.Size(743, 437);
            this.dataGrid.TabIndex = 9;
            this.dataGrid.TabStop = false;
            this.dataGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnEnter_KeyDown);
            // 
            // searchFind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 559);
            this.Controls.Add(this.dataGrid);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "searchFind";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.searchFind_Closing);
            this.Shown += new System.EventHandler(this.searchFind_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnEnter_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbIn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFor;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.RadioButton radioEndsWith;
        private System.Windows.Forms.RadioButton radioStartsWith;
        private System.Windows.Forms.RadioButton radioEquals;
        private System.Windows.Forms.RadioButton radioContains;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tStatus;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectToolStripMenuItem;
    }
}