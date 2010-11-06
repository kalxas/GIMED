/*
   Name:         GIMED
   Version:      1.2.1
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
using System.Collections;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.XPath;

namespace Inspire.Metadata
{
    
    public class MDObject
	{
        //EN
		#region members
		
        public ArrayList MD_PointOfContact;
		public string MD_Language;
		public string MD_Date;
        public string ID_ResourseTitle;
        public string ID_ResourceAbstract;
        public string ID_ResourceType;
        public ArrayList ID_ResourceLocator;
        public ArrayList ID_UniqueResourceIdentifier;
        public ArrayList ID_ResourceLanguage;
		public ArrayList CL_TopicCategory;
        public ArrayList KW_Keyword;
        public ArrayList GEO_GeographicExtend;
		public ArrayList TMP_TemporalExtend;
		public ArrayList TMP_DatePublication;
        public string TMP_DateRevision;
        public string TMP_DateCreation;
		public ArrayList QLT_Scale;
		public ArrayList QLT_Distance;
        public string QLT_Lineage;
		public ArrayList CFRM_Title;
		public ArrayList CFRM_DateType;
		public ArrayList CFRM_Date;
		public ArrayList CFRM_Degree;
        public ArrayList CSTR_LimitationsPublic;
        public ArrayList CSTR_ConditionsUseGeneral;
        public ArrayList ORG_ResponsibleParty;
        public string FileIdentifier;

        #endregion

		public MDObject()
		{
            MD_PointOfContact = new ArrayList();
			MD_Language = "";
			MD_Date = "";
            ID_ResourseTitle = "";
            ID_ResourceAbstract = "";
            ID_ResourceType = "";
            ID_ResourceLocator = new ArrayList();
            ID_UniqueResourceIdentifier = new ArrayList();
            ID_ResourceLanguage = new ArrayList();
			CL_TopicCategory = new ArrayList();
			KW_Keyword = new ArrayList();
            GEO_GeographicExtend = new ArrayList();
            TMP_TemporalExtend = new ArrayList();
            TMP_DatePublication = new ArrayList();
            TMP_DateRevision = "";
            TMP_DateCreation = "";
			QLT_Scale = new ArrayList();
			QLT_Distance = new ArrayList();
            QLT_Lineage = "";
			CFRM_Title = new ArrayList();
			CFRM_DateType = new ArrayList();
			CFRM_Date = new ArrayList();
			CFRM_Degree = new ArrayList();
            CSTR_LimitationsPublic = new ArrayList();
            CSTR_ConditionsUseGeneral = new ArrayList();
            ORG_ResponsibleParty = new ArrayList();
		}

        public void WriteToXML(string outfile)
        {
            string tmp = "";
            string[] sub = null;
            
            Stream outstr = new BufferedStream(new FileStream(outfile, FileMode.Create));
            StreamWriter o = new StreamWriter(outstr);

            tmp = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
            o.WriteLine(tmp);

            #region MD_Metadata
            tmp = "<gmd:MD_Metadata xsi:schemaLocation=\"http://www.isotc211.org/2005/gmd http://schemas.opengis.net/iso/19139/20060504/gmd/gmd.xsd\" xmlns:gmd=\"http://www.isotc211.org/2005/gmd\" xmlns:gco=\"http://www.isotc211.org/2005/gco\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:gml=\"http://www.opengis.net/gml\" xmlns:xlink=\"http://www.w3.org/1999/xlink\">";
            o.WriteLine(tmp);

            #region FileIdentifier
            tmp = "	<gmd:fileIdentifier><gco:CharacterString>" + this.FileIdentifier + "</gco:CharacterString></gmd:fileIdentifier>";
            o.WriteLine(tmp);
            #endregion

            #region MD_Language
            string tmp2 = this.ToCodeList(this.MD_Language);
            tmp = "	<gmd:language><gmd:LanguageCode codeList=\"http://standards.iso.org/ittf/PubliclyAvailableStandards/ISO_19139_Schemas/resources/Codelist/ML_gmxCodelists.xml#LanguageCode\" codeListValue=\"" + tmp2 + "\">" + tmp2 + "</gmd:LanguageCode></gmd:language>";
            o.WriteLine(tmp);            
            #endregion

            #region ID_ResourceType
            tmp2 = this.ToCodeList(this.ID_ResourceType);
            tmp = "	<gmd:hierarchyLevel><gmd:MD_ScopeCode codeList=\"http://standards.iso.org/ittf/PubliclyAvailableStandards/ISO_19139_Schemas/resources/Codelist/ML_gmxCodelists.xml#MD_ScopeCode\" codeListValue=\"" + tmp2 + "\">" + tmp2 + "</gmd:MD_ScopeCode></gmd:hierarchyLevel>";
            o.WriteLine(tmp);
            #endregion

            #region MD_PointOfContact
            for (int i = 0; i < this.MD_PointOfContact.Count; i++)
            {
                sub = ((string)this.MD_PointOfContact[i]).Split('|');
                int num = sub.Length - 1;
                tmp = "	<gmd:contact><gmd:CI_ResponsibleParty><gmd:organisationName><gco:CharacterString>" + sub[0] +"</gco:CharacterString></gmd:organisationName><gmd:contactInfo><gmd:CI_Contact><gmd:address><gmd:CI_Address>";
                for (int j = 1; j <= num; j++)
                {
                    tmp += "<gmd:electronicMailAddress><gco:CharacterString>" + sub[j] +"</gco:CharacterString></gmd:electronicMailAddress>";
                }
                tmp += "</gmd:CI_Address></gmd:address></gmd:CI_Contact></gmd:contactInfo><gmd:role><gmd:CI_RoleCode codeList=\"http://standards.iso.org/ittf/PubliclyAvailableStandards/ISO_19139_Schemas/resources/Codelist/ML_gmxCodelists.xml#CI_RoleCode\" codeListValue=\"pointOfContact\">pointOfContact</gmd:CI_RoleCode></gmd:role></gmd:CI_ResponsibleParty></gmd:contact>";
                o.WriteLine(tmp);
            }
            #endregion

            #region MD_Date
            tmp = "	<gmd:dateStamp><gco:Date>" + this.MD_Date + "</gco:Date></gmd:dateStamp>";
            o.WriteLine(tmp);
            #endregion

            #region MD_Standard
            tmp = "<gmd:metadataStandardName><gco:CharacterString>ISO19115</gco:CharacterString></gmd:metadataStandardName>";
            o.WriteLine(tmp);
            tmp = "<gmd:metadataStandardVersion><gco:CharacterString>2003/Cor.1:2006</gco:CharacterString></gmd:metadataStandardVersion>";
            o.WriteLine(tmp);
            #endregion

            #region MD_DataIdentification
            tmp = "	<gmd:identificationInfo>";
            o.WriteLine(tmp);
            tmp = "		<gmd:MD_DataIdentification>";
            o.WriteLine(tmp);

            #region CI_Citation
            tmp = "			<gmd:citation>";
            o.WriteLine(tmp);
            tmp = "				<gmd:CI_Citation>";
            o.WriteLine(tmp);

            #region ID_ResourseTitle
            tmp = "					<gmd:title><gco:CharacterString>" + this.ID_ResourseTitle + "</gco:CharacterString></gmd:title>";
            o.WriteLine(tmp);
            #endregion

            #region TMP_Date
            if (this.TMP_DatePublication.Count > 0)
            {
                for (int i = 0; i < this.TMP_DatePublication.Count; i++)
                {
                    tmp = "				<gmd:date><gmd:CI_Date><gmd:date><gco:Date>" + this.TMP_DatePublication[i].ToString() + "</gco:Date></gmd:date><gmd:dateType><gmd:CI_DateTypeCode codeList=\"http://standards.iso.org/ittf/PubliclyAvailableStandards/ISO_19139_Schemas/resources/Codelist/ML_gmxCodelists.xml#CI_DateTypeCode\" codeListValue=\"publication\">publication</gmd:CI_DateTypeCode></gmd:dateType></gmd:CI_Date></gmd:date>";
                    o.WriteLine(tmp);
                }
            }

            if (this.TMP_DateCreation != "")
            {
                tmp = "				<gmd:date><gmd:CI_Date><gmd:date><gco:Date>" + this.TMP_DateCreation + "</gco:Date></gmd:date><gmd:dateType><gmd:CI_DateTypeCode codeList=\"http://standards.iso.org/ittf/PubliclyAvailableStandards/ISO_19139_Schemas/resources/Codelist/ML_gmxCodelists.xml#CI_DateTypeCode\" codeListValue=\"creation\">creation</gmd:CI_DateTypeCode></gmd:dateType></gmd:CI_Date></gmd:date>";
                o.WriteLine(tmp);
            }
            if (this.TMP_DateRevision != "")
            {
                tmp = "				<gmd:date><gmd:CI_Date><gmd:date><gco:Date>" + this.TMP_DateRevision + "</gco:Date></gmd:date><gmd:dateType><gmd:CI_DateTypeCode codeList=\"http://standards.iso.org/ittf/PubliclyAvailableStandards/ISO_19139_Schemas/resources/Codelist/ML_gmxCodelists.xml#CI_DateTypeCode\" codeListValue=\"revision\">revision</gmd:CI_DateTypeCode></gmd:dateType></gmd:CI_Date></gmd:date>";
                o.WriteLine(tmp);
            }
            #endregion

            #region ID_UniqueResourceIdentifier

            for (int i = 0; i < this.ID_UniqueResourceIdentifier.Count; i++)
            {
                sub = ((string)this.ID_UniqueResourceIdentifier[i]).Split('|');
                tmp = "				<gmd:identifier><gmd:RS_Identifier><gmd:code><gco:CharacterString>" + sub[0] + "</gco:CharacterString></gmd:code>";
                if (sub.Length > 1)
                {
                    tmp += "<gmd:codeSpace><gco:CharacterString>" + sub[1] + "</gco:CharacterString></gmd:codeSpace>";
                }
                tmp += "</gmd:RS_Identifier></gmd:identifier>";
                o.WriteLine(tmp);
            }
            #endregion

            tmp = "				</gmd:CI_Citation>";
            o.WriteLine(tmp);
            tmp = "			</gmd:citation>";
            o.WriteLine(tmp);
            #endregion

            #region ID_ResourceAbstract
            tmp = "			<gmd:abstract><gco:CharacterString>" + this.ID_ResourceAbstract + "</gco:CharacterString></gmd:abstract>";
            o.WriteLine(tmp);
            #endregion

            #region ORG_ResponsibleParty
            foreach (object r in this.ORG_ResponsibleParty)
            {
                sub = ((string)r).Split('|');
                tmp = "<gmd:pointOfContact><gmd:CI_ResponsibleParty><gmd:organisationName><gco:CharacterString>" + sub[0] + "</gco:CharacterString></gmd:organisationName>";
                tmp += "<gmd:contactInfo><gmd:CI_Contact><gmd:address><gmd:CI_Address>";
                for (int j = 2; j < sub.Length; j++)
                {
                    tmp += "<gmd:electronicMailAddress><gco:CharacterString>" + sub[j] + "</gco:CharacterString></gmd:electronicMailAddress>";
                }
                tmp += "</gmd:CI_Address></gmd:address></gmd:CI_Contact></gmd:contactInfo>";
                tmp2 = this.ToCodeList(sub[1]);
                tmp += "<gmd:role><gmd:CI_RoleCode codeList=\"http://standards.iso.org/ittf/PubliclyAvailableStandards/ISO_19139_Schemas/resources/Codelist/ML_gmxCodelists.xml#CI_RoleCode\" codeListValue=\"" + tmp2 + "\">" + tmp2 + "</gmd:CI_RoleCode></gmd:role>";
                tmp += "</gmd:CI_ResponsibleParty></gmd:pointOfContact>";
                o.WriteLine(tmp);
            }
            #endregion

            #region KW_Keyword
            int cur_pos = 0;
            int kw_count_idx = this.KW_Keyword.Count - 1;
            string cur_voc = "";
            string cur_date = "";
            string cur_type = "";
            ArrayList cur_kw = new ArrayList();
            while (cur_pos <= kw_count_idx)
            {
                sub = ((string)this.KW_Keyword[cur_pos]).Split('|');
                cur_voc = sub[0];
                cur_type = sub[1];
                cur_date = sub[2];
                cur_kw.Add(sub[3]);
                while (true)
                {
                    if (cur_pos < kw_count_idx)//Test next value
                    {
                        sub = ((string)this.KW_Keyword[cur_pos + 1]).Split('|');
                        if (cur_voc == sub[0] && cur_type == sub[1] && cur_date == sub[2])//Next value same as previous
                        {
                            cur_kw.Add(sub[3]);
                            cur_pos++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else//Last value
                    {
                        break;
                    }
                }

                //Write at XML start
                tmp = "			<gmd:descriptiveKeywords><gmd:MD_Keywords>";
                foreach (object kw in cur_kw)
                {
                    tmp += "<gmd:keyword><gco:CharacterString>" + (string)kw + "</gco:CharacterString></gmd:keyword>";
                }
                tmp += "<gmd:thesaurusName><gmd:CI_Citation><gmd:title><gco:CharacterString>" + cur_voc + "</gco:CharacterString></gmd:title><gmd:date><gmd:CI_Date><gmd:date><gco:Date>" + cur_date + "</gco:Date></gmd:date><gmd:dateType><gmd:CI_DateTypeCode codeList=\"http://standards.iso.org/ittf/PubliclyAvailableStandards/ISO_19139_Schemas/resources/Codelist/ML_gmxCodelists.xml#CI_DateTypeCode\" codeListValue=\"" + cur_type + "\">" + cur_type + "</gmd:CI_DateTypeCode></gmd:dateType></gmd:CI_Date></gmd:date></gmd:CI_Citation></gmd:thesaurusName>";
                tmp += "</gmd:MD_Keywords></gmd:descriptiveKeywords>";
                o.WriteLine(tmp);
                //Write at XML end
                cur_kw.Clear();
                cur_pos++;
            }
            #endregion

            #region CSTR_ConditionsUseGeneral

            foreach (object r in this.CSTR_ConditionsUseGeneral)
            {
                tmp = "			<gmd:resourceConstraints><gmd:MD_Constraints><gmd:useLimitation><gco:CharacterString>" + (string)r + "</gco:CharacterString></gmd:useLimitation></gmd:MD_Constraints></gmd:resourceConstraints>";
                o.WriteLine(tmp);
            }
            #endregion

            #region CSTR_LimitationsPublic
            foreach (object r in this.CSTR_LimitationsPublic)
            {
                tmp = "			<gmd:resourceConstraints><gmd:MD_LegalConstraints><gmd:accessConstraints><gmd:MD_RestrictionCode codeList=\"http://standards.iso.org/ittf/PubliclyAvailableStandards/ISO_19139_Schemas/resources/Codelist/ML_gmxCodelists.xml#MD_RestrictionCode\" codeListValue=\"otherRestrictions\">otherRestrictions</gmd:MD_RestrictionCode></gmd:accessConstraints><gmd:otherConstraints><gco:CharacterString>" + (string)r + "</gco:CharacterString></gmd:otherConstraints></gmd:MD_LegalConstraints></gmd:resourceConstraints>";
                o.WriteLine(tmp);
            }
            #endregion

            #region QLT_Scale
            if (this.QLT_Scale.Count != 0)
            {
                foreach (object r in this.QLT_Scale)
                {
                    tmp = "			<gmd:spatialResolution><gmd:MD_Resolution><gmd:equivalentScale><gmd:MD_RepresentativeFraction><gmd:denominator><gco:Integer>" + (string)r + "</gco:Integer></gmd:denominator></gmd:MD_RepresentativeFraction></gmd:equivalentScale></gmd:MD_Resolution></gmd:spatialResolution>";
                    o.WriteLine(tmp);
                }
            }
            #endregion

            #region QLT_Distance
            if (this.QLT_Distance.Count != 0)
            {
                foreach (object r in this.QLT_Distance)
                {
                    sub = ((string)r).Split(' ');
                    tmp = "			<gmd:spatialResolution><gmd:MD_Resolution><gmd:distance><gco:Distance uom=\"" + sub[1] + "\">" + sub[0] + "</gco:Distance></gmd:distance></gmd:MD_Resolution></gmd:spatialResolution>";
                    o.WriteLine(tmp);
                }
            }
            #endregion

            #region ID_ResourceLanguage
            foreach (object obj in this.ID_ResourceLanguage)
            {
                tmp2 = this.ToCodeList((string)obj);
                tmp = "			<gmd:language><gmd:LanguageCode codeList=\"http://standards.iso.org/ittf/PubliclyAvailableStandards/ISO_19139_Schemas/resources/Codelist/ML_gmxCodelists.xml#LanguageCode\" codeListValue=\"" + tmp2 + "\">" + tmp2 + "</gmd:LanguageCode></gmd:language>";
                o.WriteLine(tmp);
            }

            #endregion

            #region CL_TopicCategory
            foreach (object obj in this.CL_TopicCategory)
            {
                tmp2 = this.ToCodeList((string)obj);
                tmp = "			<gmd:topicCategory><gmd:MD_TopicCategoryCode>" + tmp2 + "</gmd:MD_TopicCategoryCode></gmd:topicCategory>";
                o.WriteLine(tmp);
            }
            #endregion

            #region GEO_GeographicExtend
            foreach (object obj in this.GEO_GeographicExtend)
            {
                sub = ((string)obj).Split(';');
                tmp = "			<gmd:extent><gmd:EX_Extent><gmd:geographicElement><gmd:EX_GeographicBoundingBox><gmd:westBoundLongitude><gco:Decimal>" + sub[0] +"</gco:Decimal></gmd:westBoundLongitude><gmd:eastBoundLongitude><gco:Decimal>" + sub[2] + "</gco:Decimal></gmd:eastBoundLongitude><gmd:southBoundLatitude><gco:Decimal>" + sub[1] + "</gco:Decimal></gmd:southBoundLatitude><gmd:northBoundLatitude><gco:Decimal>" + sub[3] + "</gco:Decimal></gmd:northBoundLatitude></gmd:EX_GeographicBoundingBox></gmd:geographicElement></gmd:EX_Extent></gmd:extent>";
                o.WriteLine(tmp);
            }
            #endregion

            #region TMP_TemporalExtend
            foreach (object obj in this.TMP_TemporalExtend)
            {
                sub = ((string)obj).Split(' ');
                tmp = "			<gmd:extent><gmd:EX_Extent><gmd:temporalElement><gmd:EX_TemporalExtent><gmd:extent><gml:TimePeriod gml:id=\"" + "ID_" + System.Guid.NewGuid().ToString() + "\" xsi:type=\"gml:TimePeriodType\"><gml:beginPosition>" + sub[1] + "</gml:beginPosition><gml:endPosition>" + sub[3] + "</gml:endPosition></gml:TimePeriod></gmd:extent></gmd:EX_TemporalExtent></gmd:temporalElement></gmd:EX_Extent></gmd:extent>";
                o.WriteLine(tmp);
            }
            #endregion

            tmp = "		</gmd:MD_DataIdentification>";
            o.WriteLine(tmp);
            tmp = "	</gmd:identificationInfo>";
            o.WriteLine(tmp);
            #endregion

            #region MD_Distribution
            if(this.ID_ResourceLocator.Count != 0)
            {
                tmp = "<gmd:distributionInfo><gmd:MD_Distribution><gmd:distributionFormat><gmd:MD_Format><gmd:name gco:nilReason=\"inapplicable\"/><gmd:version gco:nilReason=\"inapplicable\"/></gmd:MD_Format></gmd:distributionFormat><gmd:transferOptions><gmd:MD_DigitalTransferOptions>";
                foreach(object obj in this.ID_ResourceLocator)
                {
                    string tmp3 = ((string)obj);
                    sub = tmp3.Split('&');
                    if (sub.Length > 1)
                    {
                        tmp3 = sub[0];
                        for (int i = 1; i < sub.Length; i++)
                        {
                            tmp3 += "&amp;" + sub[i];
                        }
                    }
                    tmp += "<gmd:onLine><gmd:CI_OnlineResource><gmd:linkage><gmd:URL>" + tmp3 + "</gmd:URL></gmd:linkage></gmd:CI_OnlineResource></gmd:onLine>";
                }
                tmp += "</gmd:MD_DigitalTransferOptions></gmd:transferOptions></gmd:MD_Distribution></gmd:distributionInfo>";
                o.WriteLine(tmp);
            }
            else
            {
                tmp = "<gmd:distributionInfo><gmd:MD_Distribution><gmd:distributionFormat><gmd:MD_Format><gmd:name gco:nilReason=\"inapplicable\"/><gmd:version gco:nilReason=\"inapplicable\"/></gmd:MD_Format></gmd:distributionFormat><gmd:transferOptions><gmd:MD_DigitalTransferOptions/></gmd:transferOptions></gmd:MD_Distribution></gmd:distributionInfo>";
                o.WriteLine(tmp);
            }
             
            #endregion

            #region DQ_DataQuality
            tmp = "<gmd:dataQualityInfo><gmd:DQ_DataQuality>";
            o.WriteLine(tmp);

            tmp = "<gmd:scope><gmd:DQ_Scope><gmd:level><gmd:MD_ScopeCode codeListValue=\"" + this.ToCodeList(this.ID_ResourceType) + "\" codeList=\"http://standards.iso.org/ittf/PubliclyAvailableStandards/ISO_19139_Schemas/resources/Codelist/ML_gmxCodelists.xml#MD_ScopeCode\">" + this.ToCodeList(this.ID_ResourceType) + "</gmd:MD_ScopeCode></gmd:level></gmd:DQ_Scope></gmd:scope>";
            o.WriteLine(tmp);

            #region DQ_DomainConsistency
            if (this.CFRM_Title.Count != 0)
            {
                for (int i = 0; i < this.CFRM_Title.Count; i++)
                {
                    tmp = "<gmd:report><gmd:DQ_DomainConsistency xsi:type=\"gmd:DQ_DomainConsistency_Type\"><gmd:measureIdentification><gmd:RS_Identifier><gmd:code><gco:CharacterString>Conformity_001</gco:CharacterString></gmd:code><gmd:codeSpace><gco:CharacterString>INSPIRE</gco:CharacterString></gmd:codeSpace></gmd:RS_Identifier></gmd:measureIdentification><gmd:result><gmd:DQ_ConformanceResult xsi:type=\"gmd:DQ_ConformanceResult_Type\"><gmd:specification><gmd:CI_Citation><gmd:title><gco:CharacterString>" + ((string)this.CFRM_Title[i]) + "</gco:CharacterString></gmd:title><gmd:date><gmd:CI_Date><gmd:date><gco:Date>" + ((string)this.CFRM_Date[i]) + "</gco:Date></gmd:date><gmd:dateType><gmd:CI_DateTypeCode codeList=\"http://standards.iso.org/ittf/PubliclyAvailableStandards/ISO_19139_Schemas/resources/Codelist/ML_gmxCodelists.xml#CI_DateTypeCode\" codeListValue=\"" + ((string)this.CFRM_DateType[i]) + "\">" + ((string)this.CFRM_DateType[i]) + "</gmd:CI_DateTypeCode></gmd:dateType></gmd:CI_Date></gmd:date></gmd:CI_Citation></gmd:specification><gmd:explanation><gco:CharacterString>See the referenced specification</gco:CharacterString></gmd:explanation>";
                    if (((string)this.CFRM_Degree[i]) == "Not Evaluated")
                    {
                        tmp += "<gmd:pass gco:nilReason=\"template\"/>";
                    }
                    else if (((string)this.CFRM_Degree[i]) == "Not Conformant")
                    {
                        tmp += "<gmd:pass><gco:Boolean>false</gco:Boolean></gmd:pass>";
                    }
                    else if (((string)this.CFRM_Degree[i]) == "Conformant")
                    {
                        tmp += "<gmd:pass><gco:Boolean>true</gco:Boolean></gmd:pass>";
                    }
                    tmp += "</gmd:DQ_ConformanceResult></gmd:result></gmd:DQ_DomainConsistency></gmd:report>";
                    o.WriteLine(tmp);
                }
            }
            #endregion

            #region QLT_Lineage
            tmp = "<gmd:lineage><gmd:LI_Lineage><gmd:statement><gco:CharacterString>" + this.QLT_Lineage + "</gco:CharacterString></gmd:statement></gmd:LI_Lineage></gmd:lineage>";
            o.WriteLine(tmp);
            #endregion

            tmp = "</gmd:DQ_DataQuality></gmd:dataQualityInfo>";
            o.WriteLine(tmp);
            #endregion

            tmp = "</gmd:MD_Metadata>";
            o.WriteLine(tmp);
            #endregion

            o.Close();
            outstr.Close();

            return;
        }
          
        public bool LoadFromXML(string XMLFileName)
        {
            try
            {
                ArrayList ar = new ArrayList();
                string tmp = "";

                XPathDocument doc = new XPathDocument(XMLFileName);
                XPathNavigator nav = doc.CreateNavigator();
                XmlNamespaceManager manager = new XmlNamespaceManager(nav.NameTable);
                manager.AddNamespace("gmd", "http://www.isotc211.org/2005/gmd");
                manager.AddNamespace("gco", "http://www.isotc211.org/2005/gco");
                manager.AddNamespace("gml", "http://www.opengis.net/gml");


                XPathExpression expr = nav.Compile("/gmd:MD_Metadata/gmd:fileIdentifier/gco:CharacterString");
                expr.SetContext(manager);
                XPathNodeIterator iterator = nav.Select(expr);

                while (iterator.MoveNext())
                {
                    XPathNavigator nav2 = iterator.Current.Clone();
                    this.FileIdentifier = nav2.Value.ToString();
                }

                expr = nav.Compile("/gmd:MD_Metadata/gmd:language/gmd:LanguageCode");
                expr.SetContext(manager);
                iterator = nav.Select(expr);
                while (iterator.MoveNext())
                {
                    XPathNavigator nav2 = iterator.Current.Clone();
                    this.MD_Language = this.ReverseCodeList(nav2.Value.ToString());
                }

                expr = nav.Compile("/gmd:MD_Metadata/gmd:hierarchyLevel/gmd:MD_ScopeCode");
                expr.SetContext(manager);
                iterator = nav.Select(expr);
                while (iterator.MoveNext())
                {
                    XPathNavigator nav2 = iterator.Current.Clone();
                    this.ID_ResourceType = this.ReverseCodeList(nav2.Value.ToString());
                }

                expr = nav.Compile("/gmd:MD_Metadata/gmd:contact");
                expr.SetContext(manager);
                iterator = nav.Select(expr);
                int mult = iterator.Count;

                for (int i = 1; i <= mult; i++)
                {
                    expr = nav.Compile("/gmd:MD_Metadata/gmd:contact[" + i.ToString() + "]/gmd:CI_ResponsibleParty/gmd:organisationName/gco:CharacterString");
                    expr.SetContext(manager);
                    iterator = nav.Select(expr);
                    while (iterator.MoveNext())
                    {
                        XPathNavigator nav2 = iterator.Current.Clone();
                        tmp = nav2.Value.ToString();
                    }

                    expr = nav.Compile("/gmd:MD_Metadata/gmd:contact[" + i.ToString() + "]/gmd:CI_ResponsibleParty/gmd:contactInfo/gmd:CI_Contact/gmd:address/gmd:CI_Address/gmd:electronicMailAddress/gco:CharacterString");
                    expr.SetContext(manager);
                    iterator = nav.Select(expr);
                    while (iterator.MoveNext())
                    {
                        XPathNavigator nav2 = iterator.Current.Clone();
                        tmp += "|" + nav2.Value.ToString();
                    }

                    this.MD_PointOfContact.Add(tmp);
                }

                expr = nav.Compile("/gmd:MD_Metadata/gmd:dateStamp/gco:Date");
                expr.SetContext(manager);
                iterator = nav.Select(expr);
                while (iterator.MoveNext())
                {
                    XPathNavigator nav2 = iterator.Current.Clone();
                    this.MD_Date = nav2.Value.ToString();
                }

                expr = nav.Compile("/gmd:MD_Metadata/gmd:metadataStandardName/gco:CharacterString");
                expr.SetContext(manager);
                iterator = nav.Select(expr);
                while (iterator.MoveNext())
                {
                    XPathNavigator nav2 = iterator.Current.Clone();
                    tmp = nav2.Value.ToString();
                    if (tmp != "ISO19115")
                    {
                        return false;
                    }
                }

                expr = nav.Compile("/gmd:MD_Metadata/gmd:metadataStandardVersion/gco:CharacterString");
                expr.SetContext(manager);
                iterator = nav.Select(expr);
                while (iterator.MoveNext())
                {
                    XPathNavigator nav2 = iterator.Current.Clone();
                    tmp = nav2.Value.ToString();
                    if (tmp != "2003/Cor.1:2006")
                    {
                        return false;
                    }
                }

                expr = nav.Compile("/gmd:MD_Metadata/gmd:identificationInfo/gmd:MD_DataIdentification/gmd:citation/gmd:CI_Citation/gmd:title/gco:CharacterString");
                expr.SetContext(manager);
                iterator = nav.Select(expr);
                while (iterator.MoveNext())
                {
                    XPathNavigator nav2 = iterator.Current.Clone();
                    this.ID_ResourseTitle = nav2.Value.ToString();
                }

                expr = nav.Compile("/gmd:MD_Metadata/gmd:identificationInfo/gmd:MD_DataIdentification/gmd:citation/gmd:CI_Citation/gmd:date");
                expr.SetContext(manager);
                iterator = nav.Select(expr);
                mult = iterator.Count;

                for (int i = 1; i <= mult; i++)
                {
                    expr = nav.Compile("/gmd:MD_Metadata/gmd:identificationInfo/gmd:MD_DataIdentification/gmd:citation/gmd:CI_Citation/gmd:date[" + i.ToString() + "]/gmd:CI_Date/gmd:date/gco:Date");
                    expr.SetContext(manager);
                    iterator = nav.Select(expr);
                    while (iterator.MoveNext())
                    {
                        XPathNavigator nav2 = iterator.Current.Clone();
                        tmp = nav2.Value.ToString();
                    }
                    string tmp2 = "";
                    expr = nav.Compile("/gmd:MD_Metadata/gmd:identificationInfo/gmd:MD_DataIdentification/gmd:citation/gmd:CI_Citation/gmd:date[" + i.ToString() + "]/gmd:CI_Date/gmd:dateType/gmd:CI_DateTypeCode");
                    expr.SetContext(manager);
                    iterator = nav.Select(expr);
                    while (iterator.MoveNext())
                    {
                        XPathNavigator nav2 = iterator.Current.Clone();
                        tmp2 = nav2.Value.ToString();
                    }

                    if (tmp2 == "creation")
                    {
                        this.TMP_DateCreation = tmp;
                    }
                    else if (tmp2 == "publication")
                    {
                        this.TMP_DatePublication.Add(tmp);
                    }
                    else if (tmp2 == "revision")
                    {
                        this.TMP_DateRevision = tmp;
                    }
                }

                expr = nav.Compile("/gmd:MD_Metadata/gmd:identificationInfo/gmd:MD_DataIdentification/gmd:citation/gmd:CI_Citation/gmd:identifier");
                expr.SetContext(manager);
                iterator = nav.Select(expr);
                mult = iterator.Count;

                for (int i = 1; i <= mult; i++)
                {
                    expr = nav.Compile("/gmd:MD_Metadata/gmd:identificationInfo/gmd:MD_DataIdentification/gmd:citation/gmd:CI_Citation/gmd:identifier[" + i.ToString() + "]/gmd:RS_Identifier/gmd:code/gco:CharacterString");
                    expr.SetContext(manager);
                    iterator = nav.Select(expr);
                    while (iterator.MoveNext())
                    {
                        XPathNavigator nav2 = iterator.Current.Clone();
                        tmp = nav2.Value.ToString();
                    }

                    expr = nav.Compile("/gmd:MD_Metadata/gmd:identificationInfo/gmd:MD_DataIdentification/gmd:citation/gmd:CI_Citation/gmd:identifier[" + i.ToString() + "]/gmd:RS_Identifier/gmd:codeSpace/gco:CharacterString");
                    expr.SetContext(manager);
                    iterator = nav.Select(expr);
                    while (iterator.MoveNext())
                    {
                        XPathNavigator nav2 = iterator.Current.Clone();
                        tmp += "|" + nav2.Value.ToString();
                    }
                    this.ID_UniqueResourceIdentifier.Add(tmp);
                }

                expr = nav.Compile("/gmd:MD_Metadata/gmd:identificationInfo/gmd:MD_DataIdentification/gmd:abstract/gco:CharacterString");
                expr.SetContext(manager);
                iterator = nav.Select(expr);
                while (iterator.MoveNext())
                {
                    XPathNavigator nav2 = iterator.Current.Clone();
                    this.ID_ResourceAbstract = nav2.Value.ToString();
                }

                expr = nav.Compile("/gmd:MD_Metadata/gmd:identificationInfo/gmd:MD_DataIdentification/gmd:pointOfContact");
                expr.SetContext(manager);
                iterator = nav.Select(expr);
                mult = iterator.Count;

                for (int i = 1; i <= mult; i++)
                {
                    expr = nav.Compile("/gmd:MD_Metadata/gmd:identificationInfo/gmd:MD_DataIdentification/gmd:pointOfContact[" + i.ToString() + "]/gmd:CI_ResponsibleParty/gmd:organisationName/gco:CharacterString");
                    expr.SetContext(manager);
                    iterator = nav.Select(expr);
                    while (iterator.MoveNext())
                    {
                        XPathNavigator nav2 = iterator.Current.Clone();
                        tmp = nav2.Value.ToString();
                    }

                    expr = nav.Compile("/gmd:MD_Metadata/gmd:identificationInfo/gmd:MD_DataIdentification/gmd:pointOfContact[" + i.ToString() + "]/gmd:CI_ResponsibleParty/gmd:role/gmd:CI_RoleCode");
                    expr.SetContext(manager);
                    iterator = nav.Select(expr);
                    while (iterator.MoveNext())
                    {
                        XPathNavigator nav2 = iterator.Current.Clone();
                        tmp += "|" + this.ReverseCodeList(nav2.Value.ToString());
                    }

                    expr = nav.Compile("/gmd:MD_Metadata/gmd:identificationInfo/gmd:MD_DataIdentification/gmd:pointOfContact[" + i.ToString() + "]/gmd:CI_ResponsibleParty/gmd:contactInfo/gmd:CI_Contact/gmd:address/gmd:CI_Address/gmd:electronicMailAddress/gco:CharacterString");
                    expr.SetContext(manager);
                    iterator = nav.Select(expr);
                    while (iterator.MoveNext())
                    {
                        XPathNavigator nav2 = iterator.Current.Clone();
                        tmp += "|" + nav2.Value.ToString();
                    }
                    this.ORG_ResponsibleParty.Add(tmp);
                }

                expr = nav.Compile("/gmd:MD_Metadata/gmd:identificationInfo/gmd:MD_DataIdentification/gmd:descriptiveKeywords");
                expr.SetContext(manager);
                iterator = nav.Select(expr);
                mult = iterator.Count;
                string thes = "";
                string thes_date = "";
                string thes_type = "";
                for (int i = 1; i <= mult; i++)
                {
                    expr = nav.Compile("/gmd:MD_Metadata/gmd:identificationInfo/gmd:MD_DataIdentification/gmd:descriptiveKeywords[" + i.ToString() + "]/gmd:MD_Keywords/gmd:thesaurusName/gmd:CI_Citation/gmd:title/gco:CharacterString");
                    expr.SetContext(manager);
                    iterator = nav.Select(expr);
                    while (iterator.MoveNext())
                    {
                        XPathNavigator nav2 = iterator.Current.Clone();
                        thes = nav2.Value.ToString();
                    }

                    expr = nav.Compile("/gmd:MD_Metadata/gmd:identificationInfo/gmd:MD_DataIdentification/gmd:descriptiveKeywords[" + i.ToString() + "]/gmd:MD_Keywords/gmd:thesaurusName/gmd:CI_Citation/gmd:date/gmd:CI_Date/gmd:date/gco:Date");
                    expr.SetContext(manager);
                    iterator = nav.Select(expr);
                    while (iterator.MoveNext())
                    {
                        XPathNavigator nav2 = iterator.Current.Clone();
                        thes_date = nav2.Value.ToString();
                    }

                    expr = nav.Compile("/gmd:MD_Metadata/gmd:identificationInfo/gmd:MD_DataIdentification/gmd:descriptiveKeywords[" + i.ToString() + "]/gmd:MD_Keywords/gmd:thesaurusName/gmd:CI_Citation/gmd:date/gmd:CI_Date/gmd:dateType/gmd:CI_DateTypeCode");
                    expr.SetContext(manager);
                    iterator = nav.Select(expr);
                    while (iterator.MoveNext())
                    {
                        XPathNavigator nav2 = iterator.Current.Clone();
                        thes_type = nav2.Value.ToString();
                    }

                    expr = nav.Compile("/gmd:MD_Metadata/gmd:identificationInfo/gmd:MD_DataIdentification/gmd:descriptiveKeywords[" + i.ToString() + "]/gmd:MD_Keywords/gmd:keyword/gco:CharacterString");
                    expr.SetContext(manager);
                    iterator = nav.Select(expr);
                    while (iterator.MoveNext())
                    {
                        XPathNavigator nav2 = iterator.Current.Clone();
                        this.KW_Keyword.Add(thes + "|" + thes_type + "|" + thes_date + "|" + nav2.Value.ToString());
                    }
                }

                expr = nav.Compile("/gmd:MD_Metadata/gmd:identificationInfo/gmd:MD_DataIdentification/gmd:resourceConstraints/gmd:MD_Constraints/gmd:useLimitation/gco:CharacterString");
                expr.SetContext(manager);
                iterator = nav.Select(expr);
                while (iterator.MoveNext())
                {
                    XPathNavigator nav2 = iterator.Current.Clone();
                    this.CSTR_ConditionsUseGeneral.Add(nav2.Value.ToString());
                }

                expr = nav.Compile("/gmd:MD_Metadata/gmd:identificationInfo/gmd:MD_DataIdentification/gmd:resourceConstraints/gmd:MD_LegalConstraints/gmd:otherConstraints/gco:CharacterString");
                expr.SetContext(manager);
                iterator = nav.Select(expr);
                while (iterator.MoveNext())
                {
                    XPathNavigator nav2 = iterator.Current.Clone();
                    this.CSTR_LimitationsPublic.Add(nav2.Value.ToString());
                }

                expr = nav.Compile("/gmd:MD_Metadata/gmd:identificationInfo/gmd:MD_DataIdentification/gmd:spatialResolution/gmd:MD_Resolution/gmd:equivalentScale/gmd:MD_RepresentativeFraction/gmd:denominator/gco:Integer");
                expr.SetContext(manager);
                iterator = nav.Select(expr);
                while (iterator.MoveNext())
                {
                    XPathNavigator nav2 = iterator.Current.Clone();
                    this.QLT_Scale.Add(nav2.Value.ToString());
                }

                expr = nav.Compile("/gmd:MD_Metadata/gmd:identificationInfo/gmd:MD_DataIdentification/gmd:spatialResolution/gmd:MD_Resolution/gmd:distance/gco:Distance");
                expr.SetContext(manager);
                iterator = nav.Select(expr);
                while (iterator.MoveNext())
                {
                    XPathNavigator nav2 = iterator.Current.Clone();
                    tmp = nav2.Value.ToString();
                    nav2.MoveToFirstAttribute();
                    this.QLT_Distance.Add(tmp + " " + nav2.Value.ToString());
                }

                expr = nav.Compile("/gmd:MD_Metadata/gmd:identificationInfo/gmd:MD_DataIdentification/gmd:language/gmd:LanguageCode");
                expr.SetContext(manager);
                iterator = nav.Select(expr);
                while (iterator.MoveNext())
                {
                    XPathNavigator nav2 = iterator.Current.Clone();
                    this.ID_ResourceLanguage.Add(this.ReverseCodeList(nav2.Value.ToString()));
                }

                expr = nav.Compile("/gmd:MD_Metadata/gmd:identificationInfo/gmd:MD_DataIdentification/gmd:topicCategory/gmd:MD_TopicCategoryCode");
                expr.SetContext(manager);
                iterator = nav.Select(expr);
                while (iterator.MoveNext())
                {
                    XPathNavigator nav2 = iterator.Current.Clone();
                    this.CL_TopicCategory.Add(this.ReverseCodeList(nav2.Value.ToString()));
                }

                expr = nav.Compile("/gmd:MD_Metadata/gmd:identificationInfo/gmd:MD_DataIdentification/gmd:extent/gmd:EX_Extent/gmd:geographicElement/gmd:EX_GeographicBoundingBox");
                expr.SetContext(manager);
                iterator = nav.Select(expr);
                mult = iterator.Count;
                for (int i = 1; i <= mult; i++)
                {
                    expr = nav.Compile("/gmd:MD_Metadata/gmd:identificationInfo/gmd:MD_DataIdentification/gmd:extent/gmd:EX_Extent/gmd:geographicElement/gmd:EX_GeographicBoundingBox[" + i.ToString() + "]/gmd:westBoundLongitude/gco:Decimal");
                    expr.SetContext(manager);
                    iterator = nav.Select(expr);
                    while (iterator.MoveNext())
                    {
                        XPathNavigator nav2 = iterator.Current.Clone();
                        tmp = nav2.Value.ToString();
                    }

                    expr = nav.Compile("/gmd:MD_Metadata/gmd:identificationInfo/gmd:MD_DataIdentification/gmd:extent/gmd:EX_Extent/gmd:geographicElement/gmd:EX_GeographicBoundingBox[" + i.ToString() + "]/gmd:eastBoundLongitude/gco:Decimal");
                    expr.SetContext(manager);
                    iterator = nav.Select(expr);
                    while (iterator.MoveNext())
                    {
                        XPathNavigator nav2 = iterator.Current.Clone();
                        tmp += ";" + nav2.Value.ToString();
                    }

                    expr = nav.Compile("/gmd:MD_Metadata/gmd:identificationInfo/gmd:MD_DataIdentification/gmd:extent/gmd:EX_Extent/gmd:geographicElement/gmd:EX_GeographicBoundingBox[" + i.ToString() + "]/gmd:southBoundLatitude/gco:Decimal");
                    expr.SetContext(manager);
                    iterator = nav.Select(expr);
                    while (iterator.MoveNext())
                    {
                        XPathNavigator nav2 = iterator.Current.Clone();
                        tmp += ";" + nav2.Value.ToString();
                    }

                    expr = nav.Compile("/gmd:MD_Metadata/gmd:identificationInfo/gmd:MD_DataIdentification/gmd:extent/gmd:EX_Extent/gmd:geographicElement/gmd:EX_GeographicBoundingBox[" + i.ToString() + "]/gmd:northBoundLatitude/gco:Decimal");
                    expr.SetContext(manager);
                    iterator = nav.Select(expr);
                    while (iterator.MoveNext())
                    {
                        XPathNavigator nav2 = iterator.Current.Clone();
                        tmp += ";" + nav2.Value.ToString();
                    }
                    this.GEO_GeographicExtend.Add(tmp);
                }

                expr = nav.Compile("/gmd:MD_Metadata/gmd:identificationInfo/gmd:MD_DataIdentification/gmd:extent/gmd:EX_Extent/gmd:temporalElement/gmd:EX_TemporalExtent/gmd:extent/gml:TimePeriod");
                expr.SetContext(manager);
                iterator = nav.Select(expr);
                mult = iterator.Count;
                for (int i = 1; i <= mult; i++)
                {
                    expr = nav.Compile("/gmd:MD_Metadata/gmd:identificationInfo/gmd:MD_DataIdentification/gmd:extent/gmd:EX_Extent/gmd:temporalElement/gmd:EX_TemporalExtent/gmd:extent/gml:TimePeriod[" + i.ToString() + "]/gml:beginPosition");
                    expr.SetContext(manager);
                    iterator = nav.Select(expr);
                    while (iterator.MoveNext())
                    {
                        XPathNavigator nav2 = iterator.Current.Clone();
                        tmp = "From " + nav2.Value.ToString();
                    }

                    expr = nav.Compile("/gmd:MD_Metadata/gmd:identificationInfo/gmd:MD_DataIdentification/gmd:extent/gmd:EX_Extent/gmd:temporalElement/gmd:EX_TemporalExtent/gmd:extent/gml:TimePeriod[" + i.ToString() + "]/gml:endPosition");
                    expr.SetContext(manager);
                    iterator = nav.Select(expr);
                    while (iterator.MoveNext())
                    {
                        XPathNavigator nav2 = iterator.Current.Clone();
                        tmp += " To " + nav2.Value.ToString();
                    }
                    this.TMP_TemporalExtend.Add(tmp);
                }

                expr = nav.Compile("/gmd:MD_Metadata/gmd:distributionInfo/gmd:MD_Distribution/gmd:transferOptions/gmd:MD_DigitalTransferOptions/gmd:onLine/gmd:CI_OnlineResource/gmd:linkage/gmd:URL");
                expr.SetContext(manager);
                iterator = nav.Select(expr);
                while (iterator.MoveNext())
                {
                    XPathNavigator nav2 = iterator.Current.Clone();
                    this.ID_ResourceLocator.Add(nav2.Value.ToString());
                }

                /*
                expr = nav.Compile("/gmd:MD_Metadata/gmd:dataQualityInfo/gmd:DQ_DataQuality/gmd:scope/gmd:DQ_Scope/gmd:level/gmd:MD_ScopeCode");
                expr.SetContext(manager);
                iterator = nav.Select(expr);
                while (iterator.MoveNext())
                {
                    XPathNavigator nav2 = iterator.Current.Clone();
                    Console.WriteLine(nav2.Value.ToString());
                }*/

                expr = nav.Compile("/gmd:MD_Metadata/gmd:dataQualityInfo/gmd:DQ_DataQuality/gmd:report");
                expr.SetContext(manager);
                iterator = nav.Select(expr);
                mult = iterator.Count;
                for (int i = 1; i <= mult; i++)
                {
                    expr = nav.Compile("/gmd:MD_Metadata/gmd:dataQualityInfo/gmd:DQ_DataQuality/gmd:report[" + i.ToString() + "]/gmd:DQ_DomainConsistency/gmd:result/gmd:DQ_ConformanceResult/gmd:specification/gmd:CI_Citation/gmd:title/gco:CharacterString");
                    expr.SetContext(manager);
                    iterator = nav.Select(expr);
                    while (iterator.MoveNext())
                    {
                        XPathNavigator nav2 = iterator.Current.Clone();
                        this.CFRM_Title.Add(nav2.Value.ToString());
                    }

                    expr = nav.Compile("/gmd:MD_Metadata/gmd:dataQualityInfo/gmd:DQ_DataQuality/gmd:report[" + i.ToString() + "]/gmd:DQ_DomainConsistency/gmd:result/gmd:DQ_ConformanceResult/gmd:specification/gmd:CI_Citation/gmd:date/gmd:CI_Date/gmd:date/gco:Date");
                    expr.SetContext(manager);
                    iterator = nav.Select(expr);
                    while (iterator.MoveNext())
                    {
                        XPathNavigator nav2 = iterator.Current.Clone();
                        this.CFRM_Date.Add(nav2.Value.ToString());
                    }

                    expr = nav.Compile("/gmd:MD_Metadata/gmd:dataQualityInfo/gmd:DQ_DataQuality/gmd:report[" + i.ToString() + "]/gmd:DQ_DomainConsistency/gmd:result/gmd:DQ_ConformanceResult/gmd:specification/gmd:CI_Citation/gmd:date/gmd:CI_Date/gmd:dateType/gmd:CI_DateTypeCode");
                    expr.SetContext(manager);
                    iterator = nav.Select(expr);
                    while (iterator.MoveNext())
                    {
                        XPathNavigator nav2 = iterator.Current.Clone();
                        this.CFRM_DateType.Add(nav2.Value.ToString());
                    }

                    string result = "";
                    expr = nav.Compile("/gmd:MD_Metadata/gmd:dataQualityInfo/gmd:DQ_DataQuality/gmd:report[" + i.ToString() + "]/gmd:DQ_DomainConsistency/gmd:result/gmd:DQ_ConformanceResult/gmd:pass/gco:Boolean");
                    expr.SetContext(manager);
                    iterator = nav.Select(expr);
                    while (iterator.MoveNext())
                    {
                        XPathNavigator nav2 = iterator.Current.Clone();
                        result = nav2.Value.ToString();
                    }

                    if (result == "") this.CFRM_Degree.Add("Not Evaluated");
                    else if (result == "true") this.CFRM_Degree.Add("Conformant");
                    else if (result == "false") this.CFRM_Degree.Add("Not Conformant");
                }

                expr = nav.Compile("/gmd:MD_Metadata/gmd:dataQualityInfo/gmd:DQ_DataQuality/gmd:lineage/gmd:LI_Lineage/gmd:statement/gco:CharacterString");
                expr.SetContext(manager);
                iterator = nav.Select(expr);
                while (iterator.MoveNext())
                {
                    XPathNavigator nav2 = iterator.Current.Clone();
                    this.QLT_Lineage = nav2.Value.ToString();
                }
            }
            catch
            {
                return false;
            }
            
            return true;
        }

        public string ToCodeList(string orig)
        {
            string dest = "";
            
            switch (orig)
            {
                case "Bulgarian":
                    dest = "bul";
                    break;

                case "Czech":
                    dest = "cze";
                    break;

                case "Danish":
                    dest = "dan";
                    break;

                case "Dutch":
                    dest = "dut";
                    break;

                case "English":
                    dest = "eng";
                    break;

                case "Estonian":
                    dest = "est";
                    break;

                case "Finnish":
                    dest = "fin";
                    break;

                case "French":
                    dest = "fre";
                    break;

                case "German":
                    dest = "ger";
                    break;

                case "Greek":
                    dest = "gre";
                    break;

                case "Hungarian":
                    dest = "hun";
                    break;

                case "Irish":
                    dest = "gle";
                    break;

                case "Italian":
                    dest = "ita";
                    break;

                case "Latvian":
                    dest = "lav";
                    break;

                case "Lithuanian":
                    dest = "lit";
                    break;

                case "Maltese":
                    dest = "mlt";
                    break;

                case "Polish":
                    dest = "pol";
                    break;

                case "Portuguese":
                    dest = "por";
                    break;

                case "Romanian":
                    dest = "rum";
                    break;

                case "Slovak":
                    dest = "slo";
                    break;

                case "Slovenian":
                    dest = "slv";
                    break;

                case "Spanish":
                    dest = "spa";
                    break;

                case "Swedish":
                    dest = "swe";
                    break;

                case "Dataset":
                    dest = "dataset";
                    break;

                case "Series":
                    dest = "series";
                    break;

                case "Service":
                    dest = "service";
                    break;

                case "ResourceProvider":
                    dest = "resourceProvider";
                    break;

                case "Custodian":
                    dest = "custodian";
                    break;

                case "Owner":
                    dest = "owner";
                    break;

                case "User":
                    dest = "user";
                    break;

                case "Distributor":
                    dest = "distributor";
                    break;

                case "Originator":
                    dest = "originator";
                    break;

                case "PointOfContact":
                    dest = "pointOfContact";
                    break;

                case "PrincipalInvestigator":
                    dest = "principalInvestigator";
                    break;

                case "Processor":
                    dest = "processor";
                    break;

                case "Publisher":
                    dest = "publisher";
                    break;

                case "Author":
                    dest = "author";
                    break;

                case "Farming":
                    dest = "farming";
                    break;

                case "Biota":
                    dest = "biota";
                    break;

                case "Boundaries":
                    dest = "boundaries";
                    break;

                case "ClimatologyMeteorologyAtmosphere":
                    dest = "climatologyMeteorologyAtmosphere";
                    break;

                case "Economy":
                    dest = "economy";
                    break;

                case "Elevation":
                    dest = "elevation";
                    break;

                case "Environment":
                    dest = "environment";
                    break;

                case "GeoscientificInformation":
                    dest = "geoscientificInformation";
                    break;

                case "Health":
                    dest = "health";
                    break;

                case "ImageryBaseMapsEarthCover":
                    dest = "imageryBaseMapsEarthCover";
                    break;

                case "IntelligenceMilitary":
                    dest = "intelligenceMilitary";
                    break;

                case "InlandWaters":
                    dest = "inlandWaters";
                    break;

                case "Location":
                    dest = "location";
                    break;

                case "Oceans":
                    dest = "oceans";
                    break;

                case "PlanningCadastre":
                    dest = "planningCadastre";
                    break;

                case "Society":
                    dest = "society";
                    break;

                case "Structure":
                    dest = "structure";
                    break;

                case "Transportation":
                    dest = "transportation";
                    break;

                case "UtilitiesCommunication":
                    dest = "utilitiesCommunication";
                    break;

                default:
                    dest = "";
                    break;

            }

            return dest;
 
        }

        public string ReverseCodeList(string orig)
        {
            string dest = "";

            switch (orig)
            {
                case "bul":
                    dest = "Bulgarian";
                    break;

                case "cze":
                    dest = "Czech";
                    break;

                case "dan":
                    dest = "Danish";
                    break;

                case "dut":
                    dest = "Dutch";
                    break;

                case "eng":
                    dest = "English";
                    break;

                case "est":
                    dest = "Estonian";
                    break;

                case "fin":
                    dest = "Finnish";
                    break;

                case "fre":
                    dest = "French";
                    break;

                case "ger":
                    dest = "German";
                    break;

                case "gre":
                    dest = "Greek";
                    break;

                case "hun":
                    dest = "Hungarian";
                    break;

                case "gle":
                    dest = "Irish";
                    break;

                case "ita":
                    dest = "Italian";
                    break;

                case "lav":
                    dest = "Latvian";
                    break;

                case "lit":
                    dest = "Lithuanian";
                    break;

                case "mlt":
                    dest = "Maltese";
                    break;

                case "pol":
                    dest = "Polish";
                    break;

                case "por":
                    dest = "Portuguese";
                    break;

                case "rum":
                    dest = "Romanian";
                    break;

                case "slo":
                    dest = "Slovak";
                    break;

                case "slv":
                    dest = "Slovenian";
                    break;

                case "spa":
                    dest = "Spanish";
                    break;

                case "swe":
                    dest = "Swedish";
                    break;

                case "dataset":
                    dest = "Dataset";
                    break;

                case "series":
                    dest = "Series";
                    break;

                case "service":
                    dest = "Service";
                    break;

                case "resourceProvider":
                    dest = "ResourceProvider";
                    break;

                case "custodian":
                    dest = "Custodian";
                    break;

                case "owner":
                    dest = "Owner";
                    break;

                case "user":
                    dest = "User";
                    break;

                case "distributor":
                    dest = "Distributor";
                    break;

                case "originator":
                    dest = "Originator";
                    break;

                case "pointOfContact":
                    dest = "PointOfContact";
                    break;

                case "principalInvestigator":
                    dest = "PrincipalInvestigator";
                    break;

                case "processor":
                    dest = "Processor";
                    break;

                case "publisher":
                    dest = "Publisher";
                    break;

                case "author":
                    dest = "Author";
                    break;

                case "farming":
                    dest = "Farming";
                    break;

                case "biota":
                    dest = "Biota";
                    break;

                case "boundaries":
                    dest = "Boundaries";
                    break;

                case "climatologyMeteorologyAtmosphere":
                    dest = "ClimatologyMeteorologyAtmosphere";
                    break;

                case "economy":
                    dest = "Economy";
                    break;

                case "elevation":
                    dest = "Elevation";
                    break;

                case "environment":
                    dest = "Environment";
                    break;

                case "geoscientificInformation":
                    dest = "GeoscientificInformation";
                    break;

                case "health":
                    dest = "Health";
                    break;

                case "imageryBaseMapsEarthCover":
                    dest = "ImageryBaseMapsEarthCover";
                    break;

                case "intelligenceMilitary":
                    dest = "IntelligenceMilitary";
                    break;

                case "inlandWaters":
                    dest = "InlandWaters";
                    break;

                case "location":
                    dest = "Location";
                    break;

                case "oceans":
                    dest = "Oceans";
                    break;

                case "planningCadastre":
                    dest = "PlanningCadastre";
                    break;

                case "society":
                    dest = "Society";
                    break;

                case "structure":
                    dest = "Structure";
                    break;

                case "transportation":
                    dest = "Transportation";
                    break;

                case "utilitiesCommunication":
                    dest = "UtilitiesCommunication";
                    break;

                default:
                    dest = "";
                    break;
            }

            return dest;
            
        }
    }
}
