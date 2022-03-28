#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Microsoft.Reporting.WebForms;
using System.Data.SqlClient;
using Captain.Common.Model.Data;

#endregion

namespace Captain
{
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
        }
        public bool boolStatus = false;
        public string strReport = string.Empty;
        DataSet thisDataSet = new DataSet();
      
        private void rvViewer_HostedPageLoad(object sender, Gizmox.WebGUI.Forms.Hosts.AspPageEventArgs e)
        {
            if (boolStatus)
            {
                if (strReport == "Sample")
                {
                    rvViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                    rvViewer.LocalReport.ReportPath = Context.Server.MapPath("~\\Reports\\Report1.rdlc");
                }
                else if (strReport == "CAMAST")
                {
                    rvViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                    rvViewer.LocalReport.ReportPath = Context.Server.MapPath("~\\Reports\\Report6.rdlc");

                    //reportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                    //this.reportViewer1.LocalReport.ReportPath = Context.Server.MapPath(@"~\Resources\Report1.rdlc");
                    //btnbool = false;
                    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CMMS"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("Select * from CAMAST", con);

                    DataSet thisDataSet = new DataSet();
                    da.Fill(thisDataSet);
                    ReportDataSource datasource = new ReportDataSource("DataSet1", thisDataSet.Tables[0]);

                    rvViewer.LocalReport.DataSources.Add(datasource);
                    rvViewer.LocalReport.Refresh();
                    boolStatus = false;

                }
                else if (strReport == "Zipcode")
                {
                    rvViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                    rvViewer.LocalReport.ReportPath = Context.Server.MapPath("~\\Reports\\Report7.rdlc");

                    //CaptainDataSourceTableAdapters.ZIPCODETableAdapter objZipcodeTableAdapter = new CaptainDataSourceTableAdapters.ZIPCODETableAdapter();
                    ZipCodeAndAgency objAgency = new ZipCodeAndAgency();
                    
                  //  CaptainDataSource.ZIPCODEDataTable ZipcodeDataTable = new CaptainDataSource.ZIPCODEDataTable();// objZipcodeTableAdapter.GetZIPCODEData();// new CaptainDataSource.ZIPCODEDataTable();


                    ReportDataSource objDataSource = new ReportDataSource("ZipCodeDataset", objAgency.GetZipCodeSearch1(string.Empty, string.Empty, string.Empty, string.Empty).Tables[0]);
                    
                    rvViewer.LocalReport.DataSources.Add(objDataSource);
                    rvViewer.LocalReport.Refresh();
                    boolStatus = false;

                }
                else if (strReport == "AgyTab")
                {
                    rvViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                    rvViewer.LocalReport.ReportPath = Context.Server.MapPath("~\\Reports\\AgyTabReport.rdlc");

                    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CMMS"].ConnectionString);
                    SqlDataAdapter da = new SqlDataAdapter("Select * from AGYTAB", con);

                    DataSet thisDataSet = new DataSet();
                    da.Fill(thisDataSet);
                    ReportDataSource datasource = new ReportDataSource("DataSet1", thisDataSet.Tables[0]);

                    rvViewer.LocalReport.DataSources.Add(datasource);
                    rvViewer.LocalReport.Refresh();                    
                    boolStatus = false;

                }
                else if (strReport == "CaseIncome")
                {
                    rvViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                    rvViewer.LocalReport.ReportPath = Context.Server.MapPath("~\\Reports\\Report9.rdlc");

                    //SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CMMS"].ConnectionString);
                    //SqlCommand cmd = new SqlCommand("GET_INCOME_REPORT", con);
                    //SqlDataAdapter da = new SqlDataAdapter(cmd);
                    //cmd.CommandType = CommandType.StoredProcedure;

                    //DataSet thisDataSet = new DataSet();
                    //da.Fill(thisDataSet);

                    CaptainDataSource objDatasource = new CaptainDataSource();

                    CaptainDataSourceTableAdapters.GET_INCOME_REPORTTableAdapter objtableAdapter = new CaptainDataSourceTableAdapters.GET_INCOME_REPORTTableAdapter();
                    objtableAdapter.Fill(objDatasource.GET_INCOME_REPORT);


                    ReportDataSource datasource = new ReportDataSource("DataSet1", objDatasource.Tables["GET_INCOME_REPORT"]);
                    
                   // , objtableAdapter.GetData().TableName[0]
                    rvViewer.LocalReport.DataSources.Add(datasource);
                    rvViewer.LocalReport.Refresh();                    
                    boolStatus = false;
                }
                else if (strReport == "CaseMST")
                {
                   

                    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CMMS"].ConnectionString);
                    SqlCommand cmd = new SqlCommand("select Top(25) * from caseMst where MST_AGENCY = '03' AND MST_DEPT='01' AND MST_PROGRAM='01' AND MST_YEAR = '2012'", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    cmd.CommandType = CommandType.Text;

                   
                    da.Fill(thisDataSet);

                
            //        ReportDataSource datasource = new ReportDataSource("DataSet1", thisDataSet.Tables[0]);
            //       // ReportParameter[] rptParam = new ReportParameter[5];

            //       for (int i = 0; i < thisDataSet.Tables[0].Rows.Count; i++)
            //{
			 
			
            //            List<ReportParameter> rptParam = new List<ReportParameter>();
            //            rptParam.Add(new ReportParameter("Mst_Agency", thisDataSet.Tables[0].Rows[i]["Mst_Agency"].ToString(), false));
            //            rptParam.Add(new ReportParameter("Mst_Dept", thisDataSet.Tables[0].Rows[i]["Mst_Dept"].ToString(), false));
            //            rptParam.Add(new ReportParameter("Mst_Program", thisDataSet.Tables[0].Rows[i]["Mst_Program"].ToString(), false));
            //            rptParam.Add(new ReportParameter("Mst_Year", thisDataSet.Tables[0].Rows[i]["Mst_Year"].ToString(), false));
            //            rptParam.Add(new ReportParameter("Mst_App_NO", thisDataSet.Tables[0].Rows[i]["Mst_App_NO"].ToString(), false));
            //            rvViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
            //            rvViewer.LocalReport.ReportPath = Context.Server.MapPath("~\\Reports\\CaseMstReport.rdlc");
            //            rvViewer.LocalReport.DataSources.Add(datasource);
            //            rvViewer.LocalReport.SetParameters(rptParam);    
            //            rvViewer.LocalReport.Refresh();
            //        }



                    var reportDataSource = new ReportDataSource("DataSet1", thisDataSet.Tables[0]);
                    rvViewer.LocalReport.EnableExternalImages = true;
                    

                    rvViewer.LocalReport.ReportPath = Context.Server.MapPath("~\\Reports\\CaseMstReport.rdlc");
                    rvViewer.LocalReport.DataSources.Clear();


                    string strimage = "http://localhost:2974/Resources/Images/Banner.bmp";            //Context.Server.MapPath("~\\Resources\\Images\\Banner");

                    
                    List<ReportParameter> rptParam = new List<ReportParameter>();
                    
                    rptParam.Add(new ReportParameter("Mst_Agency", "03", false));
                    //ReportParameter("paramImage", Request.Url.AbsoluteUri.Replace(Request.Url.AbsolutePath, "") + "http://localhost/ToursV2(ToursOnly)/logos/dominion.jpg")
                    rptParam.Add(new ReportParameter("Mst_Dept",  strimage));
                    rptParam.Add(new ReportParameter("Mst_Program", "01aasfdsfsd", true ));
                    rptParam.Add(new ReportParameter("Mst_Year", "2012", false));
                    rptParam.Add(new ReportParameter("Mst_App_NO", "00000002", false));
                    //rvViewer.LocalReport.DataSources.
                    rvViewer.LocalReport.SetParameters(rptParam);
                    rvViewer.LocalReport.DataSources.Add(reportDataSource);
                    this.rvViewer.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing);
                    rvViewer.LocalReport.Refresh();
                    boolStatus = false;



                    //CaptainDataSource objDatasource = new CaptainDataSource();

                    //CaptainDataSourceTableAdapters.GetCASEMSTadpynTableAdapter objtableAdapter = new CaptainDataSourceTableAdapters.GetCASEMSTadpynTableAdapter();
                    //objtableAdapter.Fill(objDatasource.GetCASEMSTadpyn, "03", "01", "01", "2012", "00000002");


                  //objDatasource.Tables["GetCASEMSTadpyn"]);
                   

                    //CaptainDataSourceTableAdapters.GetCASESNPadpynTableAdapter objSnpAdapter = new CaptainDataSourceTableAdapters.GetCASESNPadpynTableAdapter();
                    //objSnpAdapter.Fill(objDataSource.GetCASESNPadpyn, "03", "01", "01", "2012", "00000002");

                   //ReportDataSource datasource = new ReportDataSource("DataSet1", objDataSource.Tables["GetCASESNPadpyn"]);

                   // // , objtableAdapter.GetData().TableName[0]
                  
                  //                
                 
                   
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            rvViewer.Reset();
            strReport = "Sample";
            boolStatus = true;
            rvViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
            rvViewer.LocalReport.ReportPath = Context.Server.MapPath("~\\Reports\\Report1.rdlc");
            rvViewer.Update();            
           
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            rvViewer.Reset();
            boolStatus = true;
            strReport = "CAMAST";
            rvViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
            rvViewer.LocalReport.ReportPath = Context.Server.MapPath("~\\Reports\\Report1.rdlc");
            rvViewer.Update();  
          
        }

        private void btnZipCode_Click(object sender, EventArgs e)
        {
            rvViewer.Reset();
            boolStatus = true;
            strReport = "Zipcode";
            rvViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
            rvViewer.LocalReport.ReportPath = Context.Server.MapPath("~\\Reports\\Report1.rdlc");
            rvViewer.Update();

          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            rvViewer.Reset();
            boolStatus = true;
            strReport = "AgyTab";
            rvViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
            rvViewer.LocalReport.ReportPath = Context.Server.MapPath("~\\Reports\\Report1.rdlc");
            rvViewer.Update();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            rvViewer.Reset();
            boolStatus = true;
            strReport = "CaseIncome";
            rvViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
            rvViewer.LocalReport.ReportPath = Context.Server.MapPath("~\\Reports\\Report1.rdlc");
            rvViewer.Update();
        }
        int ireport = 0;
        void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {

            //CaptainDataSource objDataSource = new CaptainDataSource();
            //CaptainDataSourceTableAdapters.GetCASESNPadpynTableAdapter objSnpAdapter = new CaptainDataSourceTableAdapters.GetCASESNPadpynTableAdapter();
            //objSnpAdapter.Fill(objDataSource.GetCASESNPadpyn,"03","01","01","2012","00000002");
            string strAgency = "03";// e.Parameters["Mst_Agency"].ToString();
            string strDept = "01";//e.Parameters["Mst_Dept"].ToString();
            string strProg = "01"; //e.Parameters["Mst_Program"].ToString();
            string strYear = "2012";//e.Parameters["Mst_Year"].ToString();
            List<string> strAppl = e.Parameters["Mst_ApplNo"].Values.ToList();
            DataSet thisDataSet1 = new DataSet();
            if (thisDataSet != null)
            {

                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CMMS"].ConnectionString);
                SqlCommand cmd = new SqlCommand("select * from CASESNP where SNP_AGENCY = '" + strAgency +"' And SNP_DEPT='" + strDept  + "' AND SNP_PROGRAM='" + strProg + "' AND SNP_YEAR = '" + strYear  + "' ANd SNP_APP ='" + strAppl[0] + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.CommandType = CommandType.Text;

              
                da.Fill(thisDataSet1);

                //CaptainDataSource objDatasource = new CaptainDataSource();

                //CaptainDataSourceTableAdapters.GetCASEMSTadpynTableAdapter objtableAdapter = new CaptainDataSourceTableAdapters.GetCASEMSTadpynTableAdapter();
                //objtableAdapter.Fill(objDatasource.GetCASEMSTadpyn, "03", "01", "01", "2012", "00000002");


              //  ReportDataSource datasource = new ReportDataSource("DataSet1", thisDataSet1.Tables[0]);
                ireport =  ireport+1;
                e.DataSources.Clear();
                //e.ReportPath = Context.Server.MapPath("~\\Reports\\CaseSnpReport.rdlc");
                e.DataSources.Add(new ReportDataSource("DataSet1", thisDataSet1.Tables[0])); // objDataSource.Tables["GetCASESNPadpyn"]));
                
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            rvViewer.Reset();
            boolStatus = true;
            strReport = "CaseMST";
            this.rvViewer.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing);
            rvViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
            rvViewer.LocalReport.ReportPath = Context.Server.MapPath("~\\Reports\\Report1.rdlc");
            rvViewer.Update();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CMMS"].ConnectionString);
            SqlCommand cmd = new SqlCommand("select * from CASESUM", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType.Text;
            DataSet ds = new DataSet();
            da.Fill(ds);
            ds.WriteXml("C:\\casesum.xml");
        }


        private void Test()
        {


            StringBuilder str = new StringBuilder();
           // str.Append("<CaseSum><Details CASESUM_AGENCY = "++" CASESUM_DEPT = "++" CASESUM_PROGRAM= "++" CASESUM_YEAR = "++" CASESUM_APP_NO = "++" CASESUM_SEQ = "++" CASESUM_REF_AGENCY = "++" CASESUM_REF_DEPT = "++" CASESUM_REF_PROGRAM = "++" CASESUM_REFER_BY = "++" CASESUM_REFERDATE = "++" CASESUM_CONTACT_KEY = "++" CASESUM_POINTS = "++" CASESUM_STATUS_CODE = "++" CASESUM_STATUS_DATE = "++" CASESUM_NOT_INTERESTED = "++" CASESUM_LSTC_OPERATOR = "++" CASESUM_ADD_OPERATOR = "++" /></CaseSum>");        
        }
    

    }
}