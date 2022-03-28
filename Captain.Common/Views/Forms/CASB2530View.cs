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
using Captain.Common.Model.Data;
using Captain.Common.Model.Objects;
using Captain.Common.Views.Forms.Base;
using Captain.Common.Utilities;
using Captain.Common.Views.UserControls;

#endregion

namespace Captain.Common.Views.Forms
{
    public partial class CASB2530View : Form
    {
        #region private variables

        private ErrorProvider _errorProvider = null;
        private bool boolChangeStatus = false;
        private CaptainModel _model = null;


        #endregion
        public CASB2530View(BaseForm baseForm, PrivilegeEntity privileges, List<HierarchyEntity> hierarchyEntity)
        {
            try
            {


                InitializeComponent();
                _model = new CaptainModel();
                BaseForm = baseForm;
                prophierarchyEntity = hierarchyEntity;
                //Privileges = privileges;
                _errorProvider = new ErrorProvider(this);
                _errorProvider.BlinkRate = 3;
                _errorProvider.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;
                _errorProvider.Icon = null;
                this.Text = privileges.Program + " - View";

                propRankscategory = _model.SPAdminData.Browse_RankCtg();
                propcustResponce = _model.CaseMstData.GetCustomQuestionAnswersRank(BaseForm.BaseAgency, BaseForm.BaseDept, BaseForm.BaseProg, BaseForm.BaseYear, BaseForm.BaseApplicationNo,BaseForm.BaseCaseMstListEntity[0].FamilySeq, string.Empty,string.Empty);
                propPresResponce = _model.CaseMstData.GetPreassesQuestionAnswersRank(BaseForm.BaseAgency, BaseForm.BaseDept, BaseForm.BaseProg, BaseForm.BaseYear, BaseForm.BaseApplicationNo, BaseForm.BaseCaseMstListEntity[0].FamilySeq, string.Empty, "PRESRESP");

                CustRespEntity SearchCustresp = new CustRespEntity(true);
                SearchCustresp.ScrCode = "CASE2001";
                propCustResponceList = _model.FieldControls.Browse_CUSTRESP(SearchCustresp, "Browse");
                SearchCustresp.ScrCode = "PREASSES";
                propPresResponceList = _model.FieldControls.Browse_CUSTRESP(SearchCustresp, "Browse");

                AGYTABSEntity searchAgytabs = new AGYTABSEntity(true);
                AdhocData AgyTabs = new AdhocData();
                propAgyTabsList = AgyTabs.Browse_AGYTABS(searchAgytabs);

                fillListView();
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }
        }

        Gizmox.WebGUI.Common.Resources.ResourceHandle bookview = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle("bookview.png");
        Gizmox.WebGUI.Common.Resources.ResourceHandle bookClose = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle("bookclose.png");
        public BaseForm BaseForm { get; set; }
        public PrivilegeEntity Privileges { get; set; }
        public List<RankCatgEntity> propRankscategory { get; set; }
        public List<CustomQuestionsEntity> propcustResponce { get; set; }
        public List<CustRespEntity> propCustResponceList { get; set; }
        public List<AGYTABSEntity> propAgyTabsList { get; set; }
        public List<HierarchyEntity> prophierarchyEntity { get; set; }
        public List<CustomQuestionsEntity> propPresResponce { get; set; }
        public List<CustRespEntity> propPresResponceList { get; set; }
        private void fillListView()
        {
            try
            {

                string strAgency = BaseForm.BaseAgency.ToString();
                List<RankCatgEntity> rankCatg = propRankscategory.FindAll(u => u.Agency.Trim() == BaseForm.BaseAgency && u.SubCode.Trim() == string.Empty);
                if (rankCatg.Count == 0)
                {
                    rankCatg = propRankscategory.FindAll(u => u.Agency.Trim() == "**" && u.SubCode.Trim() == string.Empty);
                    strAgency = "**";
                }
                //List<RNKCRIT2Entity> RnkQuesFledsEntity = _model.SPAdminData.GetRanksCrit2Data("RANKQUES", BaseForm.BaseAgency, string.Empty);
                //List<RNKCRIT2Entity> RnkQuesFledsAllDataEntity = _model.SPAdminData.GetRanksCrit2Data(string.Empty, BaseForm.BaseAgency, string.Empty);
                //List<RNKCRIT2Entity> RnkCustFldsAllDataEntity = _model.SPAdminData.GetRanksCrit2Data("CUSTFLDS", BaseForm.BaseAgency, string.Empty);
                ChldMstEntity chldMst = _model.ChldMstData.GetChldMstDetails(BaseForm.BaseAgency, BaseForm.BaseDept, BaseForm.BaseProg, BaseForm.BaseYear, BaseForm.BaseApplicationNo, string.Empty);

                foreach (RankCatgEntity item in rankCatg)
                {

                    List<RNKCRIT2Entity> RnkQuesFledsEntity = _model.SPAdminData.GetRanksCrit2Data("RANKQUES", BaseForm.BaseAgency, item.Code.Trim().ToString());
                    List<RNKCRIT2Entity> RnkQuesFledsAllDataEntity = _model.SPAdminData.GetRanksCrit2Data(string.Empty, BaseForm.BaseAgency, item.Code.Trim().ToString());
                    List<RNKCRIT2Entity> RnkCustFldsAllDataEntity = _model.SPAdminData.GetRanksCrit2Data("CUSTFLDS", BaseForm.BaseAgency, item.Code.Trim().ToString());
               

                    List<RNKCRIT2Entity> RnkQuesFledsDataCodeEntity = RnkQuesFledsAllDataEntity;//RnkQuesFledsAllDataEntity.FindAll(u => u.RankCategory.Trim().ToString() == item.Code.Trim().ToString());
                    List<RNKCRIT2Entity> RnkCustFldsDataCodeEntity = RnkCustFldsAllDataEntity;//RnkCustFldsAllDataEntity.FindAll(u => u.RankCategory.Trim().ToString() == item.Code.Trim().ToString());

                    ListViewItem objItem = null;
                    DataTable dt = GetRankCategoryDetails(BaseForm.BaseCaseMstListEntity[0], BaseForm.BaseCaseSnpEntity, chldMst, RnkQuesFledsEntity, RnkQuesFledsDataCodeEntity, RnkCustFldsDataCodeEntity);

                   // Casb2530GridControl objPanel = new Casb2530GridControl(dt);
                    Casb2530ListControl objPanel = new Casb2530ListControl(dt, RnkQuesFledsDataCodeEntity, RnkCustFldsDataCodeEntity, BaseForm.BaseCaseMstListEntity[0], BaseForm.BaseCaseSnpEntity, propcustResponce, propAgyTabsList, BaseForm.BaseAgyTabsEntity, RnkQuesFledsEntity);
                    objPanel.Visible = false;
                    objPanel.Dock = DockStyle.Fill;

                    objItem = this.listViewRanks.Items.Add(objPanel, "");
                    objItem.SubItems.Add(item.Desc);

                    objItem.SubItems.Add(intRankPoint.ToString());
                   


                    Gizmox.WebGUI.Forms.Button objButton = new Gizmox.WebGUI.Forms.Button();
                    objButton.Click += new EventHandler(OnEditButtonClick);
                    // objButton.Image = bookview;

                    List<RankCatgEntity> rankCatgList = propRankscategory.FindAll(u => u.Agency == strAgency && u.SubCode.Trim() != string.Empty && u.Code == item.Code.Trim().ToString());

                    string strCategory = string.Empty;

                    if (rankCatgList.Count > 0)
                    {
                        RankCatgEntity rnkcatgCategroyDesc = rankCatgList.Find(u => Convert.ToDecimal(u.PointsLow) <= intRankPoint && Convert.ToDecimal(u.PointsHigh) >= intRankPoint);
                        if (rnkcatgCategroyDesc != null)
                        {
                            strCategory = rnkcatgCategroyDesc.Desc.ToString();                          
                        }
                    }
                    objItem.SubItems.Add(strCategory);

                    objButton.Tag = objItem;
                    objButton.Text = "+" ;
                    objItem.SubItems.Add(objButton);

                    objItem.SubItems.Add(item.Code);

                    //// objItem.SubItems.Add(GetIcon("Icons.16X16.AddItem.gif"));
                    //if (Privileges.AddPriv.Equals("true"))
                    //{

                    //    Gizmox.WebGUI.Forms.Button objAddButton = new Gizmox.WebGUI.Forms.Button();
                    //    objAddButton.Click += new EventHandler(OnAddButtonClick);
                    //    objAddButton.Tag = objItem;
                    //    objAddButton.Text = liheApd.LdLetterId;
                    //    objAddButton.Image = "Icons.16X16.AddItem.gif";
                    //    objItem.SubItems.Add(objAddButton);
                    //}


                }


            }
            catch (Exception ex)
            {

                //  MessageBox.Show(ex.Message);
            }

        }

        private void OnEditButtonClick(object sender, EventArgs e)
        {
            Gizmox.WebGUI.Forms.Button objButton = sender as Gizmox.WebGUI.Forms.Button;
            if (objButton != null)
            {
                ListViewPanelItem objPanelItem = objButton.Tag as ListViewPanelItem;
                if (objPanelItem != null)
                {
                    if (objPanelItem.Panel.Visible = !objPanelItem.Panel.Visible)
                    {
                        objButton.Text = "-";
                        // objButton.Image = bookClose;
                    }
                    else
                    {
                        objButton.Text = "+";
                        // objButton.Image = bookview;

                        Casb2530ListControl objPanel = objPanelItem.Panel as Casb2530ListControl;
                        if (objPanel != null)
                        {

                        }
                    }
                }
            }
        }

        #region RankCateogryPointsCalculation
        public CaseMstEntity propMstRank { get; set; }

        DataTable dtRankSubDetails;
        int intRankPoint = 0;
        private DataTable GetRankCategoryDetails(CaseMstEntity caseMst, List<CaseSnpEntity> caseSnp, ChldMstEntity chldMst, List<RNKCRIT2Entity> RnkQuesFledsEntity, List<RNKCRIT2Entity> RnkQuesFledsAllDataEntity, List<RNKCRIT2Entity> RnkCustFldsAllDataEntity)
        {
            try
            {

                string strResponceDesc = string.Empty;
                AGYTABSEntity agytabsMstDesc = null;
                intRankPoint = 0;
                dtRankSubDetails = new DataTable();               
                dtRankSubDetails.Columns.Add("FieldCode", typeof(string));
                dtRankSubDetails.Columns.Add("FieldDesc", typeof(string));
                dtRankSubDetails.Columns.Add("Points", typeof(string));
                 dtRankSubDetails.Columns.Add("TableCode", typeof(string));
                 dtRankSubDetails.Columns.Add("ResponceType", typeof(string));
                
                //
                // Here we add five DataRows.
                //        




                List<CommonEntity> ListRankPoints = new List<CommonEntity>();
                //for (int intRankCtg = 1; intRankCtg <= 6; intRankCtg++)
                //{ 

                //List<RNKCRIT2Entity> RnkQuesFledsDataEntity = RnkQuesFledsAllDataEntity.FindAll(u => u.RankCategory.Trim().ToString() == ((Captain.Common.Utilities.ListItem)cmbRankCategory.SelectedItem).Value.ToString());
                //List<RNKCRIT2Entity> RnkCustFldsDataEntity = RnkCustFldsAllDataEntity.FindAll(u => u.RankCategory.Trim().ToString() == ((Captain.Common.Utilities.ListItem)cmbRankCategory.SelectedItem).Value.ToString());

                List<RNKCRIT2Entity> RnkQuesFledsDataEntity = RnkQuesFledsAllDataEntity;
                List<RNKCRIT2Entity> RnkCustFldsDataEntity = RnkCustFldsAllDataEntity;

                List<CustomQuestionsEntity> custResponses = propcustResponce;
                List<CustomQuestionsEntity> custpresResponses = propPresResponce;

                List<RNKCRIT2Entity> RnkQuesSearchList;
                propMstRank = caseMst;
                RNKCRIT2Entity RnkQuesSearch = null;
                // List<RNKCRIT2Entity> RnkQuesCaseSnp = null;
                int intRankSnpPoints = 0;
                string strApplicationcode = string.Empty;
                foreach (RNKCRIT2Entity rnkQuesData in RnkQuesFledsEntity)
                {
                    intRankSnpPoints = 0;
                    DataRow dr = dtRankSubDetails.NewRow();
                    RnkQuesSearch = null;
                    dr["FieldCode"] = rnkQuesData.RankFldDesc.ToString();
                    dr["TableCode"] = rnkQuesData.RankFldName.Trim();
                    dr["ResponceType"] = rnkQuesData.RankFldRespType.Trim();
                     
                    switch (rnkQuesData.RankFldName.Trim())
                    {

                        case Consts.RankQues.MZip:
                            dr["FieldDesc"] = caseMst.Zip.Trim();
                            RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && u.RespCd.Trim() == caseMst.Zip.Trim());
                            break;
                        case Consts.RankQues.MCounty:
                            if (rnkQuesData.RankFldRespType == "D" || rnkQuesData.RankFldRespType == "L")
                            {
                                agytabsMstDesc = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == caseMst.County.Trim());
                                if (agytabsMstDesc != null)
                                {
                                    dr["FieldDesc"] = agytabsMstDesc.Code_Desc.ToString();
                                }
                                else
                                    dr["FieldDesc"] = string.Empty;
                            }
                            RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && u.RespCd.Trim() == caseMst.County.Trim());
                            break;
                        case Consts.RankQues.MLanguage:
                            if (rnkQuesData.RankFldRespType == "D" || rnkQuesData.RankFldRespType == "L")
                            {
                                agytabsMstDesc = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == caseMst.Language.Trim());
                                if (agytabsMstDesc != null)
                                {
                                    dr["FieldDesc"] = agytabsMstDesc.Code_Desc.ToString();
                                }
                                else
                                    dr["FieldDesc"] = string.Empty;
                            }
                            RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && u.RespCd.Trim() == caseMst.Language.Trim());
                            break;
                        case Consts.RankQues.MAlertCode:
                            dr["FieldDesc"] = caseMst.AlertCodes.Trim();
                            intRankSnpPoints = fillAlertIncomeCodes(caseMst.AlertCodes, RnkQuesFledsDataEntity, rnkQuesData.RankFldName.Trim());
                            intRankPoint = intRankPoint + intRankSnpPoints;
                            break;
                        case Consts.RankQues.MAboutUs:
                            if (rnkQuesData.RankFldRespType == "D" || rnkQuesData.RankFldRespType == "L")
                            {
                                agytabsMstDesc = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == caseMst.AboutUs.Trim());
                                if (agytabsMstDesc != null)
                                {
                                    dr["FieldDesc"] = agytabsMstDesc.Code_Desc.ToString();
                                }
                                else
                                    dr["FieldDesc"] = string.Empty;
                            }
                            RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && u.RespCd.Trim() == caseMst.AboutUs.Trim());
                            break;
                        case Consts.RankQues.MAddressYear:
                            if (caseMst.AddressYears != string.Empty)
                            {
                                dr["FieldDesc"] = caseMst.AddressYears.Trim();
                                RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && Convert.ToDecimal(u.LtNum) >= Convert.ToDecimal(caseMst.AddressYears) && Convert.ToDecimal(u.GtNum) <= Convert.ToDecimal(caseMst.AddressYears));
                            }
                            break;
                        case Consts.RankQues.MBestContact:
                            if (rnkQuesData.RankFldRespType == "D" || rnkQuesData.RankFldRespType == "L")
                            {
                                AGYTABSEntity agytabsEntity = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == caseMst.BestContact.Trim());
                                if (agytabsEntity != null)
                                {
                                    dr["FieldDesc"] = agytabsEntity.Code_Desc.Trim();
                                }
                                else
                                    dr["FieldDesc"] = string.Empty;
                            }
                            RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && u.RespCd.Trim() == caseMst.BestContact.Trim());
                            break;
                        case Consts.RankQues.MCaseReviewDate:
                            if (caseMst.CaseReviewDate != string.Empty)
                            {
                                dr["FieldDesc"] = caseMst.CaseReviewDate.Trim();
                                RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && Convert.ToDateTime(u.LtDate).Date >= Convert.ToDateTime(caseMst.CaseReviewDate).Date && Convert.ToDateTime(u.GtDate).Date <= Convert.ToDateTime(caseMst.CaseReviewDate).Date);
                            }
                            break;
                        case Consts.RankQues.MCaseType:
                            agytabsMstDesc = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == caseMst.CaseType.Trim());
                            if (agytabsMstDesc != null)
                            {
                                dr["FieldDesc"] = agytabsMstDesc.Code_Desc.ToString();
                            }
                            else
                                dr["FieldDesc"] = string.Empty;
                            RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && u.RespCd.Trim() == caseMst.CaseType.Trim());
                            break;
                        case Consts.RankQues.MCmi:
                            if (caseMst.Cmi != string.Empty)
                            {
                                dr["FieldDesc"] = caseMst.Cmi.Trim();
                                RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && Convert.ToDecimal(u.LtNum) >= Convert.ToDecimal(caseMst.Cmi) && Convert.ToDecimal(u.GtNum) <= Convert.ToDecimal(caseMst.Cmi));
                            }
                            break;
                        case Consts.RankQues.MEElectric:
                            if (caseMst.ExpElectric != string.Empty)
                            {
                                dr["FieldDesc"] = caseMst.ExpElectric.Trim();
                                RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && Convert.ToDecimal(u.LtNum) >= Convert.ToDecimal(caseMst.ExpElectric) && Convert.ToDecimal(u.GtNum) <= Convert.ToDecimal(caseMst.ExpElectric));
                            }
                            break;
                        case Consts.RankQues.MEDEBTCC:
                            if (caseMst.Debtcc != string.Empty)
                            {
                                dr["FieldDesc"] = caseMst.Debtcc.Trim();
                                RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && Convert.ToDecimal(u.LtNum) >= Convert.ToDecimal(caseMst.Debtcc) && Convert.ToDecimal(u.GtNum) <= Convert.ToDecimal(caseMst.Debtcc));
                            }
                            break;
                        case Consts.RankQues.MEDEBTLoans:
                            if (caseMst.DebtLoans != string.Empty)
                            {
                                dr["FieldDesc"] = caseMst.DebtLoans.Trim();
                                RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && Convert.ToDecimal(u.LtNum) >= Convert.ToDecimal(caseMst.DebtLoans) && Convert.ToDecimal(u.GtNum) <= Convert.ToDecimal(caseMst.DebtLoans));
                            }
                            break;
                        case Consts.RankQues.MEDEBTMed:
                            if (caseMst.DebtMed != string.Empty)
                            {
                                dr["FieldDesc"] = caseMst.DebtMed.Trim();
                                RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && Convert.ToDecimal(u.LtNum) >= Convert.ToDecimal(caseMst.DebtMed) && Convert.ToDecimal(u.GtNum) <= Convert.ToDecimal(caseMst.DebtMed));
                            }
                            break;
                        case Consts.RankQues.MEHeat:
                            if (caseMst.ExpHeat != string.Empty)
                            {
                                dr["FieldDesc"] = caseMst.ExpHeat.Trim();
                                RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && Convert.ToDecimal(u.LtNum) >= Convert.ToDecimal(caseMst.ExpHeat) && Convert.ToDecimal(u.GtNum) <= Convert.ToDecimal(caseMst.ExpHeat));
                            }
                            break;
                        case Consts.RankQues.MEligDate:
                            if (caseMst.EligDate != string.Empty)
                            {
                                dr["FieldDesc"] = caseMst.EligDate.Trim();
                                RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && Convert.ToDateTime(u.LtDate).Date >= Convert.ToDateTime(caseMst.EligDate).Date && Convert.ToDateTime(u.GtDate).Date <= Convert.ToDateTime(caseMst.EligDate).Date);
                            }
                            break;
                        case Consts.RankQues.MELiveExpenses:
                            if (caseMst.ExpLivexpense != string.Empty)
                            {
                                dr["FieldDesc"] = caseMst.ExpLivexpense.Trim();
                                RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && Convert.ToDecimal(u.LtNum) >= Convert.ToDecimal(caseMst.ExpLivexpense) && Convert.ToDecimal(u.GtNum) <= Convert.ToDecimal(caseMst.ExpLivexpense));
                            }
                            break;
                        case Consts.RankQues.MERent:
                            if (caseMst.ExpRent != string.Empty)
                            {
                                dr["FieldDesc"] = caseMst.ExpRent.Trim();
                                RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && Convert.ToDecimal(u.LtNum) >= Convert.ToDecimal(caseMst.ExpRent) && Convert.ToDecimal(u.GtNum) <= Convert.ToDecimal(caseMst.ExpRent));
                            }
                            break;
                        case Consts.RankQues.METotal:
                            if (caseMst.ExpTotal != string.Empty)
                            {
                                dr["FieldDesc"] = caseMst.ExpTotal.Trim();
                                RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && Convert.ToDecimal(u.LtNum) >= Convert.ToDecimal(caseMst.ExpTotal) && Convert.ToDecimal(u.GtNum) <= Convert.ToDecimal(caseMst.ExpTotal));
                            }
                            break;
                        case Consts.RankQues.MEWater:
                            if (caseMst.ExpWater != string.Empty)
                            {
                                dr["FieldDesc"] = caseMst.ExpWater.Trim();
                                RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && Convert.ToDecimal(u.LtNum) >= Convert.ToDecimal(caseMst.ExpWater) && Convert.ToDecimal(u.GtNum) <= Convert.ToDecimal(caseMst.ExpWater));
                            }
                            break;

                        case Consts.RankQues.MExpCaseworker:
                            dr["FieldDesc"] = caseMst.ExpCaseWorker.Trim();
                            RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && u.RespCd.Trim() == caseMst.ExpCaseWorker.Trim());
                            break;
                        case Consts.RankQues.MFamilyType:
                            agytabsMstDesc = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == caseMst.FamilyType.Trim());
                            if (agytabsMstDesc != null)
                            {
                                dr["FieldDesc"] = agytabsMstDesc.Code_Desc.ToString();
                            }
                            else
                                dr["FieldDesc"] = string.Empty;
                            RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && u.RespCd.Trim() == caseMst.FamilyType.Trim());
                            break;
                        case Consts.RankQues.MFamIncome:
                            if (caseMst.FamIncome != string.Empty)
                            {
                                dr["FieldDesc"] = caseMst.FamIncome.Trim();
                                RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && Convert.ToDecimal(u.LtNum) >= Convert.ToDecimal(caseMst.FamIncome) && Convert.ToDecimal(u.GtNum) <= Convert.ToDecimal(caseMst.FamIncome));
                            }
                            break;
                        case Consts.RankQues.MHousing:
                            agytabsMstDesc = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == caseMst.Housing.Trim());
                            if (agytabsMstDesc != null)
                            {
                                dr["FieldDesc"] = agytabsMstDesc.Code_Desc.ToString();
                            }
                            else
                                dr["FieldDesc"] = string.Empty;
                            RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && u.RespCd.Trim() == caseMst.Housing.Trim());
                            break;
                        case Consts.RankQues.MHud:
                            if (caseMst.Hud != string.Empty)
                            {
                                dr["FieldDesc"] = caseMst.Hud.Trim();
                                RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && Convert.ToDecimal(u.LtNum) >= Convert.ToDecimal(caseMst.Hud) && Convert.ToDecimal(u.GtNum) <= Convert.ToDecimal(caseMst.Hud));
                            }
                            break;

                        case Consts.RankQues.MIncomeTypes:
                            dr["FieldDesc"] = caseMst.IncomeTypes.Trim();
                            intRankSnpPoints = fillAlertIncomeCodes(caseMst.IncomeTypes, RnkQuesFledsDataEntity, rnkQuesData.RankFldName.Trim());
                            intRankPoint = intRankPoint + intRankSnpPoints;
                            //RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && u.RespCd.Trim() == caseMst.IncomeTypes.Trim());
                            break;
                        case Consts.RankQues.NonCashBenefits:
                            dr["FieldDesc"] = caseMst.MstNCashBen.Trim();
                            intRankSnpPoints = fillAlertNonCashBenCodes(caseMst.MstNCashBen, RnkQuesFledsDataEntity, rnkQuesData.RankFldName.Trim());
                            intRankPoint = intRankPoint + intRankSnpPoints;
                            //RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && u.RespCd.Trim() == caseMst.IncomeTypes.Trim());
                            break;
                        case Consts.RankQues.MInitialDate:
                            if (caseMst.InitialDate != string.Empty)
                            {
                                dr["FieldDesc"] = caseMst.InitialDate.Trim();
                                RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && Convert.ToDateTime(u.LtDate).Date >= Convert.ToDateTime(caseMst.InitialDate).Date && Convert.ToDateTime(u.GtDate).Date <= Convert.ToDateTime(caseMst.InitialDate).Date);
                            }
                            break;
                        case Consts.RankQues.MIntakeDate:
                            if (caseMst.IntakeDate != string.Empty)
                            {
                                dr["FieldDesc"] = caseMst.IntakeDate.Trim();
                                RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && Convert.ToDateTime(u.LtDate).Date >= Convert.ToDateTime(caseMst.IntakeDate).Date && Convert.ToDateTime(u.GtDate).Date <= Convert.ToDateTime(caseMst.IntakeDate).Date);
                            }
                            break;
                        case Consts.RankQues.MIntakeWorker:
                            dr["FieldDesc"] = caseMst.IntakeWorker.Trim();
                            RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && u.RespCd.Trim() == caseMst.IntakeWorker.Trim());
                            break;
                        case Consts.RankQues.MJuvenile:
                            agytabsMstDesc = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == caseMst.Juvenile.Trim());
                            if (agytabsMstDesc != null)
                            {
                                dr["FieldDesc"] = agytabsMstDesc.Code_Desc.ToString();
                            }
                            else
                                dr["FieldDesc"] = string.Empty;
                            RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && u.RespCd.Trim() == caseMst.Juvenile.Trim());
                            break;
                        case Consts.RankQues.MLanguageOt:
                            agytabsMstDesc = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == caseMst.LanguageOt.Trim());
                            if (agytabsMstDesc != null)
                            {
                                dr["FieldDesc"] = agytabsMstDesc.Code_Desc.ToString();
                            }
                            else
                                dr["FieldDesc"] = string.Empty;
                            RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && u.RespCd.Trim() == caseMst.LanguageOt.Trim());
                            break;
                        case Consts.RankQues.MNoInprog:
                            if (caseMst.NoInProg != string.Empty)
                            {
                                dr["FieldDesc"] = caseMst.NoInProg.Trim();
                                RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && Convert.ToDecimal(u.LtNum) >= Convert.ToDecimal(caseMst.NoInProg) && Convert.ToDecimal(u.GtNum) <= Convert.ToDecimal(caseMst.NoInProg));
                            }
                            break;
                        case Consts.RankQues.Mpoverty:
                            if (caseMst.Poverty != string.Empty)
                            {
                                dr["FieldDesc"] = caseMst.Poverty.Trim();
                                RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && Convert.ToDecimal(u.LtNum) >= Convert.ToDecimal(caseMst.Poverty) && Convert.ToDecimal(u.GtNum) <= Convert.ToDecimal(caseMst.Poverty));
                            }
                            break;
                        case Consts.RankQues.MProgIncome:
                            if (caseMst.ProgIncome != string.Empty)
                            {
                                dr["FieldDesc"] = caseMst.ProgIncome.Trim();
                                RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && Convert.ToDecimal(u.LtNum) >= Convert.ToDecimal(caseMst.ProgIncome) && Convert.ToDecimal(u.GtNum) <= Convert.ToDecimal(caseMst.ProgIncome));
                            }
                            break;
                        case Consts.RankQues.MReverifyDate:
                            if (caseMst.ReverifyDate != string.Empty)
                            {
                                dr["FieldDesc"] = caseMst.ReverifyDate.Trim();
                                RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && Convert.ToDateTime(u.LtDate).Date >= Convert.ToDateTime(caseMst.ReverifyDate).Date && Convert.ToDateTime(u.GtDate).Date <= Convert.ToDateTime(caseMst.ReverifyDate).Date);
                            }
                            break;
                        case Consts.RankQues.MSECRET:
                            agytabsMstDesc = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == caseMst.Secret.Trim());
                            if (agytabsMstDesc != null)
                            {
                                dr["FieldDesc"] = agytabsMstDesc.Code_Desc.ToString();
                            }
                            else
                                dr["FieldDesc"] = string.Empty;
                            RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && u.RespCd.Trim() == caseMst.Secret.Trim());
                            break;
                        case Consts.RankQues.MSenior:
                            agytabsMstDesc = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == caseMst.Senior.Trim());
                            if (agytabsMstDesc != null)
                            {
                                dr["FieldDesc"] = agytabsMstDesc.Code_Desc.ToString();
                            }
                            else
                                dr["FieldDesc"] = string.Empty;
                            RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && u.RespCd.Trim() == caseMst.Senior.Trim());
                            break;
                        case Consts.RankQues.MSite:
                            dr["FieldDesc"] = caseMst.Site.Trim();
                            RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && u.RespCd.Trim() == caseMst.Site.Trim());
                            break;
                        case Consts.RankQues.MSMi:
                            if (caseMst.Smi != string.Empty)
                            {
                                dr["FieldDesc"] = caseMst.Smi.Trim();
                                RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && Convert.ToDecimal(u.LtNum) >= Convert.ToDecimal(caseMst.Smi) && Convert.ToDecimal(u.GtNum) <= Convert.ToDecimal(caseMst.Smi));
                            }
                            break;
                        case Consts.RankQues.MVefiryCheckstub:
                            // {
                            agytabsMstDesc = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == caseMst.VerifyCheckStub.Trim());
                            if (agytabsMstDesc != null)
                            {
                                dr["FieldDesc"] = agytabsMstDesc.Code_Desc.ToString();
                            }
                            else
                                dr["FieldDesc"] = string.Empty;
                            RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && u.RespCd.Trim() == caseMst.VerifyCheckStub.Trim());
                            // }
                            break;
                        case Consts.RankQues.MVerifier:
                            if (prophierarchyEntity.Count > 0)
                            {
                                HierarchyEntity hierchy = prophierarchyEntity.Find(u => u.CaseWorker == caseMst.Verifier.Trim());
                                if (hierchy != null)
                                {
                                    dr["FieldDesc"] = hierchy.HirarchyName.ToString();
                                }
                                else
                                    dr["FieldDesc"] = caseMst.Verifier.Trim();

                            }
                            RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && u.RespCd.Trim() == caseMst.Verifier.Trim());
                            break;
                        case Consts.RankQues.MVerifyW2:
                            AGYTABSEntity agytabw2Entity = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == caseMst.VerifyW2.Trim());
                            if (agytabw2Entity != null)
                            {
                                dr["FieldDesc"] = agytabw2Entity.Code_Desc.Trim();
                            }
                            else
                                dr["FieldDesc"] = string.Empty;
                            RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && u.RespCd.Trim() == caseMst.VerifyW2.Trim());
                            break;
                        case Consts.RankQues.MVeriTaxReturn:
                            agytabsMstDesc = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == caseMst.VerifyTaxReturn.Trim());
                            if (agytabsMstDesc != null)
                            {
                                dr["FieldDesc"] = agytabsMstDesc.Code_Desc.ToString();
                            }
                            else
                                dr["FieldDesc"] = string.Empty;
                            RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && u.RespCd.Trim() == caseMst.VerifyTaxReturn.Trim());
                            break;
                        case Consts.RankQues.MVerLetter:
                            agytabsMstDesc = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == caseMst.VerifyLetter.Trim());
                            if (agytabsMstDesc != null)
                            {
                                dr["FieldDesc"] = agytabsMstDesc.Code_Desc.ToString();
                            }
                            else
                                dr["FieldDesc"] = string.Empty;
                            RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && u.RespCd.Trim() == caseMst.VerifyLetter.Trim());
                            break;
                        case Consts.RankQues.MVerOther:
                            agytabsMstDesc = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == caseMst.VerifyOther.Trim());
                            if (agytabsMstDesc != null)
                            {
                                dr["FieldDesc"] = agytabsMstDesc.Code_Desc.ToString();
                            }
                            else
                                dr["FieldDesc"] = string.Empty;
                            RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && u.RespCd.Trim() == caseMst.VerifyOther.Trim());
                            break;
                        case Consts.RankQues.MWaitList:
                            dr["FieldDesc"] = caseMst.WaitList.Trim();
                            RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && u.RespCd.Trim() == caseMst.WaitList.Trim());
                            break;

                            //Preassses Questuibs

                        //case Consts.RankQues.MPJOB:
                        //    agytabsMstDesc = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == caseMst.PJob.Trim());
                        //    if (agytabsMstDesc != null)
                        //    {
                        //        dr["FieldDesc"] = agytabsMstDesc.Code_Desc.Trim();
                        //    }
                        //    else
                        //        dr["FieldDesc"] = string.Empty;
                        //    RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && u.RespCd.Trim() == caseMst.PJob.Trim());
                        //    break;                       
                        //case Consts.RankQues.MPHsd:
                        //    agytabsMstDesc = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == caseMst.PHSD.Trim());
                        //    if (agytabsMstDesc != null)
                        //    {
                        //        dr["FieldDesc"] = agytabsMstDesc.Code_Desc.Trim();
                        //    }
                        //    else
                        //        dr["FieldDesc"] = string.Empty;
                        //    RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && u.RespCd.Trim() == caseMst.PHSD.Trim());
                        //    break;
                        //case Consts.RankQues.MPSkills:
                        //    agytabsMstDesc = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == caseMst.PSkills.Trim());
                        //    if (agytabsMstDesc != null)
                        //    {
                        //        dr["FieldDesc"] = agytabsMstDesc.Code_Desc.Trim();
                        //    }
                        //    else
                        //        dr["FieldDesc"] = string.Empty;
                        //    RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && u.RespCd.Trim() == caseMst.PSkills.Trim());
                        //    break;
                        //case Consts.RankQues.MPHousing:
                        //    agytabsMstDesc = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == caseMst.PHousing.Trim());
                        //    if (agytabsMstDesc != null)
                        //    {
                        //        dr["FieldDesc"] = agytabsMstDesc.Code_Desc.Trim();
                        //    }
                        //    else
                        //        dr["FieldDesc"] = string.Empty;
                        //    RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && u.RespCd.Trim() == caseMst.PHousing.Trim());
                        //    break;

                        //case Consts.RankQues.MPTransport:
                        //    agytabsMstDesc = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == caseMst.PTransport.Trim());
                        //    if (agytabsMstDesc != null)
                        //    {
                        //        dr["FieldDesc"] = agytabsMstDesc.Code_Desc.Trim();
                        //    }
                        //    else
                        //        dr["FieldDesc"] = string.Empty;
                        //    RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && u.RespCd.Trim() == caseMst.PTransport.Trim());
                        //    break;

                        //case Consts.RankQues.MPChildCare:
                        //    agytabsMstDesc = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == caseMst.PChldCare.Trim());
                        //    if (agytabsMstDesc != null)
                        //    {
                        //        dr["FieldDesc"] = agytabsMstDesc.Code_Desc.Trim();
                        //    }
                        //    else
                        //        dr["FieldDesc"] = string.Empty;
                        //    RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && u.RespCd.Trim() == caseMst.PChldCare.Trim());
                        //    break;
                        //case Consts.RankQues.MPCCEnrl:
                        //    agytabsMstDesc = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == caseMst.PCCENRL.Trim());
                        //    if (agytabsMstDesc != null)
                        //    {
                        //        dr["FieldDesc"] = agytabsMstDesc.Code_Desc.Trim();
                        //    }
                        //    else
                        //        dr["FieldDesc"] = string.Empty;
                        //    RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && u.RespCd.Trim() == caseMst.PCCENRL.Trim());
                        //    break;
                        //case Consts.RankQues.MPEldrcare:
                        //    agytabsMstDesc = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == caseMst.PELDCARE.Trim());
                        //    if (agytabsMstDesc != null)
                        //    {
                        //        dr["FieldDesc"] = agytabsMstDesc.Code_Desc.Trim();
                        //    }
                        //    else
                        //        dr["FieldDesc"] = string.Empty;
                        //    RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && u.RespCd.Trim() == caseMst.PELDCARE.Trim());
                        //    break;
                        //case Consts.RankQues.MPEcneed:
                        //    agytabsMstDesc = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == caseMst.PECNEED.Trim());
                        //    if (agytabsMstDesc != null)
                        //    {
                        //        dr["FieldDesc"] = agytabsMstDesc.Code_Desc.Trim();
                        //    }
                        //    else
                        //        dr["FieldDesc"] = string.Empty;
                        //    RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && u.RespCd.Trim() == caseMst.PECNEED.Trim());
                        //    break;
                        //case Consts.RankQues.MPChins:
                        //    agytabsMstDesc = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == caseMst.PECHINS.Trim());
                        //    if (agytabsMstDesc != null)
                        //    {
                        //        dr["FieldDesc"] = agytabsMstDesc.Code_Desc.Trim();
                        //    }
                        //    else
                        //        dr["FieldDesc"] = string.Empty;
                        //    RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && u.RespCd.Trim() == caseMst.PECHINS.Trim());
                        //    break;
                        //case Consts.RankQues.MPAhins:
                        //    agytabsMstDesc = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == caseMst.PAHINS.Trim());
                        //    if (agytabsMstDesc != null)
                        //    {
                        //        dr["FieldDesc"] = agytabsMstDesc.Code_Desc.Trim();
                        //    }
                        //    else
                        //        dr["FieldDesc"] = string.Empty;
                        //    RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && u.RespCd.Trim() == caseMst.PAHINS.Trim());
                        //    break;
                        //case Consts.RankQues.MPRWeng:
                        //    agytabsMstDesc = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == caseMst.PRWENG.Trim());
                        //    if (agytabsMstDesc != null)
                        //    {
                        //        dr["FieldDesc"] = agytabsMstDesc.Code_Desc.Trim();
                        //    }
                        //    else
                        //        dr["FieldDesc"] = string.Empty;
                        //    RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && u.RespCd.Trim() == caseMst.PRWENG.Trim());
                        //    break;
                        //case Consts.RankQues.MPCurrDss:
                        //    agytabsMstDesc = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == caseMst.PCURRDSS.Trim());
                        //    if (agytabsMstDesc != null)
                        //    {
                        //        dr["FieldDesc"] = agytabsMstDesc.Code_Desc.Trim();
                        //    }
                        //    else
                        //        dr["FieldDesc"] = string.Empty;
                        //    RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && u.RespCd.Trim() == caseMst.PCURRDSS.Trim());
                        //    break;
                        //case Consts.RankQues.MPRecvDss:
                        //    agytabsMstDesc = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == caseMst.PRECVDSS.Trim());
                        //    if (agytabsMstDesc != null)
                        //    {
                        //        dr["FieldDesc"] = agytabsMstDesc.Code_Desc.Trim();
                        //    }
                        //    else
                        //        dr["FieldDesc"] = string.Empty;
                        //    RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && u.RespCd.Trim() == caseMst.PRECVDSS.Trim());
                        //    break;



                        case Consts.RankQues.SEducation:
                            RnkQuesSearchList = RnkQuesFledsDataEntity.FindAll(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim());
                            strApplicationcode = caseSnp.Find(u => u.FamilySeq.Equals(caseMst.FamilySeq)).Education.ToString();
                            //if (rnkQuesData.RankFldRespType == "D" || rnkQuesData.RankFldRespType == "L")
                            //{
                            //    AGYTABSEntity agytab = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == strApplicationcode);
                            //    if (agytab != null)
                            //        dr["FieldDesc"] = agytab.Code_Desc.ToString();
                            //    else
                            //        dr["FieldDesc"] = strApplicationcode;
                            //}
                            //else
                            //    dr["FieldDesc"] = strApplicationcode;
                            //List<string> SnpFieldsCodesList = new List<string>();
                            //List<string> SnpFieldsRelationList = new List<string>();
                            //for (int i = 0; i < caseSnp.Count; i++)
                            //{
                            //    SnpFieldsCodesList.Add(caseSnp[i].Education);
                            //    SnpFieldsRelationList.Add(caseSnp[i].MemberCode);
                            //}
                            //intRankSnpPoints = CaseSnpDetailsCalc(RnkQuesSearchList, caseSnp, strApplicationcode, SnpFieldsCodesList, SnpFieldsRelationList, rnkQuesData.RankFldName.Trim(), rnkQuesData.RankFldRespType.Trim());
                            intRankSnpPoints = CaseSnpDetailsCalc(RnkQuesSearchList, caseSnp, strApplicationcode, rnkQuesData.RankFldName.Trim(), rnkQuesData.RankFldRespType.Trim(), out strResponceDesc);
                            dr["FieldDesc"] = GetSnpAgyTabDesc(rnkQuesData, strResponceDesc);
                            intRankPoint = intRankPoint + intRankSnpPoints;
                            break;
                        case Consts.RankQues.S1shift:
                            RnkQuesSearchList = RnkQuesFledsDataEntity.FindAll(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim());
                            strApplicationcode = caseSnp.Find(u => u.FamilySeq.Equals(caseMst.FamilySeq)).IstShift.ToString();
                            //if (rnkQuesData.RankFldRespType == "D" || rnkQuesData.RankFldRespType == "L")
                            //{
                            //    AGYTABSEntity agytab = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == strApplicationcode);
                            //    if (agytab != null)
                            //        dr["FieldDesc"] = agytab.Code_Desc.ToString();
                            //    else
                            //        dr["FieldDesc"] = strApplicationcode;
                            //}
                            //else
                            //    dr["FieldDesc"] = strApplicationcode;
                            intRankSnpPoints = CaseSnpDetailsCalc(RnkQuesSearchList, caseSnp, strApplicationcode, rnkQuesData.RankFldName.Trim(), rnkQuesData.RankFldRespType.Trim(), out strResponceDesc);
                            dr["FieldDesc"] = GetSnpAgyTabDesc(rnkQuesData, strResponceDesc);
                            intRankPoint = intRankPoint + intRankSnpPoints;
                            break;
                        case Consts.RankQues.S2ndshift:
                            RnkQuesSearchList = RnkQuesFledsDataEntity.FindAll(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim());
                            strApplicationcode = caseSnp.Find(u => u.FamilySeq.Equals(caseMst.FamilySeq)).IIndShift.ToString();
                            //if (rnkQuesData.RankFldRespType == "D" || rnkQuesData.RankFldRespType == "L")
                            //{
                            //    AGYTABSEntity agytab = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == strApplicationcode);
                            //    if (agytab != null)
                            //        dr["FieldDesc"] = agytab.Code_Desc.ToString();
                            //    else
                            //        dr["FieldDesc"] = strApplicationcode;
                            //}
                            //else
                            //    dr["FieldDesc"] = strApplicationcode;
                            intRankSnpPoints = CaseSnpDetailsCalc(RnkQuesSearchList, caseSnp, strApplicationcode, rnkQuesData.RankFldName.Trim(), rnkQuesData.RankFldRespType.Trim(), out strResponceDesc);
                            dr["FieldDesc"] = GetSnpAgyTabDesc(rnkQuesData, strResponceDesc);
                            intRankPoint = intRankPoint + intRankSnpPoints;
                            break;
                        case Consts.RankQues.S3rdShift:
                            RnkQuesSearchList = RnkQuesFledsDataEntity.FindAll(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim());
                            strApplicationcode = caseSnp.Find(u => u.FamilySeq.Equals(caseMst.FamilySeq)).IIIrdShift.ToString();
                            //if (rnkQuesData.RankFldRespType == "D" || rnkQuesData.RankFldRespType == "L")
                            //{
                            //    AGYTABSEntity agytab = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == strApplicationcode);
                            //    if (agytab != null)
                            //        dr["FieldDesc"] = agytab.Code_Desc.ToString();
                            //    else
                            //        dr["FieldDesc"] = strApplicationcode;
                            //}
                            //else
                            //    dr["FieldDesc"] = strApplicationcode;
                            intRankSnpPoints = CaseSnpDetailsCalc(RnkQuesSearchList, caseSnp, strApplicationcode, rnkQuesData.RankFldName.Trim(), rnkQuesData.RankFldRespType.Trim(), out strResponceDesc);
                            dr["FieldDesc"] = GetSnpAgyTabDesc(rnkQuesData, strResponceDesc);
                            intRankPoint = intRankPoint + intRankSnpPoints;
                            break;
                        case Consts.RankQues.SAge:
                            RnkQuesSearchList = RnkQuesFledsDataEntity.FindAll(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim());
                            strApplicationcode = caseSnp.Find(u => u.FamilySeq.Equals(caseMst.FamilySeq)).Age.ToString();
                            //if (rnkQuesData.RankFldRespType == "D" || rnkQuesData.RankFldRespType == "L")
                            //{
                            //    AGYTABSEntity agytab = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == strApplicationcode);
                            //    if (agytab != null)
                            //        dr["FieldDesc"] = agytab.Code_Desc.ToString();
                            //    else
                            //        dr["FieldDesc"] = strApplicationcode;
                            //}
                            //else
                            //    dr["FieldDesc"] = strApplicationcode;
                            intRankSnpPoints = CaseSnpDetailsCalc(RnkQuesSearchList, caseSnp, strApplicationcode, rnkQuesData.RankFldName.Trim(), rnkQuesData.RankFldRespType.Trim(), out strResponceDesc);
                            dr["FieldDesc"] = GetSnpAgyTabDesc(rnkQuesData, strResponceDesc);
                            intRankPoint = intRankPoint + intRankSnpPoints;
                            break;
                        case Consts.RankQues.SAltBdate:
                            RnkQuesSearchList = RnkQuesFledsDataEntity.FindAll(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim());
                            strApplicationcode = caseSnp.Find(u => u.FamilySeq.Equals(caseMst.FamilySeq)).AltBdate.ToString();
                            dr["FieldDesc"] = LookupDataAccess.Getdate(strApplicationcode);

                            intRankSnpPoints = CaseSnpDetailsCalc(RnkQuesSearchList, caseSnp, strApplicationcode, rnkQuesData.RankFldName.Trim(), rnkQuesData.RankFldRespType.Trim(), out strResponceDesc);
                            intRankPoint = intRankPoint + intRankSnpPoints;
                            break;
                        case Consts.RankQues.SDisable:
                            RnkQuesSearchList = RnkQuesFledsDataEntity.FindAll(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim());
                            strApplicationcode = caseSnp.Find(u => u.FamilySeq.Equals(caseMst.FamilySeq)).Disable.ToString();
                            //if (rnkQuesData.RankFldRespType == "D" || rnkQuesData.RankFldRespType == "L")
                            //{
                            //    AGYTABSEntity agytab = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == strApplicationcode);
                            //    if (agytab != null)
                            //        dr["FieldDesc"] = agytab.Code_Desc.ToString();
                            //    else
                            //        dr["FieldDesc"] = strApplicationcode;
                            //}
                            //else
                            //    dr["FieldDesc"] = strApplicationcode;

                            intRankSnpPoints = CaseSnpDetailsCalc(RnkQuesSearchList, caseSnp, strApplicationcode, rnkQuesData.RankFldName.Trim(), rnkQuesData.RankFldRespType.Trim(), out strResponceDesc);
                            dr["FieldDesc"] = GetSnpAgyTabDesc(rnkQuesData, strResponceDesc);
                            intRankPoint = intRankPoint + intRankSnpPoints;
                            break;
                        case Consts.RankQues.SDrvlic:
                            RnkQuesSearchList = RnkQuesFledsDataEntity.FindAll(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim());
                            strApplicationcode = caseSnp.Find(u => u.FamilySeq.Equals(caseMst.FamilySeq)).Drvlic.ToString();
                            //if (rnkQuesData.RankFldRespType == "D" || rnkQuesData.RankFldRespType == "L")
                            //{
                            //    AGYTABSEntity agytab = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == strApplicationcode);
                            //    if (agytab != null)
                            //        dr["FieldDesc"] = agytab.Code_Desc.ToString();
                            //    else
                            //        dr["FieldDesc"] = strApplicationcode;
                            //}
                            //else
                            //    dr["FieldDesc"] = strApplicationcode;

                            intRankSnpPoints = CaseSnpDetailsCalc(RnkQuesSearchList, caseSnp, strApplicationcode, rnkQuesData.RankFldName.Trim(), rnkQuesData.RankFldRespType.Trim(), out strResponceDesc);
                            dr["FieldDesc"] = GetSnpAgyTabDesc(rnkQuesData, strResponceDesc);
                            intRankPoint = intRankPoint + intRankSnpPoints;
                            break;
                        case Consts.RankQues.SEmployed:
                            RnkQuesSearchList = RnkQuesFledsDataEntity.FindAll(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim());
                            strApplicationcode = caseSnp.Find(u => u.FamilySeq.Equals(caseMst.FamilySeq)).Employed.ToString();
                            //if (rnkQuesData.RankFldRespType == "D" || rnkQuesData.RankFldRespType == "L")
                            //{
                            //    AGYTABSEntity agytab = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == strApplicationcode);
                            //    if (agytab != null)
                            //        dr["FieldDesc"] = agytab.Code_Desc.ToString();
                            //    else
                            //        dr["FieldDesc"] = strApplicationcode;
                            //}
                            //else
                            //    dr["FieldDesc"] = strApplicationcode;

                            intRankSnpPoints = CaseSnpDetailsCalc(RnkQuesSearchList, caseSnp, strApplicationcode, rnkQuesData.RankFldName.Trim(), rnkQuesData.RankFldRespType.Trim(), out strResponceDesc);
                            dr["FieldDesc"] = GetSnpAgyTabDesc(rnkQuesData, strResponceDesc);
                            intRankPoint = intRankPoint + intRankSnpPoints;
                            break;
                        case Consts.RankQues.SEthinic:
                            RnkQuesSearchList = RnkQuesFledsDataEntity.FindAll(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim());
                            strApplicationcode = caseSnp.Find(u => u.FamilySeq.Equals(caseMst.FamilySeq)).Ethnic.ToString();
                            //if (rnkQuesData.RankFldRespType == "D" || rnkQuesData.RankFldRespType == "L")
                            //{
                            //    AGYTABSEntity agytab = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == strApplicationcode);
                            //    if (agytab != null)
                            //        dr["FieldDesc"] = agytab.Code_Desc.ToString();
                            //    else
                            //        dr["FieldDesc"] = strApplicationcode;
                            //}
                            //else
                            //    dr["FieldDesc"] = strApplicationcode;

                            intRankSnpPoints = CaseSnpDetailsCalc(RnkQuesSearchList, caseSnp, strApplicationcode, rnkQuesData.RankFldName.Trim(), rnkQuesData.RankFldRespType.Trim(), out strResponceDesc);
                            dr["FieldDesc"] = GetSnpAgyTabDesc(rnkQuesData, strResponceDesc);
                            intRankPoint = intRankPoint + intRankSnpPoints;
                            break;
                        case Consts.RankQues.SExpireWorkDate:
                            RnkQuesSearchList = RnkQuesFledsDataEntity.FindAll(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim());
                            strApplicationcode = caseSnp.Find(u => u.FamilySeq.Equals(caseMst.FamilySeq)).ExpireWorkDate.ToString();
                            dr["FieldDesc"] = LookupDataAccess.Getdate(strApplicationcode);

                            intRankSnpPoints = CaseSnpDetailsCalc(RnkQuesSearchList, caseSnp, strApplicationcode, rnkQuesData.RankFldName.Trim(), rnkQuesData.RankFldRespType.Trim(), out strResponceDesc);
                            intRankPoint = intRankPoint + intRankSnpPoints;
                            break;
                        case Consts.RankQues.SFarmer:
                            RnkQuesSearchList = RnkQuesFledsDataEntity.FindAll(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim());
                            strApplicationcode = caseSnp.Find(u => u.FamilySeq.Equals(caseMst.FamilySeq)).Farmer.ToString();
                            //if (rnkQuesData.RankFldRespType == "D" || rnkQuesData.RankFldRespType == "L")
                            //{
                            //    AGYTABSEntity agytab = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == strApplicationcode);
                            //    if (agytab != null)
                            //        dr["FieldDesc"] = agytab.Code_Desc.ToString();
                            //    else
                            //        dr["FieldDesc"] = strApplicationcode;
                            //}
                            //else
                            //    dr["FieldDesc"] = strApplicationcode;

                            intRankSnpPoints = CaseSnpDetailsCalc(RnkQuesSearchList, caseSnp, strApplicationcode, rnkQuesData.RankFldName.Trim(), rnkQuesData.RankFldRespType.Trim(), out strResponceDesc);
                            dr["FieldDesc"] = GetSnpAgyTabDesc(rnkQuesData, strResponceDesc);
                            intRankPoint = intRankPoint + intRankSnpPoints;
                            break;
                        case Consts.RankQues.SFoodStamps:
                            RnkQuesSearchList = RnkQuesFledsDataEntity.FindAll(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim());
                            strApplicationcode = caseSnp.Find(u => u.FamilySeq.Equals(caseMst.FamilySeq)).FootStamps.ToString();
                            //if (rnkQuesData.RankFldRespType == "D" || rnkQuesData.RankFldRespType == "L")
                            //{
                            //    AGYTABSEntity agytab = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == strApplicationcode);
                            //    if (agytab != null)
                            //        dr["FieldDesc"] = agytab.Code_Desc.ToString();
                            //    else
                            //        dr["FieldDesc"] = strApplicationcode;
                            //}
                            //else
                            //    dr["FieldDesc"] = strApplicationcode;

                            intRankSnpPoints = CaseSnpDetailsCalc(RnkQuesSearchList, caseSnp, strApplicationcode, rnkQuesData.RankFldName.Trim(), rnkQuesData.RankFldRespType.Trim(), out strResponceDesc);
                            dr["FieldDesc"] = GetSnpAgyTabDesc(rnkQuesData, strResponceDesc);
                            intRankPoint = intRankPoint + intRankSnpPoints;
                            break;
                        case Consts.RankQues.SFThours:
                            RnkQuesSearchList = RnkQuesFledsDataEntity.FindAll(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim());
                            strApplicationcode = caseSnp.Find(u => u.FamilySeq.Equals(caseMst.FamilySeq)).FullTimeHours.ToString();
                            //if (rnkQuesData.RankFldRespType == "D" || rnkQuesData.RankFldRespType == "L")
                            //{
                            //    AGYTABSEntity agytab = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == strApplicationcode);
                            //    if (agytab != null)
                            //        dr["FieldDesc"] = agytab.Code_Desc.ToString();
                            //    else
                            //        dr["FieldDesc"] = strApplicationcode;
                            //}
                            //else
                            //    dr["FieldDesc"] = strApplicationcode;

                            intRankSnpPoints = CaseSnpDetailsCalc(RnkQuesSearchList, caseSnp, strApplicationcode, rnkQuesData.RankFldName.Trim(), rnkQuesData.RankFldRespType.Trim(), out strResponceDesc);
                            dr["FieldDesc"] = GetSnpAgyTabDesc(rnkQuesData, strResponceDesc);
                            intRankPoint = intRankPoint + intRankSnpPoints;
                            break;
                        case Consts.RankQues.SHealthIns:
                            RnkQuesSearchList = RnkQuesFledsDataEntity.FindAll(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim());
                            strApplicationcode = caseSnp.Find(u => u.FamilySeq.Equals(caseMst.FamilySeq)).HealthIns.ToString();
                            //if (rnkQuesData.RankFldRespType == "D" || rnkQuesData.RankFldRespType == "L")
                            //{
                            //    AGYTABSEntity agytab = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == strApplicationcode);
                            //    if (agytab != null)
                            //        dr["FieldDesc"] = agytab.Code_Desc.ToString();
                            //    else
                            //        dr["FieldDesc"] = strApplicationcode;
                            //}
                            //else
                            //    dr["FieldDesc"] = strApplicationcode;

                            intRankSnpPoints = CaseSnpDetailsCalc(RnkQuesSearchList, caseSnp, strApplicationcode, rnkQuesData.RankFldName.Trim(), rnkQuesData.RankFldRespType.Trim(), out strResponceDesc);
                            dr["FieldDesc"] = GetSnpAgyTabDesc(rnkQuesData, strResponceDesc);
                            intRankPoint = intRankPoint + intRankSnpPoints;
                            break;
                        case Consts.RankQues.SHireDate:
                            RnkQuesSearchList = RnkQuesFledsDataEntity.FindAll(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim());
                            strApplicationcode = caseSnp.Find(u => u.FamilySeq.Equals(caseMst.FamilySeq)).HireDate.ToString();
                            dr["FieldDesc"] = LookupDataAccess.Getdate(strApplicationcode);

                            intRankSnpPoints = CaseSnpDetailsCalc(RnkQuesSearchList, caseSnp, strApplicationcode, rnkQuesData.RankFldName.Trim(), rnkQuesData.RankFldRespType.Trim(), out strResponceDesc);
                            intRankPoint = intRankPoint + intRankSnpPoints;
                            break;
                        case Consts.RankQues.SHourlyWage:
                            RnkQuesSearchList = RnkQuesFledsDataEntity.FindAll(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim());
                            strApplicationcode = caseSnp.Find(u => u.FamilySeq.Equals(caseMst.FamilySeq)).HourlyWage.ToString();
                            //if (rnkQuesData.RankFldRespType == "D" || rnkQuesData.RankFldRespType == "L")
                            //{
                            //    AGYTABSEntity agytab = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == strApplicationcode);
                            //    if (agytab != null)
                            //        dr["FieldDesc"] = agytab.Code_Desc.ToString();
                            //    else
                            //        dr["FieldDesc"] = strApplicationcode;
                            //}
                            //else
                            //    dr["FieldDesc"] = strApplicationcode;

                            intRankSnpPoints = CaseSnpDetailsCalc(RnkQuesSearchList, caseSnp, strApplicationcode, rnkQuesData.RankFldName.Trim(), rnkQuesData.RankFldRespType.Trim(), out strResponceDesc);
                            dr["FieldDesc"] = GetSnpAgyTabDesc(rnkQuesData, strResponceDesc);
                            intRankPoint = intRankPoint + intRankSnpPoints;
                            break;
                        case Consts.RankQues.SjobCategory:
                            RnkQuesSearchList = RnkQuesFledsDataEntity.FindAll(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim());
                            strApplicationcode = caseSnp.Find(u => u.FamilySeq.Equals(caseMst.FamilySeq)).JobCategory.ToString();
                            //if (rnkQuesData.RankFldRespType == "D" || rnkQuesData.RankFldRespType == "L")
                            //{
                            //    AGYTABSEntity agytab = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == strApplicationcode);
                            //    if (agytab != null)
                            //        dr["FieldDesc"] = agytab.Code_Desc.ToString();
                            //    else
                            //        dr["FieldDesc"] = strApplicationcode;
                            //}
                            //else
                            //    dr["FieldDesc"] = strApplicationcode;

                            intRankSnpPoints = CaseSnpDetailsCalc(RnkQuesSearchList, caseSnp, strApplicationcode, rnkQuesData.RankFldName.Trim(), rnkQuesData.RankFldRespType.Trim(), out strResponceDesc);
                            dr["FieldDesc"] = GetSnpAgyTabDesc(rnkQuesData, strResponceDesc);
                            intRankPoint = intRankPoint + intRankSnpPoints;
                            break;
                        case Consts.RankQues.SjobTitle:
                            RnkQuesSearchList = RnkQuesFledsDataEntity.FindAll(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim());
                            strApplicationcode = caseSnp.Find(u => u.FamilySeq.Equals(caseMst.FamilySeq)).JobTitle.ToString();
                            //if (rnkQuesData.RankFldRespType == "D" || rnkQuesData.RankFldRespType == "L")
                            //{
                            //    AGYTABSEntity agytab = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == strApplicationcode);
                            //    if (agytab != null)
                            //        dr["FieldDesc"] = agytab.Code_Desc.ToString();
                            //    else
                            //        dr["FieldDesc"] = strApplicationcode;
                            //}
                            //else
                            //    dr["FieldDesc"] = strApplicationcode;

                            intRankSnpPoints = CaseSnpDetailsCalc(RnkQuesSearchList, caseSnp, strApplicationcode, rnkQuesData.RankFldName.Trim(), rnkQuesData.RankFldRespType.Trim(), out strResponceDesc);
                            dr["FieldDesc"] = GetSnpAgyTabDesc(rnkQuesData, strResponceDesc);
                            intRankPoint = intRankPoint + intRankSnpPoints;
                            break;
                        case Consts.RankQues.SLastWorkDate:
                            RnkQuesSearchList = RnkQuesFledsDataEntity.FindAll(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim());
                            strApplicationcode = caseSnp.Find(u => u.FamilySeq.Equals(caseMst.FamilySeq)).LastWorkDate.ToString();
                            dr["FieldDesc"] = LookupDataAccess.Getdate(strApplicationcode);

                            intRankSnpPoints = CaseSnpDetailsCalc(RnkQuesSearchList, caseSnp, strApplicationcode, rnkQuesData.RankFldName.Trim(), rnkQuesData.RankFldRespType.Trim(), out strResponceDesc);
                            intRankPoint = intRankPoint + intRankSnpPoints;
                            break;
                        case Consts.RankQues.SLegalTowork:
                            RnkQuesSearchList = RnkQuesFledsDataEntity.FindAll(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim());
                            strApplicationcode = caseSnp.Find(u => u.FamilySeq.Equals(caseMst.FamilySeq)).LegalTowork.ToString();
                            //if (rnkQuesData.RankFldRespType == "D" || rnkQuesData.RankFldRespType == "L")
                            //{
                            //    AGYTABSEntity agytab = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == strApplicationcode);
                            //    if (agytab != null)
                            //        dr["FieldDesc"] = agytab.Code_Desc.ToString();
                            //    else
                            //        dr["FieldDesc"] = strApplicationcode;
                            //}
                            //else
                            //    dr["FieldDesc"] = strApplicationcode;

                            intRankSnpPoints = CaseSnpDetailsCalc(RnkQuesSearchList, caseSnp, strApplicationcode, rnkQuesData.RankFldName.Trim(), rnkQuesData.RankFldRespType.Trim(), out strResponceDesc);
                            dr["FieldDesc"] = GetSnpAgyTabDesc(rnkQuesData, strResponceDesc);
                            intRankPoint = intRankPoint + intRankSnpPoints;
                            break;
                        case Consts.RankQues.SMartialStatus:
                            RnkQuesSearchList = RnkQuesFledsDataEntity.FindAll(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim());
                            strApplicationcode = caseSnp.Find(u => u.FamilySeq.Equals(caseMst.FamilySeq)).MaritalStatus.ToString();
                            //if (rnkQuesData.RankFldRespType == "D" || rnkQuesData.RankFldRespType == "L")
                            //{
                            //    AGYTABSEntity agytab = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == strApplicationcode);
                            //    if (agytab != null)
                            //        dr["FieldDesc"] = agytab.Code_Desc.ToString();
                            //    else
                            //        dr["FieldDesc"] = strApplicationcode;
                            //}
                            //else
                            //    dr["FieldDesc"] = strApplicationcode;

                            intRankSnpPoints = CaseSnpDetailsCalc(RnkQuesSearchList, caseSnp, strApplicationcode, rnkQuesData.RankFldName.Trim(), rnkQuesData.RankFldRespType.Trim(), out strResponceDesc);
                            dr["FieldDesc"] = GetSnpAgyTabDesc(rnkQuesData, strResponceDesc);
                            intRankPoint = intRankPoint + intRankSnpPoints;
                            break;
                        case Consts.RankQues.SMemberCode:
                            RnkQuesSearchList = RnkQuesFledsDataEntity.FindAll(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim());
                            strApplicationcode = caseSnp.Find(u => u.FamilySeq.Equals(caseMst.FamilySeq)).MemberCode.ToString();
                            //if (rnkQuesData.RankFldRespType == "D" || rnkQuesData.RankFldRespType == "L")
                            //{
                            //    AGYTABSEntity agytab = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == strApplicationcode);
                            //    if (agytab != null)
                            //        dr["FieldDesc"] = agytab.Code_Desc.ToString();
                            //    else
                            //        dr["FieldDesc"] = strApplicationcode;
                            //}
                            //else
                            //    dr["FieldDesc"] = strApplicationcode;

                            intRankSnpPoints = CaseSnpDetailsCalc(RnkQuesSearchList, caseSnp, strApplicationcode, rnkQuesData.RankFldName.Trim(), rnkQuesData.RankFldRespType.Trim(), out strResponceDesc);
                            dr["FieldDesc"] = GetSnpAgyTabDesc(rnkQuesData, strResponceDesc);
                            intRankPoint = intRankPoint + intRankSnpPoints;
                            break;
                        case Consts.RankQues.SNofcjob:
                            RnkQuesSearchList = RnkQuesFledsDataEntity.FindAll(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim());
                            strApplicationcode = caseSnp.Find(u => u.FamilySeq.Equals(caseMst.FamilySeq)).NumberOfcjobs.ToString();
                            //if (rnkQuesData.RankFldRespType == "D" || rnkQuesData.RankFldRespType == "L")
                            //{
                            //    AGYTABSEntity agytab = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == strApplicationcode);
                            //    if (agytab != null)
                            //        dr["FieldDesc"] = agytab.Code_Desc.ToString();
                            //    else
                            //        dr["FieldDesc"] = strApplicationcode;
                            //}
                            //else
                            //    dr["FieldDesc"] = strApplicationcode;

                            intRankSnpPoints = CaseSnpDetailsCalc(RnkQuesSearchList, caseSnp, strApplicationcode, rnkQuesData.RankFldName.Trim(), rnkQuesData.RankFldRespType.Trim(), out strResponceDesc);
                            dr["FieldDesc"] = GetSnpAgyTabDesc(rnkQuesData, strResponceDesc);
                            intRankPoint = intRankPoint + intRankSnpPoints;
                            break;
                        case Consts.RankQues.SNofljobs:
                            RnkQuesSearchList = RnkQuesFledsDataEntity.FindAll(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim());
                            strApplicationcode = caseSnp.Find(u => u.FamilySeq.Equals(caseMst.FamilySeq)).NumberofLvjobs.ToString();
                            //if (rnkQuesData.RankFldRespType == "D" || rnkQuesData.RankFldRespType == "L")
                            //{
                            //    AGYTABSEntity agytab = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == strApplicationcode);
                            //    if (agytab != null)
                            //        dr["FieldDesc"] = agytab.Code_Desc.ToString();
                            //    else
                            //        dr["FieldDesc"] = strApplicationcode;
                            //}
                            //else
                            //    dr["FieldDesc"] = strApplicationcode;

                            intRankSnpPoints = CaseSnpDetailsCalc(RnkQuesSearchList, caseSnp, strApplicationcode, rnkQuesData.RankFldName.Trim(), rnkQuesData.RankFldRespType.Trim(), out strResponceDesc);
                            dr["FieldDesc"] = GetSnpAgyTabDesc(rnkQuesData, strResponceDesc);
                            intRankPoint = intRankPoint + intRankSnpPoints;
                            break;
                        case Consts.RankQues.SPFrequency:
                            RnkQuesSearchList = RnkQuesFledsDataEntity.FindAll(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim());
                            strApplicationcode = caseSnp.Find(u => u.FamilySeq.Equals(caseMst.FamilySeq)).PayFrequency.ToString();
                            //if (rnkQuesData.RankFldRespType == "D" || rnkQuesData.RankFldRespType == "L")
                            //{
                            //    AGYTABSEntity agytab = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == strApplicationcode);
                            //    if (agytab != null)
                            //        dr["FieldDesc"] = agytab.Code_Desc.ToString();
                            //    else
                            //        dr["FieldDesc"] = strApplicationcode;
                            //}
                            //else
                            //    dr["FieldDesc"] = strApplicationcode;

                            intRankSnpPoints = CaseSnpDetailsCalc(RnkQuesSearchList, caseSnp, strApplicationcode, rnkQuesData.RankFldName.Trim(), rnkQuesData.RankFldRespType.Trim(), out strResponceDesc);
                            dr["FieldDesc"] = GetSnpAgyTabDesc(rnkQuesData, strResponceDesc);
                            intRankPoint = intRankPoint + intRankSnpPoints;
                            break;
                        case Consts.RankQues.SPregnant:
                            RnkQuesSearchList = RnkQuesFledsDataEntity.FindAll(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim());
                            strApplicationcode = caseSnp.Find(u => u.FamilySeq.Equals(caseMst.FamilySeq)).Pregnant.ToString();
                            //if (rnkQuesData.RankFldRespType == "D" || rnkQuesData.RankFldRespType == "L")
                            //{
                            //    AGYTABSEntity agytab = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == strApplicationcode);
                            //    if (agytab != null)
                            //        dr["FieldDesc"] = agytab.Code_Desc.ToString();
                            //    else
                            //        dr["FieldDesc"] = strApplicationcode;
                            //}
                            //else
                            //    dr["FieldDesc"] = strApplicationcode;

                            intRankSnpPoints = CaseSnpDetailsCalc(RnkQuesSearchList, caseSnp, strApplicationcode, rnkQuesData.RankFldName.Trim(), rnkQuesData.RankFldRespType.Trim(), out strResponceDesc);
                            dr["FieldDesc"] = GetSnpAgyTabDesc(rnkQuesData, strResponceDesc);
                            intRankPoint = intRankPoint + intRankSnpPoints;
                            break;
                        case Consts.RankQues.SPThours:
                            RnkQuesSearchList = RnkQuesFledsDataEntity.FindAll(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim());
                            strApplicationcode = caseSnp.Find(u => u.FamilySeq.Equals(caseMst.FamilySeq)).PartTimeHours.ToString();
                            //if (rnkQuesData.RankFldRespType == "D" || rnkQuesData.RankFldRespType == "L")
                            //{
                            //    AGYTABSEntity agytab = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == strApplicationcode);
                            //    if (agytab != null)
                            //        dr["FieldDesc"] = agytab.Code_Desc.ToString();
                            //    else
                            //        dr["FieldDesc"] = strApplicationcode;
                            //}
                            //else
                            //    dr["FieldDesc"] = strApplicationcode;

                            intRankSnpPoints = CaseSnpDetailsCalc(RnkQuesSearchList, caseSnp, strApplicationcode, rnkQuesData.RankFldName.Trim(), rnkQuesData.RankFldRespType.Trim(), out strResponceDesc);
                            dr["FieldDesc"] = GetSnpAgyTabDesc(rnkQuesData, strResponceDesc);
                            intRankPoint = intRankPoint + intRankSnpPoints;
                            break;
                        case Consts.RankQues.SRace:
                            RnkQuesSearchList = RnkQuesFledsDataEntity.FindAll(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim());
                            strApplicationcode = caseSnp.Find(u => u.FamilySeq.Equals(caseMst.FamilySeq)).Race.ToString();
                            //if (rnkQuesData.RankFldRespType == "D" || rnkQuesData.RankFldRespType == "L")
                            //{
                            //    AGYTABSEntity agytab = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == strApplicationcode);
                            //    if (agytab != null)
                            //        dr["FieldDesc"] = agytab.Code_Desc.ToString();
                            //    else
                            //        dr["FieldDesc"] = strApplicationcode;
                            //}
                            //else
                            //    dr["FieldDesc"] = strApplicationcode;

                            intRankSnpPoints = CaseSnpDetailsCalc(RnkQuesSearchList, caseSnp, strApplicationcode, rnkQuesData.RankFldName.Trim(), rnkQuesData.RankFldRespType.Trim(), out strResponceDesc);
                            dr["FieldDesc"] = GetSnpAgyTabDesc(rnkQuesData, strResponceDesc);
                            intRankPoint = intRankPoint + intRankSnpPoints;
                            break;
                        case Consts.RankQues.SRelitran:
                            RnkQuesSearchList = RnkQuesFledsDataEntity.FindAll(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim());
                            strApplicationcode = caseSnp.Find(u => u.FamilySeq.Equals(caseMst.FamilySeq)).Relitran.ToString();
                            //if (rnkQuesData.RankFldRespType == "D" || rnkQuesData.RankFldRespType == "L")
                            //{
                            //    AGYTABSEntity agytab = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == strApplicationcode);
                            //    if (agytab != null)
                            //        dr["FieldDesc"] = agytab.Code_Desc.ToString();
                            //    else
                            //        dr["FieldDesc"] = strApplicationcode;
                            //}
                            //else
                            //    dr["FieldDesc"] = strApplicationcode;

                            intRankSnpPoints = CaseSnpDetailsCalc(RnkQuesSearchList, caseSnp, strApplicationcode, rnkQuesData.RankFldName.Trim(), rnkQuesData.RankFldRespType.Trim(), out strResponceDesc);
                            dr["FieldDesc"] = GetSnpAgyTabDesc(rnkQuesData, strResponceDesc);
                            intRankPoint = intRankPoint + intRankSnpPoints;
                            break;
                        case Consts.RankQues.SResident:
                            RnkQuesSearchList = RnkQuesFledsDataEntity.FindAll(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim());
                            strApplicationcode = caseSnp.Find(u => u.FamilySeq.Equals(caseMst.FamilySeq)).Resident.ToString();
                            //if (rnkQuesData.RankFldRespType == "D" || rnkQuesData.RankFldRespType == "L")
                            //{
                            //    AGYTABSEntity agytab = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == strApplicationcode);
                            //    if (agytab != null)
                            //        dr["FieldDesc"] = agytab.Code_Desc.ToString();
                            //    else
                            //        dr["FieldDesc"] = strApplicationcode;
                            //}
                            //else
                            //    dr["FieldDesc"] = strApplicationcode;

                            intRankSnpPoints = CaseSnpDetailsCalc(RnkQuesSearchList, caseSnp, strApplicationcode, rnkQuesData.RankFldName.Trim(), rnkQuesData.RankFldRespType.Trim(), out strResponceDesc);
                            dr["FieldDesc"] = GetSnpAgyTabDesc(rnkQuesData, strResponceDesc);
                            intRankPoint = intRankPoint + intRankSnpPoints;
                            break;
                        case Consts.RankQues.SRshift:
                            RnkQuesSearchList = RnkQuesFledsDataEntity.FindAll(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim());
                            strApplicationcode = caseSnp.Find(u => u.FamilySeq.Equals(caseMst.FamilySeq)).RShift.ToString();
                            //if (rnkQuesData.RankFldRespType == "D" || rnkQuesData.RankFldRespType == "L")
                            //{
                            //    AGYTABSEntity agytab = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == strApplicationcode);
                            //    if (agytab != null)
                            //        dr["FieldDesc"] = agytab.Code_Desc.ToString();
                            //    else
                            //        dr["FieldDesc"] = strApplicationcode;
                            //}
                            //else
                            //    dr["FieldDesc"] = strApplicationcode;
                            intRankSnpPoints = CaseSnpDetailsCalc(RnkQuesSearchList, caseSnp, strApplicationcode, rnkQuesData.RankFldName.Trim(), rnkQuesData.RankFldRespType.Trim(), out strResponceDesc);
                            dr["FieldDesc"] = GetSnpAgyTabDesc(rnkQuesData, strResponceDesc);
                            intRankPoint = intRankPoint + intRankSnpPoints;
                            break;
                        case Consts.RankQues.SSchoolDistrict:
                            RnkQuesSearchList = RnkQuesFledsDataEntity.FindAll(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim());
                            strApplicationcode = caseSnp.Find(u => u.FamilySeq.Equals(caseMst.FamilySeq)).SchoolDistrict.ToString();
                            //if (rnkQuesData.RankFldRespType == "D" || rnkQuesData.RankFldRespType == "L")
                            //{
                            //    AGYTABSEntity agytab = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == strApplicationcode);
                            //    if (agytab != null)
                            //        dr["FieldDesc"] = agytab.Code_Desc.ToString();
                            //    else
                            //        dr["FieldDesc"] = strApplicationcode;
                            //}
                            //else
                            //    dr["FieldDesc"] = strApplicationcode;
                            intRankSnpPoints = CaseSnpDetailsCalc(RnkQuesSearchList, caseSnp, strApplicationcode, rnkQuesData.RankFldName.Trim(), rnkQuesData.RankFldRespType.Trim(), out strResponceDesc);
                            dr["FieldDesc"] = GetSnpAgyTabDesc(rnkQuesData, strResponceDesc);
                            intRankPoint = intRankPoint + intRankSnpPoints;
                            break;
                        case Consts.RankQues.SSEmploy:
                            RnkQuesSearchList = RnkQuesFledsDataEntity.FindAll(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim());
                            strApplicationcode = caseSnp.Find(u => u.FamilySeq.Equals(caseMst.FamilySeq)).Employed.ToString();
                            //if (rnkQuesData.RankFldRespType == "D" || rnkQuesData.RankFldRespType == "L")
                            //{
                            //    AGYTABSEntity agytab = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == strApplicationcode);
                            //    if (agytab != null)
                            //        dr["FieldDesc"] = agytab.Code_Desc.ToString();
                            //    else
                            //        dr["FieldDesc"] = strApplicationcode;
                            //}
                            //else
                            //    dr["FieldDesc"] = strApplicationcode;
                            intRankSnpPoints = CaseSnpDetailsCalc(RnkQuesSearchList, caseSnp, strApplicationcode, rnkQuesData.RankFldName.Trim(), rnkQuesData.RankFldRespType.Trim(), out strResponceDesc);
                            dr["FieldDesc"] = GetSnpAgyTabDesc(rnkQuesData, strResponceDesc);
                            intRankPoint = intRankPoint + intRankSnpPoints;
                            break;
                        case Consts.RankQues.SSex:
                            RnkQuesSearchList = RnkQuesFledsDataEntity.FindAll(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim());
                            strApplicationcode = caseSnp.Find(u => u.FamilySeq.Equals(caseMst.FamilySeq)).Sex.ToString();
                            //if (rnkQuesData.RankFldRespType == "D" || rnkQuesData.RankFldRespType == "L")
                            //{
                            //    AGYTABSEntity agytab = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == strApplicationcode);
                            //    if (agytab != null)
                            //        dr["FieldDesc"] = agytab.Code_Desc.ToString();
                            //    else
                            //        dr["FieldDesc"] = strApplicationcode;
                            //}
                            //else
                            //    dr["FieldDesc"] = strApplicationcode;
                            intRankSnpPoints = CaseSnpDetailsCalc(RnkQuesSearchList, caseSnp, strApplicationcode, rnkQuesData.RankFldName.Trim(), rnkQuesData.RankFldRespType.Trim(), out strResponceDesc);
                            dr["FieldDesc"] = GetSnpAgyTabDesc(rnkQuesData, strResponceDesc);
                            intRankPoint = intRankPoint + intRankSnpPoints;
                            break;
                        case Consts.RankQues.SSnpVet:
                            RnkQuesSearchList = RnkQuesFledsDataEntity.FindAll(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim());
                            strApplicationcode = caseSnp.Find(u => u.FamilySeq.Equals(caseMst.FamilySeq)).Vet.ToString();
                            //if (rnkQuesData.RankFldRespType == "D" || rnkQuesData.RankFldRespType == "L")
                            //{
                            //    AGYTABSEntity agytab = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == strApplicationcode);
                            //    if (agytab != null)
                            //        dr["FieldDesc"] = agytab.Code_Desc.ToString();
                            //    else
                            //        dr["FieldDesc"] = strApplicationcode;
                            //}
                            //else
                            //    dr["FieldDesc"] = strApplicationcode;
                            intRankSnpPoints = CaseSnpDetailsCalc(RnkQuesSearchList, caseSnp, strApplicationcode, rnkQuesData.RankFldName.Trim(), rnkQuesData.RankFldRespType.Trim(), out strResponceDesc);
                            dr["FieldDesc"] = GetSnpAgyTabDesc(rnkQuesData, strResponceDesc);
                            intRankPoint = intRankPoint + intRankSnpPoints;
                            break;
                        case Consts.RankQues.SStatus:
                            RnkQuesSearchList = RnkQuesFledsDataEntity.FindAll(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim());
                            strApplicationcode = caseSnp.Find(u => u.FamilySeq.Equals(caseMst.FamilySeq)).Status.ToString();
                            //if (rnkQuesData.RankFldRespType == "D" || rnkQuesData.RankFldRespType == "L")
                            //{
                            //    AGYTABSEntity agytab = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == strApplicationcode);
                            //    if (agytab != null)
                            //        dr["FieldDesc"] = agytab.Code_Desc.ToString();
                            //    else
                            //        dr["FieldDesc"] = strApplicationcode;
                            //}
                            //else
                            //    dr["FieldDesc"] = strApplicationcode;
                            intRankSnpPoints = CaseSnpDetailsCalc(RnkQuesSearchList, caseSnp, strApplicationcode, rnkQuesData.RankFldName.Trim(), rnkQuesData.RankFldRespType.Trim(), out strResponceDesc);
                            dr["FieldDesc"] = GetSnpAgyTabDesc(rnkQuesData, strResponceDesc);
                            intRankPoint = intRankPoint + intRankSnpPoints;
                            break;
                        case Consts.RankQues.STranserv:
                            RnkQuesSearchList = RnkQuesFledsDataEntity.FindAll(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim());
                            strApplicationcode = caseSnp.Find(u => u.FamilySeq.Equals(caseMst.FamilySeq)).Transerv.ToString();
                            //if (rnkQuesData.RankFldRespType == "D" || rnkQuesData.RankFldRespType == "L")
                            //{
                            //    AGYTABSEntity agytab = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == strApplicationcode);
                            //    if (agytab != null)
                            //        dr["FieldDesc"] = agytab.Code_Desc.ToString();
                            //    else
                            //        dr["FieldDesc"] = strApplicationcode;
                            //}
                            //else
                            //    dr["FieldDesc"] = strApplicationcode;
                            intRankSnpPoints = CaseSnpDetailsCalc(RnkQuesSearchList, caseSnp, strApplicationcode, rnkQuesData.RankFldName.Trim(), rnkQuesData.RankFldRespType.Trim(), out strResponceDesc);
                            dr["FieldDesc"] = GetSnpAgyTabDesc(rnkQuesData, strResponceDesc);
                            intRankPoint = intRankPoint + intRankSnpPoints;
                            break;
                        case Consts.RankQues.SWic:
                            RnkQuesSearchList = RnkQuesFledsDataEntity.FindAll(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim());
                            strApplicationcode = caseSnp.Find(u => u.FamilySeq.Equals(caseMst.FamilySeq)).Wic.ToString();

                            intRankSnpPoints = CaseSnpDetailsCalc(RnkQuesSearchList, caseSnp, strApplicationcode, rnkQuesData.RankFldName.Trim(), rnkQuesData.RankFldRespType.Trim(), out strResponceDesc);
                            intRankPoint = intRankPoint + intRankSnpPoints;
                            break;
                        case Consts.RankQues.SworkLimit:
                            RnkQuesSearchList = RnkQuesFledsDataEntity.FindAll(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim());
                            strApplicationcode = caseSnp.Find(u => u.FamilySeq.Equals(caseMst.FamilySeq)).WorkLimit.ToString();
                            //if (rnkQuesData.RankFldRespType == "D" || rnkQuesData.RankFldRespType == "L")
                            //{
                            //    AGYTABSEntity agytab = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == strApplicationcode);
                            //    if (agytab != null)
                            //        dr["FieldDesc"] = agytab.Code_Desc.ToString();
                            //    else
                            //        dr["FieldDesc"] = strApplicationcode;
                            //}
                            //else
                            //    dr["FieldDesc"] = strApplicationcode;
                            intRankSnpPoints = CaseSnpDetailsCalc(RnkQuesSearchList, caseSnp, strApplicationcode, rnkQuesData.RankFldName.Trim(), rnkQuesData.RankFldRespType.Trim(), out strResponceDesc);
                            dr["FieldDesc"] = GetSnpAgyTabDesc(rnkQuesData, strResponceDesc);
                            intRankPoint = intRankPoint + intRankSnpPoints;
                            break;
                        case Consts.RankQues.WorkStatus:
                            RnkQuesSearchList = RnkQuesFledsDataEntity.FindAll(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim());
                            strApplicationcode = caseSnp.Find(u => u.FamilySeq.Equals(caseMst.FamilySeq)).WorkStatus.ToString();

                            intRankSnpPoints = CaseSnpDetailsCalc(RnkQuesSearchList, caseSnp, strApplicationcode, rnkQuesData.RankFldName.Trim(), rnkQuesData.RankFldRespType.Trim(), out strResponceDesc);
                            dr["FieldDesc"] = GetSnpAgyTabDesc(rnkQuesData, strResponceDesc);
                            intRankPoint = intRankPoint + intRankSnpPoints;
                            break;
                        case Consts.RankQues.DisconectYouth:
                            RnkQuesSearchList = RnkQuesFledsDataEntity.FindAll(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim());
                            strApplicationcode = caseSnp.Find(u => u.FamilySeq.Equals(caseMst.FamilySeq)).Youth.ToString();

                            intRankSnpPoints = CaseSnpDetailsCalc(RnkQuesSearchList, caseSnp, strApplicationcode, rnkQuesData.RankFldName.Trim(), rnkQuesData.RankFldRespType.Trim(), out strResponceDesc);
                            dr["FieldDesc"] = GetSnpAgyTabDesc(rnkQuesData, strResponceDesc);
                            intRankPoint = intRankPoint + intRankSnpPoints;
                            break;
                        case Consts.RankQues.MiltaryStatus:
                            RnkQuesSearchList = RnkQuesFledsDataEntity.FindAll(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim());
                            strApplicationcode = caseSnp.Find(u => u.FamilySeq.Equals(caseMst.FamilySeq)).MilitaryStatus.ToString();

                            intRankSnpPoints = CaseSnpDetailsCalc(RnkQuesSearchList, caseSnp, strApplicationcode, rnkQuesData.RankFldName.Trim(), rnkQuesData.RankFldRespType.Trim(), out strResponceDesc);
                            dr["FieldDesc"] = GetSnpAgyTabDesc(rnkQuesData, strResponceDesc);
                            intRankPoint = intRankPoint + intRankSnpPoints;
                            break;
                        case Consts.RankQues.HealthCodes:
                            RnkQuesSearchList = RnkQuesFledsDataEntity.FindAll(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim());
                            strApplicationcode = caseSnp.Find(u => u.FamilySeq.Equals(caseMst.FamilySeq)).Health_Codes.ToString();

                            intRankSnpPoints = CaseSnpDetailsCalc(RnkQuesSearchList, caseSnp, strApplicationcode, rnkQuesData.RankFldName.Trim(), rnkQuesData.RankFldRespType.Trim(), out strResponceDesc);
                            dr["FieldDesc"] = GetSnpAgyTabDesc(rnkQuesData, strResponceDesc);
                            intRankPoint = intRankPoint + intRankSnpPoints;
                            break;
                        case Consts.RankQues.CDentalCoverage:
                            if (chldMst != null)
                            {
                                dr["FieldDesc"] = GetSnpAgyTabDesc(rnkQuesData, (chldMst.DentalCoverage.Trim() == "True" ? "1" : "0"));
                               // dr["FieldDesc"] = chldMst.DentalCoverage.Trim() == "True" ? "Seleted" : "UnSelected";
                                RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && u.RespCd.Trim() == (chldMst.DentalCoverage.Trim() == "True" ? "1" : "0"));
                            }
                            break;
                        case Consts.RankQues.CDiagNosisDate:
                            if (chldMst != null)
                                if (chldMst.DiagnosisDate != string.Empty)
                                {
                                    dr["FieldDesc"] = LookupDataAccess.Getdate(chldMst.DiagnosisDate);
                                    RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && Convert.ToDateTime(u.LtDate).Date >= Convert.ToDateTime(chldMst.DiagnosisDate).Date && Convert.ToDateTime(u.GtDate).Date <= Convert.ToDateTime(chldMst.DiagnosisDate).Date);
                                }
                            break;
                        case Consts.RankQues.CDisability:
                            if (chldMst != null)
                            {
                                dr["FieldDesc"] = GetSnpAgyTabDesc(rnkQuesData, (chldMst.Disability.Trim() == "True" ? "1" : "0"));
                               // dr["FieldDesc"] = chldMst.Disability.Trim() == "True" ? "Seleted" : "UnSelected";
                                RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && u.RespCd.Trim() == (chldMst.Disability.Trim() == "True" ? "1" : "0"));
                            }
                            break;
                        case Consts.RankQues.CInsCat:
                            if (chldMst != null)
                            {
                                dr["FieldDesc"] = chldMst.InsCat.Trim();
                                RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && u.RespCd.Trim() == chldMst.InsCat.Trim());
                            }
                            break;
                        case Consts.RankQues.CMedCoverage:
                            if (chldMst != null)
                            {
                                dr["FieldDesc"] = GetSnpAgyTabDesc(rnkQuesData, (chldMst.MedCoverage.Trim() == "True" ? "1" : "0"));
                                //dr["FieldDesc"] = chldMst.MedCoverage.Trim() == "True" ? "Seleted" : "UnSelected";
                                RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && u.RespCd.Trim() == (chldMst.MedCoverage.Trim() == "True" ? "1" : "0"));
                            }
                            break;
                        case Consts.RankQues.CMedicalCoverageType:
                            if (chldMst != null)
                            {
                                dr["FieldDesc"] = chldMst.MedCoverType.Trim();
                                RnkQuesSearch = RnkQuesFledsDataEntity.Find(u => u.RankFldName.Trim() == rnkQuesData.RankFldName.Trim() && u.RespCd.Trim() == chldMst.MedCoverType.Trim());
                            }
                            break;


                    }

                    if (RnkQuesSearch != null)
                    {
                        intRankPoint = intRankPoint + Convert.ToInt32(RnkQuesSearch.Points);
                        dr["Points"] = RnkQuesSearch.Points;
                        dtRankSubDetails.Rows.Add(dr);
                    }
                    else
                    {
                        dr["Points"] = intRankSnpPoints;
                        dtRankSubDetails.Rows.Add(dr);
                    }
                    // }


                    //ListRankPoints.Add(new CommonEntity(intRankCtg.ToString(), intRankPoint.ToString()));
                }


                #region Preassess tab calculation
                if (custpresResponses.Count > 0)
                {
                    CustomQuestionsEntity custpresResponcesearch = null;
                    RNKCRIT2Entity rnkPoints = null;
                    string strQuestionType = string.Empty;
                    foreach (CustomQuestionsEntity responceQuestion in custpresResponses)
                    {
                        DataRow dr1 = dtRankSubDetails.NewRow();
                        List<RNKCRIT2Entity> rnkCustFldsFilterCode = RnkCustFldsDataEntity.FindAll(u => u.RankFiledCode.Trim() == responceQuestion.ACTCODE.Trim());

                        if (rnkCustFldsFilterCode.Count > 0)
                        {
                            custpresResponcesearch = null;
                            rnkPoints = null;
                            strQuestionType = rnkCustFldsFilterCode[0].RankFldRespType.Trim();
                            if (strQuestionType.ToString() != "C")
                            {
                                dr1["FieldCode"] = rnkCustFldsFilterCode[0].RankFldDesc.Trim();

                                switch (rnkCustFldsFilterCode[0].RankFldRespType.Trim())
                                {
                                    case "D":
                                    case "L":
                                        rnkPoints = rnkCustFldsFilterCode.Find(u => u.RespCd.Trim() == responceQuestion.ACTMULTRESP.Trim());
                                         //custResponcesearch = custResponses.Find(u => u.ACTCODE.Trim().Equals(item.RankFiledCode) && u.ACTMULTRESP.Trim() == item.RespCd.Trim());
                                         CustRespEntity custrespent = propPresResponceList.Find(u => u.ResoCode.Trim() == responceQuestion.ACTCODE && u.DescCode == responceQuestion.ACTMULTRESP);
                                        if(custrespent!=null)
                                            dr1["FieldDesc"] = custrespent.RespDesc.ToString();
                                        else
                                            dr1["FieldDesc"] = string.Empty;
                                        break;
                                    case "N":
                                        rnkPoints = rnkCustFldsFilterCode.Find(u => Convert.ToDecimal(u.GtNum) <= Convert.ToDecimal(responceQuestion.ACTNUMRESP) && Convert.ToDecimal(u.LtNum) >= Convert.ToDecimal(responceQuestion.ACTNUMRESP));
                                        // custResponcesearch = custResponses.Find(u => u.ACTCODE.Trim().Equals(item.RankFiledCode) && Convert.ToDecimal(u.GtNum) >= Convert.ToDecimal(item.ACTNUMRESP) && Convert.ToDecimal(u.LtNum) <= Convert.ToDecimal(item.ACTNUMRESP));
                                        dr1["FieldDesc"] = responceQuestion.ACTNUMRESP;
                                        break;
                                    case "T":
                                    case "B":
                                        rnkPoints = rnkCustFldsFilterCode.Find(u => Convert.ToDateTime(u.GtDate) <= Convert.ToDateTime(responceQuestion.ACTDATERESP) && Convert.ToDateTime(u.LtDate) >= Convert.ToDateTime(responceQuestion.ACTDATERESP));
                                        // custResponcesearch = custResponses.Find(u => u.ACTCODE.Trim().Equals(item.RankFiledCode) && Convert.ToDateTime(u.GtDate) >= Convert.ToDateTime(item.ACTDATERESP) && Convert.ToDateTime(u.LtDate) <= Convert.ToDateTime(item.ACTNUMRESP));
                                        dr1["FieldDesc"] = responceQuestion.ACTDATERESP;
                                        break;
                                }
                                if (rnkPoints != null)
                                {
                                    dr1["Points"] = rnkPoints.Points;
                                    intRankPoint = intRankPoint + Convert.ToInt32(rnkPoints.Points);
                                }
                                else
                                {
                                    dr1["Points"] = "0";
                                }
                                dtRankSubDetails.Rows.Add(dr1);
                            }
                            else
                            {

                                var strresponcelist = responceQuestion.ACTALPHARESP.Split(',');
                                foreach (var item in strresponcelist)
                                {
                                    DataRow dr2 = dtRankSubDetails.NewRow();

                                    dr2["FieldCode"] = rnkCustFldsFilterCode[0].RankFldDesc.Trim();
                                    rnkPoints = rnkCustFldsFilterCode.Find(u => u.RespCd.Trim() == item);
                                    CustRespEntity custrespent = propPresResponceList.Find(u => u.ResoCode.Trim() == responceQuestion.ACTCODE && u.DescCode == item);
                                    if (custrespent != null)
                                        dr2["FieldDesc"] = custrespent.RespDesc.ToString();
                                    else
                                        dr2["FieldDesc"] = string.Empty;
                                    //dr2["FieldDesc"] = propPresResponceList.Find(u => u.ResoCode.Trim() == responceQuestion.ACTCODE && u.DescCode == item).RespDesc.ToString();

                                    if (rnkPoints != null)
                                    {
                                        dr2["Points"] = rnkPoints.Points;
                                        intRankPoint = intRankPoint + Convert.ToInt32(rnkPoints.Points);
                                    }
                                    else
                                    {
                                        dr2["Points"] = "0";
                                    }
                                    dtRankSubDetails.Rows.Add(dr2);
                                }

                            }

                        }

                    }
                }

                #endregion



                if (custResponses.Count > 0)
                {
                    CustomQuestionsEntity custResponcesearch = null;
                    RNKCRIT2Entity rnkPoints = null;
                    string strQuestionType = string.Empty;
                    foreach (CustomQuestionsEntity responceQuestion in custResponses)
                    {
                        DataRow dr1 = dtRankSubDetails.NewRow();
                        List<RNKCRIT2Entity> rnkCustFldsFilterCode = RnkCustFldsDataEntity.FindAll(u => u.RankFiledCode.Trim() == responceQuestion.ACTCODE.Trim());

                        if (rnkCustFldsFilterCode.Count > 0)
                        {                           

                                custResponcesearch = null;
                                rnkPoints = null;
                                strQuestionType = rnkCustFldsFilterCode[0].RankFldRespType.Trim();
                                if (strQuestionType.ToString() != "C")
                                {
                                    dr1["FieldCode"] = rnkCustFldsFilterCode[0].RankFldDesc.Trim();

                                    switch (rnkCustFldsFilterCode[0].RankFldRespType.Trim())
                                    {
                                        case "D":
                                        case "L":
                                            rnkPoints = rnkCustFldsFilterCode.Find(u => u.RespCd.Trim() == responceQuestion.ACTMULTRESP.Trim());
                                            //custResponcesearch = custResponses.Find(u => u.ACTCODE.Trim().Equals(item.RankFiledCode) && u.ACTMULTRESP.Trim() == item.RespCd.Trim());
                                            dr1["FieldDesc"] = propCustResponceList.Find(u => u.ResoCode.Trim() == responceQuestion.ACTCODE && u.DescCode == responceQuestion.ACTMULTRESP).RespDesc.ToString();
                                            break;
                                        case "N":
                                            rnkPoints = rnkCustFldsFilterCode.Find(u => Convert.ToDecimal(u.GtNum) <= Convert.ToDecimal(responceQuestion.ACTNUMRESP) && Convert.ToDecimal(u.LtNum) >= Convert.ToDecimal(responceQuestion.ACTNUMRESP));
                                            // custResponcesearch = custResponses.Find(u => u.ACTCODE.Trim().Equals(item.RankFiledCode) && Convert.ToDecimal(u.GtNum) >= Convert.ToDecimal(item.ACTNUMRESP) && Convert.ToDecimal(u.LtNum) <= Convert.ToDecimal(item.ACTNUMRESP));
                                            dr1["FieldDesc"] = responceQuestion.ACTNUMRESP;
                                            break;
                                        case "T":
                                        case "B":
                                            rnkPoints = rnkCustFldsFilterCode.Find(u => Convert.ToDateTime(u.GtDate) <= Convert.ToDateTime(responceQuestion.ACTDATERESP) && Convert.ToDateTime(u.LtDate) >= Convert.ToDateTime(responceQuestion.ACTDATERESP));
                                            // custResponcesearch = custResponses.Find(u => u.ACTCODE.Trim().Equals(item.RankFiledCode) && Convert.ToDateTime(u.GtDate) >= Convert.ToDateTime(item.ACTDATERESP) && Convert.ToDateTime(u.LtDate) <= Convert.ToDateTime(item.ACTNUMRESP));
                                            dr1["FieldDesc"] = responceQuestion.ACTDATERESP;
                                            break;
                                    }
                                    if (rnkPoints != null)
                                    {
                                        dr1["Points"] = rnkPoints.Points;
                                        intRankPoint = intRankPoint + Convert.ToInt32(rnkPoints.Points);
                                    }
                                    else
                                    {
                                        dr1["Points"] = "0";
                                    }
                                    dtRankSubDetails.Rows.Add(dr1);
                                }
                                else
                                {

                                    var strresponcelist = responceQuestion.ACTALPHARESP.Split(',');
                                    foreach (var item in strresponcelist)
                                    {
                                        DataRow dr2 = dtRankSubDetails.NewRow();

                                        dr2["FieldCode"] = rnkCustFldsFilterCode[0].RankFldDesc.Trim();
                                        rnkPoints = rnkCustFldsFilterCode.Find(u => u.RespCd.Trim() == item);
                                        dr2["FieldDesc"] = propCustResponceList.Find(u => u.ResoCode.Trim() == responceQuestion.ACTCODE && u.DescCode == item).RespDesc.ToString();

                                        if (rnkPoints != null)
                                        {
                                            dr2["Points"] = rnkPoints.Points;
                                            intRankPoint = intRankPoint + Convert.ToInt32(rnkPoints.Points);
                                        }
                                        else
                                        {
                                            dr2["Points"] = "0";
                                        }
                                        dtRankSubDetails.Rows.Add(dr2);
                                    }

                                }
                            
                            //custResponcesearch = null;
                            //rnkPoints = null;
                            //strQuestionType = rnkCustFldsFilterCode[0].RankFldRespType.Trim();
                            //dr1["FieldCode"] = rnkCustFldsFilterCode[0].RankFldDesc.Trim();

                            //switch (rnkCustFldsFilterCode[0].RankFldRespType.Trim())
                            //{
                            //    case "D":
                            //    case "L":
                            //        rnkPoints = rnkCustFldsFilterCode.Find(u => u.RespCd.Trim() == responceQuestion.ACTMULTRESP.Trim());
                            //        //custResponcesearch = custResponses.Find(u => u.ACTCODE.Trim().Equals(item.RankFiledCode) && u.ACTMULTRESP.Trim() == item.RespCd.Trim());
                            //        dr1["FieldDesc"] = propCustResponceList.Find(u => u.ResoCode.Trim() == responceQuestion.ACTCODE && u.DescCode == responceQuestion.ACTMULTRESP).RespDesc.ToString();
                            //        break;
                            //    case "N":
                            //        rnkPoints = rnkCustFldsFilterCode.Find(u => Convert.ToDecimal(u.GtNum) <= Convert.ToDecimal(responceQuestion.ACTNUMRESP) && Convert.ToDecimal(u.LtNum) >= Convert.ToDecimal(responceQuestion.ACTNUMRESP));
                            //        // custResponcesearch = custResponses.Find(u => u.ACTCODE.Trim().Equals(item.RankFiledCode) && Convert.ToDecimal(u.GtNum) >= Convert.ToDecimal(item.ACTNUMRESP) && Convert.ToDecimal(u.LtNum) <= Convert.ToDecimal(item.ACTNUMRESP));
                            //        dr1["FieldDesc"] = responceQuestion.ACTNUMRESP;
                            //        break;
                            //    case "T":
                            //    case "B":
                            //        rnkPoints = rnkCustFldsFilterCode.Find(u => Convert.ToDateTime(u.GtDate) <= Convert.ToDateTime(responceQuestion.ACTDATERESP) && Convert.ToDateTime(u.LtDate) >= Convert.ToDateTime(responceQuestion.ACTDATERESP));
                            //        // custResponcesearch = custResponses.Find(u => u.ACTCODE.Trim().Equals(item.RankFiledCode) && Convert.ToDateTime(u.GtDate) >= Convert.ToDateTime(item.ACTDATERESP) && Convert.ToDateTime(u.LtDate) <= Convert.ToDateTime(item.ACTNUMRESP));
                            //        dr1["FieldDesc"] = responceQuestion.ACTDATERESP;
                            //        break;
                            //}
                            //if (rnkPoints != null)
                            //{
                            //    dr1["Points"] = rnkPoints.Points;
                            //    intRankPoint = intRankPoint + Convert.ToInt32(rnkPoints.Points);
                            //}
                            //else
                            //{
                            //    dr1["Points"] = "0";
                            //}
                            //dtRankSubDetails.Rows.Add(dr1);

                        }





                        //foreach (RNKCRIT2Entity item in rnkCustFldsFilterCode)
                        //{

                        //    if (responceQuestion.ACTCODE.Trim() == item.RankFiledCode.Trim())
                        //    {
                        //        custResponcesearch = null;
                        //        strQuestionType = item.RankFldRespType.Trim();
                        //        dr1["FieldCode"] = item.RankFldDesc.Trim();

                        //        switch (item.RankFldRespType.Trim())
                        //        {
                        //            case "D":
                        //            case "L":
                        //                custResponcesearch = custResponses.Find(u => u.ACTCODE.Trim().Equals(item.RankFiledCode) && u.ACTMULTRESP.Trim() == item.RespCd.Trim());
                        //                dr1["FieldDesc"] = propCustResponceList.Find(u => u.ResoCode.Trim() == responceQuestion.ACTCODE && u.DescCode == responceQuestion.ACTMULTRESP).RespDesc.ToString();
                        //                break;
                        //            case "N":
                        //                custResponcesearch = custResponses.Find(u => u.ACTCODE.Trim().Equals(item.RankFiledCode) && Convert.ToDecimal(u.ACTNUMRESP) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(u.ACTNUMRESP) <= Convert.ToDecimal(item.LtNum));
                        //                dr1["FieldDesc"] = responceQuestion.ACTNUMRESP;
                        //                break;
                        //            case "T":
                        //            case "B":
                        //                custResponcesearch = custResponses.Find(u => u.ACTCODE.Trim().Equals(item.RankFiledCode) && Convert.ToDateTime(u.ACTDATERESP) >= Convert.ToDateTime(item.GtDate) && Convert.ToDateTime(u.ACTNUMRESP) <= Convert.ToDateTime(item.LtDate));
                        //                dr1["FieldDesc"] = responceQuestion.ACTDATERESP;
                        //                break;
                        //        }
                        //        if (custResponcesearch != null)
                        //        {
                        //            dr1["Points"] = item.Points;
                        //            intRankPoint = intRankPoint + Convert.ToInt32(item.Points);
                        //        }
                        //        else
                        //        {
                        //            dr1["Points"] = "0";
                        //        }
                        //        dtRankSubDetails.Rows.Add(dr1);                                
                        //    }
                        //}

                    }
                }
            }
            catch (Exception ex)
            {

                // MessageBox.Show(ex.Message);
            }

            return dtRankSubDetails;
        }

        private int fillAlertIncomeCodes(string alertCodes, List<RNKCRIT2Entity> rnkSearchEntity, string FieldName)
        {
            int intAlertcode = 0;
            List<string> AlertList = new List<string>();
            if (alertCodes != null)
            {
                string[] incomeTypes = alertCodes.Split(' ');
                for (int i = 0; i < incomeTypes.Length; i++)
                {
                    AlertList.Add(incomeTypes.GetValue(i).ToString());
                }
            }
            List<RNKCRIT2Entity> RnkAlertCode = rnkSearchEntity.FindAll(u => u.RankFldName.Trim() == FieldName);

            foreach (RNKCRIT2Entity rnkEntity in RnkAlertCode)
            {
                if (alertCodes != null && AlertList.Contains(rnkEntity.RespCd))
                {
                    intAlertcode = intAlertcode + Convert.ToInt32(rnkEntity.Points);
                }
            }
            return intAlertcode;
        }

        private int fillAlertNonCashBenCodes(string alertCodes, List<RNKCRIT2Entity> rnkSearchEntity, string FieldName)
        {
            int intAlertcode = 0;
            List<string> AlertList = new List<string>();
            if (alertCodes != null)
            {
                string[] NonCashBen = alertCodes.Split(',');
                for (int i = 0; i < NonCashBen.Length; i++)
                {
                    AlertList.Add(NonCashBen.GetValue(i).ToString());
                }
            }
            List<RNKCRIT2Entity> RnkAlertCode = rnkSearchEntity.FindAll(u => u.RankFldName.Trim() == FieldName);

            foreach (RNKCRIT2Entity rnkEntity in RnkAlertCode)
            {
                if (alertCodes != null && AlertList.Contains(rnkEntity.RespCd))
                {
                    intAlertcode = intAlertcode + Convert.ToInt32(rnkEntity.Points);
                }
            }
            return intAlertcode;
        }
                
        private int fillAlertHealthCodes(string alertCodes, List<RNKCRIT2Entity> rnkSearchEntity, string FieldName, string CountInd)
        {
            int intAlertcode = 0;
            List<string> AlertList = new List<string>();
            if (alertCodes != null)
            {
                string[] HealthCodes = alertCodes.Split(',');
                for (int i = 0; i < HealthCodes.Length; i++)
                {
                    AlertList.Add(HealthCodes.GetValue(i).ToString());
                }
            }
            List<RNKCRIT2Entity> RnkAlertCode = rnkSearchEntity.FindAll(u => u.RankFldName.Trim() == FieldName && u.CountInd.Trim() == CountInd);

            foreach (RNKCRIT2Entity rnkEntity in RnkAlertCode)
            {
                if (alertCodes != null && AlertList.Contains(rnkEntity.RespCd))
                {
                    intAlertcode = intAlertcode + Convert.ToInt32(rnkEntity.Points);
                }
            }
            return intAlertcode;
        }


        private int CaseSnpDetailsCalc(List<RNKCRIT2Entity> rnkCaseSnp, List<CaseSnpEntity> caseSnpDetails, string strApplicantCode, string FilterCode, string ResponceType, out string strResponseDesc)
        {
            int intSnpPoints = 0; int HealthPoints = 0;
            string strResponceCode = strApplicantCode;
            string strResponceData = strApplicantCode;
            List<CommonEntity> commonHighcount = new List<CommonEntity>();
            List<CommonEntity> commonLowcount = new List<CommonEntity>();
            commonHighcount.Clear();
            commonLowcount.Clear();
            foreach (RNKCRIT2Entity item in rnkCaseSnp)
            {
                List<RNKCRIT2Entity> RnkCrit2 = rnkCaseSnp.FindAll(u => u.RespCd.Equals(item.RespCd));
                HealthPoints = 0;
                if (item.CountInd.Trim() == "A")
                {
                    switch (ResponceType)
                    {
                        case "D":
                        case "L":
                            if (item.RespCd.Trim() == strApplicantCode)
                            {
                                intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                            }
                            if (FilterCode == Consts.RankQues.HealthCodes)
                            {
                                intSnpPoints = fillAlertHealthCodes(strApplicantCode, RnkCrit2, FilterCode.Trim(),item.CountInd.Trim());
                            }
                            break;
                        case "N":
                            if (strApplicantCode != string.Empty)
                                if (Convert.ToDecimal(strApplicantCode) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(strApplicantCode) <= Convert.ToDecimal(item.LtNum))
                                {
                                    intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                }
                            break;
                        case "G":
                            CaseSnpEntity casesnpAge = caseSnpDetails.Find(u => u.FamilySeq == propMstRank.FamilySeq);
                            if (casesnpAge != null)
                            {
                                if (casesnpAge.AltBdate != string.Empty && item.Relation.Trim() == casesnpAge.MemberCode)
                                {
                                    DateTime EndDate = GetEndDateAgeCalculation(item.AgeClcInd.Trim(), propMstRank);
                                    int AgeMonth = _model.lookupDataAccess.GetAgeCalculationMonths(Convert.ToDateTime(casesnpAge.AltBdate), EndDate);
                                    if (AgeMonth >= Convert.ToDecimal(item.GtNum) && AgeMonth <= Convert.ToDecimal(item.LtNum))
                                    {
                                        intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                    }
                                    if (AgeMonth > 12)
                                    {
                                        strResponceData = (AgeMonth / 12).ToString();
                                    }
                                }
                            }
                            break;
                        case "B":
                        case "T":
                            if (strApplicantCode != string.Empty)
                                if (Convert.ToDateTime(strApplicantCode).Date >= Convert.ToDateTime(item.GtDate).Date && Convert.ToDateTime(strApplicantCode).Date <= Convert.ToDateTime(item.LtDate).Date)
                                {
                                    intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                }
                            break;

                    }

                }
                else if (item.CountInd.Trim() == "M")
                {
                    if (item.Relation == "*")
                    {
                        int count = 0;
                        switch (FilterCode)
                        {
                            case Consts.RankQues.S1shift:
                                count = caseSnpDetails.FindAll(u => u.IstShift.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.S2ndshift:
                                count = caseSnpDetails.FindAll(u => u.IIndShift.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.S3rdShift:
                                count = caseSnpDetails.FindAll(u => u.IIIrdShift.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SAge:
                                foreach (CaseSnpEntity snpDate in caseSnpDetails)
                                {
                                    if (snpDate.AltBdate != string.Empty)
                                    {
                                        DateTime EndDate = GetEndDateAgeCalculation(item.AgeClcInd.Trim(), propMstRank);
                                        int AgeMonth = _model.lookupDataAccess.GetAgeCalculationMonths(Convert.ToDateTime(snpDate.AltBdate), EndDate);
                                        if (AgeMonth >= Convert.ToDecimal(item.GtNum) && AgeMonth <= Convert.ToDecimal(item.LtNum))
                                        {
                                            count = count + 1;
                                        }
                                    }
                                }
                                break;
                            case Consts.RankQues.SAltBdate:
                                foreach (CaseSnpEntity snpDate in caseSnpDetails)
                                {
                                    if (snpDate.AltBdate != string.Empty)
                                        if (Convert.ToDateTime(snpDate.AltBdate).Date >= Convert.ToDateTime(item.GtDate).Date && Convert.ToDateTime(snpDate.AltBdate).Date <= Convert.ToDateTime(item.LtDate).Date)
                                        {
                                            count = count + 1;
                                        }
                                }

                                break;
                            case Consts.RankQues.SSchoolDistrict:
                                count = caseSnpDetails.FindAll(u => u.SchoolDistrict.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SEducation:
                                count = caseSnpDetails.FindAll(u => u.Education.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SWic:
                                count = caseSnpDetails.FindAll(u => u.Wic.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SDisable:
                                count = caseSnpDetails.FindAll(u => u.Disable.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SDrvlic:
                                count = caseSnpDetails.FindAll(u => u.Drvlic.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SEmployed:
                                count = caseSnpDetails.FindAll(u => u.Employed.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SEthinic:
                                count = caseSnpDetails.FindAll(u => u.Ethnic.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SExpireWorkDate:
                                foreach (CaseSnpEntity snpDate in caseSnpDetails)
                                {
                                    if (snpDate.ExpireWorkDate != string.Empty)
                                        if (Convert.ToDateTime(snpDate.ExpireWorkDate).Date >= Convert.ToDateTime(item.GtDate).Date && Convert.ToDateTime(snpDate.ExpireWorkDate).Date <= Convert.ToDateTime(item.LtDate).Date)
                                        {
                                            count = count + 1;
                                        }
                                }
                                break;
                            case Consts.RankQues.SFarmer:
                                count = caseSnpDetails.FindAll(u => u.Farmer.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SFoodStamps:
                                count = caseSnpDetails.FindAll(u => u.FootStamps.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.WorkStatus:
                                count = caseSnpDetails.FindAll(u => u.WorkStatus.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.DisconectYouth:
                                count = caseSnpDetails.FindAll(u => u.Youth.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.MiltaryStatus:
                                count = caseSnpDetails.FindAll(u => u.MilitaryStatus.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.HealthCodes:
                                foreach (CaseSnpEntity snpHealth in caseSnpDetails)
                                {
                                    if (!string.IsNullOrEmpty(snpHealth.Health_Codes.Trim()))
                                    {
                                        int intRankSnpPoints = fillAlertHealthCodes(snpHealth.Health_Codes.Trim(), RnkCrit2, FilterCode.Trim(), item.CountInd.Trim());
                                        HealthPoints = HealthPoints + intRankSnpPoints;
                                        //count = intRankSnpPoints + Convert.ToInt32(item.Points);
                                    }
                                    count = count + 1;
                                }
                                if (count == caseSnpDetails.Count)
                                { intSnpPoints = intSnpPoints + HealthPoints; count++; }
                                break;
                            case Consts.RankQues.SFThours:
                                foreach (CaseSnpEntity snpNumeric in caseSnpDetails)
                                {
                                    if (snpNumeric.FullTimeHours != string.Empty)
                                        if (Convert.ToDecimal(snpNumeric.FullTimeHours) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(snpNumeric.FullTimeHours) <= Convert.ToDecimal(item.LtNum))
                                        {
                                            count = count + 1;
                                        }
                                }
                                break;
                            case Consts.RankQues.SHealthIns:
                                count = caseSnpDetails.FindAll(u => u.HealthIns.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SHireDate:
                                foreach (CaseSnpEntity snpDate in caseSnpDetails)
                                {
                                    if (snpDate.HireDate != string.Empty)
                                        if (Convert.ToDateTime(snpDate.HireDate).Date >= Convert.ToDateTime(item.GtDate).Date && Convert.ToDateTime(snpDate.HireDate).Date <= Convert.ToDateTime(item.LtDate).Date)
                                        {
                                            count = count + 1;
                                        }
                                }
                                break;
                            case Consts.RankQues.SHourlyWage:
                                foreach (CaseSnpEntity snpNumeric in caseSnpDetails)
                                {
                                    if (snpNumeric.HourlyWage != string.Empty)
                                        if (Convert.ToDecimal(snpNumeric.HourlyWage) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(snpNumeric.HourlyWage) <= Convert.ToDecimal(item.LtNum))
                                        {
                                            count = count + 1;
                                        }
                                }
                                break;
                            case Consts.RankQues.SjobCategory:
                                count = caseSnpDetails.FindAll(u => u.JobCategory.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SjobTitle:
                                count = caseSnpDetails.FindAll(u => u.JobTitle.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SLastWorkDate:
                                foreach (CaseSnpEntity snpDate in caseSnpDetails)
                                {
                                    if (snpDate.LastWorkDate != string.Empty)
                                        if (Convert.ToDateTime(snpDate.LastWorkDate).Date >= Convert.ToDateTime(item.GtDate).Date && Convert.ToDateTime(snpDate.LastWorkDate).Date <= Convert.ToDateTime(item.LtDate).Date)
                                        {
                                            count = count + 1;
                                        }
                                }
                                break;
                            case Consts.RankQues.SLegalTowork:
                                count = caseSnpDetails.FindAll(u => u.LegalTowork.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SMartialStatus:
                                count = caseSnpDetails.FindAll(u => u.MaritalStatus.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SMemberCode:
                                count = caseSnpDetails.FindAll(u => u.MemberCode.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SNofcjob:
                                foreach (CaseSnpEntity snpNumeric in caseSnpDetails)
                                {
                                    if (snpNumeric.NumberOfcjobs != string.Empty)
                                        if (Convert.ToDecimal(snpNumeric.NumberOfcjobs) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(snpNumeric.NumberOfcjobs) <= Convert.ToDecimal(item.LtNum))
                                        {
                                            count = count + 1;
                                        }
                                }
                                break;
                            case Consts.RankQues.SNofljobs:
                                foreach (CaseSnpEntity snpNumeric in caseSnpDetails)
                                {
                                    if (snpNumeric.NumberofLvjobs != string.Empty)
                                        if (Convert.ToDecimal(snpNumeric.NumberofLvjobs) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(snpNumeric.NumberofLvjobs) <= Convert.ToDecimal(item.LtNum))
                                        {
                                            count = count + 1;
                                        }
                                }
                                break;
                            case Consts.RankQues.SPFrequency:
                                count = caseSnpDetails.FindAll(u => u.PayFrequency.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SPregnant:
                                count = caseSnpDetails.FindAll(u => u.Pregnant.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SPThours:
                                foreach (CaseSnpEntity snpNumeric in caseSnpDetails)
                                {
                                    if (snpNumeric.PartTimeHours != string.Empty)
                                        if (Convert.ToDecimal(snpNumeric.PartTimeHours) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(snpNumeric.PartTimeHours) <= Convert.ToDecimal(item.LtNum))
                                        {
                                            count = count + 1;
                                        }
                                }
                                break;
                            case Consts.RankQues.SRace:
                                count = caseSnpDetails.FindAll(u => u.Race.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SRelitran:
                                count = caseSnpDetails.FindAll(u => u.Relitran.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SResident:
                                count = caseSnpDetails.FindAll(u => u.Resident.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SRshift:
                                count = caseSnpDetails.FindAll(u => u.RShift.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SSEmploy:
                                count = caseSnpDetails.FindAll(u => u.SeasonalEmploy.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SSex:
                                count = caseSnpDetails.FindAll(u => u.Sex.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SSnpVet:
                                count = caseSnpDetails.FindAll(u => u.Vet.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SStatus:
                                count = caseSnpDetails.FindAll(u => u.Status.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.STranserv:
                                count = caseSnpDetails.FindAll(u => u.Transerv.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SworkLimit:
                                count = caseSnpDetails.FindAll(u => u.WorkLimit.Trim().Equals(item.RespCd)).Count;
                                break;

                        }

                        if (caseSnpDetails.Count == count)
                            intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                    }
                    else
                    {
                        switch (ResponceType)
                        {
                            case "D":
                            case "L":
                                foreach (CaseSnpEntity snpdropdown in caseSnpDetails)
                                {

                                    switch (FilterCode)
                                    {
                                        case Consts.RankQues.S1shift:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.IstShift.Trim())
                                            {
                                                intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.S2ndshift:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.IIndShift.Trim())
                                            {
                                                intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.S3rdShift:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.IIIrdShift.Trim())
                                            {
                                                intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SSchoolDistrict:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.SchoolDistrict.Trim())
                                            {
                                                intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SEducation:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Education.Trim())
                                            {
                                                intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SWic:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Wic.Trim())
                                            {
                                                intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SDisable:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Disable.Trim())
                                            {
                                                intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SDrvlic:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Drvlic.Trim())
                                            {
                                                intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SEmployed:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Employed.Trim())
                                            {
                                                intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SEthinic:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Ethnic.Trim())
                                            {
                                                intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SFarmer:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Farmer.Trim())
                                            {
                                                intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SFoodStamps:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.FootStamps.Trim())
                                            {
                                                intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.WorkStatus:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.WorkStatus.Trim())
                                            {
                                                intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.DisconectYouth:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Youth.Trim())
                                            {
                                                intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.MiltaryStatus:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.MilitaryStatus.Trim())
                                            {
                                                intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.HealthCodes:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode)
                                            {
                                                int intRankSnpPoints = fillAlertHealthCodes(snpdropdown.Health_Codes.Trim(), RnkCrit2, FilterCode.Trim(), item.CountInd.Trim());
                                                intSnpPoints = intSnpPoints + intRankSnpPoints;

                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SHealthIns:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.HealthIns.Trim())
                                            {
                                                intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SjobCategory:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.JobCategory.Trim())
                                            {
                                                intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SjobTitle:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.JobTitle.Trim())
                                            {
                                                intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SLegalTowork:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.LegalTowork.Trim())
                                            {
                                                intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SMartialStatus:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.MaritalStatus.Trim())
                                            {
                                                intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SMemberCode:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.MemberCode.Trim())
                                            {
                                                intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SPFrequency:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.PayFrequency.Trim())
                                            {
                                                intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SPregnant:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Pregnant.Trim())
                                            {
                                                intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SRace:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Race.Trim())
                                            {
                                                intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SRelitran:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Relitran.Trim())
                                            {
                                                intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SResident:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Resident.Trim())
                                            {
                                                intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SRshift:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.RShift.Trim())
                                            {
                                                intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SSEmploy:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.SeasonalEmploy.Trim())
                                            {
                                                intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SSex:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Sex.Trim())
                                            {
                                                intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SSnpVet:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Vet.Trim())
                                            {
                                                intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SStatus:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Status.Trim())
                                            {
                                                intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.STranserv:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Transerv.Trim())
                                            {
                                                intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SworkLimit:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.WorkLimit.Trim())
                                            {
                                                intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                    }
                                }
                                //if (listRelationstring.Contains(item.Relation))
                                //{
                                //    if (listCodestring.Contains(item.RespCd))
                                //    {
                                //        intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                //    }
                                //}
                                break;
                            case "N":
                            case "G":
                                foreach (CaseSnpEntity snpNumeric in caseSnpDetails)
                                {

                                    switch (FilterCode)
                                    {
                                        case Consts.RankQues.SAge:
                                            if (snpNumeric.AltBdate != string.Empty && item.Relation.Trim() == snpNumeric.MemberCode)
                                            {
                                                DateTime EndDate = GetEndDateAgeCalculation(item.AgeClcInd.Trim(), propMstRank);
                                                int AgeMonth = _model.lookupDataAccess.GetAgeCalculationMonths(Convert.ToDateTime(snpNumeric.AltBdate), EndDate);
                                                if (AgeMonth >= Convert.ToDecimal(item.GtNum) && AgeMonth <= Convert.ToDecimal(item.LtNum))
                                                {
                                                    intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                }
                                                if (AgeMonth > 12)
                                                {
                                                    strResponceData = (AgeMonth / 12).ToString();
                                                }
                                            }
                                            break;

                                        case Consts.RankQues.SNofcjob:
                                            if (snpNumeric.NumberOfcjobs != string.Empty && item.Relation.Trim() == snpNumeric.MemberCode)
                                                if (Convert.ToDecimal(snpNumeric.NumberOfcjobs) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(snpNumeric.NumberOfcjobs) <= Convert.ToDecimal(item.LtNum))
                                                {
                                                    intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                }
                                            break;
                                        case Consts.RankQues.SNofljobs:
                                            if (snpNumeric.NumberofLvjobs != string.Empty && item.Relation.Trim() == snpNumeric.MemberCode)
                                                if (Convert.ToDecimal(snpNumeric.NumberofLvjobs) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(snpNumeric.NumberofLvjobs) <= Convert.ToDecimal(item.LtNum))
                                                {
                                                    intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                }
                                            break;
                                        case Consts.RankQues.SFThours:
                                            if (snpNumeric.FullTimeHours != string.Empty && item.Relation.Trim() == snpNumeric.MemberCode)
                                                if (Convert.ToDecimal(snpNumeric.FullTimeHours) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(snpNumeric.FullTimeHours) <= Convert.ToDecimal(item.LtNum))
                                                {
                                                    intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                }
                                            break;
                                        case Consts.RankQues.SPThours:
                                            if (snpNumeric.PartTimeHours != string.Empty && item.Relation.Trim() == snpNumeric.MemberCode)
                                                if (Convert.ToDecimal(snpNumeric.PartTimeHours) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(snpNumeric.PartTimeHours) <= Convert.ToDecimal(item.LtNum))
                                                {
                                                    intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                }
                                            break;
                                        case Consts.RankQues.SHourlyWage:
                                            if (snpNumeric.HourlyWage != string.Empty && item.Relation.Trim() == snpNumeric.MemberCode)
                                                if (Convert.ToDecimal(snpNumeric.HourlyWage) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(snpNumeric.HourlyWage) <= Convert.ToDecimal(item.LtNum))
                                                {
                                                    intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                }
                                            break;

                                    }
                                }
                                break;
                            case "B":
                            case "T":
                                foreach (CaseSnpEntity snpNumeric in caseSnpDetails)
                                {

                                    switch (FilterCode)
                                    {
                                        case Consts.RankQues.SAltBdate:
                                            if (snpNumeric.AltBdate != string.Empty && item.Relation.Trim() == snpNumeric.MemberCode)
                                                if (Convert.ToDateTime(snpNumeric.AltBdate).Date >= Convert.ToDateTime(item.GtDate).Date && Convert.ToDateTime(snpNumeric.AltBdate).Date <= Convert.ToDateTime(item.LtDate).Date)
                                                {
                                                    intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                }
                                            break;
                                        case Consts.RankQues.SExpireWorkDate:
                                            if (snpNumeric.ExpireWorkDate != string.Empty && item.Relation.Trim() == snpNumeric.MemberCode)
                                                if (Convert.ToDateTime(snpNumeric.ExpireWorkDate).Date >= Convert.ToDateTime(item.GtDate).Date && Convert.ToDateTime(snpNumeric.ExpireWorkDate).Date <= Convert.ToDateTime(item.LtDate).Date)
                                                {
                                                    intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                }
                                            break;
                                        case Consts.RankQues.SLastWorkDate:
                                            if (snpNumeric.LastWorkDate != string.Empty && item.Relation.Trim() == snpNumeric.MemberCode)
                                                if (Convert.ToDateTime(snpNumeric.LastWorkDate).Date >= Convert.ToDateTime(item.GtDate).Date && Convert.ToDateTime(snpNumeric.LastWorkDate).Date <= Convert.ToDateTime(item.LtDate).Date)
                                                {
                                                    intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                }
                                            break;
                                        case Consts.RankQues.SHireDate:
                                            if (snpNumeric.HireDate != string.Empty && item.Relation.Trim() == snpNumeric.MemberCode)
                                                if (Convert.ToDateTime(snpNumeric.HireDate).Date >= Convert.ToDateTime(item.GtDate).Date && Convert.ToDateTime(snpNumeric.HireDate).Date <= Convert.ToDateTime(item.LtDate).Date)
                                                {
                                                    intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                }
                                            break;


                                    }
                                }
                                break;

                        }


                    }

                }
                else if (item.CountInd.Trim() == "H")
                {
                    if (item.Relation == "*")
                    {
                        int count = 0;
                        switch (FilterCode)
                        {
                            case Consts.RankQues.S1shift:
                                count = caseSnpDetails.FindAll(u => u.IstShift.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.S2ndshift:
                                count = caseSnpDetails.FindAll(u => u.IIndShift.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.S3rdShift:
                                count = caseSnpDetails.FindAll(u => u.IIIrdShift.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SAge:
                                foreach (CaseSnpEntity snpDate in caseSnpDetails)
                                {
                                    if (snpDate.AltBdate != string.Empty)
                                    {
                                        DateTime EndDate = GetEndDateAgeCalculation(item.AgeClcInd.Trim(), propMstRank);
                                        int AgeMonth = _model.lookupDataAccess.GetAgeCalculationMonths(Convert.ToDateTime(snpDate.AltBdate), EndDate);
                                        if (AgeMonth >= Convert.ToDecimal(item.GtNum) && AgeMonth <= Convert.ToDecimal(item.LtNum))
                                        {
                                            count = count + 1;
                                        }
                                    }
                                }
                                break;
                            case Consts.RankQues.SAltBdate:
                                foreach (CaseSnpEntity snpDate in caseSnpDetails)
                                {
                                    if (snpDate.AltBdate != string.Empty)
                                        if (Convert.ToDateTime(snpDate.AltBdate).Date >= Convert.ToDateTime(item.GtDate).Date && Convert.ToDateTime(snpDate.AltBdate).Date <= Convert.ToDateTime(item.LtDate).Date)
                                        {
                                            count = count + 1;
                                        }
                                }

                                break;
                            case Consts.RankQues.SSchoolDistrict:
                                count = caseSnpDetails.FindAll(u => u.SchoolDistrict.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SEducation:
                                count = caseSnpDetails.FindAll(u => u.Education.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SWic:
                                count = caseSnpDetails.FindAll(u => u.Wic.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SDisable:
                                count = caseSnpDetails.FindAll(u => u.Disable.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SDrvlic:
                                count = caseSnpDetails.FindAll(u => u.Drvlic.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SEmployed:
                                count = caseSnpDetails.FindAll(u => u.Employed.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SEthinic:
                                count = caseSnpDetails.FindAll(u => u.Ethnic.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SExpireWorkDate:
                                foreach (CaseSnpEntity snpDate in caseSnpDetails)
                                {
                                    if (snpDate.ExpireWorkDate != string.Empty)
                                        if (Convert.ToDateTime(snpDate.ExpireWorkDate).Date >= Convert.ToDateTime(item.GtDate).Date && Convert.ToDateTime(snpDate.ExpireWorkDate).Date <= Convert.ToDateTime(item.LtDate).Date)
                                        {
                                            count = count + 1;
                                        }
                                }
                                break;
                            case Consts.RankQues.SFarmer:
                                count = caseSnpDetails.FindAll(u => u.Farmer.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SFoodStamps:
                                count = caseSnpDetails.FindAll(u => u.FootStamps.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.WorkStatus:
                                count = caseSnpDetails.FindAll(u => u.WorkStatus.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.DisconectYouth:
                                count = caseSnpDetails.FindAll(u => u.Youth.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.MiltaryStatus:
                                count = caseSnpDetails.FindAll(u => u.MilitaryStatus.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.HealthCodes:
                                foreach (CaseSnpEntity snpHealth in caseSnpDetails)
                                {
                                    if (!string.IsNullOrEmpty(snpHealth.Health_Codes.Trim()))
                                    {
                                        int intRankSnpPoints = fillAlertHealthCodes(snpHealth.Health_Codes.Trim(), RnkCrit2, FilterCode.Trim(), item.CountInd.Trim());
                                        HealthPoints = HealthPoints + intRankSnpPoints;
                                        //count = intRankSnpPoints + Convert.ToInt32(item.Points);
                                    }
                                    count = count + 1;
                                }
                                if (caseSnpDetails.Count == count)
                                {
                                    commonHighcount.Add(new CommonEntity(HealthPoints.ToString(), item.RespCd));
                                    count++;
                                }

                                break;
                            case Consts.RankQues.SFThours:
                                foreach (CaseSnpEntity snpNumeric in caseSnpDetails)
                                {
                                    if (snpNumeric.FullTimeHours != string.Empty)
                                        if (Convert.ToDecimal(snpNumeric.FullTimeHours) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(snpNumeric.FullTimeHours) <= Convert.ToDecimal(item.LtNum))
                                        {
                                            count = count + 1;
                                        }
                                }
                                break;
                            case Consts.RankQues.SHealthIns:
                                count = caseSnpDetails.FindAll(u => u.HealthIns.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SHireDate:
                                foreach (CaseSnpEntity snpDate in caseSnpDetails)
                                {
                                    if (snpDate.HireDate != string.Empty)
                                        if (Convert.ToDateTime(snpDate.HireDate).Date >= Convert.ToDateTime(item.GtDate).Date && Convert.ToDateTime(snpDate.HireDate).Date <= Convert.ToDateTime(item.LtDate).Date)
                                        {
                                            count = count + 1;
                                        }
                                }
                                break;
                            case Consts.RankQues.SHourlyWage:
                                foreach (CaseSnpEntity snpNumeric in caseSnpDetails)
                                {
                                    if (snpNumeric.HourlyWage != string.Empty)
                                        if (Convert.ToDecimal(snpNumeric.HourlyWage) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(snpNumeric.HourlyWage) <= Convert.ToDecimal(item.LtNum))
                                        {
                                            count = count + 1;
                                        }
                                }
                                break;
                            case Consts.RankQues.SjobCategory:
                                count = caseSnpDetails.FindAll(u => u.JobCategory.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SjobTitle:
                                count = caseSnpDetails.FindAll(u => u.JobTitle.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SLastWorkDate:
                                foreach (CaseSnpEntity snpDate in caseSnpDetails)
                                {
                                    if (snpDate.LastWorkDate != string.Empty)
                                        if (Convert.ToDateTime(snpDate.LastWorkDate).Date >= Convert.ToDateTime(item.GtDate).Date && Convert.ToDateTime(snpDate.LastWorkDate).Date <= Convert.ToDateTime(item.LtDate).Date)
                                        {
                                            count = count + 1;
                                        }
                                }
                                break;
                            case Consts.RankQues.SLegalTowork:
                                count = caseSnpDetails.FindAll(u => u.LegalTowork.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SMartialStatus:
                                count = caseSnpDetails.FindAll(u => u.MaritalStatus.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SMemberCode:
                                count = caseSnpDetails.FindAll(u => u.MemberCode.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SNofcjob:
                                foreach (CaseSnpEntity snpNumeric in caseSnpDetails)
                                {
                                    if (snpNumeric.NumberOfcjobs != string.Empty)
                                        if (Convert.ToDecimal(snpNumeric.NumberOfcjobs) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(snpNumeric.NumberOfcjobs) <= Convert.ToDecimal(item.LtNum))
                                        {
                                            count = count + 1;
                                        }
                                }
                                break;
                            case Consts.RankQues.SNofljobs:
                                foreach (CaseSnpEntity snpNumeric in caseSnpDetails)
                                {
                                    if (snpNumeric.NumberofLvjobs != string.Empty)
                                        if (Convert.ToDecimal(snpNumeric.NumberofLvjobs) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(snpNumeric.NumberofLvjobs) <= Convert.ToDecimal(item.LtNum))
                                        {
                                            count = count + 1;
                                        }
                                }
                                break;
                            case Consts.RankQues.SPFrequency:
                                count = caseSnpDetails.FindAll(u => u.PayFrequency.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SPregnant:
                                count = caseSnpDetails.FindAll(u => u.Pregnant.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SPThours:
                                foreach (CaseSnpEntity snpNumeric in caseSnpDetails)
                                {
                                    if (snpNumeric.PartTimeHours != string.Empty)
                                        if (Convert.ToDecimal(snpNumeric.PartTimeHours) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(snpNumeric.PartTimeHours) <= Convert.ToDecimal(item.LtNum))
                                        {
                                            count = count + 1;
                                        }
                                }
                                break;
                            case Consts.RankQues.SRace:
                                count = caseSnpDetails.FindAll(u => u.Race.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SRelitran:
                                count = caseSnpDetails.FindAll(u => u.Relitran.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SResident:
                                count = caseSnpDetails.FindAll(u => u.Resident.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SRshift:
                                count = caseSnpDetails.FindAll(u => u.RShift.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SSEmploy:
                                count = caseSnpDetails.FindAll(u => u.SeasonalEmploy.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SSex:
                                count = caseSnpDetails.FindAll(u => u.Sex.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SSnpVet:
                                count = caseSnpDetails.FindAll(u => u.Vet.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SStatus:
                                count = caseSnpDetails.FindAll(u => u.Status.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.STranserv:
                                count = caseSnpDetails.FindAll(u => u.Transerv.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SworkLimit:
                                count = caseSnpDetails.FindAll(u => u.WorkLimit.Trim().Equals(item.RespCd)).Count;
                                break;

                        }

                        if (caseSnpDetails.Count == count)
                        {
                            commonHighcount.Add(new CommonEntity(item.Points,item.RespCd));
                           // intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                        }
                    }
                    else
                    {
                        switch (ResponceType)
                        {
                            case "D":
                            case "L":
                                foreach (CaseSnpEntity snpdropdown in caseSnpDetails)
                                {

                                    switch (FilterCode)
                                    {
                                        case Consts.RankQues.S1shift:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.IstShift.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespCd));
                                                //intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.S2ndshift:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.IIndShift.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespCd));
                                                //intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.S3rdShift:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.IIIrdShift.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespCd));
                                                //intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SSchoolDistrict:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.SchoolDistrict.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespCd));
                                                //intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SEducation:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Education.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespCd));
                                                //intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SWic:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Wic.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespCd));
                                                //intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SDisable:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Disable.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespCd));
                                                //intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SDrvlic:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Drvlic.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespCd));
                                                //intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SEmployed:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Employed.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespCd));
                                                //intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SEthinic:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Ethnic.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespCd));
                                                //intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SFarmer:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Farmer.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespCd));
                                                //intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SFoodStamps:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.FootStamps.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespCd));
                                                //intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.WorkStatus:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.WorkStatus.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespCd));
                                                //intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.DisconectYouth:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Youth.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespCd));
                                                //intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.MiltaryStatus:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.MilitaryStatus.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespCd));
                                                //intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.HealthCodes:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode)
                                            {
                                                int intRankSnpPoints = fillAlertHealthCodes(snpdropdown.Health_Codes.Trim(), RnkCrit2, FilterCode.Trim(), item.CountInd.Trim());
                                                //intRankPoint = intRankPoint + intRankSnpPoints;
                                                commonHighcount.Add(new CommonEntity(intRankSnpPoints.ToString(), item.RespCd));
                                                //intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                //strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SHealthIns:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.HealthIns.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespCd));
                                                //intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SjobCategory:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.JobCategory.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespCd));
                                                //intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SjobTitle:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.JobTitle.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespCd));
                                                //intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SLegalTowork:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.LegalTowork.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespCd));
                                                //intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SMartialStatus:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.MaritalStatus.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespCd));
                                                //intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SMemberCode:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.MemberCode.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespCd));
                                                //intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SPFrequency:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.PayFrequency.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespCd));
                                                //intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SPregnant:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Pregnant.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespCd));
                                                //intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SRace:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Race.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespCd));
                                                //intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SRelitran:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Relitran.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespCd));
                                                //intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SResident:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Resident.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespCd));
                                                //intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SRshift:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.RShift.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespCd));
                                                //intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SSEmploy:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.SeasonalEmploy.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespCd));
                                                //intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SSex:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Sex.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespCd));
                                                //intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SSnpVet:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Vet.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespCd));
                                                //intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SStatus:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Status.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespCd));
                                                //intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.STranserv:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Transerv.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespCd));
                                                //intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SworkLimit:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.WorkLimit.Trim())
                                            {
                                                commonHighcount.Add(new CommonEntity(item.Points, item.RespCd));
                                                //intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                    }
                                }
                                //if (listRelationstring.Contains(item.Relation))
                                //{
                                //    if (listCodestring.Contains(item.RespCd))
                                //    {
                                //        intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                //    }
                                //}
                                break;
                            case "N":
                            case "G":
                                foreach (CaseSnpEntity snpNumeric in caseSnpDetails)
                                {

                                    switch (FilterCode)
                                    {
                                        case Consts.RankQues.SAge:
                                            if (snpNumeric.AltBdate != string.Empty && item.Relation.Trim() == snpNumeric.MemberCode)
                                            {
                                                DateTime EndDate = GetEndDateAgeCalculation(item.AgeClcInd.Trim(), propMstRank);
                                                int AgeMonth = _model.lookupDataAccess.GetAgeCalculationMonths(Convert.ToDateTime(snpNumeric.AltBdate), EndDate);
                                                if (AgeMonth >= Convert.ToDecimal(item.GtNum) && AgeMonth <= Convert.ToDecimal(item.LtNum))
                                                {
                                                   // intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                    commonHighcount.Add(new CommonEntity(item.Points, item.RespCd));
                                                    
                                                }
                                                if (AgeMonth > 12)
                                                {
                                                    strResponceData = (AgeMonth / 12).ToString();
                                                }
                                            }
                                            break;

                                        case Consts.RankQues.SNofcjob:
                                            if (snpNumeric.NumberOfcjobs != string.Empty && item.Relation.Trim() == snpNumeric.MemberCode)
                                                if (Convert.ToDecimal(snpNumeric.NumberOfcjobs) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(snpNumeric.NumberOfcjobs) <= Convert.ToDecimal(item.LtNum))
                                                {                                                   
                                                    commonHighcount.Add(new CommonEntity(item.Points, item.RespCd));
                                                    //intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                }
                                            break;
                                        case Consts.RankQues.SNofljobs:
                                            if (snpNumeric.NumberofLvjobs != string.Empty && item.Relation.Trim() == snpNumeric.MemberCode)
                                                if (Convert.ToDecimal(snpNumeric.NumberofLvjobs) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(snpNumeric.NumberofLvjobs) <= Convert.ToDecimal(item.LtNum))
                                                {

                                                    commonHighcount.Add(new CommonEntity(item.Points, item.RespCd));
                                                    //intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                }
                                            break;
                                        case Consts.RankQues.SFThours:
                                            if (snpNumeric.FullTimeHours != string.Empty && item.Relation.Trim() == snpNumeric.MemberCode)
                                                if (Convert.ToDecimal(snpNumeric.FullTimeHours) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(snpNumeric.FullTimeHours) <= Convert.ToDecimal(item.LtNum))
                                                {

                                                    commonHighcount.Add(new CommonEntity(item.Points, item.RespCd));
                                                    //intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                }
                                            break;
                                        case Consts.RankQues.SPThours:
                                            if (snpNumeric.PartTimeHours != string.Empty && item.Relation.Trim() == snpNumeric.MemberCode)
                                                if (Convert.ToDecimal(snpNumeric.PartTimeHours) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(snpNumeric.PartTimeHours) <= Convert.ToDecimal(item.LtNum))
                                                {

                                                    commonHighcount.Add(new CommonEntity(item.Points, item.RespCd));
                                                    //intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                }
                                            break;
                                        case Consts.RankQues.SHourlyWage:
                                            if (snpNumeric.HourlyWage != string.Empty && item.Relation.Trim() == snpNumeric.MemberCode)
                                                if (Convert.ToDecimal(snpNumeric.HourlyWage) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(snpNumeric.HourlyWage) <= Convert.ToDecimal(item.LtNum))
                                                {

                                                    commonHighcount.Add(new CommonEntity(item.Points, item.RespCd));
                                                    //intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                }
                                            break;

                                    }
                                }
                                break;
                            case "B":
                            case "T":
                                foreach (CaseSnpEntity snpNumeric in caseSnpDetails)
                                {

                                    switch (FilterCode)
                                    {
                                        case Consts.RankQues.SAltBdate:
                                            if (snpNumeric.AltBdate != string.Empty && item.Relation.Trim() == snpNumeric.MemberCode)
                                                if (Convert.ToDateTime(snpNumeric.AltBdate).Date >= Convert.ToDateTime(item.GtDate).Date && Convert.ToDateTime(snpNumeric.AltBdate).Date <= Convert.ToDateTime(item.LtDate).Date)
                                                {

                                                    commonHighcount.Add(new CommonEntity(item.Points, item.RespCd));
                                                    //intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                }
                                            break;
                                        case Consts.RankQues.SExpireWorkDate:
                                            if (snpNumeric.ExpireWorkDate != string.Empty && item.Relation.Trim() == snpNumeric.MemberCode)
                                                if (Convert.ToDateTime(snpNumeric.ExpireWorkDate).Date >= Convert.ToDateTime(item.GtDate).Date && Convert.ToDateTime(snpNumeric.ExpireWorkDate).Date <= Convert.ToDateTime(item.LtDate).Date)
                                                {

                                                    commonHighcount.Add(new CommonEntity(item.Points, item.RespCd));
                                                    //intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                }
                                            break;
                                        case Consts.RankQues.SLastWorkDate:
                                            if (snpNumeric.LastWorkDate != string.Empty && item.Relation.Trim() == snpNumeric.MemberCode)
                                                if (Convert.ToDateTime(snpNumeric.LastWorkDate).Date >= Convert.ToDateTime(item.GtDate).Date && Convert.ToDateTime(snpNumeric.LastWorkDate).Date <= Convert.ToDateTime(item.LtDate).Date)
                                                {

                                                    commonHighcount.Add(new CommonEntity(item.Points, item.RespCd));
                                                    //intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                }
                                            break;
                                        case Consts.RankQues.SHireDate:
                                            if (snpNumeric.HireDate != string.Empty && item.Relation.Trim() == snpNumeric.MemberCode)
                                                if (Convert.ToDateTime(snpNumeric.HireDate).Date >= Convert.ToDateTime(item.GtDate).Date && Convert.ToDateTime(snpNumeric.HireDate).Date <= Convert.ToDateTime(item.LtDate).Date)
                                                {

                                                    commonHighcount.Add(new CommonEntity(item.Points,item.RespCd));
                                                }
                                            break;


                                    }
                                }
                                break;

                        }


                    }

                }
                //Lowest Points
                else if (item.CountInd.Trim() == "L")
                {
                    if (item.Relation == "*")
                    {
                        int count = 0;
                        switch (FilterCode)
                        {
                            case Consts.RankQues.S1shift:
                                count = caseSnpDetails.FindAll(u => u.IstShift.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.S2ndshift:
                                count = caseSnpDetails.FindAll(u => u.IIndShift.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.S3rdShift:
                                count = caseSnpDetails.FindAll(u => u.IIIrdShift.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SAge:
                                foreach (CaseSnpEntity snpDate in caseSnpDetails)
                                {
                                    if (snpDate.AltBdate != string.Empty)
                                    {
                                        DateTime EndDate = GetEndDateAgeCalculation(item.AgeClcInd.Trim(), propMstRank);
                                        int AgeMonth = _model.lookupDataAccess.GetAgeCalculationMonths(Convert.ToDateTime(snpDate.AltBdate), EndDate);
                                        if (AgeMonth >= Convert.ToDecimal(item.GtNum) && AgeMonth <= Convert.ToDecimal(item.LtNum))
                                        {
                                            count = count + 1;
                                        }
                                    }
                                }
                                break;
                            case Consts.RankQues.SAltBdate:
                                foreach (CaseSnpEntity snpDate in caseSnpDetails)
                                {
                                    if (snpDate.AltBdate != string.Empty)
                                        if (Convert.ToDateTime(snpDate.AltBdate).Date >= Convert.ToDateTime(item.GtDate).Date && Convert.ToDateTime(snpDate.AltBdate).Date <= Convert.ToDateTime(item.LtDate).Date)
                                        {
                                            count = count + 1;
                                        }
                                }

                                break;
                            case Consts.RankQues.SSchoolDistrict:
                                count = caseSnpDetails.FindAll(u => u.SchoolDistrict.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SEducation:
                                count = caseSnpDetails.FindAll(u => u.Education.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SWic:
                                count = caseSnpDetails.FindAll(u => u.Wic.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SDisable:
                                count = caseSnpDetails.FindAll(u => u.Disable.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SDrvlic:
                                count = caseSnpDetails.FindAll(u => u.Drvlic.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SEmployed:
                                count = caseSnpDetails.FindAll(u => u.Employed.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SEthinic:
                                count = caseSnpDetails.FindAll(u => u.Ethnic.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SExpireWorkDate:
                                foreach (CaseSnpEntity snpDate in caseSnpDetails)
                                {
                                    if (snpDate.ExpireWorkDate != string.Empty)
                                        if (Convert.ToDateTime(snpDate.ExpireWorkDate).Date >= Convert.ToDateTime(item.GtDate).Date && Convert.ToDateTime(snpDate.ExpireWorkDate).Date <= Convert.ToDateTime(item.LtDate).Date)
                                        {
                                            count = count + 1;
                                        }
                                }
                                break;
                            case Consts.RankQues.SFarmer:
                                count = caseSnpDetails.FindAll(u => u.Farmer.Trim().Equals(item.RespCd)).Count;
                                break;                           
                            case Consts.RankQues.SFoodStamps:
                                count = caseSnpDetails.FindAll(u => u.FootStamps.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.WorkStatus:
                                count = caseSnpDetails.FindAll(u => u.WorkStatus.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.DisconectYouth:
                                count = caseSnpDetails.FindAll(u => u.Youth.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.MiltaryStatus:
                                count = caseSnpDetails.FindAll(u => u.MilitaryStatus.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.HealthCodes:
                                foreach (CaseSnpEntity snpHealth in caseSnpDetails)
                                {
                                    if (!string.IsNullOrEmpty(snpHealth.Health_Codes.Trim()))
                                    {
                                        int intRankSnpPoints = fillAlertHealthCodes(snpHealth.Health_Codes.Trim(), RnkCrit2, FilterCode.Trim(), item.CountInd.Trim());
                                        HealthPoints = HealthPoints + intRankSnpPoints;
                                    }
                                    count = count + 1;
                                }
                                if (caseSnpDetails.Count == count)
                                {
                                    commonLowcount.Add(new CommonEntity(HealthPoints.ToString(), item.RespText));
                                    count++;
                                }
                                break;
                            case Consts.RankQues.SFThours:
                                foreach (CaseSnpEntity snpNumeric in caseSnpDetails)
                                {
                                    if (snpNumeric.FullTimeHours != string.Empty)
                                        if (Convert.ToDecimal(snpNumeric.FullTimeHours) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(snpNumeric.FullTimeHours) <= Convert.ToDecimal(item.LtNum))
                                        {
                                            count = count + 1;
                                        }
                                }
                                break;
                            case Consts.RankQues.SHealthIns:
                                count = caseSnpDetails.FindAll(u => u.HealthIns.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SHireDate:
                                foreach (CaseSnpEntity snpDate in caseSnpDetails)
                                {
                                    if (snpDate.HireDate != string.Empty)
                                        if (Convert.ToDateTime(snpDate.HireDate).Date >= Convert.ToDateTime(item.GtDate).Date && Convert.ToDateTime(snpDate.HireDate).Date <= Convert.ToDateTime(item.LtDate).Date)
                                        {
                                            count = count + 1;
                                        }
                                }
                                break;
                            case Consts.RankQues.SHourlyWage:
                                foreach (CaseSnpEntity snpNumeric in caseSnpDetails)
                                {
                                    if (snpNumeric.HourlyWage != string.Empty)
                                        if (Convert.ToDecimal(snpNumeric.HourlyWage) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(snpNumeric.HourlyWage) <= Convert.ToDecimal(item.LtNum))
                                        {
                                            count = count + 1;
                                        }
                                }
                                break;
                            case Consts.RankQues.SjobCategory:
                                count = caseSnpDetails.FindAll(u => u.JobCategory.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SjobTitle:
                                count = caseSnpDetails.FindAll(u => u.JobTitle.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SLastWorkDate:
                                foreach (CaseSnpEntity snpDate in caseSnpDetails)
                                {
                                    if (snpDate.LastWorkDate != string.Empty)
                                        if (Convert.ToDateTime(snpDate.LastWorkDate).Date >= Convert.ToDateTime(item.GtDate).Date && Convert.ToDateTime(snpDate.LastWorkDate).Date <= Convert.ToDateTime(item.LtDate).Date)
                                        {
                                            count = count + 1;
                                        }
                                }
                                break;
                            case Consts.RankQues.SLegalTowork:
                                count = caseSnpDetails.FindAll(u => u.LegalTowork.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SMartialStatus:
                                count = caseSnpDetails.FindAll(u => u.MaritalStatus.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SMemberCode:
                                count = caseSnpDetails.FindAll(u => u.MemberCode.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SNofcjob:
                                foreach (CaseSnpEntity snpNumeric in caseSnpDetails)
                                {
                                    if (snpNumeric.NumberOfcjobs != string.Empty)
                                        if (Convert.ToDecimal(snpNumeric.NumberOfcjobs) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(snpNumeric.NumberOfcjobs) <= Convert.ToDecimal(item.LtNum))
                                        {
                                            count = count + 1;
                                        }
                                }
                                break;
                            case Consts.RankQues.SNofljobs:
                                foreach (CaseSnpEntity snpNumeric in caseSnpDetails)
                                {
                                    if (snpNumeric.NumberofLvjobs != string.Empty)
                                        if (Convert.ToDecimal(snpNumeric.NumberofLvjobs) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(snpNumeric.NumberofLvjobs) <= Convert.ToDecimal(item.LtNum))
                                        {
                                            count = count + 1;
                                        }
                                }
                                break;
                            case Consts.RankQues.SPFrequency:
                                count = caseSnpDetails.FindAll(u => u.PayFrequency.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SPregnant:
                                count = caseSnpDetails.FindAll(u => u.Pregnant.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SPThours:
                                foreach (CaseSnpEntity snpNumeric in caseSnpDetails)
                                {
                                    if (snpNumeric.PartTimeHours != string.Empty)
                                        if (Convert.ToDecimal(snpNumeric.PartTimeHours) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(snpNumeric.PartTimeHours) <= Convert.ToDecimal(item.LtNum))
                                        {
                                            count = count + 1;
                                        }
                                }
                                break;
                            case Consts.RankQues.SRace:
                                count = caseSnpDetails.FindAll(u => u.Race.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SRelitran:
                                count = caseSnpDetails.FindAll(u => u.Relitran.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SResident:
                                count = caseSnpDetails.FindAll(u => u.Resident.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SRshift:
                                count = caseSnpDetails.FindAll(u => u.RShift.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SSEmploy:
                                count = caseSnpDetails.FindAll(u => u.SeasonalEmploy.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SSex:
                                count = caseSnpDetails.FindAll(u => u.Sex.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SSnpVet:
                                count = caseSnpDetails.FindAll(u => u.Vet.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SStatus:
                                count = caseSnpDetails.FindAll(u => u.Status.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.STranserv:
                                count = caseSnpDetails.FindAll(u => u.Transerv.Trim().Equals(item.RespCd)).Count;
                                break;
                            case Consts.RankQues.SworkLimit:
                                count = caseSnpDetails.FindAll(u => u.WorkLimit.Trim().Equals(item.RespCd)).Count;
                                break;

                        }

                        if (caseSnpDetails.Count == count)
                        {
                            commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                        }
                    }
                    else
                    {
                        switch (ResponceType)
                        {
                            case "D":
                            case "L":
                                foreach (CaseSnpEntity snpdropdown in caseSnpDetails)
                                {

                                    switch (FilterCode)
                                    {
                                        case Consts.RankQues.S1shift:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.IstShift.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.S2ndshift:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.IIndShift.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.S3rdShift:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.IIIrdShift.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SSchoolDistrict:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.SchoolDistrict.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SEducation:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Education.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SWic:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Wic.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SDisable:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Disable.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SDrvlic:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Drvlic.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SEmployed:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Employed.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SEthinic:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Ethnic.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SFarmer:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Farmer.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SFoodStamps:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.FootStamps.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.WorkStatus:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.WorkStatus.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));                                                
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.DisconectYouth:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Youth.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));                                                
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.MiltaryStatus:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.MilitaryStatus.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));                                               
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.HealthCodes:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode)
                                            {
                                                int intRankSnpPoints = fillAlertHealthCodes(snpdropdown.Health_Codes.Trim(), RnkCrit2, FilterCode.Trim(), item.CountInd.Trim());                                               
                                                commonLowcount.Add(new CommonEntity(intRankSnpPoints.ToString(), item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SHealthIns:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.HealthIns.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SjobCategory:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.JobCategory.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SjobTitle:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.JobTitle.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SLegalTowork:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.LegalTowork.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SMartialStatus:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.MaritalStatus.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SMemberCode:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.MemberCode.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SPFrequency:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.PayFrequency.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SPregnant:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Pregnant.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));                                               
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SRace:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Race.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                //intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SRelitran:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Relitran.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));                                              
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SResident:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Resident.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));                                               
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SRshift:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.RShift.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));                                               
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SSEmploy:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.SeasonalEmploy.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));                                               
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SSex:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Sex.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));                                               
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SSnpVet:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Vet.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));                                               
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SStatus:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Status.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));                                                
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.STranserv:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.Transerv.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));                                               
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                        case Consts.RankQues.SworkLimit:
                                            if (item.Relation.Trim() == snpdropdown.MemberCode && item.RespCd.Trim() == snpdropdown.WorkLimit.Trim())
                                            {
                                                commonLowcount.Add(new CommonEntity(item.Points, item.RespText));                                               
                                                strResponceData = item.RespCd.Trim();
                                            }
                                            break;
                                    }
                                }
                                //if (listRelationstring.Contains(item.Relation))
                                //{
                                //    if (listCodestring.Contains(item.RespCd))
                                //    {
                                //        intSnpPoints = intSnpPoints + Convert.ToInt32(item.Points);
                                //    }
                                //}
                                break;
                            case "N":
                            case "G":
                                foreach (CaseSnpEntity snpNumeric in caseSnpDetails)
                                {

                                    switch (FilterCode)
                                    {
                                        case Consts.RankQues.SAge:
                                            if (snpNumeric.AltBdate != string.Empty && item.Relation.Trim() == snpNumeric.MemberCode)
                                            {
                                                DateTime EndDate = GetEndDateAgeCalculation(item.AgeClcInd.Trim(), propMstRank);
                                                int AgeMonth = _model.lookupDataAccess.GetAgeCalculationMonths(Convert.ToDateTime(snpNumeric.AltBdate), EndDate);
                                                if (AgeMonth >= Convert.ToDecimal(item.GtNum) && AgeMonth <= Convert.ToDecimal(item.LtNum))
                                                {
                                                    
                                                    commonLowcount.Add(new CommonEntity(item.Points, item.RespText));

                                                }
                                                if (AgeMonth > 12)
                                                {
                                                    strResponceData = (AgeMonth / 12).ToString();
                                                }
                                            }
                                            break;

                                        case Consts.RankQues.SNofcjob:
                                            if (snpNumeric.NumberOfcjobs != string.Empty && item.Relation.Trim() == snpNumeric.MemberCode)
                                                if (Convert.ToDecimal(snpNumeric.NumberOfcjobs) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(snpNumeric.NumberOfcjobs) <= Convert.ToDecimal(item.LtNum))
                                                {
                                                    commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                    
                                                }
                                            break;
                                        case Consts.RankQues.SNofljobs:
                                            if (snpNumeric.NumberofLvjobs != string.Empty && item.Relation.Trim() == snpNumeric.MemberCode)
                                                if (Convert.ToDecimal(snpNumeric.NumberofLvjobs) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(snpNumeric.NumberofLvjobs) <= Convert.ToDecimal(item.LtNum))
                                                {

                                                    commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                    
                                                }
                                            break;
                                        case Consts.RankQues.SFThours:
                                            if (snpNumeric.FullTimeHours != string.Empty && item.Relation.Trim() == snpNumeric.MemberCode)
                                                if (Convert.ToDecimal(snpNumeric.FullTimeHours) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(snpNumeric.FullTimeHours) <= Convert.ToDecimal(item.LtNum))
                                                {

                                                    commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                    
                                                }
                                            break;
                                        case Consts.RankQues.SPThours:
                                            if (snpNumeric.PartTimeHours != string.Empty && item.Relation.Trim() == snpNumeric.MemberCode)
                                                if (Convert.ToDecimal(snpNumeric.PartTimeHours) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(snpNumeric.PartTimeHours) <= Convert.ToDecimal(item.LtNum))
                                                {

                                                    commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                    
                                                }
                                            break;
                                        case Consts.RankQues.SHourlyWage:
                                            if (snpNumeric.HourlyWage != string.Empty && item.Relation.Trim() == snpNumeric.MemberCode)
                                                if (Convert.ToDecimal(snpNumeric.HourlyWage) >= Convert.ToDecimal(item.GtNum) && Convert.ToDecimal(snpNumeric.HourlyWage) <= Convert.ToDecimal(item.LtNum))
                                                {

                                                    commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                    
                                                }
                                            break;

                                    }
                                }
                                break;
                            case "B":
                            case "T":
                                foreach (CaseSnpEntity snpNumeric in caseSnpDetails)
                                {

                                    switch (FilterCode)
                                    {
                                        case Consts.RankQues.SAltBdate:
                                            if (snpNumeric.AltBdate != string.Empty && item.Relation.Trim() == snpNumeric.MemberCode)
                                                if (Convert.ToDateTime(snpNumeric.AltBdate).Date >= Convert.ToDateTime(item.GtDate).Date && Convert.ToDateTime(snpNumeric.AltBdate).Date <= Convert.ToDateTime(item.LtDate).Date)
                                                {

                                                    commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                   
                                                }
                                            break;
                                        case Consts.RankQues.SExpireWorkDate:
                                            if (snpNumeric.ExpireWorkDate != string.Empty && item.Relation.Trim() == snpNumeric.MemberCode)
                                                if (Convert.ToDateTime(snpNumeric.ExpireWorkDate).Date >= Convert.ToDateTime(item.GtDate).Date && Convert.ToDateTime(snpNumeric.ExpireWorkDate).Date <= Convert.ToDateTime(item.LtDate).Date)
                                                {

                                                    commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                    
                                                }
                                            break;
                                        case Consts.RankQues.SLastWorkDate:
                                            if (snpNumeric.LastWorkDate != string.Empty && item.Relation.Trim() == snpNumeric.MemberCode)
                                                if (Convert.ToDateTime(snpNumeric.LastWorkDate).Date >= Convert.ToDateTime(item.GtDate).Date && Convert.ToDateTime(snpNumeric.LastWorkDate).Date <= Convert.ToDateTime(item.LtDate).Date)
                                                {

                                                    commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                    
                                                }
                                            break;
                                        case Consts.RankQues.SHireDate:
                                            if (snpNumeric.HireDate != string.Empty && item.Relation.Trim() == snpNumeric.MemberCode)
                                                if (Convert.ToDateTime(snpNumeric.HireDate).Date >= Convert.ToDateTime(item.GtDate).Date && Convert.ToDateTime(snpNumeric.HireDate).Date <= Convert.ToDateTime(item.LtDate).Date)
                                                {

                                                    commonLowcount.Add(new CommonEntity(item.Points, item.RespText));
                                                    
                                                }
                                            break;


                                    }
                                }
                                break;

                        }


                    }

                }


            }
            if (commonHighcount.Count > 0)
            {
                commonHighcount = commonHighcount.FindAll(u => u.Code.Trim() != string.Empty);
                commonHighcount = commonHighcount.OrderByDescending(u => Convert.ToInt16(u.Code)).ToList();
                if (commonHighcount.Count > 0)
                {
                    intSnpPoints = intSnpPoints + Convert.ToInt32(commonHighcount[0].Code);
                }
            }
            if (commonLowcount.Count > 0)
            {
                commonLowcount = commonLowcount.FindAll(u => u.Code.Trim() != string.Empty);
                commonLowcount = commonLowcount.OrderBy(u => Convert.ToInt16(u.Code)).ToList();
                if (commonLowcount.Count > 0)
                {
                    intSnpPoints = intSnpPoints + Convert.ToInt32(commonLowcount[0].Code);
                }
            }

            strResponseDesc = strResponceData;
            return intSnpPoints;
        }



        public DateTime GetEndDateAgeCalculation(string Type, CaseMstEntity caseMst)
        {
            DateTime EndDate = DateTime.Now.Date;
            if (Type == "T")
            {
                EndDate = DateTime.Now.Date;
            }
            else if (Type == "I")
            {
                EndDate = Convert.ToDateTime(caseMst.IntakeDate);
            }
            else if (Type == "K")
            {
                string strDate = DateTime.Now.Date.ToShortDateString();
                string strYear;
                List<ZipCodeEntity> zipCodeEntity = _model.ZipCodeAndAgency.GetZipCodeSearch(BaseForm.BaseCaseMstListEntity[0].Zip, string.Empty, string.Empty, string.Empty);
                ZipCodeEntity zipentity = zipCodeEntity.Find(u => u.Zcrzip.Trim().Equals(caseMst.Zip.Trim()));
                if (zipentity != null)
                {
                    if (zipentity.Zcrhssyear.Trim() == "2")
                    {
                        strYear = DateTime.Now.AddYears(1).Year.ToString();
                    }
                    else
                    {
                        strYear = DateTime.Now.Year.ToString();
                    }
                    strDate = zipentity.Zcrhssmo + "/" + zipentity.Zcrhssday + "/" + strYear;
                }
                EndDate = Convert.ToDateTime(strDate);
            }
            return EndDate;
        }


        public string GetSnpAgyTabDesc(RNKCRIT2Entity rnkQuesData, string strApplicationcode)
        {
            string strDesc = string.Empty;
            if (rnkQuesData.RankFldRespType == "D" || rnkQuesData.RankFldRespType == "L")
            {
                AGYTABSEntity agytab = propAgyTabsList.Find(u => u.Tabs_Type == rnkQuesData.RankAgyCode && u.Table_Code == strApplicationcode);
                if (agytab != null)
                    strDesc = agytab.Code_Desc.ToString();
                else
                    strDesc = strApplicationcode;
            }
            else
                strDesc = strApplicationcode;

            return strDesc;
        }



        #endregion
        string strRank1, strRank2, strRank3, strRank4, strRank5, strRank6;
        private void btnUpdateRanks_Click(object sender, EventArgs e)
        {
            strRank1 = "0"; strRank2 = "0"; strRank3 = "0"; strRank4 = "0"; strRank5 = "0"; strRank6 = "0";
            foreach (ListViewItem lstitem in listViewRanks.Items)
            {
                switch (lstitem.SubItems[5].Text.Trim())
                {
                    case "01":
                    case "1":
                        strRank1 = lstitem.SubItems[2].Text;
                        break;
                    case "02":
                    case "2":
                        strRank2 = lstitem.SubItems[2].Text;
                        break;
                    case "03":
                    case "3":
                        strRank3 = lstitem.SubItems[2].Text;
                        break;
                    case "04":
                    case "4":
                        strRank4 = lstitem.SubItems[2].Text;
                        break;
                    case "05":
                    case "5":
                        strRank5 = lstitem.SubItems[2].Text;
                        break;
                    case "06":
                    case "6":
                        strRank6 = lstitem.SubItems[2].Text;
                        break;
                }

            }
            StringBuilder strMstAppl = new StringBuilder();
            strMstAppl.Append("<Applicants>");
            strMstAppl.Append("<Details MSTApplDetails = \"" + BaseForm.BaseAgency + BaseForm.BaseDept + BaseForm.BaseProg + (BaseForm.BaseYear.Trim() == string.Empty ? "    " : BaseForm.BaseYear.Trim()) + BaseForm.BaseApplicationNo + "\" MST_RANK1 = \"" + strRank1 + "\" MST_RANK2 = \"" + strRank2 + "\" MST_RANK3 = \"" + strRank3 + "\" MST_RANK4 = \"" + strRank4 + "\" MST_RANK5 = \"" + strRank5 + "\" MST_RANK6 = \"" + strRank6 + "\"   />");
            strMstAppl.Append("</Applicants>");

            if (_model.CaseMstData.UpdateCaseMstRanks(strMstAppl.ToString(), "Single"))
            {
                this.Close();
            }
        }

    }
}