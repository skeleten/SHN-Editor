namespace SHNDecrypt
{
    partial class Translator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Translator));
            this.label1 = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbOrTrans = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbOrIndex = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbLanTrans = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbLanIndex = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDo = new System.Windows.Forms.Button();
            this.txtInfo = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDefault = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please open the other language SHN";
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(17, 25);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(72, 27);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbOrTrans);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbOrIndex);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(17, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(207, 103);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Original:";
            // 
            // cmbOrTrans
            // 
            this.cmbOrTrans.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrTrans.FormattingEnabled = true;
            this.cmbOrTrans.Location = new System.Drawing.Point(18, 69);
            this.cmbOrTrans.Name = "cmbOrTrans";
            this.cmbOrTrans.Size = new System.Drawing.Size(177, 21);
            this.cmbOrTrans.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Column to translate:";
            // 
            // cmbOrIndex
            // 
            this.cmbOrIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrIndex.FormattingEnabled = true;
            this.cmbOrIndex.Location = new System.Drawing.Point(57, 17);
            this.cmbOrIndex.Name = "cmbOrIndex";
            this.cmbOrIndex.Size = new System.Drawing.Size(100, 21);
            this.cmbOrIndex.TabIndex = 1;
            this.cmbOrIndex.SelectedIndexChanged += new System.EventHandler(this.cmbOrIndex_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Index:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbLanTrans);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cmbLanIndex);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(272, 58);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(207, 103);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Language SHN:";
            // 
            // cmbLanTrans
            // 
            this.cmbLanTrans.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLanTrans.FormattingEnabled = true;
            this.cmbLanTrans.Location = new System.Drawing.Point(18, 69);
            this.cmbLanTrans.Name = "cmbLanTrans";
            this.cmbLanTrans.Size = new System.Drawing.Size(177, 21);
            this.cmbLanTrans.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Translation source:";
            // 
            // cmbLanIndex
            // 
            this.cmbLanIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLanIndex.FormattingEnabled = true;
            this.cmbLanIndex.Location = new System.Drawing.Point(57, 17);
            this.cmbLanIndex.Name = "cmbLanIndex";
            this.cmbLanIndex.Size = new System.Drawing.Size(100, 21);
            this.cmbLanIndex.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Index:";
            // 
            // btnDo
            // 
            this.btnDo.Location = new System.Drawing.Point(203, 167);
            this.btnDo.Name = "btnDo";
            this.btnDo.Size = new System.Drawing.Size(90, 40);
            this.btnDo.TabIndex = 4;
            this.btnDo.Text = "Translate!";
            this.btnDo.UseVisualStyleBackColor = true;
            this.btnDo.Click += new System.EventHandler(this.btnDo_Click);
            // 
            // txtInfo
            // 
            this.txtInfo.AutoSize = true;
            this.txtInfo.Location = new System.Drawing.Point(37, 225);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(0, 13);
            this.txtInfo.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 179);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Default Val:";
            // 
            // txtDefault
            // 
            this.txtDefault.Location = new System.Drawing.Point(90, 176);
            this.txtDefault.Name = "txtDefault";
            this.txtDefault.Size = new System.Drawing.Size(84, 20);
            this.txtDefault.TabIndex = 7;
            this.txtDefault.Text = "donothing";
            // 
            // Translator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 220);
            this.Controls.Add(this.txtDefault);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.btnDo);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Translator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Translator";
            this.Load += new System.EventHandler(this.Translator_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbOrIndex;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbOrTrans;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbLanTrans;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbLanIndex;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDo;
        private System.Windows.Forms.Label txtInfo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDefault;
    }
}