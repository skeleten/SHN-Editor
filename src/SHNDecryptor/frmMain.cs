using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO.Compression;
using Microsoft.Win32;
using System.Diagnostics;

namespace SHNDecrypt
{
    public partial class frmMain : Form
    {
        private MRUManager mruManager;
        public Boolean dataGridError = false;

        public frmMain()
        {
            InitializeComponent();
        }

        void checkForParams()
        {
            string[] args = Environment.GetCommandLineArgs();

            if (args.Length == 1) return;
            string filePath = args[1];
            InitFile(filePath);
        }

        public TabControl FileTab { get { return FileTabs; } }

        private void frmMain_Load(object sender, EventArgs e)
        {
            bool isAso = FileAssociation.AssociationCheck(".shn", "SHN Tool");
            fileAssociationToolStripMenuItem.Checked = isAso;

            if (!isAso)
            {
                DialogResult result = MessageBox.Show("Do you want to associate this tool with SHN files?", "SHN", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes) CreateAssociation();
            }

            setRegistryInfo();

            this.mruManager = new MRUManager(recentToolStripMenuItem, Program.assemblyName, myOwnRecentFileGotClicked_handler);
            this.Text = "SHN Editor - V" + Application.ProductVersion;
            showHideMySQLToolStripMenuItem_Click_1(null, null);
            checkForParams();
        }

        private void setRegistryInfo()
        {
            try
            {
                Program.eT = Registry.CurrentUser.OpenSubKey("Software\\" + Program.assemblyName + "\\Encoding").GetValue("0").ToString();
            }
            catch (NullReferenceException)
            {
                Program.rK.SetValue("0", "ISO-8859-1");
                Program.eT = Registry.CurrentUser.OpenSubKey("Software\\" + Program.assemblyName + "\\Encoding").GetValue("0").ToString();
            }
            catch (Exception ex) 
            { 
                MessageBox.Show("An error occurred trying to get encoding type: " + ex.Message); 
            }
        }

        private void myOwnRecentFileGotClicked_handler(object obj, EventArgs evt)
        {
            string fName = (obj as ToolStripItem).Text;
            if (!File.Exists(fName))
            {
                if (MessageBox.Show(string.Format("{0} doesn't exist. Remove item?", fName), "File not found", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    this.mruManager.RemoveRecentFile(fName);
                return;
            }
            InitFile(fName);
        }

        void InitFile(string Filename, bool NewFile = false)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Restart();

            if (NewFile == false) 
            {
                if (!File.Exists(Filename)) return;
                if (Path.GetFileName(Filename) == "QuestData.shn")
                {
                    MessageBox.Show("Please use iQuest as this application cannot view this file.");
                    return;
                }
                if (!(Filename.ToLower().EndsWith(".shn"))) //other file handling
                {
                    SHNFile file = new SHNFile();
                    file.LoadMe(Filename);
                    OPToolEditor editor = new OPToolEditor(this, file.data, Path.GetExtension(Filename));
                    editor.ShowDialog();
                    return;
                }
            }
            try
            {
                TabPage page;
                SHNFile ifile;

                if (NewFile == true)
                {
                    ifile = new SHNFile();
                    ifile.CreateDefaultLayout();
                    page = new TabPage(Filename);
                }
                else
                {
                    page = new TabPage(Path.GetFileName(Filename));
                    ifile = new SHNFile(Filename);
                }

                FileTabs.TabPages.Add(page);
                FileTabs.SelectedTab = page;
                DataGridView grid = new DataGridView();
                page.Tag = grid;
                grid.Tag = ifile;

                /* dataGridView Properties Set Here */
                grid.DataSource = ifile.table;
                grid.AllowUserToDeleteRows = true;
                grid.AllowUserToOrderColumns = true;
                grid.AllowUserToResizeColumns = true;
                grid.DoubleBuffered(true);

                grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                grid.Location = new System.Drawing.Point(6, 19);
                grid.Name = "grid";
                grid.Size = new System.Drawing.Size(749, 470);
                grid.ScrollBars = ScrollBars.Both;
                grid.TabIndex = 1;
                grid.Dock = DockStyle.Fill;
                grid.DataError += new DataGridViewDataErrorEventHandler(grid_DataError);
                grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellClick);

                page.Controls.Add(grid);
                page.ToolTipText = Filename;
                if (!groupMysql.Visible) BigTabs(page); 
                this.Text = "SHN Editor - " + FileTabs.TabCount.ToString() + " file(s) open";
                stopwatch.Stop();
                SQLStatus.Text = "Loaded " + file.table.Columns.Count + " column(s) and " + (file.table.Rows.Count).ToString() + " row(s) in " + stopwatch.ElapsedMilliseconds + " milliseconds.";
            }
            catch (Exception e)
            {
                SQLStatus.Text = e.Message;
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitFile("New File.shn", true);
        }

        void grid_DataError(object sender, DataGridViewDataErrorEventArgs anError)
        {
            if (anError.Context == DataGridViewDataErrorContexts.Commit)
            {
                MessageBox.Show("Commit Error: " + anError.Exception.Message.ToString());
                dataGridError = true;
            }
            else if ((anError.Exception) is ConstraintException)
            {
                DataGridView view = (DataGridView)sender;
                view.Rows[anError.RowIndex].ErrorText = "an error";
                view.Rows[anError.RowIndex].Cells[anError.ColumnIndex].ErrorText = "an error";
                anError.ThrowException = false;
                dataGridError = true;
            }
            else
            {
                MessageBox.Show("An error occured: " + anError.Exception.Message.ToString());
                dataGridError = true;
            }
        }

        public SHNFile file
        {
            get
            {
                try
                {
                    return (SHNFile)dataGrid.Tag;
                }
                catch 
                { /*MessageBox.Show("No file found");*/ return null; }
            }
            set
            {
                try
                {
                    dataGrid.Tag = value;
                }
                catch { }
            }
        }

        public DataGridView dataGrid
        {
            get
            {
                try
                {
                    return (DataGridView)FileTabs.SelectedTab.Tag;
                }
                catch { return null; }
            }
            set
            {
                FileTabs.SelectedTab.Tag = value;
            }
        }

        void CreateAssociation()
        {
            string[] OpenWithList = new string[] { "notepad.exe", "wordpad.exe" };
            FileAssociation.AssociationCreation(".shn", "SHN Tool", "application/myfile", OpenWithList, true, "SHN Editor");
        }

        private void dataGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            MessageBox.Show("Data Type: " + ((DataTable)dataGrid.DataSource).Columns[e.ColumnIndex].DataType.Name);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog x = new OpenFileDialog();
            x.Filter = "SHN File (*.shn)|*.shn|OTD File (*.otd)|*.otd|Other File(*.*)|*.*";
            x.Title = "Select File";
            if (x.ShowDialog() == DialogResult.OK)
            {
                InitFile(x.FileName);
                if (recentToolStripMenuItem.DropDownItems.Count == 7)
                {
                    mruManager.RemoveRecentFile(recentToolStripMenuItem.DropDown.Items[0].Text);
                    mruManager.AddRecentFile(x.FileName);
                }
                else
                {
                    mruManager.AddRecentFile(x.FileName);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGrid == null) return;
            if (dataGrid.DataSource == null) return;
            SQLStatus.Text = "Busy...";
            string text = "";
            file.CreateSQL(out text, chkDrop.Checked);
            SQLScript.Text = text;
            SQLStatus.Text = "Done generating query.";
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (file == null) return;
            if (dataGrid == null) return;
            SQLScript.Text = string.Empty;
            file.Dispose();
            file = null;
            FileTabs.TabPages.Remove(FileTabs.SelectedTab);
            SQLStatus.Text = "Closed Tab.";
            this.Text = "SHN Editor - " + FileTabs.TabCount.ToString() + " file(s) open";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (SQLScript.Text.Length < 5) return;
            SaveFileDialog x = new SaveFileDialog();
            x.Filter = "SQL Script(*.sql)|*.sql";
            x.Title = "Save SQL Query";
            if (x.ShowDialog() == DialogResult.OK)
            {
                TextWriter tw = new StreamWriter(x.FileName);
                tw.Write(SQLScript.Text);
                tw.Close();
            }
            SQLStatus.Text = "File saved!";
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (file == null) return;
            if (dataGrid == null) return;
            SaveTo(file.Path);
        }

        void SaveTo(string FileName)
        {
            //if (File.Exists(FileName)) { File.Delete(FileName); }
            for (int i = 0; i < dataGrid.Columns.Count; i++)
            {
                file.displayToReal.Add(dataGrid.Columns[i].DisplayIndex, i); //lists all displayed
            }
            bool suc = file.Save(FileName);
            file.displayToReal.Clear();
            if (!suc)
            {
                //File.Delete(FileName);
                SQLStatus.Text = "Could not save file.";
            }
            else
                SQLStatus.Text = "File saved!";
            file.displayToReal.Clear();
        }

        private void copySelectedRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (file == null) return;
            if (dataGrid == null) return;
            try
            {
                if (dataGrid.Rows[dataGrid.NewRowIndex].Selected == true)
                {
                    dataGrid.Rows[dataGrid.NewRowIndex].Selected = false;
                    //dataGrid.CurrentCell = dataGrid.Rows[dataGrid.NewRowIndex - 1].Cells[0];
                    //dataGrid.Rows[dataGrid.NewRowIndex - 1].Selected = true;
                }
            }
            catch (Exception) { }
            //dataGrid.AllowUserToAddRows = false;
            MemoryStream stream = new MemoryStream();
            BinaryWriter writor = new BinaryWriter(stream);
            DataTable toCopyTo = new DataTable();
            toCopyTo = file.table.Clone();
            var orderedRows = dataGrid.SelectedRows.Cast<DataGridViewRow>().OrderBy(row => row.Index);
            writor.Write((int)dataGrid.SelectedRows.Count);
            foreach (DataGridViewRow row in orderedRows)
            {
                try
                {
                    DataRow myRow = (row.DataBoundItem as DataRowView).Row;
                    object[] EachColumn = myRow.ItemArray;
                    writor.Write((int)EachColumn.Length);

                    for (int i = 0; i < EachColumn.Length; i++)
                    {
                        writor.Write(file.table.Columns[i].ColumnName);
                        writor.Write(EachColumn[i].ToString());
                    }
                    writor.Write((byte)0x00);
                }
                catch (NullReferenceException NullEx)
                {
                    MessageBox.Show("You have selected an invalid row: " + Environment.NewLine + NullEx.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An unknown error has occured: " + Environment.NewLine + ex.Message);
                }
            }
            stream.Position = 0;
            byte[] toCop = new byte[stream.Length];
            stream.Read(toCop, 0, (int)stream.Length);
            Clipboard.SetData("Bytes", toCop);
            writor.Close();
            SQLStatus.Text = "Copied to clipboard.";
            //dataGrid.AllowUserToAddRows = true;
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
           if (file == null) return;
           if (FileTabs.TabPages.Count < 1) return;
           searchFind searchFrm = new searchFind(this);
           searchFrm.Text = "Search: " + FileTabs.SelectedTab.Text;
           searchFrm.ShowDialog();
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (file == null) return;
            if (FileTabs.TabPages.Count < 1) return;
            searchReplace srchrep = new searchReplace(this);
            srchrep.Show();
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (file == null) return;
            if (dataGrid == null) return;
            if (dataGrid.DataSource == null) return;
            columnRename box = new columnRename(this);
            box.init();
            box.ShowDialog();    
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGrid == null) return;
            if (dataGrid.DataSource == null) return;
            columnDeletion deleter = new columnDeletion(this);
            deleter.init();
            deleter.ShowDialog();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (file == null) return;
            if (dataGrid == null) return;
            if (dataGrid.DataSource == null)
            {
                MessageBox.Show("Please open a file first");
                return;
            }
            columnCreate colcreate = new columnCreate(this);
            colcreate.init();
            colcreate.ShowDialog();
        }

        private void deleteRowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (file == null) return;
            if (dataGrid == null) return;
            if (dataGrid.DataSource == null) return;
            foreach (DataGridViewRow item in this.dataGrid.SelectedRows)
            {
                try
                {
                    dataGrid.Rows.RemoveAt(item.Index);
                }
                catch { MessageBox.Show("You have selected to delete an invalid row."); }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void BigTabs(TabPage page)
        {
            page.Width += 290;
            ((DataGridView)page.Tag).Width += 290;
        }

        public void SmallTabs(TabPage page)
        {
            page.Width -= 290;
            ((DataGridView)page.Tag).Width -= 290;
        }

        private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGrid.SelectedRows.Count < 1)
                {
                    SHNColumn col = file.GetColByName(file.table.Columns[e.ColumnIndex].ColumnName);
                    string type = file.table.Columns[e.ColumnIndex].DataType.ToString();
                    SQLStatus.Text = col.name + ": " + type + " || SHN type: " + col.Type + " len: " + col.Lenght;                    
                }
                else
                {
                    SQLStatus.Text = "Ready. Columns: " + (dataGrid.Columns.Count).ToString() + " Row: " + dataGrid.CurrentCell.RowIndex + "/" + (file.table.Rows.Count - 1).ToString();
                }
            }
            catch (Exception ex)
            {
                SQLStatus.Text = ("Ready. Error Occured: " + ex.Message);
            }
        }

        private void expRateEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (file == null) return;
            if (!file.Path.EndsWith("MobInfoServer.shn"))
            {
                MessageBox.Show("Please open MobInfoServer.shn first!");
                return;
            }     
            ExpEditor editor = new ExpEditor(this);
            editor.ShowDialog();
        }

        private void oDTEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OPToolEditor editor = new OPToolEditor(this, new byte[1], ".dat");
            editor.ShowDialog();
        }

        private void translatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.file == null) return;
            Translator trans = new Translator(this);
            trans.ShowDialog();
        }

        private void columnMultiplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.file == null) return;
            columnBulkEdit mult = new columnBulkEdit(this);
            mult.ShowDialog();
        }

        private void columnBulkMultiplyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.file == null) return;
            columnMultiply cmulti = new columnMultiply(this);
            cmulti.ShowDialog();
        }

        private void columnDivideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.file == null) return;
            columnDivide cdivide = new columnDivide(this);
            cdivide.ShowDialog();
        }

        private void columnAutosetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (file == null) return;
            rowReplace setter = new rowReplace(this);
            setter.ShowDialog();
        }

        private void debugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DebugFrm debuggor = new DebugFrm(this);
            debuggor.ShowDialog();
        }

        private void transToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TransByList listor = new TransByList(this);
            //listor.ShowDialog();
            MessageBox.Show("Option disabled by creator");
        }

        private void itemEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (file == null)
            {
                return;
            }
            else
            {
                if (FileTabs.SelectedTab.Text.ToString() != "ItemInfo.shn")
                {
                    MessageBox.Show("Please open ItemInfo.shn first.");
                    return;
                }
                else
                {
                    ItemEditor editor = new ItemEditor(this);
                    editor.ShowDialog();
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (file == null) return;
            if (dataGrid == null) return;
            //dataGrid.AllowUserToAddRows = false;
            try
            {
                if (dataGrid.Rows[dataGrid.NewRowIndex].Selected == true)
                {
                    dataGrid.Rows[dataGrid.NewRowIndex].Selected = false;
                    dataGrid.CurrentCell = dataGrid.Rows[dataGrid.NewRowIndex - 1].Cells[0];
                    dataGrid.Rows[dataGrid.NewRowIndex - 1].Selected = true;
                }
                dataGrid.CurrentCell = dataGrid.Rows[dataGrid.NewRowIndex - 1].Cells[0];
                dataGrid.Rows[dataGrid.NewRowIndex].Selected = false;
            }
            catch (Exception) { }
            Boolean importFailed = false;
            if (Clipboard.ContainsData("Bytes"))
            {
                byte[] array = (byte[])Clipboard.GetData("Bytes");
                BinaryReader reader = new BinaryReader(new MemoryStream(array));
                int rowCount = reader.ReadInt32();
                for (int i = 0; i < rowCount; i++)
                {
                    int columnCount = reader.ReadInt32();
                    Dictionary<string, string> clipCols = new Dictionary<string, string>();
                    //byte test = 1;
                    for (int iz = 0; iz < columnCount; iz++)
                    {
                        string colName = reader.ReadString();
                        string colContent = reader.ReadString();
                        clipCols.Add(colName, colContent);
                    }
                    //test = reader.ReadByte();
                    //if (test != 0x00) return;
                    //allright, now they're all in the array
                    DataRow row = file.table.NewRow();
                    for (int iw = 0; iw < file.table.Columns.Count; iw++)
                    {
                        string internalName = file.table.Columns[iw].ColumnName;
                        try
                        {
                            if (clipCols[internalName].Length > 0)
                            {
                                if (clipCols.ContainsKey(internalName))
                                    row[iw] = clipCols[internalName];
                            }
                        }
                        catch (Exception ex)
                        {
                            if (importFailed == false)
                            {
                                MessageBox.Show("Program encountered an error while trying to import data: " + ex.Message);
                                SQLStatus.Text = ex.Message;
                                importFailed = true;
                            }
                        }

                    }
                    file.table.Rows.Add(row);
                    //dataGrid.AllowUserToAddRows = true;
                }
                reader.Close();
                if (file.table.DefaultView.Sort == String.Empty)
                {
                    dataGrid.CurrentCell = dataGrid.Rows[dataGrid.NewRowIndex - 1].Cells[0];
                    dataGrid.Rows[dataGrid.NewRowIndex - 1].Selected = true;
                }
                SQLStatus.Text = "Imported " + rowCount.ToString() + " rows.";
            }
            else
                SQLStatus.Text = "Clipboard has wrong type of data.";
            importFailed = false;
        }

        private void specOutputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (file == null) return;
            rowFilter mover = new rowFilter(this);
            mover.ShowDialog();
        }

        private void shopCreatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createShop creator = new createShop(this);
            creator.ShowDialog();
        }

        private void removeFileAsoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (fileAssociationToolStripMenuItem.Checked == false)
                {
                    //deleteAso();
                    FileAssociation.AssociationDeletion(".shn", "SHN Tool");
                    SQLStatus.Text = "File Association Deleted!";
                }
                else
                {
                    CreateAssociation();
                    SQLStatus.Text = "File Association Created!";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured: " + ex.Message);
            }
        }

        private void showHideMySQLToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (groupMysql.Visible)
            {
                groupMysql.Visible = false;
                FileTabs.Width += 290;
                foreach (TabPage page in FileTabs.TabPages)
                {
                    BigTabs(page);
                }
            }
            else
            {
                groupMysql.Visible = true;
                foreach (TabPage page in FileTabs.TabPages)
                {
                    SmallTabs(page);
                }
                FileTabs.Width -= 290;
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (file == null) return;
            if (dataGrid == null) return;
            SaveFileDialog diag = new SaveFileDialog();
            diag.Filter = "SHN File (*.shn)|*.shn";
            if (diag.ShowDialog() == DialogResult.OK)
            {
                SaveTo(diag.FileName);
            }
        }

        private void headerInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (file == null) return;
            if (dataGrid == null) return;
            editHeaderInfo props = new editHeaderInfo(this);
            props.ShowDialog();
        }

        private void toSHRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (file == null) return;
            if (dataGrid == null) return;
            SaveFileDialog diag = new SaveFileDialog();
            diag.Filter = "SHN Row File (*.shr)|*.shr";
            diag.Title = "Save to SHR";
            if(diag.ShowDialog () != DialogResult.OK) return;
            FileStream stream = new FileStream(diag.FileName, FileMode.Create);
            GZipStream zippr = new GZipStream(stream, CompressionMode.Compress);
            BinaryWriter writor = new BinaryWriter(zippr);
            DataTable toCopyTo = new DataTable();
            toCopyTo = file.table.Clone();
            writor.Write((int)dataGrid.SelectedRows.Count);
            foreach (DataGridViewRow row in dataGrid.SelectedRows)
            {
                DataRow myRow = (row.DataBoundItem as DataRowView).Row;
                object[] EachColumn = myRow.ItemArray;
                writor.Write((int)EachColumn.Length);
                for (int i = 0; i < EachColumn.Length; i++)
                {
                    writor.Write(file.table.Columns[i].ColumnName);
                    writor.Write(EachColumn[i].ToString());
                }
                writor.Write((byte)0x00);
            }
            zippr.Close();
            stream.Close();
            SQLStatus.Text = "Rows exported successfully!";
        }

        private void fromSHRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (file == null) return;
            OpenFileDialog diag = new OpenFileDialog();
            diag.Filter = "SHN Row File (*.shr)|*.shr";
            diag.Title = "Select SHN Row file";
            if (diag.ShowDialog() != DialogResult.OK) return;

            GZipStream filez = new GZipStream(File.Open(diag.FileName, FileMode.Open), CompressionMode.Decompress);
            BinaryReader reader = new BinaryReader(filez);
                int rowCount = reader.ReadInt32();
                for (int i = 0; i < rowCount; i++)
                {
                    int columnCount = reader.ReadInt32();
                    Dictionary<string, string> clipCols = new Dictionary<string, string>();
                    byte test = 1;
                    for (int iz = 0; iz < columnCount; iz++)
                    {
                        string colName = reader.ReadString();
                        string colContent = reader.ReadString();
                        clipCols.Add(colName, colContent);
                    }
                    test = reader.ReadByte();
                    if (test != 0x00) return;
                    //allright, now they're all in the array
                    DataRow row = file.table.NewRow();
                    for (int iw = 0; iw < file.table.Columns.Count; iw++)
                    {
                        string internalName = file.table.Columns[iw].ColumnName;
                        if (clipCols.ContainsKey(internalName))
                            row[iw] = clipCols[internalName];
                    }
                    file.table.Rows.Add(row);
                }
                filez.Close();
                SQLStatus.Text = "Imported " + rowCount.ToString() + " rows.";
        }

        private void toCSVBetaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (file == null) return;
            if (dataGrid == null) return;
            SaveFileDialog csvFile = new SaveFileDialog();
            csvFile.Title = "Export to CSV";
            csvFile.Filter = "Comma Separated File (*.csv)|*.csv";
            if (csvFile.ShowDialog() != DialogResult.OK) return;
            file.exportCVS(csvFile.FileName);
            SQLStatus.Text = "File saved!";
        }

        private void rowRecountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.file == null) return;
            rowTally rt = new rowTally(this);
            rt.ShowDialog();
        }

        private void updatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help.helpUpdates helpUps = new Help.helpUpdates(this);
            helpUps.ShowDialog();
        }

        private void creditsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            helpAbout AboutDialouge = new helpAbout();
            AboutDialouge.ShowDialog();
        }

        private void createToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (this.file == null) return;
            if (this.dataGrid == null) return;            
            createRow creator = new createRow(this);
            creator.ShowDialog();
        }
		
        private void FileTabs_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string filePath in files)
                {
                    InitFile(filePath);
                    if (recentToolStripMenuItem.DropDownItems.Count == 7)
                    {
                        mruManager.RemoveRecentFile(recentToolStripMenuItem.DropDown.Items[0].Text);
                        mruManager.AddRecentFile(filePath);
                    }
                    else
                    {
                        mruManager.AddRecentFile(filePath);
                    }
                }
            }
        }

        private void FileTabs_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void goToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.file == null) return;
            Search.searchGoTo GoTo = new Search.searchGoTo(this);
            GoTo.ShowDialog();
        }

        private void FileTabs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true;
                Application.Exit();
            }
        }

		private void encodingToolStripMenuItem_Click(object sender, EventArgs e) {
		  Tools.toolSetEncoding setEncodingWindow = new Tools.toolSetEncoding();
		  setEncodingWindow.ShowDialog();
		}
	}
}
