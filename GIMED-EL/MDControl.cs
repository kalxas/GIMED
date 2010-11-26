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

namespace Inspire.Metadata
{
	/// <summary>
	/// Summary description for MDControl.
	/// </summary>
	public class MDControl : System.Windows.Forms.UserControl
	{
        public string mdguid;
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
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
            this.CreateGUID();
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
            this.MD_tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MD_tabControl.Location = new System.Drawing.Point(0, 0);
            this.MD_tabControl.Multiline = true;
            this.MD_tabControl.Name = "MD_tabControl";
            this.MD_tabControl.SelectedIndex = 0;
            this.MD_tabControl.Size = new System.Drawing.Size(589, 525);
            this.MD_tabControl.TabIndex = 0;
            // 
            // MetadataTab
            // 
            this.MetadataTab.Controls.Add(this.groupBox3);
            this.MetadataTab.Controls.Add(this.MD_GroupBox);
            this.MetadataTab.Location = new System.Drawing.Point(4, 40);
            this.MetadataTab.Name = "MetadataTab";
            this.MetadataTab.Size = new System.Drawing.Size(581, 481);
            this.MetadataTab.TabIndex = 0;
            this.MetadataTab.Text = "Μεταδεδομένα";
            this.MetadataTab.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.MD_ContactListBox);
            this.groupBox3.Controls.Add(this.MD_ContactListRemoveButton);
            this.groupBox3.Controls.Add(this.MD_ContactListAddButton);
            this.groupBox3.Controls.Add(this.groupBox6);
            this.groupBox3.Location = new System.Drawing.Point(19, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(554, 292);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Αρμόδιος για επικοινωνία";
            // 
            // MD_ContactListBox
            // 
            this.MD_ContactListBox.FormattingEnabled = true;
            this.MD_ContactListBox.Location = new System.Drawing.Point(19, 210);
            this.MD_ContactListBox.Name = "MD_ContactListBox";
            this.MD_ContactListBox.Size = new System.Drawing.Size(458, 56);
            this.MD_ContactListBox.TabIndex = 24;
            // 
            // MD_ContactListRemoveButton
            // 
            this.MD_ContactListRemoveButton.Location = new System.Drawing.Point(483, 224);
            this.MD_ContactListRemoveButton.Name = "MD_ContactListRemoveButton";
            this.MD_ContactListRemoveButton.Size = new System.Drawing.Size(67, 24);
            this.MD_ContactListRemoveButton.TabIndex = 23;
            this.MD_ContactListRemoveButton.Text = "Διαγραφή";
            this.MD_ContactListRemoveButton.Click += new System.EventHandler(this.MD_ContactListRemoveButton_Click);
            // 
            // MD_ContactListAddButton
            // 
            this.MD_ContactListAddButton.Location = new System.Drawing.Point(483, 84);
            this.MD_ContactListAddButton.Name = "MD_ContactListAddButton";
            this.MD_ContactListAddButton.Size = new System.Drawing.Size(67, 24);
            this.MD_ContactListAddButton.TabIndex = 22;
            this.MD_ContactListAddButton.Text = "Προσθήκη";
            this.MD_ContactListAddButton.Click += new System.EventHandler(this.MD_ContactListAddButton_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.MD_emailTextBox);
            this.groupBox6.Controls.Add(this.MD_RemoveEmailButton);
            this.groupBox6.Controls.Add(this.MD_AddEmailButton);
            this.groupBox6.Controls.Add(this.MD_EmailListBox);
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Controls.Add(this.MD_OrganizationNameTextBox);
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Location = new System.Drawing.Point(19, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(458, 186);
            this.groupBox6.TabIndex = 17;
            this.groupBox6.TabStop = false;
            // 
            // MD_emailTextBox
            // 
            this.MD_emailTextBox.Location = new System.Drawing.Point(49, 39);
            this.MD_emailTextBox.Name = "MD_emailTextBox";
            this.MD_emailTextBox.Size = new System.Drawing.Size(326, 20);
            this.MD_emailTextBox.TabIndex = 17;
            // 
            // MD_RemoveEmailButton
            // 
            this.MD_RemoveEmailButton.Location = new System.Drawing.Point(381, 85);
            this.MD_RemoveEmailButton.Name = "MD_RemoveEmailButton";
            this.MD_RemoveEmailButton.Size = new System.Drawing.Size(67, 24);
            this.MD_RemoveEmailButton.TabIndex = 21;
            this.MD_RemoveEmailButton.Text = "Διαγραφή";
            this.MD_RemoveEmailButton.Click += new System.EventHandler(this.MD_RemoveEmailButton_Click);
            // 
            // MD_AddEmailButton
            // 
            this.MD_AddEmailButton.Location = new System.Drawing.Point(381, 36);
            this.MD_AddEmailButton.Name = "MD_AddEmailButton";
            this.MD_AddEmailButton.Size = new System.Drawing.Size(67, 24);
            this.MD_AddEmailButton.TabIndex = 20;
            this.MD_AddEmailButton.Text = "Προσθήκη";
            this.MD_AddEmailButton.Click += new System.EventHandler(this.MD_AddEmailButton_Click);
            // 
            // MD_EmailListBox
            // 
            this.MD_EmailListBox.Location = new System.Drawing.Point(49, 71);
            this.MD_EmailListBox.Name = "MD_EmailListBox";
            this.MD_EmailListBox.Size = new System.Drawing.Size(326, 56);
            this.MD_EmailListBox.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(9, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 16);
            this.label2.TabIndex = 18;
            this.label2.Text = "Ηλεκτρονική διεύθυνση";
            // 
            // MD_OrganizationNameTextBox
            // 
            this.MD_OrganizationNameTextBox.Location = new System.Drawing.Point(49, 151);
            this.MD_OrganizationNameTextBox.Name = "MD_OrganizationNameTextBox";
            this.MD_OrganizationNameTextBox.Size = new System.Drawing.Size(326, 20);
            this.MD_OrganizationNameTextBox.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(9, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 16);
            this.label3.TabIndex = 22;
            this.label3.Text = "Ονομασία Οργανισμού";
            // 
            // MD_GroupBox
            // 
            this.MD_GroupBox.Controls.Add(this.MD_LanguageComboBox);
            this.MD_GroupBox.Controls.Add(this.label5);
            this.MD_GroupBox.Controls.Add(this.MD_DateTimePicker);
            this.MD_GroupBox.Controls.Add(this.label4);
            this.MD_GroupBox.Location = new System.Drawing.Point(19, 301);
            this.MD_GroupBox.Name = "MD_GroupBox";
            this.MD_GroupBox.Size = new System.Drawing.Size(554, 104);
            this.MD_GroupBox.TabIndex = 10;
            this.MD_GroupBox.TabStop = false;
            this.MD_GroupBox.Text = "Μεταδεδομένα για τα μεταδεδομένα";
            // 
            // MD_LanguageComboBox
            // 
            this.MD_LanguageComboBox.Items.AddRange(new object[] {
            "Αγγλικά",
            "Γαλλικά",
            "Γερμανικά",
            "Ελληνικά",
            "Ιταλικά"});
            this.MD_LanguageComboBox.Location = new System.Drawing.Point(56, 72);
            this.MD_LanguageComboBox.Name = "MD_LanguageComboBox";
            this.MD_LanguageComboBox.Size = new System.Drawing.Size(273, 21);
            this.MD_LanguageComboBox.TabIndex = 20;
            this.MD_LanguageComboBox.Text = "Παρακαλώ επιλέξτε";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(16, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 16);
            this.label5.TabIndex = 19;
            this.label5.Text = "Γλώσσα μεταδεδομένων";
            // 
            // MD_DateTimePicker
            // 
            this.MD_DateTimePicker.CustomFormat = "yyyy-MM-dd";
            this.MD_DateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.MD_DateTimePicker.Location = new System.Drawing.Point(56, 32);
            this.MD_DateTimePicker.Name = "MD_DateTimePicker";
            this.MD_DateTimePicker.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.MD_DateTimePicker.Size = new System.Drawing.Size(273, 20);
            this.MD_DateTimePicker.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(16, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 16);
            this.label4.TabIndex = 17;
            this.label4.Text = "Ημερομηνία μεταδεδομένων";
            // 
            // IdentificationTab
            // 
            this.IdentificationTab.Controls.Add(this.groupBox1);
            this.IdentificationTab.Controls.Add(this.groupBox9);
            this.IdentificationTab.Controls.Add(this.groupBox8);
            this.IdentificationTab.Controls.Add(this.groupBox7);
            this.IdentificationTab.Location = new System.Drawing.Point(4, 40);
            this.IdentificationTab.Name = "IdentificationTab";
            this.IdentificationTab.Size = new System.Drawing.Size(581, 481);
            this.IdentificationTab.TabIndex = 2;
            this.IdentificationTab.Text = "Ταυτοποίηση";
            this.IdentificationTab.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ID_ResourceTypeComboBox);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.ID_ResourceAbstractTextBox);
            this.groupBox1.Controls.Add(this.ID_ResourseTitleTextBox);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(65, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(465, 164);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "Τίτλος πόρου";
            // 
            // ID_ResourceTypeComboBox
            // 
            this.ID_ResourceTypeComboBox.Items.AddRange(new object[] {
            "Σύνολο χωρικών δεδομένων",
            "Σειρά συνόλων χωρικών δεδομένων",
            "Υπηρεσίες χωρικών δεδομένων"});
            this.ID_ResourceTypeComboBox.Location = new System.Drawing.Point(51, 139);
            this.ID_ResourceTypeComboBox.Name = "ID_ResourceTypeComboBox";
            this.ID_ResourceTypeComboBox.Size = new System.Drawing.Size(326, 21);
            this.ID_ResourceTypeComboBox.TabIndex = 22;
            this.ID_ResourceTypeComboBox.Text = "Παρακαλώ επιλέξτε";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(6, 123);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 16);
            this.label8.TabIndex = 21;
            this.label8.Text = "Τύπος πόρου";
            // 
            // ID_ResourceAbstractTextBox
            // 
            this.ID_ResourceAbstractTextBox.Location = new System.Drawing.Point(51, 72);
            this.ID_ResourceAbstractTextBox.Multiline = true;
            this.ID_ResourceAbstractTextBox.Name = "ID_ResourceAbstractTextBox";
            this.ID_ResourceAbstractTextBox.Size = new System.Drawing.Size(326, 48);
            this.ID_ResourceAbstractTextBox.TabIndex = 20;
            // 
            // ID_ResourseTitleTextBox
            // 
            this.ID_ResourseTitleTextBox.Location = new System.Drawing.Point(51, 33);
            this.ID_ResourseTitleTextBox.Name = "ID_ResourseTitleTextBox";
            this.ID_ResourseTitleTextBox.Size = new System.Drawing.Size(326, 20);
            this.ID_ResourseTitleTextBox.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(6, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 16);
            this.label7.TabIndex = 19;
            this.label7.Text = "Σύνοψη πόρου";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.ID_ResourceLanguageListBox);
            this.groupBox9.Controls.Add(this.ID_ResourceLanguageComboBox);
            this.groupBox9.Controls.Add(this.ID_ResourceLanguageAddButton);
            this.groupBox9.Controls.Add(this.ID_ResourceLanguageRemoveButton);
            this.groupBox9.Location = new System.Drawing.Point(63, 376);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(467, 97);
            this.groupBox9.TabIndex = 43;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Γλώσσα πόρου";
            // 
            // ID_ResourceLanguageListBox
            // 
            this.ID_ResourceLanguageListBox.Location = new System.Drawing.Point(53, 49);
            this.ID_ResourceLanguageListBox.Name = "ID_ResourceLanguageListBox";
            this.ID_ResourceLanguageListBox.Size = new System.Drawing.Size(326, 43);
            this.ID_ResourceLanguageListBox.TabIndex = 38;
            // 
            // ID_ResourceLanguageComboBox
            // 
            this.ID_ResourceLanguageComboBox.Items.AddRange(new object[] {
            "Αγγλικά",
            "Γαλικά",
            "Γερμανικά",
            "Ελληνικά",
            "Ιταλικά"});
            this.ID_ResourceLanguageComboBox.Location = new System.Drawing.Point(53, 22);
            this.ID_ResourceLanguageComboBox.Name = "ID_ResourceLanguageComboBox";
            this.ID_ResourceLanguageComboBox.Size = new System.Drawing.Size(326, 21);
            this.ID_ResourceLanguageComboBox.TabIndex = 24;
            this.ID_ResourceLanguageComboBox.Text = "Παρακαλώ επιλέξτε";
            // 
            // ID_ResourceLanguageAddButton
            // 
            this.ID_ResourceLanguageAddButton.Location = new System.Drawing.Point(385, 19);
            this.ID_ResourceLanguageAddButton.Name = "ID_ResourceLanguageAddButton";
            this.ID_ResourceLanguageAddButton.Size = new System.Drawing.Size(67, 24);
            this.ID_ResourceLanguageAddButton.TabIndex = 39;
            this.ID_ResourceLanguageAddButton.Text = "Προσθήκη";
            this.ID_ResourceLanguageAddButton.Click += new System.EventHandler(this.ID_ResourceLanguageAddButton_Click);
            // 
            // ID_ResourceLanguageRemoveButton
            // 
            this.ID_ResourceLanguageRemoveButton.Location = new System.Drawing.Point(385, 59);
            this.ID_ResourceLanguageRemoveButton.Name = "ID_ResourceLanguageRemoveButton";
            this.ID_ResourceLanguageRemoveButton.Size = new System.Drawing.Size(67, 24);
            this.ID_ResourceLanguageRemoveButton.TabIndex = 40;
            this.ID_ResourceLanguageRemoveButton.Text = "Διαγραφή";
            this.ID_ResourceLanguageRemoveButton.Click += new System.EventHandler(this.ID_ResourceLanguageRemoveButton_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.GUIDButton);
            this.groupBox8.Controls.Add(this.ID_CodeTextBox);
            this.groupBox8.Controls.Add(this.ID_UIDListBox);
            this.groupBox8.Controls.Add(this.ID_UIDAddButton);
            this.groupBox8.Controls.Add(this.ID_UIDRemoveButton);
            this.groupBox8.Controls.Add(this.ID_NamespaceTextBox);
            this.groupBox8.Controls.Add(this.label66);
            this.groupBox8.Controls.Add(this.label65);
            this.groupBox8.Location = new System.Drawing.Point(63, 260);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(467, 114);
            this.groupBox8.TabIndex = 42;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Μοναδικό αναγνωριστικό πόρου";
            // 
            // GUIDButton
            // 
            this.GUIDButton.Location = new System.Drawing.Point(366, 45);
            this.GUIDButton.Name = "GUIDButton";
            this.GUIDButton.Size = new System.Drawing.Size(95, 36);
            this.GUIDButton.TabIndex = 38;
            this.GUIDButton.Text = "Νέο αναγνωριστικό";
            this.GUIDButton.Click += new System.EventHandler(this.GUIDButton_Click);
            // 
            // ID_CodeTextBox
            // 
            this.ID_CodeTextBox.Location = new System.Drawing.Point(112, 19);
            this.ID_CodeTextBox.Name = "ID_CodeTextBox";
            this.ID_CodeTextBox.Size = new System.Drawing.Size(248, 20);
            this.ID_CodeTextBox.TabIndex = 30;
            // 
            // ID_UIDListBox
            // 
            this.ID_UIDListBox.Location = new System.Drawing.Point(53, 67);
            this.ID_UIDListBox.Name = "ID_UIDListBox";
            this.ID_UIDListBox.Size = new System.Drawing.Size(307, 43);
            this.ID_UIDListBox.TabIndex = 32;
            // 
            // ID_UIDAddButton
            // 
            this.ID_UIDAddButton.Location = new System.Drawing.Point(366, 16);
            this.ID_UIDAddButton.Name = "ID_UIDAddButton";
            this.ID_UIDAddButton.Size = new System.Drawing.Size(95, 24);
            this.ID_UIDAddButton.TabIndex = 33;
            this.ID_UIDAddButton.Text = "Προσθήκη";
            this.ID_UIDAddButton.Click += new System.EventHandler(this.ID_UIDAddButton_Click);
            // 
            // ID_UIDRemoveButton
            // 
            this.ID_UIDRemoveButton.Location = new System.Drawing.Point(366, 84);
            this.ID_UIDRemoveButton.Name = "ID_UIDRemoveButton";
            this.ID_UIDRemoveButton.Size = new System.Drawing.Size(95, 24);
            this.ID_UIDRemoveButton.TabIndex = 34;
            this.ID_UIDRemoveButton.Text = "Διαγραφή";
            this.ID_UIDRemoveButton.Click += new System.EventHandler(this.ID_UIDRemoveButton_Click);
            // 
            // ID_NamespaceTextBox
            // 
            this.ID_NamespaceTextBox.Location = new System.Drawing.Point(112, 45);
            this.ID_NamespaceTextBox.Name = "ID_NamespaceTextBox";
            this.ID_NamespaceTextBox.Size = new System.Drawing.Size(248, 20);
            this.ID_NamespaceTextBox.TabIndex = 35;
            // 
            // label66
            // 
            this.label66.Location = new System.Drawing.Point(8, 48);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(98, 16);
            this.label66.TabIndex = 37;
            this.label66.Text = "Χώρος ονομάτων";
            // 
            // label65
            // 
            this.label65.Location = new System.Drawing.Point(8, 22);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(98, 16);
            this.label65.TabIndex = 36;
            this.label65.Text = "Αναγνωριστικό";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.ID_ResourceLocatorTextBox);
            this.groupBox7.Controls.Add(this.ID_ResourceLocatorListBox);
            this.groupBox7.Controls.Add(this.ID_ResourceLocatorAddButton);
            this.groupBox7.Controls.Add(this.ID_ResourceLocatorRemoveButton);
            this.groupBox7.Location = new System.Drawing.Point(63, 166);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(467, 92);
            this.groupBox7.TabIndex = 41;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Εντοπιστής πόρου";
            // 
            // ID_ResourceLocatorTextBox
            // 
            this.ID_ResourceLocatorTextBox.Location = new System.Drawing.Point(53, 19);
            this.ID_ResourceLocatorTextBox.Name = "ID_ResourceLocatorTextBox";
            this.ID_ResourceLocatorTextBox.Size = new System.Drawing.Size(326, 20);
            this.ID_ResourceLocatorTextBox.TabIndex = 25;
            // 
            // ID_ResourceLocatorListBox
            // 
            this.ID_ResourceLocatorListBox.Location = new System.Drawing.Point(53, 45);
            this.ID_ResourceLocatorListBox.Name = "ID_ResourceLocatorListBox";
            this.ID_ResourceLocatorListBox.Size = new System.Drawing.Size(326, 43);
            this.ID_ResourceLocatorListBox.TabIndex = 27;
            // 
            // ID_ResourceLocatorAddButton
            // 
            this.ID_ResourceLocatorAddButton.Location = new System.Drawing.Point(385, 16);
            this.ID_ResourceLocatorAddButton.Name = "ID_ResourceLocatorAddButton";
            this.ID_ResourceLocatorAddButton.Size = new System.Drawing.Size(67, 24);
            this.ID_ResourceLocatorAddButton.TabIndex = 28;
            this.ID_ResourceLocatorAddButton.Text = "Προσθήκη";
            this.ID_ResourceLocatorAddButton.Click += new System.EventHandler(this.ID_ResourceLocatorAddButton_Click);
            // 
            // ID_ResourceLocatorRemoveButton
            // 
            this.ID_ResourceLocatorRemoveButton.Location = new System.Drawing.Point(385, 55);
            this.ID_ResourceLocatorRemoveButton.Name = "ID_ResourceLocatorRemoveButton";
            this.ID_ResourceLocatorRemoveButton.Size = new System.Drawing.Size(67, 24);
            this.ID_ResourceLocatorRemoveButton.TabIndex = 29;
            this.ID_ResourceLocatorRemoveButton.Text = "Διαγραφή";
            this.ID_ResourceLocatorRemoveButton.Click += new System.EventHandler(this.ID_ResourceLocatorRemoveButton_Click);
            // 
            // ClassificationTab
            // 
            this.ClassificationTab.Controls.Add(this.CL_GroupBox);
            this.ClassificationTab.Location = new System.Drawing.Point(4, 40);
            this.ClassificationTab.Name = "ClassificationTab";
            this.ClassificationTab.Size = new System.Drawing.Size(581, 481);
            this.ClassificationTab.TabIndex = 3;
            this.ClassificationTab.Text = "Κατηγοριοποίηση";
            this.ClassificationTab.UseVisualStyleBackColor = true;
            // 
            // CL_GroupBox
            // 
            this.CL_GroupBox.Controls.Add(this.CL_RemoveTopicCategoryButton);
            this.CL_GroupBox.Controls.Add(this.CL_TopicCategoryListBox);
            this.CL_GroupBox.Controls.Add(this.CL_AddTopicCategoryButton);
            this.CL_GroupBox.Controls.Add(this.CL_TopicCategoryComboBox);
            this.CL_GroupBox.Location = new System.Drawing.Point(63, 13);
            this.CL_GroupBox.Name = "CL_GroupBox";
            this.CL_GroupBox.Size = new System.Drawing.Size(467, 127);
            this.CL_GroupBox.TabIndex = 16;
            this.CL_GroupBox.TabStop = false;
            this.CL_GroupBox.Text = "Θεματική κατηγορία";
            // 
            // CL_RemoveTopicCategoryButton
            // 
            this.CL_RemoveTopicCategoryButton.Location = new System.Drawing.Point(385, 62);
            this.CL_RemoveTopicCategoryButton.Name = "CL_RemoveTopicCategoryButton";
            this.CL_RemoveTopicCategoryButton.Size = new System.Drawing.Size(67, 24);
            this.CL_RemoveTopicCategoryButton.TabIndex = 29;
            this.CL_RemoveTopicCategoryButton.Text = "Διαγραφή";
            this.CL_RemoveTopicCategoryButton.Click += new System.EventHandler(this.CL_RemoveTopicCategoryButton_Click);
            // 
            // CL_TopicCategoryListBox
            // 
            this.CL_TopicCategoryListBox.Location = new System.Drawing.Point(53, 46);
            this.CL_TopicCategoryListBox.Name = "CL_TopicCategoryListBox";
            this.CL_TopicCategoryListBox.Size = new System.Drawing.Size(326, 56);
            this.CL_TopicCategoryListBox.TabIndex = 28;
            // 
            // CL_AddTopicCategoryButton
            // 
            this.CL_AddTopicCategoryButton.Location = new System.Drawing.Point(385, 16);
            this.CL_AddTopicCategoryButton.Name = "CL_AddTopicCategoryButton";
            this.CL_AddTopicCategoryButton.Size = new System.Drawing.Size(67, 24);
            this.CL_AddTopicCategoryButton.TabIndex = 27;
            this.CL_AddTopicCategoryButton.Text = "Προσθήκη";
            this.CL_AddTopicCategoryButton.Click += new System.EventHandler(this.CL_AddTopicCategoryButton_Click);
            // 
            // CL_TopicCategoryComboBox
            // 
            this.CL_TopicCategoryComboBox.Items.AddRange(new object[] {
            "Γεωργία",
            "Βιόκοσμος",
            "Όρια",
            "Κλιματολογία/Μετεωρολογία/Ατμόσφαιρα",
            "Οικονομία",
            "Υψομετρία",
            "Περιβάλλον",
            "Γεωεπιστημονικές πληροφορίες",
            "Υγεία",
            "Ορθοεικόνες/Βασικοίχάρτες/Κάλυψη γης",
            "Στρατιωτικές πληροφορίες",
            "Εσωτερικά ύδατα",
            "Γεωγραφική θέση",
            "Θάλασσες",
            "Χωροταξία/κτηματολόγιο",
            "Κοινωνία",
            "Κατασκευές",
            "Μεταφορές",
            "Επιχειρήσεις κοινής ωφελείας/Επικοινωνία"});
            this.CL_TopicCategoryComboBox.Location = new System.Drawing.Point(53, 19);
            this.CL_TopicCategoryComboBox.Name = "CL_TopicCategoryComboBox";
            this.CL_TopicCategoryComboBox.Size = new System.Drawing.Size(326, 21);
            this.CL_TopicCategoryComboBox.TabIndex = 26;
            this.CL_TopicCategoryComboBox.Text = "Παρακαλώ επιλέξτε";
            // 
            // KeywordTab
            // 
            this.KeywordTab.Controls.Add(this.KeywordGroupBox);
            this.KeywordTab.Location = new System.Drawing.Point(4, 40);
            this.KeywordTab.Name = "KeywordTab";
            this.KeywordTab.Size = new System.Drawing.Size(581, 481);
            this.KeywordTab.TabIndex = 1;
            this.KeywordTab.Text = "Λέξη κλειδί";
            this.KeywordTab.UseVisualStyleBackColor = true;
            // 
            // KeywordGroupBox
            // 
            this.KeywordGroupBox.Controls.Add(this.label17);
            this.KeywordGroupBox.Controls.Add(this.groupBox2);
            this.KeywordGroupBox.Controls.Add(this.KW_AddInspireButton);
            this.KeywordGroupBox.Controls.Add(this.label9);
            this.KeywordGroupBox.Controls.Add(this.KW_InspireComboBox);
            this.KeywordGroupBox.Controls.Add(this.KW_KeywordRemoveButton);
            this.KeywordGroupBox.Controls.Add(this.KW_KeywordListBox);
            this.KeywordGroupBox.Location = new System.Drawing.Point(63, 13);
            this.KeywordGroupBox.Name = "KeywordGroupBox";
            this.KeywordGroupBox.Size = new System.Drawing.Size(467, 293);
            this.KeywordGroupBox.TabIndex = 31;
            this.KeywordGroupBox.TabStop = false;
            this.KeywordGroupBox.Text = "Λέξη κλειδί";
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(6, 202);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(137, 16);
            this.label17.TabIndex = 35;
            this.label17.Text = "Λίστα λέξεων κλειδιών";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.KW_DateTimePicker);
            this.groupBox2.Controls.Add(this.KW_DateTypeComboBox);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.KW_VocabularyTextBox);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.KW_KeywordTextBox);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.KW_KeywordAddButton);
            this.groupBox2.Location = new System.Drawing.Point(7, 65);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(454, 134);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            // 
            // KW_DateTimePicker
            // 
            this.KW_DateTimePicker.CustomFormat = "yyyy-MM-dd";
            this.KW_DateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.KW_DateTimePicker.Location = new System.Drawing.Point(213, 105);
            this.KW_DateTimePicker.Name = "KW_DateTimePicker";
            this.KW_DateTimePicker.Size = new System.Drawing.Size(162, 20);
            this.KW_DateTimePicker.TabIndex = 45;
            // 
            // KW_DateTypeComboBox
            // 
            this.KW_DateTypeComboBox.Items.AddRange(new object[] {
            "δημιουργία",
            "δημοσίευση",
            "αναθεώρηση"});
            this.KW_DateTypeComboBox.Location = new System.Drawing.Point(49, 105);
            this.KW_DateTypeComboBox.Name = "KW_DateTypeComboBox";
            this.KW_DateTypeComboBox.Size = new System.Drawing.Size(158, 21);
            this.KW_DateTypeComboBox.TabIndex = 44;
            this.KW_DateTypeComboBox.Text = "Παρακαλώ επιλέξτε";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(6, 91);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(130, 16);
            this.label10.TabIndex = 43;
            this.label10.Text = "Ημερομηνία αναφοράς";
            // 
            // KW_VocabularyTextBox
            // 
            this.KW_VocabularyTextBox.Location = new System.Drawing.Point(49, 69);
            this.KW_VocabularyTextBox.Name = "KW_VocabularyTextBox";
            this.KW_VocabularyTextBox.Size = new System.Drawing.Size(326, 20);
            this.KW_VocabularyTextBox.TabIndex = 42;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(6, 51);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(184, 16);
            this.label16.TabIndex = 41;
            this.label16.Text = "Ελεγχόμενο λεξιλόγιο προέλευσης";
            // 
            // KW_KeywordTextBox
            // 
            this.KW_KeywordTextBox.Location = new System.Drawing.Point(49, 28);
            this.KW_KeywordTextBox.Name = "KW_KeywordTextBox";
            this.KW_KeywordTextBox.Size = new System.Drawing.Size(326, 20);
            this.KW_KeywordTextBox.TabIndex = 30;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(2, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(119, 16);
            this.label11.TabIndex = 25;
            this.label11.Text = "Τιμή της λέξης κλειδί";
            // 
            // KW_KeywordAddButton
            // 
            this.KW_KeywordAddButton.Location = new System.Drawing.Point(381, 66);
            this.KW_KeywordAddButton.Name = "KW_KeywordAddButton";
            this.KW_KeywordAddButton.Size = new System.Drawing.Size(67, 24);
            this.KW_KeywordAddButton.TabIndex = 27;
            this.KW_KeywordAddButton.Text = "Προσθήκη";
            this.KW_KeywordAddButton.Click += new System.EventHandler(this.KW_KeywordAddButton_Click);
            // 
            // KW_AddInspireButton
            // 
            this.KW_AddInspireButton.Location = new System.Drawing.Point(388, 32);
            this.KW_AddInspireButton.Name = "KW_AddInspireButton";
            this.KW_AddInspireButton.Size = new System.Drawing.Size(67, 24);
            this.KW_AddInspireButton.TabIndex = 33;
            this.KW_AddInspireButton.Text = "Προσθήκη";
            this.KW_AddInspireButton.Click += new System.EventHandler(this.KW_AddInspireButton_Click);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(6, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(137, 16);
            this.label9.TabIndex = 32;
            this.label9.Text = "Θέμα δεδομένων Inspire";
            // 
            // KW_InspireComboBox
            // 
            this.KW_InspireComboBox.Items.AddRange(new object[] {
            "Ανθρώπινη υγεία και ασφάλεια",
            "Ατμοσφαιρικές συνθήκες",
            "Βιογεωγραφικές περιοχές",
            "Γεωλογία",
            "Γεωργικές εγκαταστάσεις και εγκαταστάσεις υδατοκαλλιέργειας",
            "Γεωτεμάχια κτηματολογίου",
            "Διευθύνσεις",
            "Δίκτυα μεταφορών",
            "Διοικητικές ενότητες",
            "Εγκαταστάσεις παραγωγής και βιομηχανικές εγκαταστάσεις",
            "Εγκαταστάσεις παρακολούθησης του περιβάλλοντος",
            "Έδαφος",
            "Ενδιαιτήματα και βιότοποι",
            "Ενεργειακοί πόροι",
            "Επιχειρήσεις κοινής ωφελείας και κρατικές υπηρεσίες",
            "Ζώνες διαχείρισης/περιορισμού/ρύθμισης εκτάσεων και μονάδες αναφοράς",
            "Ζώνες φυσικών κινδύνων",
            "Θαλάσσιες περιοχές",
            "Κάλυψη γης",
            "Κατανομή ειδών",
            "Κατανομή πληθυσμού  δημογραφία",
            "Κτίρια",
            "Μετεωρολογικά γεωγραφικά χαρακτηριστικά",
            "Ορθοφωτογραφία",
            "Ορυκτοί πόροι",
            "Προστατευόμενες τοποθεσίες",
            "Στατιστικές μονάδες",
            "Συστήματα γεωγραφικού καννάβου",
            "Συστήματα συντεταγμένων",
            "Τοπωνύμια",
            "Υδρογραφία",
            "Υψομετρία",
            "Χρήσεις γης",
            "Ωκεανογραφικά γεωγραφικά χαρακτηριστικά"});
            this.KW_InspireComboBox.Location = new System.Drawing.Point(56, 35);
            this.KW_InspireComboBox.Name = "KW_InspireComboBox";
            this.KW_InspireComboBox.Size = new System.Drawing.Size(326, 21);
            this.KW_InspireComboBox.TabIndex = 31;
            this.KW_InspireComboBox.Text = "Παρακαλώ επιλέξτε";
            // 
            // KW_KeywordRemoveButton
            // 
            this.KW_KeywordRemoveButton.Location = new System.Drawing.Point(388, 235);
            this.KW_KeywordRemoveButton.Name = "KW_KeywordRemoveButton";
            this.KW_KeywordRemoveButton.Size = new System.Drawing.Size(67, 24);
            this.KW_KeywordRemoveButton.TabIndex = 29;
            this.KW_KeywordRemoveButton.Text = "Διαγραφή";
            this.KW_KeywordRemoveButton.Click += new System.EventHandler(this.KW_KeywordRemoveButton_Click);
            // 
            // KW_KeywordListBox
            // 
            this.KW_KeywordListBox.Location = new System.Drawing.Point(6, 221);
            this.KW_KeywordListBox.Name = "KW_KeywordListBox";
            this.KW_KeywordListBox.Size = new System.Drawing.Size(376, 56);
            this.KW_KeywordListBox.TabIndex = 28;
            // 
            // GeographicTab
            // 
            this.GeographicTab.Controls.Add(this.SPT_GroupBox);
            this.GeographicTab.Location = new System.Drawing.Point(4, 40);
            this.GeographicTab.Name = "GeographicTab";
            this.GeographicTab.Size = new System.Drawing.Size(581, 481);
            this.GeographicTab.TabIndex = 4;
            this.GeographicTab.Text = "Γεωγραφική θέση";
            this.GeographicTab.UseVisualStyleBackColor = true;
            // 
            // SPT_GroupBox
            // 
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
            this.SPT_GroupBox.Location = new System.Drawing.Point(63, 13);
            this.SPT_GroupBox.Name = "SPT_GroupBox";
            this.SPT_GroupBox.Size = new System.Drawing.Size(467, 229);
            this.SPT_GroupBox.TabIndex = 29;
            this.SPT_GroupBox.TabStop = false;
            this.SPT_GroupBox.Text = "Περίγραμμα γεωγραφικών συντεταγμένων";
            // 
            // GEO_RemoveExtendButton
            // 
            this.GEO_RemoveExtendButton.Location = new System.Drawing.Point(382, 183);
            this.GEO_RemoveExtendButton.Name = "GEO_RemoveExtendButton";
            this.GEO_RemoveExtendButton.Size = new System.Drawing.Size(67, 24);
            this.GEO_RemoveExtendButton.TabIndex = 46;
            this.GEO_RemoveExtendButton.Text = "Διαγραφή";
            this.GEO_RemoveExtendButton.Click += new System.EventHandler(this.GEO_RemoveExtendButton_Click);
            // 
            // GEO_ExtendListBox
            // 
            this.GEO_ExtendListBox.Location = new System.Drawing.Point(50, 167);
            this.GEO_ExtendListBox.Name = "GEO_ExtendListBox";
            this.GEO_ExtendListBox.Size = new System.Drawing.Size(326, 56);
            this.GEO_ExtendListBox.TabIndex = 45;
            // 
            // GEO_AddExtendButton
            // 
            this.GEO_AddExtendButton.Location = new System.Drawing.Point(382, 77);
            this.GEO_AddExtendButton.Name = "GEO_AddExtendButton";
            this.GEO_AddExtendButton.Size = new System.Drawing.Size(67, 24);
            this.GEO_AddExtendButton.TabIndex = 44;
            this.GEO_AddExtendButton.Text = "Προσθήκη";
            this.GEO_AddExtendButton.Click += new System.EventHandler(this.GEO_AddExtendButton_Click);
            // 
            // label61
            // 
            this.label61.Location = new System.Drawing.Point(218, 64);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(158, 16);
            this.label61.TabIndex = 43;
            this.label61.Text = "Ανατολικό γεωγραφικό μήκος";
            this.label61.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // GEO_XmaxTextBox
            // 
            this.GEO_XmaxTextBox.Location = new System.Drawing.Point(252, 80);
            this.GEO_XmaxTextBox.Name = "GEO_XmaxTextBox";
            this.GEO_XmaxTextBox.Size = new System.Drawing.Size(76, 20);
            this.GEO_XmaxTextBox.TabIndex = 42;
            // 
            // label60
            // 
            this.label60.Location = new System.Drawing.Point(47, 64);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(140, 16);
            this.label60.TabIndex = 41;
            this.label60.Text = "Δυτικό γεωγραφικό μήκος";
            this.label60.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // GEO_XminTextBox
            // 
            this.GEO_XminTextBox.Location = new System.Drawing.Point(84, 80);
            this.GEO_XminTextBox.Name = "GEO_XminTextBox";
            this.GEO_XminTextBox.Size = new System.Drawing.Size(76, 20);
            this.GEO_XminTextBox.TabIndex = 40;
            // 
            // label59
            // 
            this.label59.Location = new System.Drawing.Point(131, 109);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(145, 16);
            this.label59.TabIndex = 39;
            this.label59.Text = "Νότιο γεωγραφικό πλάτος";
            this.label59.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // GEO_YminTextBox
            // 
            this.GEO_YminTextBox.Location = new System.Drawing.Point(164, 128);
            this.GEO_YminTextBox.Name = "GEO_YminTextBox";
            this.GEO_YminTextBox.Size = new System.Drawing.Size(76, 20);
            this.GEO_YminTextBox.TabIndex = 38;
            // 
            // label58
            // 
            this.label58.Location = new System.Drawing.Point(131, 16);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(147, 16);
            this.label58.TabIndex = 37;
            this.label58.Text = "Βόρειο γεωγραφικό πλάτος";
            this.label58.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // GEO_YmaxTextBox
            // 
            this.GEO_YmaxTextBox.Location = new System.Drawing.Point(164, 32);
            this.GEO_YmaxTextBox.Name = "GEO_YmaxTextBox";
            this.GEO_YmaxTextBox.Size = new System.Drawing.Size(76, 20);
            this.GEO_YmaxTextBox.TabIndex = 34;
            // 
            // TemporalTab
            // 
            this.TemporalTab.Controls.Add(this.TMP_GroupBox);
            this.TemporalTab.Location = new System.Drawing.Point(4, 40);
            this.TemporalTab.Name = "TemporalTab";
            this.TemporalTab.Size = new System.Drawing.Size(581, 481);
            this.TemporalTab.TabIndex = 5;
            this.TemporalTab.Text = "Χρονική Αναφορά";
            this.TemporalTab.UseVisualStyleBackColor = true;
            // 
            // TMP_GroupBox
            // 
            this.TMP_GroupBox.Controls.Add(this.groupBox11);
            this.TMP_GroupBox.Controls.Add(this.groupBox10);
            this.TMP_GroupBox.Controls.Add(this.groupBox5);
            this.TMP_GroupBox.Controls.Add(this.groupBox4);
            this.TMP_GroupBox.Location = new System.Drawing.Point(63, 13);
            this.TMP_GroupBox.Name = "TMP_GroupBox";
            this.TMP_GroupBox.Size = new System.Drawing.Size(471, 447);
            this.TMP_GroupBox.TabIndex = 32;
            this.TMP_GroupBox.TabStop = false;
            this.TMP_GroupBox.Text = "Χρονική αναφορά";
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.label14);
            this.groupBox11.Controls.Add(this.TMP_ToDateTimePicker);
            this.groupBox11.Controls.Add(this.label13);
            this.groupBox11.Controls.Add(this.TMP_FromDateTimePicker);
            this.groupBox11.Controls.Add(this.TMP_RemoveExtendButton);
            this.groupBox11.Controls.Add(this.TMP_TemporalExtendListBox);
            this.groupBox11.Controls.Add(this.TMP_AddExtendButton);
            this.groupBox11.Location = new System.Drawing.Point(6, 16);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(460, 131);
            this.groupBox11.TabIndex = 57;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Χρονική έκταση";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(47, 52);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(32, 16);
            this.label14.TabIndex = 33;
            this.label14.Text = "Έως";
            // 
            // TMP_ToDateTimePicker
            // 
            this.TMP_ToDateTimePicker.CustomFormat = "yyyy-MM-dd";
            this.TMP_ToDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TMP_ToDateTimePicker.Location = new System.Drawing.Point(119, 48);
            this.TMP_ToDateTimePicker.Name = "TMP_ToDateTimePicker";
            this.TMP_ToDateTimePicker.Size = new System.Drawing.Size(256, 20);
            this.TMP_ToDateTimePicker.TabIndex = 32;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(47, 28);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 16);
            this.label13.TabIndex = 31;
            this.label13.Text = "Από";
            // 
            // TMP_FromDateTimePicker
            // 
            this.TMP_FromDateTimePicker.CustomFormat = "yyyy-MM-dd";
            this.TMP_FromDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TMP_FromDateTimePicker.Location = new System.Drawing.Point(120, 24);
            this.TMP_FromDateTimePicker.Name = "TMP_FromDateTimePicker";
            this.TMP_FromDateTimePicker.Size = new System.Drawing.Size(255, 20);
            this.TMP_FromDateTimePicker.TabIndex = 30;
            // 
            // TMP_RemoveExtendButton
            // 
            this.TMP_RemoveExtendButton.Location = new System.Drawing.Point(387, 84);
            this.TMP_RemoveExtendButton.Name = "TMP_RemoveExtendButton";
            this.TMP_RemoveExtendButton.Size = new System.Drawing.Size(67, 24);
            this.TMP_RemoveExtendButton.TabIndex = 29;
            this.TMP_RemoveExtendButton.Text = "Διαγραφή";
            this.TMP_RemoveExtendButton.Click += new System.EventHandler(this.TMP_RemoveExtendButton_Click);
            // 
            // TMP_TemporalExtendListBox
            // 
            this.TMP_TemporalExtendListBox.Location = new System.Drawing.Point(49, 72);
            this.TMP_TemporalExtendListBox.Name = "TMP_TemporalExtendListBox";
            this.TMP_TemporalExtendListBox.Size = new System.Drawing.Size(326, 56);
            this.TMP_TemporalExtendListBox.TabIndex = 28;
            // 
            // TMP_AddExtendButton
            // 
            this.TMP_AddExtendButton.Location = new System.Drawing.Point(387, 40);
            this.TMP_AddExtendButton.Name = "TMP_AddExtendButton";
            this.TMP_AddExtendButton.Size = new System.Drawing.Size(67, 24);
            this.TMP_AddExtendButton.TabIndex = 27;
            this.TMP_AddExtendButton.Text = "Προσθήκη";
            this.TMP_AddExtendButton.Click += new System.EventHandler(this.TMP_AddExtendButton_Click);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.TMP_RemoveCreationDateButton);
            this.groupBox10.Controls.Add(this.TMP_AddCreationDateButton);
            this.groupBox10.Controls.Add(this.TMP_CreationDateListBox);
            this.groupBox10.Controls.Add(this.TMP_CreationDateTimePicker);
            this.groupBox10.Controls.Add(this.label31);
            this.groupBox10.Location = new System.Drawing.Point(6, 349);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(460, 75);
            this.groupBox10.TabIndex = 56;
            this.groupBox10.TabStop = false;
            // 
            // TMP_RemoveCreationDateButton
            // 
            this.TMP_RemoveCreationDateButton.Location = new System.Drawing.Point(387, 42);
            this.TMP_RemoveCreationDateButton.Name = "TMP_RemoveCreationDateButton";
            this.TMP_RemoveCreationDateButton.Size = new System.Drawing.Size(67, 24);
            this.TMP_RemoveCreationDateButton.TabIndex = 53;
            this.TMP_RemoveCreationDateButton.Text = "Διαγραφή";
            this.TMP_RemoveCreationDateButton.Click += new System.EventHandler(this.TMP_RemoveCreationDateButton_Click);
            // 
            // TMP_AddCreationDateButton
            // 
            this.TMP_AddCreationDateButton.Location = new System.Drawing.Point(387, 12);
            this.TMP_AddCreationDateButton.Name = "TMP_AddCreationDateButton";
            this.TMP_AddCreationDateButton.Size = new System.Drawing.Size(67, 24);
            this.TMP_AddCreationDateButton.TabIndex = 52;
            this.TMP_AddCreationDateButton.Text = "Προσθήκη";
            this.TMP_AddCreationDateButton.Click += new System.EventHandler(this.TMP_AddCreationDateButton_Click);
            // 
            // TMP_CreationDateListBox
            // 
            this.TMP_CreationDateListBox.Location = new System.Drawing.Point(49, 40);
            this.TMP_CreationDateListBox.Name = "TMP_CreationDateListBox";
            this.TMP_CreationDateListBox.Size = new System.Drawing.Size(326, 30);
            this.TMP_CreationDateListBox.TabIndex = 49;
            // 
            // TMP_CreationDateTimePicker
            // 
            this.TMP_CreationDateTimePicker.CustomFormat = "yyyy-MM-dd";
            this.TMP_CreationDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TMP_CreationDateTimePicker.Location = new System.Drawing.Point(145, 14);
            this.TMP_CreationDateTimePicker.Name = "TMP_CreationDateTimePicker";
            this.TMP_CreationDateTimePicker.Size = new System.Drawing.Size(230, 20);
            this.TMP_CreationDateTimePicker.TabIndex = 47;
            // 
            // label31
            // 
            this.label31.Location = new System.Drawing.Point(6, 18);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(130, 22);
            this.label31.TabIndex = 46;
            this.label31.Text = "Ημερομηνία δημιουργίας";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.TMP_RevisionDateTimePicker);
            this.groupBox5.Controls.Add(this.label30);
            this.groupBox5.Controls.Add(this.TMP_RevisionDateListBox);
            this.groupBox5.Controls.Add(this.TMP_AddRevisionDateButton);
            this.groupBox5.Controls.Add(this.TMP_RemoveRevisionDateButton);
            this.groupBox5.Location = new System.Drawing.Point(6, 262);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(460, 81);
            this.groupBox5.TabIndex = 55;
            this.groupBox5.TabStop = false;
            // 
            // TMP_RevisionDateTimePicker
            // 
            this.TMP_RevisionDateTimePicker.CustomFormat = "yyyy-MM-dd";
            this.TMP_RevisionDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TMP_RevisionDateTimePicker.Location = new System.Drawing.Point(145, 19);
            this.TMP_RevisionDateTimePicker.Name = "TMP_RevisionDateTimePicker";
            this.TMP_RevisionDateTimePicker.Size = new System.Drawing.Size(231, 20);
            this.TMP_RevisionDateTimePicker.TabIndex = 45;
            // 
            // label30
            // 
            this.label30.Location = new System.Drawing.Point(10, 16);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(129, 30);
            this.label30.TabIndex = 44;
            this.label30.Text = "Ημερομηνία τελευταίας αναθεώρησης";
            // 
            // TMP_RevisionDateListBox
            // 
            this.TMP_RevisionDateListBox.Location = new System.Drawing.Point(49, 45);
            this.TMP_RevisionDateListBox.Name = "TMP_RevisionDateListBox";
            this.TMP_RevisionDateListBox.Size = new System.Drawing.Size(326, 30);
            this.TMP_RevisionDateListBox.TabIndex = 48;
            // 
            // TMP_AddRevisionDateButton
            // 
            this.TMP_AddRevisionDateButton.Location = new System.Drawing.Point(388, 17);
            this.TMP_AddRevisionDateButton.Name = "TMP_AddRevisionDateButton";
            this.TMP_AddRevisionDateButton.Size = new System.Drawing.Size(67, 24);
            this.TMP_AddRevisionDateButton.TabIndex = 50;
            this.TMP_AddRevisionDateButton.Text = "Προσθήκη";
            this.TMP_AddRevisionDateButton.Click += new System.EventHandler(this.TMP_AddRevisionDateButton_Click);
            // 
            // TMP_RemoveRevisionDateButton
            // 
            this.TMP_RemoveRevisionDateButton.Location = new System.Drawing.Point(387, 47);
            this.TMP_RemoveRevisionDateButton.Name = "TMP_RemoveRevisionDateButton";
            this.TMP_RemoveRevisionDateButton.Size = new System.Drawing.Size(67, 24);
            this.TMP_RemoveRevisionDateButton.TabIndex = 51;
            this.TMP_RemoveRevisionDateButton.Text = "Διαγραφή";
            this.TMP_RemoveRevisionDateButton.Click += new System.EventHandler(this.TMP_RemoveRevisionDateButton_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.TMP_PublicTimePicker);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.TMP_AddDateButton);
            this.groupBox4.Controls.Add(this.TMP_PublicDateListBox);
            this.groupBox4.Controls.Add(this.TMP_RemoveDateButton);
            this.groupBox4.Location = new System.Drawing.Point(6, 145);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(460, 118);
            this.groupBox4.TabIndex = 54;
            this.groupBox4.TabStop = false;
            // 
            // TMP_PublicTimePicker
            // 
            this.TMP_PublicTimePicker.CustomFormat = "yyyy-MM-dd";
            this.TMP_PublicTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TMP_PublicTimePicker.Location = new System.Drawing.Point(145, 19);
            this.TMP_PublicTimePicker.Name = "TMP_PublicTimePicker";
            this.TMP_PublicTimePicker.Size = new System.Drawing.Size(231, 20);
            this.TMP_PublicTimePicker.TabIndex = 35;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(6, 23);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(140, 18);
            this.label15.TabIndex = 34;
            this.label15.Text = "Ημερομηνία δημοσίευσης";
            // 
            // TMP_AddDateButton
            // 
            this.TMP_AddDateButton.Location = new System.Drawing.Point(388, 17);
            this.TMP_AddDateButton.Name = "TMP_AddDateButton";
            this.TMP_AddDateButton.Size = new System.Drawing.Size(67, 24);
            this.TMP_AddDateButton.TabIndex = 41;
            this.TMP_AddDateButton.Text = "Προσθήκη";
            this.TMP_AddDateButton.Click += new System.EventHandler(this.TMP_AddDateButton_Click);
            // 
            // TMP_PublicDateListBox
            // 
            this.TMP_PublicDateListBox.Location = new System.Drawing.Point(50, 45);
            this.TMP_PublicDateListBox.Name = "TMP_PublicDateListBox";
            this.TMP_PublicDateListBox.Size = new System.Drawing.Size(326, 56);
            this.TMP_PublicDateListBox.TabIndex = 42;
            // 
            // TMP_RemoveDateButton
            // 
            this.TMP_RemoveDateButton.Location = new System.Drawing.Point(388, 58);
            this.TMP_RemoveDateButton.Name = "TMP_RemoveDateButton";
            this.TMP_RemoveDateButton.Size = new System.Drawing.Size(67, 24);
            this.TMP_RemoveDateButton.TabIndex = 43;
            this.TMP_RemoveDateButton.Text = "Διαγραφή";
            this.TMP_RemoveDateButton.Click += new System.EventHandler(this.TMP_RemoveDateButton_Click);
            // 
            // QualityValidityTab
            // 
            this.QualityValidityTab.Controls.Add(this.LineageGroupBox);
            this.QualityValidityTab.Controls.Add(this.QLT_GroupBox);
            this.QualityValidityTab.Location = new System.Drawing.Point(4, 40);
            this.QualityValidityTab.Name = "QualityValidityTab";
            this.QualityValidityTab.Size = new System.Drawing.Size(581, 481);
            this.QualityValidityTab.TabIndex = 6;
            this.QualityValidityTab.Text = "Ποιότητα και Εγκυρότητα";
            this.QualityValidityTab.UseVisualStyleBackColor = true;
            // 
            // LineageGroupBox
            // 
            this.LineageGroupBox.Controls.Add(this.LIN_FreeTextBox);
            this.LineageGroupBox.Location = new System.Drawing.Point(63, 259);
            this.LineageGroupBox.Name = "LineageGroupBox";
            this.LineageGroupBox.Size = new System.Drawing.Size(467, 140);
            this.LineageGroupBox.TabIndex = 27;
            this.LineageGroupBox.TabStop = false;
            this.LineageGroupBox.Text = "Καταγωγή";
            // 
            // LIN_FreeTextBox
            // 
            this.LIN_FreeTextBox.AcceptsReturn = true;
            this.LIN_FreeTextBox.Location = new System.Drawing.Point(6, 12);
            this.LIN_FreeTextBox.Multiline = true;
            this.LIN_FreeTextBox.Name = "LIN_FreeTextBox";
            this.LIN_FreeTextBox.Size = new System.Drawing.Size(455, 116);
            this.LIN_FreeTextBox.TabIndex = 20;
            // 
            // QLT_GroupBox
            // 
            this.QLT_GroupBox.Controls.Add(this.Spatial_GroupBox);
            this.QLT_GroupBox.Location = new System.Drawing.Point(63, 13);
            this.QLT_GroupBox.Name = "QLT_GroupBox";
            this.QLT_GroupBox.Size = new System.Drawing.Size(467, 240);
            this.QLT_GroupBox.TabIndex = 26;
            this.QLT_GroupBox.TabStop = false;
            this.QLT_GroupBox.Text = "Ποιότητα";
            // 
            // Spatial_GroupBox
            // 
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
            this.Spatial_GroupBox.Location = new System.Drawing.Point(8, 16);
            this.Spatial_GroupBox.Name = "Spatial_GroupBox";
            this.Spatial_GroupBox.Size = new System.Drawing.Size(453, 216);
            this.Spatial_GroupBox.TabIndex = 26;
            this.Spatial_GroupBox.TabStop = false;
            this.Spatial_GroupBox.Text = "Χωρική ανάλυση";
            // 
            // QLT_UnitsComboBox
            // 
            this.QLT_UnitsComboBox.Items.AddRange(new object[] {
            "Meter",
            "Centimeter",
            "Millimeter",
            "Kilometer",
            "Yard",
            "Foot",
            "Mile"});
            this.QLT_UnitsComboBox.Location = new System.Drawing.Point(48, 115);
            this.QLT_UnitsComboBox.Name = "QLT_UnitsComboBox";
            this.QLT_UnitsComboBox.Size = new System.Drawing.Size(326, 21);
            this.QLT_UnitsComboBox.TabIndex = 40;
            this.QLT_UnitsComboBox.Text = "Παρακαλώ επιλέξτε";
            // 
            // label29
            // 
            this.label29.Location = new System.Drawing.Point(23, 35);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(18, 16);
            this.label29.TabIndex = 39;
            this.label29.Text = "1/";
            // 
            // QLT_AddDistanceButton
            // 
            this.QLT_AddDistanceButton.Location = new System.Drawing.Point(380, 69);
            this.QLT_AddDistanceButton.Name = "QLT_AddDistanceButton";
            this.QLT_AddDistanceButton.Size = new System.Drawing.Size(67, 24);
            this.QLT_AddDistanceButton.TabIndex = 38;
            this.QLT_AddDistanceButton.Text = "Προσθήκη";
            this.QLT_AddDistanceButton.Click += new System.EventHandler(this.QLT_AddDistanceButton_Click);
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(8, 96);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(104, 16);
            this.label20.TabIndex = 36;
            this.label20.Text = "Μονάδα μέτρησης";
            // 
            // QLT_DistanceTextBox
            // 
            this.QLT_DistanceTextBox.Location = new System.Drawing.Point(48, 72);
            this.QLT_DistanceTextBox.Name = "QLT_DistanceTextBox";
            this.QLT_DistanceTextBox.Size = new System.Drawing.Size(326, 20);
            this.QLT_DistanceTextBox.TabIndex = 35;
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(8, 56);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(104, 16);
            this.label19.TabIndex = 34;
            this.label19.Text = "Απόσταση";
            // 
            // QLT_ScaleTextBox
            // 
            this.QLT_ScaleTextBox.Location = new System.Drawing.Point(48, 32);
            this.QLT_ScaleTextBox.Name = "QLT_ScaleTextBox";
            this.QLT_ScaleTextBox.Size = new System.Drawing.Size(326, 20);
            this.QLT_ScaleTextBox.TabIndex = 33;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(8, 16);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(104, 16);
            this.label18.TabIndex = 32;
            this.label18.Text = "Ισοδύναμη κλίμακα";
            // 
            // QLT_RemoveButton
            // 
            this.QLT_RemoveButton.Location = new System.Drawing.Point(380, 167);
            this.QLT_RemoveButton.Name = "QLT_RemoveButton";
            this.QLT_RemoveButton.Size = new System.Drawing.Size(67, 24);
            this.QLT_RemoveButton.TabIndex = 31;
            this.QLT_RemoveButton.Text = "Διαγραφή";
            this.QLT_RemoveButton.Click += new System.EventHandler(this.QLT_RemoveButton_Click);
            // 
            // QLT_AddScaleButton
            // 
            this.QLT_AddScaleButton.Location = new System.Drawing.Point(380, 29);
            this.QLT_AddScaleButton.Name = "QLT_AddScaleButton";
            this.QLT_AddScaleButton.Size = new System.Drawing.Size(67, 24);
            this.QLT_AddScaleButton.TabIndex = 30;
            this.QLT_AddScaleButton.Text = "Προσθήκη";
            this.QLT_AddScaleButton.Click += new System.EventHandler(this.QLT_AddScaleButton_Click);
            // 
            // QLT_ListBox
            // 
            this.QLT_ListBox.Location = new System.Drawing.Point(48, 152);
            this.QLT_ListBox.Name = "QLT_ListBox";
            this.QLT_ListBox.Size = new System.Drawing.Size(326, 56);
            this.QLT_ListBox.TabIndex = 29;
            // 
            // ConformityTab
            // 
            this.ConformityTab.Controls.Add(this.CFRM_GroupBox);
            this.ConformityTab.Location = new System.Drawing.Point(4, 40);
            this.ConformityTab.Name = "ConformityTab";
            this.ConformityTab.Size = new System.Drawing.Size(581, 481);
            this.ConformityTab.TabIndex = 7;
            this.ConformityTab.Text = "Συμμόρφωση";
            this.ConformityTab.UseVisualStyleBackColor = true;
            // 
            // CFRM_GroupBox
            // 
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
            this.CFRM_GroupBox.Location = new System.Drawing.Point(63, 13);
            this.CFRM_GroupBox.Name = "CFRM_GroupBox";
            this.CFRM_GroupBox.Size = new System.Drawing.Size(467, 216);
            this.CFRM_GroupBox.TabIndex = 28;
            this.CFRM_GroupBox.TabStop = false;
            this.CFRM_GroupBox.Text = "Συμμόρφωση";
            // 
            // CFRM_DegreeComboBox
            // 
            this.CFRM_DegreeComboBox.Items.AddRange(new object[] {
            "Σύμμορφος",
            "Δεν είναι σύμμορφος",
            "Δεν αξιολογήθηκε"});
            this.CFRM_DegreeComboBox.Location = new System.Drawing.Point(48, 112);
            this.CFRM_DegreeComboBox.Name = "CFRM_DegreeComboBox";
            this.CFRM_DegreeComboBox.Size = new System.Drawing.Size(174, 21);
            this.CFRM_DegreeComboBox.TabIndex = 41;
            this.CFRM_DegreeComboBox.Text = "Παρακαλώ επιλέξτε";
            // 
            // CFRM_DateTimePicker
            // 
            this.CFRM_DateTimePicker.CustomFormat = "yyyy-MM-dd";
            this.CFRM_DateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.CFRM_DateTimePicker.Location = new System.Drawing.Point(228, 73);
            this.CFRM_DateTimePicker.Name = "CFRM_DateTimePicker";
            this.CFRM_DateTimePicker.Size = new System.Drawing.Size(160, 20);
            this.CFRM_DateTimePicker.TabIndex = 40;
            // 
            // CFRM_DateTypeComboBox
            // 
            this.CFRM_DateTypeComboBox.Items.AddRange(new object[] {
            "δημιουργία",
            "δημοσίευση",
            "αναθεώρηση"});
            this.CFRM_DateTypeComboBox.Location = new System.Drawing.Point(48, 72);
            this.CFRM_DateTypeComboBox.Name = "CFRM_DateTypeComboBox";
            this.CFRM_DateTypeComboBox.Size = new System.Drawing.Size(174, 21);
            this.CFRM_DateTypeComboBox.TabIndex = 39;
            this.CFRM_DateTypeComboBox.Text = "Παρακαλώ επιλέξτε";
            // 
            // CFRM_AddButton
            // 
            this.CFRM_AddButton.Location = new System.Drawing.Point(394, 31);
            this.CFRM_AddButton.Name = "CFRM_AddButton";
            this.CFRM_AddButton.Size = new System.Drawing.Size(67, 24);
            this.CFRM_AddButton.TabIndex = 38;
            this.CFRM_AddButton.Text = "Προσθήκη";
            this.CFRM_AddButton.Click += new System.EventHandler(this.CFRM_AddButton_Click);
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(8, 96);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(130, 16);
            this.label21.TabIndex = 36;
            this.label21.Text = "Βαθμός συμμόρφωσης";
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(8, 56);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(130, 16);
            this.label22.TabIndex = 34;
            this.label22.Text = "Ημερομηνία αναφοράς";
            // 
            // CFRM_TitleTextBox
            // 
            this.CFRM_TitleTextBox.Location = new System.Drawing.Point(48, 34);
            this.CFRM_TitleTextBox.Name = "CFRM_TitleTextBox";
            this.CFRM_TitleTextBox.Size = new System.Drawing.Size(340, 20);
            this.CFRM_TitleTextBox.TabIndex = 33;
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(8, 16);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(104, 16);
            this.label23.TabIndex = 32;
            this.label23.Text = "Τίτλος αναφοράς";
            // 
            // CFRM_RemoveButton
            // 
            this.CFRM_RemoveButton.Location = new System.Drawing.Point(394, 159);
            this.CFRM_RemoveButton.Name = "CFRM_RemoveButton";
            this.CFRM_RemoveButton.Size = new System.Drawing.Size(67, 24);
            this.CFRM_RemoveButton.TabIndex = 31;
            this.CFRM_RemoveButton.Text = "Διαγραφή";
            this.CFRM_RemoveButton.Click += new System.EventHandler(this.CFRM_RemoveButton_Click);
            // 
            // CFRM_ListBox
            // 
            this.CFRM_ListBox.Location = new System.Drawing.Point(48, 144);
            this.CFRM_ListBox.Name = "CFRM_ListBox";
            this.CFRM_ListBox.Size = new System.Drawing.Size(340, 56);
            this.CFRM_ListBox.TabIndex = 29;
            // 
            // ConstraintsTab
            // 
            this.ConstraintsTab.Controls.Add(this.CSTR_GroupBox);
            this.ConstraintsTab.Location = new System.Drawing.Point(4, 40);
            this.ConstraintsTab.Name = "ConstraintsTab";
            this.ConstraintsTab.Size = new System.Drawing.Size(581, 481);
            this.ConstraintsTab.TabIndex = 8;
            this.ConstraintsTab.Text = "Περιορισμοί";
            this.ConstraintsTab.UseVisualStyleBackColor = true;
            // 
            // CSTR_GroupBox
            // 
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
            this.CSTR_GroupBox.Location = new System.Drawing.Point(63, 13);
            this.CSTR_GroupBox.Name = "CSTR_GroupBox";
            this.CSTR_GroupBox.Size = new System.Drawing.Size(467, 439);
            this.CSTR_GroupBox.TabIndex = 27;
            this.CSTR_GroupBox.TabStop = false;
            this.CSTR_GroupBox.Text = "Περιορισμοί σχετικά με την πρόσβαση και την χρήση";
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(45, 264);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(161, 16);
            this.label26.TabIndex = 53;
            this.label26.Text = "ή εισάγετε ελέυθερο κείμενο";
            // 
            // CSTR_RemoveConditionsUseGeneralButton
            // 
            this.CSTR_RemoveConditionsUseGeneralButton.Location = new System.Drawing.Point(392, 355);
            this.CSTR_RemoveConditionsUseGeneralButton.Name = "CSTR_RemoveConditionsUseGeneralButton";
            this.CSTR_RemoveConditionsUseGeneralButton.Size = new System.Drawing.Size(67, 24);
            this.CSTR_RemoveConditionsUseGeneralButton.TabIndex = 52;
            this.CSTR_RemoveConditionsUseGeneralButton.Text = "Διαγραφή";
            this.CSTR_RemoveConditionsUseGeneralButton.Click += new System.EventHandler(this.CSTR_RemoveConditionsUseGeneralButton_Click);
            // 
            // CSTR_ConditionsUseGeneralListBox
            // 
            this.CSTR_ConditionsUseGeneralListBox.Location = new System.Drawing.Point(46, 342);
            this.CSTR_ConditionsUseGeneralListBox.Name = "CSTR_ConditionsUseGeneralListBox";
            this.CSTR_ConditionsUseGeneralListBox.Size = new System.Drawing.Size(340, 56);
            this.CSTR_ConditionsUseGeneralListBox.TabIndex = 51;
            // 
            // CSTR_AddConditionsUseGeneralButton2
            // 
            this.CSTR_AddConditionsUseGeneralButton2.Location = new System.Drawing.Point(392, 297);
            this.CSTR_AddConditionsUseGeneralButton2.Name = "CSTR_AddConditionsUseGeneralButton2";
            this.CSTR_AddConditionsUseGeneralButton2.Size = new System.Drawing.Size(67, 24);
            this.CSTR_AddConditionsUseGeneralButton2.TabIndex = 50;
            this.CSTR_AddConditionsUseGeneralButton2.Text = "Προσθήκη";
            this.CSTR_AddConditionsUseGeneralButton2.Click += new System.EventHandler(this.CSTR_AddConditionsUseGeneralButton2_Click);
            // 
            // CSTR_ConditionsUseGeneralTextBox
            // 
            this.CSTR_ConditionsUseGeneralTextBox.AcceptsReturn = true;
            this.CSTR_ConditionsUseGeneralTextBox.Location = new System.Drawing.Point(46, 283);
            this.CSTR_ConditionsUseGeneralTextBox.Multiline = true;
            this.CSTR_ConditionsUseGeneralTextBox.Name = "CSTR_ConditionsUseGeneralTextBox";
            this.CSTR_ConditionsUseGeneralTextBox.Size = new System.Drawing.Size(340, 38);
            this.CSTR_ConditionsUseGeneralTextBox.TabIndex = 49;
            // 
            // CSTR_AddConditionsUseGeneralButton1
            // 
            this.CSTR_AddConditionsUseGeneralButton1.Location = new System.Drawing.Point(392, 236);
            this.CSTR_AddConditionsUseGeneralButton1.Name = "CSTR_AddConditionsUseGeneralButton1";
            this.CSTR_AddConditionsUseGeneralButton1.Size = new System.Drawing.Size(67, 24);
            this.CSTR_AddConditionsUseGeneralButton1.TabIndex = 48;
            this.CSTR_AddConditionsUseGeneralButton1.Text = "Προσθήκη";
            this.CSTR_AddConditionsUseGeneralButton1.Click += new System.EventHandler(this.CSTR_AddConditionsUseGeneralButton1_Click);
            // 
            // CSTR_RemoveLimitationsPublicButton
            // 
            this.CSTR_RemoveLimitationsPublicButton.Location = new System.Drawing.Point(394, 147);
            this.CSTR_RemoveLimitationsPublicButton.Name = "CSTR_RemoveLimitationsPublicButton";
            this.CSTR_RemoveLimitationsPublicButton.Size = new System.Drawing.Size(67, 24);
            this.CSTR_RemoveLimitationsPublicButton.TabIndex = 47;
            this.CSTR_RemoveLimitationsPublicButton.Text = "Διαγραφή";
            this.CSTR_RemoveLimitationsPublicButton.Click += new System.EventHandler(this.CSTR_RemoveLimitationsPublicButton_Click);
            // 
            // CSTR_LimitationsPublicListBox
            // 
            this.CSTR_LimitationsPublicListBox.Location = new System.Drawing.Point(48, 134);
            this.CSTR_LimitationsPublicListBox.Name = "CSTR_LimitationsPublicListBox";
            this.CSTR_LimitationsPublicListBox.Size = new System.Drawing.Size(340, 56);
            this.CSTR_LimitationsPublicListBox.TabIndex = 46;
            // 
            // CSTR_AddLimitationsPublicButton2
            // 
            this.CSTR_AddLimitationsPublicButton2.Location = new System.Drawing.Point(394, 89);
            this.CSTR_AddLimitationsPublicButton2.Name = "CSTR_AddLimitationsPublicButton2";
            this.CSTR_AddLimitationsPublicButton2.Size = new System.Drawing.Size(67, 24);
            this.CSTR_AddLimitationsPublicButton2.TabIndex = 45;
            this.CSTR_AddLimitationsPublicButton2.Text = "Προσθήκη";
            this.CSTR_AddLimitationsPublicButton2.Click += new System.EventHandler(this.CSTR_AddLimitationsPublicButton2_Click);
            // 
            // CSTR_LimitationsPublicTextBox
            // 
            this.CSTR_LimitationsPublicTextBox.AcceptsReturn = true;
            this.CSTR_LimitationsPublicTextBox.Location = new System.Drawing.Point(48, 75);
            this.CSTR_LimitationsPublicTextBox.Multiline = true;
            this.CSTR_LimitationsPublicTextBox.Name = "CSTR_LimitationsPublicTextBox";
            this.CSTR_LimitationsPublicTextBox.Size = new System.Drawing.Size(340, 38);
            this.CSTR_LimitationsPublicTextBox.TabIndex = 44;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(45, 56);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(161, 16);
            this.label12.TabIndex = 43;
            this.label12.Text = "ή εισάγετε ελέυθερο κείμενο";
            // 
            // CSTR_AddLimitationsPublicButton1
            // 
            this.CSTR_AddLimitationsPublicButton1.Location = new System.Drawing.Point(394, 29);
            this.CSTR_AddLimitationsPublicButton1.Name = "CSTR_AddLimitationsPublicButton1";
            this.CSTR_AddLimitationsPublicButton1.Size = new System.Drawing.Size(67, 24);
            this.CSTR_AddLimitationsPublicButton1.TabIndex = 42;
            this.CSTR_AddLimitationsPublicButton1.Text = "Προσθήκη";
            this.CSTR_AddLimitationsPublicButton1.Click += new System.EventHandler(this.CSTR_AddLimitationsPublicButton1_Click);
            // 
            // CSTR_ConditionsUseGeneralComboBox
            // 
            this.CSTR_ConditionsUseGeneralComboBox.Items.AddRange(new object[] {
            "δεν ισχύουν όροι",
            "άγνωστοι όροι"});
            this.CSTR_ConditionsUseGeneralComboBox.Location = new System.Drawing.Point(46, 239);
            this.CSTR_ConditionsUseGeneralComboBox.Name = "CSTR_ConditionsUseGeneralComboBox";
            this.CSTR_ConditionsUseGeneralComboBox.Size = new System.Drawing.Size(340, 21);
            this.CSTR_ConditionsUseGeneralComboBox.TabIndex = 41;
            this.CSTR_ConditionsUseGeneralComboBox.Text = "Παρακαλώ επιλέξτε";
            // 
            // CSTR_LimitationsPublicComboBox
            // 
            this.CSTR_LimitationsPublicComboBox.Items.AddRange(new object[] {
            "no limitations",
            "(a) the confidentiality of the proceedings of public authorities,where such confi" +
                "dentiality is provided for by law",
            "(b) international relations, public security or national defence",
            "(c) the course of justice, the ability of any person to receive a fair trial or t" +
                "he ability of a public authority to conduct an enquiry of a criminal or discipli" +
                "nary nature",
            resources.GetString("CSTR_LimitationsPublicComboBox.Items"),
            "(e) intellectual property rights",
            resources.GetString("CSTR_LimitationsPublicComboBox.Items1"),
            resources.GetString("CSTR_LimitationsPublicComboBox.Items2"),
            "(h) the protection of the environment to which such information relates, such as " +
                "the location of rare species"});
            this.CSTR_LimitationsPublicComboBox.Location = new System.Drawing.Point(48, 32);
            this.CSTR_LimitationsPublicComboBox.Name = "CSTR_LimitationsPublicComboBox";
            this.CSTR_LimitationsPublicComboBox.Size = new System.Drawing.Size(340, 21);
            this.CSTR_LimitationsPublicComboBox.TabIndex = 40;
            this.CSTR_LimitationsPublicComboBox.Text = "Παρακαλώ επιλέξτε";
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(6, 220);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(200, 16);
            this.label25.TabIndex = 36;
            this.label25.Text = "Όροι για την πρόσβαση και τη χρήση";
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(8, 16);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(265, 16);
            this.label24.TabIndex = 34;
            this.label24.Text = "Περιορισμοί σχετικά με την πρόσβαση του κοινού";
            // 
            // OrganizationTab
            // 
            this.OrganizationTab.Controls.Add(this.ORG_GroupBox);
            this.OrganizationTab.Location = new System.Drawing.Point(4, 40);
            this.OrganizationTab.Name = "OrganizationTab";
            this.OrganizationTab.Size = new System.Drawing.Size(581, 481);
            this.OrganizationTab.TabIndex = 9;
            this.OrganizationTab.Text = "Οργανισμοί";
            this.OrganizationTab.UseVisualStyleBackColor = true;
            // 
            // ORG_GroupBox
            // 
            this.ORG_GroupBox.Controls.Add(this.groupBox12);
            this.ORG_GroupBox.Controls.Add(this.ORG_IndividualListBox);
            this.ORG_GroupBox.Controls.Add(this.ORG_RemoveButton);
            this.ORG_GroupBox.Controls.Add(this.ORG_AddButton);
            this.ORG_GroupBox.Location = new System.Drawing.Point(26, 13);
            this.ORG_GroupBox.Name = "ORG_GroupBox";
            this.ORG_GroupBox.Size = new System.Drawing.Size(523, 257);
            this.ORG_GroupBox.TabIndex = 28;
            this.ORG_GroupBox.TabStop = false;
            this.ORG_GroupBox.Text = "Αρμόδιοι οργανισμοι για τη δημιουργία, τη συντήρηση και τη διανομή";
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.ORG_RemoveEmailButton);
            this.groupBox12.Controls.Add(this.ORG_EmailListBox);
            this.groupBox12.Controls.Add(this.ORG_AddEmailButton);
            this.groupBox12.Controls.Add(this.ORG_EmailTextBox);
            this.groupBox12.Controls.Add(this.label27);
            this.groupBox12.Controls.Add(this.ORG_NameTextBox);
            this.groupBox12.Controls.Add(this.label28);
            this.groupBox12.Controls.Add(this.label6);
            this.groupBox12.Controls.Add(this.ORG_RoleComboBox);
            this.groupBox12.Location = new System.Drawing.Point(5, 16);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(439, 171);
            this.groupBox12.TabIndex = 39;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Αρμόδιο μέρος";
            // 
            // ORG_RemoveEmailButton
            // 
            this.ORG_RemoveEmailButton.Location = new System.Drawing.Point(366, 56);
            this.ORG_RemoveEmailButton.Name = "ORG_RemoveEmailButton";
            this.ORG_RemoveEmailButton.Size = new System.Drawing.Size(67, 24);
            this.ORG_RemoveEmailButton.TabIndex = 41;
            this.ORG_RemoveEmailButton.Text = "Διαγραφή";
            this.ORG_RemoveEmailButton.Click += new System.EventHandler(this.ORG_RemoveEmailButton_Click);
            // 
            // ORG_EmailListBox
            // 
            this.ORG_EmailListBox.Location = new System.Drawing.Point(108, 43);
            this.ORG_EmailListBox.Name = "ORG_EmailListBox";
            this.ORG_EmailListBox.Size = new System.Drawing.Size(252, 56);
            this.ORG_EmailListBox.TabIndex = 40;
            // 
            // ORG_AddEmailButton
            // 
            this.ORG_AddEmailButton.Location = new System.Drawing.Point(366, 13);
            this.ORG_AddEmailButton.Name = "ORG_AddEmailButton";
            this.ORG_AddEmailButton.Size = new System.Drawing.Size(67, 24);
            this.ORG_AddEmailButton.TabIndex = 39;
            this.ORG_AddEmailButton.Text = "Προσθήκη";
            this.ORG_AddEmailButton.Click += new System.EventHandler(this.ORG_AddEmailButton_Click);
            // 
            // ORG_EmailTextBox
            // 
            this.ORG_EmailTextBox.Location = new System.Drawing.Point(108, 16);
            this.ORG_EmailTextBox.Name = "ORG_EmailTextBox";
            this.ORG_EmailTextBox.Size = new System.Drawing.Size(252, 20);
            this.ORG_EmailTextBox.TabIndex = 37;
            // 
            // label27
            // 
            this.label27.Location = new System.Drawing.Point(6, 19);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(96, 28);
            this.label27.TabIndex = 38;
            this.label27.Text = "Ηλεκτρονική διεύθυνση";
            // 
            // ORG_NameTextBox
            // 
            this.ORG_NameTextBox.Location = new System.Drawing.Point(106, 145);
            this.ORG_NameTextBox.Name = "ORG_NameTextBox";
            this.ORG_NameTextBox.Size = new System.Drawing.Size(327, 20);
            this.ORG_NameTextBox.TabIndex = 31;
            // 
            // label28
            // 
            this.label28.Location = new System.Drawing.Point(6, 145);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(104, 16);
            this.label28.TabIndex = 30;
            this.label28.Text = "Όνομα οργανισμού";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(6, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 40);
            this.label6.TabIndex = 23;
            this.label6.Text = "Ρόλος αρμόδιου μέρους";
            // 
            // ORG_RoleComboBox
            // 
            this.ORG_RoleComboBox.Items.AddRange(new object[] {
            "Πάροχος πόρου",
            "Υπόλογος",
            "Κάτοχος",
            "Χρήστης",
            "Διανομέας",
            "Δημιουργός",
            "Αρμόδιος για επικοινωνία",
            "Πρωτεύων διερευνητής",
            "Επεξεργαστής",
            "Εκδότης",
            "Συντάκτης"});
            this.ORG_RoleComboBox.Location = new System.Drawing.Point(108, 105);
            this.ORG_RoleComboBox.Name = "ORG_RoleComboBox";
            this.ORG_RoleComboBox.Size = new System.Drawing.Size(200, 21);
            this.ORG_RoleComboBox.TabIndex = 24;
            this.ORG_RoleComboBox.Text = "Παρακαλώ επιλέξτε";
            // 
            // ORG_IndividualListBox
            // 
            this.ORG_IndividualListBox.Location = new System.Drawing.Point(5, 193);
            this.ORG_IndividualListBox.Name = "ORG_IndividualListBox";
            this.ORG_IndividualListBox.Size = new System.Drawing.Size(438, 56);
            this.ORG_IndividualListBox.TabIndex = 34;
            // 
            // ORG_RemoveButton
            // 
            this.ORG_RemoveButton.Location = new System.Drawing.Point(449, 208);
            this.ORG_RemoveButton.Name = "ORG_RemoveButton";
            this.ORG_RemoveButton.Size = new System.Drawing.Size(67, 24);
            this.ORG_RemoveButton.TabIndex = 29;
            this.ORG_RemoveButton.Text = "Διαγραφή";
            this.ORG_RemoveButton.Click += new System.EventHandler(this.ORG_RemoveButton_Click);
            // 
            // ORG_AddButton
            // 
            this.ORG_AddButton.Location = new System.Drawing.Point(450, 72);
            this.ORG_AddButton.Name = "ORG_AddButton";
            this.ORG_AddButton.Size = new System.Drawing.Size(67, 24);
            this.ORG_AddButton.TabIndex = 28;
            this.ORG_AddButton.Text = "Προσθήκη";
            this.ORG_AddButton.Click += new System.EventHandler(this.ORG_AddButton_Click);
            // 
            // MDControl
            // 
            this.Controls.Add(this.MD_tabControl);
            this.Name = "MDControl";
            this.Size = new System.Drawing.Size(589, 525);
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
