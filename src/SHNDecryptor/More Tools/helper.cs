using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SHNDecrypt.More_Tools
{
    class helper
    {
        public String zgetstrto(String strin, int xint, char tochar)
        {
            String zxstring = "";
            int l = strin.Length;
            for (int xint2 = xint; xint2 < l; xint2++)
            {
                if (strin[xint2] == tochar)
                {
                    break;
                }
                else
                {
                    zxstring += strin[xint2];
                }
            }
            return zxstring;
        }
        public List<String> parseDatas(String strin, char parsechar)
        {
            List<String> sl = new List<String>();
            int l = strin.Length;
            int total = 0;
            String str = "";
            String tmp = "";
            while (total < l)
            {
                tmp = zgetstrto(strin, total, parsechar);
                sl.Add(tmp);
                str += tmp;
                str += parsechar;
                total = str.Length;
            }
            return sl;
        }
        public List<merchantRow> parseMerchantDatas(List<String> lin)
        {
            List<merchantRow> oo = new List<merchantRow>();
            int l = lin.Count;
            for (int xint = 0; xint < l; xint++)
            {
                merchantRow mr = new merchantRow();
                mr.items = new String[6];
                List<String> tmp = parseDatas(lin[xint], '	');
                // tmp [ 0 ] will always be "#Record"
                // tmp [ 1 ] ==> row ID
                // tmp [ 2 ] ~-~ [ 7 ] ==> items
                int l2 = tmp.Count;
                if (l2 > 7) l2 = 7;
                if (l2 > 0)
                {
                    try
                    {
                        mr.rowID = int.Parse(tmp[1]);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Fomrat error; example of what your clipboard should contain for this function:\n#Record	7	SpeedShield06	SpeedShield07	SpeedShield08	SpeedShield09	-	-\n#Record	8	HarmDefect05	HarmDefect06	HarmDefect07	HarmDefect08	-	-\n\n\nStack Trace: " + e.StackTrace);
                    }
                }
                int xint2 = 2;
                // add the items that aren't empty
                for (; xint2 < l2; xint2++)
                {
                    mr.items[(xint2 - 2)] = tmp[xint2];
                }
                // add the items that are empty as '-'
                for (; xint2 < 8; xint2++)
                {
                    mr.items[(xint2 - 2)] = "-";
                }
                oo.Add(mr);
            }
            return oo;
        }
        public struct merchantRow
        {
            public int rowID;
            public String[] items;
        }
        public String writeMerchantRowsToClipboard(List<merchantRow> rows)
        {
            String oo = "";
            int l = rows.Count;
            for (int xint = 0; xint < l; xint++)
            {
                oo += "#Record	";
                oo += rows[xint].rowID;
                for (int xint2 = 0; xint2 < 6; xint2++)
                {
                    oo += "	" + rows[xint].items[xint2];
                }
                if ((l - xint) > 1)
                {
                    oo += "\n";
                }
            }
            return oo;
        }
    }
}
