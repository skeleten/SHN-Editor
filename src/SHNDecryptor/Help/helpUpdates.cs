using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SHNDecrypt.Help
{
    public partial class helpUpdates : Form
    {
        frmMain helpUps;
        public helpUpdates(frmMain main)
        {
            this.helpUps = main;
            InitializeComponent();
        }
    }
}
