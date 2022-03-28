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
using Captain.Common.Utilities;
using Captain.Common.Views.Forms.Base;
using Captain.Common.Menus;
using Captain.Common.Views.Forms;
using System.Data.SqlClient;
using Captain.Common.Views.Controls;
using Captain.Common.Model.Objects;
using Captain.Common.Model.Data;
#endregion

namespace Captain.Common.Views.Forms
{
    public partial class SsnScanSearchForm : Form
    {
        string SelSsnNo = null;
        public SsnScanSearchForm(string SsnNo)
        {
            SelSsnNo = SsnNo;
            InitializeComponent();

            SsnScanSearch();
        }

        

        private void btnSSNSelect_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SsnScanSearch()
        {
            gvwssnscansearch.Rows.Clear();
            int Rows = 0;
            DataSet ds1=  Captain.DatabaseLayer.SSN_Search.MainMenuSearch("SSN", "ALL", SelSsnNo, " ", " ", " ", " ", " ", " ", " ", " ");
            DataTable dt = ds1.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                int rowIndex = gvwssnscansearch.Rows.Add(dr["AppKey"].ToString(), dr["Fname"].ToString() + " ," + dr["Mname"].ToString() + " , " + dr["Lname"].ToString(), dr["DtBirth"].ToString(), dr["LtDate"].ToString(), dr["Ssn"].ToString(), dr["Seq"].ToString());                                              
                gvwssnscansearch.Rows[rowIndex].Tag = dr;
                Rows++;
            }
            if (Rows == 0)
            {
                MessageBox.Show("No Records Exists...", "CAP Systems", MessageBoxButtons.OK);
            }
        }
        

        public string[] GetScanSelected()
        {
            string[] SelDetails = new string[3];
            string SelDetails2 = null;
            SelDetails[0] = SelDetails[1] = SelDetails[2] = null;
            if (gvwssnscansearch != null)
            {
                foreach (DataGridViewRow dr in gvwssnscansearch.SelectedRows)
                {
                    if (dr.Selected)
                    {
                        //DataRow srow = dr.Tag as DataRow;

                        SelDetails2 = dr.Cells["SsnNo"].Value.ToString();
                        SelDetails[0] = SelDetails2;
                        SelDetails2 = dr.Cells["ApplicantNumber"].Value.ToString();
                        SelDetails[1] = SelDetails2;
                        SelDetails2 = dr.Cells["MemSeq"].Value.ToString();
                        SelDetails[2] = SelDetails2;                                            

                        break;
                    }
                }
            }
            return SelDetails;
        }

        private String[] SsnScanSearchForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            string[] SelSsn = new string[3];
            SelSsn = GetScanSelected();

            return SelSsn;
        }
    }
}