namespace SHNDecrypt.Help
{
    partial class helpUpdates
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(helpUpdates));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.Items.AddRange(new object[] {
            "Update V3.4.14.0604:",
            "- Fixed OTD replace function.",
            "- Added .OTD file type.",
            "- Made main form window resizable.",
            "- Added recount function.",
            "- Added exception handling for copying and pasting.",
            "- Added ability to press enter to search on search screen.",
            "- Removed the need to register the software.",
            "- Improved Data Grid cell click method.",
            "- Added currently selected row.",
            "- Fixed new row index copying.",
            "- Added row recount error handling.",
            "- Cleaned and improved pasting function.",
            "- Item Editor now only opens for ItemInfo.shn.",
            "- Changed default paste value to 0.",
            "- Changed encoding to UTF8 which supports bigger charset.",
            "",
            "Update V3.5.14.0605:",
            "- Changed encoding to ISO-8859-1. ",
            "- Fixed row order when copying/pasting.",
            "- Fixed NPCDialogue.shn saving issues.",
            "",
            "Update V3.8.14.0620:",
            "- Made shop creator.",
            "- Added shop creator item list and search feature.",
            "- Added delete strip menu item.",
            "- Added most recently used file.",
            "- Fixed close tab exception when no tabs open.",
            "- Fixed delete tool strip menu exception when no file open.",
            "- Suppressed beep sound when pressing enter on search and NPC list.",
            "- Made ODT editor form resizable.",
            "- Added create row UI, with default value and base row.",
            "- Removed text default paste.",
            "- Added UTF7, UTF8, ISO-8859-1 and ISO-8859-2 encoding options.",
            "",
            "Update V3.9.14.0711:",
            "- Fixed shop creator empty input line.",
            "- Added file association exception handling.",
            "- Added delete row exception handling.",
            "- Fixed create row base row function.",
            "- Added error handling for data grid view.",
            "- Added drag and drop function.",
            "- Made search screen form resizable.",
            "- Reduced minimum size for main form.",
            "- Added GB2312 encoding for Chinese character support.",
            "- Fixed new row index, seemed to have been broken.",
            "- Removed group box text title in ODT editor.",
            "- Added row tally GUI.",
            "- Added ability to press enter for ODT replace function.",
            "- Added confirmation message for ODT replace function.",
            "- Added short cut keys for all functions which may need them.",
            "",
            "Update 4.0.14.0718:",
            "- When pasting you will automatically be taken to the new row.",
            "- Changed \"SHN - 1 files open\" to \"SHN - 1 file(s) open\".",
            "- Changed some short cut keys to prevent interference with each other.",
            "- Encoding type is saved in registry and will load on start up.",
            "- Cleaned up new file code, made it more efficient.",
            "- Removed unreferenced and unused code.",
            "- Added column, multiplication, division and bulk edit.",
            "- Added a replace feature.",
            "- Completely removed registration feature.",
            "- Made data grid double buffered at request.",
            "- Removed old file association and created new custom file association class.",
            "- Organised Visual Studio project.",
            "- Made the program run as admin.",
            "- Added confirmation message on column deletion.",
            "- Added updates UI.",
            "- Added go to function for search.",
            "- Added a progress bar for row filter.",
            "- Other minor bug fixes and improvements.",
            "",
            "Update 4.0.14.0801:",
            "- Made Go To function update current row position.",
            "- Column bulk edit, deletion, divide, multiply and rename no longer closes when y" +
                "ou click ok.",
            "- SHN files with blank columns are now loaded with a default unknown column name." +
                "",
            "- Empty cells are now saved as empty cells, without error.",
            "- The full version number is now shown in the window text.",
            "- Replace function now checks cell value instead of object data.",
            "- Fixed extensive loading time of large shn files, reducing loading times by 88%." +
                "",
            "",
            "Update 4.1.14.0814:",
            "- Remade search function.",
            "- Removed column refresher for search form.",
            "- Search form now saves upon exit.",
            "- You can no longer click away from search form window.",
            "- Added search form search parameters: contains, equals, starts with and ends wit" +
                "h.",
            "- When you first open the search form the data grid view will be populated.",
            "- If you search with an empty search field, it will reset your search.",
            "- The replace window is no longer be the top most window.",
            "- All buttons (i.e functions) in the replace form now check cell value instead of" +
                " object data.",
            "- Turned on WS_EX_COMPOSITED for main form and search form, making loading smooth" +
                "er.",
            "- Search form now takes you to the cell you selected on the main form.",
            "- Search parameters are loaded if any were set previously when searching.",
            "- The search form no longer resets your currently selected row when opening/closi" +
                "ng.",
            "- Now when dragging in files it will add them to your recent list.",
            "",
            "Update 4.1.14.0816:",
            "- Fixed save function.",
            "- Search form will no longer take you to the row selected in the main form.",
            "- Turned off WS_EX_COMPOSITED for main form.",
            "- Fixed search function, seemed to have been broken after I added the numbers \"00" +
                ":\".",
            "- You can now press Escape to close the goto form and the search form.",
            "",
            "Update 4.2.14.0817:",
            "- Fixed encoding type registry issues.",
            "- Fixed search form resetting main form datagrid issue.",
            "",
            "Update 4.2.14.1004:",
            "- Fixed search screen horizontal scroll bar not showing.",
            "- Updated NewRowIndex handling for Copy / Paste functions.",
            "- Only one message box is now shown if clip board data is invalid.",
            "- Made some changes to row filter UI.",
            "",
            "Update 4.4.14.1225:",
            "- Added search screen copy function.",
            "- Added search screen find function which takes you to the selected cell/row in m" +
                "ain grid.",
            "- Fixed search screen open/close cell and row positioning on main grid.",
            "- Changed copy and paste functions again.",
            "- Added exception handling for go to function.",
            "- Added shortcuts for copy and find options on search screen.",
            "- Files are no longer deleted if there is an error, but rather just not saved.",
            "- Files are now overwritten instead of deleted and re-written.",
            "- Added exclamation sign to the save error message box.",
            "",
            "Update 4.5.12.28:",
            "- Pasting should no longer add an empty row.",
            "- Added \"In Selection\" option to column editors and replace option.",
            "- Cleaned up the layout for column editor forms.",
            "- New version formatting.",
            "- Added loading time calculation for opening files.",
            "- Fixed select function on search screen.",
            "",
            "Update 4.6.01.01:",
            "- Added ISO-2022-JP encoding type.",
            "- Added BIG5 encoding type."});
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(353, 394);
            this.listBox1.TabIndex = 1;
            this.listBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 412);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(353, 64);
            this.textBox1.TabIndex = 10;
            this.textBox1.TabStop = false;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // helpUpdates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 485);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "helpUpdates";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Updates";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox textBox1;
    }
}