﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Captain.DatabaseLayer;
using Captain.Common.Model.Objects;
using System.Data.SqlClient;
using System.Data;


namespace Captain.Common.Model.Data
{

    public class ZipCodeAndAgency
    {

        public ZipCodeEntity GetZipcodeByID(string zipcodeId, string zipPlus)
        {
            ZipCodeEntity ZipCodeProfile = null;
            try
            {
                DataSet zipCodeData = ZipCodePlusAgency.GetZipCodeByID(zipcodeId, zipPlus);
                if (zipCodeData != null && zipCodeData.Tables[0].Rows.Count > 0)
                {
                    ZipCodeProfile = new ZipCodeEntity(zipCodeData.Tables[0].Rows[0]);
                }
            }
            catch (Exception ex)
            {
                //
                return ZipCodeProfile;
            }

            return ZipCodeProfile;
        }

        /// <summary>
        /// Get User Profile information. 
        /// </summary>
        /// <param name="userID">The Zipcode ID to get ZipCode.</param>
        /// <returns>Returns a DataSet with the ZipCode's profiles.</returns>
        public bool InsertUpdateDelZIPCODE(ZipCodeEntity zipCode)
        {
            bool boolsuccess;

            try
            {
                List<SqlParameter> sqlParamList = new List<SqlParameter>();
                sqlParamList.Add(new SqlParameter("@ZCR_ZIP", zipCode.Zcrzip));
                sqlParamList.Add(new SqlParameter("@ZCRPLUS_4", zipCode.Zcrplus4));
                if (zipCode.Zcrcity != string.Empty)
                {
                    sqlParamList.Add(new SqlParameter("@ZCR_CITY", zipCode.Zcrcity));
                }
                if (zipCode.Zcrstate != string.Empty)
                {
                    sqlParamList.Add(new SqlParameter("@ZCR_STATE", zipCode.Zcrstate));
                }
                if (zipCode.Zcrcitycode != string.Empty)
                {
                    sqlParamList.Add(new SqlParameter("@ZCR_CITY_CODE", zipCode.Zcrcitycode));
                }
                if (zipCode.Zcrcountry != string.Empty)
                {
                    sqlParamList.Add(new SqlParameter("@ZCR_COUNTY", zipCode.Zcrcountry));
                }
                if (zipCode.Zcrintakecode != string.Empty)
                {
                    sqlParamList.Add(new SqlParameter("@ZCR_INTAKE_CODE", zipCode.Zcrintakecode));
                }
                //sqlParamList.Add(new SqlParameter("@ZCR_DATE", zipCode.Zcrdate));
                if (zipCode.Zcrhssmo != string.Empty)
                {
                    sqlParamList.Add(new SqlParameter("@ZCR_HSS_MO", zipCode.Zcrhssmo));
                }
                if (zipCode.Zcrhssday != string.Empty)
                {
                    sqlParamList.Add(new SqlParameter("@ZCR_HSS_DAY", zipCode.Zcrhssday));
                }
                if (zipCode.Zcrhssyear != string.Empty)
                {
                    sqlParamList.Add(new SqlParameter("@ZCR_HSS_YEAR", zipCode.Zcrhssyear));
                }

                if (zipCode.InActive != string.Empty)
                {
                    sqlParamList.Add(new SqlParameter("@ZCR_INACTIVE", zipCode.InActive));
                }

                sqlParamList.Add(new SqlParameter("@ZCR_APP", zipCode.Zcrapp));
                sqlParamList.Add(new SqlParameter("@ZCR_LSTC_OPERATOR", zipCode.Zcrlstcoperator));

                sqlParamList.Add(new SqlParameter("@ZCR_ADD_OPERATOR", zipCode.Zcraddoperator));
                sqlParamList.Add(new SqlParameter("@Mode", zipCode.Mode));
                boolsuccess = ZipCodePlusAgency.InsertUpdateDelZIPCODE(sqlParamList);
            }
            catch (Exception ex)
            {
                //
                return false;
            }

            return boolsuccess;
        }

        public bool InsertUpdateAGCYCNTL(AgencyControlEntity AgencyControl)
        {
            bool boolsuccess;
            try
            {
                List<SqlParameter> sqlParamList = new List<SqlParameter>();

                sqlParamList.Add(new SqlParameter("@ACR_STREET", AgencyControl.Street));
                sqlParamList.Add(new SqlParameter("@ACR_CITY", AgencyControl.City));
                sqlParamList.Add(new SqlParameter("@ACR_ZIP1", AgencyControl.Zip1));
                sqlParamList.Add(new SqlParameter("@ACR_ZIP2", AgencyControl.Zip2));
                sqlParamList.Add(new SqlParameter("@ACR_STATE", AgencyControl.State));
                sqlParamList.Add(new SqlParameter("@ACR_MAIN_PHONE", AgencyControl.MainPhone));
                sqlParamList.Add(new SqlParameter("@ACR_FAX_NUMBER", AgencyControl.FaxNumbe));
                sqlParamList.Add(new SqlParameter("@ACR_HRS_FROM", AgencyControl.HoursFrom));
                sqlParamList.Add(new SqlParameter("@ACR_HRS_TO", AgencyControl.HoursTo));
                sqlParamList.Add(new SqlParameter("@ACR_VOUCHER_NO", AgencyControl.VoucherNo));
                sqlParamList.Add(new SqlParameter("@ACR_EDIT_ZIP", AgencyControl.EditZip));


                sqlParamList.Add(new SqlParameter("@ACR_CLEAR_CAPREP", AgencyControl.ClearCaprep));
                sqlParamList.Add(new SqlParameter("@ACR_SERVINQ_CASEHIE", AgencyControl.ServinqCaseHie));
                sqlParamList.Add(new SqlParameter("@ACR_CASEMNGR_COMBO", AgencyControl.CasemngrCombo));
                sqlParamList.Add(new SqlParameter("@ACR_SEARCH_DATABASE", AgencyControl.SearchDataBase));

                if (AgencyControl.AgyShortName != string.Empty)
                {
                    sqlParamList.Add(new SqlParameter("@ACR_SHORT_NAME", AgencyControl.AgyShortName));
                }

                if (AgencyControl.AgyName != string.Empty)
                {
                    sqlParamList.Add(new SqlParameter("@ACR_NAME", AgencyControl.AgyName));
                }

                if (AgencyControl.SearchBy != string.Empty)
                {
                    sqlParamList.Add(new SqlParameter("@ACR_SEARCH_BY", AgencyControl.SearchBy));
                }
                if (AgencyControl.SearchFor != string.Empty)
                {
                    sqlParamList.Add(new SqlParameter("@ACR_SEARCH_FOR", AgencyControl.SearchFor));
                }
                if (AgencyControl.SearchCaseType != string.Empty)
                {
                    sqlParamList.Add(new SqlParameter("@ACR_SEARCH_CASETYPE", AgencyControl.SearchCaseType));
                }
                sqlParamList.Add(new SqlParameter("@ACR_PATH", AgencyControl.Path));
                if (AgencyControl.ImportPath != string.Empty)
                {
                    sqlParamList.Add(new SqlParameter("@ACR_IMP_PATH", AgencyControl.ImportPath));
                }
                if (AgencyControl.ExportPath != string.Empty)
                {
                    sqlParamList.Add(new SqlParameter("@ACR_EXP_PATH", AgencyControl.ExportPath));
                }
                if (AgencyControl.AgencyCode != string.Empty)
                {
                    sqlParamList.Add(new SqlParameter("@ACR_AGENCY_CODE", AgencyControl.AgencyCode));
                }
                sqlParamList.Add(new SqlParameter("@ACR_LSTC_OPERATOR", AgencyControl.LastOperator));
                sqlParamList.Add(new SqlParameter("@ACR_ADD_OPERATOR", AgencyControl.AddOperator));
                sqlParamList.Add(new SqlParameter("@Mode", AgencyControl.Mode));
                sqlParamList.Add(new SqlParameter("@ACR_NEXT_SERVICE", int.Parse(AgencyControl.NextService)));
                sqlParamList.Add(new SqlParameter("@ACR_FUEL_TMSB20", AgencyControl.Tmsb20));
                sqlParamList.Add(new SqlParameter("@ACR_XML_HIERARCHY", AgencyControl.XMLHierarchy));
                sqlParamList.Add(new SqlParameter("@ACR_XML_PATH", AgencyControl.XMLPath));
                if (AgencyControl.CAPVoucher != string.Empty)
                    sqlParamList.Add(new SqlParameter("@ACR_CA_PVOUCHER", AgencyControl.CAPVoucher));
                if (AgencyControl.TaxExemption != string.Empty)
                    sqlParamList.Add(new SqlParameter("@ACR_CA_TAX_EXMNO", AgencyControl.TaxExemption));               
                if (AgencyControl.IncVerfication != string.Empty)
                    sqlParamList.Add(new SqlParameter("@ACR_INC_VER", AgencyControl.IncVerfication));
                if (AgencyControl.IncMethods != string.Empty)
                    sqlParamList.Add(new SqlParameter("@ACR_INC_METHODS", AgencyControl.IncMethods));
                if(AgencyControl.MainEXT!=string.Empty)
                    sqlParamList.Add(new SqlParameter("@ACR_MAIN_EXT", AgencyControl.MainEXT));
                if (AgencyControl.CaseNotesstamp != string.Empty)
                    sqlParamList.Add(new SqlParameter("@ACR_CASENOTES_STAMP", AgencyControl.CaseNotesstamp));
                sqlParamList.Add(new SqlParameter("@ACR_ALLOW_CILENT_INQ", AgencyControl.AllowClientINQ));
                if (AgencyControl.MatAssesment != string.Empty)
                    sqlParamList.Add(new SqlParameter("@ACR_MAT_IND_ASSMNTS", AgencyControl.MatAssesment));
                if (AgencyControl.SSN != string.Empty)
                    sqlParamList.Add(new SqlParameter("@ACR_SSN", AgencyControl.SSN));
                if (AgencyControl.DOB != string.Empty)
                    sqlParamList.Add(new SqlParameter("@ACR_DOB", AgencyControl.DOB));
                if (AgencyControl.FirstName != string.Empty)
                    sqlParamList.Add(new SqlParameter("@ACR_FIRSTNAME", AgencyControl.FirstName));
                if (AgencyControl.LastName != string.Empty)
                    sqlParamList.Add(new SqlParameter("@ACR_LASTNAME", AgencyControl.LastName));
                if (AgencyControl.ClientRules != string.Empty)
                    sqlParamList.Add(new SqlParameter("@ACR_CLIENT_RULES", AgencyControl.ClientRules));
                if (AgencyControl.SSNPoint != string.Empty)
                    sqlParamList.Add(new SqlParameter("@ACR_SSN_POINT", AgencyControl.SSNPoint));
                if (AgencyControl.DOBPoint != string.Empty)
                    sqlParamList.Add(new SqlParameter("@ACR_DOB_POINT", AgencyControl.DOBPoint));
                if (AgencyControl.FirstNamePoint != string.Empty)
                    sqlParamList.Add(new SqlParameter("@ACR_FIRSTNAME_POINT", AgencyControl.FirstNamePoint));
                if (AgencyControl.LastNamePoint != string.Empty)
                    sqlParamList.Add(new SqlParameter("@ACR_LASTNAME_POINT", AgencyControl.LastNamePoint));
                if (AgencyControl.DOBLastNamePoint != string.Empty)
                    sqlParamList.Add(new SqlParameter("@ACR_DOBLNAME_POINT", AgencyControl.DOBLastNamePoint));
                //added by sudheer on 02/21/2018
                if (AgencyControl.DOBFirstNamePoint != string.Empty)
                    sqlParamList.Add(new SqlParameter("@ACR_DOBFNAME_POINT", AgencyControl.DOBFirstNamePoint));
                if (AgencyControl.SSNLastNamePoint != string.Empty)
                    sqlParamList.Add(new SqlParameter("@ACR_SSNLNAME_POINT", AgencyControl.SSNLastNamePoint));
                if (AgencyControl.RefConn != string.Empty)
                    sqlParamList.Add(new SqlParameter("@ACR_REF_CONN", AgencyControl.RefConn));
                if (AgencyControl.SearchHit != string.Empty)
                    sqlParamList.Add(new SqlParameter("@ACR_SEARCH_HIT", AgencyControl.SearchHit));
                if (AgencyControl.SearchRating != string.Empty)
                    sqlParamList.Add(new SqlParameter("@ACR_SEARCH_RATING", AgencyControl.SearchRating));
                sqlParamList.Add(new SqlParameter("@ACR_SITE_SEC", AgencyControl.SiteSecurity));
                if (AgencyControl.DelAppSwitch != string.Empty)
                    sqlParamList.Add(new SqlParameter("@ACR_APPDEL_SWITCH", AgencyControl.DelAppSwitch));
                if (AgencyControl.DefIntakeDtSwitch != string.Empty)
                    sqlParamList.Add(new SqlParameter("@ACR_INTAKEDT_SWITCH", AgencyControl.DefIntakeDtSwitch));
                if (AgencyControl.VerSwitch != string.Empty)
                    sqlParamList.Add(new SqlParameter("@ACR_INC_VERSWITCH", AgencyControl.VerSwitch));
                if (AgencyControl.CAOBO != string.Empty)
                    sqlParamList.Add(new SqlParameter("@ACR_CAOBO", AgencyControl.CAOBO));
                if (AgencyControl.SearchCurAgySwitch != string.Empty)
                    sqlParamList.Add(new SqlParameter("@ACR_CUR_AGYSWITCH", AgencyControl.SearchCurAgySwitch));
                if (AgencyControl.ProgressNotesSwitch != string.Empty)
                    sqlParamList.Add(new SqlParameter("@ACR_PRONOTES_SWITCH", AgencyControl.ProgressNotesSwitch));
                if (AgencyControl.DeepSearchSwitch != string.Empty)
                    sqlParamList.Add(new SqlParameter("@ACR_DEEP_SEARCH", AgencyControl.DeepSearchSwitch));

                if (AgencyControl.CentralHierarchy != string.Empty)
                    sqlParamList.Add(new SqlParameter("@ACR_CENT_HIE", AgencyControl.CentralHierarchy));

                if (AgencyControl.MailAddressSwitch != string.Empty)
                    sqlParamList.Add(new SqlParameter("@ACR_MAIL_ADSSWITCH", AgencyControl.MailAddressSwitch));

                if (AgencyControl.FTypeSwitch != string.Empty)
                    sqlParamList.Add(new SqlParameter("@ACR_FTYPE_SWITCH", AgencyControl.FTypeSwitch));

                if (AgencyControl.QuickPostServices != string.Empty)
                    sqlParamList.Add(new SqlParameter("@ACR_QK_SER", AgencyControl.QuickPostServices));

                //if (AgencyControl.PaymentVoucherNumber != string.Empty)
                //    sqlParamList.Add(new SqlParameter("@ACR_NXT_VOUCHER", AgencyControl.PaymentVoucherNumber));

                if (AgencyControl.WipeBMALSP != string.Empty)
                    sqlParamList.Add(new SqlParameter("@ACR_WIPE_BMALPS", AgencyControl.WipeBMALSP));

                if (AgencyControl.BenefitFrom != string.Empty)
                    sqlParamList.Add(new SqlParameter("@ACR_BENEFIT_FROM", AgencyControl.BenefitFrom));

                if (AgencyControl.ClidSmash != string.Empty)
                    sqlParamList.Add(new SqlParameter("@ACR_CLID_SMASH", AgencyControl.ClidSmash));

                if (AgencyControl.ClidYear  != string.Empty)
                    sqlParamList.Add(new SqlParameter("@ACR_CLID_YEAR", AgencyControl.ClidYear));

                if (AgencyControl.ClidFrom  != string.Empty)
                    sqlParamList.Add(new SqlParameter("@ACR_CLID_FROM", AgencyControl.ClidFrom));

                if (AgencyControl.ClidTo  != string.Empty)
                    sqlParamList.Add(new SqlParameter("@ACR_CLID_TO", AgencyControl.ClidTo));

                if (AgencyControl.ClidSSN != string.Empty)
                    sqlParamList.Add(new SqlParameter("@ACR_CLID_SSN", AgencyControl.ClidSSN));

                if (AgencyControl.ClidClid != string.Empty)
                    sqlParamList.Add(new SqlParameter("@ACR_CLID_CLID", AgencyControl.ClidClid));

                if (AgencyControl.ClidDateStamp != string.Empty)
                    sqlParamList.Add(new SqlParameter("@ACR_CLID_DATESTAMP", AgencyControl.ClidDateStamp));

                if (AgencyControl.ClidDateStamp != string.Empty)
                    sqlParamList.Add(new SqlParameter("@ACR_FIXFAMID_HIE", AgencyControl.FamilyIdHie));

                if (AgencyControl.ClidDateStamp != string.Empty)
                    sqlParamList.Add(new SqlParameter("@ACR_FIXFAMID_DUPLVL", AgencyControl.FamilyIdDuplvl));

                if (AgencyControl.MemberActivity != string.Empty)
                    sqlParamList.Add(new SqlParameter("@ACR_MEM_ACTIVTY", AgencyControl.MemberActivity));

                if (AgencyControl.TMS201SoftEdit != string.Empty)
                    sqlParamList.Add(new SqlParameter("@ACR_VEND_ACCT_SOFT_EDIT", AgencyControl.TMS201SoftEdit));
                if (AgencyControl.ShowIntakeSwitch != string.Empty)
                    sqlParamList.Add(new SqlParameter("@ACR_SHOW_INTHIE", AgencyControl.ShowIntakeSwitch));
                if (AgencyControl.MostRecentintake != string.Empty)
                    sqlParamList.Add(new SqlParameter("@ACR_RECENT_INTAKE", AgencyControl.MostRecentintake));
                if (AgencyControl.ServicePlanHiecontrol != string.Empty)
                    sqlParamList.Add(new SqlParameter("@ACR_SERPLAN_HIES", AgencyControl.ServicePlanHiecontrol));
                if (AgencyControl.LoginMFA != string.Empty)
                    sqlParamList.Add(new SqlParameter("@ACR_LOGIN_MFA", AgencyControl.LoginMFA));
                if (AgencyControl.SerPlanAllow != string.Empty)
                    sqlParamList.Add(new SqlParameter("@ACR_SERPLAN_ALLOW", AgencyControl.SerPlanAllow));
                if (AgencyControl.SsnDobMMenu != string.Empty)
                    sqlParamList.Add(new SqlParameter("@ACR_SSNDOB_MMENU", AgencyControl.SsnDobMMenu));
                if (AgencyControl.BulkpostTemp != string.Empty)
                    sqlParamList.Add(new SqlParameter("@ACR_BULKPOST_TMPLT", AgencyControl.BulkpostTemp));

                boolsuccess = Captain.DatabaseLayer.ZipCodePlusAgency.InsertUpdateAGCYCNTL(sqlParamList);
            }
            catch (Exception ex)
            {
                return false;
            }

            return boolsuccess;
        }

        public bool UpdateXMLAGCYCNTL(AgencyControlEntity AgencyControl)
        {
            bool boolsuccess;
            try
            {
                List<SqlParameter> sqlParamList = new List<SqlParameter>();

                sqlParamList.Add(new SqlParameter("@ACR_AGENCY_CODE", AgencyControl.AgencyCode));
                if (AgencyControl.AgencySystemID != string.Empty)
                    sqlParamList.Add(new SqlParameter("@ACR_XML_AGENCYSYSTEM_ID", AgencyControl.AgencySystemID));
                if (AgencyControl.AgencyID != string.Empty)
                    sqlParamList.Add(new SqlParameter("@ACR_XML_AGENCY_ID", AgencyControl.AgencyID));
                if (AgencyControl.ForcePwd != string.Empty)
                    sqlParamList.Add(new SqlParameter("@ACR_FORCE_PWD", AgencyControl.ForcePwd));
                if (AgencyControl.ForcePwdDays != string.Empty)
                    sqlParamList.Add(new SqlParameter("@ACR_FORCE_PWD_DAYS", AgencyControl.ForcePwdDays));
                sqlParamList.Add(new SqlParameter("@Mode", AgencyControl.Mode));

                boolsuccess = Captain.DatabaseLayer.ZipCodePlusAgency.UpdateXMLAGCYCNTL(sqlParamList);
            }
            catch (Exception ex)
            {
                return false;
            }

            return boolsuccess;
        }

        public bool ADMN0014_UPD_AGCYCNTL(AgencyControlEntity AgencyControl,string strAttenstation)
        {
            bool boolsuccess;
            try
            {
                List<SqlParameter> sqlParamList = new List<SqlParameter>();

                sqlParamList.Add(new SqlParameter("@ACR_AGENCY_CODE", AgencyControl.AgencyCode));

                if (AgencyControl.ServinqCaseHie != string.Empty)
                    sqlParamList.Add(new SqlParameter("@ACR_SERVINQ_CASEHIE", AgencyControl.ServinqCaseHie));
                if (AgencyControl.RomaSwitch != string.Empty)
                    sqlParamList.Add(new SqlParameter("@ACR_ROMA_SWITCH", AgencyControl.RomaSwitch));
                if (AgencyControl.SpanishSwitch != string.Empty)
                    sqlParamList.Add(new SqlParameter("@ACR_SPAN_SWITCH", AgencyControl.SpanishSwitch));
                if (AgencyControl.PIPSwitch != string.Empty)
                    sqlParamList.Add(new SqlParameter("@ACR_PIP_SWITCH", AgencyControl.PIPSwitch));


                if (AgencyControl.AgencySystemID != string.Empty)
                    sqlParamList.Add(new SqlParameter("@ACR_XML_AGENCYSYSTEM_ID", AgencyControl.AgencySystemID));
                if (AgencyControl.AgencySystemID2 != string.Empty)
                    sqlParamList.Add(new SqlParameter("@ACR_XML_AGENCYSYSTEM_ID2", AgencyControl.AgencySystemID2));
                if (strAttenstation != string.Empty)
                    sqlParamList.Add(new SqlParameter("@ACR_03_ATTESTATION", strAttenstation));
                                
                    sqlParamList.Add(new SqlParameter("@ACR_PAYCAT_SERPOST", AgencyControl.PaymentCategorieService));

                sqlParamList.Add(new SqlParameter("@Mode", AgencyControl.Mode));

                boolsuccess = Captain.DatabaseLayer.ZipCodePlusAgency.ADMN0014_UPD_AGCYCNTL(sqlParamList);
            }
            catch (Exception ex)
            {
                return false;
            }

            return boolsuccess;
        }

        public AgencyControlEntity GetAgencyControlFile(string agencyControl)
        {
            AgencyControlEntity AgencyControlDetails = null;
            try
            {
                DataSet AgencyData = Captain.DatabaseLayer.ZipCodePlusAgency.GetAgencyControlDetails(agencyControl);
                if (AgencyData != null && AgencyData.Tables[0].Rows.Count > 0)
                {
                    AgencyControlDetails = new AgencyControlEntity(AgencyData.Tables[0].Rows[0]);
                }
            }
            catch (Exception ex)
            {
                //
                return AgencyControlDetails;
            }

            return AgencyControlDetails;
        }

        public List<AgencyControlEntity> GetAgencyControlFile()
        {
            List<AgencyControlEntity> AgencyControlDetails = new List<AgencyControlEntity>();
            try
            {
                DataSet AgencyData = Captain.DatabaseLayer.ZipCodePlusAgency.GetAgencyControlDetails(string.Empty);
                if (AgencyData != null && AgencyData.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in AgencyData.Tables[0].Rows)
                    {
                        AgencyControlDetails.Add(new AgencyControlEntity(row));
                    }
                }
            }
            catch (Exception ex)
            {
                //
                return AgencyControlDetails;
            }

            return AgencyControlDetails;
        }

        public List<AgencyControlEntity> GetAgencyControlFileALL()
        {
            List<AgencyControlEntity> AgencyControlDetails = new List<AgencyControlEntity>();
            try
            {
                DataSet AgencyData = DatabaseLayer.ADMNB001DB.ADMNB001_Browse_AGCYCNTL(null, null, null, null, null, null, null);
                if (AgencyData != null && AgencyData.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in AgencyData.Tables[0].Rows)
                    {
                        AgencyControlDetails.Add(new AgencyControlEntity(row));
                    }
                }
            }
            catch (Exception ex)
            {
                //
                return AgencyControlDetails;
            }

            return AgencyControlDetails;
        }
      

        public bool DeleteAGCYCNTL(string AgencyControl)
        {
            try
            {
                List<SqlParameter> sqlParamList = new List<SqlParameter>();
                sqlParamList.Add(new SqlParameter("@ACR_NAME", AgencyControl));
                Captain.DatabaseLayer.ZipCodePlusAgency.DeleteAGCYCNTL(sqlParamList);
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }


        public List<CommonEntity> GetCounty()
        {
            List<CommonEntity> commonEntity = new List<CommonEntity>();
            try
            {

                DataSet County = Captain.DatabaseLayer.ZipCodePlusAgency.GetCounty(); ;
                if (County != null && County.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in County.Tables[0].Rows)
                    {
                        commonEntity.Add(new CommonEntity(row["Agy_3"].ToString(), row["Agy_7"].ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                return commonEntity;
            }

            return commonEntity;
        }

        public List<CommonEntity> GetCity(string strzip, string strcity, string strcounty, string Type)
        {
            List<CommonEntity> commonEntity = new List<CommonEntity>();
            try
            {

                DataSet County = Captain.DatabaseLayer.ZipCodePlusAgency.GetCity(strzip,strcity,strcounty,Type); ;
                if (County != null && County.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in County.Tables[0].Rows)
                    {
                        commonEntity.Add(new CommonEntity(row["SQR_RESP_CODE"].ToString(), row["SQR_RESP_DESC"].ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                return commonEntity;
            }

            return commonEntity;
        }


        public List<CommonEntity> GetTownship()
        {
            List<CommonEntity> commonEntity = new List<CommonEntity>();
            try
            {

                DataSet County = Captain.DatabaseLayer.ZipCodePlusAgency.GetTownship(); ;
                if (County != null && County.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in County.Tables[0].Rows)
                    {
                        commonEntity.Add(new CommonEntity(row["Agy_3"].ToString(), row["Agy_7"].ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                return commonEntity;
            }

            return commonEntity;
        }

        public List<ZipCodeEntity> GetZipCodeSearch(string zipcode, string city, string township, string county)
        {
            List<ZipCodeEntity> ZipCodeEntity = new List<ZipCodeEntity>();
            try
            {
                DataSet zipCodeData = ZipCodePlusAgency.ZipCodeSearch(zipcode, city, township, county);
                if (zipCodeData != null && zipCodeData.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in zipCodeData.Tables[0].Rows)
                    {
                        ZipCodeEntity.Add(new ZipCodeEntity(row, string.Empty));
                    }
                }
            }
            catch (Exception ex)
            {
                //
                return ZipCodeEntity;
            }

            return ZipCodeEntity;
        }

        public DataSet GetZipCodeSearch1(string zipcode, string city, string township, string county)
        {
            DataSet zipCodeData = null;
            List<ZipCodeEntity> ZipCodeEntity = new List<ZipCodeEntity>();
            try
            {
                zipCodeData = ZipCodePlusAgency.ZipCodeSearch(zipcode, city, township, county);
                if (zipCodeData != null && zipCodeData.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in zipCodeData.Tables[0].Rows)
                    {
                        ZipCodeEntity.Add(new ZipCodeEntity(row, string.Empty));
                    }
                }
            }
            catch (Exception ex)
            {
                //
                return zipCodeData;
            }

            return zipCodeData;
        }

        public List<LIHPMQuesEntity> GetLIHPMQuesData(string agytype,string strYear)
        {
            List<LIHPMQuesEntity> Lihpmquesdata = new List<LIHPMQuesEntity>();
            try
            {
                DataSet zipCodeData = ZipCodePlusAgency.GetLihpmpQues(agytype,strYear);
                if (zipCodeData != null && zipCodeData.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in zipCodeData.Tables[0].Rows)
                    {
                        Lihpmquesdata.Add(new LIHPMQuesEntity(row));
                    }
                }
            }
            catch (Exception ex)
            {
                //
                return Lihpmquesdata;
            }

            return Lihpmquesdata;
        }




    }
}