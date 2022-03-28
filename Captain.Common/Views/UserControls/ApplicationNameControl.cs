#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Captain.Common.Views.Forms.Base;
using Captain.Common.Model.Objects;
using Captain.Common.Model.Data;
using Captain.Common.Views.UserControls.Base;
using Captain.Common.Views.Forms;
using Captain.Common.Utilities;
using Captain.Common.Model.Parameters;

#endregion

namespace Captain.Common.Views.UserControls
{
    public partial class ApplicationNameControl : UserControl
    {
        private CaptainModel _model = null;
        public ApplicationNameControl(BaseForm baseForm)
        {
            InitializeComponent();
            _model = new CaptainModel();
            BaseForm = baseForm;
            try
            {
                Application = lblApplicationName;

            }
            catch
            {
            }
        }

        #region Public Properties

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]

        public Label Application { get; set; }

        public string Agency { get; set; }
        public string Dept { get; set; }
        public string Program { get; set; }
        public string Year { get; set; }
        public BaseForm BaseForm { get; set; }
        public string OldAppNo { get; set; }
        #endregion

        private void txtAppNo_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtAppNo.Text))
            {

                txtAppNo.Text = SetLeadingZeros(txtAppNo.Text);

                MainMenuControl mainmenuControl = BaseForm.GetBaseUserControl() as MainMenuControl;
                if (mainmenuControl != null)
                {
                    mainmenuControl.TxtAppNo.Text = txtAppNo.Text;
                    mainmenuControl.TxtAppNo_LostFocus(sender, e);
                    if (BaseForm.BaseApplicationNo == string.Empty)
                    {
                        txtAppNo.Text = string.Empty;
                    }
                    //mainmenuControl.BtnSearchApp_Click(BtnSearchApp, EventArgs.Empty);

                    //ShowHierachyandApplNo(BaseForm.BaseAgency, BaseForm.BaseDept, BaseForm.BaseProg, BaseForm.BaseYear, txtAppNo.Text, "Display");

                }
                else
                {
                    DataSet ds = Captain.DatabaseLayer.MainMenu.MainMenuSearch("APP", "ALL", null, null, txtAppNo.Text, null, null, null, null, null, null, null, null, null, null, BaseForm.BaseAgency + BaseForm.BaseDept + BaseForm.BaseProg + BaseForm.BaseYear, null, BaseForm.UserID, string.Empty, string.Empty);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (txtAppNo.Text != BaseForm.BaseApplicationNo)
                        {
                            ShowHierachyandApplNo(BaseForm.BaseAgency, BaseForm.BaseDept, BaseForm.BaseProg, BaseForm.BaseYear, txtAppNo.Text, "Display");
                            NavigationLoading(string.Empty);
                        }
                        else
                        {
                            if (BaseForm.BaseTopApplSelect == "N")
                            {
                                ShowHierachyandApplNo(BaseForm.BaseAgency, BaseForm.BaseDept, BaseForm.BaseProg, BaseForm.BaseYear, txtAppNo.Text, "Display");
                                NavigationLoading(string.Empty);
                            }
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(txtAppNo.Text.Trim()))
                        {
                            MessageBox.Show("App# : " + txtAppNo.Text + " Does Not Exist", "CAPSystems", MessageBoxButtons.OK);
                            txtAppNo.Text = BaseForm.BaseApplicationNo;
                        }

                    }
                }
                // btnAdvance.Focus();
            }
        }

        private string SetLeadingZeros(string TmpSeq)
        {
            int Seq_len = TmpSeq.Trim().Length;
            string TmpCode = null;
            TmpCode = TmpSeq.ToString().Trim();
            switch (Seq_len)
            {
                case 7: TmpCode = "0" + TmpCode; break;
                case 6: TmpCode = "00" + TmpCode; break;
                case 5: TmpCode = "000" + TmpCode; break;
                case 4: TmpCode = "0000" + TmpCode; break;
                case 3: TmpCode = "00000" + TmpCode; break;
                case 2: TmpCode = "000000" + TmpCode; break;
                case 1: TmpCode = "0000000" + TmpCode; break;
                    //default: MessageBox.Show("Table Code should not be blank", "CAP Systems", MessageBoxButtons.OK);  TxtCode.Focus();
                    //    break;
            }
            return (TmpCode);
        }

        public void ShowHierachyandApplNo(string strAgency, string strDept, string strProg, string strYear1, string strApplicationNo, string strDisplay)
        {

            CaseMstEntity caseMstEntity = null;
            List<CaseSnpEntity> caseSnpEntity = null;
            string strYear = strYear1;
            string strApplNo = strApplicationNo;

            if (string.IsNullOrEmpty(strYear))
                strYear = "    ";

            string strAgencyName = strAgency + " - " + _model.lookupDataAccess.GetHierachyDescription("1", strAgency, strDept, strProg);
            string strDeptName = strDept + " - " + _model.lookupDataAccess.GetHierachyDescription("2", strAgency, strDept, strProg);
            string strProgName = strProg + " - " + _model.lookupDataAccess.GetHierachyDescription("3", strAgency, strDept, strProg);

            caseMstEntity = _model.CaseMstData.GetCaseMST(strAgency, strDept, strProg, strYear1, strApplNo);
            if (caseMstEntity != null)
            {
                strApplNo = caseMstEntity.ApplNo;
                strYear = caseMstEntity.ApplYr;
                BaseForm.BaseApplicationNo = strApplNo;
                caseSnpEntity = _model.CaseMstData.GetCaseSnpadpyn(strAgency, strDept, strProg, strYear, strApplNo);

                BaseForm.GetApplicantDetails(caseMstEntity, caseSnpEntity, strAgencyName, strDeptName, strProgName, strYear.ToString(), string.Empty, strDisplay);
                if (strDisplay == "Display")
                    BaseForm.BaseTopApplSelect = "Y";
            }
            else
            {
                if (!string.IsNullOrEmpty(txtAppNo.Text.Trim()))
                {
                    MessageBox.Show("App# : " + txtAppNo.Text + " Does Not Exist", "CAPSystems", MessageBoxButtons.OK);
                    txtAppNo.Clear();
                }
                if (BaseForm.BaseTopApplSelect == "Y")
                    txtAppNo.Text = BaseForm.BaseApplicationNo;
            }

        }


        private void Navigation_Click(object sender, EventArgs e)
        {
            string Navigation_Option = string.Empty;
            bool Rec_Exists = false;
            if (sender == Btn_First)
                Navigation_Option = "First";
            else if (sender == BtnP10)
                Navigation_Option = "RR";
            else if (sender == BtnNxt)
            {
                if (BaseForm.BaseTopApplSelect == "N")
                    Navigation_Option = "First";
                else
                    Navigation_Option = "Next";
            }
            else if (sender == BtnPrev)
                if (BaseForm.BaseTopApplSelect == "N")
                    Navigation_Option = "First";
                else
                    Navigation_Option = "Previous";
            else if (sender == BtnN10)
                Navigation_Option = "FF";
            else if (sender == BtnLast)
                Navigation_Option = "Last";


            DataSet ds = Captain.DatabaseLayer.MainMenu.MainMenu_Navigate_App(BaseForm.UserID, Navigation_Option,
                                                        BaseForm.BaseAgency + BaseForm.BaseDept + BaseForm.BaseProg + BaseForm.BaseYear, BaseForm.BaseApplicationNo);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Rec_Exists = true;
                    txtAppNo.Text = ds.Tables[0].Rows[0]["MST_APP_NO"].ToString();
                    MainMenuControl mainmenuControl = BaseForm.GetBaseUserControl() as MainMenuControl;
                    if (mainmenuControl != null)
                    {
                        mainmenuControl.TxtAppNo.Text = txtAppNo.Text;
                        mainmenuControl.TxtAppNo_LostFocus(sender, e);
                    }
                    else
                    {
                        ShowHierachyandApplNo(BaseForm.BaseAgency, BaseForm.BaseDept, BaseForm.BaseProg, BaseForm.BaseYear, txtAppNo.Text, "Display");
                        NavigationLoading(string.Empty);
                        BaseForm.BaseTopApplSelect = "Y";
                    }
                }
            }

            if (!Rec_Exists)
            {
                string Error_Msg = string.Empty;
                switch (Navigation_Option)
                {
                    case "First":
                    case "RR":
                    case "Previous": Error_Msg = "You are Already at the First Record"; break;

                    case "Next":
                    case "FF":
                    case "Last": Error_Msg = "You are Already at the Last Record"; break;
                }
                MessageBox.Show(Error_Msg, "CAP Systems");
            }
        }

        private void NavigationLoading(string strMainmenu)
        {
            BaseUserControl baseUserControl = BaseForm.GetBaseUserControl();
            if (baseUserControl != null)
            {
                if (strMainmenu != string.Empty)
                {
                    if (baseUserControl is MainMenuControl)
                    {
                        (baseUserControl as MainMenuControl).RefreshClearControl();
                    }
                }
                //if (baseUserControl is ClientIntakeControl)
                //{
                //    (baseUserControl as ClientIntakeControl).Refresh();
                //}
                //if (baseUserControl is Case3001Control)
                //{
                //    (baseUserControl as Case3001Control).Refresh();
                //}
                //if (baseUserControl is TMS00100)
                //{
                //    (baseUserControl as TMS00100).Refresh();
                //}
                //if (baseUserControl is TMS00300Control)
                //{
                //    (baseUserControl as TMS00300Control).Refresh();
                //}
                //if (baseUserControl is TMS00310Control)
                //{
                //    (baseUserControl as TMS00310Control).Refresh();
                //}

                //if (baseUserControl is CASE4006Control)
                //    (baseUserControl as CASE4006Control).Refresh();

                //if (baseUserControl is CaseSumControl)
                //{
                //    (baseUserControl as CaseSumControl).RefreshFormGrid();
                //}
                //if (baseUserControl is MAT00003Control)
                //{
                //    (baseUserControl as MAT00003Control).RefreshForm();
                //}
                //if (baseUserControl is HSS00134Control)
                //{
                //    (baseUserControl as HSS00134Control).Refresh();
                //}
                //if (baseUserControl is HSS00137Control)
                //{
                //    (baseUserControl as HSS00137Control).RefreshHss00137Form();
                //}
                //if (baseUserControl is HLS00134Control)
                //{
                //    (baseUserControl as HLS00134Control).Refresh();
                //}
                //if (baseUserControl is ARS20120)
                //{
                //    (baseUserControl as ARS20120).Refresh();
                //}
                //if (baseUserControl is Ars20130Control)
                //{
                //    (baseUserControl as Ars20130Control).Refresh();
                //}
                //if (baseUserControl is EMS00010Control)
                //{
                //    (baseUserControl as EMS00010Control).Refresh();
                //}
                //if (baseUserControl is EMS00020Control)
                //{
                //    (baseUserControl as EMS00020Control).Refresh();
                //}
                //if (baseUserControl is EMS00040Control)
                //{
                //    (baseUserControl as EMS00040Control).Refresh();
                //}

                //if (baseUserControl is TMS00081_Control)
                //    (baseUserControl as TMS00081_Control).Refresh();

                //if (baseUserControl is PIR20001Control)
                //    (baseUserControl as PIR20001Control).Refresh();

                //if (baseUserControl is TMSB0030_ABCcalcControl)
                //    (baseUserControl as TMSB0030_ABCcalcControl).Refresh();

                //if (baseUserControl is ProgramDefinition)
                //    (baseUserControl as ProgramDefinition).RefreshMaindata();

                
                if (baseUserControl is Case3001Control)
                {
                    (baseUserControl as Case3001Control).Refresh();
                }

            }
        }

        private void btnAdvance_Click(object sender, EventArgs e)
        {
            // Adv_search = true;
            BaseForm.BasePIPDragSwitch = "N";
            //AdvancedMainMenuSearch advancedMainMenuSearch = new AdvancedMainMenuSearch(BaseForm, true, true);
            //advancedMainMenuSearch.FormClosed += new Form.FormClosedEventHandler(On_ADV_SerachFormClosed);
            //advancedMainMenuSearch.ShowDialog();
        }

        //private void On_ADV_SerachFormClosed(object sender, FormClosedEventArgs e)
        //{
        //    AdvancedMainMenuSearch form = sender as AdvancedMainMenuSearch;
        //    if (form.DialogResult == DialogResult.OK)
        //    {
        //        if (BaseForm.BasePIPDragSwitch == "Y")
        //        {
        //            BaseForm.BaseTopApplSelect = "Y";
        //            BaseUserControl baseUserControl = BaseForm.GetBaseUserControl();
        //            if (baseUserControl != null)
        //            {
        //                if (baseUserControl is MainMenuControl)
        //                {
        //                    MainMenuControl mainmenuControl = BaseForm.GetBaseUserControl() as MainMenuControl;
        //                    if (mainmenuControl != null)
        //                    {
        //                        mainmenuControl.TxtAppNo.Text = BaseForm.BaseApplicationNo;
        //                        mainmenuControl.TxtAppNo_LostFocus(sender, e);
        //                    }
                            
        //                }
        //                else
        //                {
        //                    ShowHierachyandApplNo(BaseForm.BaseAgency, BaseForm.BaseDept, BaseForm.BaseProg, BaseForm.BaseYear, BaseForm.BaseApplicationNo, "Display");
        //                    NavigationLoading(string.Empty);
        //                }
        //            }
                    
        //        }
        //        else
        //        {
        //            Btn_First.Visible = BtnP10.Visible = BtnPrev.Visible =
        //                  BtnNxt.Visible = BtnN10.Visible = BtnLast.Visible = true;
        //            string Selected_App_key = null, BaseForm_Priv_Hierarchy = null;
        //            //                BaseForm_Priv_Hierarchy = BaseForm.BaseAgency + BaseForm.BaseDept + BaseForm.BaseProg;

        //            setTreeviewhierachy(BaseForm.BusinessModuleID);
        //            BaseForm_Priv_Hierarchy = BaseForm.BaseAgency + BaseForm.BaseDept + BaseForm.BaseProg + BaseForm.BaseYear;
        //            Selected_App_key = form.GetSelectedApplicant();
        //            if (!string.IsNullOrEmpty(Selected_App_key))
        //            {


        //                //if (BaseForm_Priv_Hierarchy.Trim() != Selected_App_key.Substring(0, 6))
        //                if (BaseForm_Priv_Hierarchy.Trim() != Selected_App_key.Substring(0, 10).Trim())
        //                {
        //                    BaseForm.BaseAgency = Selected_App_key.Substring(0, 2);
        //                    BaseForm.BaseDept = Selected_App_key.Substring(2, 2);
        //                    BaseForm.BaseProg = Selected_App_key.Substring(4, 2);
        //                    BaseForm.BaseYear = Selected_App_key.Substring(6, 4);
        //                    BaseForm.RefreshNavigationTabs(Selected_App_key.Substring(0, 2) + Selected_App_key.Substring(2, 2) + Selected_App_key.Substring(4, 2));
        //                }
        //                else
        //                {
        //                    if (BaseForm.BaseTopApplSelect == "Y")
        //                    {
        //                        if ((Selected_App_key.Length > 10))
        //                        {
        //                            if (BaseForm.BaseApplicationNo == Selected_App_key.Substring(10, 8))
        //                                Selected_App_key = BaseForm.BaseAgency + BaseForm.BaseDept + BaseForm.BaseProg + BaseForm.BaseYear + BaseForm.BaseApplicationNo;
        //                        }
        //                        else
        //                        {
        //                            Selected_App_key = BaseForm.BaseAgency + BaseForm.BaseDept + BaseForm.BaseProg + BaseForm.BaseYear + BaseForm.BaseApplicationNo;
        //                        }
        //                    }
        //                }

        //                BaseForm.BaseTopApplSelect = "N";
        //                txtAppNo.Clear();

        //                if (Selected_App_key.Length > 10)
        //                {
        //                    BaseForm.BaseTopApplSelect = "Y";

        //                    BaseUserControl baseUserControl = BaseForm.GetBaseUserControl();
        //                    if (baseUserControl != null)
        //                    {
        //                        if (baseUserControl is MainMenuControl)
        //                        {
        //                            MainMenuControl mainmenuControl = BaseForm.GetBaseUserControl() as MainMenuControl;
        //                            if (mainmenuControl != null)
        //                            {
        //                                mainmenuControl.TxtAppNo.Text = Selected_App_key.Substring(10, 8);
        //                                mainmenuControl.TxtAppNo_LostFocus(sender, e);
        //                            }
        //                        }
        //                        else
        //                        {
        //                            ShowHierachyandApplNo(Selected_App_key.Substring(0, 2), Selected_App_key.Substring(2, 2), Selected_App_key.Substring(4, 2), Selected_App_key.Substring(6, 4), Selected_App_key.Substring(10, 8), "Display");
        //                            NavigationLoading(string.Empty);
        //                        }
        //                    }

        //                }
        //                else
        //                {
        //                    // BaseForm.GetBaseUserControlMainMenu();
        //                    ShowHierachyandApplNo(Selected_App_key.Substring(0, 2), Selected_App_key.Substring(2, 2), Selected_App_key.Substring(4, 2), Selected_App_key.Substring(6, 4), string.Empty, string.Empty);

        //                    //BaseUserControl baseUserControl = BaseForm.GetBaseUserControlMainMenu();
        //                    //if (baseUserControl is MainMenuControl)
        //                    //{
        //                    //    (baseUserControl as MainMenuControl).RefreshClearControl();
        //                    //}

        //                    NavigationLoading("Mainmenu");

        //                }

        //                if (BaseForm.BaseTopApplSelect == "Y" || !string.IsNullOrEmpty(BaseForm.BaseApplicationNo.Trim()))
        //                {

        //                    Btn_First.Visible = BtnP10.Visible = BtnPrev.Visible =
        //                    BtnNxt.Visible = BtnN10.Visible = BtnLast.Visible = true;
        //                }
        //                else
        //                {
        //                    Btn_First.Visible = BtnP10.Visible = BtnPrev.Visible =
        //                      BtnNxt.Visible = BtnN10.Visible = BtnLast.Visible = false;
        //                }
        //            }
        //        }
        //    }


        //}

        string strkeyApp = string.Empty;
        private void txtAppNo_EnterKeyDown(object objSender, KeyEventArgs objArgs)
        {

            txtAppNo_LostFocus(txtAppNo, EventArgs.Empty);

        }
        private void setTreeviewhierachy(string BusinessModuleID)
        {
            switch (BusinessModuleID)
            {
                case Consts.Applications.Code.Administration:
                    InitializeModule("MiddleBanner.gif", TreeType.Administration);
                    break;
                case Consts.Applications.Code.HeadStart:
                    InitializeModule("MiddleBanner.gif", TreeType.HeadStart);
                    break;
                case Consts.Applications.Code.CaseManagement:
                    InitializeModule("MiddleBanner.gif", TreeType.CaseManagement);
                    break;
                case Consts.Applications.Code.EnergyRI:
                    InitializeModule("MiddleBanner.gif", TreeType.EnergyRI);
                    break;
                case Consts.Applications.Code.EnergyCT:
                    InitializeModule("MiddleBanner.gif", TreeType.EnergyCT);
                    break;
                case Consts.Applications.Code.EmergencyAssistance:
                    InitializeModule("MiddleBanner.gif", TreeType.EmergencyAssistance);
                    break;
                case Consts.Applications.Code.AccountsReceivable:
                    InitializeModule("MiddleBanner.gif", TreeType.AccountsReceivable);
                    break;
                case Consts.Applications.Code.HousingWeatherization:
                    InitializeModule("MiddleBanner.gif", TreeType.HousingWeatherization);
                    break;
                case Consts.Applications.Code.DashBoard:
                    InitializeModule("MiddleBanner.gif", TreeType.DashBoard);
                    break;
                case Consts.Applications.Code.HealthyStart:
                    InitializeModule("MiddleBanner.gif", TreeType.HealthyStart);
                    break;
            }
        }

        private void InitializeModule(string headerTitleImage, TreeType treeViewType)
        {
            TreeViewControllerParameter treeViewControllerParameter = null;

            // pnlApplicationHeaderImage.BackgroundImage = new ImageResourceHandle(headerTitleImage);
            //  pnlApplicationHeaderImage.Width = 30;
            BaseForm.NavigationTreeView.Nodes.Clear();
            string HIE = HIE = BaseForm.BaseAgency + BaseForm.BaseDept + BaseForm.BaseProg; ;


            treeViewControllerParameter = new TreeViewControllerParameter()
            {
                TreeType = treeViewType,
                TreeView = BaseForm.NavigationTreeView,
                Hierarchy = HIE
            };

            BaseForm.TreeViewController.Initialize(treeViewControllerParameter);
        }

    }
}