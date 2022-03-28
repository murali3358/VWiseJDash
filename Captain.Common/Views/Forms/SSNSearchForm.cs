#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Design;
using System.Web.Configuration;
using Captain.Common.Views.Forms.Base;
using Captain.Common.Utilities;
using Captain.Common.Menus;
using System.Data.SqlClient;
using Captain.Common.Model.Data;
using Captain.Common.Model.Objects;
using Gizmox.WebGUI.Common.Resources;
using Captain.Common.Views.UserControls.Base;
using Captain.Common.Exceptions;
using System.Diagnostics;
using Captain.Common.Views.Forms;

#endregion

namespace Captain.Common.Views.Forms
{


    public partial class SSNSearchForm : Form
    {
        #region private variables
        private CaptainModel _model = null;
        private string strNameFormat = string.Empty;
        private ErrorProvider _errorProvider = null;
        #endregion

        public SSNSearchForm()
        {
            _model = new CaptainModel();
            InitializeComponent();
            propFilterAllOrApp = string.Empty;
            _errorProvider = new ErrorProvider(this);
            _errorProvider.BlinkRate = 3;
            _errorProvider.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;
            _errorProvider.Icon = null;
            propScreenName = string.Empty;
        }

        public List<CaseSnpEntity> CaseSnpAllList { get; set; }
        public ProgramDefinitionEntity ProgramDefinition { get; set; }
        public CaseMstEntity CaseMST { get; set; }
        #region properties

        public BaseForm BaseForm { get; set; }
        public string propFilterType { get; set; }
        public string propFilterAllOrApp { get; set; }
        public string propScreenName { get; set; }
        #endregion


        public string strPageType = string.Empty;
        public SSNSearchForm(BaseForm baseForm, PrivilegeEntity Privileges, List<CaseMstSnpEntity> snplist,string strFirstName,string strLastName,string strDOB)
        {
            _model = new CaptainModel();
            InitializeComponent();
            _errorProvider = new ErrorProvider(this);
            _errorProvider.BlinkRate = 3;
            _errorProvider.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;
            _errorProvider.Icon = null;
            propScreenName = string.Empty;
            BaseForm = baseForm;
            cbduplicates.Visible = false;
            propFilterType = "H";
            propFilterAllOrApp = "ALL";
            strNameFormat = baseForm.BaseHierarchyCnFormat;
            if (Privileges.Program == "APPT0002")
            {
                propScreenName = Privileges.Program;
                lblDOB.Location = new Point(6, 5);
                lblSSN.Location = new Point(344, 56);
                mskSSNNO.Location = new Point(399, 52);
                dtBirth.Location = new Point(55, 5);
                DOBReq.Location = new Point(1, 5);
                lblssnreq.Location = new Point(332, 56);
                this.Text = Privileges.Program + " - Search";
                label8.Text = "Search";
                txtLastName.Text = strLastName;
                txtFirstName.Text = strFirstName;
                SsnNo.HeaderText = "DOB";
                if (strDOB != string.Empty)
                    dtBirth.Value = Convert.ToDateTime(strDOB);

                if (snplist != null)
                {
                    if (snplist.Count > 0)
                    {
                        gvwSSNSearch.SelectionChanged -= gvwSSNSearch_SelectionChanged;
                        gvwSSNSearch.Rows.Clear();


                        foreach (CaseMstSnpEntity CaseSnp in snplist)
                        {
                            string ApplicantName = LookupDataAccess.GetMemberName(CaseSnp.NameixFi, CaseSnp.NameixMi, CaseSnp.NameixLast, strNameFormat);

                            //if (IsDup.Equals("N"))
                            //{
                            //    if (listSSN.Exists(u => u.Equals(CaseSnp.Ssno.ToString() + ApplicantName))) continue;
                            //}


                            // listSSN.Add(CaseSnp.Ssno.ToString() + ApplicantName);
                            string Address = CaseSnp.Hn.Trim();
                            if (!CaseSnp.Street.Equals(string.Empty))
                            {
                                if (!Address.Equals(string.Empty)) { Address += " "; }
                                Address += CaseSnp.Street.Trim();
                            }
                            if (!CaseSnp.City.Equals(string.Empty))
                            {
                                if (!Address.Equals(string.Empty)) { Address += ", "; }
                                Address += CaseSnp.City.Trim();
                            }
                            if (!CaseSnp.State.Equals(string.Empty))
                            {
                                if (!Address.Equals(string.Empty)) { Address += ", "; }
                                Address += CaseSnp.State.Trim();
                            }
                            string phone = "   ".Substring(0, 3 - CaseSnp.Area.Length) + CaseSnp.Area + CaseSnp.Phone + "       ".Substring(0, 7 - CaseSnp.Phone.Length);


                            int rowIndex = gvwSSNSearch.Rows.Add(LookupDataAccess.Getdate(CaseSnp.AltBdate), ApplicantName, phone, Address);
                            gvwSSNSearch.Rows[rowIndex].Tag = CaseSnp;
                            if (CaseSnp.SnpActive.Equals("I"))
                                gvwSSNSearch.Rows[rowIndex].DefaultCellStyle.ForeColor = System.Drawing.Color.Red;



                        }
                        gvwSSNSearch.SelectionChanged += gvwSSNSearch_SelectionChanged;
                        if (gvwSSNSearch.Rows.Count > 0)
                        {
                            gvwSSNSearch_SelectionChanged(gvwSSNSearch, new EventArgs());
                        }

                    }
                }
            }
            //HierarchyEntity HierarchyEntity = CommonFunctions.GetHierachyNameFormat(baseForm.BaseAgency, baseForm.BaseDept, baseForm.BaseProg);
            //if (HierarchyEntity != null)
            //{
            //    strNameFormat = HierarchyEntity.CNFormat.ToString();
            //}
           // strNameFormat = baseForm.BaseHierarchyCnFormat;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseForm"></param>
        /// <param name="strPagetype">Pass the Programme Name</param>
        /// <param name="caseSnpEntitylist"></param>
        /// <param name="ProgramEntity"></param>
        /// <param name="casemst"></param>
        /// <param name="strFilterType">Must Pass H or A </param>
        /// where H is hierachy based filter or A is All hierachy based filter        
        /// <param name="FilterAllORApp">Must Pass APP or ALL or MEM </param>
        public SSNSearchForm(BaseForm baseForm, string strPagetype, List<CaseSnpEntity> caseSnpEntitylist, ProgramDefinitionEntity ProgramEntity, CaseMstEntity casemst, string strFilterType, string strFilterAllORApp)
        {
            _model = new CaptainModel();
            InitializeComponent();
            strPageType = strPagetype;
            CaseSnpAllList = caseSnpEntitylist;
            ProgramDefinition = ProgramEntity;
            CaseMST = casemst;
            propScreenName = string.Empty;
            _errorProvider = new ErrorProvider(this);
            _errorProvider.BlinkRate = 3;
            _errorProvider.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;
            _errorProvider.Icon = null;
            BaseForm = baseForm;
            propFilterType = strFilterType;
            propFilterAllOrApp = strFilterAllORApp;
            //HierarchyEntity HierarchyEntity = CommonFunctions.GetHierachyNameFormat(baseForm.BaseAgency, baseForm.BaseDept, baseForm.BaseProg);
            //if (HierarchyEntity != null)
            //{
            //    strNameFormat = HierarchyEntity.CNFormat.ToString();
            //}
            strNameFormat = baseForm.BaseHierarchyCnFormat;
            cbduplicates.Visible = false;
            //jen is asked Murali is Hided cbduplicates checkbox on 03/08/2021
            //if (propFilterType == "H")
            //    cbduplicates.Visible = false;
            //else
            //    cbduplicates.Visible = true;
        }

        public SSNSearchForm(BaseForm baseForm, string strSsnSearch, string strType)
        {
            _model = new CaptainModel();
            InitializeComponent();
            _errorProvider = new ErrorProvider(this);
            _errorProvider.BlinkRate = 3;
            _errorProvider.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;
            _errorProvider.Icon = null;
            BaseForm = baseForm;
            propScreenName = string.Empty;

            propFilterType = strType;
            propFilterAllOrApp = "App";
            //HierarchyEntity HierarchyEntity = CommonFunctions.GetHierachyNameFormat(baseForm.BaseAgency, baseForm.BaseDept, baseForm.BaseProg);
            //if (HierarchyEntity != null)
            //{
            strNameFormat = baseForm.BaseHierarchyCnFormat; //HierarchyEntity.CNFormat.ToString();
                                                            // }
            // Jen is asked Murali is Hided cbduplicates checkbox on 03/08/2021
            cbduplicates.Visible = false; 
            //if (propFilterType == "H")
            //    cbduplicates.Visible = false;
            //else
            //    cbduplicates.Visible = true;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lblFooter.Text = string.Empty;
            if (ValidateForm())
            {

                gvwSSNSearch.SelectionChanged -= gvwSSNSearch_SelectionChanged;
                gvwSSNSearch.Rows.Clear();
                string SSNNO = mskSSNNO.Text.ToString();
                string FirstName = txtFirstName.Text.ToString();
                string LastName = txtLastName.Text.ToString();
                string Alias = txtAlias.Text.ToString();
                string TelePhone = mskTelePhone.Text.ToString();
                string HouseNo = txtHouseNo.Text.ToString();
                string Street = txtStreet.Text.ToString();
                string City = txtCity.Text.ToString();
                string Phone = mskTelePhone.Text.ToString();
                string State = txtState.Text.ToString();
                string IsDup = cbduplicates.Checked ? "Y" : "N";
                string strDob = string.Empty;
                if (dtBirth.Checked)
                    strDob = dtBirth.Value.ToShortDateString();
                string Agency = string.Empty;
                string Dept = string.Empty;
                string Prog = string.Empty;
                string Year = string.Empty;
                if (propFilterType == "H")
                {
                    Agency = BaseForm.BaseAgency;
                    Dept = BaseForm.BaseDept;
                    Prog = BaseForm.BaseProg;
                    Year = BaseForm.BaseYear;
                }

                List<CaseMstSnpEntity> CaseSnpEntityList = _model.CaseMstData.GetSSNSearch(propFilterAllOrApp, SSNNO, FirstName, LastName, HouseNo, Street, City, State, Phone, Alias, IsDup, Agency, Dept, Prog, Year, BaseForm.UserID, BaseForm.BaseAgency + BaseForm.BaseDept + BaseForm.BaseProg, strDob);

                if (CaseSnpEntityList.Count > 0)
                {
                    int rowIndex;
                    string strSSN = string.Empty;
                    // List<string> listSSN = new List<string>(); //int rowIndex = 0;
                    foreach (CaseMstSnpEntity CaseSnp in CaseSnpEntityList)
                    {
                        string ApplicantName = LookupDataAccess.GetMemberName(CaseSnp.NameixFi, CaseSnp.NameixMi, CaseSnp.NameixLast, strNameFormat);

                        //if (IsDup.Equals("N"))
                        //{
                        //    if (listSSN.Exists(u => u.Equals(CaseSnp.Ssno.ToString() + ApplicantName))) continue;
                        //}


                        // listSSN.Add(CaseSnp.Ssno.ToString() + ApplicantName);
                        string Address = CaseSnp.Hn.Trim();
                        if (!CaseSnp.Street.Equals(string.Empty))
                        {
                            if (!Address.Equals(string.Empty)) { Address += " "; }
                            Address += CaseSnp.Street.Trim();
                        }
                        if (!CaseSnp.City.Equals(string.Empty))
                        {
                            if (!Address.Equals(string.Empty)) { Address += ", "; }
                            Address += CaseSnp.City.Trim();
                        }
                        if (!CaseSnp.State.Equals(string.Empty))
                        {
                            if (!Address.Equals(string.Empty)) { Address += ", "; }
                            Address += CaseSnp.State.Trim();
                        }
                        string phone = "   ".Substring(0, 3 - CaseSnp.Area.Length) + CaseSnp.Area + CaseSnp.Phone + "       ".Substring(0, 7 - CaseSnp.Phone.Length);

                        if(propScreenName == "APPT0002")
                        {
                            rowIndex = gvwSSNSearch.Rows.Add(LookupDataAccess.Getdate(CaseSnp.AltBdate), ApplicantName, phone, Address);
                        }
                        else
                        {
                            if (CaseSnp.Ssno.Trim() != string.Empty)
                                strSSN = LookupDataAccess.GetPhoneSsnNoFormat(CaseSnp.Ssno);
                            
                            rowIndex = gvwSSNSearch.Rows.Add(strSSN, ApplicantName, phone, Address);
                        }
                         
                        gvwSSNSearch.Rows[rowIndex].Tag = CaseSnp;
                        if (CaseSnp.SnpActive.Equals("I"))
                            gvwSSNSearch.Rows[rowIndex].DefaultCellStyle.ForeColor = System.Drawing.Color.Red;



                    }
                }
                else
                {
                    CommonFunctions.MessageBoxDisplay("No Record Found..");
                }
                gvwSSNSearch.SelectionChanged += gvwSSNSearch_SelectionChanged;
                if (gvwSSNSearch.Rows.Count > 0)
                {
                    gvwSSNSearch_SelectionChanged(gvwSSNSearch, new EventArgs());
                }
            }
        }

        public CaseMstSnpEntity GetSelectedRow()
        {
            CaseMstSnpEntity entity = null;
            if (gvwSSNSearch != null)
            {
                foreach (DataGridViewRow dr in gvwSSNSearch.SelectedRows)
                {
                    if (dr.Selected)
                    {
                        entity = dr.Tag as CaseMstSnpEntity;
                        string DOB = string.Empty;
                        if (!entity.AltBdate.Equals(string.Empty))
                        {
                            DOB = CommonFunctions.ChangeDateFormat(entity.AltBdate, Consts.DateTimeFormats.DateSaveFormat, Consts.DateTimeFormats.DateDisplayFormat);
                        }
                        string yr = entity.Year.Equals(string.Empty) ? "    " : entity.Year;
                        lblFooter.Text = entity.Agency + "  " + entity.Dept + "  " + entity.Program + " " + yr + "   App #" + entity.ApplNo + "       DOB : " + DOB;
                        break;
                    }
                }
            }
            return entity;
        }

        private void btnSSNSelect_Click(object sender, EventArgs e)
        {
            if (strPageType == "Case2001")
            {

                CaseMstSnpEntity CaseMSTSnp = GetSelectedRow();
                if (CaseMSTSnp != null)
                {
                    if (CaseMSTSnp.Ssno != "000000000" && CaseMSTSnp.Ssno.ToUpper() != "NEWSSNNUM")
                    {
                        CaseSnpAllList = _model.CaseMstData.GetCaseSnpSSno(CaseMSTSnp.Ssno);
                        if (ProgramDefinition.ProDupMEM.Equals("Y"))
                        {
                            CaseSnpEntity casesnpssnoEntity = CaseSnpAllList.Find(u => u.Agency.Equals(CaseMST.ApplAgency) && u.Dept.Equals(CaseMST.ApplDept) && u.Program.Equals(CaseMST.ApplProgram) && u.Year.Trim().Equals(CaseMST.ApplYr.Trim()) && u.App.Equals(CaseMST.ApplNo) && u.Ssno.Equals(CaseMSTSnp.Ssno));
                            if (casesnpssnoEntity != null)
                            {
                                CommonFunctions.MessageBoxDisplay("SSN Number already exist in this family");

                            }

                            else
                            {
                                CaseSnpEntity casesnpAlllistEntity = CaseSnpAllList.Find(u => u.Agency.Equals(CaseMST.ApplAgency) && u.Dept.Equals(CaseMST.ApplDept) && u.Program.Equals(CaseMST.ApplProgram) && u.Year.Trim().Equals(CaseMST.ApplYr.Trim()) && u.Ssno.Equals(CaseMSTSnp.Ssno));
                                if (casesnpAlllistEntity != null)
                                {
                                    CommonFunctions.MessageBoxDisplay("Member already exists in App#: " + casesnpAlllistEntity.App);

                                }
                                else
                                {
                                    this.DialogResult = DialogResult.OK;
                                    this.Close();
                                    //List<CaseSnpEntity> casesnpssnosearchEntity = CaseSnpAllList.FindAll(u => u.Ssno.Equals(mskSSN.Text));
                                    //if (casesnpssnosearchEntity != null)
                                    //{
                                    //    if (casesnpssnosearchEntity.Count != 0)
                                    //    {
                                    //        if (casesnpssnosearchEntity.Count == 1)
                                    //        {
                                    //            // mskSSN.Text = selectedSsn.Ssno;
                                    //            AltAgency = casesnpssnosearchEntity[0].Agency;
                                    //            AltDept = casesnpssnosearchEntity[0].Dept;
                                    //            AltProgram = casesnpssnosearchEntity[0].Program;
                                    //            AltYear = casesnpssnosearchEntity[0].Year;
                                    //            AltApp = casesnpssnosearchEntity[0].App.Substring(0, 8);
                                    //            AltFamilySeq = casesnpssnosearchEntity[0].FamilySeq;
                                    //            SearchSnpType = "SSNSEARCH";
                                    //            fillCaseSnpDetails(AltAgency.ToString(), AltDept.ToString(), AltProgram.ToString(), AltYear.ToString(), AltApp.ToString(), AltFamilySeq.ToString());
                                    //        }
                                    //        else
                                    //        {
                                    //            SsnScanForm SsnScanForm = new SsnScanForm(BaseForm, mskSSN.Text);
                                    //            SsnScanForm.FormClosed += new Form.FormClosedEventHandler(OnSsnScanSearchFormClosed);
                                    //            SsnScanForm.ShowDialog();
                                    //        }
                                    //    }
                                    //}

                                }
                            }



                        }
                        else
                        {
                            CaseSnpEntity casesnpssnoEntity = CaseSnpAllList.Find(u => u.Agency.Equals(CaseMST.ApplAgency) && u.Dept.Equals(CaseMST.ApplDept) && u.Program.Equals(CaseMST.ApplProgram) && u.Year.Trim().Equals(CaseMST.ApplYr.Trim()) && u.App.Equals(CaseMST.ApplNo) && u.Ssno.Equals(CaseMSTSnp.Ssno));
                            if (casesnpssnoEntity != null)
                            {
                                CommonFunctions.MessageBoxDisplay("SSN Number already exist in this family");

                            }
                            else
                            {
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }

                        }

                    }
                    else
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void gvwSSNSearch_SelectionChanged(object sender, EventArgs e)
        {
            if (gvwSSNSearch.Rows.Count > 0 && gvwSSNSearch.SelectedRows.Count > 0)
            {
                CaseMstSnpEntity entity = gvwSSNSearch.SelectedRows[0].Tag as CaseMstSnpEntity;
                string DOB = string.Empty;
                if (!entity.AltBdate.Equals(string.Empty))
                {
                    DOB = CommonFunctions.ChangeDateFormat(entity.AltBdate, Consts.DateTimeFormats.DateSaveFormat, Consts.DateTimeFormats.DateDisplayFormat);
                }
                string yr = entity.Year.Equals(string.Empty) ? "    " : entity.Year;

                lblFooter.Text = entity.Agency + "  " + entity.Dept + "  " + entity.Program + "  " + yr + "  App #" + entity.ApplNo + "       DOB : " + DOB;
            }
        }

        private bool ValidateForm()
        {
            bool isValid = true;


            if (String.IsNullOrEmpty(mskSSNNO.Text.Trim()) && String.IsNullOrEmpty(txtAlias.Text.Trim()) && String.IsNullOrEmpty(txtCity.Text.Trim()) && String.IsNullOrEmpty(txtFirstName.Text.Trim()) && String.IsNullOrEmpty(txtHouseNo.Text.Trim()) && String.IsNullOrEmpty(txtLastName.Text.Trim()) && String.IsNullOrEmpty(txtState.Text.Trim()) && String.IsNullOrEmpty(txtStreet.Text.Trim()) && string.IsNullOrEmpty(mskTelePhone.Text) && (dtBirth.Checked == false))
            {
                CommonFunctions.MessageBoxDisplay("Please enter atleast one item");
                isValid = false;
            }
            else
            {
                _errorProvider.SetError(mskSSNNO, null);
            }
            //if (dtBirth.Checked == false)
            //{
            //    _errorProvider.SetError(dtBirth, string.Format(Consts.Messages.BlankIsRequired.GetMessage(), lblDOB.Text));
            //    isValid = false;
            //}
            //else
            //{
            //    _errorProvider.SetError(dtBirth, null);
            //}
            return (isValid);
        }

    }
}