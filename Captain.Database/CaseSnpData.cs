﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.ComponentModel;
using System.Data;

namespace Captain.DatabaseLayer
{
    [DataObject]
    [Serializable]
    public partial class CaseSnpData
    {
        #region Constants
        //private static readonly string TABLE_NAME = "[dbo].[CASESNP]";
        private static Database _dbFactory = DatabaseFactory.CreateDatabase();
        private static DbCommand _dbCommand;


        #endregion



        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public static DataSet GetCustomQuestionAnswers(string agency, string dep, string program, string year, string app, string seq, string strType)
        {
            DataSet ds;
            Database db;
            string sqlCommand;
            DbCommand dbCommand;

            db = DatabaseFactory.CreateDatabase();
            sqlCommand = "[dbo].[GetCustomQuestionAnswers]";
            dbCommand = db.GetStoredProcCommand(sqlCommand);
            if (agency != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@ACT_AGENCY", agency);
                dbCommand.Parameters.Add(empnoParm);
            }
            if (dep != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@ACT_DEPT", dep);
                dbCommand.Parameters.Add(empnoParm);
            }
            if (program != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@ACT_PROGRAM", program);
                dbCommand.Parameters.Add(empnoParm);
            }
            if (year != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@ACT_YEAR", year);
                dbCommand.Parameters.Add(empnoParm);
            }
            if (app != string.Empty || app != null)
            {
                SqlParameter empnoParm = new SqlParameter("@ACT_APP_NO", app);
                dbCommand.Parameters.Add(empnoParm);
            }
            if (seq != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@ACT_SNP_FAMILY_SEQ", seq);
                dbCommand.Parameters.Add(empnoParm);
            }
            if (strType != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@Type", strType);
                dbCommand.Parameters.Add(empnoParm);
            }

            // Get results.
            ds = db.ExecuteDataSet(dbCommand);
            return ds;
        }


        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public static DataSet GetSERCustomQuestionAnswers(string agency, string dep, string program, string year, string app, string fund, string strType)
        {
            DataSet ds;
            Database db;
            string sqlCommand;
            DbCommand dbCommand;

            db = DatabaseFactory.CreateDatabase();
            sqlCommand = "[dbo].[GetSERCustomQuestionAnswers]";
            dbCommand = db.GetStoredProcCommand(sqlCommand);
            if (agency != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@SER_AGENCY", agency);
                dbCommand.Parameters.Add(empnoParm);
            }
            if (dep != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@SER_DEPT", dep);
                dbCommand.Parameters.Add(empnoParm);
            }
            if (program != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@SER_PROGRAM", program);
                dbCommand.Parameters.Add(empnoParm);
            }
            if (year != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@SER_YEAR", year);
                dbCommand.Parameters.Add(empnoParm);
            }
            if (app != string.Empty || app != null)
            {
                SqlParameter empnoParm = new SqlParameter("@SER_APP_NO", app);
                dbCommand.Parameters.Add(empnoParm);
            }
            if (fund != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@SER_FUND", fund);
                dbCommand.Parameters.Add(empnoParm);
            }
            if (strType != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@Type", strType);
                dbCommand.Parameters.Add(empnoParm);
            }

            // Get results.
            ds = db.ExecuteDataSet(dbCommand);
            return ds;
        }


        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public static DataSet GetCustomQuestionAnswersRank(string agency, string dep, string program, string year, string app, string seq, string strApplicantDetais, string strType)
        {
            DataSet ds;
            Database db;
            string sqlCommand;
            DbCommand dbCommand;

            db = DatabaseFactory.CreateDatabase();
            sqlCommand = "[dbo].[GetCustomQuestionAnswersNew]";
            dbCommand = db.GetStoredProcCommand(sqlCommand);
            if (agency != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@ACT_AGENCY", agency);
                dbCommand.Parameters.Add(empnoParm);
            }
            if (dep != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@ACT_DEPT", dep);
                dbCommand.Parameters.Add(empnoParm);
            }
            if (program != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@ACT_PROGRAM", program);
                dbCommand.Parameters.Add(empnoParm);
            }
            if (year != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@ACT_YEAR", year);
                dbCommand.Parameters.Add(empnoParm);
            }
            if (app != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@ACT_APP_NO", app);
                dbCommand.Parameters.Add(empnoParm);
            }
            if (seq != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@ACT_SNP_FAMILY_SEQ", seq);
                dbCommand.Parameters.Add(empnoParm);
            }
            if (strApplicantDetais != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@ApplicantXml ", strApplicantDetais);
                dbCommand.Parameters.Add(empnoParm);
            }
            if (strType != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@Type ", strType);
                dbCommand.Parameters.Add(empnoParm);
            }

            // Get results.
            ds = db.ExecuteDataSet(dbCommand);
            return ds;
        }


        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public static DataSet GETPREACTIVEQUESXML(string agency, string dep, string program, string year, string strType)
        {
            DataSet ds;
            Database db;
            string sqlCommand;
            DbCommand dbCommand;

            db = DatabaseFactory.CreateDatabase();
            sqlCommand = "[dbo].[GETPREACTIVEQUES]";
            dbCommand = db.GetStoredProcCommand(sqlCommand);
            if (agency != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@AGENCY", agency);
                dbCommand.Parameters.Add(empnoParm);
            }
            if (dep != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@DEPT", dep);
                dbCommand.Parameters.Add(empnoParm);
            }
            if (program != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@PROGRAM", program);
                dbCommand.Parameters.Add(empnoParm);
            }
            if (year != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@YEAR", year);
                dbCommand.Parameters.Add(empnoParm);
            }
            if (strType != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@Type ", strType);
                dbCommand.Parameters.Add(empnoParm);
            }

            // Get results.
            ds = db.ExecuteDataSet(dbCommand);
            return ds;
        }


        public static bool InsertSNPDETAILS(List<SqlParameter> sqlParamList)
        {
            _dbCommand = _dbFactory.GetStoredProcCommand("dbo.InsertSNPDETAILS");
            _dbCommand.CommandTimeout = 1200;
            _dbCommand.Parameters.Clear();
            foreach (SqlParameter sqlPar in sqlParamList)
            {
                _dbCommand.Parameters.Add(sqlPar);
            }
            return _dbFactory.ExecuteNonQuery(_dbCommand) > 0 ? true : false;
        }

        public static bool InsertSNPDETAILSLeanIntake(List<SqlParameter> sqlParamList)
        {
            _dbCommand = _dbFactory.GetStoredProcCommand("dbo.InsertSNPDETAILSPIPIntake");
            _dbCommand.CommandTimeout = 1200;
            _dbCommand.Parameters.Clear();
            foreach (SqlParameter sqlPar in sqlParamList)
            {
                _dbCommand.Parameters.Add(sqlPar);
            }
            return _dbFactory.ExecuteNonQuery(_dbCommand) > 0 ? true : false;
        }


        public static bool DeleteCASESNP(List<SqlParameter> sqlParamList)
        {
            _dbCommand = _dbFactory.GetStoredProcCommand("dbo.DeleteCASESNP");
            _dbCommand.CommandTimeout = 1200;
            _dbCommand.Parameters.Clear();
            foreach (SqlParameter sqlPar in sqlParamList)
            {
                _dbCommand.Parameters.Add(sqlPar);
            }
            return _dbFactory.ExecuteNonQuery(_dbCommand) > 0 ? true : false;
        }

        public static bool InsertUpdateADDCUST(List<SqlParameter> sqlParamList)
        {
            _dbCommand = _dbFactory.GetStoredProcCommand("dbo.InsertUpdateADDCUST");
            _dbCommand.CommandTimeout = 1200;
            _dbCommand.Parameters.Clear();
            foreach (SqlParameter sqlPar in sqlParamList)
            {
                _dbCommand.Parameters.Add(sqlPar);
            }
            return _dbFactory.ExecuteNonQuery(_dbCommand) > 0 ? true : false;
        }

        public static bool InsertUpdateSERCUST(List<SqlParameter> sqlParamList)
        {
            _dbCommand = _dbFactory.GetStoredProcCommand("dbo.InsertUpdateSERCUST");
            _dbCommand.CommandTimeout = 1200;
            _dbCommand.Parameters.Clear();
            foreach (SqlParameter sqlPar in sqlParamList)
            {
                _dbCommand.Parameters.Add(sqlPar);
            }
            return _dbFactory.ExecuteNonQuery(_dbCommand) > 0 ? true : false;
        }

        public static bool InsertUpdatePRESRESP(List<SqlParameter> sqlParamList)
        {
            _dbCommand = _dbFactory.GetStoredProcCommand("dbo.InsertUpdatePRESRESP");
            _dbCommand.CommandTimeout = 1200;
            _dbCommand.Parameters.Clear();
            foreach (SqlParameter sqlPar in sqlParamList)
            {
                _dbCommand.Parameters.Add(sqlPar);
            }
            return _dbFactory.ExecuteNonQuery(_dbCommand) > 0 ? true : false;
        }

        public static bool InsertUpdateDIMSCORE(List<SqlParameter> sqlParamList)
        {
            _dbCommand = _dbFactory.GetStoredProcCommand("dbo.InsertUpdateDIMSCORE");
            _dbCommand.CommandTimeout = 1200;
            _dbCommand.Parameters.Clear();
            foreach (SqlParameter sqlPar in sqlParamList)
            {
                _dbCommand.Parameters.Add(sqlPar);
            }
            return _dbFactory.ExecuteNonQuery(_dbCommand) > 0 ? true : false;
        }



        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public static DataSet GetCaseSnpDetails(string agency, string dep, string program, string year, string app, string seq)
        {
            DataSet ds;
            Database db;
            string sqlCommand;
            DbCommand dbCommand;

            db = DatabaseFactory.CreateDatabase();
            sqlCommand = "[dbo].[GetCaseSnpDetails]";
            dbCommand = db.GetStoredProcCommand(sqlCommand);
            dbCommand.CommandTimeout = 1200;

            if (agency != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@SNP_AGENCY", agency);
                dbCommand.Parameters.Add(empnoParm);
            }
            if (dep != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@SNP_DEPT", dep);
                dbCommand.Parameters.Add(empnoParm);
            }
            if (program != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@SNP_PROGRAM", program);
                dbCommand.Parameters.Add(empnoParm);
            }
            if (year != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@SNP_YEAR ", year);
                dbCommand.Parameters.Add(empnoParm);
            }
            if (app != string.Empty || app != null)
            {
                SqlParameter empnoParm = new SqlParameter("@SNP_APP ", app);
                dbCommand.Parameters.Add(empnoParm);
            }
            if (seq != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@SNP_FAMILY_SEQ", seq);
                dbCommand.Parameters.Add(empnoParm);
            }
            ds = db.ExecuteDataSet(dbCommand);
            return ds;
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public static DataSet GetCaseMST(string agency, string dep, string program, string year, string app)
        {
            DataSet ds;
            Database db;
            string sqlCommand;
            DbCommand dbCommand;

            db = DatabaseFactory.CreateDatabase();
            sqlCommand = "[dbo].[GetCASEMST]";
            dbCommand = db.GetStoredProcCommand(sqlCommand);

            if (agency != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@MST_AGENCY", agency);
                dbCommand.Parameters.Add(empnoParm);
            }

            if (dep != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@MST_DEPT", dep);
                dbCommand.Parameters.Add(empnoParm);
            }

            if (program != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@MST_PROGRAM", program);
                dbCommand.Parameters.Add(empnoParm);
            }
            //if (year != string.Empty)
            //{
            SqlParameter empnoParm1 = new SqlParameter("@MST_YEAR", year);
            dbCommand.Parameters.Add(empnoParm1);
            //}

            if (app != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@MST_APP_NO", app);
                dbCommand.Parameters.Add(empnoParm);
            }
            ds = db.ExecuteDataSet(dbCommand);
            return ds;
        }


        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public static DataSet GetLPMQ0001(string agency, string dep, string program, string year, string Heatsource)
        {
            DataSet ds;
            Database db;
            string sqlCommand;
            DbCommand dbCommand;

            db = DatabaseFactory.CreateDatabase();
            sqlCommand = "[dbo].[LPMQ0001]";
            dbCommand = db.GetStoredProcCommand(sqlCommand);

            if (agency != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@MST_AGENCY", agency);
                dbCommand.Parameters.Add(empnoParm);
            }

            if (dep != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@MST_DEPT", dep);
                dbCommand.Parameters.Add(empnoParm);
            }

            if (program != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@MST_PROGRAM", program);
                dbCommand.Parameters.Add(empnoParm);
            }
            if (year != string.Empty)
            {
                SqlParameter empnoParm1 = new SqlParameter("@MST_YEAR", year);
                dbCommand.Parameters.Add(empnoParm1);
            }

            if (Heatsource != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@HEATSOURCE", Heatsource);
                dbCommand.Parameters.Add(empnoParm);
            }
            ds = db.ExecuteDataSet(dbCommand);
            return ds;
        }


        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public static DataSet SSNSearch(string searchFor, string SSN, string firstName, string lastName, string HN, string street, string city, string state, string phone, string alias, string isDuplicate, string Agency, string Dept, string Prog, string Year, string userName, string Hierachy,string strDob)
        {
            DataSet ds;
            Database db;
            string sqlCommand;
            DbCommand dbCommand;

            db = DatabaseFactory.CreateDatabase();
            sqlCommand = "[dbo].[SSNSearch]";
            dbCommand = db.GetStoredProcCommand(sqlCommand);
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            if (searchFor != string.Empty)
            {
                SqlParameter sqlSearchFor = new SqlParameter("@For", searchFor);
                dbCommand.Parameters.Add(sqlSearchFor);
            }
            if (SSN != string.Empty)
            {
                SqlParameter sqlSsn = new SqlParameter("@Ssn", SSN);
                dbCommand.Parameters.Add(sqlSsn);
            }
            if (firstName != string.Empty)
            {
                SqlParameter sqltmp = new SqlParameter("@FNAME", firstName);
                dbCommand.Parameters.Add(sqltmp);
            }
            if (lastName != string.Empty)
            {
                SqlParameter sqltmp = new SqlParameter("@LNAME", lastName);
                dbCommand.Parameters.Add(sqltmp);
            }
            if (alias != string.Empty)
            {
                SqlParameter sqltmp = new SqlParameter("@ALIAS", alias);
                dbCommand.Parameters.Add(sqltmp);
            }
            if (HN != string.Empty)
            {
                SqlParameter sqltmp = new SqlParameter("@HN", HN);
                dbCommand.Parameters.Add(sqltmp);
            }
            if (street != string.Empty)
            {
                SqlParameter sqltmp = new SqlParameter("@STREET", street);
                dbCommand.Parameters.Add(sqltmp);
            }
            if (city != string.Empty)
            {
                SqlParameter sqltmp = new SqlParameter("@CITY", city);
                dbCommand.Parameters.Add(sqltmp);
            }
            if (state != string.Empty)
            {
                SqlParameter sqltmp = new SqlParameter("@STATE", state);
                dbCommand.Parameters.Add(sqltmp);
            }
            if (phone != string.Empty)
            {
                SqlParameter sqltmp = new SqlParameter("@PHONE", phone);
                dbCommand.Parameters.Add(sqltmp);
            }
            if (isDuplicate != string.Empty)
            {
                SqlParameter sqltmp = new SqlParameter("@SHOWDUPLICATE", isDuplicate);
                dbCommand.Parameters.Add(sqltmp);
            }

            if (Agency != string.Empty)
            {
                SqlParameter sqltmp = new SqlParameter("@Agency", Agency);
                dbCommand.Parameters.Add(sqltmp);
            }
            if (Dept != string.Empty)
            {
                SqlParameter sqltmp = new SqlParameter("@Dept", Dept);
                dbCommand.Parameters.Add(sqltmp);
            }
            if (Prog != string.Empty)
            {
                SqlParameter sqltmp = new SqlParameter("@Prog", Prog);
                dbCommand.Parameters.Add(sqltmp);
            }
            if (Year != string.Empty)
            {
                SqlParameter sqltmp = new SqlParameter("@YEAR", Year);
                dbCommand.Parameters.Add(sqltmp);
            }
            if (userName != string.Empty)
            {
                SqlParameter sqltmp = new SqlParameter("@UserName", userName);
                dbCommand.Parameters.Add(sqltmp);
            }
            if (Hierachy != string.Empty)
            {
                SqlParameter sqltmp = new SqlParameter("@Hierarchy", Hierachy);
                dbCommand.Parameters.Add(sqltmp);
            }
            if (strDob != string.Empty)
            {
                SqlParameter sqltmp = new SqlParameter("@Snp_Dob", strDob);
                dbCommand.Parameters.Add(sqltmp);
            }

            
            ds = db.ExecuteDataSet(dbCommand);
            return ds;
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public static DataSet GetCaseSnpSSNO(string strSSNNO)
        {
            DataSet ds;
            Database db;
            string sqlCommand;
            DbCommand dbCommand;

            db = DatabaseFactory.CreateDatabase();
            sqlCommand = "[dbo].[GetSnpSsno]";
            dbCommand = db.GetStoredProcCommand(sqlCommand);
            if (strSSNNO != string.Empty)
            {
                SqlParameter sqltmp = new SqlParameter("@SNP_SSNO", strSSNNO);
                dbCommand.Parameters.Add(sqltmp);
            }

            ds = db.ExecuteDataSet(dbCommand);
            return ds;
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public static DataSet GetCaseSnpImageUploadDetails(string strssnNO, string strHierachy, string strUserName, string strInccurHie, string strMember, string strDuplicate, string strApp, string strFamilySeq, string strBypassSecrect)
        {
            DataSet ds;
            Database db;
            string sqlCommand;
            DbCommand dbCommand;

            db = DatabaseFactory.CreateDatabase();
            sqlCommand = "[dbo].[ImgUpload_OtherPrograms]";
            dbCommand = db.GetStoredProcCommand(sqlCommand);
            dbCommand.CommandTimeout = 2400;
            //if (strssnNO != string.Empty)
            //{
            //    SqlParameter sqltmp = new SqlParameter("@Ssn", strssnNO);
            //    dbCommand.Parameters.Add(sqltmp);
            //}
            if (strHierachy != string.Empty)
            {
                SqlParameter sqltmp = new SqlParameter("@Hierarchy", strHierachy);
                dbCommand.Parameters.Add(sqltmp);
            }
            if (strApp != string.Empty)
            {
                SqlParameter sqltmp = new SqlParameter("@APP", strApp);
                dbCommand.Parameters.Add(sqltmp);
            }
            if (strFamilySeq != string.Empty)
            {
                SqlParameter sqltmp = new SqlParameter("@Fam_Seq", strFamilySeq);
                dbCommand.Parameters.Add(sqltmp);
            }
            if (strUserName != string.Empty)
            {
                SqlParameter sqltmp = new SqlParameter("@UserName", strUserName);
                dbCommand.Parameters.Add(sqltmp);
            }
            if (strInccurHie != string.Empty)
            {
                SqlParameter sqltmp = new SqlParameter("@Inc_Curr_Hie", strInccurHie);
                dbCommand.Parameters.Add(sqltmp);
            }
            if (strMember != string.Empty)
            {
                SqlParameter sqltmp = new SqlParameter("@Inc_Members", strMember);
                dbCommand.Parameters.Add(sqltmp);
            }
            if (strDuplicate != string.Empty)
            {
                SqlParameter sqltmp = new SqlParameter("@Inc_Duplicates", strDuplicate);
                dbCommand.Parameters.Add(sqltmp);
            }
            if (strBypassSecrect != string.Empty)
            {
                SqlParameter sqltmp = new SqlParameter("@Bypass_Secret_Condition", strBypassSecrect);
                dbCommand.Parameters.Add(sqltmp);
            }

            ds = db.ExecuteDataSet(dbCommand);
            return ds;
        }


        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public static DataSet GETDIMSCORE(string agency, string dep, string program, string year, string app, string strMode, string strAppFilter)
        {
            DataSet ds;
            Database db;
            string sqlCommand;
            DbCommand dbCommand;

            db = DatabaseFactory.CreateDatabase();
            sqlCommand = "[dbo].[GETDIMSCORE]";
            dbCommand = db.GetStoredProcCommand(sqlCommand);
            dbCommand.CommandTimeout = 1800;

            if (agency != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@DIMSCOR_AGENCY", agency);
                dbCommand.Parameters.Add(empnoParm);
            }
            if (dep != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@DIMSCOR_DEPT", dep);
                dbCommand.Parameters.Add(empnoParm);
            }
            if (program != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@DIMSCOR_PROGRAM", program);
                dbCommand.Parameters.Add(empnoParm);
            }
            if (year != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@DIMSCOR_YEAR ", year);
                dbCommand.Parameters.Add(empnoParm);
            }
            if (app != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@DIMSCOR_APP_NO", app);
                dbCommand.Parameters.Add(empnoParm);
            }
            if (strMode != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@Mode", strMode);
                dbCommand.Parameters.Add(empnoParm);
            }
            if (strAppFilter != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@FilterApp", strAppFilter);
                dbCommand.Parameters.Add(empnoParm);
            }

            ds = db.ExecuteDataSet(dbCommand);
            return ds;
        }

        public static DataSet GETDIMSCORE(string agency, string dep, string program, string year, string app, string strMode, string strAppFilter, string strFrom, string strTo, string strDimensioncode, string strGroupcode, string strFromdate, string strTodate)
        {
            DataSet ds;
            Database db;
            string sqlCommand;
            DbCommand dbCommand;

            db = DatabaseFactory.CreateDatabase();
            sqlCommand = "[dbo].[GETDIMSCORE]";
            dbCommand = db.GetStoredProcCommand(sqlCommand);
            dbCommand.CommandTimeout = 1800;

            if (agency != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@DIMSCOR_AGENCY", agency);
                dbCommand.Parameters.Add(empnoParm);
            }
            if (dep != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@DIMSCOR_DEPT", dep);
                dbCommand.Parameters.Add(empnoParm);
            }
            if (program != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@DIMSCOR_PROGRAM", program);
                dbCommand.Parameters.Add(empnoParm);
            }
            if (year != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@DIMSCOR_YEAR ", year);
                dbCommand.Parameters.Add(empnoParm);
            }
            if (app != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@DIMSCOR_APP_NO", app);
                dbCommand.Parameters.Add(empnoParm);
            }
            if (strMode != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@Mode", strMode);
                dbCommand.Parameters.Add(empnoParm);
            }
            if (strAppFilter != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@FilterApp", strAppFilter);
                dbCommand.Parameters.Add(empnoParm);
            }
            if (strFrom != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@From", strFrom);
                dbCommand.Parameters.Add(empnoParm);
            }
            if (strTo != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@To", strTo);
                dbCommand.Parameters.Add(empnoParm);
            }
            if (strDimensioncode != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@DIMSCOR_CODE", strDimensioncode);
                dbCommand.Parameters.Add(empnoParm);
            }
            if (strGroupcode != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@GroupCode", strGroupcode);
                dbCommand.Parameters.Add(empnoParm);
            }
            if (strFromdate != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@Fromdate", strFromdate);
                dbCommand.Parameters.Add(empnoParm);
            }
            if (strTodate != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@ToDate", strTodate);
                dbCommand.Parameters.Add(empnoParm);
            }
            ds = db.ExecuteDataSet(dbCommand);
            return ds;
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public static DataSet GetCase0008_REPORT(string agency, string dep, string program, string year, string Fromdate,string Todate)
        {
            DataSet ds;
            Database db;
            string sqlCommand;
            DbCommand dbCommand;

            db = DatabaseFactory.CreateDatabase();
            sqlCommand = "[dbo].[CASE0008_Report]";
            dbCommand = db.GetStoredProcCommand(sqlCommand);
            dbCommand.CommandTimeout = 2400;

            if (agency != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@MST_AGENCY", agency);
                dbCommand.Parameters.Add(empnoParm);
            }

            if (dep != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@MST_DEPT", dep);
                dbCommand.Parameters.Add(empnoParm);
            }

            if (program != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@MST_PROGRAM", program);
                dbCommand.Parameters.Add(empnoParm);
            }
            if (year != string.Empty)
            {
                SqlParameter empnoParm1 = new SqlParameter("@MST_YEAR", year);
                dbCommand.Parameters.Add(empnoParm1);
            }

            if (Fromdate != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@FROM_DATE", Fromdate);
                dbCommand.Parameters.Add(empnoParm);
            }

            if (Todate != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@TO_DATE", Todate);
                dbCommand.Parameters.Add(empnoParm);
            }

            //if (Curr_Prog != string.Empty)
            //{
            //    SqlParameter empnoParm = new SqlParameter("@CURR_PROG", Curr_Prog);
            //    dbCommand.Parameters.Add(empnoParm);
            //}

            ds = db.ExecuteDataSet(dbCommand);
            return ds;
        }


        public static bool DELETEAPP_ALLTABLESDATA(List<SqlParameter> sqlParamList)
        {
            _dbCommand = _dbFactory.GetStoredProcCommand("dbo.DELETEAPP_ALLTABLESDATA");
            _dbCommand.CommandTimeout = 1200;
            _dbCommand.Parameters.Clear();
            foreach (SqlParameter sqlPar in sqlParamList)
            {
                _dbCommand.Parameters.Add(sqlPar);
            }
            return _dbFactory.ExecuteNonQuery(_dbCommand) > 0 ? true : false;
        }

    }
}
