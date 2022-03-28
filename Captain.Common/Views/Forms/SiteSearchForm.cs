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
using Captain.Common.Model.Objects;
using Captain.Common.Model.Data;
using Captain.Common.Utilities;
using Captain.Common.Views.Forms.Base;

#endregion

namespace Captain.Common.Views.Forms
{
    public partial class SiteSearchForm : Form
    {
        private CaptainModel _model = null;
        public string SearchCode { get; set; }
        public string strTypeSearch { get; set; }
        public string strAgency { get; set; }
        public string strDept { get; set; }
        public string strProgram { get; set; }

        public SiteSearchForm(string strAgency, string strDept, string strProgram, string strYear, string strTitleName,string strFilterType)
        {
            InitializeComponent();
            this.Text = strTitleName + "- Site Search";
            _model = new CaptainModel();
            dataGridSiteSearch.Rows.Clear();
            dataGridSiteSearch.Columns[1].Width = 380;
            List<TmsApcnEntity> tmsApcnEntity = _model.TmsApcndata.GetCASESITEadpy(strAgency, strDept, strProgram, strYear, strFilterType);
            foreach (TmsApcnEntity tmsapcn in tmsApcnEntity)
            {
                int rowIndex = dataGridSiteSearch.Rows.Add(tmsapcn.Location, tmsapcn.Description, tmsapcn.Active);
                if (tmsapcn.Active == "N")
                    dataGridSiteSearch.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.Red;
                dataGridSiteSearch.Rows[rowIndex].Tag = tmsapcn;
                dataGridSiteSearch.ItemsPerPage = 100;
            }
        }

        public SiteSearchForm(string Agency, string Dept, string Program, PrivilegeEntity privilegeEntity, string strType,BaseForm baseForm)
        {
            InitializeComponent();
            this.Text = privilegeEntity.PrivilegeName.Trim() + "- Site Search";
            _model = new CaptainModel();
            strTypeSearch = strType;
            dataGridSiteSearch.Rows.Clear();
            dataGridSiteSearch.Columns.Clear();
            AddSiteGridColumns(dataGridSiteSearch);
            strAgency = Agency;
            strDept = Dept;
            strProgram = Program;
            BaseForm = baseForm;

        }

        BaseForm BaseForm { get; set; }
        /// <summary>
        /// Add the columns to the grid.
        /// </summary>
        /// <param name="dataGridView"></param>
        private void AddSiteGridColumns(DataGridView dataGridView)
        {
            string columnName = string.Empty;

            dataGridView.Columns.Clear();
            DataGridViewTextBoxColumn moduleColumn = new DataGridViewTextBoxColumn();
            moduleColumn.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            moduleColumn.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            moduleColumn.CellTemplate = new DataGridViewTextBoxCell();
            moduleColumn.HeaderText = "Site No.";
            moduleColumn.Name = "SiteNo";
            moduleColumn.Width = 100;
            moduleColumn.ReadOnly = true;
            moduleColumn.Visible = true;
            dataGridView.Columns.Add(moduleColumn);

            DataGridViewTextBoxColumn codeColumn = new DataGridViewTextBoxColumn();
            codeColumn.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            codeColumn.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            codeColumn.CellTemplate = new DataGridViewTextBoxCell();
            codeColumn.HeaderText = "Site Name";
            codeColumn.Name = "SiteName";
            codeColumn.Width = 200;
            codeColumn.ReadOnly = true;
            dataGridView.Columns.Add(codeColumn);

            DataGridViewTextBoxColumn descColumn = new DataGridViewTextBoxColumn();
            descColumn.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            descColumn.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            descColumn.CellTemplate = new DataGridViewTextBoxCell();
            descColumn.HeaderText = "City";
            descColumn.Name = "City";
            descColumn.Width = 100;
            descColumn.ReadOnly = true;
            dataGridView.Columns.Add(descColumn);

            DataGridViewTextBoxColumn ActColumn = new DataGridViewTextBoxColumn();
            ActColumn.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet;
            ActColumn.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            ActColumn.CellTemplate = new DataGridViewTextBoxCell();
            ActColumn.HeaderText = "Active";
            ActColumn.Name = "Active";
            ActColumn.Width = 100;
            ActColumn.ReadOnly = true;
            ActColumn.Visible = false;
            dataGridView.Columns.Add(ActColumn);
        }

        private void OnHelpClick(object sender, EventArgs e)
        {
            Help.ShowHelp(this, Context.Server.MapPath("~\\Resources\\HelpFiles\\Captain_Help.chm"), HelpNavigator.KeywordIndex, "CASE2001");
        }

        private void dataGridSiteSearch_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (dataGridSiteSearch.Rows.Count > 0)
            {
                if (dataGridSiteSearch.CurrentRow.Cells["Active"].Value.ToString() == "N")
                    MessageBox.Show("Selected Site is Inactive" + "\n" + "Are you sure want to continue?", Consts.Common.ApplicationCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, Selected_Site_Row);
                else
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }

        public void Selected_Site_Row(object sender, EventArgs e)
        {
            Gizmox.WebGUI.Forms.Form senderform = (Gizmox.WebGUI.Forms.Form)sender;

            if (senderform != null)
            {
                if (senderform.DialogResult.ToString() == "Yes")
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        public string GetSelectedRowDetails()
        {
            string strCode = "";
            if (dataGridSiteSearch != null)
            {
                foreach (DataGridViewRow dr in dataGridSiteSearch.SelectedRows)
                {
                    if (dr.Selected)
                    {
                        try
                        {
                            strCode = dataGridSiteSearch.CurrentRow.Cells["SiteNo"].Value.ToString();

                            //if (dr.Selected)
                            //{
                            //    TmsApcnEntity srow = dr.Tag as TmsApcnEntity;
                            //    strCode = srow.Location;
                            //}
                        }
                        catch (Exception ex) { }
                    }
                }
            }
            return strCode;
        }

        public string GetSelectedRow()
        {
            string strCode = "";
            if (dataGridSiteSearch != null)
            {
                foreach (DataGridViewRow dr in dataGridSiteSearch.SelectedRows)
                {
                    if (dr.Selected)
                    {
                        try
                        {
                            if (dr.Selected)
                            {
                                DataRow srow = dr.Tag as DataRow;
                                strCode = srow["SITE_NUMBER"].ToString();
                                break;
                            }
                        }
                        catch (Exception ex) { }
                    }
                }
            }
            return strCode;
        }

        private void SiteSearchForm_Load(object sender, EventArgs e)
        {
            if (strTypeSearch == "ClientIntake")
            {

                if (BaseForm.BaseAgencyControlDetails.SiteSecurity.ToString() == "1")
                {
                    List<CaseSiteEntity> CaseSiteEntityList = _model.CaseMstData.GetCaseSite(BaseForm.BaseAgency, BaseForm.BaseDept, BaseForm.BaseProg, "SiteHie");
                    HierarchyEntity hierarchyEntity = new HierarchyEntity();
                    List<HierarchyEntity> userHierarchy = _model.UserProfileAccess.GetUserHierarchyByID(BaseForm.UserID);
                    foreach (HierarchyEntity Entity in userHierarchy)
                    {
                        if (Entity.InActiveFlag == "N")
                        {
                            if (Entity.Agency == BaseForm.BaseAgency && Entity.Dept == BaseForm.BaseDept && Entity.Prog == BaseForm.BaseProg)
                                hierarchyEntity = Entity;
                            else if (Entity.Agency == BaseForm.BaseAgency && Entity.Dept == BaseForm.BaseDept && Entity.Prog == "**")
                                hierarchyEntity = Entity;
                            else if (Entity.Agency == BaseForm.BaseAgency && Entity.Dept == "**" && Entity.Prog == "**")
                                hierarchyEntity = Entity;
                            else if (Entity.Agency == "**" && Entity.Dept == "**" && Entity.Prog == "**")
                            {
                                //Entity.Agency = Agency;
                                hierarchyEntity = Entity;
                            }
                        }
                    }

                    List<CaseSiteEntity> ListcaseSiteEntity = new List<CaseSiteEntity>();

                    if (hierarchyEntity.Sites.Length > 0)
                    {
                        string[] Sites = hierarchyEntity.Sites.Split(',');

                        for (int i = 0; i < Sites.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(Sites[i].ToString().Trim()))
                            {
                                foreach (CaseSiteEntity casesite in CaseSiteEntityList) //Site_List)//ListcaseSiteEntity)
                                {
                                    if (Sites[i].ToString() == casesite.SiteNUMBER)
                                    {
                                        ListcaseSiteEntity.Add(casesite);
                                        //break;
                                    }
                                    // Sel_Site_Codes += "'" + casesite.SiteNUMBER + "' ,";
                                }
                            }
                        }
                    }
                    //else if (hierarchyEntity.Agency + hierarchyEntity.Dept + hierarchyEntity.Prog != "******") CaseSiteEntityList = ListcaseSiteEntity;

                    if (ListcaseSiteEntity.Count > 0) CaseSiteEntityList = ListcaseSiteEntity;

                    if (CaseSiteEntityList.Count > 0)
                    {
                        foreach (CaseSiteEntity siteitem in CaseSiteEntityList)
                        {
                            int rowIndex = dataGridSiteSearch.Rows.Add(siteitem.SiteNUMBER.ToString(), siteitem.SiteNAME.ToString(), siteitem.SiteCITY.ToString(), siteitem.SiteACTIVE.ToString());
                            if (siteitem.SiteACTIVE.ToString() == "N")
                                dataGridSiteSearch.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.Red;
                            dataGridSiteSearch.Rows[rowIndex].Tag = siteitem;
                        }
                    }
                    else
                    {
                        MessageBox.Show("No Records Exists!.");
                    }
                
                }
                else
                {
                    DataSet ds = Captain.DatabaseLayer.CaseMst.GetSiteByHIE(strAgency, strDept, strProgram);
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            int rowIndex = dataGridSiteSearch.Rows.Add(dr["SITE_NUMBER"].ToString(), dr["SITE_NAME"].ToString(), dr["SITE_CITY"].ToString(), dr["SITE_ACTIVE"].ToString());
                            if (dr["SITE_ACTIVE"].ToString() == "N")
                                dataGridSiteSearch.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.Red;
                            dataGridSiteSearch.Rows[rowIndex].Tag = dr;
                        }
                    }
                    else
                    {
                        MessageBox.Show("No Records Exists!.");
                    }
                }
            }

        }

    }
}