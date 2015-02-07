using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SHNDecrypt
{
    public partial class columnDivide : Form
    {
        frmMain frmColDivide;
        public columnDivide(frmMain form)
        {
            frmColDivide = form;
            InitializeComponent();
        }

        private void columnDivide_Load(object sender, EventArgs e)
        {
            if (frmColDivide.file == null)
            {
                this.Close();
                return;
            }
            init();
        }

        public void init()
        {
            if (frmColDivide.file.table == null) return;
            comboBox1.Items.Clear();
            for (int i = 0; i < frmColDivide.file.table.Columns.Count; i++)
            {
                comboBox1.Items.Add(frmColDivide.file.table.Columns[i].ColumnName);
            }
            comboBox1.SelectedIndex = 0;
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            int colIndex = frmColDivide.file.getColIndex(comboBox1.Items[comboBox1.SelectedIndex].ToString());
            if (colIndex < 0) return;
            double factor = 0;
            try
            {
                factor = double.Parse(txtFactor.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            string type = frmColDivide.file.table.Columns[colIndex].DataType.ToString();

            if (checkBox1.Checked != true)
            {
                for (int i = 0; i < frmColDivide.file.table.Rows.Count; i++)
                {
                    try
                    {
                        switch (type)
                        {
                            case "System.UInt16":
                                frmColDivide.file.table.Rows[i][colIndex] = (UInt16)((UInt16)frmColDivide.file.table.Rows[i][colIndex] / factor);
                                break;
                            case "System.UInt32":
                                frmColDivide.file.table.Rows[i][colIndex] = (UInt32)((UInt32)frmColDivide.file.table.Rows[i][colIndex] / factor);
                                break;
                            case "System.SByte":
                                frmColDivide.file.table.Rows[i][colIndex] = (SByte)((SByte)frmColDivide.file.table.Rows[i][colIndex] / factor);
                                break;
                            case "System.Byte":
                                frmColDivide.file.table.Rows[i][colIndex] = (Byte)((Byte)frmColDivide.file.table.Rows[i][colIndex] / factor);
                                break;
                            default:
                                frmColDivide.file.table.Rows[i][colIndex] = (int)((int)frmColDivide.file.table.Rows[i][colIndex] / factor);
                                break;
                        }
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); break; } //wrong item conv
                }
            }
            else
            {
                if (frmColDivide.dataGrid.SelectedRows.Count != 0)
                {
                    foreach (DataGridViewRow r in frmColDivide.dataGrid.SelectedRows)
                    {
                        try
                        {
                            switch (type)
                            {
                                case "System.UInt16":
                                    frmColDivide.file.table.Rows[r.Index][colIndex] = (UInt16)((UInt16)frmColDivide.file.table.Rows[r.Index][colIndex] / factor);
                                    break;
                                case "System.UInt32":
                                    frmColDivide.file.table.Rows[r.Index][colIndex] = (UInt32)((UInt32)frmColDivide.file.table.Rows[r.Index][colIndex] / factor);
                                    break;
                                case "System.SByte":
                                    frmColDivide.file.table.Rows[r.Index][colIndex] = (SByte)((SByte)frmColDivide.file.table.Rows[r.Index][colIndex] / factor);
                                    break;
                                case "System.Byte":
                                    frmColDivide.file.table.Rows[r.Index][colIndex] = (Byte)((Byte)frmColDivide.file.table.Rows[r.Index][colIndex] / factor);
                                    break;
                                default:
                                    frmColDivide.file.table.Rows[r.Index][colIndex] = (int)((int)frmColDivide.file.table.Rows[r.Index][colIndex] / factor);
                                    break;
                            }
                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message); break; } //wrong item conv
                    }
                }
                else 
                {
                    MessageBox.Show("Please select the appropriate rows to modify.");
                    frmColDivide.SQLStatus.Text = "Please select the appropriate rows to modify."; 
                }
            }
            //this.Close();
            frmColDivide.SQLStatus.Text = comboBox1.SelectedItem.ToString() + " column has been divided by " + factor.ToString() + ".";
        }
    }
}
