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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEPSG));
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
            resources.ApplyResources(this.lbEPSGCodes, "lbEPSGCodes");
            this.lbEPSGCodes.Name = "lbEPSGCodes";
            this.lbEPSGCodes.Sorted = true;
            this.lbEPSGCodes.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.lbEPSGCodes_Format);
            // 
            // btnSelectEpsg
            // 
            this.btnSelectEpsg.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.btnSelectEpsg, "btnSelectEpsg");
            this.btnSelectEpsg.Name = "btnSelectEpsg";
            this.btnSelectEpsg.UseVisualStyleBackColor = true;
            this.btnSelectEpsg.Click += new System.EventHandler(this.btnSelectEpsg_Click);
            // 
            // btnCancelEpsg
            // 
            this.btnCancelEpsg.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnCancelEpsg, "btnCancelEpsg");
            this.btnCancelEpsg.Name = "btnCancelEpsg";
            this.btnCancelEpsg.UseVisualStyleBackColor = true;
            this.btnCancelEpsg.Click += new System.EventHandler(this.btnCancelEpsg_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // frmEPSG
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelEpsg);
            this.Controls.Add(this.btnSelectEpsg);
            this.Controls.Add(this.lbEPSGCodes);
            this.Name = "frmEPSG";
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