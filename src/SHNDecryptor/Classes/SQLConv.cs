using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SHNDecrypt
{
   public class SQLConv
    {
       public static string GetSQLType(Type type)
       {
           if (type == typeof(byte))
           {
               return "TINYINT(1)";
           } 
           else if(type == typeof(SByte)){
              return "TINYINT(1) UNSIGNED";
           }
           else if (type == typeof(UInt32))
           {
               return "INT(11) UNSIGNED";
           }
           else if (type == typeof(UInt16))
           {
               return "SMALLINT(5) UNSIGNED";
           }
           else if (type == typeof(Single))
           {
               return "FLOAT(10)";
           }
           else if (type == typeof(Int16))
           {
               return "SMALLINT(5)";
           }
           else if (type == typeof(Int32))
           {
               return "INT(11)";
           }
           else
           {
               return "TEXT";
           }
       }

       public static string CreateHeader(string name, bool drop)
       {
           string toret = "";
           if(drop) toret += "DROP TABLE IF EXISTS `" + name + "`;\r\n";
           toret += "CREATE TABLE `" + name + "` (";
           return toret;
       }

       public static string GetPrefix(Type type)
       {
           string toret = "";
           if (type == typeof(string)) toret = "'";
           return toret;
       }

       public static string InsterInto(string table, DataColumnCollection columns)
       {
           string to  ="";
           to += "INSERT INTO `" + table + "` (";
           for (int i = 0; i < columns.Count; i++)
           {
               to += "`" + columns[i].Caption + "`";
               if (i + 1 != columns.Count) to += ",";
           }
           to += ") VALUES \r\n";
           return to;

       }
    }
}
