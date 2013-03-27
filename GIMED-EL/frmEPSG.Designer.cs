namespace GIMED_EL
{
    partial class frmEPSG
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
            this.lbEPSGCodes = new System.Windows.Forms.ListBox();
            this.btnSelectEpsg = new System.Windows.Forms.Button();
            this.btnCancelEpsg = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbEPSGCodes
            // 
            this.lbEPSGCodes.FormattingEnabled = true;
            this.lbEPSGCodes.ItemHeight = 16;
            this.lbEPSGCodes.Location = new System.Drawing.Point(12, 74);
            this.lbEPSGCodes.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.lbEPSGCodes.Name = "lbEPSGCodes";
            this.lbEPSGCodes.Size = new System.Drawing.Size(355, 228);
            this.lbEPSGCodes.Sorted = true;
            this.lbEPSGCodes.TabIndex = 0;
            this.lbEPSGCodes.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.lbEPSGCodes_Format);
            // 
            // btnSelectEpsg
            // 
            this.btnSelectEpsg.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSelectEpsg.Location = new System.Drawing.Point(292, 308);
            this.btnSelectEpsg.Name = "btnSelectEpsg";
            this.btnSelectEpsg.Size = new System.Drawing.Size(75, 35);
            this.btnSelectEpsg.TabIndex = 1;
            this.btnSelectEpsg.Text = "ΟΚ";
            this.btnSelectEpsg.UseVisualStyleBackColor = true;
            this.btnSelectEpsg.Click += new System.EventHandler(this.btnSelectEpsg_Click);
            // 
            // btnCancelEpsg
            // 
            this.btnCancelEpsg.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelEpsg.Location = new System.Drawing.Point(211, 308);
            this.btnCancelEpsg.Name = "btnCancelEpsg";
            this.btnCancelEpsg.Size = new System.Drawing.Size(75, 35);
            this.btnCancelEpsg.TabIndex = 2;
            this.btnCancelEpsg.Text = "Άκυρο";
            this.btnCancelEpsg.UseVisualStyleBackColor = true;
            this.btnCancelEpsg.Click += new System.EventHandler(this.btnCancelEpsg_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(378, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Επιλέξτε το προβολικό σύστημα του εισερχόμενου αρχείου";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Αναζήτηση";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(97, 42);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(213, 22);
            this.textBox1.TabIndex = 5;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // frmEPSG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 355);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelEpsg);
            this.Controls.Add(this.btnSelectEpsg);
            this.Controls.Add(this.lbEPSGCodes);
            this.Name = "frmEPSG";
            this.Text = "frmEPSG";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbEPSGCodes;
        private System.Windows.Forms.Button btnSelectEpsg;
        private System.Windows.Forms.Button btnCancelEpsg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
    }
}