#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Captain.Common.Model.Data;
using Captain.Common.Views.UserControls.Base;
using Captain.Common.Views.Forms.Base;
using Captain.Common.Model.Objects;
using System.Data.SqlClient;
using Microsoft.Reporting.WebForms;
using Captain.Common.Views.Controls;
using Captain.Common.Utilities;
using Captain.DatabaseLayer;
using Captain.Common.Views.Forms;

#endregion

namespace Captain.Common.Views.UserControls
{
    public partial class ReportGridControl1 : UserControl
    {
        #region private variables

        private CaptainModel _model = null;
        public bool blnUseHostedpageLoad = true;
        public bool blnUseHostedpageLoadDetails = true;

        #endregion
        public ReportGridControl1(BaseForm baseForm, PrivilegeEntity privileges, string strReportName)
        {
            InitializeComponent();
            BaseForm = baseForm;
            Privileges = privileges;
            propReportName = strReportName;
            _model = new CaptainModel();
            propReportTabcount = 1;
            fillCombo();            
            fillData();
            blnUseHostedpageLoad = true;
            propUserNames = string.Empty;
           // tabPage1.Hide();
            // blnUseHostedpageLoadDetails = true;
            tabControl1.SelectedIndex = 0;
        }

        #region properties

        public BaseForm BaseForm { get; set; }

        public PrivilegeEntity Privileges { get; set; }

        public string propReportName { get; set; }

        public string propUserNames { get; set; }

        public string propProgrames { get; set; }

        public string propReportType { get; set; }

        public int propReportTabcount { get; set; }

        public DataTable propDatatableUser { get; set; }
        public DataTable propDatatableProgram { get; set; }

        public DataTable propDatatableSummary { get; set; }

        public List<ListItem> propApplication { get; set; }

        #endregion


        private void fillCombo()
        {
            //cmbChartType.Visible = true;
            //lblChartType.Visible = true;
            //cmbChartType.Items.Add(new Captain.Common.Utilities.ListItem("Column", "1"));

            //cmbChartType.Items.Add(new Captain.Common.Utilities.ListItem("Line", "2"));
            //cmbChartType.Items.Add(new Captain.Common.Utilities.ListItem("Shape", "3"));
            //cmbChartType.Items.Add(new Captain.Common.Utilities.ListItem("Bar", "4"));
            //cmbChartType.Items.Add(new Captain.Common.Utilities.ListItem("Area", "5"));
            //cmbChartType.Items.Insert(0, new Captain.Common.Utilities.ListItem("Select One", "0"));
            //cmbChartType.SelectedIndex = 3;

            DataSet ds1 = Captain.DatabaseLayer.ADMNB002DB.GetUserNames();
            DataTable dt1 = ds1.Tables[0];
            List<Captain.Common.Utilities.ListItem> listItem = new List<Captain.Common.Utilities.ListItem>();
            listItem.Clear();
            listItem.Add(new Captain.Common.Utilities.ListItem("All Users", "**"));
            foreach (DataRow dr in dt1.Rows)
            {
                listItem.Add(new Captain.Common.Utilities.ListItem(dr["PWR_EMPLOYEE_NO"].ToString(), dr["PWR_EMPLOYEE_NO"].ToString()));
            }


            DataSet ds = Captain.DatabaseLayer.Lookups.GetModules();
            DataTable dt2 = ds.Tables[0];

            List<ListItem> listApplications = new List<ListItem>();

            foreach (DataRow dr in dt2.Rows)
            {
                listApplications.Add(new Captain.Common.Utilities.ListItem(dr["APPL_DESCRIPTION"].ToString(), dr["APPL_CODE"].ToString()));
            }
            propApplication = listApplications;

            //cmbRepUserId.Items.AddRange(listItem.ToArray());
            //cmbRepUserId.SelectedIndex = 0;

        }

        private void fillData()
        {
            gvwData.CellValueChanged -= new DataGridViewCellEventHandler(gvwData_CellValueChanged);
            DataGridViewComboBoxColumn cb = (DataGridViewComboBoxColumn)this.gvwData.Columns["gvcDatetypes"];

            List<CommonEntity> listDateTypes = new List<CommonEntity>();
            listDateTypes.Add(new CommonEntity("1", "DATE ADD"));
            listDateTypes.Add(new CommonEntity("2", "LSTC DATE"));
            listDateTypes.Add(new CommonEntity("3", "Intake DATE"));

            cb.DataSource = listDateTypes;
            cb.DisplayMember = "DESC";
            cb.ValueMember = "CODE";
            cb = (DataGridViewComboBoxColumn)this.gvwData.Columns["gvcDatetypes"];


            ListItem listheadstart = propApplication.Find(u => u.Value.ToString() == "02" || u.Value.ToString() == "03");

            if (listheadstart != null)
            {
                gvwData.Rows.Add(Img_Tick, "Client Intakes", "1", "Y");
                gvwData.Rows.Add(null, "Household Members", "1", "N");
                gvwData.Rows.Add(null, "Income Verification", "1", "N");
                gvwData.Rows.Add(null, "Enrollment", "1", "N");
                gvwData.Rows.Add(null, "Service Plans", "1", "N");
                gvwData.Rows.Add(null, "Services Activities (CA)", "1", "N");
                gvwData.Rows.Add(null, "Outcome Indicators (MS)", "1", "N");
                gvwData.Rows.Add(null, "Full Assessment Scales Completed", "1", "N");
            }
            ListItem listEnergyassisteance = propApplication.Find(u => u.Value.ToString() == "08");
            if (listEnergyassisteance != null)
            {
                gvwData.Rows.Add(null, "Fuel Assistance Supplier Data", "1", "N");
                gvwData.Rows.Add(null, "Fuel Assistance Benefit Data", "1", "N");
                gvwData.Rows.Add(null, "Fuel Assistance Payments", "1", "N");
            }
            ListItem listems = propApplication.Find(u => u.Value.ToString() == "05");
            if (listems != null)
            {
                gvwData.Rows.Add(null, "Emergency Services(Resource Records)", "1", "N");
                gvwData.Rows.Add(null, "Emergency Services(Invoices/Authorizations)", "1", "N");
            }
            gvwData.CellValueChanged += new DataGridViewCellEventHandler(gvwData_CellValueChanged);


        }

        void gvwData_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            gvwData.CellValueChanged -= new DataGridViewCellEventHandler(gvwData_CellValueChanged);
            if (e.ColumnIndex == gvcDatetypes.Index)
            {
                int introwindex = gvwData.CurrentCell.RowIndex;
                string strDateTypeValue = Convert.ToString(gvwData.Rows[introwindex].Cells["gvcDatetypes"].Value);
                string strtableName = Convert.ToString(gvwData.Rows[introwindex].Cells["gvtTableName"].Value);
                if (strDateTypeValue == "3" && strtableName.ToUpper() != "CLIENT INTAKES")
                {
                    CommonFunctions.MessageBoxDisplay("Intake Date Does Not Select this " + strtableName + " table.");
                    gvwData.Rows[introwindex].Cells["gvcDatetypes"].Value = "1";
                }
            }
            gvwData.CellValueChanged += new DataGridViewCellEventHandler(gvwData_CellValueChanged);
        }

        Gizmox.WebGUI.Common.Resources.ResourceHandle Img_Blank = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle("Blank.JPG");
        Gizmox.WebGUI.Common.Resources.ResourceHandle Img_Tick = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle("tick.ico");


        private void gvwData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gvwData.Rows.Count > 0 && e.RowIndex != -1)
            {
                int ColIdx = gvwData.CurrentCell.ColumnIndex;
                int RowIdx = gvwData.CurrentCell.RowIndex;

                if (gviImg.Index == ColIdx)
                {
                    if (e.ColumnIndex == 0)//&& (Mode.Equals("Add") || Mode.Equals("Edit")))
                    {
                        if (gvwData.CurrentRow.Cells["gvtSelect"].Value.ToString() == "Y")
                        {
                            gvwData.CurrentRow.Cells["gviImg"].Value = Img_Blank;
                            gvwData.CurrentRow.Cells["gvtSelect"].Value = "N";

                            //Selected_Col_Count--;

                            //Delete_SelCol_From_List();


                        }
                        else
                        {
                            gvwData.CurrentRow.Cells["gviImg"].Value = Img_Tick;
                            gvwData.CurrentRow.Cells["gvtSelect"].Value = "Y";


                        }
                    }
                }

            }



        }


        public void GetReportDataDetails()
        {
            try
            {

                reportViewer2.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                reportViewer2.LocalReport.ReportPath = @"SSRS\Reports\ProgramWisereport.rdlc";//UserWiseData.rdl";


                string strUserId = string.Empty;
                string strStartDate = string.Empty;
                string strEndDate = string.Empty;
                string strType = string.Empty;

                if (dtStartDate.Checked)
                {
                    strStartDate = dtStartDate.Value.ToShortDateString();
                    strEndDate = DateTime.Now.ToShortDateString();
                    if (dtEndDate.Checked)
                        strEndDate = dtEndDate.Value.ToShortDateString();
                }
                StringBuilder str = new StringBuilder();
                str.Append("<TABLE>");
                string strAddDate, strLstcDate, strIntakeDate, strCertifiedDt = string.Empty;
                foreach (DataGridViewRow item in gvwData.Rows)
                {

                    if (item.Cells["gvtSelect"].Value == "Y")
                    {
                        str.Append("<Details>");

                        str.Append("<TBNAME>" + GetTableName(item.Cells["gvtTableName"].Value.ToString()) + "</TBNAME>");

                        strAddDate = strLstcDate = strIntakeDate = strCertifiedDt = string.Empty;
                        if (dtStartDate.Checked == true)
                        {
                            if (item.Cells["gvcDatetypes"].Value == "1")
                            {
                                strAddDate = dtStartDate.Value.ToShortDateString();
                            }
                            if (item.Cells["gvcDatetypes"].Value == "2")
                            {
                                strLstcDate = dtStartDate.Value.ToShortDateString();
                            }
                            if (item.Cells["gvcDatetypes"].Value == "3")
                            {
                                strIntakeDate = dtStartDate.Value.ToShortDateString();
                            }


                            if (strAddDate != string.Empty)
                            {
                                str.Append("<TBAddStartDate>" + strAddDate + "</TBAddStartDate>");
                                str.Append("<TBAddEndDate>" + strEndDate + "</TBAddEndDate>");
                            }
                            else if (strLstcDate != string.Empty)
                            {
                                str.Append("<TBLstcStartDate>" + strLstcDate + "</TBLstcStartDate>");
                                str.Append("<TBLstcEndDate>" + strEndDate + "</TBLstcEndDate>");
                            }
                            else if (strIntakeDate != string.Empty)
                            {
                                str.Append("<TBIntakeStartDate>" + strIntakeDate + "</TBIntakeStartDate>");
                                str.Append("<TBIntakeEndDate>" + strEndDate + "</TBIntakeEndDate>");
                            }
                            else if (strCertifiedDt != string.Empty)
                            {
                                str.Append("<TBCertifiedStartDate>" + strCertifiedDt + "</TBCertifiedStartDate>");
                                str.Append("<TBCertifiedEndDate>" + strEndDate + "</TBCertifiedEndDate>");
                            }
                            //str.Append("<Details TBNAME = \"" + item.Cells["gvtTableName"].Value.ToString() + "\" TBAddDate = \"" + strAddDate + "\" TBLstcDate =\"" + strLstcDate + "\" TBIntakeDate = \"" + strIntakeDate + "\" TBCertified = \"" + strCertifiedDt + "\" />");
                        }
                        str.Append("</Details>");

                    }
                }
                str.Append("</TABLE>");



                DataSet thisDataSetDetails = DashBoardDB.GETRDLCALLDATANew123(strUserId, strStartDate, strEndDate, str.ToString(), string.Empty, string.Empty, string.Empty, BaseForm.BaseAgency);

                propDatatableUser = thisDataSetDetails.Tables[1];
                propDatatableProgram = thisDataSetDetails.Tables[2];
                propDatatableSummary = thisDataSetDetails.Tables[3];

                ReportDataSource datasourcedetails = new ReportDataSource("DataSet1", thisDataSetDetails.Tables[0]);
                reportViewer2.LocalReport.DataSources.Clear();
                reportViewer2.LocalReport.DataSources.Add(datasourcedetails);
                reportViewer2.LocalReport.Refresh();
                reportViewer2.Update();
                if (tabControl1.SelectedTab == tabPage2)
                    blnUseHostedpageLoadDetails = false;


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        public void GetReportSummaryDetails()
        {
            try
            {

                reportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                //if (rdox.Checked)
                reportViewer1.LocalReport.ReportPath = @"SSRS\Reports\summaryreport.rdlc";//UserWiseData.rdl";
                //else
                //    reportViewer1.LocalReport.ReportPath = @"SSRS\Reports\ProgramWisereportProgram.rdlc";//UserWiseData.rdl";


                //string strUserId = string.Empty;
                //string strStartDate = string.Empty;
                //string strEndDate = string.Empty;
                //string strType = string.Empty;

                //if (dtStartDate.Checked)
                //{
                //    strStartDate = dtStartDate.Value.ToShortDateString();
                //    strEndDate = DateTime.Now.ToShortDateString();
                //    if (dtEndDate.Checked)
                //        strEndDate = dtEndDate.Value.ToShortDateString();
                //}
                //StringBuilder str = new StringBuilder();
                //str.Append("<TABLE>");
                //string strAddDate, strLstcDate, strIntakeDate, strCertifiedDt = string.Empty;
                //foreach (DataGridViewRow item in gvwData.Rows)
                //{

                //    if (item.Cells["gvtSelect"].Value == "Y")
                //    {
                //        str.Append("<Details>");

                //        str.Append("<TBNAME>" + GetTableName(item.Cells["gvtTableName"].Value.ToString()) + "</TBNAME>");

                //        strAddDate = strLstcDate = strIntakeDate = strCertifiedDt = string.Empty;
                //        if (dtStartDate.Checked == true)
                //        {
                //            if (item.Cells["gvcDatetypes"].Value == "1")
                //            {
                //                strAddDate = dtStartDate.Value.ToShortDateString();
                //            }
                //            if (item.Cells["gvcDatetypes"].Value == "2")
                //            {
                //                strLstcDate = dtStartDate.Value.ToShortDateString();
                //            }
                //            if (item.Cells["gvcDatetypes"].Value == "3")
                //            {
                //                strIntakeDate = dtStartDate.Value.ToShortDateString();
                //            }


                //            if (strAddDate != string.Empty)
                //            {
                //                str.Append("<TBAddStartDate>" + strAddDate + "</TBAddStartDate>");
                //                str.Append("<TBAddEndDate>" + strEndDate + "</TBAddEndDate>");
                //            }
                //            else if (strLstcDate != string.Empty)
                //            {
                //                str.Append("<TBLstcStartDate>" + strLstcDate + "</TBLstcStartDate>");
                //                str.Append("<TBLstcEndDate>" + strEndDate + "</TBLstcEndDate>");
                //            }
                //            else if (strIntakeDate != string.Empty)
                //            {
                //                str.Append("<TBIntakeStartDate>" + strIntakeDate + "</TBIntakeStartDate>");
                //                str.Append("<TBIntakeEndDate>" + strEndDate + "</TBIntakeEndDate>");
                //            }
                //            else if (strCertifiedDt != string.Empty)
                //            {
                //                str.Append("<TBCertifiedStartDate>" + strCertifiedDt + "</TBCertifiedStartDate>");
                //                str.Append("<TBCertifiedEndDate>" + strEndDate + "</TBCertifiedEndDate>");
                //            }
                //            //str.Append("<Details TBNAME = \"" + item.Cells["gvtTableName"].Value.ToString() + "\" TBAddDate = \"" + strAddDate + "\" TBLstcDate =\"" + strLstcDate + "\" TBIntakeDate = \"" + strIntakeDate + "\" TBCertified = \"" + strCertifiedDt + "\" />");
                //        }
                //        str.Append("</Details>");

                //    }
                //}
                //str.Append("</TABLE>");

                //DataSet thisDataSetDetails = DashBoardDB.GETRDLCALLDATANew123(strUserId, strStartDate, strEndDate, str.ToString(), string.Empty, propUserNames, propProgrames);


                ReportDataSource datasourcedetails = new ReportDataSource("DataSet1", propDatatableSummary);
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(datasourcedetails);
                reportViewer1.LocalReport.Refresh();
                reportViewer1.Update();
                intsummaryhosted++;
                if (intsummaryhosted > 2)
                { blnUseHostedpageLoad = false; }

                if (tabControl1.SelectedTab == tabPage1)
                    blnUseHostedpageLoad = false;


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        Gizmox.WebGUI.Reporting.ReportViewer rptdynamicviewer;
        public void GetReportDynamicRdlcData(Gizmox.WebGUI.Reporting.ReportViewer rptviewerId)
        {
            try
            {

                rptviewerId.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                //if (rdox.Checked)
                //    reportViewer1.LocalReport.ReportPath = @"SSRS\Reports\ProgramandUsersrpt.rdlc";//UserWiseData.rdl";
                //else
                if (propReportName == "Report")
                    rptviewerId.LocalReport.ReportPath = @"SSRS\Reports\ProgramWisereport.rdlc";//UserWiseData.rdl";
                if (propReportName == "Column")
                    rptviewerId.LocalReport.ReportPath = @"SSRS\Reports\ProgramWisecolumrpt.rdlc";
                if (propReportName == "Shape")
                    rptviewerId.LocalReport.ReportPath = @"SSRS\Reports\ProgramWiseshaperpt.rdlc";
                if (propReportName == "Bar")
                    rptviewerId.LocalReport.ReportPath = @"SSRS\Reports\ProgramWisebarrpt.rdlc";


                string strUserId = string.Empty;
                string strStartDate = string.Empty;
                string strEndDate = string.Empty;
                string strType = string.Empty;

                if (dtStartDate.Checked)
                {
                    strStartDate = dtStartDate.Value.ToShortDateString();
                    strEndDate = DateTime.Now.ToShortDateString();
                    if (dtEndDate.Checked)
                        strEndDate = dtEndDate.Value.ToShortDateString();
                }
                StringBuilder str = new StringBuilder();
                str.Append("<TABLE>");
                string strAddDate, strLstcDate, strIntakeDate, strCertifiedDt = string.Empty;
                foreach (DataGridViewRow item in gvwData.Rows)
                {

                    if (item.Cells["gvtSelect"].Value == "Y")
                    {
                        str.Append("<Details>");

                        str.Append("<TBNAME>" + GetTableName(item.Cells["gvtTableName"].Value.ToString()) + "</TBNAME>");

                        strAddDate = strLstcDate = strIntakeDate = strCertifiedDt = string.Empty;
                        if (dtStartDate.Checked == true)
                        {
                            if (item.Cells["gvcDatetypes"].Value == "1")
                            {
                                strAddDate = dtStartDate.Value.ToShortDateString();
                            }
                            if (item.Cells["gvcDatetypes"].Value == "2")
                            {
                                strLstcDate = dtStartDate.Value.ToShortDateString();
                            }
                            if (item.Cells["gvcDatetypes"].Value == "3")
                            {
                                strIntakeDate = dtStartDate.Value.ToShortDateString();
                            }


                            if (strAddDate != string.Empty)
                            {
                                str.Append("<TBAddStartDate>" + strAddDate + "</TBAddStartDate>");
                                str.Append("<TBAddEndDate>" + strEndDate + "</TBAddEndDate>");
                            }
                            else if (strLstcDate != string.Empty)
                            {
                                str.Append("<TBLstcStartDate>" + strLstcDate + "</TBLstcStartDate>");
                                str.Append("<TBLstcEndDate>" + strEndDate + "</TBLstcEndDate>");
                            }
                            else if (strIntakeDate != string.Empty)
                            {
                                str.Append("<TBIntakeStartDate>" + strIntakeDate + "</TBIntakeStartDate>");
                                str.Append("<TBIntakeEndDate>" + strEndDate + "</TBIntakeEndDate>");
                            }
                            else if (strCertifiedDt != string.Empty)
                            {
                                str.Append("<TBCertifiedStartDate>" + strCertifiedDt + "</TBCertifiedStartDate>");
                                str.Append("<TBCertifiedEndDate>" + strEndDate + "</TBCertifiedEndDate>");
                            }
                            //str.Append("<Details TBNAME = \"" + item.Cells["gvtTableName"].Value.ToString() + "\" TBAddDate = \"" + strAddDate + "\" TBLstcDate =\"" + strLstcDate + "\" TBIntakeDate = \"" + strIntakeDate + "\" TBCertified = \"" + strCertifiedDt + "\" />");
                        }
                        str.Append("</Details>");

                    }
                }
                str.Append("</TABLE>");



                DataSet thisDataSetDetails = DashBoardDB.GETRDLCALLDATANew123(strUserId, strStartDate, strEndDate, str.ToString(), string.Empty, propUserNames, propProgrames,BaseForm.BaseAgency);



                ReportDataSource datasourcedetails = new ReportDataSource("DataSet1", thisDataSetDetails.Tables[0]);
                rptviewerId.LocalReport.DataSources.Clear();
                rptviewerId.LocalReport.DataSources.Add(datasourcedetails);
                rptviewerId.LocalReport.Refresh();
                rptviewerId.Update();
                if (tabControl1.SelectedTab.Text == propReportName)
                {
                    if (propReportTabcount != 0)
                    {
                        if (tabControl1.TabPages.Count == propReportTabcount)
                            booldynamichostedData = false;
                    }
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


        public DataSet  GetReportDynamicRdlcDateset()
        {
            DataSet thisDataSetDetails = new DataSet();
            try
            {

             


                string strUserId = string.Empty;
                string strStartDate = string.Empty;
                string strEndDate = string.Empty;
                string strType = string.Empty;

                if (dtStartDate.Checked)
                {
                    strStartDate = dtStartDate.Value.ToShortDateString();
                    strEndDate = DateTime.Now.ToShortDateString();
                    if (dtEndDate.Checked)
                        strEndDate = dtEndDate.Value.ToShortDateString();
                }
                StringBuilder str = new StringBuilder();
                str.Append("<TABLE>");
                string strAddDate, strLstcDate, strIntakeDate, strCertifiedDt = string.Empty;
                foreach (DataGridViewRow item in gvwData.Rows)
                {

                    if (item.Cells["gvtSelect"].Value == "Y")
                    {
                        str.Append("<Details>");

                        str.Append("<TBNAME>" + GetTableName(item.Cells["gvtTableName"].Value.ToString()) + "</TBNAME>");

                        strAddDate = strLstcDate = strIntakeDate = strCertifiedDt = string.Empty;
                        if (dtStartDate.Checked == true)
                        {
                            if (item.Cells["gvcDatetypes"].Value == "1")
                            {
                                strAddDate = dtStartDate.Value.ToShortDateString();
                            }
                            if (item.Cells["gvcDatetypes"].Value == "2")
                            {
                                strLstcDate = dtStartDate.Value.ToShortDateString();
                            }
                            if (item.Cells["gvcDatetypes"].Value == "3")
                            {
                                strIntakeDate = dtStartDate.Value.ToShortDateString();
                            }


                            if (strAddDate != string.Empty)
                            {
                                str.Append("<TBAddStartDate>" + strAddDate + "</TBAddStartDate>");
                                str.Append("<TBAddEndDate>" + strEndDate + "</TBAddEndDate>");
                            }
                            else if (strLstcDate != string.Empty)
                            {
                                str.Append("<TBLstcStartDate>" + strLstcDate + "</TBLstcStartDate>");
                                str.Append("<TBLstcEndDate>" + strEndDate + "</TBLstcEndDate>");
                            }
                            else if (strIntakeDate != string.Empty)
                            {
                                str.Append("<TBIntakeStartDate>" + strIntakeDate + "</TBIntakeStartDate>");
                                str.Append("<TBIntakeEndDate>" + strEndDate + "</TBIntakeEndDate>");
                            }
                            else if (strCertifiedDt != string.Empty)
                            {
                                str.Append("<TBCertifiedStartDate>" + strCertifiedDt + "</TBCertifiedStartDate>");
                                str.Append("<TBCertifiedEndDate>" + strEndDate + "</TBCertifiedEndDate>");
                            }
                            //str.Append("<Details TBNAME = \"" + item.Cells["gvtTableName"].Value.ToString() + "\" TBAddDate = \"" + strAddDate + "\" TBLstcDate =\"" + strLstcDate + "\" TBIntakeDate = \"" + strIntakeDate + "\" TBCertified = \"" + strCertifiedDt + "\" />");
                        }
                        str.Append("</Details>");

                    }
                }
                str.Append("</TABLE>");
                

                 thisDataSetDetails = DashBoardDB.GETRDLCALLDATANew123(strUserId, strStartDate, strEndDate, str.ToString(), string.Empty, propUserNames, propProgrames,BaseForm.BaseAgency);


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            return thisDataSetDetails;
        }

        public string GetReportDynamicRdlcTable()
        {
            string  strtabledata = string.Empty;
            try
            {




                string strUserId = string.Empty;
                string strStartDate = string.Empty;
                string strEndDate = string.Empty;
                string strType = string.Empty;

                if (dtStartDate.Checked)
                {
                    strStartDate = dtStartDate.Value.ToShortDateString();
                    strEndDate = DateTime.Now.ToShortDateString();
                    if (dtEndDate.Checked)
                        strEndDate = dtEndDate.Value.ToShortDateString();
                }
                StringBuilder str = new StringBuilder();
                str.Append("<TABLE>");
                string strAddDate, strLstcDate, strIntakeDate, strCertifiedDt = string.Empty;
                foreach (DataGridViewRow item in gvwData.Rows)
                {

                    if (item.Cells["gvtSelect"].Value == "Y")
                    {
                        str.Append("<Details>");

                        str.Append("<TBNAME>" + GetTableName(item.Cells["gvtTableName"].Value.ToString()) + "</TBNAME>");

                        strAddDate = strLstcDate = strIntakeDate = strCertifiedDt = string.Empty;
                        if (dtStartDate.Checked == true)
                        {
                            if (item.Cells["gvcDatetypes"].Value == "1")
                            {
                                strAddDate = dtStartDate.Value.ToShortDateString();
                            }
                            if (item.Cells["gvcDatetypes"].Value == "2")
                            {
                                strLstcDate = dtStartDate.Value.ToShortDateString();
                            }
                            if (item.Cells["gvcDatetypes"].Value == "3")
                            {
                                strIntakeDate = dtStartDate.Value.ToShortDateString();
                            }


                            if (strAddDate != string.Empty)
                            {
                                str.Append("<TBAddStartDate>" + strAddDate + "</TBAddStartDate>");
                                str.Append("<TBAddEndDate>" + strEndDate + "</TBAddEndDate>");
                            }
                            else if (strLstcDate != string.Empty)
                            {
                                str.Append("<TBLstcStartDate>" + strLstcDate + "</TBLstcStartDate>");
                                str.Append("<TBLstcEndDate>" + strEndDate + "</TBLstcEndDate>");
                            }
                            else if (strIntakeDate != string.Empty)
                            {
                                str.Append("<TBIntakeStartDate>" + strIntakeDate + "</TBIntakeStartDate>");
                                str.Append("<TBIntakeEndDate>" + strEndDate + "</TBIntakeEndDate>");
                            }
                            else if (strCertifiedDt != string.Empty)
                            {
                                str.Append("<TBCertifiedStartDate>" + strCertifiedDt + "</TBCertifiedStartDate>");
                                str.Append("<TBCertifiedEndDate>" + strEndDate + "</TBCertifiedEndDate>");
                            }
                            //str.Append("<Details TBNAME = \"" + item.Cells["gvtTableName"].Value.ToString() + "\" TBAddDate = \"" + strAddDate + "\" TBLstcDate =\"" + strLstcDate + "\" TBIntakeDate = \"" + strIntakeDate + "\" TBCertified = \"" + strCertifiedDt + "\" />");
                        }
                        str.Append("</Details>");

                    }
                }
                str.Append("</TABLE>");

                strtabledata = str.ToString();
                //thisDataSetDetails = DashBoardDB.GETRDLCALLDATANew123(strUserId, strStartDate, strEndDate, str.ToString(), string.Empty, propUserNames, propProgrames);


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            return strtabledata;
        }


        private string GetTableName(string strDesc)
        {
            string strTableName = string.Empty;
            switch (strDesc)
            {
                case "Client Intakes":
                    strTableName = "CASEMST";
                    break;
                case "Household Members":
                    strTableName = "CASESNP";
                    break;
                case "Income Details":
                    strTableName = "CASEINCOME";
                    break;
                case "Income Verification":
                    strTableName = "CASEVER";
                    break;
                case "Services Activities (CA)":
                    strTableName = "CASEACT";
                    break;
                case "Outcome Indicators (MS)":
                    strTableName = "CASEMS";
                    break;
                case "Service Plans":
                    strTableName = "CASESPM";
                    break;
                case "Fuel Assistance Supplier Data":
                    strTableName = "LIHEAPV";
                    break;
                case "Fuel Assistance Benefit Data":
                    strTableName = "LIHEAPB";
                    break;
                case "Fuel Assistance Payments":
                    strTableName = "PAYMENT";
                    break;
                case "Enrollment":
                    strTableName = "CASEENRL";
                    break;
                case "Full Assessment Scales Completed":
                    strTableName = "MATASMT";
                    break;
                case "Emergency Services(Resource Records)":
                    strTableName = "EMSRES";
                    break;
                case "Emergency Services(Invoices/Authorizations)":
                    strTableName = "EMSCLCPMC";
                    break;


            }

            return strTableName;

        }

        private void btnGetReport_Click(object sender, EventArgs e)
        {
            propUserNames = string.Empty;

            tabControl1.SelectedIndex = 0;            
            intsummaryhosted = 0;
            //tabPage1.Hide();
            GetReportDataDetails();
            tabControl1.SelectedIndex = 0;
            tabControl1.SelectedIndex = 0;
           
            blnUseHostedpageLoad = true;
            if (propDatatableProgram.Rows.Count > 0 || propDatatableUser.Rows.Count > 0)
            {
                btnUserId.Visible = true;
                btnUserId.Enabled = true;
            }
            else
            {
                btnUserId.Enabled = btnUserId.Visible = false;
            }
           

        }

        void UserDataFill(DataTable dt)
        {
            gvwUserData.Rows.Clear();
            //List<CommonEntity> listsubdetails;
            //var varuserid = listrdlcdata.Select(u => u.Code).Distinct();
            //if (listrdlcdata.Count > 0)
            //{
            //    foreach (var useriddata in varuserid)
            //    {
            //        int rowindex = gvwUserData.Rows.Add(useriddata);
            //        gvwUserData.Rows[rowindex].Cells["gvtUserId"].Style.BackColor = Color.AntiqueWhite;
            //        gvwUserData.Rows[rowindex].Cells["gvtUserId"].Style.ForeColor = Color.Green;
            //        listsubdetails = listrdlcdata.FindAll(u => u.Code.Trim() == useriddata.Trim());
            //        foreach (CommonEntity listofcount in listsubdetails)
            //        {
            //            gvwUserData.Rows.Add(listofcount.Desc, listofcount.Extension);
            //        }
            //    }
            //}

        }
        void fillProgramDefinationData(DataTable dt)
        {
            //List<ProgramDefinitionEntity> programEntityList = _model.HierarchyAndPrograms.GetPrograms(string.Empty, string.Empty);
            //foreach (ProgramDefinitionEntity programEntity in programEntityList)
            //{
            //    string code = programEntity.Agency +  programEntity.Dept +  programEntity.Prog;

            //    int rowIndex = gvwUserData.Rows.Add(Img_Blank, code, programEntity.DepAGCY,"N");
            //}

            gvwUserData.Rows.Clear();
            foreach (DataRow dtrows in dt.Rows)
            {
                //string code = programEntity.Agency + programEntity.Dept + programEntity.Prog;

                int rowIndex = gvwUserData.Rows.Add(Img_Blank, dtrows["Programcode"].ToString(), dtrows["Program"].ToString(), "N");
            }
        }

        private void reportViewer2_HostedPageLoad(object sender, Gizmox.WebGUI.Forms.Hosts.AspPageEventArgs e)
        {
            if (blnUseHostedpageLoadDetails)
            {
                GetReportDataDetails();
            }
        }

        bool booldynamichostedData = true;
        private void reportViewerdyanamic_HostedPageLoad(object sender, Gizmox.WebGUI.Forms.Hosts.AspPageEventArgs e)
        {
            if (booldynamichostedData)
                GetReportDynamicRdlcData(rptdynamicviewer);

        }


        private void btnUserId_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Count < 6)
            {
                string strUserId = string.Empty;
                string strStartDate = string.Empty;
                string strEndDate = string.Empty;
                string strType = string.Empty;

                if (dtStartDate.Checked)
                {
                    strStartDate = dtStartDate.Value.ToShortDateString();
                    strEndDate = DateTime.Now.ToShortDateString();
                    if (dtEndDate.Checked)
                        strEndDate = dtEndDate.Value.ToShortDateString();
                }
                string strTableData =  GetReportDynamicRdlcTable();
                RdlcUserForm userform = new RdlcUserForm(propUserNames, propDatatableUser, string.Empty, string.Empty, propDatatableProgram, strStartDate, strEndDate, strTableData,BaseForm);
               // userform.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(userform_FormClosed);
                userform.ShowDialog();
            }
        }

        void userform_FormClosed(object sender, FormClosedEventArgs e)
        {
            RdlcUserForm rdlcform = sender as RdlcUserForm;
            if (rdlcform.DialogResult == DialogResult.OK)
            {
               
                ////booldynamichostedData = true;
                propUserNames = rdlcform.propUserName;
                propProgrames = rdlcform.propProgramName;
                propReportName = rdlcform.propReportType;


              DataSet ds=  GetReportDynamicRdlcDateset();
              PrintRdlcForm printrdlcform = new PrintRdlcForm(ds, propReportName);
              printrdlcform.ShowDialog();

                //propReportTabcount = 0;
                //TabPage tappage1 = new TabPage();
                //Gizmox.WebGUI.Reporting.ReportViewer rptviewer = new Gizmox.WebGUI.Reporting.ReportViewer();
                //rptviewer.ID = "Rpt" + tabControl1.TabPages.Count;
                //tappage1.Text = propReportName;
                //rptviewer.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
                //rptviewer.AsyncRendering = false;
                //tappage1.Controls.Add(rptviewer);
                //rptviewer.HostedPageLoad += new Gizmox.WebGUI.Forms.Hosts.AspPageEventHandler(reportViewerdyanamic_HostedPageLoad);
                //rptdynamicviewer = rptviewer;
                //GetReportDynamicRdlcData(rptdynamicviewer);
                //tabControl1.TabPages.Add(tappage1);
                //tabControl1.SelectedIndex = tabControl1.TabPages.Count - 1;
                //propReportTabcount = tabControl1.TabPages.Count;               

            }
        }


        private void gvwUserData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gvwUserData.Rows.Count > 0 && e.RowIndex != -1)
            {
                int ColIdx = gvwUserData.CurrentCell.ColumnIndex;
                int RowIdx = gvwUserData.CurrentCell.RowIndex;

                if (gvIData.Index == ColIdx)
                {
                    if (e.ColumnIndex == 0)//&& (Mode.Equals("Add") || Mode.Equals("Edit")))
                    {
                        if (gvwUserData.CurrentRow.Cells["gvtSelectuser"].Value.ToString() == "Y")
                        {
                            gvwUserData.CurrentRow.Cells["gvIData"].Value = Img_Blank;
                            gvwUserData.CurrentRow.Cells["gvtSelectuser"].Value = "N";

                        }
                        else
                        {
                            gvwUserData.CurrentRow.Cells["gvIData"].Value = Img_Tick;
                            gvwUserData.CurrentRow.Cells["gvtSelectuser"].Value = "Y";
                        }
                    }
                }
            }

        }

        int intsummaryhosted = 0;
        private void reportViewer1_HostedPageLoad(object sender, Gizmox.WebGUI.Forms.Hosts.AspPageEventArgs e)
        {
            if (blnUseHostedpageLoad)
            {
                GetReportSummaryDetails();
            }
        }

        private void btnSummary_Click(object sender, EventArgs e)
        {
            TabPage tappage1 = new TabPage();
            tappage1.Text = "Report" + tabControl1.TabPages.Count + 1;
            tabControl1.TabPages.Add(tappage1);
            //string strprogrames = string.Empty;
            //foreach (DataGridViewRow item in gvwUserData.Rows)
            //{

            //    if (item.Cells["gvtSelectuser"].Value == "Y")
            //    {
            //        if (strprogrames.Trim() == string.Empty)
            //            strprogrames = item.Cells["gvtprogramCode"].Value.ToString() + ",";
            //        else
            //            strprogrames = strprogrames + item.Cells["gvtprogramCode"].Value.ToString() + ",";
            //    }
            //}
            //if (strprogrames != string.Empty && propUserNames != string.Empty)
            //{
            //    propProgrames = strprogrames;
            //    GetReportSummaryDetails();
            //    tabControl1.SelectedIndex = 0;
            //}
            //else
            //{
            //    CommonFunctions.MessageBoxDisplay("Please select users or programes");
            //}
        }
        
       

        private void tabControl1_CloseClick(object sender, EventArgs e)
        {
            //string strtabname = tabControl1.SelectedItem.Text;
            //if (strtabname != "User/Program View")
            //{
            //    tabControl1.TabPages.Remove(tabControl1.SelectedTab);             
            //    tabControl1.SelectedIndex = 1;
            //    reportViewer2.Update();
            //}
            
        }

    }
}