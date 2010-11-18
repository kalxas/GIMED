/*
   Name:         GIMED
   Version:      1.2.4
   Author:       Angelos Tzotsos <tzotsos@gmail.com>
   Date:         03/11/10
   Modified:     03/11/10
   Description:  Greek INSPIRE Metadata Editor

   Copyright (C) November 2010 Angelos Tzotsos <tzotsos@gmail.com>

   This program is free software: you can redistribute it and/or modify
   it under the terms of the GNU General Public License as published by
   the Free Software Foundation, either version 3 of the License, or
   (at your option) any later version.

   This program is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
   GNU General Public License for more details.

   You should have received a copy of the GNU General Public License
   along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

partial class GIMEDForm_el
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
        this.label1 = new System.Windows.Forms.Label();
        this.textBox1 = new System.Windows.Forms.TextBox();
        this.DataFileButton = new System.Windows.Forms.Button();
        this.SaveXMLButton = new System.Windows.Forms.Button();
        this.LoadXMLButton = new System.Windows.Forms.Button();
        this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
        this.ValidateButton = new System.Windows.Forms.Button();
        this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
        this.mdControl1 = new Inspire.Metadata.MDControl();
        this.AboutButton = new System.Windows.Forms.Button();
        this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
        this.SuspendLayout();
        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(2, 6);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(149, 13);
        this.label1.TabIndex = 1;
        this.label1.Text = "Ψηφιακό αρχείο δεδομένων:";
        // 
        // textBox1
        // 
        this.textBox1.Location = new System.Drawing.Point(5, 22);
        this.textBox1.Name = "textBox1";
        this.textBox1.Size = new System.Drawing.Size(242, 20);
        this.textBox1.TabIndex = 2;
        this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
        // 
        // DataFileButton
        // 
        this.DataFileButton.Location = new System.Drawing.Point(253, 22);
        this.DataFileButton.Name = "DataFileButton";
        this.DataFileButton.Size = new System.Drawing.Size(32, 20);
        this.DataFileButton.TabIndex = 3;
        this.DataFileButton.Text = "...";
        this.DataFileButton.UseVisualStyleBackColor = true;
        this.DataFileButton.Click += new System.EventHandler(this.DataFileButton_Click);
        // 
        // SaveXMLButton
        // 
        this.SaveXMLButton.Enabled = false;
        this.SaveXMLButton.Location = new System.Drawing.Point(495, 6);
        this.SaveXMLButton.Name = "SaveXMLButton";
        this.SaveXMLButton.Size = new System.Drawing.Size(91, 36);
        this.SaveXMLButton.TabIndex = 28;
        this.SaveXMLButton.Text = "Αποθήκευση αρχείου XML";
        this.SaveXMLButton.Click += new System.EventHandler(this.SaveXMLButton_Click);
        // 
        // LoadXMLButton
        // 
        this.LoadXMLButton.Location = new System.Drawing.Point(303, 6);
        this.LoadXMLButton.Name = "LoadXMLButton";
        this.LoadXMLButton.Size = new System.Drawing.Size(82, 36);
        this.LoadXMLButton.TabIndex = 29;
        this.LoadXMLButton.Text = "’νοιγμα αρχείου XML";
        this.LoadXMLButton.Click += new System.EventHandler(this.LoadXMLButton_Click);
        // 
        // openFileDialog1
        // 
        this.openFileDialog1.FileName = "openFileDialog1";
        // 
        // ValidateButton
        // 
        this.ValidateButton.Location = new System.Drawing.Point(391, 6);
        this.ValidateButton.Name = "ValidateButton";
        this.ValidateButton.Size = new System.Drawing.Size(98, 36);
        this.ValidateButton.TabIndex = 30;
        this.ValidateButton.Text = "Πιστοποίηση Μεταδεδομένων";
        this.ValidateButton.Click += new System.EventHandler(this.ValidateButton_Click);
        // 
        // mdControl1
        // 
        this.mdControl1.Location = new System.Drawing.Point(5, 48);
        this.mdControl1.Name = "mdControl1";
        this.mdControl1.Size = new System.Drawing.Size(592, 529);
        this.mdControl1.TabIndex = 31;
        // 
        // AboutButton
        // 
        this.AboutButton.Location = new System.Drawing.Point(587, 0);
        this.AboutButton.Name = "AboutButton";
        this.AboutButton.Size = new System.Drawing.Size(10, 10);
        this.AboutButton.TabIndex = 32;
        this.AboutButton.Text = "?";
        this.AboutButton.UseVisualStyleBackColor = true;
        this.AboutButton.Click += new System.EventHandler(this.AboutButton_Click);
        // 
        // openFileDialog2
        // 
        this.openFileDialog2.FileName = "openFileDialog2";
        // 
        // GIMEDForm_el
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(600, 582);
        this.Controls.Add(this.AboutButton);
        this.Controls.Add(this.mdControl1);
        this.Controls.Add(this.ValidateButton);
        this.Controls.Add(this.LoadXMLButton);
        this.Controls.Add(this.SaveXMLButton);
        this.Controls.Add(this.DataFileButton);
        this.Controls.Add(this.textBox1);
        this.Controls.Add(this.label1);
        this.Name = "GIMEDForm_el";
        this.Text = "Ελληνικός Επεξεργαστής Μεταδεδομένων INSPIRE - GIMED";
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Button DataFileButton;
    public System.Windows.Forms.Button SaveXMLButton;
    public System.Windows.Forms.Button LoadXMLButton;
    private System.Windows.Forms.OpenFileDialog openFileDialog1;
    public System.Windows.Forms.Button ValidateButton;
    private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    private Inspire.Metadata.MDControl mdControl1;
    private System.Windows.Forms.Button AboutButton;
    private System.Windows.Forms.OpenFileDialog openFileDialog2;
}


