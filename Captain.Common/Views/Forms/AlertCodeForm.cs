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
using Captain.Common.Views.Forms.Base;
using Captain.Common.Utilities;

#endregion

namespace Captain.Common.Views.Forms
{
    public partial class AlertCodeForm : Form
    {
        private CaptainModel _model = null;
        public AlertCodeForm(BaseForm baseForm, PrivilegeEntity privileges, string strAlertCode, CaseMstEntity caseMst)
        {
            InitializeComponent();
            BaseForm = baseForm;
            Privileges = privileges;
            _model = new CaptainModel();
            CaseMST = caseMst;
            propType = string.Empty;
            propAlertCode = strAlertCode;
            if (Privileges.AddPriv.Equals("true") || Privileges.ChangePriv.Equals("true"))
            {
                btnOk.Enabled = true;
            }
            fillAlertCode(strAlertCode);
            this.gvwAlertCode.Size = new System.Drawing.Size(215, 204);
            this.Size = new System.Drawing.Size(230, 234);
            this.btnOk.Location = new System.Drawing.Point(111, 209);
            this.btnClose.Location = new System.Drawing.Point(168, 209);
            gvwAlertCode.Columns["gvtInterval"].Visible = false;
            this.Item.HeaderText = "Items";
        }

        public BaseForm BaseForm { get; set; }
        public PrivilegeEntity Privileges { get; set; }
        public CaseMstEntity CaseMST { get; set; }
        public CaseSnpEntity propcasesnp { get; set; }
        public string propAlertCode { get; set; }
        public string propType { get; set; }
        public string propFieldCode { get; set; }
        public string propResponseCodes { get; set; }
        public void fillAlertCode(string strAlertCode)
        {

            List<string> alertCodesList = new List<string>();
            string AlertCodes = strAlertCode;
            if (!string.IsNullOrEmpty(AlertCodes))
            {
                string[] alertCodes = AlertCodes.Split(' ');
                for (int i = 0; i < alertCodes.Length; i++)
                {
                    alertCodesList.Add(alertCodes.GetValue(i).ToString());
                }
            }
            List<CommonEntity> listCodes = _model.lookupDataAccess.GetAlertCodes();
            listCodes = filterByHIE(listCodes);
            int rowIndex = 0;
            foreach (CommonEntity alertCodes in listCodes)
            {
                rowIndex = gvwAlertCode.Rows.Add(false, alertCodes.Code + " - " + alertCodes.Desc, alertCodes.Code);

                if (alertCodesList.Contains(alertCodes.Code))
                {
                    gvwAlertCode.Rows[rowIndex].Cells["Select"].Value = true;
                }


            }

        }

        private List<CommonEntity> filterByHIE(List<CommonEntity> LookupValues)
        {
            string HIE = BaseForm.BaseAgency + BaseForm.BaseDept + BaseForm.BaseProg;
            LookupValues = LookupValues.FindAll(u => u.ListHierarchy.Contains(HIE) || u.ListHierarchy.Contains(BaseForm.BaseAgency + BaseForm.BaseDept + "**") || u.ListHierarchy.Contains(BaseForm.BaseAgency + "****") || u.ListHierarchy.Contains("******"));
            return LookupValues;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {


            if (propType == "Income")
            {
                //CaseIncomeEntity caseIncomeEntity = new CaseIncomeEntity();
                //caseIncomeEntity.Agency = BaseForm.BaseAgency;
                //caseIncomeEntity.Dept = BaseForm.BaseDept;
                //caseIncomeEntity.Program = BaseForm.BaseProg;
                //caseIncomeEntity.Year = BaseForm.BaseYear;
                //caseIncomeEntity.App = BaseForm.BaseApplicationNo;
                //caseIncomeEntity.FamilySeq = propcasesnp.FamilySeq ;
                //caseIncomeEntity.Seq = string.Empty;
                //if (_model.CaseMstData.DeleteCaseIncome(caseIncomeEntity))
                //{

                //    foreach (DataGridViewRow gvRows in gvwAlertCode.Rows)
                //    {
                //        if (gvRows.Cells["Select"].Value != null && Convert.ToBoolean(gvRows.Cells["Select"].Value) == true)
                //        {
                //            caseIncomeEntity.Type = Convert.ToString(gvRows.Cells["AlertCode"].Value);
                //            caseIncomeEntity.Interval = "O";
                //            caseIncomeEntity.Val1 = string.Empty;
                //            caseIncomeEntity.Val2 = string.Empty;
                //            caseIncomeEntity.Val3 = string.Empty;
                //            caseIncomeEntity.Val4 = string.Empty;
                //            caseIncomeEntity.Val5 = string.Empty;
                //            caseIncomeEntity.Date1 = string.Empty;
                //            caseIncomeEntity.Date2 = string.Empty;
                //            caseIncomeEntity.Date3 = string.Empty;
                //            caseIncomeEntity.Date4 = string.Empty;
                //            caseIncomeEntity.Date5 = string.Empty;

                //            caseIncomeEntity.LstcOperator = BaseForm.UserID;
                //            caseIncomeEntity.AddOperator = BaseForm.UserID;
                //            caseIncomeEntity.Mode ="Type";
                //            //txtSub.Text;                
                //            if (_model.CaseMstData.InsertCaseIncome(caseIncomeEntity))
                //            { }
                //        }
                //    }
                //}

            }
            else if(propType == "IncomePIP")
            {
                string selectedCode = string.Empty;
                foreach (DataGridViewRow gvRows in gvwAlertCode.Rows)
                {
                    if (gvRows.Cells["Select"].Value != null && Convert.ToBoolean(gvRows.Cells["Select"].Value) == true)
                    {
                        if (!selectedCode.Equals(string.Empty))
                        {
                            selectedCode += ",";
                            selectedCode += gvRows.Cells["AlertCode"].Value;
                        }
                        else
                        {
                            selectedCode += gvRows.Cells["AlertCode"].Value;
                        }

                    }
                }
                propAlertCode = selectedCode;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else if (propType == "Custom")
            {
                string selectedCode = string.Empty;
                foreach (DataGridViewRow gvRows in gvwAlertCode.Rows)
                {
                    if (gvRows.Cells["Select"].Value != null && Convert.ToBoolean(gvRows.Cells["Select"].Value) == true)
                    {
                        if (!selectedCode.Equals(string.Empty))
                        {
                            selectedCode += ",";
                            selectedCode += gvRows.Cells["AlertCode"].Value;
                        }
                        else
                        {
                            selectedCode += gvRows.Cells["AlertCode"].Value;
                        }

                    }
                }
                propAlertCode = selectedCode;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else if (propType == "SAL")
            {
                string selectedCode = string.Empty;
                foreach (DataGridViewRow gvRows in gvwAlertCode.Rows)
                {
                    if (gvRows.Cells["Select"].Value != null && Convert.ToBoolean(gvRows.Cells["Select"].Value) == true)
                    {
                        if (!selectedCode.Equals(string.Empty))
                        {
                            selectedCode += ",";
                            selectedCode += gvRows.Cells["AlertCode"].Value.ToString().Trim();
                        }
                        else
                        {
                            selectedCode += gvRows.Cells["AlertCode"].Value.ToString().Trim();
                        }

                    }
                }
                propAlertCode = selectedCode;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {

                if (CaseMST != null)
                {
                    if (Privileges.AddPriv.Equals("true") || Privileges.ChangePriv.Equals("true"))
                    {
                        string selectedCode = string.Empty;
                        foreach (DataGridViewRow gvRows in gvwAlertCode.Rows)
                        {
                            if (gvRows.Cells["Select"].Value != null && Convert.ToBoolean(gvRows.Cells["Select"].Value) == true)
                            {
                                if (!selectedCode.Equals(string.Empty))
                                {
                                    selectedCode += " ";
                                    selectedCode += gvRows.Cells["AlertCode"].Value;
                                }
                                else
                                {
                                    selectedCode += gvRows.Cells["AlertCode"].Value;
                                }

                            }
                        }

                        selectedCode = selectedCode.Replace("  ", " ");
                        selectedCode = selectedCode.TrimStart();
                        // List<string> strALertcode = new List<string>(selectedCode.Split(' '));
                        if (selectedCode.Length <= 11)
                        {
                            //foreach (string item in strALertcode)
                            //{
                            //    txtAlertCodes.Text = item.ToString() + " ";
                            //}

                            // string selectcodeLength = selectedCode.);


                            CaseMstEntity CaseMstEntity = new CaseMstEntity();

                            CaseMstEntity.ApplAgency = CaseMST.ApplAgency;
                            CaseMstEntity.ApplDept = CaseMST.ApplDept;
                            CaseMstEntity.ApplProgram = CaseMST.ApplProgram;
                            CaseMstEntity.ApplYr = CaseMST.ApplYr;
                            CaseMstEntity.ApplNo = CaseMST.ApplNo;
                            CaseMstEntity.LstcOperator4 = BaseForm.UserID;
                            CaseMstEntity.AlertCodes = selectedCode;
                            CaseMstEntity.Mode = "AlertCodes";
                            string strApplNo = string.Empty;
                            string strClientId = string.Empty;
                            string strFamilyId = string.Empty;
                            string strNewSSNNO = string.Empty;
                            string strErrorMsg = string.Empty;                         
                            if (_model.CaseMstData.InsertUpdateCaseMst(CaseMstEntity, out strApplNo, out strClientId, out strFamilyId, out strNewSSNNO, out strErrorMsg))
                            {
                                if (Privileges.Program == "CASE2001")
                                {
                                    CheckHistoryTableData(propAlertCode, selectedCode);
                                }
                                propAlertCode = selectedCode;
                                BaseForm.BaseCaseMstListEntity[0].AlertCodes = selectedCode;

                                this.Close();
                            }
                        }
                        else
                        {
                            CommonFunctions.MessageBoxDisplay("You Can't Add More Than 6 Alert Codes");
                        }
                    }

                }
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        int Sel_Count = 0;
        private void gvwAlertCode_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gvwAlertCode.Rows.Count > 0)
            {
                if (propType == "Custom" || propType == "SAL" || propType == "IncomePIP")
                {                    
                
                }
                else
                {
                    string selectedCode = string.Empty;
                    foreach (DataGridViewRow gvRows in gvwAlertCode.Rows)
                    {
                        if (gvRows.Cells["Select"].Value != null && Convert.ToBoolean(gvRows.Cells["Select"].Value) == true)
                        {
                            if (!selectedCode.Equals(string.Empty))
                            {
                                selectedCode += " ";
                                selectedCode += gvRows.Cells["AlertCode"].Value;
                            }
                            else
                            {
                                selectedCode += gvRows.Cells["AlertCode"].Value;
                            }

                        }
                    }
                    selectedCode = selectedCode.Replace("  ", " ");
                    selectedCode = selectedCode.TrimStart();
                    // List<string> strALertcode = new List<string>(selectedCode.Split(' '));
                    if (selectedCode.Length <= 11)
                    { }
                    else
                    {
                        gvwAlertCode.CurrentRow.Cells["Select"].Value = false;
                        CommonFunctions.MessageBoxDisplay("You Can't Add More Than 6 Alert Codes");

                    }
                }
            }
        }


        private void CheckHistoryTableData(string oldcode, string newcode)
        {
            string strHistoryDetails = "<XmlHistory>";
            bool boolHistory = false;



            if (oldcode.ToUpper().Trim() != newcode.ToUpper().Trim())
            {
                boolHistory = true;
                strHistoryDetails = strHistoryDetails + "<HistoryFields><FieldName>Alert Codes</FieldName><OldValue>" + oldcode + "</OldValue><NewValue>" + newcode + "</NewValue></HistoryFields>";
            }


            strHistoryDetails = strHistoryDetails + "</XmlHistory>";
            if (boolHistory)
            {
                CaseHistEntity caseHistEntity = new CaseHistEntity();
                caseHistEntity.HistTblName = "CASEMST";
                caseHistEntity.HistScreen = "CASE2001";
                caseHistEntity.HistTblKey = BaseForm.BaseAgency + BaseForm.BaseDept + BaseForm.BaseProg + BaseForm.BaseYear + BaseForm.BaseApplicationNo + BaseForm.BaseCaseMstListEntity[0].FamilySeq;
                caseHistEntity.LstcOperator = BaseForm.UserID;
                caseHistEntity.HistChanges = strHistoryDetails;
                _model.CaseMstData.InsertCaseHist(caseHistEntity);
            }


        }

        /// <summary>
        /// Case Income Types filling functionality
        /// </summary>
        /// <param name="baseForm"></param>
        /// <param name="privileges"></param>
        /// <param name="strAlertCode"></param>
        /// <param name="caseMst"></param>
        public AlertCodeForm(BaseForm baseForm, PrivilegeEntity privileges, CaseSnpEntity casesnp)
        {
            InitializeComponent();
            BaseForm = baseForm;
            this.Text = "Income Types";
            Privileges = privileges;
            _model = new CaptainModel();
            propType = "Income";
            propcasesnp = casesnp;
            if (Privileges.AddPriv.Equals("true") || Privileges.ChangePriv.Equals("true"))
            {
                btnOk.Enabled = true;
            }
            fillIncomes();
        }


        /// <summary>
        /// Case Income Types filling functionality
        /// </summary>
        /// <param name="baseForm"></param>
        /// <param name="privileges"></param>
        /// <param name="strAlertCode"></param>
        
        public AlertCodeForm(BaseForm baseForm, string strIncomeTypes, PrivilegeEntity privileges)
        {
            InitializeComponent();
            BaseForm = baseForm;
            this.Text = "Income Types";
            Privileges = privileges;
            _model = new CaptainModel();
            propType = "IncomePIP";
           
            if (Privileges.AddPriv.Equals("true") || Privileges.ChangePriv.Equals("true"))
            {
                btnOk.Enabled = true;
            }
            fillIncomesTypesPIPAdmin(strIncomeTypes);
        }
        
        void fillIncomes()
        {
            List<AgyTabEntity> lookUpIncomeTypes = _model.lookupDataAccess.GetIncomeTypes();
            List<CaseIncomeEntity> caseIncomeList = _model.CaseMstData.GetCaseIncomeadpynf(BaseForm.BaseAgency, BaseForm.BaseDept, BaseForm.BaseProg, BaseForm.BaseYear, BaseForm.BaseApplicationNo, propcasesnp.FamilySeq);
            bool boolexist = false;
            foreach (AgyTabEntity agyEntity in lookUpIncomeTypes)
            {
                boolexist = false;
                if (caseIncomeList.Count > 0)
                {
                    CaseIncomeEntity caseincometypes = caseIncomeList.Find(u => u.Type.Trim() == agyEntity.agycode);
                    if (caseincometypes != null)
                        boolexist = true;
                }

                int index = gvwAlertCode.Rows.Add(boolexist, agyEntity.agydesc, agyEntity.agycode, "None");

                gvwAlertCode.Rows[index].Tag = agyEntity;

            }

        }

        void fillIncomesTypesPIPAdmin(string strIncomeTypes)
        {
            List<AgyTabEntity> lookUpIncomeTypes = _model.lookupDataAccess.GetIncomeTypes();
             bool boolexist = false;
            string response = strIncomeTypes;
            string[] arrResponse = null;
            if (response.IndexOf(',') > 0)
            {
                arrResponse = response.Split(',');
            }
            else if (!response.Equals(string.Empty))
            {
                arrResponse = new string[] { response };
            }

            gvtInterval.Visible = false;
            AlertCode.Visible = true;
            AlertCode.HeaderText = "Code";
            Item.Width = 255;

            foreach (AgyTabEntity agyEntity in lookUpIncomeTypes)
            {
                boolexist = false;
                string resDesc = agyEntity.agycode.ToString().Trim();


                if (arrResponse != null && arrResponse.ToList().Exists(u => u.Equals(resDesc)))
                {
                    boolexist = true;
                }
                int index = gvwAlertCode.Rows.Add(boolexist, agyEntity.agydesc, agyEntity.agycode, "None");

                gvwAlertCode.Rows[index].Tag = agyEntity;
            }
           

        }

        void fillCustomResponce()
        {
            List<CustRespEntity> custReponseEntity = _model.FieldControls.GetCustomResponses("CASE2001", propFieldCode);
            if (custReponseEntity.Count > 0)
            {
                string response = propResponseCodes;
                string[] arrResponse = null;
                if (response.IndexOf(',') > 0)
                {
                    arrResponse = response.Split(',');
                }
                else if (!response.Equals(string.Empty))
                {
                    arrResponse = new string[] { response };
                }
                bool boolexist = false;
                foreach (CustRespEntity dr in custReponseEntity)
                {
                    boolexist = false;
                    string resDesc = dr.DescCode.ToString().Trim();

                    
                    if (arrResponse != null && arrResponse.ToList().Exists(u => u.Equals(resDesc)))
                    {
                        boolexist = true;
                    }
                    int index = gvwAlertCode.Rows.Add(boolexist, dr.RespDesc, dr.DescCode, "None");

                    //gvwAlertCode.Rows[index].Tag = agyEntity;
                }
            }

        }

        void fillSalResponses()
        {
            List<CustRespEntity> custReponseEntity = _model.FieldControls.GetCustomResponses("CASE2001", propFieldCode);
            if (custReponseEntity.Count > 0)
            {
                string response = propResponseCodes;
                string[] arrResponse = null;
                if (response.IndexOf(',') > 0)
                {
                    arrResponse = response.Split(',');
                }
                else if (!response.Equals(string.Empty))
                {
                    arrResponse = new string[] { response };
                }
                bool boolexist = false;
                foreach (CustRespEntity dr in custReponseEntity)
                {
                    boolexist = false;
                    string resDesc = dr.DescCode.ToString().Trim();


                    if (arrResponse != null && arrResponse.ToList().Exists(u => u.Equals(resDesc)))
                    {
                        boolexist = true;
                    }
                    int index = gvwAlertCode.Rows.Add(boolexist, dr.RespDesc, dr.DescCode, "None");

                    //gvwAlertCode.Rows[index].Tag = agyEntity;
                }
            }

        }

        public AlertCodeForm(BaseForm baseForm, PrivilegeEntity privileges, string strCustomData, string FieldCode)
        {
            InitializeComponent();
            BaseForm = baseForm;
            this.Text = "CheckBox Response";
            Privileges = privileges;
            _model = new CaptainModel();
            propType = "Custom";

            //this.gvtInterval
            this.AlertCode.Visible = true;
            this.AlertCode.HeaderText = "Code";
            this.AlertCode.Width = 40;
            this.gvwAlertCode.Size = new System.Drawing.Size(275, 204);
            //this.Size = new System.Drawing.Size(230, 234);
            //this.btnOk.Location = new System.Drawing.Point(111, 209);
            //this.btnClose.Location = new System.Drawing.Point(168, 209);

            this.Size = new System.Drawing.Size(285, 234);
            //this.Size = new System.Drawing.Size(265, 234); original
            this.btnOk.Location = new System.Drawing.Point(150, 209);
            this.btnClose.Location = new System.Drawing.Point(205, 209);
            btnClose.Text = "Cancel";
            gvwAlertCode.Columns["gvtInterval"].Visible = false;
            this.Item.HeaderText = "Description";
            if (Privileges.AddPriv.Equals("true") || Privileges.ChangePriv.Equals("true"))
            {
                btnOk.Enabled = true;
            }
            propFieldCode = FieldCode;
            propResponseCodes = strCustomData;
            fillCustomResponce();
        }


        public AlertCodeForm(BaseForm baseForm, PrivilegeEntity privileges, string strCustomData, string FieldCode,SalquesEntity _salquesentity)
        {
            InitializeComponent();
            BaseForm = baseForm;
            this.Text = "Question Response";
            Privileges = privileges;
            _model = new CaptainModel();
            propType = "Custom";

            //this.gvtInterval
            this.AlertCode.Visible = true;
            this.AlertCode.HeaderText = "Code";
            this.AlertCode.Width = 40;
            this.gvwAlertCode.Size = new System.Drawing.Size(275, 204);
            //this.Size = new System.Drawing.Size(230, 234);
            //this.btnOk.Location = new System.Drawing.Point(111, 209);
            //this.btnClose.Location = new System.Drawing.Point(168, 209);

            this.Size = new System.Drawing.Size(285, 234);
            //this.Size = new System.Drawing.Size(265, 234); original
            this.btnOk.Location = new System.Drawing.Point(150, 209);
            this.btnClose.Location = new System.Drawing.Point(205, 209);
            btnClose.Text = "Cancel";
            gvwAlertCode.Columns["gvtInterval"].Visible = false;
            this.Item.HeaderText = "Description";
            if (Privileges.AddPriv.Equals("true") || Privileges.ChangePriv.Equals("true"))
            {
                btnOk.Enabled = true;
            }
            propFieldCode = FieldCode;
            propResponseCodes = strCustomData;
            fillSALResponses();
        }


        public AlertCodeForm(BaseForm baseForm, PrivilegeEntity privileges, string strCustomData, string FieldCode,string strType)
        {
            InitializeComponent();
            BaseForm = baseForm;
            if (strType == "HEALTH")
            {
                this.Text = "Health Insurance";
            }
            else if (strType == "Non-Cash Benefits")
            {
                this.Text = "Non-Cash Benefits";
            }
            else if (strType == "Funds")
            {
                this.Text = "Funds";
            }
            Privileges = privileges;
            _model = new CaptainModel();
            propType = "Custom";

            //this.gvtInterval
            this.AlertCode.Visible = true;
            this.AlertCode.HeaderText = "Code";
            this.Size = new System.Drawing.Size(300, 234);
            gvwAlertCode.Size = new System.Drawing.Size(290, 204);
            this.btnOk.Location = new System.Drawing.Point(180, 209);
            this.btnClose.Location = new System.Drawing.Point(235, 209);
            btnClose.Text = "Cancel";
            gvwAlertCode.Columns["gvtInterval"].Visible = false;
            this.Item.HeaderText = "Description";
            if (Privileges.AddPriv.Equals("true") || Privileges.ChangePriv.Equals("true"))
            {
                btnOk.Enabled = true;
            }
            propFieldCode = FieldCode;
            propResponseCodes = strCustomData;
            propAlertCode = strCustomData;
            if (strType.ToUpper() == "SERVICES")
            {
                
                fillServices();
            }
            else
            {
                fillHealthInsurance();
            }
        }

        void fillHealthInsurance()
        {

            List<CommonEntity> HealthInsurance = new List<CommonEntity>();
            if (propFieldCode == "00501")
            {
                HealthInsurance = _model.lookupDataAccess.GetAgyFunds();
            }
            else if(propFieldCode.ToUpper()=="FUNDS")
            {
                HealthInsurance.Add(new CommonEntity("9","All Funds"));
                HealthInsurance.Add(new CommonEntity("H","HS"));
                HealthInsurance.Add(new CommonEntity("2","HS2" ));
                HealthInsurance.Add(new CommonEntity("E","EHS" ));
                HealthInsurance.Add(new CommonEntity("S","EHSCCP"));
            }
            else
            {
                HealthInsurance = CommonFunctions.AgyTabsFilterCode(BaseForm.BaseAgyTabsEntity, propFieldCode, BaseForm.BaseAgency, BaseForm.BaseDept, BaseForm.BaseProg, string.Empty); //_model.lookupDataAccess.GetHealthInsurance();
            }
            if (HealthInsurance.Count > 0)
            {
                string response = propResponseCodes;
                string[] arrResponse = null;
                if (response.IndexOf(',') > 0)
                {
                    arrResponse = response.Split(',');
                }
                else if (!response.Equals(string.Empty))
                {
                    arrResponse = new string[] { response };
                }
                bool boolexist = false;
                foreach (CommonEntity dr in HealthInsurance)
                {
                    boolexist = false;
                    string resDesc = dr.Code.ToString().Trim();


                    if (arrResponse != null && arrResponse.ToList().Exists(u => u.Equals(resDesc)))
                    {
                        boolexist = true;
                    }
                    int index = gvwAlertCode.Rows.Add(boolexist, dr.Desc, dr.Code, "None");

                    //gvwAlertCode.Rows[index].Tag = agyEntity;
                }
            }

        }

        public AlertCodeForm(BaseForm baseForm, PrivilegeEntity privileges, string strCustomData, string FieldCode, string QuestionDesc,string SAL)
        {
            InitializeComponent();
            BaseForm = baseForm;
            
                this.Text = QuestionDesc;
            Privileges = privileges;
            _model = new CaptainModel();
            propType = "SAL";

            //this.gvtInterval
            this.AlertCode.Visible = false;
            this.AlertCode.HeaderText = "Code";
            this.Item.Width = 250;
            this.Size = new System.Drawing.Size(300, 234);
            gvwAlertCode.Size = new System.Drawing.Size(290, 204);
            this.btnOk.Location = new System.Drawing.Point(190, 209);
            this.btnClose.Location = new System.Drawing.Point(245, 209);
            //this.btnOk.Location = new System.Drawing.Point(150, 209);
            //this.btnClose.Location = new System.Drawing.Point(205, 209);
            btnClose.Text = "Cancel";
            gvwAlertCode.Columns["gvtInterval"].Visible = false;
            gvwAlertCode.Columns["AlertCode"].Visible = false;
            
            this.Item.HeaderText = "Description";
            if (Privileges.AddPriv.Equals("true") || Privileges.ChangePriv.Equals("true"))
            {
                btnOk.Enabled = true;
            }
            propFieldCode = FieldCode;
            propResponseCodes = strCustomData;
            propAlertCode = strCustomData;
            fillSALResponses();
        }

        void fillSALResponses()
        {
            //List<CustRespEntity> custReponseEntity = _model.FieldControls.GetCustomResponses("CASE2001", propFieldCode);

            SalqrespEntity Search_entity = new SalqrespEntity(true);
            Search_entity.SALQR_Q_ID = propFieldCode;

            List<SalqrespEntity> SALResponseEntity = _model.SALDEFData.Browse_SALQRESP(Search_entity, "Browse");
            if (SALResponseEntity.Count > 0)
            {
                string response = propResponseCodes;
                string[] arrResponse = null;
                if (response.IndexOf(',') > 0)
                {
                    arrResponse = response.Split(',');
                }
                else if (!response.Equals(string.Empty))
                {
                    arrResponse = new string[] { response };
                }
                bool boolexist = false;
                foreach (SalqrespEntity dr in SALResponseEntity)
                {
                    boolexist = false;
                    string resDesc = dr.SALQR_CODE.ToString().Trim();


                    if (arrResponse != null && arrResponse.ToList().Exists(u => u.Trim().Equals(resDesc)))
                    {
                        boolexist = true;
                    }
                    int index = gvwAlertCode.Rows.Add(boolexist, dr.SALQR_DESC, dr.SALQR_CODE.Trim(), "None");

                    //gvwAlertCode.Rows[index].Tag = agyEntity;
                }
            }

        }

        public AlertCodeForm(BaseForm baseForm,string strType,DataTable dt)
        {
            InitializeComponent();
            BaseForm = baseForm;
            this.Text = strType;
           
            _model = new CaptainModel();
            propType = strType;

           
                btnOk.Visible = false;

            fillPipEmailHistory(dt);

        }

        void fillPipEmailHistory(DataTable dt)
        {
            bool boolexist = false;
          
            Item.HeaderText = "Email Sender Name";
            AlertCode.HeaderText = "Date";
            gvtInterval.Visible = false;
            AlertCode.Visible = true;
            Select.Visible = false;
            AlertCode.Width = 120;

            foreach (DataRow dr in dt.Rows)
            {
                boolexist = false;
                
                int index = gvwAlertCode.Rows.Add(boolexist, dr["PIPMAILH_SENT_BY"].ToString(), dr["PIPMAILH_DATE_SENT"].ToString(), string.Empty);

                gvwAlertCode.Rows[index].Tag = dr;
            }


        }

        void fillServices()
        {
            string strAgency = "00";
            if (BaseForm.BaseAgencyControlDetails.PIPSwitch.Trim() == "I")
            {
                strAgency = BaseForm.BaseAgency;
            }

            string strType = string.Empty;
            if (BaseForm.BaseAgencyControlDetails.ServinqCaseHie == "0")
            {
                this.Text = "Services";
                strType = "CAMAST";
            }
            else if (BaseForm.BaseAgencyControlDetails.ServinqCaseHie == "1")
            {
                this.Text = "Programs";
                strType = "CASEHIE";
            }
            else if (BaseForm.BaseAgencyControlDetails.ServinqCaseHie == "2")
            {
                this.Text = "Services";
                strType = "CASESER";
            }

            //DataTable dtservice = PIPDATA.GETPIPSERVICES(BaseForm.BaseLeanDataBaseConnectionString, strType, BaseForm.BaseAgencyControlDetails.AgyShortName, strAgency);

            //if (dtservice.Rows.Count > 0)
            //{
            //    string response = propResponseCodes;
            //    string[] arrResponse = null;
            //    if (response.IndexOf(',') > 0)
            //    {
            //        arrResponse = response.Split(',');
            //    }
            //    else if (!response.Equals(string.Empty))
            //    {
            //        arrResponse = new string[] { response };
            //    }
            //    bool boolexist = false;
            //    foreach (DataRow dr in dtservice.Rows)
            //    {
            //        boolexist = false;
            //        string resDesc = dr["CODE"].ToString().Trim();


            //        if (arrResponse != null && arrResponse.ToList().Exists(u => u.Equals(resDesc)))
            //        {
            //            boolexist = true;
            //        }
            //        int index = gvwAlertCode.Rows.Add(boolexist, dr["DESCRIP"], dr["CODE"], "None");

            //        //gvwAlertCode.Rows[index].Tag = agyEntity;
            //    }
            //}
        }
    }
}