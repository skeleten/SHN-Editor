using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Windows.Forms;
using Microsoft.Win32;

namespace SHNDecrypt
{
    public class SHNColumn
    {
        public string name;
        public uint Type;
        public int Lenght;
    }

    public class SHNFile
    {
        public byte[] CryptHeader;
        public uint Header;
        public string Path;
        public DataTable table = new DataTable();
        public Dictionary<int, int> displayToReal = new Dictionary<int, int>();

        public List<SHNColumn> columns = new List<SHNColumn>();

        uint RecordCount;
        uint DefaultRecordLength;
        uint ColumnCount;
        string[] ColumnNames;
        uint[] ColumnTypes;
        int[] ColumnLengths;
        public byte[] data;
        public bool isTextData = false;

        public SHNFile() { }

        public void LoadMe(string path)
        {
            BinaryReaderEx r = new BinaryReaderEx(File.OpenRead(path));
            if (path.EndsWith(".shn"))
            {
                this.CryptHeader = r.ReadBytes(0x20);
                data = r.ReadBytes(r.ReadInt32() - 0x24);
            }
            else
            {
                data = r.ReadBytes((int)r.Length);
            }
            r.Close();
            this.Decrypt(data, 0, data.Length);
        }

        public void CreateDefaultLayout()
        {
            CryptHeader = new byte[32];
            SetCryptHeader("3B 02 00 00 32 30 30 35 2D 30 38 2D 32 36 20 BF C0 C8 C4 20 32 3A 33 00 6A 7F 00 00 01 00 00 00");
            Header = 0;
            CreateColumn("Empty Column", byte.MaxValue, 24, "");
            Path = "New File.shn";
        }

        public void SetCryptHeader(string hexString)
        {
            string[] tempArray = hexString.Split(' ');
            if (tempArray.Length != 32) throw new Exception("Incorrect header length!");
            for (int i = 0; i < tempArray.Length; i++)
                CryptHeader[i] = byte.Parse(tempArray[i], System.Globalization.NumberStyles.HexNumber);
        }

        public string GetCryptString()
        {
            string toret = "";
            for (int i = 0; i < CryptHeader.Length; i++)
            {
                if (i != CryptHeader.Length - 1)
                    toret += this.CryptHeader[i].ToString("X2") + " ";
                else
                    toret += this.CryptHeader[i].ToString("X2");
            }
            return toret;
        }

        public SHNFile(string path)
        {
            try
            {
                columns.Clear();
                this.Path = path;
                if (System.IO.Path.GetFileNameWithoutExtension(path).ToLower().Contains("textdata")) isTextData = true;
                BinaryReaderEx r;
                using (r = new BinaryReaderEx (File.OpenRead(path)))
                {
                    if (path.EndsWith(".shn"))
                    {
                        this.CryptHeader = r.ReadBytes(0x20);
                        data = r.ReadBytes(r.ReadInt32() - 0x24);
                    }
                    else
                        data = r.ReadBytes((int)r.Length);
                }
                this.Decrypt(data, 0, data.Length);
                r = new BinaryReaderEx(new MemoryStream(data));
                this.Header = r.ReadUInt32();

                //Parse columns
                this.RecordCount = r.ReadUInt32();
                this.DefaultRecordLength = r.ReadUInt32();
                this.ColumnCount = r.ReadUInt32();
                this.ColumnNames = new string[this.ColumnCount];
                this.ColumnTypes = new uint[this.ColumnCount];
                this.ColumnLengths = new int[this.ColumnCount];

                int num2 = 2;
                int unkCols = 0;
                for (uint i = 0; i < this.ColumnCount; i++)
                {
                    string str = r.ReadString(0x30);
                    uint num4 = r.ReadUInt32();
                    int num5 = r.ReadInt32();

                    SHNColumn col = new SHNColumn();
                    if (str.Length == 0 || String.IsNullOrWhiteSpace(str))
                    {
                        str = "UnkCol" + unkCols.ToString();
                        unkCols++;
                    }
                    col.name = str;
                    col.Type = num4;
                    col.Lenght = num5;
                    columns.Add(col);
                    this.ColumnNames[i] = str;
                    this.ColumnTypes[i] = num4;
                    this.ColumnLengths[i] = num5;
                    num2 += num5;
                }
                if (num2 != this.DefaultRecordLength)
                {
                    throw new Exception("Wrong record length!");
                }
                //generate columns
                this.GenerateColumns(table, columns);
                //add data into rows
                this.ReadRows(r, table);
            }
            catch (Exception e)
            {
                Stream X = new FileStream("unk.dat", FileMode.OpenOrCreate);
                BinaryWriter lol = new BinaryWriter(X);
                lol.Write(data, 0, data.Length);
                lol.Close();
                //throw new Exception("Unknown File Type -- dec to unk.dat Reason: " + e.Message);
                throw new Exception("An error occured trying to open the file: " + e.Message);
            }
        }

        public void Dispose()
        {
            table = null;
            CryptHeader = null;
        }

        public void CreateSQL(out string Output, bool drop)
        {
            Output = string.Empty;
            string tablename = "data_" + System.IO.Path.GetFileNameWithoutExtension(Path);
            Output += SQLConv.CreateHeader(tablename, drop) + "\r\n";
            for (int i = 0; i < table.Columns.Count; i++)
            {
                string toadd = "";
                toadd += "`" + table.Columns[i].Caption + "` " + SQLConv.GetSQLType(table.Columns[i].DataType);
                if (!(i + 1 == table.Columns.Count)) toadd += ",";
                toadd += "\r\n";
                Output += toadd;
            }
            Output += "); \r\n\r\n";

            int rowIndex = 0;
            int rowReadCount = 2000;
            if (table.Rows.Count < 2000) rowReadCount = table.Rows.Count;
            while (rowIndex < table.Rows.Count - 1) //arrays start @ zero
            {
                Output += SQLConv.InsterInto(tablename, table.Columns);
                int columncount = table.Columns.Count;
                for (int i = rowIndex; i < rowReadCount + rowIndex; i++) //each row
                {
                    //write each column value
                    string line = "(";
                    for (int iz = 0; iz < columncount; iz++) //each column
                    {
                        string prefix = SQLConv.GetPrefix(table.Columns[iz].DataType);
                        string value = Convert.ToString(table.Rows[i][iz]);
                        value = value.Replace("'", "\\'");
                        line += prefix + value + prefix;
                        if (iz + 1 != columncount) line += ",";
                    }
                    line += ")";
                    if (i + 1 != rowReadCount + rowIndex)
                        line += ",";
                    else line += ";";
                    Output += line + "\r\n";
                }
                rowIndex += rowReadCount;
                if (table.Rows.Count - rowIndex < 2000) rowReadCount = table.Rows.Count - rowIndex;
            }
        }

        public uint GetDefaultRecLen()
        {
            uint start = 2;
            foreach (DataColumn colz in table.Columns)
            {
                SHNColumn col = GetColByName(colz.ColumnName);
                start += (uint)col.Lenght;
            }
            return start;
        }

        public bool Save(string file)
        {
            MemoryStream output = new MemoryStream();
            BinaryWriter w = new BinaryWriter(output);
            try
            {
                //this.table.DefaultView.Sort = this.table.Columns[0].ColumnName;
                //this.table = this.table.DefaultView.ToTable();
                w.Write(this.Header);
                w.Write(this.table.Rows.Count); //rowcount
                w.Write(GetDefaultRecLen());
                w.Write(this.table.Columns.Count);
                for (int i = 0; i < this.table.Columns.Count; i++)
                {
                    SHNColumn colz = GetColByName(this.table.Columns[displayToReal[i]].ColumnName); //converts the display to the row order
                    if (colz.name.Contains("UnkCol"))
                    {
                        w.Write(new byte[0x30]); //empty name
                    }
                    else
                    {
                        this.WriteString(w, colz.name, 0x30);
                    }
                    w.Write(colz.Type);
                    w.Write(colz.Lenght);
                }
                this.WriteRows(w);
                byte[] sourceArray = output.GetBuffer();
                long length = output.Length;
                byte[] destinationArray = new byte[length];
                Array.Copy(sourceArray, destinationArray, length);
                this.Decrypt(destinationArray, 0, destinationArray.Length);
                w.Close();
                w = new BinaryWriter(File.Create(file));
                w.Write(this.CryptHeader);
                w.Write((int)(destinationArray.Length + 0x24));
                w.Write(destinationArray);
                w.Close();
                Path = file;
                return true;
            }
            catch (Exception ex)
            {
                w.Close();
                MessageBox.Show("Could not save file: " + ex.Message, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public void DeleteColumn(string name)
        {
            columns.Remove(GetColByName(name));
            table.Columns.Remove(GetDataColByName(name));
        }

        public void CreateColumn(string name, int len, uint type, string defaultval)
        {
            SHNColumn newCol = new SHNColumn();
            newCol.name = name;
            newCol.Lenght = len;
            newCol.Type = type;
            columns.Add(newCol);

            DataColumn column = new DataColumn();
            column.ColumnName = name;
            column.DefaultValue = defaultval;
            column.DataType = GetType(newCol);
            table.Columns.Add(column);
        }

        public void EditColumnName(string from, string to)
        {
            DataColumn olddat = GetDataColByName(from);
            olddat.ColumnName = to;

            SHNColumn colz = GetColByName(from);
            colz.name = to;
        }

        public DataColumn GetDataColByName(string name)
        {
            for (int i = 0; i < table.Columns.Count; i++)
            {
                if (table.Columns[i].ColumnName == name) return table.Columns[i];
            }
            return null;
        }

        public SHNColumn GetColByName(string name)
        {
            foreach (SHNColumn col in columns)
            {
                if (col.name.ToLower() == name.ToLower()) return col;
            }
            return null;
        }

        public int GetRowByIndex(int ColIndex, string RowInput)
        {
            for (int i = 0; i < this.table.Rows.Count; i++)
            {
                if (this.table.Rows[i][ColIndex].ToString().ToLower() == RowInput.ToLower()) return i;
            }
            return -1;
        }

        private void WriteRows(BinaryWriter w)
        {
            for (int iz = 0; iz < this.table.Rows.Count; iz++)
            {
                DataRow row = this.table.Rows[iz];
                long position = w.BaseStream.Position;
                w.Write((ushort)0); //show new start

                for (int i = 0; i < this.table.Columns.Count; i++)
                {
                    object obj2 = row.ItemArray[displayToReal[i]];
                    if (obj2 == null) obj2 = (string)"0";
                    SHNColumn col = GetColByName(this.table.Columns[displayToReal[i]].ColumnName);
                    switch (col.Type)
                    {
                        case 1:
                            if (obj2 is string)
                            {
                                obj2 = byte.Parse((string)obj2);
                            }
                            w.Write((byte)obj2);
                            break;

                        case 2:
                            if (obj2 is string)
                            {
                                obj2 = ushort.Parse((string)obj2);
                            }
                            w.Write((ushort)obj2);
                            break;

                        case 3:
                            if (obj2 is string)
                            {
                                obj2 = uint.Parse((string)obj2);
                            }
                            w.Write((uint)obj2);
                            break;

                        case 5:
                            if (obj2 is string)
                            {
                                obj2 = float.Parse((string)obj2);
                            }
                            w.Write((float)obj2);
                            break;

                        case 9:
                            if (String.IsNullOrWhiteSpace(obj2.ToString()))
                            {
                                this.WriteString(w, obj2.ToString(), col.Lenght);
                            }
                            else
                            {
                                this.WriteString(w, (string)obj2, col.Lenght);
                            }
                            break;

                        case 11:
                            if (obj2 is string)
                            {
                                obj2 = uint.Parse((string)obj2);
                            }
                            w.Write((uint)obj2);
                            break;

                        case 12:
                            if (obj2 is string)
                            {
                                obj2 = byte.Parse((string)obj2);
                            }
                            w.Write((byte)obj2);
                            break;

                        case 13:
                            if (obj2 is string)
                            {
                                obj2 = short.Parse((string)obj2);
                            }
                            w.Write((short)obj2);
                            break;

                        case 0x10:
                            if (obj2 is string)
                            {
                                obj2 = byte.Parse((string)obj2);
                            }
                            w.Write((byte)obj2);
                            break;

                        case 0x12:
                            if (obj2 is string)
                            {
                                obj2 = uint.Parse((string)obj2);
                            }
                            w.Write((uint)obj2);
                            break;

                        case 20:
                            if (obj2 is string)
                            {
                                obj2 = sbyte.Parse((string)obj2);
                            }
                            w.Write((sbyte)obj2);
                            break;

                        case 0x15:
                            if (obj2 is string)
                            {
                                obj2 = short.Parse((string)obj2);
                            }
                            w.Write((short)obj2);
                            break;

                        case 0x16:
                            if (obj2 is string)
                            {
                                obj2 = int.Parse((string)obj2);
                            }
                            w.Write((int)obj2);
                            break;

                        case 0x18:
                            this.WriteString(w, (string)obj2, col.Lenght);
                            break;

                        case 0x1a:
                            this.WriteString(w, (string)obj2, -1);
                            break;

                        case 0x1b:
                            if (obj2 is string)
                            {
                                obj2 = uint.Parse((string)obj2);
                            }
                            w.Write((uint)obj2);
                            break;
                    }
                }
                long num3 = w.BaseStream.Position - position;
                long offset = w.BaseStream.Position;
                w.BaseStream.Seek(position, SeekOrigin.Begin);
                w.Write((ushort)num3);
                w.BaseStream.Seek(offset, SeekOrigin.Begin);
            }
        }

        public int getColIndex(string name)
        {
            for (int i = 0; i < this.table.Columns.Count; i++)
            {
                if (this.table.Columns[i].ColumnName == name) return i;
            }
            return -1;
        }

        private void WriteString(BinaryWriter w, string s, int length)
        {
            Encoding enc = Encoding.GetEncoding(Program.eT);
            byte[] bytes = enc.GetBytes(s);

            if (length == -1) //write unkLen
            {
                w.Write(bytes);
                w.Write((byte)0); //end of string 
                return;
            }

            byte[] destinationArray = new byte[length];
            Array.Copy(bytes, destinationArray, Math.Min(length, bytes.Length));
            w.Write(destinationArray);
        }

        public void exportCVS(string path)
        {
            TextWriter writer = new StreamWriter(path);
            foreach (DataColumn col in table.Columns)
            {
                SHNColumn colz = GetColByName(col.ColumnName);
                writer.Write(colz.name + ", ");  //"@" + colz.Lenght + "@" + colz.Type
            }
            writer.Write(writer.NewLine); //end all columns
            foreach (DataRow row in table.Rows)
            {
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    string s = row[i].ToString();
                    if (s.Contains('"')) s = s.Replace('"', ' ');
                    writer.Write("\"" + s + "\"");
                    //writer.Write(s);
                    if (i + 1 == table.Columns.Count)
                        writer.Write(writer.NewLine);
                    else
                        writer.Write(',');
                }
            }
            writer.Close();
        }

        private void ReadRows(BinaryReaderEx r, DataTable table)
        {
            object[] values = new object[columns.Count];
            for (uint i = 0; i < RecordCount; i++)
            {
                r.ReadUInt16();
                for (int j = 0; j < columns.Count; j++)
                {
                    switch (this.columns[j].Type)
                    {
                        case 1:
                            values[j] = r.ReadByte();
                            break;

                        case 2:
                            values[j] = r.ReadUInt16();
                            break;

                        case 3:
                            values[j] = r.ReadUInt32();
                            break;

                        case 5:
                            values[j] = r.ReadSingle();
                            break;

                        case 9:
                            values[j] = r.ReadString(this.ColumnLengths[j]);
                            break;

                        case 11:
                            values[j] = r.ReadUInt32();
                            break;

                        case 12:
                            values[j] = r.ReadByte();
                            break;

                        case 13:
                            values[j] = r.ReadInt16();
                            break;

                        case 0x10:
                            values[j] = r.ReadByte();
                            break;

                        case 0x12:
                            values[j] = r.ReadUInt32();
                            break;

                        case 20:
                            values[j] = r.ReadSByte();
                            break;

                        case 0x15:
                            values[j] = r.ReadInt16();
                            break;

                        case 0x16:
                            values[j] = r.ReadInt32();
                            break;

                        case 0x18:
                            values[j] = r.ReadString(this.ColumnLengths[j]);
                            break;

                        case 0x1a: //unk lenght
                            values[j] = r.ReadString();
                            break;

                        case 0x1b:
                            values[j] = r.ReadUInt32();
                            break;
                    }
                }
                table.Rows.Add(values);
            }
        }

        private void GenerateColumns(DataTable table, List<SHNColumn> cols)
        {
            for (int i = 0; i < cols.Count; i++)
            {
                DataColumn column = new DataColumn();
                column.ColumnName = cols[i].name;
                column.DataType = GetType(cols[i]);
                table.Columns.Add(column);
            }
        }

        public Type GetType(SHNColumn col)
        {
            switch (col.Type)
            {
                default:
                    return typeof(object);
                case 1:
                case 12:
                    return typeof(byte);
                case 2:
                    return typeof(UInt16);
                case 3:
                case 11:
                    return typeof(UInt32);
                case 5:
                    return typeof(Single);
                case 0x15:
                case 13:
                    return typeof(Int16);
                case 0x10:
                    return typeof(byte);
                case 0x12:
                case 0x1b:
                    return typeof(UInt32);
                case 20:
                    return typeof(SByte);
                case 0x16:
                    return typeof(Int32);
                case 0x18:
                case 0x1a:
                case 9:
                    return typeof(string);
            }
        }

        private void Decrypt(byte[] data, int index, int length)
        {
            if (((index < 0) | (length < 1)) | ((index + length) > data.Length))
            {
                throw new IndexOutOfRangeException();
            }
            byte num = (byte)length;
            for (int i = length - 1; i >= 0; i--)
            {
                data[i] = (byte)(data[i] ^ num);
                byte num3 = (byte)i;
                num3 = (byte)(num3 & 15);
                num3 = (byte)(num3 + 0x55);
                num3 = (byte)(num3 ^ ((byte)(((byte)i) * 11)));
                num3 = (byte)(num3 ^ num);
                num3 = (byte)(num3 ^ 170);
                num = num3;
            }
        }
    }

    internal class BinaryReaderEx : BinaryReader
    {
        // Fields
        private static byte[] Buffer = new byte[0x100];
        private const int BufferLength = 0x100;

        // Properties
        public long Length { get { return this.BaseStream.Length; } }

        // Methods
        public BinaryReaderEx(Stream input) : base(input) { }
        
        private String _ReadString(uint bytes)
        {
            string str = string.Empty;

            if (bytes > 0x100) { str = ReadString((uint)(bytes - 0x100)); }

            this.Read(Buffer, 0, (int)bytes);

            Encoding enc = Encoding.GetEncoding(Program.eT);
            string data = enc.GetString(Buffer, 0, (int) bytes);
            return str + data;
        }

        public override String ReadString()
        {
            int count = 0;
            for (byte i = ReadByte(); i != 0; i = ReadByte()) //read until there's a 00
            {
                Buffer[count++] = i;
                if (count >= 0x100)
                    break;
            }
            string str = Encoding.GetEncoding(Program.eT).GetString(Buffer, 0, count);
            if (count == 0x100) { str = str + ReadString(); }
            return str;
        }

        public String ReadString(int bytes)
        {
            if (bytes > 0) { return this.ReadString((uint)bytes); }
            return string.Empty;
        }

        public String ReadString(uint bytes) { return _ReadString(bytes).TrimEnd(new char[1]); }
    }
}
