/*
   Name:         GIMED
   Version:      1.2.5
   Author:       Angelos Tzotsos <tzotsos@gmail.com>
   Date:         19/11/10
   Modified:     19/11/10
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
using DotSpatial.Data;
using DotSpatial.Projections;
using System.Threading;
using System.Globalization;
using GIMED_EL.Properties;


public partial class GIMEDForm : Form
{
    //GR
    public MDObject myMDObject;
    bool GeoModule = false;
    string DataFile = "";

    string geo_extend_file = "geo_extends";
    

    //Thread.CurrentThread.

    public GIMEDForm(bool geo)
    {
        //MessageBox.Show(Thread.CurrentThread.CurrentUICulture.DisplayName);
        //Thread.CurrentThread.CurrentUICulture = new CultureInfo("el-GR");
        //MessageBox.Show(Thread.CurrentThread.CurrentUICulture.DisplayName);
        //MessageBox.Show(Thread.CurrentThread.CurrentUICulture.DisplayName);
        //SelectLang();
        //MessageBox.Show(Thread.CurrentThread.CurrentUICulture.DisplayName);
        InitializeComponent();
        
        myMDObject = null;
        GeoModule = geo;
        ToolTip toolTip1 = new ToolTip();
        toolTip1.AutoPopDelay = 5000;
        toolTip1.InitialDelay = 1000;
        toolTip1.ReshowDelay = 500;
        toolTip1.ShowAlways = true;
        toolTip1.SetToolTip(this.AboutButton, "Σχετικά...");
    }

    public bool ValidateMDControl(MDControl md)
    {
        if (md.MD_ContactListBox.Items.Count == 0)
        {
            MessageBox.Show("Δεν βρέθηκε αρμόδιος για επικοινωνία");
            return false;
        }
        if (md.MD_LanguageComboBox.SelectedIndex == -1)
        {
            MessageBox.Show("Δεν βρέθηκε γλώσσα μεταδεδομένων");
            return false;
        }
        if (md.ID_ResourseTitleTextBox.Text == "")
        {
            MessageBox.Show("Δεν βρέθηκε τίτλος πόρου");
            return false;
        }
        if (md.ID_ResourceAbstractTextBox.Text == "")
        {
            MessageBox.Show("Δεν βρέθηκε σύνοψη πόρου");
            return false;
        }
        if (md.ID_ResourceTypeComboBox.SelectedIndex == -1)
        {
            MessageBox.Show("Δεν επιλέχθηκε τύπος πόρου");
            return false;
        }
        if (md.ID_ResourceLanguageListBox.Items.Count == 0)
        {
            MessageBox.Show("Δεν βρέθηκε γλώσσα πόρου");
            return false;
        }
        if (md.ID_UIDListBox.Items.Count == 0)
        {
            MessageBox.Show("Δεν βρέθηκε μοναδικό χαρακτηριστικό πόρου");
            return false;
        }
        if (md.CL_TopicCategoryListBox.Items.Count == 0)
        {
            MessageBox.Show("Δεν βρέθηκε θεματική κατηγορία");
            return false;
        }
        if (md.KW_KeywordListBox.Items.Count == 0)
        {
            MessageBox.Show("Δεν βρέθηκε λέξη κλειδί");
            return false;
        }
        if (md.GEO_ExtendListBox.Items.Count == 0)
        {
            MessageBox.Show("Δεν βρέθηκε γεωγραφικό περίγραμμα συντεταγμένων");
            return false;
        }
        if (md.TMP_TemporalExtendListBox.Items.Count == 0 && md.TMP_PublicDateListBox.Items.Count == 0 && md.TMP_RevisionDateListBox.Items.Count == 0 && md.TMP_CreationDateListBox.Items.Count == 0)
        {
            MessageBox.Show("Πρέπει να συμπληρωθεί τουλάχιστο μία χρονική αναφορά");
            return false;
        }
        if (md.LIN_FreeTextBox.Text == "")
        {
            MessageBox.Show("Δεν βρέθηκε ελεύθερο κείμενο καταγωγής");
            return false;
        }
        if (md.CSTR_ConditionsUseGeneralListBox.Items.Count == 0)
        {
            MessageBox.Show("Δεν βρέθηκαν όροι για την πρόσβαση και τη χρήση");
            return false;
        }
        if (md.CSTR_LimitationsPublicListBox.Items.Count == 0)
        {
            MessageBox.Show("Δεν βρέθηκαν περιορισμοί σχετικά με την πρόσβαση του κοινού");
            return false;
        }
        if (md.ORG_IndividualListBox.Items.Count == 0)
        {
            MessageBox.Show("Δεν βρέθηκαν αρμόδιοι οργανισμοι για τη δημιουργία, τη συντήρηση και τη διανομή");
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
                if (sub[0] == "Κλίμακα:")
                {
                    obj.QLT_Scale.Add(sub[1]);
                }
                else if (sub[0] == "Απόσταση:")
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
        if (obj.ID_ResourceLocator.Count > 0)
        {
            foreach (object o in obj.ID_ResourceLocator)
            {
                md.ID_ResourceLocatorListBox.Items.Add((string)o);
            }
        }
        md.ID_UIDListBox.Items.Clear();
        foreach (object o in obj.ID_UniqueResourceIdentifier)
        {
            md.ID_UIDListBox.Items.Add((string)o);
        }
        md.ID_ResourceLanguageListBox.Items.Clear();
        foreach (object o in obj.ID_ResourceLanguage)
        {
            md.ID_ResourceLanguageListBox.Items.Add((string)o);
        }
        md.CL_TopicCategoryListBox.Items.Clear();
        foreach (object o in obj.CL_TopicCategory)
        {
            md.CL_TopicCategoryListBox.Items.Add((string)o);
        }
        md.KW_KeywordListBox.Items.Clear();
        foreach (object o in obj.KW_Keyword)
        {
            md.KW_KeywordListBox.Items.Add((string)o);
        }
        md.GEO_ExtendListBox.Items.Clear();
        foreach (object o in obj.GEO_GeographicExtend)
        {
            md.GEO_ExtendListBox.Items.Add((string)o);
        }
        md.TMP_TemporalExtendListBox.Items.Clear();
        foreach (object o in obj.TMP_TemporalExtend)
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
                md.QLT_ListBox.Items.Add("Κλίμακα: " + (string)o);
            }
        }
        if (obj.QLT_Distance.Count > 0)
        {
            foreach (object o in obj.QLT_Distance)
            {
                md.QLT_ListBox.Items.Add("Απόσταση: " + (string)o);
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

    private Dictionary<int, string> ReadEpsgFile()
    {
        string filePath = @"epsg";
        string line;
        Dictionary<int, string> dictEpsg = new Dictionary<int, string>();
        if (File.Exists(filePath))
        {
            StreamReader file = null;
            bool isCodeline=false;
            string tmpKey = string.Empty;
            string tmpVal = string.Empty;
            try
            {
                file = new StreamReader(filePath);
                int c=0;
                while ((line = file.ReadLine()) != null)
                {
                    if (c == 2) c = 0;
                    if (line.StartsWith("#"))
                    {
                        isCodeline = true;
                        tmpVal = line.Split('#')[1].Trim();
                        c++;
                    }
                    else if (line.StartsWith("<"))
                    {
                        isCodeline = false;
                        tmpKey = line.Split('<')[1].Split('>')[0].Trim();
                        c++;
                    }
                    if (c == 2)
                    {
                        try
                        {
                            dictEpsg.Add(Convert.ToInt32(tmpKey), tmpVal);
                        }
                        catch (Exception)
                        {}
                        
                    }
                }
            }
            finally
            {
                if (file != null)
                    file.Close();
            }
        }
        return dictEpsg;
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
        if (this.mdControl1.newGUIDpressed)
        {
            this.DataFile = "";
            this.mdControl1.newGUIDpressed = false;
        }
        
        if(this.DataFile != "")
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
            MessageBox.Show("Το αρχείο xml μεταδεδομένων αποθηκεύτηκε!");
            this.SaveXMLButton.Enabled = false;
        }
        return;
    }

    private void DataFileButton_Click(object sender, EventArgs e)
    {
        this.openFileDialog1.Filter = "Shape files (*.shp)|*.shp|Mapinfo TAB files (*.tab)|*.tab|TIFF Files (*.tif)|*.tif|JPEG2000 Files (*.jp2)|*.jp2|Imagine Files (*.img)|*.img|ER-Mapper Files (*.ers)|*.ers|JPEG Files (*.jpg)|*.jpg|DTM files (*.dtm)|*.dtm|All files (*.*)|*.*";
        this.openFileDialog1.FilterIndex = 1;
        openFileDialog1.DefaultExt = "shp";
        openFileDialog1.FileName = string.Empty;

        int inSRID = -1;

        DialogResult rslt = this.openFileDialog1.ShowDialog();
        if (rslt == DialogResult.OK)
        {
            Extent ext = new Extent();
            this.DataFile = this.openFileDialog1.FileName;
            this.textBox1.Text = this.DataFile;
            if (DataFile.EndsWith(".shp") || DataFile.EndsWith(".tab"))
            {
                //Declare a new feature set
                FeatureSet fs = (FeatureSet)FeatureSet.Open(DataFile);
                ext = fs.Extent;
                if (fs.Projection == null)
                {
                    inSRID = -1;
                }
            }
            else
            {
                //Assume its raster
                InRamImageData img = (InRamImageData)InRamImageData.Open(DataFile);
                ext = img.Extent;
                inSRID = -1;
            }

            PopulateExtent(ext, inSRID);
        }
        return;
    }

    private void PopulateExtent(Extent ext, int inEpsgCode)
    {
        
        if (inEpsgCode == -1)
        {
            Dictionary<int, string> d = ReadEpsgFile();
            GIMED_EL.frmEPSG dlgEpsg = new GIMED_EL.frmEPSG();
            dlgEpsg.PopulateListBox(d);
            var result = dlgEpsg.ShowDialog();
            if (result == DialogResult.OK)
            {
                inEpsgCode = dlgEpsg.selectedSRID;
            }
        }

        if (inEpsgCode == -1) return;

        Extent latlonExtent = reprojectRectangle(ext, inEpsgCode);
        this.mdControl1.GEO_ExtendListBox.Items.Clear();
        string tmp = latlonExtent.MinX.ToString() + ";" + latlonExtent.MinY.ToString() + ";" + latlonExtent.MaxX.ToString() + ";" + latlonExtent.MaxY.ToString();
        this.mdControl1.GEO_ExtendListBox.Items.Add(tmp);

        //Also fill in the GEO * textboxes
        mdControl1.GEO_XminTextBox.Text = latlonExtent.MinX.ToString();
        mdControl1.GEO_XmaxTextBox.Text = latlonExtent.MaxX.ToString();
        mdControl1.GEO_YminTextBox.Text = latlonExtent.MinY.ToString();
        mdControl1.GEO_YmaxTextBox.Text = latlonExtent.MaxY.ToString();
        this.SaveXMLButton.Enabled = false;
        this.LoadXMLButton.Enabled = false;


       
    }

    private Extent reprojectRectangle( Extent inExt, int fromSrid)
    {
        Extent outExt = new Extent();
        List<double> xy = new List<double>();
        List<double> z = new List<double>();

        xy.Add(inExt.MinX);
        xy.Add(inExt.MinY);
        xy.Add(inExt.MaxX);
        xy.Add(inExt.MaxY);
        z.Add(0.0);
        z.Add(0.0);
        double[] xyA = xy.ToArray();
        double[] zA = z.ToArray();

        ProjectionInfo piFrom = ProjectionInfo.FromEpsgCode(fromSrid);

        //Always reproject to WGS84 (EPSG:4326)
        ProjectionInfo piTo = ProjectionInfo.FromEpsgCode(4326);
        Reproject.ReprojectPoints(xyA, zA, piFrom, piTo, 0, 2);
        outExt.MinX=xyA[0];
        outExt.MinY = xyA[1];
        outExt.MaxX = xyA[2];
        outExt.MaxY = xyA[3];
        return outExt;
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
            //prc.StartInfo.Arguments = "\"" + DataFile + "\"";
            prc.StartInfo.UseShellExecute = false;
            prc.StartInfo.Arguments = "\"" + DataFile + "\"";
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
                MessageBox.Show("Δεν βρέθηκε Γεωγραφική Θέση");
            }
        }
        catch
        {
            MessageBox.Show("Σφάλμα στην εκτέλεση του πρόσθετου geoextent. Παρακαλώ ελέγξτε αν το αρχείο έχει δικαίωμα εκτέλεσης στο λειτουργικό σύστημα.");
        }

    }
    
    private void AboutButton_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Ανάπτυξη εφαρμογής: ’γγελος Τζώτσος\nΤο GIMED είναι Ελεύθερο Λογισμικό υπό την άδεια GPL3\nΕπικοινωνία: tzotsos@gmail.com");
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
                MessageBox.Show("Φορτώθηκε αρχείο XML");
            }
            else
            {
                MessageBox.Show("Σφάλμα φόρτωσης αρχείου XML");
            }
        }
        return;
    }

    private void SelectLang()
    {
        if (Settings.Default["Language"] != null)
        {
            Thread.CurrentThread.CurrentUICulture= new CultureInfo(Settings.Default["Language"].ToString());
           
        }
    }


    private void cboLanguages_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cboLanguages.SelectedIndex != -1)
        {
            if (cboLanguages.SelectedItem.ToString() == "Ελληνικά")
            {
                //SaveLanguage("el-GR");
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("el-GR");
            }
            else
            {
                //SaveLanguage("en-US");
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            }
            //MessageBox.Show("Yo need to restart the application for the changes to take effect");
        }
       
        ComponentResourceManager resources = new ComponentResourceManager(typeof(GIMEDForm));
        resources.ApplyResources(this, "$this");
        applyResources(resources, this.Controls);

        ComponentResourceManager resources1 = new ComponentResourceManager(typeof(MDControl));
        applyResources(resources1, mdControl1.Controls);

    }

    private void applyResources(ComponentResourceManager resources, Control.ControlCollection ctls)
    {
        foreach (Control ctl in ctls)
        {
            resources.ApplyResources(ctl, ctl.Name);
            applyResources(resources, ctl.Controls);
        }
    }

}