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
using System.Web;

#endregion

namespace Captain.Common.Views.Forms
{
    public partial class PdfViewerNewForm : Form
    {
        public PdfViewerNewForm(string strFileName)
        {
            string strpath = GetSiteUrl();
            strpath = strpath.Replace("///", "/");
            strFileName = strFileName.Replace(" ", "%20");
            //URI uri = new URI(string.replace(" ", "%20"));
            strpath = strpath + "ViewPdfForm.aspx?Name=" + strFileName;

            InitializeComponent();
            pnlDetails.Visible = false;
            this.htmlBox1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.pnlDetails.Dock = Gizmox.WebGUI.Forms.DockStyle.None;

            //System.Drawing.Image IMG;
            //if (strFileName.ToUpper().Contains(".JPG") || strFileName.ToUpper().Contains(".JPEG") || strFileName.ToUpper().Contains(".PNG") || strFileName.ToUpper().Contains(".BMP"))
            //{
            //    try
            //    {
            //        IMG = System.Drawing.Image.FromFile(strFileName);
            //        this.htmlBox1.Html = "<HTML><iframe src=" + strpath + " height= 100% width = 100%></iframe></HTML>";
            //        this.Size = new Size(IMG.Width, IMG.Height);
            //        this.htmlBox1.Dock = DockStyle.Fill;
            //        this.Dock = DockStyle.Fill;
            //    }
            //    catch (Exception ex)
            //    {
            //        this.htmlBox1.Html = "<HTML><iframe src=" + strpath + " height=100% width=100%></iframe></HTML>";
            //    }

            //}
            //else
            //{
                this.htmlBox1.Html = "<HTML><iframe src=" + strpath + " height=100% width=100%></iframe></HTML>";
           // }
        }

        public PdfViewerNewForm(string strFileName,string strtype)
        {
            string strpath = GetSiteUrl();
            strpath = strpath.Replace("///", "/");
            strFileName = strFileName.Replace(" ", "%20");
            //URI uri = new URI(string.replace(" ", "%20"));
            strpath = strpath + "CaptchaImage.aspx";

            InitializeComponent();
            pnlDetails.Visible = false;
            this.htmlBox1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.pnlDetails.Dock = Gizmox.WebGUI.Forms.DockStyle.None;

            //System.Drawing.Image IMG;
            //if (strFileName.ToUpper().Contains(".JPG") || strFileName.ToUpper().Contains(".JPEG") || strFileName.ToUpper().Contains(".PNG") || strFileName.ToUpper().Contains(".BMP"))
            //{
            //    try
            //    {
            //        IMG = System.Drawing.Image.FromFile(strFileName);
            //        this.htmlBox1.Html = "<HTML><iframe src=" + strpath + " height= 100% width = 100%></iframe></HTML>";
            //        this.Size = new Size(IMG.Width, IMG.Height);
            //        this.htmlBox1.Dock = DockStyle.Fill;
            //        this.Dock = DockStyle.Fill;
            //    }
            //    catch (Exception ex)
            //    {
            //        this.htmlBox1.Html = "<HTML><iframe src=" + strpath + " height=100% width=100%></iframe></HTML>";
            //    }

            //}
            //else
            //{
            this.htmlBox1.Html = "<HTML><iframe src=" + strpath + " height=100% width=100%></iframe></HTML>";
            // }
        }

        public PdfViewerNewForm(string strFileName, string strApplicantNo, string struserid, string strFileType)
        {
            string strpath = GetSiteUrl();
            strpath = strpath.Replace("///", "/");
            strFileName = strFileName.Replace(" ", "%20");
            //URI uri = new URI(string.replace(" ", "%20"));
            strpath = strpath + "signature.aspx?id=" + strFileName + "&actid=" + strApplicantNo + "&userid=" + struserid + "&filetype=" + strFileType;

            InitializeComponent();
            pnlDetails.Visible = false;
            this.htmlBox1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.pnlDetails.Dock = Gizmox.WebGUI.Forms.DockStyle.None;
            this.htmlBox1.Html = "<HTML><iframe src=" + strpath + " height=100% width=100%></iframe></HTML>";
        }

        public PdfViewerNewForm(string strFileName, DataSet Result_dataSet, DataTable Result_table, string report_name, string report_to_process, string reportpath, string strUserId, bool Detail_Rep_Required, string scr_Code)
        {
            string strpath = GetSiteUrl();
            strpath = strpath.Replace("///", "/");
            strFileName = strFileName.Replace(" ", "%20");
            //URI uri = new URI(string.replace(" ", "%20"));
            strpath = strpath + "ViewPdfForm.aspx?Name=" + strFileName;
            UserId = strUserId;
            Scr_Code = scr_Code;
            Report_To_Process = report_to_process;
            Result_Table = Result_table;
            Report_Name = report_name;
            Result_DataSet = Result_dataSet;
            Detail_Rep_Required = Detail_Rep_Required;
            ReportPath = reportpath;
            InitializeComponent();
            if (Detail_Rep_Required)
            {
                this.htmlBox1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
                pnlDetails.Visible = true;
                switch (Scr_Code)
                {
                    case "RNGB0004": Btn_Bypass.Visible = Btn_SNP_Details.Visible = Btn_MST_Details.Visible = true; break; // 
                    case "RNGB0014":
                        this.Btn_Bypass.Location = new System.Drawing.Point(2, 507);
                        Btn_Bypass.Text = "Detail Report"; Btn_Bypass.Visible = true; break;
                }
            }
            else
            {
                this.htmlBox1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
                pnlDetails.Visible = false;
            }

            this.htmlBox1.Html = "<HTML><iframe src=" + strpath + " height=100% width=100%></iframe></HTML>";
        }

        public string UserId { get; set; }

        public static string GetSiteUrl()
        {
            string url = string.Empty;
            HttpRequest request = HttpContext.Current.Request;

            if (request.IsSecureConnection)
                url = "https://";
            else
                url = "http://";

            return url + HttpContext.Current.Request.Url.Authority + "/" + HttpContext.Current.Request.ApplicationPath + "/";


        }

        #region properties

        public string Scr_Code { get; set; }

        public string Report_Name { get; set; }

        public string Report_To_Process { get; set; }

        public DataTable Result_Table { get; set; }

        public DataTable Summary_table { get; set; }

        public DataSet Result_DataSet { get; set; }

        public bool Detail_Rep_Required { get; set; }

        public string Main_Rep_Name { get; set; }

        public string ReportPath { get; set; }

        #endregion

        private void Btn_Bypass_Click(object sender, EventArgs e)
        {

            switch (Scr_Code)
            {
                case "RNGB0004":
                    Report_Name = "RNGB0004_Bypass_RdlC.rdlc";
                    break;
                case "RNGB0014":
                    Report_Name = Report_Name;
                    break;
            }

            //CASB2012_AdhocRDLCForm RDLC_Form = new CASB2012_AdhocRDLCForm(Summary_table, Result_Table, Report_Name, "Result Table", ReportPath);
            //CASB2012_AdhocRDLCForm RDLC_Form;
            //if (Scr_Code == "RNGB0004")
            //    RDLC_Form = new CASB2012_AdhocRDLCForm(Result_DataSet.Tables[3], Summary_table, Report_Name, "Result Table", ReportPath, UserId, "RNG");
            //else
            //    RDLC_Form = new CASB2012_AdhocRDLCForm(Result_Table, Summary_table, Report_Name, "Result Table", ReportPath, UserId, "RNG");
            ////RDLC_Form.FormClosed += new Form.FormClosedEventHandler(Delete_Dynamic_RDLC_File);
            //RDLC_Form.ShowDialog();
        }

        private void Btn_SNP_Details_Click(object sender, EventArgs e)
        {
            Report_Name = "RNGB0004_SNP_IND_RdlC.rdlc";

            CASB2012_AdhocRDLCForm RDLC_Form = new CASB2012_AdhocRDLCForm(Result_DataSet.Tables[5], Summary_table, Report_Name, "Result Table", ReportPath, UserId, "RNG"); //8, 5
            //RDLC_Form.FormClosed += new Form.FormClosedEventHandler(Delete_Dynamic_RDLC_File);
            RDLC_Form.ShowDialog();
        }

        private void Btn_MST_Details_Click(object sender, EventArgs e)
        {
            Report_Name = "RNGB0004_MST_FAM_RdlC.rdlc";

            CASB2012_AdhocRDLCForm RDLC_Form = new CASB2012_AdhocRDLCForm(Result_DataSet.Tables[7], Summary_table, Report_Name, "Result Table", ReportPath, UserId, "RNG"); //8, 8
            //RDLC_Form.FormClosed += new Form.FormClosedEventHandler(Delete_Dynamic_RDLC_File);
            RDLC_Form.ShowDialog();
        }



    }
}