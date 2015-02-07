using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using Microsoft.Win32;

namespace SHNDecrypt
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }

        public static String assemblyName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
        public static RegistryKey rK = Registry.CurrentUser.CreateSubKey("Software\\" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + "\\Encoding", RegistryKeyPermissionCheck.ReadWriteSubTree);
        public static String eT;
        
        public static String searchParam0;
        public static int searchParam1;
        public static bool radioContains = false;
        public static bool radioEquals = false;
        public static bool radioStartsWith = false;
        public static bool radioEndsWith = false;
        public static String searchFile;

        public static void DoubleBuffered(this DataGridView dgv, bool setting)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);
        }
    }
}
