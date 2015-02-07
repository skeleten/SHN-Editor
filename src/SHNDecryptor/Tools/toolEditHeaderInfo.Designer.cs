namespace SHNDecrypt
{
    partial class editHeaderInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(editHeaderInfo));
            this.label1 = new System.Windows.Forms.Label();
            this.txtCryptHeader = new System.Windows.Forms.TextBox();
            this.btnEditCrypt = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHeader = new System.Windows.Forms.TextBox();
            this.btnChangeHeader = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblAttempt = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "CryptHeader:";
            // 
            // txtCryptHeader
            // 
            this.txtCryptHeader.Location = new System.Drawing.Point(16, 26);
            this.txtCryptHeader.Name = "txtCryptHeader";
            this.txtCryptHeader.Size = new System.Drawing.Size(599, 20);
            this.txtCryptHeader.TabIndex = 1;
            // 
            // btnEditCrypt
            // 
            this.btnEditCrypt.Location = new System.Drawing.Point(621, 25);
            this.btnEditCrypt.Name = "btnEditCrypt";
            this.btnEditCrypt.Size = new System.Drawing.Size(68, 20);
            this.btnEditCrypt.TabIndex = 2;
            this.btnEditCrypt.Text = "Modify";
            this.btnEditCrypt.UseVisualStyleBackColor = true;
            this.btnEditCrypt.Click += new System.EventHandler(this.btnEditCrypt_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Header:";
            // 
            // txtHeader
            // 
            this.txtHeader.Location = new System.Drawing.Point(16, 78);
            this.txtHeader.Name = "txtHeader";
            this.txtHeader.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtHeader.Size = new System.Drawing.Size(115, 20);
            this.txtHeader.TabIndex = 4;
            // 
            // btnChangeHeader
            // 
            this.btnChangeHeader.Location = new System.Drawing.Point(137, 78);
            this.btnChangeHeader.Name = "btnChangeHeader";
            this.btnChangeHeader.Size = new System.Drawing.Size(76, 20);
            this.btnChangeHeader.TabIndex = 5;
            this.btnChangeHeader.Text = "Modify";
            this.btnChangeHeader.UseVisualStyleBackColor = true;
            this.btnChangeHeader.Click += new System.EventHandler(this.btnChangeHeader_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(621, 65);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(68, 35);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(336, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(279, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Please be aware that changing this might corrupt your file!";
            // 
            // lblAttempt
            // 
            this.lblAttempt.AutoSize = true;
            this.lblAttempt.Location = new System.Drawing.Point(277, 8);
            this.lblAttempt.Name = "lblAttempt";
            this.lblAttempt.Size = new System.Drawing.Size(100, 13);
            this.lblAttempt.TabIndex = 8;
            this.lblAttempt.Text = "Decryption Attempt:";
            // 
            // frmEditFileProps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 110);
            this.Controls.Add(this.lblAttempt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnChangeHeader);
            this.Controls.Add(this.txtHeader);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnEditCrypt);
            this.Controls.Add(this.txtCryptHeader);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEditFileProps";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit File Properties";
            this.Load += new System.EventHandler(this.frmEditFileProps_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCryptHeader;
        private System.Windows.Forms.Button btnEditCrypt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtHeader;
        private System.Windows.Forms.Button btnChangeHeader;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblAttempt;
    }
}