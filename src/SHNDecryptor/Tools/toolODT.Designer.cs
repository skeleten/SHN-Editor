namespace SHNDecrypt
{
    partial class OPToolEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OPToolEditor));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openTXTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToTXTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openTXTToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveTXTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtWith = new System.Windows.Forms.TextBox();
            this.btnReplc = new System.Windows.Forms.Button();
            this.groupMysql = new System.Windows.Forms.GroupBox();
            this.txtSettings = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupMysql.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openTXTToolStripMenuItem,
            this.saveToTXTToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(137, 48);
            this.contextMenuStrip1.Text = "File";
            // 
            // openTXTToolStripMenuItem
            // 
            this.openTXTToolStripMenuItem.Name = "openTXTToolStripMenuItem";
            this.openTXTToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.openTXTToolStripMenuItem.Text = "Open TXT";
            // 
            // saveToTXTToolStripMenuItem
            // 
            this.saveToTXTToolStripMenuItem.Name = "saveToTXTToolStripMenuItem";
            this.saveToTXTToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.saveToTXTToolStripMenuItem.Text = "Save to TXT";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolToolStripMenuItem
            // 
            this.toolToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openTXTToolStripMenuItem1,
            this.saveTXTToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.toolToolStripMenuItem.Name = "toolToolStripMenuItem";
            this.toolToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.toolToolStripMenuItem.Text = "Tool";
            // 
            // openTXTToolStripMenuItem1
            // 
            this.openTXTToolStripMenuItem1.Name = "openTXTToolStripMenuItem1";
            this.openTXTToolStripMenuItem1.Size = new System.Drawing.Size(127, 22);
            this.openTXTToolStripMenuItem1.Text = "Open TXT";
            this.openTXTToolStripMenuItem1.Click += new System.EventHandler(this.openTXTToolStripMenuItem1_Click);
            // 
            // saveTXTToolStripMenuItem
            // 
            this.saveTXTToolStripMenuItem.Name = "saveTXTToolStripMenuItem";
            this.saveTXTToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.saveTXTToolStripMenuItem.Text = "Save TXT";
            this.saveTXTToolStripMenuItem.Click += new System.EventHandler(this.saveTXTToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 25);
            this.button1.TabIndex = 1;
            this.button1.Text = "Save to File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(124, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Replace:";
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(180, 24);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(127, 20);
            this.txtFrom.TabIndex = 3;
            this.txtFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtWith_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(324, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "With:";
            // 
            // txtWith
            // 
            this.txtWith.Location = new System.Drawing.Point(362, 24);
            this.txtWith.Name = "txtWith";
            this.txtWith.Size = new System.Drawing.Size(106, 20);
            this.txtWith.TabIndex = 5;
            this.txtWith.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtWith_KeyDown);
            // 
            // btnReplc
            // 
            this.btnReplc.AutoSize = true;
            this.btnReplc.Location = new System.Drawing.Point(474, 21);
            this.btnReplc.Name = "btnReplc";
            this.btnReplc.Size = new System.Drawing.Size(59, 23);
            this.btnReplc.TabIndex = 6;
            this.btnReplc.Text = "Go";
            this.btnReplc.UseVisualStyleBackColor = true;
            this.btnReplc.Click += new System.EventHandler(this.btnReplc_Click);
            // 
            // groupMysql
            // 
            this.groupMysql.Controls.Add(this.btnReplc);
            this.groupMysql.Controls.Add(this.txtWith);
            this.groupMysql.Controls.Add(this.txtFrom);
            this.groupMysql.Controls.Add(this.label2);
            this.groupMysql.Controls.Add(this.label1);
            this.groupMysql.Controls.Add(this.button1);
            this.groupMysql.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupMysql.Location = new System.Drawing.Point(0, 527);
            this.groupMysql.Name = "groupMysql";
            this.groupMysql.Size = new System.Drawing.Size(784, 55);
            this.groupMysql.TabIndex = 11;
            this.groupMysql.TabStop = false;
            // 
            // txtSettings
            // 
            this.txtSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSettings.Location = new System.Drawing.Point(0, 24);
            this.txtSettings.Multiline = true;
            this.txtSettings.Name = "txtSettings";
            this.txtSettings.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSettings.Size = new System.Drawing.Size(784, 503);
            this.txtSettings.TabIndex = 0;
            // 
            // OPToolEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 582);
            this.Controls.Add(this.txtSettings);
            this.Controls.Add(this.groupMysql);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "OPToolEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Text Editor";
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupMysql.ResumeLayout(false);
            this.groupMysql.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openTXTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToTXTToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openTXTToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveTXTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnReplc;
        private System.Windows.Forms.TextBox txtWith;
        private System.Windows.Forms.GroupBox groupMysql;
        private System.Windows.Forms.TextBox txtSettings;
    }
}