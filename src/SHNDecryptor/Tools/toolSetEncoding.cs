using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SHNDecrypt.Tools {
	public partial class toolSetEncoding : Form {
		public toolSetEncoding() {
			InitializeComponent();
		  PopulateEncodingList();
		}

	  protected virtual void PopulateEncodingList(string filter = "") {
	    lstEncoding.Items.Clear();
	    foreach (EncodingInfo e in Encoding.GetEncodings().Where(e => e.Name.ToUpper().Contains(filter.ToUpper()))) {
	      lstEncoding.Items.Add(e.Name);
	    }
	    SelectCurrentEncoding();
	  }
	  protected void SelectCurrentEncoding() {
	    string encoding = Program.eT;
			if(lstEncoding.Items.Contains(encoding))
				lstEncoding.SelectedItems.Add(encoding);
	  }

		private void btnOk_Click(object sender, EventArgs e) {
		  if (lstEncoding.SelectedItem == null) {
		    // TODO: MessageBox
		  } else {
		    string selectedEncoding = lstEncoding.SelectedItem as string;
				if (string.IsNullOrEmpty(selectedEncoding)) {
					// TODO: MessageBox
				}
		    Program.rK.SetValue("0", selectedEncoding);
		    Program.eT = selectedEncoding;

		    Close();
		  }
		}

		private void btnCancel_Click(object sender, EventArgs e) {
		  Close();
		}

		private void btnSearch_Click(object sender, EventArgs e) {
		  PopulateEncodingList(tbSearchText.Text);
		}

        private void tbSearchText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PopulateEncodingList(tbSearchText.Text);
            }
        }
    }
}
