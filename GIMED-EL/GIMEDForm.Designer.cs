/*
   Name:         GIMED
   Version:      1.2.5
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

partial class GIMEDForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GIMEDForm));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.DataFileButton = new System.Windows.Forms.Button();
            this.SaveXMLButton = new System.Windows.Forms.Button();
            this.LoadXMLButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.ValidateButton = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.AboutButton = new System.Windows.Forms.Button();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.mdControl1 = new Inspire.Metadata.MDControl();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // DataFileButton
            // 
            resources.ApplyResources(this.DataFileButton, "DataFileButton");
            this.DataFileButton.Name = "DataFileButton";
            this.DataFileButton.UseVisualStyleBackColor = true;
            this.DataFileButton.Click += new System.EventHandler(this.DataFileButton_Click);
            // 
            // SaveXMLButton
            // 
            resources.ApplyResources(this.SaveXMLButton, "SaveXMLButton");
            this.SaveXMLButton.Name = "SaveXMLButton";
            this.SaveXMLButton.Click += new System.EventHandler(this.SaveXMLButton_Click);
            // 
            // LoadXMLButton
            // 
            resources.ApplyResources(this.LoadXMLButton, "LoadXMLButton");
            this.LoadXMLButton.Name = "LoadXMLButton";
            this.LoadXMLButton.Click += new System.EventHandler(this.LoadXMLButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
            // 
            // ValidateButton
            // 
            resources.ApplyResources(this.ValidateButton, "ValidateButton");
            this.ValidateButton.Name = "ValidateButton";
            this.ValidateButton.Click += new System.EventHandler(this.ValidateButton_Click);
            // 
            // saveFileDialog1
            // 
            resources.ApplyResources(this.saveFileDialog1, "saveFileDialog1");
            // 
            // AboutButton
            // 
            resources.ApplyResources(this.AboutButton, "AboutButton");
            this.AboutButton.Name = "AboutButton";
            this.AboutButton.UseVisualStyleBackColor = true;
            this.AboutButton.Click += new System.EventHandler(this.AboutButton_Click);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            resources.ApplyResources(this.openFileDialog2, "openFileDialog2");
            // 
            // mdControl1
            // 
            resources.ApplyResources(this.mdControl1, "mdControl1");
            this.mdControl1.Name = "mdControl1";
            // 
            // GIMEDForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.AboutButton);
            this.Controls.Add(this.mdControl1);
            this.Controls.Add(this.ValidateButton);
            this.Controls.Add(this.LoadXMLButton);
            this.Controls.Add(this.SaveXMLButton);
            this.Controls.Add(this.DataFileButton);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "GIMEDForm";
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


