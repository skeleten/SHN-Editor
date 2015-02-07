namespace SHNDecrypt.Search
{
    partial class searchGoTo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(searchGoTo));
            this.label1 = new System.Windows.Forms.Label();
            this.txtCurrentPos = new System.Windows.Forms.TextBox();
            this.txtPosLimit = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGoToPos = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current Position:";
            // 
            // txtCurrentPos
            // 
            this.txtCurrentPos.Enabled = false;
            this.txtCurrentPos.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCurrentPos.Location = new System.Drawing.Point(102, 12);
            this.txtCurrentPos.Name = "txtCurrentPos";
            this.txtCurrentPos.Size = new System.Drawing.Size(159, 20);
            this.txtCurrentPos.TabIndex = 1;
            // 
            // txtPosLimit
            // 
            this.txtPosLimit.Enabled = false;
            this.txtPosLimit.Location = new System.Drawing.Point(102, 38);
            this.txtPosLimit.Name = "txtPosLimit";
            this.txtPosLimit.Size = new System.Drawing.Size(159, 20);
            this.txtPosLimit.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Position Limit:";
            // 
            // txtGoToPos
            // 
            this.txtGoToPos.Location = new System.Drawing.Point(102, 64);
            this.txtGoToPos.Name = "txtGoToPos";
            this.txtGoToPos.Size = new System.Drawing.Size(159, 20);
            this.txtGoToPos.TabIndex = 5;
            this.txtGoToPos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGoToPos_KeyDown);
            this.txtGoToPos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGoToPos_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Go To Position:";
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(102, 90);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(159, 30);
            this.btnGo.TabIndex = 6;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            this.btnGo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGoToPos_KeyDown);
            // 
            // searchGoTo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 129);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtGoToPos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPosLimit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCurrentPos);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "searchGoTo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Go To";
            this.Load += new System.EventHandler(this.searchGoTo_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGoToPos_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCurrentPos;
        private System.Windows.Forms.TextBox txtPosLimit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGoToPos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGo;
    }
}