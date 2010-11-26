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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using Inspire.Metadata;

public partial class Form1 : Form
{
    //EN
    public MDObject myMDObject;
    bool GeoModule = false;
    string DataFile = "";
    string geo_extend_file = "geo_extends";
    
    public Form1(bool geo)
    {
        InitializeComponent();
        myMDObject = null;
        GeoModule = geo;
        ToolTip toolTip1 = new ToolTip();
        toolTip1.AutoPopDelay = 5000;
        toolTip1.InitialDelay = 1000;
        toolTip1.ReshowDelay = 500;
        toolTip1.ShowAlways = true;
        toolTip1.SetToolTip(this.AboutButton, "About...");
    }

    public bool ValidateMDControl(MDControl md)
    {
        if (md.MD_ContactListBox.Items.Count == 0)
        {
            MessageBox.Show("Point of Contact metadata not found");
            return false;
        }
        if (md.MD_LanguageComboBox.SelectedIndex == -1)
        {
            MessageBox.Show("Metadata Language not found");
            return false;
        }
        if (md.ID_ResourseTitleTextBox.Text == "")
        {
            MessageBox.Show("Resource Title metadata not found");
            return false;
        }
        if (md.ID_ResourceAbstractTextBox.Text == "")
        {
            MessageBox.Show("Resource Abstract metadata not found");
            return false;
        }
        if (md.ID_ResourceTypeComboBox.SelectedIndex == -1)
        {
            MessageBox.Show("Resource Type not selected");
            return false;
        }
        if (md.ID_ResourceLanguageListBox.Items.Count == 0)
        {
            MessageBox.Show("Resource Language metadata not found");
            return false;
        }
        if (md.ID_UIDListBox.Items.Count == 0)
        {
            MessageBox.Show("Unique Resource Identifier not found");
            return false;
        }
        if (md.CL_TopicCategoryListBox.Items.Count == 0)
        {
            MessageBox.Show("Topic Category not found");
            return false;
        }
        if (md.KW_KeywordListBox.Items.Count == 0)
        {
            MessageBox.Show("Keywords not found");
            return false;
        }
        if (md.GEO_ExtendListBox.Items.Count == 0)
        {
            MessageBox.Show("Geographic Extend not found");
            return false;
        }
        if (md.TMP_TemporalExtendListBox.Items.Count == 0 && md.TMP_PublicDateListBox.Items.Count == 0 && md.TMP_RevisionDateListBox.Items.Count == 0 && md.TMP_CreationDateListBox.Items.Count == 0)
        {
            MessageBox.Show("At least one Temporal Reference must be completed");
            return false;
        }
        if (md.LIN_FreeTextBox.Text == "")
        {
            MessageBox.Show("Lineage free text not found");
            return false;
        }
        if (md.CSTR_ConditionsUseGeneralListBox.Items.Count == 0)
        {
            MessageBox.Show("Conditions for access and use-general not found");
            return false;
        }
        if (md.CSTR_LimitationsPublicListBox.Items.Count == 0)
        {
            MessageBox.Show("Limitations on public access not found");
            return false;
        }
        if (md.ORG_IndividualListBox.Items.Count == 0)
        {
            MessageBox.Show("Responsible Party metadatanot found");
            return false;
        }
        
        return true;
    }

    public void FillMDObject(MDObject obj, MDControl md)
    {
        obj.FileIdentifier = md.mdguid;
        foreach (object contact in md.MD_ContactListBox.Items)
        {
            string tmp = (string) contact;
            obj.MD_PointOfContact.Add(tmp);
        }
        obj.MD_Date = md.MD_DateTimePicker.Value.ToString("yyyy-MM-dd");
        obj.MD_Language = (string)md.MD_LanguageComboBox.SelectedItem;
        obj.ID_ResourseTitle = md.ID_ResourseTitleTextBox.Text;
        obj.ID_ResourceAbstract = md.ID_ResourceAbstractTextBox.Text;
        obj.ID_ResourceType = (string)md.ID_ResourceTypeComboBox.SelectedItem;
        if (md.ID_ResourceLocatorListBox.Items.Count != 0)
        {
            foreach (object locator in md.ID_ResourceLocatorListBox.Items)
            {
                string tmp = (string)locator;
                obj.ID_ResourceLocator.Add(tmp);
            }
        }
        foreach (object uid in md.ID_UIDListBox.Items)
        {
            obj.ID_UniqueResourceIdentifier.Add((string)uid);
        }
        foreach (object lang in md.ID_ResourceLanguageListBox.Items)
        {
            obj.ID_ResourceLanguage.Add((string)lang);
        }
        foreach (object t in md.CL_TopicCategoryListBox.Items)
        {
            obj.CL_TopicCategory.Add((string)t);
        }
        foreach (object t in md.KW_KeywordListBox.Items)
        {
            obj.KW_Keyword.Add((string)t);
        }
        foreach (object t in md.GEO_ExtendListBox.Items)
        {
            obj.GEO_GeographicExtend.Add((string)t);
        }
        foreach (object t in md.TMP_TemporalExtendListBox.Items)
        {
            obj.TMP_TemporalExtend.Add((string)t);
        }
        if (md.TMP_CreationDateListBox.Items.Count != 0)
        {
            foreach (object t in md.TMP_CreationDateListBox.Items)
            {
                obj.TMP_DateCreation = (string)t;
            }
        }
        if (md.TMP_PublicDateListBox.Items.Count != 0)
        {
            foreach (object t in md.TMP_PublicDateListBox.Items)
            {
                obj.TMP_DatePublication.Add((string)t);
            }
        }
        if (md.TMP_RevisionDateListBox.Items.Count != 0)
        {
            foreach (object t in md.TMP_RevisionDateListBox.Items)
            {
                obj.TMP_DateRevision = (string)t;
            }
        }
        
        obj.QLT_Lineage = md.LIN_FreeTextBox.Text;
        
        if (md.QLT_ListBox.Items.Count != 0)
        {
            foreach (object t in md.QLT_ListBox.Items)
            {
                string tmp = (string)t;
                string[] sub = tmp.Split(' ');
                if (sub[0] == "Scale:")
                {
                    obj.QLT_Scale.Add(sub[1]);
                }
                else if (sub[0] == "Distance:")
                {
                    string sum = sub[1] + " " + sub[2];
                    obj.QLT_Distance.Add(sum);
                }
            }
        }

        if (md.CFRM_ListBox.Items.Count != 0)
        {
            foreach (object t in md.CFRM_ListBox.Items)
            {
                string tmp = (string)t;
                string[] sub = tmp.Split('|');
                obj.CFRM_Degree.Add(sub[0]);
                obj.CFRM_Title.Add(sub[1]);
                obj.CFRM_DateType.Add(sub[2]);
                obj.CFRM_Date.Add(sub[3]);
            }
        }

        foreach (object t in md.CSTR_ConditionsUseGeneralListBox.Items)
        {
            obj.CSTR_ConditionsUseGeneral.Add((string)t);
        }
        foreach (object t in md.CSTR_LimitationsPublicListBox.Items)
        {
            obj.CSTR_LimitationsPublic.Add((string)t);
        }
        foreach (object t in md.ORG_IndividualListBox.Items)
        {
            obj.ORG_ResponsibleParty.Add((string)t);
        }
        
        return;
    }

    public void FillMDControl(MDObject obj, MDControl md)
    {
        md.mdguid = obj.FileIdentifier;
        md.MD_ContactListBox.Items.Clear();
        foreach (object o in obj.MD_PointOfContact)
        {
            md.MD_ContactListBox.Items.Add((string)o);
        }
        DateTime dt = Convert.ToDateTime(obj.MD_Date);
        md.MD_DateTimePicker.Value = dt;
        md.MD_LanguageComboBox.SelectedItem = obj.MD_Language;
        md.ID_ResourseTitleTextBox.Text = obj.ID_ResourseTitle;
        md.ID_ResourceAbstractTextBox.Text = obj.ID_ResourceAbstract;
        md.ID_ResourceTypeComboBox.SelectedItem = obj.ID_ResourceType;
        
        md.ID_ResourceLocatorListBox.Items.Clear();
        if(obj.ID_ResourceLocator.Count > 0)
        {
            foreach(object o in obj.ID_ResourceLocator)
            {
                md.ID_ResourceLocatorListBox.Items.Add((string)o);
            }
        }
        md.ID_UIDListBox.Items.Clear();
        foreach(object o in obj.ID_UniqueResourceIdentifier)
        {
            md.ID_UIDListBox.Items.Add((string)o);
        }
        md.ID_ResourceLanguageListBox.Items.Clear();
        foreach(object o in obj.ID_ResourceLanguage)
        {
            md.ID_ResourceLanguageListBox.Items.Add((string)o);
        }
        md.CL_TopicCategoryListBox.Items.Clear();
        foreach(object o in obj.CL_TopicCategory)
        {
            md.CL_TopicCategoryListBox.Items.Add((string)o);
        }
        md.KW_KeywordListBox.Items.Clear();
        foreach(object o in obj.KW_Keyword)
        {
            md.KW_KeywordListBox.Items.Add((string)o);
        }
        md.GEO_ExtendListBox.Items.Clear();
        foreach(object o in obj.GEO_GeographicExtend)
        {
            md.GEO_ExtendListBox.Items.Add((string)o);
        }
        md.TMP_TemporalExtendListBox.Items.Clear();
        foreach(object o in obj.TMP_TemporalExtend)
        {
            md.TMP_TemporalExtendListBox.Items.Add((string)o);
        }
        md.TMP_CreationDateListBox.Items.Clear();
        md.TMP_AddCreationDateButton.Enabled = true;
        if (obj.TMP_DateCreation != "")
        {
            md.TMP_CreationDateListBox.Items.Add(obj.TMP_DateCreation);
            md.TMP_AddCreationDateButton.Enabled = false;
        }
        md.TMP_RevisionDateListBox.Items.Clear();
        md.TMP_AddRevisionDateButton.Enabled = true;
        if (obj.TMP_DateRevision != "")
        {
            md.TMP_RevisionDateListBox.Items.Add(obj.TMP_DateRevision);
            md.TMP_AddRevisionDateButton.Enabled = false;
        }
        md.TMP_PublicDateListBox.Items.Clear();
        if (obj.TMP_DatePublication.Count > 0)
        {
            foreach (object o in obj.TMP_DatePublication)
            {
                md.TMP_PublicDateListBox.Items.Add((string)o);
            }
        }
        md.LIN_FreeTextBox.Text = obj.QLT_Lineage;
        md.QLT_ListBox.Items.Clear();
        if (obj.QLT_Scale.Count > 0)
        {
            foreach (object o in obj.QLT_Scale)
            {
                md.QLT_ListBox.Items.Add("Scale: " + (string)o);
            }
        }
        if (obj.QLT_Distance.Count > 0)
        {
            foreach (object o in obj.QLT_Distance)
            {
                md.QLT_ListBox.Items.Add("Distance: " + (string)o);
            }
        }
        md.CFRM_ListBox.Items.Clear();
        if (obj.CFRM_Title.Count > 0)
        {
            int cnt = obj.CFRM_Title.Count;
            for (int i = 0; i < cnt; i++)
            {
                string tmp = ((string)obj.CFRM_Degree[i]) + "|" + ((string)obj.CFRM_Title[i]) + "|" + ((string)obj.CFRM_DateType[i]) + "|" + ((string)obj.CFRM_Date[i]);
                md.CFRM_ListBox.Items.Add(tmp);
            }
        }
        
        md.CSTR_ConditionsUseGeneralListBox.Items.Clear();
        foreach (object t in obj.CSTR_ConditionsUseGeneral)
        {
            md.CSTR_ConditionsUseGeneralListBox.Items.Add((string)t);
        }
        md.CSTR_AddConditionsUseGeneralButton1.Enabled = false;
        md.CSTR_AddConditionsUseGeneralButton2.Enabled = false;
        md.CSTR_LimitationsPublicListBox.Items.Clear();
        foreach (object t in obj.CSTR_LimitationsPublic)
        {
            md.CSTR_LimitationsPublicListBox.Items.Add((string)t);
        }
        md.CSTR_AddLimitationsPublicButton1.Enabled = false;
        md.CSTR_AddLimitationsPublicButton2.Enabled = false;
        md.ORG_IndividualListBox.Items.Clear();
        foreach (object o in obj.ORG_ResponsibleParty)
        {
            md.ORG_IndividualListBox.Items.Add((string)o);
        }

    }
    
    private void ValidateButton_Click(object sender, EventArgs e)
    {
        if (this.ValidateMDControl(mdControl1))
        {
            this.myMDObject = null;
            this.myMDObject = new MDObject();
            this.FillMDObject(myMDObject, mdControl1);
            this.SaveXMLButton.Enabled = true;
        }
    }

    private void SaveXMLButton_Click(object sender, EventArgs e)
    {
        if (this.DataFile != "")
        {
            this.saveFileDialog1.FileName = this.DataFile.Substring(0, this.DataFile.Length - 4) + ".xml";
        }
        else
        {
            this.saveFileDialog1.FileName = this.mdControl1.mdguid + ".xml";
        }
        this.saveFileDialog1.Filter = "XML Files (*.xml)|*.xml|All files (*.*)|*.*";
        this.saveFileDialog1.FilterIndex = 1;
        DialogResult rslt = this.saveFileDialog1.ShowDialog();
        if (rslt == DialogResult.OK)
        {
            this.myMDObject.WriteToXML(this.saveFileDialog1.FileName);
            MessageBox.Show("Metadata XML saved!");
            this.SaveXMLButton.Enabled = false;
            this.LoadXMLButton.Enabled = true;
            this.DataFileButton.Enabled = true;
        }
        return;
    }

    private void DataFileButton_Click(object sender, EventArgs e)
    {
        this.openFileDialog1.Filter = "TIFF Files (*.tif)|*.tif|JPEG2000 Files (*.jp2)|*.jp2|Imagine Files (*.img)|*.img|ER-Mapper Files (*.ers)|*.ers|JPEG Files (*.jpg)|*.jpg|Shape files (*.shp)|*.shp|DTM files (*.dtm)|*.dtm|All files (*.*)|*.*";
        this.openFileDialog1.FilterIndex = 1;
        DialogResult rslt = this.openFileDialog1.ShowDialog();
        if (rslt == DialogResult.OK)
        {
            this.DataFile = this.openFileDialog1.FileName;
            this.textBox1.Text = this.DataFile;
            this.LoadGeoExtend();
            this.SaveXMLButton.Enabled = false;
            this.LoadXMLButton.Enabled = false;
        }
        return;
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        this.textBox1.Text = this.DataFile;
    }

    public void LoadGeoExtend()
    {
        try
        {
            Checker chk = new Checker();
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            if (chk.IsWindows()) 
            {
                appPath += Path.DirectorySeparatorChar + this.geo_extend_file + ".exe";
            }
            else
            {
                appPath += Path.DirectorySeparatorChar + this.geo_extend_file;
            }

            StreamReader str0 = StreamReader.Null;
            string output = "";
            Process prc = new Process();
            prc.StartInfo.FileName = appPath;
            prc.StartInfo.Arguments = "\"" + DataFile + "\"";
            prc.StartInfo.UseShellExecute = false;
            prc.StartInfo.CreateNoWindow = true;
            prc.StartInfo.RedirectStandardOutput = true;
            prc.Start();
            str0 = prc.StandardOutput;
            output = str0.ReadToEnd();
            prc.WaitForExit();
            str0.Close();

            string[] SubStrings = output.Split(' ');
            if (SubStrings[0] == "BoundingBox:")
            {
                this.mdControl1.GEO_ExtendListBox.Items.Clear();
                string tmp = Convert.ToDouble((string)SubStrings[1]).ToString() + ";" + Convert.ToDouble((string)SubStrings[2]).ToString() + ";" + Convert.ToDouble((string)SubStrings[3]).ToString() + ";" + Convert.ToDouble((string)SubStrings[4]).ToString();
                this.mdControl1.GEO_ExtendListBox.Items.Add(tmp);
            }
            else
            {
                MessageBox.Show("No valid Geographic Extend found");
            }
        }
        catch
        {
            MessageBox.Show("Error in GeoExtend module. Check if geo_extend binary file has execute permisions.");
        }

    }

    private void LoadXMLButton_Click(object sender, EventArgs e)
    {
        this.openFileDialog2.Filter = "XML Files (*.xml)|*.xml|All files (*.*)|*.*";
        this.openFileDialog2.FilterIndex = 1;
        DialogResult rslt = this.openFileDialog2.ShowDialog();
        if (rslt == DialogResult.OK)
        {
            this.DataFile = this.openFileDialog2.FileName;
            this.myMDObject = null;
            this.myMDObject = new MDObject();
            if (this.myMDObject.LoadFromXML(this.DataFile))
            {
                this.FillMDControl(this.myMDObject, mdControl1);
                this.DataFileButton.Enabled = false;
                this.SaveXMLButton.Enabled = false;
                MessageBox.Show("XML Loaded");
            }
            else
            {
                MessageBox.Show("Error Loading XML");
            }
        }
        return;
    }

    private void AboutButton_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Developed by Angelos Tzotsos\nThis program is Free Software under GPL3\nContact: tzotsos@gmail.com");
    }
    
}