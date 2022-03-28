using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;

namespace Captain.DatabaseLayer
{


    [DataObject]
    [Serializable]
  public  class TMSAllDB
    {
        #region Constants
        //private static readonly string TABLE_NAME = "[dbo].[Notice]";
        private static Database _dbFactory = DatabaseFactory.CreateDatabase();
        //private static DbCommand _dbCommand;


        #endregion

      [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public static DataSet GETNOTICE(string agency, string dep, string program, string year, string app, string byProg,string Type)
      {
          DataSet ds;
          Database db;
          string sqlCommand;
          DbCommand dbCommand;

          db = DatabaseFactory.CreateDatabase();
          sqlCommand = "[dbo].[GETNOTICE]";
          dbCommand = db.GetStoredProcCommand(sqlCommand);

          if (agency != string.Empty)
          {
              SqlParameter empnoParm = new SqlParameter("@VDN_AGENCY", agency);
              dbCommand.Parameters.Add(empnoParm);
          }
          if (dep != string.Empty)
          {
              SqlParameter empnoParm = new SqlParameter("@VDN_DEPT", dep);
              dbCommand.Parameters.Add(empnoParm);
          }
          if (program != string.Empty)
          {
              SqlParameter empnoParm = new SqlParameter("@VDN_PROGRAM", program);
              dbCommand.Parameters.Add(empnoParm);
          }
          if (year != string.Empty)
          {
              SqlParameter empnoParm = new SqlParameter("@VDN_YEAR ", year);
              dbCommand.Parameters.Add(empnoParm);
          }
          if (app != string.Empty)
          {
              SqlParameter empnoParm = new SqlParameter("@VDN_APP_NO ", app);
              dbCommand.Parameters.Add(empnoParm);
          }
          if (byProg != string.Empty)
          {
              SqlParameter empnoParm = new SqlParameter("@VDN_BY_PROG", byProg);
              dbCommand.Parameters.Add(empnoParm);
          }
          if (Type != string.Empty)
          {
              SqlParameter empnoParm = new SqlParameter("@VDN_TYPE", Type);
              dbCommand.Parameters.Add(empnoParm);
          }
          
          ds = db.ExecuteDataSet(dbCommand);
          return ds;
      }


      [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
      public static DataSet GETTMSB4015(string agency, string dep, string program, string year, string FromDate, string Todate)
      {
          DataSet ds;
          Database db;
          string sqlCommand;
          DbCommand dbCommand;

          db = DatabaseFactory.CreateDatabase();
          sqlCommand = "[dbo].[TMSB4015_Report_New]";
          dbCommand = db.GetStoredProcCommand(sqlCommand);

          if (agency != string.Empty)
          {
              SqlParameter empnoParm = new SqlParameter("@LPB_AGENCY", agency);
              dbCommand.Parameters.Add(empnoParm);
          }
          if (dep != string.Empty)
          {
              SqlParameter empnoParm = new SqlParameter("@LPB_DEPT", dep);
              dbCommand.Parameters.Add(empnoParm);
          }
          if (program != string.Empty)
          {
              SqlParameter empnoParm = new SqlParameter("@LPB_PROG", program);
              dbCommand.Parameters.Add(empnoParm);
          }
          if (year != string.Empty)
          {
              SqlParameter empnoParm = new SqlParameter("@LPB_YEAR", year);
              dbCommand.Parameters.Add(empnoParm);
          }
          if (FromDate != string.Empty)
          {
              SqlParameter empnoParm = new SqlParameter("@FROM_DATE", FromDate);
              dbCommand.Parameters.Add(empnoParm);
          }
          if (Todate != string.Empty)
          {
              SqlParameter empnoParm = new SqlParameter("@TO_DATE", Todate);
              dbCommand.Parameters.Add(empnoParm);
          }
          

          ds = db.ExecuteDataSet(dbCommand);
          return ds;
      }

      [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
      public static DataSet GETTMSB4003(string agency, string dep, string program, string year, string FromDate, string Todate,string Disable,string Elder,string selsite,string seltown)
      {
          DataSet ds;
          Database db;
          string sqlCommand;
          DbCommand dbCommand;

          db = DatabaseFactory.CreateDatabase();
          sqlCommand = "[dbo].[TMSB4003_REPORT]";
          dbCommand = db.GetStoredProcCommand(sqlCommand);
          dbCommand.CommandTimeout = 1200;

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
          if (FromDate != string.Empty)
          {
              SqlParameter empnoParm = new SqlParameter("@FromDate", FromDate);
              dbCommand.Parameters.Add(empnoParm);
          }
          if (Todate != string.Empty)
          {
              SqlParameter empnoParm = new SqlParameter("@ToDate", Todate);
              dbCommand.Parameters.Add(empnoParm);
          }

          if (Disable != string.Empty)
          {
              SqlParameter empnoParm = new SqlParameter("@DISABLE", Disable);
              dbCommand.Parameters.Add(empnoParm);
          }
          if (Elder != string.Empty)
          {
              SqlParameter empnoParm = new SqlParameter("@ELDER", Elder);
              dbCommand.Parameters.Add(empnoParm);
          }

          if (selsite != string.Empty)
          {
              SqlParameter empnoParm = new SqlParameter("@SelSite", selsite);
              dbCommand.Parameters.Add(empnoParm);
          }
          if (seltown != string.Empty)
          {
              SqlParameter empnoParm = new SqlParameter("@seltown", seltown);
              dbCommand.Parameters.Add(empnoParm);
          }

          ds = db.ExecuteDataSet(dbCommand);
          return ds;
      }


      [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
      public static DataSet GETTMSB4005(string agency, string dep, string program, string year)
      {
          DataSet ds;
          Database db;
          string sqlCommand;
          DbCommand dbCommand;

          db = DatabaseFactory.CreateDatabase();
          sqlCommand = "[dbo].[TMSB4005_Report]";
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
          //if (FromDate != string.Empty)
          //{
          //    SqlParameter empnoParm = new SqlParameter("@FromDate", FromDate);
          //    dbCommand.Parameters.Add(empnoParm);
          //}
          //if (Todate != string.Empty)
          //{
          //    SqlParameter empnoParm = new SqlParameter("@ToDate", Todate);
          //    dbCommand.Parameters.Add(empnoParm);
          //}

          //if (Disable != string.Empty)
          //{
          //    SqlParameter empnoParm = new SqlParameter("@DISABLE", Disable);
          //    dbCommand.Parameters.Add(empnoParm);
          //}
          //if (Elder != string.Empty)
          //{
          //    SqlParameter empnoParm = new SqlParameter("@ELDER", Elder);
          //    dbCommand.Parameters.Add(empnoParm);
          //}

          //if (selsite != string.Empty)
          //{
          //    SqlParameter empnoParm = new SqlParameter("@SelSite", selsite);
          //    dbCommand.Parameters.Add(empnoParm);
          //}
          //if (seltown != string.Empty)
          //{
          //    SqlParameter empnoParm = new SqlParameter("@seltown", seltown);
          //    dbCommand.Parameters.Add(empnoParm);
          //}

          ds = db.ExecuteDataSet(dbCommand);
          return ds;
      }

      [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
      public static DataSet GETTMSB4004(string agency, string dep, string program, string year,string Site)
      {
          DataSet ds;
          Database db;
          string sqlCommand;
          DbCommand dbCommand;

          db = DatabaseFactory.CreateDatabase();
          sqlCommand = "[dbo].[TMSB4004_Report]";
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
              SqlParameter empnoParm = new SqlParameter("@PROG", program);
              dbCommand.Parameters.Add(empnoParm);
          }
          if (year != string.Empty)
          {
              SqlParameter empnoParm = new SqlParameter("@YEAR", year);
              dbCommand.Parameters.Add(empnoParm);
          }
          if (Site != string.Empty)
          {
              SqlParameter empnoParm = new SqlParameter("@Site", Site);
              dbCommand.Parameters.Add(empnoParm);
          }
          //if (Todate != string.Empty)
          //{
          //    SqlParameter empnoParm = new SqlParameter("@ToDate", Todate);
          //    dbCommand.Parameters.Add(empnoParm);
          //}

          //if (Disable != string.Empty)
          //{
          //    SqlParameter empnoParm = new SqlParameter("@DISABLE", Disable);
          //    dbCommand.Parameters.Add(empnoParm);
          //}
          //if (Elder != string.Empty)
          //{
          //    SqlParameter empnoParm = new SqlParameter("@ELDER", Elder);
          //    dbCommand.Parameters.Add(empnoParm);
          //}

          //if (selsite != string.Empty)
          //{
          //    SqlParameter empnoParm = new SqlParameter("@SelSite", selsite);
          //    dbCommand.Parameters.Add(empnoParm);
          //}
          //if (seltown != string.Empty)
          //{
          //    SqlParameter empnoParm = new SqlParameter("@seltown", seltown);
          //    dbCommand.Parameters.Add(empnoParm);
          //}

          ds = db.ExecuteDataSet(dbCommand);
          return ds;
      }

      [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
      public static DataSet GetReRunDates(string agency, string dep, string program, string year,string FormName,string Vendor)
      {
          DataSet ds;
          Database db;
          string sqlCommand;
          DbCommand dbCommand;

          db = DatabaseFactory.CreateDatabase();
          sqlCommand = "[dbo].[Get_ReRundates]";
          dbCommand = db.GetStoredProcCommand(sqlCommand);

          if (agency != string.Empty)
          {
              SqlParameter empnoParm = new SqlParameter("@VDN_AGENCY", agency);
              dbCommand.Parameters.Add(empnoParm);
          }
          if (dep != string.Empty)
          {
              SqlParameter empnoParm = new SqlParameter("@VDN_DEPT", dep);
              dbCommand.Parameters.Add(empnoParm);
          }
          if (program != string.Empty)
          {
              SqlParameter empnoParm = new SqlParameter("@VDN_PROGRAM", program);
              dbCommand.Parameters.Add(empnoParm);
          }
          if (year != string.Empty)
          {
              SqlParameter empnoParm = new SqlParameter("@VDN_YEAR", year);
              dbCommand.Parameters.Add(empnoParm);
          }
          if (FormName != string.Empty)
          {
              SqlParameter empnoParm = new SqlParameter("@VDN_BY_PROG", FormName);
              dbCommand.Parameters.Add(empnoParm);
          }

          if (Vendor != string.Empty)
          {
              SqlParameter empnoParm = new SqlParameter("@VDN_VENDOR", Vendor);
              dbCommand.Parameters.Add(empnoParm);
          }

          ds = db.ExecuteDataSet(dbCommand);
          return ds;
      }


      [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
      public static DataSet GetTMS81PrintReport(string agency, string dep, string program, string year, string appno)
      {
          DataSet ds;
          Database db;
          string sqlCommand;
          DbCommand dbCommand;

          db = DatabaseFactory.CreateDatabase();
          sqlCommand = "[dbo].[TMS81_PrintLetter]";
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
          if (appno != string.Empty)
          {
              SqlParameter empnoParm = new SqlParameter("@APPNO", appno);
              dbCommand.Parameters.Add(empnoParm);
          }

          ds = db.ExecuteDataSet(dbCommand);
          return ds;
      }


      [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
      public static DataSet GetTMSB4010_Bundling(string agency, string dep, string program, string year, string PBR_No)
      {
          DataSet ds;
          Database db;
          string sqlCommand;
          DbCommand dbCommand;

          db = DatabaseFactory.CreateDatabase();
          sqlCommand = "[dbo].[TMSB4010_Bundling]";
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
              SqlParameter empnoParm = new SqlParameter("@PROG", program);
              dbCommand.Parameters.Add(empnoParm);
          }
          if (year != string.Empty)
          {
              SqlParameter empnoParm = new SqlParameter("@YEAR", year);
              dbCommand.Parameters.Add(empnoParm);
          }
          if (PBR_No != string.Empty)
          {
              SqlParameter empnoParm = new SqlParameter("@PBR_NO_N", PBR_No);
              dbCommand.Parameters.Add(empnoParm);
          }

          ds = db.ExecuteDataSet(dbCommand);
          return ds;
      }

      [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
      public static DataSet GetMissing_Check_Apps(string agency, string dep, string program, string year, string PBR_No)
      {
          DataSet ds;
          Database db;
          string sqlCommand;
          DbCommand dbCommand;

          db = DatabaseFactory.CreateDatabase();
          sqlCommand = "[dbo].[Missing_Check_Apps]";
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
              SqlParameter empnoParm = new SqlParameter("@PROG", program);
              dbCommand.Parameters.Add(empnoParm);
          }
          if (year != string.Empty)
          {
              SqlParameter empnoParm = new SqlParameter("@YEAR", year);
              dbCommand.Parameters.Add(empnoParm);
          }
          if (PBR_No != string.Empty)
          {
              SqlParameter empnoParm = new SqlParameter("@PBR_NO_N", PBR_No);
              dbCommand.Parameters.Add(empnoParm);
          }

          ds = db.ExecuteDataSet(dbCommand);
          return ds;
      }

      [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
      public static DataSet BundlingReport(string agency, string dep, string program, string year, string Rep_Type, string frmdt, string Todt, string Client, decimal Amt, string Vendor, string User)
      {
          DataSet ds;
          Database db;
          string sqlCommand;
          DbCommand dbCommand;

          db = DatabaseFactory.CreateDatabase();
          sqlCommand = "[dbo].[Bundling_Report]";
          dbCommand = db.GetStoredProcCommand(sqlCommand);
          dbCommand.CommandTimeout = 1800;

          if (agency != string.Empty)
          {
              SqlParameter empnoParm = new SqlParameter("@Agy", agency);
              dbCommand.Parameters.Add(empnoParm);
          }
          if (dep != string.Empty)
          {
              SqlParameter empnoParm = new SqlParameter("@Dept", dep);
              dbCommand.Parameters.Add(empnoParm);
          }
          if (program != string.Empty)
          {
              SqlParameter empnoParm = new SqlParameter("@Prog", program);
              dbCommand.Parameters.Add(empnoParm);
          }
          if (year != string.Empty)
          {
              SqlParameter empnoParm = new SqlParameter("@Year", year);
              dbCommand.Parameters.Add(empnoParm);
          }
          if (Rep_Type != string.Empty)
          {
              SqlParameter empnoParm = new SqlParameter("@Rep_Type", Rep_Type);
              dbCommand.Parameters.Add(empnoParm);
          }

          if (Client != string.Empty)
          {
              SqlParameter empnoParm = new SqlParameter("@Client_Type", Client);
              dbCommand.Parameters.Add(empnoParm);
          }

          if (Vendor != string.Empty)
          {
              SqlParameter empVend = new SqlParameter("@Sel_Vendor", Vendor);
              dbCommand.Parameters.Add(empVend);
          }

          
          SqlParameter frmdta = new SqlParameter("@From_Date", frmdt);
          dbCommand.Parameters.Add(frmdta);

          SqlParameter todta = new SqlParameter("@To_Date", Todt);
          dbCommand.Parameters.Add(todta);

          //if (string.IsNullOrEmpty(Amt.ToString().Trim()))
          //{
              SqlParameter BAMt = new SqlParameter("@Bundle_Amount", Amt);
              dbCommand.Parameters.Add(BAMt);
          //}

              SqlParameter SqlUser = new SqlParameter("@User", User);
              dbCommand.Parameters.Add(SqlUser);


          ds = db.ExecuteDataSet(dbCommand);
          return ds;
      }

      [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
      public static DataSet GetTMSCHECKDetails(string agency, string dep, string program, string year, string Vendor)
      {
          DataSet ds;
          Database db;
          string sqlCommand;
          DbCommand dbCommand;

          db = DatabaseFactory.CreateDatabase();
          sqlCommand = "[dbo].[TMSBCHCT_FILLCHECK]";
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

          //if (FormName != string.Empty)
          //{
          //    SqlParameter empnoParm = new SqlParameter("@VDN_BY_PROG", FormName);
          //    dbCommand.Parameters.Add(empnoParm);
          //}

          if (Vendor != string.Empty)
          {
              SqlParameter empnoParm = new SqlParameter("@VENDOR", Vendor);
              dbCommand.Parameters.Add(empnoParm);
          }

          ds = db.ExecuteDataSet(dbCommand);
          return ds;
      }

      [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
      public static DataSet GetLoadChecks(string agency, string dep, string program, string year, string Vendor, string Chkdate)
      {
          DataSet ds;
          Database db;
          string sqlCommand;
          DbCommand dbCommand;

          db = DatabaseFactory.CreateDatabase();
          sqlCommand = "[dbo].[TMSBCHCT_LoadChecks]";
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

          

          if (Vendor != string.Empty)
          {
              SqlParameter empnoParm = new SqlParameter("@VENDOR", Vendor);
              dbCommand.Parameters.Add(empnoParm);
          }

          if (Chkdate != string.Empty)
          {
              SqlParameter empnoParm = new SqlParameter("@CHKDATE", Chkdate);
              dbCommand.Parameters.Add(empnoParm);
          }

          ds = db.ExecuteDataSet(dbCommand);
          return ds;
      }


      [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
      public static DataSet GetTMSBRecalc(string agency, string dep, string program, string year, string Update,string User)
      {
          DataSet ds;
          Database db;
          string sqlCommand;
          DbCommand dbCommand;

          db = DatabaseFactory.CreateDatabase();
          sqlCommand = "[dbo].[Recalc_Benefit]";
          dbCommand = db.GetStoredProcCommand(sqlCommand);

          if (agency != string.Empty)
          {
              SqlParameter empnoParm = new SqlParameter("@Agy", agency);
              dbCommand.Parameters.Add(empnoParm);
          }
          if (dep != string.Empty)
          {
              SqlParameter empnoParm = new SqlParameter("@Dept", dep);
              dbCommand.Parameters.Add(empnoParm);
          }
          if (program != string.Empty)
          {
              SqlParameter empnoParm = new SqlParameter("@Prog", program);
              dbCommand.Parameters.Add(empnoParm);
          }
          if (year != string.Empty)
          {
              SqlParameter empnoParm = new SqlParameter("@Year", year);
              dbCommand.Parameters.Add(empnoParm);
          }

          //if (FormName != string.Empty)
          //{
          //    SqlParameter empnoParm = new SqlParameter("@VDN_BY_PROG", FormName);
          //    dbCommand.Parameters.Add(empnoParm);
          //}

          if (Update != string.Empty)
          {
              SqlParameter empnoParm = new SqlParameter("@Update", Update);
              dbCommand.Parameters.Add(empnoParm);
          }
          if (User != string.Empty)
          {
              SqlParameter empnoParm = new SqlParameter("@User", User);
              dbCommand.Parameters.Add(empnoParm);
          }

          ds = db.ExecuteDataSet(dbCommand);
          return ds;
      }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public static DataSet GetTMSB0027Report(string agency, string dep, string program, string year, string Reason, string FromDate,string ToDate,string ReasonCodes)
        {
            DataSet ds;
            Database db;
            string sqlCommand;
            DbCommand dbCommand;

            db = DatabaseFactory.CreateDatabase();
            sqlCommand = "[dbo].[TMSB0027_Report]";
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

            if (Reason != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@Reason", Reason);
                dbCommand.Parameters.Add(empnoParm);
            }

            if (FromDate != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@FROMDATE", FromDate);
                dbCommand.Parameters.Add(empnoParm);
            }
            if (ToDate != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@TODATE", ToDate);
                dbCommand.Parameters.Add(empnoParm);
            }

            if (ReasonCodes != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@Reason_Filter_Codes", ReasonCodes);
                dbCommand.Parameters.Add(empnoParm);
            }

            ds = db.ExecuteDataSet(dbCommand);
            return ds;
        }


        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
      public static DataSet DelTMSB0044(string agency, string dep, string program, string year)
      {
          DataSet ds;
          Database db;
          string sqlCommand;
          DbCommand dbCommand;

          db = DatabaseFactory.CreateDatabase();
          sqlCommand = "[dbo].[Delete_TMSB0044]";
          dbCommand = db.GetStoredProcCommand(sqlCommand);
          dbCommand.CommandTimeout = 2400;

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

          //if (FormName != string.Empty)
          //{
          //    SqlParameter empnoParm = new SqlParameter("@VDN_BY_PROG", FormName);
          //    dbCommand.Parameters.Add(empnoParm);
          //}

          ds = db.ExecuteDataSet(dbCommand);
          return ds;
      }

      [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
      public static DataSet GetTMSB0044(string agency, string dep, string program, string year)
      {
          DataSet ds;
          Database db;
          string sqlCommand;
          DbCommand dbCommand;

          db = DatabaseFactory.CreateDatabase();
          sqlCommand = "[dbo].[Browse_TMSB0044]";
          dbCommand = db.GetStoredProcCommand(sqlCommand);
          dbCommand.CommandTimeout = 2400;

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

          //if (FormName != string.Empty)
          //{
          //    SqlParameter empnoParm = new SqlParameter("@VDN_BY_PROG", FormName);
          //    dbCommand.Parameters.Add(empnoParm);
          //}

          ds = db.ExecuteDataSet(dbCommand);
          return ds;
      }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public static DataSet UpdateTMSB0044(string agency, string dep, string program, string year, string Appno, string Addoperator, string clearincome, string clearinctypes, string casenotes, string custflds, string PreAss, string Alerts, string LiheapV,string Sites,string Services, string Supplier)
        {
            DataSet ds;
            Database db;
            string sqlCommand;
            DbCommand dbCommand;

            db = DatabaseFactory.CreateDatabase();
            sqlCommand = "[dbo].[Update_TMSB0044]";
            dbCommand = db.GetStoredProcCommand(sqlCommand);
            dbCommand.CommandTimeout = 2400;

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

            if (Appno != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@APPNO", Appno);
                dbCommand.Parameters.Add(empnoParm);
            }

            if (Addoperator != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@ADDOPERATOR", Addoperator);
                dbCommand.Parameters.Add(empnoParm);
            }
            if (clearincome != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@ClearIncome", clearincome);
                dbCommand.Parameters.Add(empnoParm);
            }
            if (clearinctypes != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@ClearIncTypes", clearinctypes);
                dbCommand.Parameters.Add(empnoParm);
            }
            if (casenotes != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@CASENOTES", casenotes);
                dbCommand.Parameters.Add(empnoParm);
            }
            if (custflds != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@CUSTFLDS", custflds);
                dbCommand.Parameters.Add(empnoParm);
            }
            if (PreAss != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@PREASS", PreAss);
                dbCommand.Parameters.Add(empnoParm);
            }
            if (Alerts != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@ALERTS", Alerts);
                dbCommand.Parameters.Add(empnoParm);
            }
            if (LiheapV != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@LIHEAPV", LiheapV);
                dbCommand.Parameters.Add(empnoParm);
            }
            if (Sites != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@SITES", Sites);
                dbCommand.Parameters.Add(empnoParm);
            }

            if (Services != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@SERVICES", Services);
                dbCommand.Parameters.Add(empnoParm);
            }

            if (Supplier != string.Empty)
            {
                SqlParameter empnoParm = new SqlParameter("@SUPPLIER", Supplier);
                dbCommand.Parameters.Add(empnoParm);
            }

            ds = db.ExecuteDataSet(dbCommand);
            return ds;
        }


        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public static DataSet GetTMSELIGData(string agency, string dept, string Prog, string year, string CatElig,string Round)
        {
            DataSet ds;
            Database db;
            string sqlCommand;
            DbCommand dbCommand;

            db = DatabaseFactory.CreateDatabase();
            sqlCommand = "[dbo].[GETTMSELIG]";
            dbCommand = db.GetStoredProcCommand(sqlCommand);
            dbCommand.CommandTimeout = 1200;

            List<SqlParameter> sqlParamList = new List<SqlParameter>();


            SqlParameter sql_agency = new SqlParameter("@TMSELIG_AGENCY", agency);
            dbCommand.Parameters.Add(sql_agency);
            SqlParameter sql_dept = new SqlParameter("@TMSELIG_DEPT", dept);
            dbCommand.Parameters.Add(sql_dept);

            SqlParameter sql_Prog = new SqlParameter("@TMSELIG_PROG", Prog);
            dbCommand.Parameters.Add(sql_Prog);

            SqlParameter sql_year = new SqlParameter("@TMSELIG_YEAR", year);
            dbCommand.Parameters.Add(sql_year);

            SqlParameter sql_county = new SqlParameter("@TMSELIG_CATELIG", CatElig);
            dbCommand.Parameters.Add(sql_county);

            SqlParameter sql_zipcode = new SqlParameter("@TMSELIG_ROUND", Round);
            dbCommand.Parameters.Add(sql_zipcode);

            ds = db.ExecuteDataSet(dbCommand);
            return ds;
        }

    }
}
