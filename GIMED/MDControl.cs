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
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Threading;


namespace Inspire.Metadata
{
	/// <summary>
	/// Summary description for MDControl.
	/// </summary>
	public class MDControl : System.Windows.Forms.UserControl
	{
        public string mdguid;
        public bool newGUIDpressed;
        public System.Windows.Forms.TabControl MD_tabControl;
		public System.Windows.Forms.TabPage MetadataTab;
        private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		public System.Windows.Forms.ComboBox MD_LanguageComboBox;
        public System.Windows.Forms.DateTimePicker MD_DateTimePicker;
        private System.Windows.Forms.TabPage IdentificationTab;
        private System.Windows.Forms.GroupBox MD_GroupBox;
		public System.Windows.Forms.TabPage KeywordTab;
        public System.Windows.Forms.TabPage ClassificationTab;
        private TabPage GeographicTab;
        private TabPage TemporalTab;
        private TabPage QualityValidityTab;
        private TabPage ConformityTab;
        private TabPage ConstraintsTab;
        private TabPage OrganizationTab;
        public GroupBox KeywordGroupBox;
        public TextBox KW_KeywordTextBox;
        public Button KW_KeywordRemoveButton;
        public ListBox KW_KeywordListBox;
        public Button KW_KeywordAddButton;
        private Label label11;
        private GroupBox SPT_GroupBox;
        private Label label61;
        public TextBox GEO_XmaxTextBox;
        private Label label60;
        public TextBox GEO_XminTextBox;
        private Label label59;
        public TextBox GEO_YminTextBox;
        private Label label58;
        public TextBox GEO_YmaxTextBox;
        private GroupBox TMP_GroupBox;
        public Button TMP_RemoveDateButton;
        public ListBox TMP_PublicDateListBox;
        public Button TMP_AddDateButton;
        public DateTimePicker TMP_PublicTimePicker;
        private Label label15;
        private Label label14;
        public DateTimePicker TMP_ToDateTimePicker;
        private Label label13;
        public DateTimePicker TMP_FromDateTimePicker;
        public Button TMP_RemoveExtendButton;
        public ListBox TMP_TemporalExtendListBox;
        public Button TMP_AddExtendButton;
        public GroupBox LineageGroupBox;
        public TextBox LIN_FreeTextBox;
        private GroupBox QLT_GroupBox;
        private GroupBox Spatial_GroupBox;
        private Label label29;
        public Button QLT_AddDistanceButton;
        private Label label20;
        public TextBox QLT_DistanceTextBox;
        private Label label19;
        public TextBox QLT_ScaleTextBox;
        private Label label18;
        public Button QLT_RemoveButton;
        public Button QLT_AddScaleButton;
        public ListBox QLT_ListBox;
        public GroupBox CFRM_GroupBox;
        public ComboBox CFRM_DegreeComboBox;
        public DateTimePicker CFRM_DateTimePicker;
        public ComboBox CFRM_DateTypeComboBox;
        public Button CFRM_AddButton;
        private Label label21;
        private Label label22;
        public TextBox CFRM_TitleTextBox;
        private Label label23;
        public Button CFRM_RemoveButton;
        public ListBox CFRM_ListBox;
        public GroupBox CSTR_GroupBox;
        public ComboBox CSTR_ConditionsUseGeneralComboBox;
        public ComboBox CSTR_LimitationsPublicComboBox;
        private Label label25;
        private Label label24;
        public GroupBox ORG_GroupBox;
        public TextBox ORG_EmailTextBox;
        private Label label27;
        public ListBox ORG_IndividualListBox;
        public TextBox ORG_NameTextBox;
        private Label label28;
        private Label label6;
        public ComboBox ORG_RoleComboBox;
        public Button ORG_RemoveButton;
        public Button ORG_AddButton;
        public ComboBox ID_ResourceLanguageComboBox;
        public ComboBox ID_ResourceTypeComboBox;
        private Label label8;
        public TextBox ID_ResourceAbstractTextBox;
        private Label label7;
        public TextBox ID_ResourseTitleTextBox;
        private Label label1;
        private GroupBox CL_GroupBox;
        public Button CL_RemoveTopicCategoryButton;
        public ListBox CL_TopicCategoryListBox;
        public Button CL_AddTopicCategoryButton;
        public ComboBox CL_TopicCategoryComboBox;
        private GroupBox groupBox3;
        private GroupBox groupBox6;
        public ListBox MD_ContactListBox;
        public Button MD_ContactListRemoveButton;
        public Button MD_ContactListAddButton;
        public TextBox MD_emailTextBox;
        public Button MD_RemoveEmailButton;
        public Button MD_AddEmailButton;
        public ListBox MD_EmailListBox;
        private Label label2;
        public TextBox MD_OrganizationNameTextBox;
        private Label label3;
        public TextBox ID_ResourceLocatorTextBox;
        public Button ID_ResourceLocatorRemoveButton;
        public Button ID_ResourceLocatorAddButton;
        public ListBox ID_ResourceLocatorListBox;
        private Label label66;
        private Label label65;
        public TextBox ID_NamespaceTextBox;
        public TextBox ID_CodeTextBox;
        public Button ID_UIDRemoveButton;
        public Button ID_UIDAddButton;
        public ListBox ID_UIDListBox;
        public Button ID_ResourceLanguageRemoveButton;
        public Button ID_ResourceLanguageAddButton;
        public ListBox ID_ResourceLanguageListBox;
        private GroupBox groupBox7;
        private GroupBox groupBox9;
        private GroupBox groupBox8;
        private GroupBox groupBox1;
        public Button GUIDButton;
        private Label label9;
        public ComboBox KW_InspireComboBox;
        private GroupBox groupBox2;
        public Button KW_AddInspireButton;
        public DateTimePicker KW_DateTimePicker;
        public ComboBox KW_DateTypeComboBox;
        private Label label10;
        public TextBox KW_VocabularyTextBox;
        private Label label16;
        private Label label17;
        public DateTimePicker TMP_CreationDateTimePicker;
        private Label label31;
        public DateTimePicker TMP_RevisionDateTimePicker;
        private Label label30;
        public Button TMP_RemoveCreationDateButton;
        public Button TMP_AddCreationDateButton;
        public Button TMP_RemoveRevisionDateButton;
        public Button TMP_AddRevisionDateButton;
        public ListBox TMP_CreationDateListBox;
        public ListBox TMP_RevisionDateListBox;
        private GroupBox groupBox5;
        private GroupBox groupBox4;
        private GroupBox groupBox11;
        private GroupBox groupBox10;
        public Button GEO_RemoveExtendButton;
        public ListBox GEO_ExtendListBox;
        public Button GEO_AddExtendButton;
        private GroupBox groupBox12;
        public Button ORG_AddEmailButton;
        public Button ORG_RemoveEmailButton;
        public ListBox ORG_EmailListBox;
        public Button CSTR_RemoveLimitationsPublicButton;
        public ListBox CSTR_LimitationsPublicListBox;
        public Button CSTR_AddLimitationsPublicButton2;
        public TextBox CSTR_LimitationsPublicTextBox;
        private Label label12;
        public Button CSTR_AddLimitationsPublicButton1;
        private Label label26;
        public Button CSTR_RemoveConditionsUseGeneralButton;
        public ListBox CSTR_ConditionsUseGeneralListBox;
        public Button CSTR_AddConditionsUseGeneralButton2;
        public TextBox CSTR_ConditionsUseGeneralTextBox;
        public Button CSTR_AddConditionsUseGeneralButton1;
        public ComboBox QLT_UnitsComboBox;

        

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MDControl()
		{
            //MessageBox.Show(Thread.CurrentThread.CurrentUICulture.DisplayName);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("el-GR");
            //MessageBox.Show(Thread.CurrentThread.CurrentUICulture.DisplayName);
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
            this.CreateGUID();
            this.newGUIDpressed = false;
			// TODO: Add any initialization after the InitializeComponent call

		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDControl));
            this.MD_tabControl = new System.Windows.Forms.TabControl();
            this.MetadataTab = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.MD_ContactListBox = new System.Windows.Forms.ListBox();
            this.MD_ContactListRemoveButton = new System.Windows.Forms.Button();
            this.MD_ContactListAddButton = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.MD_emailTextBox = new System.Windows.Forms.TextBox();
            this.MD_RemoveEmailButton = new System.Windows.Forms.Button();
            this.MD_AddEmailButton = new System.Windows.Forms.Button();
            this.MD_EmailListBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.MD_OrganizationNameTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.MD_GroupBox = new System.Windows.Forms.GroupBox();
            this.MD_LanguageComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.MD_DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.IdentificationTab = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ID_ResourceTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ID_ResourceAbstractTextBox = new System.Windows.Forms.TextBox();
            this.ID_ResourseTitleTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.ID_ResourceLanguageListBox = new System.Windows.Forms.ListBox();
            this.ID_ResourceLanguageComboBox = new System.Windows.Forms.ComboBox();
            this.ID_ResourceLanguageAddButton = new System.Windows.Forms.Button();
            this.ID_ResourceLanguageRemoveButton = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.GUIDButton = new System.Windows.Forms.Button();
            this.ID_CodeTextBox = new System.Windows.Forms.TextBox();
            this.ID_UIDListBox = new System.Windows.Forms.ListBox();
            this.ID_UIDAddButton = new System.Windows.Forms.Button();
            this.ID_UIDRemoveButton = new System.Windows.Forms.Button();
            this.ID_NamespaceTextBox = new System.Windows.Forms.TextBox();
            this.label66 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.ID_ResourceLocatorTextBox = new System.Windows.Forms.TextBox();
            this.ID_ResourceLocatorListBox = new System.Windows.Forms.ListBox();
            this.ID_ResourceLocatorAddButton = new System.Windows.Forms.Button();
            this.ID_ResourceLocatorRemoveButton = new System.Windows.Forms.Button();
            this.ClassificationTab = new System.Windows.Forms.TabPage();
            this.CL_GroupBox = new System.Windows.Forms.GroupBox();
            this.CL_RemoveTopicCategoryButton = new System.Windows.Forms.Button();
            this.CL_TopicCategoryListBox = new System.Windows.Forms.ListBox();
            this.CL_AddTopicCategoryButton = new System.Windows.Forms.Button();
            this.CL_TopicCategoryComboBox = new System.Windows.Forms.ComboBox();
            this.KeywordTab = new System.Windows.Forms.TabPage();
            this.KeywordGroupBox = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.KW_DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.KW_DateTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.KW_VocabularyTextBox = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.KW_KeywordTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.KW_KeywordAddButton = new System.Windows.Forms.Button();
            this.KW_AddInspireButton = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.KW_InspireComboBox = new System.Windows.Forms.ComboBox();
            this.KW_KeywordRemoveButton = new System.Windows.Forms.Button();
            this.KW_KeywordListBox = new System.Windows.Forms.ListBox();
            this.GeographicTab = new System.Windows.Forms.TabPage();
            this.SPT_GroupBox = new System.Windows.Forms.GroupBox();
            this.GEO_RemoveExtendButton = new System.Windows.Forms.Button();
            this.GEO_ExtendListBox = new System.Windows.Forms.ListBox();
            this.GEO_AddExtendButton = new System.Windows.Forms.Button();
            this.label61 = new System.Windows.Forms.Label();
            this.GEO_XmaxTextBox = new System.Windows.Forms.TextBox();
            this.label60 = new System.Windows.Forms.Label();
            this.GEO_XminTextBox = new System.Windows.Forms.TextBox();
            this.label59 = new System.Windows.Forms.Label();
            this.GEO_YminTextBox = new System.Windows.Forms.TextBox();
            this.label58 = new System.Windows.Forms.Label();
            this.GEO_YmaxTextBox = new System.Windows.Forms.TextBox();
            this.TemporalTab = new System.Windows.Forms.TabPage();
            this.TMP_GroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.TMP_ToDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.TMP_FromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.TMP_RemoveExtendButton = new System.Windows.Forms.Button();
            this.TMP_TemporalExtendListBox = new System.Windows.Forms.ListBox();
            this.TMP_AddExtendButton = new System.Windows.Forms.Button();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.TMP_RemoveCreationDateButton = new System.Windows.Forms.Button();
            this.TMP_AddCreationDateButton = new System.Windows.Forms.Button();
            this.TMP_CreationDateListBox = new System.Windows.Forms.ListBox();
            this.TMP_CreationDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label31 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.TMP_RevisionDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label30 = new System.Windows.Forms.Label();
            this.TMP_RevisionDateListBox = new System.Windows.Forms.ListBox();
            this.TMP_AddRevisionDateButton = new System.Windows.Forms.Button();
            this.TMP_RemoveRevisionDateButton = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.TMP_PublicTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.TMP_AddDateButton = new System.Windows.Forms.Button();
            this.TMP_PublicDateListBox = new System.Windows.Forms.ListBox();
            this.TMP_RemoveDateButton = new System.Windows.Forms.Button();
            this.QualityValidityTab = new System.Windows.Forms.TabPage();
            this.LineageGroupBox = new System.Windows.Forms.GroupBox();
            this.LIN_FreeTextBox = new System.Windows.Forms.TextBox();
            this.QLT_GroupBox = new System.Windows.Forms.GroupBox();
            this.Spatial_GroupBox = new System.Windows.Forms.GroupBox();
            this.QLT_UnitsComboBox = new System.Windows.Forms.ComboBox();
            this.label29 = new System.Windows.Forms.Label();
            this.QLT_AddDistanceButton = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.QLT_DistanceTextBox = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.QLT_ScaleTextBox = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.QLT_RemoveButton = new System.Windows.Forms.Button();
            this.QLT_AddScaleButton = new System.Windows.Forms.Button();
            this.QLT_ListBox = new System.Windows.Forms.ListBox();
            this.ConformityTab = new System.Windows.Forms.TabPage();
            this.CFRM_GroupBox = new System.Windows.Forms.GroupBox();
            this.CFRM_DegreeComboBox = new System.Windows.Forms.ComboBox();
            this.CFRM_DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.CFRM_DateTypeComboBox = new System.Windows.Forms.ComboBox();
            this.CFRM_AddButton = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.CFRM_TitleTextBox = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.CFRM_RemoveButton = new System.Windows.Forms.Button();
            this.CFRM_ListBox = new System.Windows.Forms.ListBox();
            this.ConstraintsTab = new System.Windows.Forms.TabPage();
            this.CSTR_GroupBox = new System.Windows.Forms.GroupBox();
            this.label26 = new System.Windows.Forms.Label();
            this.CSTR_RemoveConditionsUseGeneralButton = new System.Windows.Forms.Button();
            this.CSTR_ConditionsUseGeneralListBox = new System.Windows.Forms.ListBox();
            this.CSTR_AddConditionsUseGeneralButton2 = new System.Windows.Forms.Button();
            this.CSTR_ConditionsUseGeneralTextBox = new System.Windows.Forms.TextBox();
            this.CSTR_AddConditionsUseGeneralButton1 = new System.Windows.Forms.Button();
            this.CSTR_RemoveLimitationsPublicButton = new System.Windows.Forms.Button();
            this.CSTR_LimitationsPublicListBox = new System.Windows.Forms.ListBox();
            this.CSTR_AddLimitationsPublicButton2 = new System.Windows.Forms.Button();
            this.CSTR_LimitationsPublicTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.CSTR_AddLimitationsPublicButton1 = new System.Windows.Forms.Button();
            this.CSTR_ConditionsUseGeneralComboBox = new System.Windows.Forms.ComboBox();
            this.CSTR_LimitationsPublicComboBox = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.OrganizationTab = new System.Windows.Forms.TabPage();
            this.ORG_GroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.ORG_RemoveEmailButton = new System.Windows.Forms.Button();
            this.ORG_EmailListBox = new System.Windows.Forms.ListBox();
            this.ORG_AddEmailButton = new System.Windows.Forms.Button();
            this.ORG_EmailTextBox = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.ORG_NameTextBox = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ORG_RoleComboBox = new System.Windows.Forms.ComboBox();
            this.ORG_IndividualListBox = new System.Windows.Forms.ListBox();
            this.ORG_RemoveButton = new System.Windows.Forms.Button();
            this.ORG_AddButton = new System.Windows.Forms.Button();
            this.MD_tabControl.SuspendLayout();
            this.MetadataTab.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.MD_GroupBox.SuspendLayout();
            this.IdentificationTab.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.ClassificationTab.SuspendLayout();
            this.CL_GroupBox.SuspendLayout();
            this.KeywordTab.SuspendLayout();
            this.KeywordGroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.GeographicTab.SuspendLayout();
            this.SPT_GroupBox.SuspendLayout();
            this.TemporalTab.SuspendLayout();
            this.TMP_GroupBox.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.QualityValidityTab.SuspendLayout();
            this.LineageGroupBox.SuspendLayout();
            this.QLT_GroupBox.SuspendLayout();
            this.Spatial_GroupBox.SuspendLayout();
            this.ConformityTab.SuspendLayout();
            this.CFRM_GroupBox.SuspendLayout();
            this.ConstraintsTab.SuspendLayout();
            this.CSTR_GroupBox.SuspendLayout();
            this.OrganizationTab.SuspendLayout();
            this.ORG_GroupBox.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.SuspendLayout();
            // 
            // MD_tabControl
            // 
            resources.ApplyResources(this.MD_tabControl, "MD_tabControl");
            this.MD_tabControl.Controls.Add(this.MetadataTab);
            this.MD_tabControl.Controls.Add(this.IdentificationTab);
            this.MD_tabControl.Controls.Add(this.ClassificationTab);
            this.MD_tabControl.Controls.Add(this.KeywordTab);
            this.MD_tabControl.Controls.Add(this.GeographicTab);
            this.MD_tabControl.Controls.Add(this.TemporalTab);
            this.MD_tabControl.Controls.Add(this.QualityValidityTab);
            this.MD_tabControl.Controls.Add(this.ConformityTab);
            this.MD_tabControl.Controls.Add(this.ConstraintsTab);
            this.MD_tabControl.Controls.Add(this.OrganizationTab);
            this.MD_tabControl.Multiline = true;
            this.MD_tabControl.Name = "MD_tabControl";
            this.MD_tabControl.SelectedIndex = 0;
            // 
            // MetadataTab
            // 
            resources.ApplyResources(this.MetadataTab, "MetadataTab");
            this.MetadataTab.Controls.Add(this.groupBox3);
            this.MetadataTab.Controls.Add(this.MD_GroupBox);
            this.MetadataTab.Name = "MetadataTab";
            this.MetadataTab.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Controls.Add(this.MD_ContactListBox);
            this.groupBox3.Controls.Add(this.MD_ContactListRemoveButton);
            this.groupBox3.Controls.Add(this.MD_ContactListAddButton);
            this.groupBox3.Controls.Add(this.groupBox6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // MD_ContactListBox
            // 
            resources.ApplyResources(this.MD_ContactListBox, "MD_ContactListBox");
            this.MD_ContactListBox.FormattingEnabled = true;
            this.MD_ContactListBox.Name = "MD_ContactListBox";
            // 
            // MD_ContactListRemoveButton
            // 
            resources.ApplyResources(this.MD_ContactListRemoveButton, "MD_ContactListRemoveButton");
            this.MD_ContactListRemoveButton.Name = "MD_ContactListRemoveButton";
            this.MD_ContactListRemoveButton.Click += new System.EventHandler(this.MD_ContactListRemoveButton_Click);
            // 
            // MD_ContactListAddButton
            // 
            resources.ApplyResources(this.MD_ContactListAddButton, "MD_ContactListAddButton");
            this.MD_ContactListAddButton.Name = "MD_ContactListAddButton";
            this.MD_ContactListAddButton.Click += new System.EventHandler(this.MD_ContactListAddButton_Click);
            // 
            // groupBox6
            // 
            resources.ApplyResources(this.groupBox6, "groupBox6");
            this.groupBox6.Controls.Add(this.MD_emailTextBox);
            this.groupBox6.Controls.Add(this.MD_RemoveEmailButton);
            this.groupBox6.Controls.Add(this.MD_AddEmailButton);
            this.groupBox6.Controls.Add(this.MD_EmailListBox);
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Controls.Add(this.MD_OrganizationNameTextBox);
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.TabStop = false;
            // 
            // MD_emailTextBox
            // 
            resources.ApplyResources(this.MD_emailTextBox, "MD_emailTextBox");
            this.MD_emailTextBox.Name = "MD_emailTextBox";
            // 
            // MD_RemoveEmailButton
            // 
            resources.ApplyResources(this.MD_RemoveEmailButton, "MD_RemoveEmailButton");
            this.MD_RemoveEmailButton.Name = "MD_RemoveEmailButton";
            this.MD_RemoveEmailButton.Click += new System.EventHandler(this.MD_RemoveEmailButton_Click);
            // 
            // MD_AddEmailButton
            // 
            resources.ApplyResources(this.MD_AddEmailButton, "MD_AddEmailButton");
            this.MD_AddEmailButton.Name = "MD_AddEmailButton";
            this.MD_AddEmailButton.Click += new System.EventHandler(this.MD_AddEmailButton_Click);
            // 
            // MD_EmailListBox
            // 
            resources.ApplyResources(this.MD_EmailListBox, "MD_EmailListBox");
            this.MD_EmailListBox.Name = "MD_EmailListBox";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // MD_OrganizationNameTextBox
            // 
            resources.ApplyResources(this.MD_OrganizationNameTextBox, "MD_OrganizationNameTextBox");
            this.MD_OrganizationNameTextBox.Name = "MD_OrganizationNameTextBox";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // MD_GroupBox
            // 
            resources.ApplyResources(this.MD_GroupBox, "MD_GroupBox");
            this.MD_GroupBox.Controls.Add(this.MD_LanguageComboBox);
            this.MD_GroupBox.Controls.Add(this.label5);
            this.MD_GroupBox.Controls.Add(this.MD_DateTimePicker);
            this.MD_GroupBox.Controls.Add(this.label4);
            this.MD_GroupBox.Name = "MD_GroupBox";
            this.MD_GroupBox.TabStop = false;
            // 
            // MD_LanguageComboBox
            // 
            resources.ApplyResources(this.MD_LanguageComboBox, "MD_LanguageComboBox");
            this.MD_LanguageComboBox.Items.AddRange(new object[] {
            resources.GetString("MD_LanguageComboBox.Items"),
            resources.GetString("MD_LanguageComboBox.Items1"),
            resources.GetString("MD_LanguageComboBox.Items2"),
            resources.GetString("MD_LanguageComboBox.Items3"),
            resources.GetString("MD_LanguageComboBox.Items4")});
            this.MD_LanguageComboBox.Name = "MD_LanguageComboBox";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // MD_DateTimePicker
            // 
            resources.ApplyResources(this.MD_DateTimePicker, "MD_DateTimePicker");
            this.MD_DateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.MD_DateTimePicker.Name = "MD_DateTimePicker";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // IdentificationTab
            // 
            resources.ApplyResources(this.IdentificationTab, "IdentificationTab");
            this.IdentificationTab.Controls.Add(this.groupBox1);
            this.IdentificationTab.Controls.Add(this.groupBox9);
            this.IdentificationTab.Controls.Add(this.groupBox8);
            this.IdentificationTab.Controls.Add(this.groupBox7);
            this.IdentificationTab.Name = "IdentificationTab";
            this.IdentificationTab.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ID_ResourceTypeComboBox);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.ID_ResourceAbstractTextBox);
            this.groupBox1.Controls.Add(this.ID_ResourseTitleTextBox);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // ID_ResourceTypeComboBox
            // 
            resources.ApplyResources(this.ID_ResourceTypeComboBox, "ID_ResourceTypeComboBox");
            this.ID_ResourceTypeComboBox.Items.AddRange(new object[] {
            resources.GetString("ID_ResourceTypeComboBox.Items"),
            resources.GetString("ID_ResourceTypeComboBox.Items1"),
            resources.GetString("ID_ResourceTypeComboBox.Items2")});
            this.ID_ResourceTypeComboBox.Name = "ID_ResourceTypeComboBox";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // ID_ResourceAbstractTextBox
            // 
            resources.ApplyResources(this.ID_ResourceAbstractTextBox, "ID_ResourceAbstractTextBox");
            this.ID_ResourceAbstractTextBox.Name = "ID_ResourceAbstractTextBox";
            // 
            // ID_ResourseTitleTextBox
            // 
            resources.ApplyResources(this.ID_ResourseTitleTextBox, "ID_ResourseTitleTextBox");
            this.ID_ResourseTitleTextBox.Name = "ID_ResourseTitleTextBox";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // groupBox9
            // 
            resources.ApplyResources(this.groupBox9, "groupBox9");
            this.groupBox9.Controls.Add(this.ID_ResourceLanguageListBox);
            this.groupBox9.Controls.Add(this.ID_ResourceLanguageComboBox);
            this.groupBox9.Controls.Add(this.ID_ResourceLanguageAddButton);
            this.groupBox9.Controls.Add(this.ID_ResourceLanguageRemoveButton);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.TabStop = false;
            // 
            // ID_ResourceLanguageListBox
            // 
            resources.ApplyResources(this.ID_ResourceLanguageListBox, "ID_ResourceLanguageListBox");
            this.ID_ResourceLanguageListBox.Name = "ID_ResourceLanguageListBox";
            // 
            // ID_ResourceLanguageComboBox
            // 
            resources.ApplyResources(this.ID_ResourceLanguageComboBox, "ID_ResourceLanguageComboBox");
            this.ID_ResourceLanguageComboBox.Items.AddRange(new object[] {
            resources.GetString("ID_ResourceLanguageComboBox.Items"),
            resources.GetString("ID_ResourceLanguageComboBox.Items1"),
            resources.GetString("ID_ResourceLanguageComboBox.Items2"),
            resources.GetString("ID_ResourceLanguageComboBox.Items3"),
            resources.GetString("ID_ResourceLanguageComboBox.Items4")});
            this.ID_ResourceLanguageComboBox.Name = "ID_ResourceLanguageComboBox";
            // 
            // ID_ResourceLanguageAddButton
            // 
            resources.ApplyResources(this.ID_ResourceLanguageAddButton, "ID_ResourceLanguageAddButton");
            this.ID_ResourceLanguageAddButton.Name = "ID_ResourceLanguageAddButton";
            this.ID_ResourceLanguageAddButton.Click += new System.EventHandler(this.ID_ResourceLanguageAddButton_Click);
            // 
            // ID_ResourceLanguageRemoveButton
            // 
            resources.ApplyResources(this.ID_ResourceLanguageRemoveButton, "ID_ResourceLanguageRemoveButton");
            this.ID_ResourceLanguageRemoveButton.Name = "ID_ResourceLanguageRemoveButton";
            this.ID_ResourceLanguageRemoveButton.Click += new System.EventHandler(this.ID_ResourceLanguageRemoveButton_Click);
            // 
            // groupBox8
            // 
            resources.ApplyResources(this.groupBox8, "groupBox8");
            this.groupBox8.Controls.Add(this.GUIDButton);
            this.groupBox8.Controls.Add(this.ID_CodeTextBox);
            this.groupBox8.Controls.Add(this.ID_UIDListBox);
            this.groupBox8.Controls.Add(this.ID_UIDAddButton);
            this.groupBox8.Controls.Add(this.ID_UIDRemoveButton);
            this.groupBox8.Controls.Add(this.ID_NamespaceTextBox);
            this.groupBox8.Controls.Add(this.label66);
            this.groupBox8.Controls.Add(this.label65);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.TabStop = false;
            // 
            // GUIDButton
            // 
            resources.ApplyResources(this.GUIDButton, "GUIDButton");
            this.GUIDButton.Name = "GUIDButton";
            this.GUIDButton.Click += new System.EventHandler(this.GUIDButton_Click);
            // 
            // ID_CodeTextBox
            // 
            resources.ApplyResources(this.ID_CodeTextBox, "ID_CodeTextBox");
            this.ID_CodeTextBox.Name = "ID_CodeTextBox";
            // 
            // ID_UIDListBox
            // 
            resources.ApplyResources(this.ID_UIDListBox, "ID_UIDListBox");
            this.ID_UIDListBox.Name = "ID_UIDListBox";
            // 
            // ID_UIDAddButton
            // 
            resources.ApplyResources(this.ID_UIDAddButton, "ID_UIDAddButton");
            this.ID_UIDAddButton.Name = "ID_UIDAddButton";
            this.ID_UIDAddButton.Click += new System.EventHandler(this.ID_UIDAddButton_Click);
            // 
            // ID_UIDRemoveButton
            // 
            resources.ApplyResources(this.ID_UIDRemoveButton, "ID_UIDRemoveButton");
            this.ID_UIDRemoveButton.Name = "ID_UIDRemoveButton";
            this.ID_UIDRemoveButton.Click += new System.EventHandler(this.ID_UIDRemoveButton_Click);
            // 
            // ID_NamespaceTextBox
            // 
            resources.ApplyResources(this.ID_NamespaceTextBox, "ID_NamespaceTextBox");
            this.ID_NamespaceTextBox.Name = "ID_NamespaceTextBox";
            // 
            // label66
            // 
            resources.ApplyResources(this.label66, "label66");
            this.label66.Name = "label66";
            // 
            // label65
            // 
            resources.ApplyResources(this.label65, "label65");
            this.label65.Name = "label65";
            // 
            // groupBox7
            // 
            resources.ApplyResources(this.groupBox7, "groupBox7");
            this.groupBox7.Controls.Add(this.ID_ResourceLocatorTextBox);
            this.groupBox7.Controls.Add(this.ID_ResourceLocatorListBox);
            this.groupBox7.Controls.Add(this.ID_ResourceLocatorAddButton);
            this.groupBox7.Controls.Add(this.ID_ResourceLocatorRemoveButton);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.TabStop = false;
            // 
            // ID_ResourceLocatorTextBox
            // 
            resources.ApplyResources(this.ID_ResourceLocatorTextBox, "ID_ResourceLocatorTextBox");
            this.ID_ResourceLocatorTextBox.Name = "ID_ResourceLocatorTextBox";
            // 
            // ID_ResourceLocatorListBox
            // 
            resources.ApplyResources(this.ID_ResourceLocatorListBox, "ID_ResourceLocatorListBox");
            this.ID_ResourceLocatorListBox.Name = "ID_ResourceLocatorListBox";
            // 
            // ID_ResourceLocatorAddButton
            // 
            resources.ApplyResources(this.ID_ResourceLocatorAddButton, "ID_ResourceLocatorAddButton");
            this.ID_ResourceLocatorAddButton.Name = "ID_ResourceLocatorAddButton";
            this.ID_ResourceLocatorAddButton.Click += new System.EventHandler(this.ID_ResourceLocatorAddButton_Click);
            // 
            // ID_ResourceLocatorRemoveButton
            // 
            resources.ApplyResources(this.ID_ResourceLocatorRemoveButton, "ID_ResourceLocatorRemoveButton");
            this.ID_ResourceLocatorRemoveButton.Name = "ID_ResourceLocatorRemoveButton";
            this.ID_ResourceLocatorRemoveButton.Click += new System.EventHandler(this.ID_ResourceLocatorRemoveButton_Click);
            // 
            // ClassificationTab
            // 
            resources.ApplyResources(this.ClassificationTab, "ClassificationTab");
            this.ClassificationTab.Controls.Add(this.CL_GroupBox);
            this.ClassificationTab.Name = "ClassificationTab";
            this.ClassificationTab.UseVisualStyleBackColor = true;
            // 
            // CL_GroupBox
            // 
            resources.ApplyResources(this.CL_GroupBox, "CL_GroupBox");
            this.CL_GroupBox.Controls.Add(this.CL_RemoveTopicCategoryButton);
            this.CL_GroupBox.Controls.Add(this.CL_TopicCategoryListBox);
            this.CL_GroupBox.Controls.Add(this.CL_AddTopicCategoryButton);
            this.CL_GroupBox.Controls.Add(this.CL_TopicCategoryComboBox);
            this.CL_GroupBox.Name = "CL_GroupBox";
            this.CL_GroupBox.TabStop = false;
            // 
            // CL_RemoveTopicCategoryButton
            // 
            resources.ApplyResources(this.CL_RemoveTopicCategoryButton, "CL_RemoveTopicCategoryButton");
            this.CL_RemoveTopicCategoryButton.Name = "CL_RemoveTopicCategoryButton";
            this.CL_RemoveTopicCategoryButton.Click += new System.EventHandler(this.CL_RemoveTopicCategoryButton_Click);
            // 
            // CL_TopicCategoryListBox
            // 
            resources.ApplyResources(this.CL_TopicCategoryListBox, "CL_TopicCategoryListBox");
            this.CL_TopicCategoryListBox.Name = "CL_TopicCategoryListBox";
            // 
            // CL_AddTopicCategoryButton
            // 
            resources.ApplyResources(this.CL_AddTopicCategoryButton, "CL_AddTopicCategoryButton");
            this.CL_AddTopicCategoryButton.Name = "CL_AddTopicCategoryButton";
            this.CL_AddTopicCategoryButton.Click += new System.EventHandler(this.CL_AddTopicCategoryButton_Click);
            // 
            // CL_TopicCategoryComboBox
            // 
            resources.ApplyResources(this.CL_TopicCategoryComboBox, "CL_TopicCategoryComboBox");
            this.CL_TopicCategoryComboBox.Items.AddRange(new object[] {
            resources.GetString("CL_TopicCategoryComboBox.Items"),
            resources.GetString("CL_TopicCategoryComboBox.Items1"),
            resources.GetString("CL_TopicCategoryComboBox.Items2"),
            resources.GetString("CL_TopicCategoryComboBox.Items3"),
            resources.GetString("CL_TopicCategoryComboBox.Items4"),
            resources.GetString("CL_TopicCategoryComboBox.Items5"),
            resources.GetString("CL_TopicCategoryComboBox.Items6"),
            resources.GetString("CL_TopicCategoryComboBox.Items7"),
            resources.GetString("CL_TopicCategoryComboBox.Items8"),
            resources.GetString("CL_TopicCategoryComboBox.Items9"),
            resources.GetString("CL_TopicCategoryComboBox.Items10"),
            resources.GetString("CL_TopicCategoryComboBox.Items11"),
            resources.GetString("CL_TopicCategoryComboBox.Items12"),
            resources.GetString("CL_TopicCategoryComboBox.Items13"),
            resources.GetString("CL_TopicCategoryComboBox.Items14"),
            resources.GetString("CL_TopicCategoryComboBox.Items15"),
            resources.GetString("CL_TopicCategoryComboBox.Items16"),
            resources.GetString("CL_TopicCategoryComboBox.Items17"),
            resources.GetString("CL_TopicCategoryComboBox.Items18")});
            this.CL_TopicCategoryComboBox.Name = "CL_TopicCategoryComboBox";
            // 
            // KeywordTab
            // 
            resources.ApplyResources(this.KeywordTab, "KeywordTab");
            this.KeywordTab.Controls.Add(this.KeywordGroupBox);
            this.KeywordTab.Name = "KeywordTab";
            this.KeywordTab.UseVisualStyleBackColor = true;
            // 
            // KeywordGroupBox
            // 
            resources.ApplyResources(this.KeywordGroupBox, "KeywordGroupBox");
            this.KeywordGroupBox.Controls.Add(this.label17);
            this.KeywordGroupBox.Controls.Add(this.groupBox2);
            this.KeywordGroupBox.Controls.Add(this.KW_AddInspireButton);
            this.KeywordGroupBox.Controls.Add(this.label9);
            this.KeywordGroupBox.Controls.Add(this.KW_InspireComboBox);
            this.KeywordGroupBox.Controls.Add(this.KW_KeywordRemoveButton);
            this.KeywordGroupBox.Controls.Add(this.KW_KeywordListBox);
            this.KeywordGroupBox.Name = "KeywordGroupBox";
            this.KeywordGroupBox.TabStop = false;
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.KW_DateTimePicker);
            this.groupBox2.Controls.Add(this.KW_DateTypeComboBox);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.KW_VocabularyTextBox);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.KW_KeywordTextBox);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.KW_KeywordAddButton);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // KW_DateTimePicker
            // 
            resources.ApplyResources(this.KW_DateTimePicker, "KW_DateTimePicker");
            this.KW_DateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.KW_DateTimePicker.Name = "KW_DateTimePicker";
            // 
            // KW_DateTypeComboBox
            // 
            resources.ApplyResources(this.KW_DateTypeComboBox, "KW_DateTypeComboBox");
            this.KW_DateTypeComboBox.Items.AddRange(new object[] {
            resources.GetString("KW_DateTypeComboBox.Items"),
            resources.GetString("KW_DateTypeComboBox.Items1"),
            resources.GetString("KW_DateTypeComboBox.Items2")});
            this.KW_DateTypeComboBox.Name = "KW_DateTypeComboBox";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // KW_VocabularyTextBox
            // 
            resources.ApplyResources(this.KW_VocabularyTextBox, "KW_VocabularyTextBox");
            this.KW_VocabularyTextBox.Name = "KW_VocabularyTextBox";
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // KW_KeywordTextBox
            // 
            resources.ApplyResources(this.KW_KeywordTextBox, "KW_KeywordTextBox");
            this.KW_KeywordTextBox.Name = "KW_KeywordTextBox";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // KW_KeywordAddButton
            // 
            resources.ApplyResources(this.KW_KeywordAddButton, "KW_KeywordAddButton");
            this.KW_KeywordAddButton.Name = "KW_KeywordAddButton";
            this.KW_KeywordAddButton.Click += new System.EventHandler(this.KW_KeywordAddButton_Click);
            // 
            // KW_AddInspireButton
            // 
            resources.ApplyResources(this.KW_AddInspireButton, "KW_AddInspireButton");
            this.KW_AddInspireButton.Name = "KW_AddInspireButton";
            this.KW_AddInspireButton.Click += new System.EventHandler(this.KW_AddInspireButton_Click);
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // KW_InspireComboBox
            // 
            resources.ApplyResources(this.KW_InspireComboBox, "KW_InspireComboBox");
            this.KW_InspireComboBox.Items.AddRange(new object[] {
            resources.GetString("KW_InspireComboBox.Items"),
            resources.GetString("KW_InspireComboBox.Items1"),
            resources.GetString("KW_InspireComboBox.Items2"),
            resources.GetString("KW_InspireComboBox.Items3"),
            resources.GetString("KW_InspireComboBox.Items4"),
            resources.GetString("KW_InspireComboBox.Items5"),
            resources.GetString("KW_InspireComboBox.Items6"),
            resources.GetString("KW_InspireComboBox.Items7"),
            resources.GetString("KW_InspireComboBox.Items8"),
            resources.GetString("KW_InspireComboBox.Items9"),
            resources.GetString("KW_InspireComboBox.Items10"),
            resources.GetString("KW_InspireComboBox.Items11"),
            resources.GetString("KW_InspireComboBox.Items12"),
            resources.GetString("KW_InspireComboBox.Items13"),
            resources.GetString("KW_InspireComboBox.Items14"),
            resources.GetString("KW_InspireComboBox.Items15"),
            resources.GetString("KW_InspireComboBox.Items16"),
            resources.GetString("KW_InspireComboBox.Items17"),
            resources.GetString("KW_InspireComboBox.Items18"),
            resources.GetString("KW_InspireComboBox.Items19"),
            resources.GetString("KW_InspireComboBox.Items20"),
            resources.GetString("KW_InspireComboBox.Items21"),
            resources.GetString("KW_InspireComboBox.Items22"),
            resources.GetString("KW_InspireComboBox.Items23"),
            resources.GetString("KW_InspireComboBox.Items24"),
            resources.GetString("KW_InspireComboBox.Items25"),
            resources.GetString("KW_InspireComboBox.Items26"),
            resources.GetString("KW_InspireComboBox.Items27"),
            resources.GetString("KW_InspireComboBox.Items28"),
            resources.GetString("KW_InspireComboBox.Items29"),
            resources.GetString("KW_InspireComboBox.Items30"),
            resources.GetString("KW_InspireComboBox.Items31"),
            resources.GetString("KW_InspireComboBox.Items32"),
            resources.GetString("KW_InspireComboBox.Items33")});
            this.KW_InspireComboBox.Name = "KW_InspireComboBox";
            // 
            // KW_KeywordRemoveButton
            // 
            resources.ApplyResources(this.KW_KeywordRemoveButton, "KW_KeywordRemoveButton");
            this.KW_KeywordRemoveButton.Name = "KW_KeywordRemoveButton";
            this.KW_KeywordRemoveButton.Click += new System.EventHandler(this.KW_KeywordRemoveButton_Click);
            // 
            // KW_KeywordListBox
            // 
            resources.ApplyResources(this.KW_KeywordListBox, "KW_KeywordListBox");
            this.KW_KeywordListBox.Name = "KW_KeywordListBox";
            // 
            // GeographicTab
            // 
            resources.ApplyResources(this.GeographicTab, "GeographicTab");
            this.GeographicTab.Controls.Add(this.SPT_GroupBox);
            this.GeographicTab.Name = "GeographicTab";
            this.GeographicTab.UseVisualStyleBackColor = true;
            // 
            // SPT_GroupBox
            // 
            resources.ApplyResources(this.SPT_GroupBox, "SPT_GroupBox");
            this.SPT_GroupBox.Controls.Add(this.GEO_RemoveExtendButton);
            this.SPT_GroupBox.Controls.Add(this.GEO_ExtendListBox);
            this.SPT_GroupBox.Controls.Add(this.GEO_AddExtendButton);
            this.SPT_GroupBox.Controls.Add(this.label61);
            this.SPT_GroupBox.Controls.Add(this.GEO_XmaxTextBox);
            this.SPT_GroupBox.Controls.Add(this.label60);
            this.SPT_GroupBox.Controls.Add(this.GEO_XminTextBox);
            this.SPT_GroupBox.Controls.Add(this.label59);
            this.SPT_GroupBox.Controls.Add(this.GEO_YminTextBox);
            this.SPT_GroupBox.Controls.Add(this.label58);
            this.SPT_GroupBox.Controls.Add(this.GEO_YmaxTextBox);
            this.SPT_GroupBox.Name = "SPT_GroupBox";
            this.SPT_GroupBox.TabStop = false;
            // 
            // GEO_RemoveExtendButton
            // 
            resources.ApplyResources(this.GEO_RemoveExtendButton, "GEO_RemoveExtendButton");
            this.GEO_RemoveExtendButton.Name = "GEO_RemoveExtendButton";
            this.GEO_RemoveExtendButton.Click += new System.EventHandler(this.GEO_RemoveExtendButton_Click);
            // 
            // GEO_ExtendListBox
            // 
            resources.ApplyResources(this.GEO_ExtendListBox, "GEO_ExtendListBox");
            this.GEO_ExtendListBox.Name = "GEO_ExtendListBox";
            // 
            // GEO_AddExtendButton
            // 
            resources.ApplyResources(this.GEO_AddExtendButton, "GEO_AddExtendButton");
            this.GEO_AddExtendButton.Name = "GEO_AddExtendButton";
            this.GEO_AddExtendButton.Click += new System.EventHandler(this.GEO_AddExtendButton_Click);
            // 
            // label61
            // 
            resources.ApplyResources(this.label61, "label61");
            this.label61.Name = "label61";
            // 
            // GEO_XmaxTextBox
            // 
            resources.ApplyResources(this.GEO_XmaxTextBox, "GEO_XmaxTextBox");
            this.GEO_XmaxTextBox.Name = "GEO_XmaxTextBox";
            // 
            // label60
            // 
            resources.ApplyResources(this.label60, "label60");
            this.label60.Name = "label60";
            // 
            // GEO_XminTextBox
            // 
            resources.ApplyResources(this.GEO_XminTextBox, "GEO_XminTextBox");
            this.GEO_XminTextBox.Name = "GEO_XminTextBox";
            // 
            // label59
            // 
            resources.ApplyResources(this.label59, "label59");
            this.label59.Name = "label59";
            // 
            // GEO_YminTextBox
            // 
            resources.ApplyResources(this.GEO_YminTextBox, "GEO_YminTextBox");
            this.GEO_YminTextBox.Name = "GEO_YminTextBox";
            // 
            // label58
            // 
            resources.ApplyResources(this.label58, "label58");
            this.label58.Name = "label58";
            // 
            // GEO_YmaxTextBox
            // 
            resources.ApplyResources(this.GEO_YmaxTextBox, "GEO_YmaxTextBox");
            this.GEO_YmaxTextBox.Name = "GEO_YmaxTextBox";
            // 
            // TemporalTab
            // 
            resources.ApplyResources(this.TemporalTab, "TemporalTab");
            this.TemporalTab.Controls.Add(this.TMP_GroupBox);
            this.TemporalTab.Name = "TemporalTab";
            this.TemporalTab.UseVisualStyleBackColor = true;
            // 
            // TMP_GroupBox
            // 
            resources.ApplyResources(this.TMP_GroupBox, "TMP_GroupBox");
            this.TMP_GroupBox.Controls.Add(this.groupBox11);
            this.TMP_GroupBox.Controls.Add(this.groupBox10);
            this.TMP_GroupBox.Controls.Add(this.groupBox5);
            this.TMP_GroupBox.Controls.Add(this.groupBox4);
            this.TMP_GroupBox.Name = "TMP_GroupBox";
            this.TMP_GroupBox.TabStop = false;
            // 
            // groupBox11
            // 
            resources.ApplyResources(this.groupBox11, "groupBox11");
            this.groupBox11.Controls.Add(this.label14);
            this.groupBox11.Controls.Add(this.TMP_ToDateTimePicker);
            this.groupBox11.Controls.Add(this.label13);
            this.groupBox11.Controls.Add(this.TMP_FromDateTimePicker);
            this.groupBox11.Controls.Add(this.TMP_RemoveExtendButton);
            this.groupBox11.Controls.Add(this.TMP_TemporalExtendListBox);
            this.groupBox11.Controls.Add(this.TMP_AddExtendButton);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.TabStop = false;
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // TMP_ToDateTimePicker
            // 
            resources.ApplyResources(this.TMP_ToDateTimePicker, "TMP_ToDateTimePicker");
            this.TMP_ToDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TMP_ToDateTimePicker.Name = "TMP_ToDateTimePicker";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // TMP_FromDateTimePicker
            // 
            resources.ApplyResources(this.TMP_FromDateTimePicker, "TMP_FromDateTimePicker");
            this.TMP_FromDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TMP_FromDateTimePicker.Name = "TMP_FromDateTimePicker";
            // 
            // TMP_RemoveExtendButton
            // 
            resources.ApplyResources(this.TMP_RemoveExtendButton, "TMP_RemoveExtendButton");
            this.TMP_RemoveExtendButton.Name = "TMP_RemoveExtendButton";
            this.TMP_RemoveExtendButton.Click += new System.EventHandler(this.TMP_RemoveExtendButton_Click);
            // 
            // TMP_TemporalExtendListBox
            // 
            resources.ApplyResources(this.TMP_TemporalExtendListBox, "TMP_TemporalExtendListBox");
            this.TMP_TemporalExtendListBox.Name = "TMP_TemporalExtendListBox";
            // 
            // TMP_AddExtendButton
            // 
            resources.ApplyResources(this.TMP_AddExtendButton, "TMP_AddExtendButton");
            this.TMP_AddExtendButton.Name = "TMP_AddExtendButton";
            this.TMP_AddExtendButton.Click += new System.EventHandler(this.TMP_AddExtendButton_Click);
            // 
            // groupBox10
            // 
            resources.ApplyResources(this.groupBox10, "groupBox10");
            this.groupBox10.Controls.Add(this.TMP_RemoveCreationDateButton);
            this.groupBox10.Controls.Add(this.TMP_AddCreationDateButton);
            this.groupBox10.Controls.Add(this.TMP_CreationDateListBox);
            this.groupBox10.Controls.Add(this.TMP_CreationDateTimePicker);
            this.groupBox10.Controls.Add(this.label31);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.TabStop = false;
            // 
            // TMP_RemoveCreationDateButton
            // 
            resources.ApplyResources(this.TMP_RemoveCreationDateButton, "TMP_RemoveCreationDateButton");
            this.TMP_RemoveCreationDateButton.Name = "TMP_RemoveCreationDateButton";
            this.TMP_RemoveCreationDateButton.Click += new System.EventHandler(this.TMP_RemoveCreationDateButton_Click);
            // 
            // TMP_AddCreationDateButton
            // 
            resources.ApplyResources(this.TMP_AddCreationDateButton, "TMP_AddCreationDateButton");
            this.TMP_AddCreationDateButton.Name = "TMP_AddCreationDateButton";
            this.TMP_AddCreationDateButton.Click += new System.EventHandler(this.TMP_AddCreationDateButton_Click);
            // 
            // TMP_CreationDateListBox
            // 
            resources.ApplyResources(this.TMP_CreationDateListBox, "TMP_CreationDateListBox");
            this.TMP_CreationDateListBox.Name = "TMP_CreationDateListBox";
            // 
            // TMP_CreationDateTimePicker
            // 
            resources.ApplyResources(this.TMP_CreationDateTimePicker, "TMP_CreationDateTimePicker");
            this.TMP_CreationDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TMP_CreationDateTimePicker.Name = "TMP_CreationDateTimePicker";
            // 
            // label31
            // 
            resources.ApplyResources(this.label31, "label31");
            this.label31.Name = "label31";
            // 
            // groupBox5
            // 
            resources.ApplyResources(this.groupBox5, "groupBox5");
            this.groupBox5.Controls.Add(this.TMP_RevisionDateTimePicker);
            this.groupBox5.Controls.Add(this.label30);
            this.groupBox5.Controls.Add(this.TMP_RevisionDateListBox);
            this.groupBox5.Controls.Add(this.TMP_AddRevisionDateButton);
            this.groupBox5.Controls.Add(this.TMP_RemoveRevisionDateButton);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.TabStop = false;
            // 
            // TMP_RevisionDateTimePicker
            // 
            resources.ApplyResources(this.TMP_RevisionDateTimePicker, "TMP_RevisionDateTimePicker");
            this.TMP_RevisionDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TMP_RevisionDateTimePicker.Name = "TMP_RevisionDateTimePicker";
            // 
            // label30
            // 
            resources.ApplyResources(this.label30, "label30");
            this.label30.Name = "label30";
            // 
            // TMP_RevisionDateListBox
            // 
            resources.ApplyResources(this.TMP_RevisionDateListBox, "TMP_RevisionDateListBox");
            this.TMP_RevisionDateListBox.Name = "TMP_RevisionDateListBox";
            // 
            // TMP_AddRevisionDateButton
            // 
            resources.ApplyResources(this.TMP_AddRevisionDateButton, "TMP_AddRevisionDateButton");
            this.TMP_AddRevisionDateButton.Name = "TMP_AddRevisionDateButton";
            this.TMP_AddRevisionDateButton.Click += new System.EventHandler(this.TMP_AddRevisionDateButton_Click);
            // 
            // TMP_RemoveRevisionDateButton
            // 
            resources.ApplyResources(this.TMP_RemoveRevisionDateButton, "TMP_RemoveRevisionDateButton");
            this.TMP_RemoveRevisionDateButton.Name = "TMP_RemoveRevisionDateButton";
            this.TMP_RemoveRevisionDateButton.Click += new System.EventHandler(this.TMP_RemoveRevisionDateButton_Click);
            // 
            // groupBox4
            // 
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Controls.Add(this.TMP_PublicTimePicker);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.TMP_AddDateButton);
            this.groupBox4.Controls.Add(this.TMP_PublicDateListBox);
            this.groupBox4.Controls.Add(this.TMP_RemoveDateButton);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // TMP_PublicTimePicker
            // 
            resources.ApplyResources(this.TMP_PublicTimePicker, "TMP_PublicTimePicker");
            this.TMP_PublicTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TMP_PublicTimePicker.Name = "TMP_PublicTimePicker";
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // TMP_AddDateButton
            // 
            resources.ApplyResources(this.TMP_AddDateButton, "TMP_AddDateButton");
            this.TMP_AddDateButton.Name = "TMP_AddDateButton";
            this.TMP_AddDateButton.Click += new System.EventHandler(this.TMP_AddDateButton_Click);
            // 
            // TMP_PublicDateListBox
            // 
            resources.ApplyResources(this.TMP_PublicDateListBox, "TMP_PublicDateListBox");
            this.TMP_PublicDateListBox.Name = "TMP_PublicDateListBox";
            // 
            // TMP_RemoveDateButton
            // 
            resources.ApplyResources(this.TMP_RemoveDateButton, "TMP_RemoveDateButton");
            this.TMP_RemoveDateButton.Name = "TMP_RemoveDateButton";
            this.TMP_RemoveDateButton.Click += new System.EventHandler(this.TMP_RemoveDateButton_Click);
            // 
            // QualityValidityTab
            // 
            resources.ApplyResources(this.QualityValidityTab, "QualityValidityTab");
            this.QualityValidityTab.Controls.Add(this.LineageGroupBox);
            this.QualityValidityTab.Controls.Add(this.QLT_GroupBox);
            this.QualityValidityTab.Name = "QualityValidityTab";
            this.QualityValidityTab.UseVisualStyleBackColor = true;
            // 
            // LineageGroupBox
            // 
            resources.ApplyResources(this.LineageGroupBox, "LineageGroupBox");
            this.LineageGroupBox.Controls.Add(this.LIN_FreeTextBox);
            this.LineageGroupBox.Name = "LineageGroupBox";
            this.LineageGroupBox.TabStop = false;
            // 
            // LIN_FreeTextBox
            // 
            this.LIN_FreeTextBox.AcceptsReturn = true;
            resources.ApplyResources(this.LIN_FreeTextBox, "LIN_FreeTextBox");
            this.LIN_FreeTextBox.Name = "LIN_FreeTextBox";
            // 
            // QLT_GroupBox
            // 
            resources.ApplyResources(this.QLT_GroupBox, "QLT_GroupBox");
            this.QLT_GroupBox.Controls.Add(this.Spatial_GroupBox);
            this.QLT_GroupBox.Name = "QLT_GroupBox";
            this.QLT_GroupBox.TabStop = false;
            // 
            // Spatial_GroupBox
            // 
            resources.ApplyResources(this.Spatial_GroupBox, "Spatial_GroupBox");
            this.Spatial_GroupBox.Controls.Add(this.QLT_UnitsComboBox);
            this.Spatial_GroupBox.Controls.Add(this.label29);
            this.Spatial_GroupBox.Controls.Add(this.QLT_AddDistanceButton);
            this.Spatial_GroupBox.Controls.Add(this.label20);
            this.Spatial_GroupBox.Controls.Add(this.QLT_DistanceTextBox);
            this.Spatial_GroupBox.Controls.Add(this.label19);
            this.Spatial_GroupBox.Controls.Add(this.QLT_ScaleTextBox);
            this.Spatial_GroupBox.Controls.Add(this.label18);
            this.Spatial_GroupBox.Controls.Add(this.QLT_RemoveButton);
            this.Spatial_GroupBox.Controls.Add(this.QLT_AddScaleButton);
            this.Spatial_GroupBox.Controls.Add(this.QLT_ListBox);
            this.Spatial_GroupBox.Name = "Spatial_GroupBox";
            this.Spatial_GroupBox.TabStop = false;
            // 
            // QLT_UnitsComboBox
            // 
            resources.ApplyResources(this.QLT_UnitsComboBox, "QLT_UnitsComboBox");
            this.QLT_UnitsComboBox.Items.AddRange(new object[] {
            resources.GetString("QLT_UnitsComboBox.Items"),
            resources.GetString("QLT_UnitsComboBox.Items1"),
            resources.GetString("QLT_UnitsComboBox.Items2"),
            resources.GetString("QLT_UnitsComboBox.Items3"),
            resources.GetString("QLT_UnitsComboBox.Items4"),
            resources.GetString("QLT_UnitsComboBox.Items5"),
            resources.GetString("QLT_UnitsComboBox.Items6")});
            this.QLT_UnitsComboBox.Name = "QLT_UnitsComboBox";
            // 
            // label29
            // 
            resources.ApplyResources(this.label29, "label29");
            this.label29.Name = "label29";
            // 
            // QLT_AddDistanceButton
            // 
            resources.ApplyResources(this.QLT_AddDistanceButton, "QLT_AddDistanceButton");
            this.QLT_AddDistanceButton.Name = "QLT_AddDistanceButton";
            this.QLT_AddDistanceButton.Click += new System.EventHandler(this.QLT_AddDistanceButton_Click);
            // 
            // label20
            // 
            resources.ApplyResources(this.label20, "label20");
            this.label20.Name = "label20";
            // 
            // QLT_DistanceTextBox
            // 
            resources.ApplyResources(this.QLT_DistanceTextBox, "QLT_DistanceTextBox");
            this.QLT_DistanceTextBox.Name = "QLT_DistanceTextBox";
            // 
            // label19
            // 
            resources.ApplyResources(this.label19, "label19");
            this.label19.Name = "label19";
            // 
            // QLT_ScaleTextBox
            // 
            resources.ApplyResources(this.QLT_ScaleTextBox, "QLT_ScaleTextBox");
            this.QLT_ScaleTextBox.Name = "QLT_ScaleTextBox";
            // 
            // label18
            // 
            resources.ApplyResources(this.label18, "label18");
            this.label18.Name = "label18";
            // 
            // QLT_RemoveButton
            // 
            resources.ApplyResources(this.QLT_RemoveButton, "QLT_RemoveButton");
            this.QLT_RemoveButton.Name = "QLT_RemoveButton";
            this.QLT_RemoveButton.Click += new System.EventHandler(this.QLT_RemoveButton_Click);
            // 
            // QLT_AddScaleButton
            // 
            resources.ApplyResources(this.QLT_AddScaleButton, "QLT_AddScaleButton");
            this.QLT_AddScaleButton.Name = "QLT_AddScaleButton";
            this.QLT_AddScaleButton.Click += new System.EventHandler(this.QLT_AddScaleButton_Click);
            // 
            // QLT_ListBox
            // 
            resources.ApplyResources(this.QLT_ListBox, "QLT_ListBox");
            this.QLT_ListBox.Name = "QLT_ListBox";
            // 
            // ConformityTab
            // 
            resources.ApplyResources(this.ConformityTab, "ConformityTab");
            this.ConformityTab.Controls.Add(this.CFRM_GroupBox);
            this.ConformityTab.Name = "ConformityTab";
            this.ConformityTab.UseVisualStyleBackColor = true;
            // 
            // CFRM_GroupBox
            // 
            resources.ApplyResources(this.CFRM_GroupBox, "CFRM_GroupBox");
            this.CFRM_GroupBox.Controls.Add(this.CFRM_DegreeComboBox);
            this.CFRM_GroupBox.Controls.Add(this.CFRM_DateTimePicker);
            this.CFRM_GroupBox.Controls.Add(this.CFRM_DateTypeComboBox);
            this.CFRM_GroupBox.Controls.Add(this.CFRM_AddButton);
            this.CFRM_GroupBox.Controls.Add(this.label21);
            this.CFRM_GroupBox.Controls.Add(this.label22);
            this.CFRM_GroupBox.Controls.Add(this.CFRM_TitleTextBox);
            this.CFRM_GroupBox.Controls.Add(this.label23);
            this.CFRM_GroupBox.Controls.Add(this.CFRM_RemoveButton);
            this.CFRM_GroupBox.Controls.Add(this.CFRM_ListBox);
            this.CFRM_GroupBox.Name = "CFRM_GroupBox";
            this.CFRM_GroupBox.TabStop = false;
            // 
            // CFRM_DegreeComboBox
            // 
            resources.ApplyResources(this.CFRM_DegreeComboBox, "CFRM_DegreeComboBox");
            this.CFRM_DegreeComboBox.Items.AddRange(new object[] {
            resources.GetString("CFRM_DegreeComboBox.Items"),
            resources.GetString("CFRM_DegreeComboBox.Items1"),
            resources.GetString("CFRM_DegreeComboBox.Items2")});
            this.CFRM_DegreeComboBox.Name = "CFRM_DegreeComboBox";
            // 
            // CFRM_DateTimePicker
            // 
            resources.ApplyResources(this.CFRM_DateTimePicker, "CFRM_DateTimePicker");
            this.CFRM_DateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.CFRM_DateTimePicker.Name = "CFRM_DateTimePicker";
            // 
            // CFRM_DateTypeComboBox
            // 
            resources.ApplyResources(this.CFRM_DateTypeComboBox, "CFRM_DateTypeComboBox");
            this.CFRM_DateTypeComboBox.Items.AddRange(new object[] {
            resources.GetString("CFRM_DateTypeComboBox.Items"),
            resources.GetString("CFRM_DateTypeComboBox.Items1"),
            resources.GetString("CFRM_DateTypeComboBox.Items2")});
            this.CFRM_DateTypeComboBox.Name = "CFRM_DateTypeComboBox";
            // 
            // CFRM_AddButton
            // 
            resources.ApplyResources(this.CFRM_AddButton, "CFRM_AddButton");
            this.CFRM_AddButton.Name = "CFRM_AddButton";
            this.CFRM_AddButton.Click += new System.EventHandler(this.CFRM_AddButton_Click);
            // 
            // label21
            // 
            resources.ApplyResources(this.label21, "label21");
            this.label21.Name = "label21";
            // 
            // label22
            // 
            resources.ApplyResources(this.label22, "label22");
            this.label22.Name = "label22";
            // 
            // CFRM_TitleTextBox
            // 
            resources.ApplyResources(this.CFRM_TitleTextBox, "CFRM_TitleTextBox");
            this.CFRM_TitleTextBox.Name = "CFRM_TitleTextBox";
            // 
            // label23
            // 
            resources.ApplyResources(this.label23, "label23");
            this.label23.Name = "label23";
            // 
            // CFRM_RemoveButton
            // 
            resources.ApplyResources(this.CFRM_RemoveButton, "CFRM_RemoveButton");
            this.CFRM_RemoveButton.Name = "CFRM_RemoveButton";
            this.CFRM_RemoveButton.Click += new System.EventHandler(this.CFRM_RemoveButton_Click);
            // 
            // CFRM_ListBox
            // 
            resources.ApplyResources(this.CFRM_ListBox, "CFRM_ListBox");
            this.CFRM_ListBox.Name = "CFRM_ListBox";
            // 
            // ConstraintsTab
            // 
            resources.ApplyResources(this.ConstraintsTab, "ConstraintsTab");
            this.ConstraintsTab.Controls.Add(this.CSTR_GroupBox);
            this.ConstraintsTab.Name = "ConstraintsTab";
            this.ConstraintsTab.UseVisualStyleBackColor = true;
            // 
            // CSTR_GroupBox
            // 
            resources.ApplyResources(this.CSTR_GroupBox, "CSTR_GroupBox");
            this.CSTR_GroupBox.Controls.Add(this.label26);
            this.CSTR_GroupBox.Controls.Add(this.CSTR_RemoveConditionsUseGeneralButton);
            this.CSTR_GroupBox.Controls.Add(this.CSTR_ConditionsUseGeneralListBox);
            this.CSTR_GroupBox.Controls.Add(this.CSTR_AddConditionsUseGeneralButton2);
            this.CSTR_GroupBox.Controls.Add(this.CSTR_ConditionsUseGeneralTextBox);
            this.CSTR_GroupBox.Controls.Add(this.CSTR_AddConditionsUseGeneralButton1);
            this.CSTR_GroupBox.Controls.Add(this.CSTR_RemoveLimitationsPublicButton);
            this.CSTR_GroupBox.Controls.Add(this.CSTR_LimitationsPublicListBox);
            this.CSTR_GroupBox.Controls.Add(this.CSTR_AddLimitationsPublicButton2);
            this.CSTR_GroupBox.Controls.Add(this.CSTR_LimitationsPublicTextBox);
            this.CSTR_GroupBox.Controls.Add(this.label12);
            this.CSTR_GroupBox.Controls.Add(this.CSTR_AddLimitationsPublicButton1);
            this.CSTR_GroupBox.Controls.Add(this.CSTR_ConditionsUseGeneralComboBox);
            this.CSTR_GroupBox.Controls.Add(this.CSTR_LimitationsPublicComboBox);
            this.CSTR_GroupBox.Controls.Add(this.label25);
            this.CSTR_GroupBox.Controls.Add(this.label24);
            this.CSTR_GroupBox.Name = "CSTR_GroupBox";
            this.CSTR_GroupBox.TabStop = false;
            // 
            // label26
            // 
            resources.ApplyResources(this.label26, "label26");
            this.label26.Name = "label26";
            // 
            // CSTR_RemoveConditionsUseGeneralButton
            // 
            resources.ApplyResources(this.CSTR_RemoveConditionsUseGeneralButton, "CSTR_RemoveConditionsUseGeneralButton");
            this.CSTR_RemoveConditionsUseGeneralButton.Name = "CSTR_RemoveConditionsUseGeneralButton";
            this.CSTR_RemoveConditionsUseGeneralButton.Click += new System.EventHandler(this.CSTR_RemoveConditionsUseGeneralButton_Click);
            // 
            // CSTR_ConditionsUseGeneralListBox
            // 
            resources.ApplyResources(this.CSTR_ConditionsUseGeneralListBox, "CSTR_ConditionsUseGeneralListBox");
            this.CSTR_ConditionsUseGeneralListBox.Name = "CSTR_ConditionsUseGeneralListBox";
            // 
            // CSTR_AddConditionsUseGeneralButton2
            // 
            resources.ApplyResources(this.CSTR_AddConditionsUseGeneralButton2, "CSTR_AddConditionsUseGeneralButton2");
            this.CSTR_AddConditionsUseGeneralButton2.Name = "CSTR_AddConditionsUseGeneralButton2";
            this.CSTR_AddConditionsUseGeneralButton2.Click += new System.EventHandler(this.CSTR_AddConditionsUseGeneralButton2_Click);
            // 
            // CSTR_ConditionsUseGeneralTextBox
            // 
            this.CSTR_ConditionsUseGeneralTextBox.AcceptsReturn = true;
            resources.ApplyResources(this.CSTR_ConditionsUseGeneralTextBox, "CSTR_ConditionsUseGeneralTextBox");
            this.CSTR_ConditionsUseGeneralTextBox.Name = "CSTR_ConditionsUseGeneralTextBox";
            // 
            // CSTR_AddConditionsUseGeneralButton1
            // 
            resources.ApplyResources(this.CSTR_AddConditionsUseGeneralButton1, "CSTR_AddConditionsUseGeneralButton1");
            this.CSTR_AddConditionsUseGeneralButton1.Name = "CSTR_AddConditionsUseGeneralButton1";
            this.CSTR_AddConditionsUseGeneralButton1.Click += new System.EventHandler(this.CSTR_AddConditionsUseGeneralButton1_Click);
            // 
            // CSTR_RemoveLimitationsPublicButton
            // 
            resources.ApplyResources(this.CSTR_RemoveLimitationsPublicButton, "CSTR_RemoveLimitationsPublicButton");
            this.CSTR_RemoveLimitationsPublicButton.Name = "CSTR_RemoveLimitationsPublicButton";
            this.CSTR_RemoveLimitationsPublicButton.Click += new System.EventHandler(this.CSTR_RemoveLimitationsPublicButton_Click);
            // 
            // CSTR_LimitationsPublicListBox
            // 
            resources.ApplyResources(this.CSTR_LimitationsPublicListBox, "CSTR_LimitationsPublicListBox");
            this.CSTR_LimitationsPublicListBox.Name = "CSTR_LimitationsPublicListBox";
            // 
            // CSTR_AddLimitationsPublicButton2
            // 
            resources.ApplyResources(this.CSTR_AddLimitationsPublicButton2, "CSTR_AddLimitationsPublicButton2");
            this.CSTR_AddLimitationsPublicButton2.Name = "CSTR_AddLimitationsPublicButton2";
            this.CSTR_AddLimitationsPublicButton2.Click += new System.EventHandler(this.CSTR_AddLimitationsPublicButton2_Click);
            // 
            // CSTR_LimitationsPublicTextBox
            // 
            this.CSTR_LimitationsPublicTextBox.AcceptsReturn = true;
            resources.ApplyResources(this.CSTR_LimitationsPublicTextBox, "CSTR_LimitationsPublicTextBox");
            this.CSTR_LimitationsPublicTextBox.Name = "CSTR_LimitationsPublicTextBox";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // CSTR_AddLimitationsPublicButton1
            // 
            resources.ApplyResources(this.CSTR_AddLimitationsPublicButton1, "CSTR_AddLimitationsPublicButton1");
            this.CSTR_AddLimitationsPublicButton1.Name = "CSTR_AddLimitationsPublicButton1";
            this.CSTR_AddLimitationsPublicButton1.Click += new System.EventHandler(this.CSTR_AddLimitationsPublicButton1_Click);
            // 
            // CSTR_ConditionsUseGeneralComboBox
            // 
            resources.ApplyResources(this.CSTR_ConditionsUseGeneralComboBox, "CSTR_ConditionsUseGeneralComboBox");
            this.CSTR_ConditionsUseGeneralComboBox.Items.AddRange(new object[] {
            resources.GetString("CSTR_ConditionsUseGeneralComboBox.Items"),
            resources.GetString("CSTR_ConditionsUseGeneralComboBox.Items1")});
            this.CSTR_ConditionsUseGeneralComboBox.Name = "CSTR_ConditionsUseGeneralComboBox";
            // 
            // CSTR_LimitationsPublicComboBox
            // 
            resources.ApplyResources(this.CSTR_LimitationsPublicComboBox, "CSTR_LimitationsPublicComboBox");
            this.CSTR_LimitationsPublicComboBox.Items.AddRange(new object[] {
            resources.GetString("CSTR_LimitationsPublicComboBox.Items"),
            resources.GetString("CSTR_LimitationsPublicComboBox.Items1"),
            resources.GetString("CSTR_LimitationsPublicComboBox.Items2"),
            resources.GetString("CSTR_LimitationsPublicComboBox.Items3"),
            resources.GetString("CSTR_LimitationsPublicComboBox.Items4"),
            resources.GetString("CSTR_LimitationsPublicComboBox.Items5"),
            resources.GetString("CSTR_LimitationsPublicComboBox.Items6"),
            resources.GetString("CSTR_LimitationsPublicComboBox.Items7"),
            resources.GetString("CSTR_LimitationsPublicComboBox.Items8")});
            this.CSTR_LimitationsPublicComboBox.Name = "CSTR_LimitationsPublicComboBox";
            // 
            // label25
            // 
            resources.ApplyResources(this.label25, "label25");
            this.label25.Name = "label25";
            // 
            // label24
            // 
            resources.ApplyResources(this.label24, "label24");
            this.label24.Name = "label24";
            // 
            // OrganizationTab
            // 
            resources.ApplyResources(this.OrganizationTab, "OrganizationTab");
            this.OrganizationTab.Controls.Add(this.ORG_GroupBox);
            this.OrganizationTab.Name = "OrganizationTab";
            this.OrganizationTab.UseVisualStyleBackColor = true;
            // 
            // ORG_GroupBox
            // 
            resources.ApplyResources(this.ORG_GroupBox, "ORG_GroupBox");
            this.ORG_GroupBox.Controls.Add(this.groupBox12);
            this.ORG_GroupBox.Controls.Add(this.ORG_IndividualListBox);
            this.ORG_GroupBox.Controls.Add(this.ORG_RemoveButton);
            this.ORG_GroupBox.Controls.Add(this.ORG_AddButton);
            this.ORG_GroupBox.Name = "ORG_GroupBox";
            this.ORG_GroupBox.TabStop = false;
            // 
            // groupBox12
            // 
            resources.ApplyResources(this.groupBox12, "groupBox12");
            this.groupBox12.Controls.Add(this.ORG_RemoveEmailButton);
            this.groupBox12.Controls.Add(this.ORG_EmailListBox);
            this.groupBox12.Controls.Add(this.ORG_AddEmailButton);
            this.groupBox12.Controls.Add(this.ORG_EmailTextBox);
            this.groupBox12.Controls.Add(this.label27);
            this.groupBox12.Controls.Add(this.ORG_NameTextBox);
            this.groupBox12.Controls.Add(this.label28);
            this.groupBox12.Controls.Add(this.label6);
            this.groupBox12.Controls.Add(this.ORG_RoleComboBox);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.TabStop = false;
            // 
            // ORG_RemoveEmailButton
            // 
            resources.ApplyResources(this.ORG_RemoveEmailButton, "ORG_RemoveEmailButton");
            this.ORG_RemoveEmailButton.Name = "ORG_RemoveEmailButton";
            this.ORG_RemoveEmailButton.Click += new System.EventHandler(this.ORG_RemoveEmailButton_Click);
            // 
            // ORG_EmailListBox
            // 
            resources.ApplyResources(this.ORG_EmailListBox, "ORG_EmailListBox");
            this.ORG_EmailListBox.Name = "ORG_EmailListBox";
            // 
            // ORG_AddEmailButton
            // 
            resources.ApplyResources(this.ORG_AddEmailButton, "ORG_AddEmailButton");
            this.ORG_AddEmailButton.Name = "ORG_AddEmailButton";
            this.ORG_AddEmailButton.Click += new System.EventHandler(this.ORG_AddEmailButton_Click);
            // 
            // ORG_EmailTextBox
            // 
            resources.ApplyResources(this.ORG_EmailTextBox, "ORG_EmailTextBox");
            this.ORG_EmailTextBox.Name = "ORG_EmailTextBox";
            // 
            // label27
            // 
            resources.ApplyResources(this.label27, "label27");
            this.label27.Name = "label27";
            // 
            // ORG_NameTextBox
            // 
            resources.ApplyResources(this.ORG_NameTextBox, "ORG_NameTextBox");
            this.ORG_NameTextBox.Name = "ORG_NameTextBox";
            // 
            // label28
            // 
            resources.ApplyResources(this.label28, "label28");
            this.label28.Name = "label28";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // ORG_RoleComboBox
            // 
            resources.ApplyResources(this.ORG_RoleComboBox, "ORG_RoleComboBox");
            this.ORG_RoleComboBox.Items.AddRange(new object[] {
            resources.GetString("ORG_RoleComboBox.Items"),
            resources.GetString("ORG_RoleComboBox.Items1"),
            resources.GetString("ORG_RoleComboBox.Items2"),
            resources.GetString("ORG_RoleComboBox.Items3"),
            resources.GetString("ORG_RoleComboBox.Items4"),
            resources.GetString("ORG_RoleComboBox.Items5"),
            resources.GetString("ORG_RoleComboBox.Items6"),
            resources.GetString("ORG_RoleComboBox.Items7"),
            resources.GetString("ORG_RoleComboBox.Items8"),
            resources.GetString("ORG_RoleComboBox.Items9"),
            resources.GetString("ORG_RoleComboBox.Items10")});
            this.ORG_RoleComboBox.Name = "ORG_RoleComboBox";
            // 
            // ORG_IndividualListBox
            // 
            resources.ApplyResources(this.ORG_IndividualListBox, "ORG_IndividualListBox");
            this.ORG_IndividualListBox.Name = "ORG_IndividualListBox";
            // 
            // ORG_RemoveButton
            // 
            resources.ApplyResources(this.ORG_RemoveButton, "ORG_RemoveButton");
            this.ORG_RemoveButton.Name = "ORG_RemoveButton";
            this.ORG_RemoveButton.Click += new System.EventHandler(this.ORG_RemoveButton_Click);
            // 
            // ORG_AddButton
            // 
            resources.ApplyResources(this.ORG_AddButton, "ORG_AddButton");
            this.ORG_AddButton.Name = "ORG_AddButton";
            this.ORG_AddButton.Click += new System.EventHandler(this.ORG_AddButton_Click);
            // 
            // MDControl
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.MD_tabControl);
            this.Name = "MDControl";
            this.MD_tabControl.ResumeLayout(false);
            this.MetadataTab.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.MD_GroupBox.ResumeLayout(false);
            this.IdentificationTab.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ClassificationTab.ResumeLayout(false);
            this.CL_GroupBox.ResumeLayout(false);
            this.KeywordTab.ResumeLayout(false);
            this.KeywordGroupBox.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.GeographicTab.ResumeLayout(false);
            this.SPT_GroupBox.ResumeLayout(false);
            this.SPT_GroupBox.PerformLayout();
            this.TemporalTab.ResumeLayout(false);
            this.TMP_GroupBox.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.QualityValidityTab.ResumeLayout(false);
            this.LineageGroupBox.ResumeLayout(false);
            this.LineageGroupBox.PerformLayout();
            this.QLT_GroupBox.ResumeLayout(false);
            this.Spatial_GroupBox.ResumeLayout(false);
            this.Spatial_GroupBox.PerformLayout();
            this.ConformityTab.ResumeLayout(false);
            this.CFRM_GroupBox.ResumeLayout(false);
            this.CFRM_GroupBox.PerformLayout();
            this.ConstraintsTab.ResumeLayout(false);
            this.CSTR_GroupBox.ResumeLayout(false);
            this.CSTR_GroupBox.PerformLayout();
            this.OrganizationTab.ResumeLayout(false);
            this.ORG_GroupBox.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

        #region utilities

        public void CreateGUID()
        {
            this.mdguid = System.Guid.NewGuid().ToString();
            this.ID_UIDListBox.Items.Add(this.mdguid);
        }

        public bool validateEmail(string email)
        {
            string pattern = @"^[a-z][a-z|0-9|]*([_][a-z|0-9]+)*([.][a-z|" +
               @"0-9]+([_][a-z|0-9]+)*)?@[a-z][a-z|0-9|]*\.([a-z]" +
               @"[a-z|0-9]*(\.[a-z][a-z|0-9]*)?)$";

            System.Text.RegularExpressions.Match match = Regex.Match(email.Trim(), pattern, RegexOptions.IgnoreCase);
            if (match.Success) return true;
            else return false;
        }

        #endregion

        #region MetadataTab

        //OK
		private void MD_AddEmailButton_Click(object sender, System.EventArgs e)
		{
			if(this.MD_emailTextBox.Text == "")
			{
				MessageBox.Show("Συμπληρώστε μια ηλεκτρονική διεύθυνση");
				return;
			}
            if (!this.validateEmail(this.MD_emailTextBox.Text))
            {
                MessageBox.Show("Η ηλεκτρονική διεύθυνση δεν είναι έγκυρη");
                return;
            }
            foreach (object o in this.MD_EmailListBox.Items)
            {
                if (this.MD_emailTextBox.Text == (string)o)
                {
                    MessageBox.Show("Η ηλεκτρονική διεύθυνση υπάρχει ήδη");
                    return;
                }
            }
			this.MD_EmailListBox.Items.Add(this.MD_emailTextBox.Text);
			this.MD_emailTextBox.Text = "";
		}

		//OK
		private void MD_RemoveEmailButton_Click(object sender, System.EventArgs e)
		{
			if(this.MD_EmailListBox.SelectedIndex == -1)
			{
				MessageBox.Show("Επιλέξτε μια διεύθυνση για να διαγραφεί");
				return;				
			}
			
			this.MD_EmailListBox.Items.RemoveAt(this.MD_EmailListBox.SelectedIndex);
		}

        //OK
        private void MD_ContactListAddButton_Click(object sender, EventArgs e)
        {
            if (this.MD_OrganizationNameTextBox.Text == "")
            {
                MessageBox.Show("Συμπληρώστε ένα όνομα οργανισμού");
                return;
            }
            if (this.MD_EmailListBox.Items.Count == 0)
            {
                MessageBox.Show("Παρακαλώ εισάγετε μια ηλεκτρονική διεύθυνση");
                return;
            }
            string tmp = this.MD_OrganizationNameTextBox.Text;
            for (int i = 0; i < this.MD_EmailListBox.Items.Count; i++)
            {
                tmp += "|" + this.MD_EmailListBox.Items[i].ToString();
            }
            foreach (object t in this.MD_ContactListBox.Items)
            {
                if (tmp == (string)t)
                {
                    MessageBox.Show("Οι πληροφορίες του οργανισμού υπάρχουν ήδη στη λίστα");
                    return;
                }
            }
            this.MD_ContactListBox.Items.Add(tmp);
            this.MD_EmailListBox.Items.Clear();
            this.MD_OrganizationNameTextBox.Clear();
        }

        //OK
        private void MD_ContactListRemoveButton_Click(object sender, EventArgs e)
        {
            if (this.MD_ContactListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Επιλέξτε έναν αρμόδιο επικοινωνίας για διαγραφή");
                return;
            }

            this.MD_ContactListBox.Items.RemoveAt(this.MD_ContactListBox.SelectedIndex);
        }

        #endregion

        #region IdentificationTab

        private void ID_ResourceLocatorAddButton_Click(object sender, EventArgs e)
        {
            if (this.ID_ResourceLocatorTextBox.Text == "")
            {
                MessageBox.Show("Συμπληρώστε μια ηλεκτρονική διεύθυνση (URL)");
                return;
            }
            if (this.ID_ResourceLocatorTextBox.Text.Length < 8)
            {
                MessageBox.Show("Η ηλεκτρονική διεύθυνση δεν είναι έγκυρη");
                return;
            }
            if (this.ID_ResourceLocatorTextBox.Text.Substring(0, 7) != "http://" && this.ID_ResourceLocatorTextBox.Text.Substring(0, 8) != "https://")
            {
                MessageBox.Show("Η ηλεκτρονική διεύθυνση δεν είναι έγκυρη");
                return;
            }
            foreach (object o in this.ID_ResourceLocatorListBox.Items)
            {
                if (this.ID_ResourceLocatorTextBox.Text == (string)o)
                {
                    MessageBox.Show("Η ηλεκτρονική διεύθυνση υπάρχει στη λίστα");
                    return;
                }
            }
            this.ID_ResourceLocatorListBox.Items.Add(this.ID_ResourceLocatorTextBox.Text);
            this.ID_ResourceLocatorTextBox.Text = "";
        }

        private void ID_ResourceLocatorRemoveButton_Click(object sender, EventArgs e)
        {
            if (this.ID_ResourceLocatorListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Επιλέξτε μια διεύθυνση για διαγραφή");
                return;
            }

            this.ID_ResourceLocatorListBox.Items.RemoveAt(this.ID_ResourceLocatorListBox.SelectedIndex);
        }

        private void ID_UIDAddButton_Click(object sender, EventArgs e)
        {
            if (this.ID_CodeTextBox.Text == "")
            {
                MessageBox.Show("Συμπληρώστε ένα αναγνωριστικό");
                return;
            }
            string tmp = ID_CodeTextBox.Text;

            if (this.ID_NamespaceTextBox.Text != "")
            {
                tmp += "|" + this.ID_NamespaceTextBox.Text;
            }
            foreach (object o in this.ID_UIDListBox.Items)
            {
                if (tmp == (string)o)
                {
                    MessageBox.Show("Το αναγνωριστικό υπάρχει ήδη");
                    return;
                }
            }
            this.ID_UIDListBox.Items.Add(tmp);
            this.ID_CodeTextBox.Text = "";
            this.ID_NamespaceTextBox.Text = "";
        }

        private void ID_UIDRemoveButton_Click(object sender, EventArgs e)
        {
            if (this.ID_UIDListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Επιλέξτε ένα μοναδικό χαρακτηριστικό για διαγραφή");
                return;
            }

            this.ID_UIDListBox.Items.RemoveAt(this.ID_UIDListBox.SelectedIndex);
        }

        private void GUIDButton_Click(object sender, EventArgs e)
        {
            this.CreateGUID();
            this.newGUIDpressed = true;
        }

        private void ID_ResourceLanguageAddButton_Click(object sender, EventArgs e)
        {
            if (this.ID_ResourceLanguageComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Επιλέξτε γλώσσα πόρου");
                return;
            }

            string tmp = (string)this.ID_ResourceLanguageComboBox.SelectedItem;
            foreach (object o in this.ID_ResourceLanguageListBox.Items)
            {
                if (tmp == (string)o)
                {
                    MessageBox.Show("Η γλώσσα πόρου υπάρχει στη λίστα");
                    return;
                }
            }
            this.ID_ResourceLanguageListBox.Items.Add(tmp);
            this.ID_ResourceLanguageComboBox.SelectedIndex = -1;
        }

        private void ID_ResourceLanguageRemoveButton_Click(object sender, EventArgs e)
        {
            if (this.ID_ResourceLanguageListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Επιλέξτε μια γλώσσα πόρου για διαγραφή");
                return;
            }

            this.ID_ResourceLanguageListBox.Items.RemoveAt(this.ID_ResourceLanguageListBox.SelectedIndex);
        }

        #endregion

        #region ClassificationTab

        //OK
		private void CL_AddTopicCategoryButton_Click(object sender, System.EventArgs e)
		{
			if(this.CL_TopicCategoryComboBox.SelectedIndex == -1)
			{
				MessageBox.Show("Επιλέξτε θεματική κατηγορία");
				return;
			}
            string tmp = (string) this.CL_TopicCategoryComboBox.SelectedItem;
			if (this.CL_TopicCategoryListBox.Items.Count != 0)
            {
                foreach (object obj in this.CL_TopicCategoryListBox.Items)
                {
                    if (tmp == (string)obj)
                    {
                        MessageBox.Show("Αυτή η θεματική κατηγορία είναι ήδη επιλεγμένη");
                        return;
                    }
                }
            }
			this.CL_TopicCategoryListBox.Items.Add(tmp);
            this.CL_TopicCategoryComboBox.SelectedIndex = -1;
		}

		//OK
		private void CL_RemoveTopicCategoryButton_Click(object sender, System.EventArgs e)
		{
			if(this.CL_TopicCategoryListBox.SelectedIndex == -1)
			{
				MessageBox.Show("Επιλέξτε θεματική κατηγορία για διαγραφή");
				return;				
			}
			
			this.CL_TopicCategoryListBox.Items.RemoveAt(this.CL_TopicCategoryListBox.SelectedIndex);
        }

        #endregion

        #region KeywordTab

        private void KW_AddInspireButton_Click(object sender, EventArgs e)
        {
            if (this.KW_InspireComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Επιλέξτε ένα θέμα δεδομένων Inspire");
                return;
            }

            string tmp = "GEMET - INSPIRE themes, version 1.0|δημοσίευση|2008-06-01|" + ((string)this.KW_InspireComboBox.SelectedItem);
            foreach (object o in this.KW_KeywordListBox.Items)
            {
                if (tmp == (string)o)
                {
                    MessageBox.Show("Το θέμα δεδομένων υπάρχει στη λίστα");
                    return;
                }
            }
            this.KW_KeywordListBox.Items.Add(tmp);
            this.KW_InspireComboBox.SelectedIndex = -1;
            this.KW_Sort();
        }

        

        //OK
		private void KW_KeywordAddButton_Click(object sender, System.EventArgs e)
		{
			if(this.KW_KeywordTextBox.Text == "")
			{
				MessageBox.Show("Συμπληρώστε μια λέξη κλειδί");
				return;
			}
            if (this.KW_VocabularyTextBox.Text == "")
            {
                MessageBox.Show("Συμπληρώστε ένα λεξιλόγιο προέλευσης");
                return;
            }
            if (this.KW_DateTypeComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Επιλέξτε μια ημερομηνία αναφοράς");
                return;
            }

            string tmp = this.KW_VocabularyTextBox.Text + "|" + ((string)this.KW_DateTypeComboBox.SelectedItem) + "|" + this.KW_DateTimePicker.Value.ToString("yyyy-MM-dd") + "|" + this.KW_KeywordTextBox.Text;
            foreach (object o in this.KW_KeywordListBox.Items)
            {
                if (tmp == (string)o)
                {
                    MessageBox.Show("Η λέξη κλειδί υπάρχει στη λίστα");
                    return;
                }
            }
            this.KW_KeywordListBox.Items.Add(tmp);
			this.KW_KeywordTextBox.Text = "";
            this.KW_VocabularyTextBox.Text = "";
            this.KW_DateTypeComboBox.SelectedIndex = -1;
            this.KW_Sort();
		}

        private void KW_Sort()
        {
            ArrayList ar = new ArrayList();

            foreach (object o in this.KW_KeywordListBox.Items)
            {
                ar.Add((string)o);
            }

            ar.Sort();

            this.KW_KeywordListBox.Items.Clear();

            foreach (object o in ar)
            {
                this.KW_KeywordListBox.Items.Add((string)o);
            }
        }

		//OK
		private void KW_KeywordRemoveButton_Click(object sender, System.EventArgs e)
		{
			if(this.KW_KeywordListBox.SelectedIndex == -1)
			{
				MessageBox.Show("Επιλέξτε μια λέξη κλειδί για διαγραφή");
				return;				
			}
			
			this.KW_KeywordListBox.Items.RemoveAt(this.KW_KeywordListBox.SelectedIndex);
        }

        #endregion

        #region GeographicTab

        private void GEO_AddExtendButton_Click(object sender, EventArgs e)
        {
            if (this.GEO_XminTextBox.Text == "")
            {
                MessageBox.Show("Συμπληρώστε δυτικό γεωγραφικό μήκος");
                return;
            }
            if (this.GEO_XmaxTextBox.Text == "")
            {
                MessageBox.Show("Συμπληρώστε ανατολικό γεωγραφικό μήκος");
                return;
            }
            if (this.GEO_YminTextBox.Text == "")
            {
                MessageBox.Show("Συμπληρώστε νότιο γεωγραφικό πλάτος");
                return;
            }
            if (this.GEO_YmaxTextBox.Text == "")
            {
                MessageBox.Show("Συμπληρώστε βόρειο γεωγραφικό πλάτος");
                return;
            }

            // Make sure the numbers use . for the decimal separator
            // If there are any . for thousands separator ignore them
            GEO_XminTextBox.Text = GEO_XminTextBox.Text.Replace(".",string.Empty).Replace(",",".");
            GEO_YminTextBox.Text = GEO_YminTextBox.Text.Replace(".", string.Empty).Replace(",", ".");
            GEO_XmaxTextBox.Text = GEO_XmaxTextBox.Text.Replace(".", string.Empty).Replace(",", ".");
            GEO_YmaxTextBox.Text = GEO_YmaxTextBox.Text.Replace(".", string.Empty).Replace(",", ".");

            double xmin, xmax, ymin, ymax;
            if (!Double.TryParse(this.GEO_XminTextBox.Text, out xmin))
            {
                MessageBox.Show("Το δυτικό γεωγραφικό μήκος δεν είναι έγκυρος αριθμός");
                return;
            }
            if (!Double.TryParse(this.GEO_XmaxTextBox.Text, out xmax))
            {
                MessageBox.Show("Το ανατολικό γεωγραφικό μήκος δεν είναι έγκυρος αριθμός");
                return;
            }
            if (!Double.TryParse(this.GEO_YminTextBox.Text, out ymin))
            {
                MessageBox.Show("Το νότιο γεωγραφικό πλάτος δεν είναι έγκυρος αριθμός");
                return;
            }
            if (!Double.TryParse(this.GEO_YmaxTextBox.Text, out ymax))
            {
                MessageBox.Show("Το βόρειο γεωγραφικό πλάτος δεν είναι έγκυρος αριθμός");
                return;
            }
            
            if (xmin > 180.0 || xmin < -180.0)
            {
                MessageBox.Show("Το δυτικό γεωγραφικό μήκος δεν είναι έγκυρος αριθμός");
                return;
            }
            if (xmax > 180.0 || xmax < -180.0)
            {
                MessageBox.Show("Το ανατολικό γεωγραφικό μήκος δεν είναι έγκυρος αριθμός");
                return;
            }
            if (ymin > 90.0 || ymin < -90.0)
            {
                MessageBox.Show("Το νότιο γεωγραφικό πλάτος δεν είναι έγκυρος αριθμός");
                return;
            }
            if (ymax > 90.0 || ymax < -90.0)
            {
                MessageBox.Show("Το βόρειο γεωγραφικό πλάτος δεν είναι έγκυρος αριθμός");
                return;
            }

            int xmin1, xmax1, ymin1, ymax1;
            if (Int32.TryParse(this.GEO_XminTextBox.Text, out xmin1))
            {
                MessageBox.Show("Το δυτικό γεωγραφικό μήκος πρέπει να είναι δεκαδικός αριθμός με τουλάχιστο δυο δεκαδικά ψηφία");
                return;
            }
            if (Int32.TryParse(this.GEO_XmaxTextBox.Text, out xmax1))
            {
                MessageBox.Show("Το ανατολικό γεωγραφικό μήκος πρέπει να είναι δεκαδικός αριθμός με τουλάχιστο δυο δεκαδικά ψηφία");
                return;
            }
            if (Int32.TryParse(this.GEO_YminTextBox.Text, out ymin1))
            {
                MessageBox.Show("Το νότιο γεωγραφικό πλάτος πρέπει να είναι δεκαδικός αριθμός με τουλάχιστο δυο δεκαδικά ψηφία");
                return;
            }
            if (Int32.TryParse(this.GEO_YmaxTextBox.Text, out ymax1))
            {
                MessageBox.Show("Το βόρειο γεωγραφικό πλάτος πρέπει να είναι δεκαδικός αριθμός με τουλάχιστο δυο δεκαδικά ψηφία");
                return;
            }

            if (xmin > xmax)
            {
                MessageBox.Show("Το δυτικό γεωγραφικό μήκος είναι μεγαλύτερο από το ανατολικό");
                return;
            }
            if (ymin > ymax)
            {
                MessageBox.Show("Το νότιο γεωγραφικό πλάτος είναι μεγαλύτερο από το βόρειο");
                return;
            }

            char c;
            System.Globalization.CultureInfo ci = System.Globalization.CultureInfo.CurrentUICulture;
            System.Globalization.NumberFormatInfo ni = (System.Globalization.NumberFormatInfo) ci.NumberFormat.Clone();
            c = (ni.NumberDecimalSeparator.ToCharArray())[0];

            string[] part;
            part = this.GEO_XminTextBox.Text.Split(c);
            if (part[1].Length < 2)
            {
                MessageBox.Show("Το δυτικό γεωγραφικό μήκος πρέπει να είναι δεκαδικός αριθμός με τουλάχιστο δυο δεκαδικά ψηφία");
                return;
            }
            part = this.GEO_XmaxTextBox.Text.Split(c);
            if (part[1].Length < 2)
            {
                MessageBox.Show("Το ανατολικό γεωγραφικό μήκος πρέπει να είναι δεκαδικός αριθμός με τουλάχιστο δυο δεκαδικά ψηφία");
                return;
            }
            part = this.GEO_YminTextBox.Text.Split(c);
            if (part[1].Length < 2)
            {
                MessageBox.Show("Το νότιο γεωγραφικό πλάτος πρέπει να είναι δεκαδικός αριθμός με τουλάχιστο δυο δεκαδικά ψηφία");
                return;
            }
            part = this.GEO_YmaxTextBox.Text.Split(c);
            if (part[1].Length < 2)
            {
                MessageBox.Show("Το βόρειο γεωγραφικό πλάτος πρέπει να είναι δεκαδικός αριθμός με τουλάχιστο δυο δεκαδικά ψηφία");
                return;
            }

            string tmp = this.GEO_XminTextBox.Text + ";" + this.GEO_YminTextBox.Text + ";" + this.GEO_XmaxTextBox.Text + ";" + this.GEO_YmaxTextBox.Text;
            this.GEO_ExtendListBox.Items.Add(tmp);
            this.GEO_XminTextBox.Text = "";
            this.GEO_XmaxTextBox.Text = "";
            this.GEO_YminTextBox.Text = "";
            this.GEO_YmaxTextBox.Text = "";
            
        }

        private void GEO_RemoveExtendButton_Click(object sender, EventArgs e)
        {
            if (this.GEO_ExtendListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Επιλέξτε ένα γεωγραφικό περίγραμμα για διαγραφή");
                return;
            }

            this.GEO_ExtendListBox.Items.RemoveAt(this.GEO_ExtendListBox.SelectedIndex);
        }

        #endregion

        #region TemporalTab

        //OK
		private void TMP_AddExtendButton_Click(object sender, System.EventArgs e)
		{
			if(this.TMP_FromDateTimePicker.Value > this.TMP_ToDateTimePicker.Value)
			{
				MessageBox.Show("Δώστε τις ημερομηνίες Από-Έως με σωστή χρονική σειρά");
				return;
			}

			string tmp;
            tmp = "Από " + this.TMP_FromDateTimePicker.Value.ToString("yyyy-MM-dd") + " Έως " + this.TMP_ToDateTimePicker.Value.ToString("yyyy-MM-dd");
			this.TMP_TemporalExtendListBox.Items.Add(tmp);
		}

		//OK
		private void TMP_RemoveExtendButton_Click(object sender, System.EventArgs e)
		{
			if(this.TMP_TemporalExtendListBox.SelectedIndex == -1)
			{
				MessageBox.Show("Επιλέξτε μια χρονική έκταση για διαγραφή");
				return;				
			}
			
			this.TMP_TemporalExtendListBox.Items.RemoveAt(this.TMP_TemporalExtendListBox.SelectedIndex);
		}

		//OK
		private void TMP_AddDateButton_Click(object sender, System.EventArgs e)
		{
            if (this.TMP_PublicDateListBox.Items.Count == 0)
            {
                this.TMP_PublicDateListBox.Items.Add(this.TMP_PublicTimePicker.Value.ToString("yyyy-MM-dd"));
            }
            else
            {
                string tmp1 = this.TMP_PublicTimePicker.Value.ToString("yyyy-MM-dd");
                foreach (object date in this.TMP_PublicDateListBox.Items)
                {
                    string tmp = (string)date;
                    if (tmp == tmp1)
                    {
                        MessageBox.Show("Προσοχή! Η ημερομηνία δημοσίευσης ήδη υπάρχει.");
                        break;
                    }
                }
                this.TMP_PublicDateListBox.Items.Add(tmp1);
            }
		}

		//OK
		private void TMP_RemoveDateButton_Click(object sender, System.EventArgs e)
		{
			if(this.TMP_PublicDateListBox.SelectedIndex == -1)
			{
				MessageBox.Show("Επιλέξτε ημερομηνία δημοσίευσης για διαγραφή");
				return;				
			}
			
			this.TMP_PublicDateListBox.Items.RemoveAt(this.TMP_PublicDateListBox.SelectedIndex);
        }

        private void TMP_AddRevisionDateButton_Click(object sender, EventArgs e)
        {
            this.TMP_RevisionDateListBox.Items.Add(this.TMP_RevisionDateTimePicker.Value.ToString("yyyy-MM-dd"));
            this.TMP_AddRevisionDateButton.Enabled = false;
        }

        private void TMP_RemoveRevisionDateButton_Click(object sender, EventArgs e)
        {
            this.TMP_RevisionDateListBox.Items.Clear();
            this.TMP_AddRevisionDateButton.Enabled = true;
        }

        private void TMP_AddCreationDateButton_Click(object sender, EventArgs e)
        {
            this.TMP_CreationDateListBox.Items.Add(this.TMP_CreationDateTimePicker.Value.ToString("yyyy-MM-dd"));
            this.TMP_AddCreationDateButton.Enabled = false;
        }

        private void TMP_RemoveCreationDateButton_Click(object sender, EventArgs e)
        {
            this.TMP_CreationDateListBox.Items.Clear();
            this.TMP_AddCreationDateButton.Enabled = true;
        }

        #endregion

        #region QualityTab

        //OK
		private void QLT_AddScaleButton_Click(object sender, System.EventArgs e)
		{
			if(this.QLT_ScaleTextBox.Text == "")
			{
				MessageBox.Show("Επιλέξτε κλίμακα");
				return;
			}
            int tmp1;
            if (!Int32.TryParse(this.QLT_ScaleTextBox.Text, out tmp1))
            {
                MessageBox.Show("Η κλίμακα πρέπει να είναι ακέραιος αριθμός");
                return;
            }
            if (tmp1 <= 0)
            {
                MessageBox.Show("Η κλίμακα δεν μπορεί να είναι αρνητικός αριθμός ή μηδέν");
                return;
            }
            Regex r = new Regex(@"\s");
			string dest = r.Replace(this.QLT_ScaleTextBox.Text, "");
			string tmp = "Κλίμακα: " + dest;
            foreach (object o in this.QLT_ListBox.Items)
            {
                if (tmp == (string)o)
                {
                    MessageBox.Show("Η κλίμακα υπάρχει ήδη στη λίστα");
                    return;
                }
            }
			this.QLT_ListBox.Items.Add(tmp);
            this.QLT_ScaleTextBox.Text = "";
		}

		//OK
		private void QLT_AddDistanceButton_Click(object sender, System.EventArgs e)
		{
			if(this.QLT_DistanceTextBox.Text == "")
			{
				MessageBox.Show("Επιλέξτε απόσταση");
				return;
			}
			if(this.QLT_UnitsComboBox.SelectedIndex == -1)
			{
				MessageBox.Show("Επιλέξτε μονάδα μέτρησης");
				return;
			}
            double tmp1;
            if (!Double.TryParse(this.QLT_DistanceTextBox.Text, out tmp1))
            {
                MessageBox.Show("Η απόσταση δεν είναι έγκυρος αριθμός");
                return;
            }
            if (tmp1 <= 0)
            {
                MessageBox.Show("Η απόσταση δεν είναι έγκυρος αριθμός");
                return;
            }
			Regex r = new Regex(@"\s");
			string dest1 = r.Replace(this.QLT_DistanceTextBox.Text, "");
            string dest2 = ((string)this.QLT_UnitsComboBox.SelectedItem);
			string tmp = "Απόσταση: " + dest1 + " " + dest2 + "s";
            foreach (object o in this.QLT_ListBox.Items)
            {
                if (tmp == (string)o)
                {
                    MessageBox.Show("Η απόσταση υπάρχει ήδη στη λίστα");
                    return;
                }
            }
			this.QLT_ListBox.Items.Add(tmp);
            this.QLT_DistanceTextBox.Text = "";
            this.QLT_UnitsComboBox.SelectedIndex = -1;
		}

		//OK
		private void QLT_RemoveButton_Click(object sender, System.EventArgs e)
		{
			if(this.QLT_ListBox.SelectedIndex == -1)
			{
				MessageBox.Show("Επιλέξτε χωρική ανάλυση για διαγραφή");
				return;				
			}
			
			this.QLT_ListBox.Items.RemoveAt(this.QLT_ListBox.SelectedIndex);
        }

        #endregion

        #region ConformityTab

        //OK
		private void CFRM_AddButton_Click(object sender, System.EventArgs e)
		{
			if(this.CFRM_DegreeComboBox.SelectedIndex == -1)
			{
				MessageBox.Show("Επιλέξτε ένα βαθμό συμμόρφωσης");
				return;
			}
			if(this.CFRM_TitleTextBox.Text == "")
			{
                MessageBox.Show("Επιλέξτε ένα τίτλο");
				return;
			}
			if(this.CFRM_DateTypeComboBox.SelectedIndex == -1)
			{
                MessageBox.Show("Επιλέξτε ένα τύπο ημερομηνίας");
				return;
			}

            string degree = (string)this.CFRM_DegreeComboBox.SelectedItem;
            string title = this.CFRM_TitleTextBox.Text;
            string datetype = (string)this.CFRM_DateTypeComboBox.SelectedItem;
            string date = this.CFRM_DateTimePicker.Value.ToString("yyyy-MM-dd");
            string tmp = degree + "|" + title + "|" + datetype + "|" + date;

            if (this.CFRM_ListBox.Items.Count != 0)
            {
                foreach (object obj in this.CFRM_ListBox.Items)
                {
                    string[] part = ((string)obj).Split('|');
                    string cur_degree = part[0];
                    string cur_title = part[1];
                    string cur_datetype = part[2];
                    string cur_date = part[3];

                    if (datetype == cur_datetype && degree == cur_degree && title == cur_title && date == cur_date)
                    {
                        MessageBox.Show("Προσοχή! Αυτή η εγγραφή υπάρχει ήδη.");
                        break;
                    }
                    if (title == cur_title && datetype == cur_datetype && datetype == "δημιουργία")
                    {
                        MessageBox.Show("Προσοχή! Υπάρχει ήδη μια ημερομηνία δημιουργίας για αυτόν τον τίτλο.");
                        break;
                    }
                    if (title == cur_title && datetype == cur_datetype && datetype == "δημοσίευση" && date == cur_date)
                    {
                        MessageBox.Show("Προσοχή! Υπάρχει ήδη μια ημερομηνία δημοσίευσης για αυτόν τον τίτλο");
                        break;
                    }
                }
            }
            
            this.CFRM_ListBox.Items.Add(tmp);
            this.CFRM_DateTypeComboBox.SelectedIndex = -1;
            this.CFRM_DegreeComboBox.SelectedIndex = -1;
            this.CFRM_TitleTextBox.Text = "";
		}

		//OK
		private void CFRM_RemoveButton_Click(object sender, System.EventArgs e)
		{
			if(this.CFRM_ListBox.SelectedIndex == -1)
			{
				MessageBox.Show("Επιλέξτε μια εγγραφή συμμόρφωσης για διαγραφή");
				return;				
			}
			
			this.CFRM_ListBox.Items.RemoveAt(this.CFRM_ListBox.SelectedIndex);
        }

        #endregion

        #region ConstraintsTab

        private void CSTR_AddLimitationsPublicButton1_Click(object sender, EventArgs e)
        {
            if (this.CSTR_LimitationsPublicComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Επιλέξτε έναν όρο πρόσβασης και χρήσης");
                return;
            }
            this.CSTR_LimitationsPublicListBox.Items.Add(((string)this.CSTR_LimitationsPublicComboBox.SelectedItem));
            this.CSTR_AddLimitationsPublicButton1.Enabled = false;
            this.CSTR_AddLimitationsPublicButton2.Enabled = false;
            this.CSTR_LimitationsPublicComboBox.SelectedIndex = -1;
        }

        private void CSTR_AddLimitationsPublicButton2_Click(object sender, EventArgs e)
        {
            if (this.CSTR_LimitationsPublicTextBox.Text == "")
            {
                MessageBox.Show("Συμπληρώστε με ελεύθερο κείμενο έναν όρο πρόσβασης και χρήσης");
                return;
            }
            this.CSTR_LimitationsPublicListBox.Items.Add(this.CSTR_LimitationsPublicTextBox.Text);
            this.CSTR_AddLimitationsPublicButton1.Enabled = false;
            this.CSTR_LimitationsPublicTextBox.Text = "";
        }

        private void CSTR_RemoveLimitationsPublicButton_Click(object sender, EventArgs e)
        {
            if (this.CSTR_LimitationsPublicListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Επιλέξτε μια εγγραφή για διαγραφή");
                return;
            }

            this.CSTR_LimitationsPublicListBox.Items.RemoveAt(this.CSTR_LimitationsPublicListBox.SelectedIndex);
            this.CSTR_AddLimitationsPublicButton2.Enabled = true;
            if (this.CSTR_LimitationsPublicListBox.Items.Count == 0) this.CSTR_AddLimitationsPublicButton1.Enabled = true;
        }

        private void CSTR_AddConditionsUseGeneralButton1_Click(object sender, EventArgs e)
        {
            if (this.CSTR_ConditionsUseGeneralComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Συμπληρώστε έναν περιορισμό πρόσβασης");
                return;
            }
            this.CSTR_ConditionsUseGeneralListBox.Items.Add(((string)this.CSTR_ConditionsUseGeneralComboBox.SelectedItem));
            this.CSTR_AddConditionsUseGeneralButton1.Enabled = false;
            this.CSTR_AddConditionsUseGeneralButton2.Enabled = false;
            this.CSTR_ConditionsUseGeneralComboBox.SelectedIndex = -1;
        }

        private void CSTR_AddConditionsUseGeneralButton2_Click(object sender, EventArgs e)
        {
            if (this.CSTR_ConditionsUseGeneralTextBox.Text == "")
            {
                MessageBox.Show("Συμπληρώστε με ελεύθερο κείμενο έναν περιορισμό πρόσβασης");
                return;
            }
            this.CSTR_ConditionsUseGeneralListBox.Items.Add(this.CSTR_ConditionsUseGeneralTextBox.Text);
            this.CSTR_AddConditionsUseGeneralButton1.Enabled = false;
            this.CSTR_ConditionsUseGeneralTextBox.Text = "";
        }

        private void CSTR_RemoveConditionsUseGeneralButton_Click(object sender, EventArgs e)
        {
            if (this.CSTR_ConditionsUseGeneralListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Επιλέξτε μια εγγραφή για διαγραφή");
                return;
            }

            this.CSTR_ConditionsUseGeneralListBox.Items.RemoveAt(this.CSTR_ConditionsUseGeneralListBox.SelectedIndex);
            this.CSTR_AddConditionsUseGeneralButton2.Enabled = true;
            if (this.CSTR_ConditionsUseGeneralListBox.Items.Count == 0) this.CSTR_AddConditionsUseGeneralButton1.Enabled = true;
        }

        #endregion

        #region OrganisationTab

        //OK
		private void ORG_AddButton_Click(object sender, System.EventArgs e)
		{
			if(this.ORG_NameTextBox.Text == "")
			{
				MessageBox.Show("Επιλέξτε ένα όνομα οργανισμού");
				return;
			}
			if(this.ORG_EmailListBox.Items.Count == 0)
			{
				MessageBox.Show("Επιλέξτε μια διεύθυνση ηλεκτρονικού ταχυδρομίου");
				return;
			}
			if(this.ORG_RoleComboBox.SelectedIndex == -1)
			{
				MessageBox.Show("Επιλέξτε ένα ρόλο αρμόδιου μέρους");
				return;
			}

			string tmp = this.ORG_NameTextBox.Text + "|" + ((string)this.ORG_RoleComboBox.SelectedItem);
            for (int i = 0; i < this.ORG_EmailListBox.Items.Count; i++)
            {
                tmp += "|" + this.ORG_EmailListBox.Items[i].ToString();
            }
            
            foreach (object t in this.ORG_IndividualListBox.Items)
            {
                if (tmp == (string)t)
                {
                    MessageBox.Show("Οι πληροφορίες οργανισμού υπάρχουν ήδη");
                    return;
                }
            }
            
            this.ORG_IndividualListBox.Items.Add(tmp);
            this.ORG_EmailListBox.Items.Clear();
            this.ORG_RoleComboBox.SelectedIndex = -1;
            this.ORG_NameTextBox.Text = "";
		}

        //OK
        private void ORG_RemoveButton_Click(object sender, System.EventArgs e)
		{
			if(this.ORG_IndividualListBox.SelectedIndex == -1)
			{
				MessageBox.Show("Επιλέξτε μια εγγραφή οργανισμού για διαγραφή");
				return;				
			}
			
			this.ORG_IndividualListBox.Items.RemoveAt(this.ORG_IndividualListBox.SelectedIndex);
        }

        private void ORG_AddEmailButton_Click(object sender, EventArgs e)
        {
            if (this.ORG_EmailTextBox.Text == "")
            {
                MessageBox.Show("Συμπληρώστε μια διεύθυνση ηλεκτρονικού ταχυδρομίου");
                return;
            }
            if (!this.validateEmail(this.ORG_EmailTextBox.Text))
            {
                MessageBox.Show("Η ηλεκτρονική διεύθυνση δεν είναι έγκυρη");
                return;
            }
            foreach (object o in this.ORG_EmailListBox.Items)
            {
                if (this.ORG_EmailTextBox.Text == (string)o)
                {
                    MessageBox.Show("Η ηλεκτρονική διεύθυνση υπάρχει ήδη στη λίστα");
                    return;
                }
            }
            this.ORG_EmailListBox.Items.Add(this.ORG_EmailTextBox.Text);
            this.ORG_EmailTextBox.Text = "";
        }

        private void ORG_RemoveEmailButton_Click(object sender, EventArgs e)
        {
            if (this.ORG_EmailListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Επιλέξτε μια ηλεκτρονική διεύθυνση για διαγραφή");
                return;
            }

            this.ORG_EmailListBox.Items.RemoveAt(this.ORG_EmailListBox.SelectedIndex);
        }        

        #endregion

    }
}
