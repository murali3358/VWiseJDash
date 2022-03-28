/****************************************************************************************
 * Class Name   : MainForm
 * Author       : Chitti
 * Created Date : 
 * Version      : 
 * Description  : The applications main presentation layer.
 ****************************************************************************************/

#region Using

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.SessionState;
using System.Xml;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms;
using Captain.Common.Controllers;
using Captain.Common.Exceptions;
using Captain.Common.Handlers;
using Captain.Common.Menus;
using Captain.Common.Model.Data;
using Captain.Common.Model.Objects;
using Captain.Common.Model.Parameters;
using Captain.Common.Model.CaptainFaults;
using Captain.Common.Resources;
using Captain.Common.Utilities;
using Captain.Common.Views.Controls;
using Captain.Common.Views.Forms;
using Captain.Common.Views.Forms.Base;
using Captain.Common.Views.UserControls;
using Captain.Common.Views.UserControls.Base;
using System.ComponentModel;
using System.Collections.Specialized;

#endregion

namespace Captain
{
    public partial class MainForm : BaseForm
    {
        #region Variables

        // Private variables
        private Panel _fullScreenPanel = null;
        private XmlDocument _xmlDocument = null;
        private TreeNode _selectedTreeNode;
        private string _simpleFooterDisplay = string.Empty;
        private bool _isPDFEditorInitialized = false;
        private string _uploadedFileType = string.Empty;
        private PrivilegeEntity _privilegeEntity = null;
        private string _lastGuid = string.Empty;
        private CaptainModel _model = null;
        public HierachyNameControl hierachyNamecontrol = new HierachyNameControl();
        public ApplicationNameControl applicationNameControl;

        //public ApplicationDetailsControl applicationDetailsControl ;
        public List<TagClass> RequestedDownloadTagClassList = new List<TagClass>();
        private bool _defaultHierchyform = false;

        #endregion

        #region Contructor and Initialization

        public MainForm()
        {
            InitializeComponent();

            try
            {
                //Application.ThreadException += new ThreadExceptionEventHandler(OnApplicationThreadException);

                MenuManager = new MenuManager(this);

                Initialize();
                applicationNameControl = new ApplicationNameControl(this);
                
                _model = new CaptainModel();
                BaseAgency = UserProfile.Agency;
                BaseDept = UserProfile.Dept;
                BaseProg = UserProfile.Prog;
                //List<ChldTrckEntity> chldtrackList = new List<ChldTrckEntity>();
                //BaseTaskEntity = chldtrackList;
                //List<HlsTrckEntity> hlstrackList = new List<HlsTrckEntity>();
                //BaseHlsTaskEntity = hlstrackList;
                BaseFilterYear = "3";
                BaseYear = "    ";
                BaseComponent = string.Empty;
                ProgramDefinitionEntity programEntity = _model.HierarchyAndPrograms.GetCaseDepadp(BaseAgency, BaseDept, BaseProg);
                if (programEntity != null)
                {
                    BaseYear = programEntity.DepYear.Trim() == string.Empty ? "    " : programEntity.DepYear;
                }
                BaseAgencyControlDetails = _model.ZipCodeAndAgency.GetAgencyControlFile("00");
                BaseAgyTabsEntity = _model.lookupDataAccess.GetAgyTabs(string.Empty, string.Empty, string.Empty);
                BaseAgencyuserHierarchys = _model.UserProfileAccess.GetUserHierarchyByID(UserID);
                BaseCaseHierachyListEntity = _model.HierarchyAndPrograms.GetCaseHierachyAllData("**", "**", "**");
                if (BaseAgencyuserHierarchys.Count > 0)
                {
                    if (BaseAgencyControlDetails.SiteSecurity == "1")
                    {
                        List<HierarchyEntity> userHierarchy = BaseAgencyuserHierarchys.FindAll(u => u.Sites != string.Empty);
                        if (userHierarchy.Count > 0)
                        {
                            BaseAgencyControlDetails.SitesData = "1";
                        }

                    }
                }
                BasePIPDragSwitch = "N";
                DataBaseConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CMMS"].ConnectionString.ToString();
                if (System.Configuration.ConfigurationManager.ConnectionStrings["LEANINTAKEConnection"] != null)
                    BaseLeanDataBaseConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["LEANINTAKEConnection"].ConnectionString.ToString();
                List<TabPage> tabList = new List<TabPage>();
                tabList.Add(tabAdministration);
                tabList.Add(tabHeadStart);
                tabList.Add(tabCaseManagement);
                tabList.Add(tabEnergyRI);
                tabList.Add(tabEnergyCT);
                tabList.Add(tabEmergencyAssistance);
                tabList.Add(tabAccountsReceivable);
                tabList.Add(tabHousingWeatherization);
                tabList.Add(tabDashBoard);
                tabList.Add(tabHealthyStart);
                tabList.Add(tabAgencypartner);
                tabAdministration.Tag = Consts.Applications.Code.Administration;
                tabCaseManagement.Tag = Consts.Applications.Code.CaseManagement;
                tabHeadStart.Tag = Consts.Applications.Code.HeadStart;
                tabEnergyRI.Tag = Consts.Applications.Code.EnergyRI;
                tabEnergyCT.Tag = Consts.Applications.Code.EnergyCT;
                tabEmergencyAssistance.Tag = Consts.Applications.Code.EmergencyAssistance;
                tabHousingWeatherization.Tag = Consts.Applications.Code.HousingWeatherization;
                tabAccountsReceivable.Tag = Consts.Applications.Code.AccountsReceivable;
                tabDashBoard.Tag = Consts.Applications.Code.DashBoard;
                tabHealthyStart.Tag = Consts.Applications.Code.HealthyStart;
                tabAgencypartner.Tag = Consts.Applications.Code.AgencyPartner;
                List<PrivilegeEntity> NavigationPrivileges = _model.UserProfileAccess.GetApplicationsByUserID(UserID, string.Empty);

                this.NavigationTabs.Controls.Clear();
                //if (NavigationPrivileges.Count == 0)
                //{
                //    MessageBox.Show("You don't have Privileges Please Contact System Administrator."); //, Consts.Common.ApplicationCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}
                foreach (TabPage tabPage in tabList)
                {
                    if (NavigationPrivileges.Exists(u => u.ModuleCode.Equals(tabPage.Tag as string)))
                    {
                        this.NavigationTabs.Controls.Add(tabPage);
                    }
                }
                tabList.Clear();
                tabList = null;
                NavigationTabs.SelectedIndexChanged -= OnNavigationTabsSelectedIndexChanged;
                NavigationTabs.SelectedIndexChanged += OnNavigationTabsSelectedIndexChanged;
                if (NavigationTabs.TabPages.Count > 0)
                {
                    NavigationTabs.SelectedIndex = 0;
                    OnNavigationTabsSelectedIndexChanged(NavigationTabs, new EventArgs());
                }
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogAndDisplayMessageToUser(new StackFrame(true), ex, QuantumFaults.None, ExceptionSeverityLevel.High);
            }
        }

        private void Initialize()
        {
            base.ObjectType = Consts.Common.MainForm;
            string messagesName = string.Empty;
            try
            {

                AddWelcomeScreen(pnlTabs);

                CaptainResourceManager.Culture = CommonFunctions.GetBrowserCulture(Context.HttpContext);
                Init();

                //GenerateMenus(ref mainMenu, string.Empty);
                //pnlMainMenu.Controls.Add(mainMenu);

                //mainMenu.Dock = DockStyle.Top;
                //mainMenu.Update();
                MainToolbar.Visible = true;
                this.lblLogout.Cursor = Cursors.Hand;
                this.lblLogout.Visible = true;
                this.lblHelp.Cursor = Cursors.Hand;
                this.lblChangePassword.Cursor = Cursors.Hand;

                OnNavigationTabsSelectedIndexChanged(this, EventArgs.Empty);
                NavigationTabs.Visible = true;
            }
            catch (Exception ex)
            {
                StackFrame stackFrame = new StackFrame();
                //ExceptionLogger.LogAndDisplayMessageToUser(stackFrame, ex, QuantumFaults.None, ExceptionSeverityLevel.High);
            }
        }

        private void CaptainLogoBanner(bool isEnabled)
        {
            IsCaptainBannerDisplayed = isEnabled;
            pnlBanner.Visible = isEnabled;
            pnlBanner.Update();
            pnlSmallBanner.Visible = !isEnabled;
            pnlSmallBanner.Update();
            pnlSmallBannerLogo.Visible = !isEnabled;
            pnlSmallBannerLogo.Update();

            BaseUserControl baseUserControl = GetBaseUserControl();

        }

        public override void SetLogoBanner()
        {
            CaptainLogoBanner(true);
        }

        private void Init()
        {
            lblHelp.Text = CaptainResourceManager.GetControlString(Consts.Controls.HelpLabel);
            lblLogout.Text = CaptainResourceManager.GetControlString(Consts.Controls.LogoutLabel);
            tabWelcome.Text = CaptainResourceManager.GetControlString("Welcome");

        }

        #endregion

        #region Public / Protected Methods

        public override void RefreshNavigationTabs(string HIE)
        {
            NavigationTabs.SelectedIndexChanged -= OnNavigationTabsSelectedIndexChanged;
            string previousTab = BusinessModuleID;
            List<TabPage> tabList = new List<TabPage>();
            tabList.Add(tabAdministration);
            tabList.Add(tabHeadStart);
            tabList.Add(tabCaseManagement);
            tabList.Add(tabEnergyRI);
            tabList.Add(tabEnergyCT);
            tabList.Add(tabEmergencyAssistance);
            tabList.Add(tabAccountsReceivable);
            tabList.Add(tabHousingWeatherization);
            tabList.Add(tabDashBoard);
            tabList.Add(tabHealthyStart);
            tabList.Add(tabAgencypartner);

            tabAdministration.Tag = Consts.Applications.Code.Administration;
            tabCaseManagement.Tag = Consts.Applications.Code.CaseManagement;
            tabHeadStart.Tag = Consts.Applications.Code.HeadStart;
            tabEnergyRI.Tag = Consts.Applications.Code.EnergyRI;
            tabEnergyCT.Tag = Consts.Applications.Code.EnergyCT;
            tabEmergencyAssistance.Tag = Consts.Applications.Code.EmergencyAssistance;
            tabHousingWeatherization.Tag = Consts.Applications.Code.HousingWeatherization;
            tabAccountsReceivable.Tag = Consts.Applications.Code.AccountsReceivable;
            tabDashBoard.Tag = Consts.Applications.Code.DashBoard;
            tabHealthyStart.Tag = Consts.Applications.Code.HealthyStart;
            tabAgencypartner.Tag = Consts.Applications.Code.AgencyPartner;
            _model = new CaptainModel();

            //BaseAgency = HIE.Substring(0, 2);    we need to  add this yeswanth
            //BaseDept = HIE.Substring(2, 2);
            //BaseProg = HIE.Substring(4, 2);

            List<PrivilegeEntity> NavigationPrivileges = _model.UserProfileAccess.GetApplicationsByUserID(UserID, HIE);

            this.NavigationTabs.Controls.Clear();
            foreach (TabPage tabPage in tabList)
            {
                if (NavigationPrivileges.Exists(u => u.ModuleCode.Equals(tabPage.Tag as string)))
                {
                    this.NavigationTabs.Controls.Add(tabPage);
                }
            }
            tabList.Clear();
            tabList = null;

            NavigationTabs.SelectedIndexChanged += OnNavigationTabsSelectedIndexChanged;
            int index = 0;
            bool flag = false;
            foreach (TabPage tabPage in NavigationTabs.TabPages)
            {
                if ((tabPage.Tag as string).Equals(previousTab))
                {
                    NavigationTabs.SelectedIndex = index;
                    flag = true;
                    break;
                }
                index++;
            }
            if (NavigationTabs.TabPages.Count > 0 && !flag)
                NavigationTabs.SelectedIndex = 0;

            OnNavigationTabsSelectedIndexChanged(NavigationTabs, new EventArgs());
        }

        /// <summary>
        /// Opens a content tab for a tagclass
        /// </summary>
        /// <param name="tagClass"></param>
        public override void OpenContentTab(TagClass tagClass)
        {
            pnlTabs.Controls.Clear();
            pnlTabs.Controls.Add(ContentTabs);


        }

        public void AddContentTab(string title, string name, UserControl baseUserControl)
        {
            if (ContentTabs.TabPages.Count == 0)
            {
                pnlTabs.Controls.Clear();
                pnlTabs.Controls.Add(ContentTabs);
            }
            CurrentTabPage = null;
            try
            {
                for (int iContentTabs = 0; iContentTabs < ContentTabs.TabPages.Count; iContentTabs++)
                {
                    string tagItem = ContentTabs.TabPages[iContentTabs].Tag.ToString();
                    if (tagItem == null) { continue; }
                    if (tagItem == name && !string.IsNullOrEmpty(name))
                    {
                        CurrentTabPage = ContentTabs.TabPages[iContentTabs];
                        if (CurrentTabPage.Text == title)
                        {
                            ContentTabs.SelectedItem = CurrentTabPage;
                            break;
                        }
                    }
                }

                if (CurrentTabPage == null)
                {
                    CurrentTabPage = new WorkspaceTab();
                    this.ContentTabs.Controls.Add(CurrentTabPage);
                    CurrentTabPage.Controls.Add(baseUserControl);
                    baseUserControl.Dock = DockStyle.Fill;
                    CurrentTabPage.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
                    CurrentTabPage.Location = new System.Drawing.Point(40, 0);
                    CurrentTabPage.Name = name + ContentTabs.TabPages.Count.ToString();
                    CurrentTabPage.Tag = name;
                    CurrentTabPage.Size = new System.Drawing.Size(828, 589);
                    CurrentTabPage.TabIndex = 0;
                    ContentTabs.SelectedIndexChanged -= OnContentTabsSelectedIndexChanged;
                    CurrentTabPage.Text = title;
                    ContentTabs.SelectedItem = CurrentTabPage;
                    ContentTabs.SelectedIndexChanged += OnContentTabsSelectedIndexChanged;
                }

                BaseUserControl baseUserControl1 = GetBaseUserControl();
                if (baseUserControl1 != null)
                {
                    baseUserControl1.PopulateToolbar(MainToolbar);
                }
            }
            catch (Exception ex)
            {
                //
            }
        }

        /// <summary>
        /// GenerateMenus
        /// </summary>
        public override void GenerateMenus(ref MainMenu mainMenu, string count)
        {
            try
            {
                base.GenerateMenus(ref mainMenu, count);
                MenuManager.MenuItemClick += new EventHandler<MenuManagerEventArgs>(OnProcessMenuItemEvents);
            }
            catch (Exception ex)
            {
                StackFrame stackFrame = new StackFrame();
                ExceptionLogger.LogAndDisplayMessageToUser(stackFrame, ex, QuantumFaults.None, ExceptionSeverityLevel.High);
            }
        }

        public override void GetTreeView(TreeViewControllerParameter treeViewParam)
        {
            NavigationTreeView.Nodes.Clear();
            NavigationTreeView.SelectedNode = null;
            switch (BusinessModuleID)
            {
                case Consts.Applications.Code.Administration:
                    treeViewParam.TreeType = TreeType.Administration;
                    break;
                case Consts.Applications.Code.HeadStart:
                    treeViewParam.TreeType = TreeType.HeadStart;
                    break;
                case Consts.Applications.Code.CaseManagement:
                    treeViewParam.TreeType = TreeType.CaseManagement;
                    break;
                case Consts.Applications.Code.EnergyRI:
                    treeViewParam.TreeType = TreeType.EnergyRI;
                    break;
                case Consts.Applications.Code.EnergyCT:
                    treeViewParam.TreeType = TreeType.EnergyCT;
                    break;
                case Consts.Applications.Code.EmergencyAssistance:
                    treeViewParam.TreeType = TreeType.EmergencyAssistance;
                    break;
                case Consts.Applications.Code.AccountsReceivable:
                    treeViewParam.TreeType = TreeType.AccountsReceivable;
                    break;
                case Consts.Applications.Code.HousingWeatherization:
                    treeViewParam.TreeType = TreeType.HousingWeatherization;
                    break;
                case Consts.Applications.Code.DashBoard:
                    treeViewParam.TreeType = TreeType.DashBoard;
                    break;

            }
            TreeViewController tv = new TreeViewController(this);
            tv.Initialize(treeViewParam);
            this.TreeViewController = tv;
        }

        public override void GetApplicantDetails(CaseMstEntity caseMstEntity, List<CaseSnpEntity> caseSNPEntity, string strAgency, string strDept, string strProgram, string strYear, string strType, string strAppDisplay)
        {
            //this.pnlApplicationHeaderImage.Controls.Clear();            
            // applicationDetailsControl = new ApplicationDetailsControl(this);
            //this.pnlApplicationHeaderImage.Controls.Add(applicationDetailsControl);
            //this.pnlApplicationHeaderImage.Size = new System.Drawing.Size(315, 90);
            if (strType != "LinkApplicant")
            {

                HierarchyEntity hierachyEntity = _model.HierarchyAndPrograms.GetCaseHierarchyName(strAgency.Substring(0, 2), "**", "**");
                if (hierachyEntity != null)
                {
                    hierachyNamecontrol.lblHierchy.Text = CommonFunctions.GetHierachyFormat(strAgency, strDept, strProgram, strYear, hierachyEntity.HIERepresentation);
                    BaseHierarchyCnFormat = hierachyEntity.CNFormat.ToString();
                    BaseHierarchyCwFormat = hierachyEntity.CWFormat.ToString();
                }
            }
            // hierachyNamecontrol.lblHierchy.Text = strAgency + "        " + strDept + "        " + strProgram + "        " + strYear;


            BaseApplicationName = string.Empty;                                         // Yeswanth To ClearCommon Text in Header
            applicationNameControl.lblApplicationName.Text = string.Empty;
            applicationNameControl.txtAppNo.Text = string.Empty;
            
            // applicationDetailsControl.ClearGridData();

            BaseCaseMstListEntity = null;
            BaseCaseSnpEntity = null;

            if (caseMstEntity != null)  // Yeswanth To Bypass Hierarchies With No Applicants
            {
                List<CaseMstEntity> casmsttemp = new List<CaseMstEntity>();
                casmsttemp.Add(caseMstEntity);
                BaseCaseMstListEntity = casmsttemp;
                BaseCaseSnpEntity = caseSNPEntity;
                if (BaseCaseSnpEntity.Count > 0)
                    BaseCaseSnpEntity.Find(u => u.FamilySeq.Equals(BaseCaseMstListEntity[0].FamilySeq)).M_Code = "A";
                // string strFormat = applicationDetailsControl.FillGridData(caseMstEntity.ApplAgency.ToString(), caseMstEntity.ApplDept.ToString(), caseMstEntity.ApplProgram.ToString(), caseMstEntity.ApplYr.ToString(), caseMstEntity.ApplNo.ToString());
                foreach (CaseSnpEntity caseSnp in caseSNPEntity)
                {
                    if (caseSnp.FamilySeq == caseMstEntity.FamilySeq)
                    {
                        BaseApplicationName = LookupDataAccess.GetMemberName(caseSnp.NameixFi, caseSnp.NameixMi, caseSnp.NameixLast, BaseHierarchyCnFormat);
                        string strZipcode = "00000".Substring(0, 5 - caseMstEntity.Zip.Length) + caseMstEntity.Zip;

                        string strPhonedis = string.Empty;
                        string strtelephone = string.Empty;
                        if (caseMstEntity.Area != string.Empty && caseMstEntity.Phone != string.Empty && caseMstEntity.Phone.Length == 7)
                        {
                            strPhonedis = "  Home (" + caseMstEntity.Area + ")" + caseMstEntity.Phone.Substring(0, 3) + "-" + caseMstEntity.Phone.Substring(3, 4);
                        }
                        if (caseMstEntity.CellPhone != string.Empty && caseMstEntity.CellPhone.Trim().Length == 10)
                        {
                            strtelephone = " Cell (" + caseMstEntity.CellPhone.Substring(0, 3) + ")" + caseMstEntity.CellPhone.Substring(3, 3) + "-" + caseMstEntity.CellPhone.Substring(6, 4);
                        }
                        if (strZipcode == "00000")
                            strZipcode = "";
                        //if (strAppDisplay == "Display")
                        //{
                        //    applicationNameControl.lblApplicationName.Text = BaseApplicationName + "     " + caseMstEntity.Hn.Trim() + ' ' + caseMstEntity.Street.Trim() + ' ' + caseMstEntity.Suffix.Trim() + ' ' + caseMstEntity.City.Trim() + ' ' + caseMstEntity.State.Trim() + ' ' + strZipcode + strPhonedis;
                        //    applicationNameControl.txtAppNo.Text = caseMstEntity.ApplNo;
                        //}
                        //else
                        //{
                        //    applicationNameControl.lblApplicationName.Text = "";
                        //    applicationNameControl.txtAppNo.Text = string.Empty;
                        //}

                        if (strAppDisplay == "Display")
                        {
                            if (BaseAgencyControlDetails.SitesData == "1")
                            {
                                string strSite = string.Empty;
                                if (caseMstEntity.Site.Trim() != string.Empty)
                                    strSite = " (" + caseMstEntity.Site.Trim() + ")";
                                applicationNameControl.lblApplicationName.Text = BaseApplicationName + strSite;
                            }
                            else
                            {
                                applicationNameControl.lblApplicationName.Text = BaseApplicationName;
                            }
                            ToolTip toolnewtip = new ToolTip();
                            toolnewtip.SetToolTip(applicationNameControl.lblApplicationName, caseMstEntity.Hn.Trim() + ' ' + caseMstEntity.Street.Trim() + ' ' + caseMstEntity.Suffix.Trim() + ' ' + caseMstEntity.City.Trim() + ' ' + caseMstEntity.State.Trim() + ' ' + strZipcode + strPhonedis + strtelephone);
                            applicationNameControl.txtAppNo.Text = caseMstEntity.ApplNo;
                        }
                        else
                        {
                            applicationNameControl.lblApplicationName.Text = "";
                            ToolTip toolnewtip = new ToolTip();
                            toolnewtip.SetToolTip(applicationNameControl.lblApplicationName, "");
                            applicationNameControl.txtAppNo.Text = string.Empty;
                        }
                        if (BaseTopApplSelect == "Y" || !string.IsNullOrEmpty(BaseApplicationNo.Trim()))
                        {

                            applicationNameControl.Btn_First.Visible = applicationNameControl.BtnP10.Visible = applicationNameControl.BtnPrev.Visible =
                            applicationNameControl.BtnNxt.Visible = applicationNameControl.BtnN10.Visible = applicationNameControl.BtnLast.Visible = true;
                        }
                        else
                        {
                            applicationNameControl.Btn_First.Visible = applicationNameControl.BtnP10.Visible = applicationNameControl.BtnPrev.Visible =
                              applicationNameControl.BtnNxt.Visible = applicationNameControl.BtnN10.Visible = applicationNameControl.BtnLast.Visible = false;
                        }
                    }
                }
            }
            else
            {
                applicationNameControl.Btn_First.Visible = applicationNameControl.BtnP10.Visible = applicationNameControl.BtnPrev.Visible =
                             applicationNameControl.BtnNxt.Visible = applicationNameControl.BtnN10.Visible = applicationNameControl.BtnLast.Visible = false;
            }

        }

        public override void GetAgencyDetails(DataRow dr, string strAgency, string strDept, string strProgram, string strYear, string strType, string strAppDisplay)
        {

            if (strType != "LinkApplicant")
            {

                HierarchyEntity hierachyEntity = _model.HierarchyAndPrograms.GetCaseHierarchyName(strAgency.Substring(0, 2), "**", "**");
                if (hierachyEntity != null)
                {
                    hierachyNamecontrol.lblHierchy.Text = CommonFunctions.GetHierachyFormat(strAgency, strDept, strProgram, strYear, hierachyEntity.HIERepresentation);
                    BaseHierarchyCnFormat = hierachyEntity.CNFormat.ToString();
                    BaseHierarchyCwFormat = hierachyEntity.CWFormat.ToString();
                }
            }


            BaseApplicationName = string.Empty;
            applicationNameControl.lblApplicationName.Text = string.Empty;
            applicationNameControl.txtAppNo.Text = string.Empty;
           

            if (dr != null)
            {
                if (strAppDisplay == "Display")
                {
                    
                }
            }


            //else
            //{
            //    applicationNameControl.Btn_First.Visible = applicationNameControl.BtnP10.Visible = applicationNameControl.BtnPrev.Visible =
            //                 applicationNameControl.BtnNxt.Visible = applicationNameControl.BtnN10.Visible = applicationNameControl.BtnLast.Visible = false;
            //}

        }


        public override void RemoveTabPages(string strModuleType)
        {
            pnlTabs.Controls.Clear();

            switch (BusinessModuleID)
            {
                case Consts.Applications.Code.Administration:
                    AddWelcomeScreen(pnlTabs);
                    break;
                case Consts.Applications.Code.DashBoard:
                    AddWelcomeScreen(pnlTabs);
                    break;
            }

            // ContentTabs.TabPages.Clear();
            //AddWelcomeScreen(pnlTabs);
            int intTabPagesTotal = ContentTabs.TabPages.Count;
            int intTabPages = ContentTabs.TabPages.Count - 1;
            for (int i = 0; i < intTabPagesTotal; i++)
            {
                if (!ContentTabs.TabPages[intTabPages].Name.Equals("MainMenu1"))
                {
                    if (strModuleType == "Client")
                    {
                        if (!ContentTabs.TabPages[intTabPages].Name.ToUpper().Contains("CASE2001"))
                        {
                            ContentTabs.TabPages.RemoveAt(intTabPages);
                            intTabPages = intTabPages - 1;
                        }
                        else
                        {
                            intTabPages = intTabPages - 1;
                        }
                    }
                    else
                    {
                        ContentTabs.TabPages.RemoveAt(intTabPages);
                        intTabPages = intTabPages - 1;
                    }
                }
            }
            pnlTabs.Controls.Add(ContentTabs);
            if (strModuleType != "Client")
            {
                MainToolbar.Buttons.Clear();
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Initializes a module treeview and header image
        /// </summary>
        /// <param name="headerTitleImage">The name of the header title image</param>
        /// <param name="treeViewType">The type of tree to initialize.</param>
        private void InitializeModule(string headerTitleImage, TreeType treeViewType)
        {
            TreeViewControllerParameter treeViewControllerParameter = null;
            this.tabWelcome.Controls.Clear();
            this.tabCaseManagement.Controls.Clear();
            this.tabAdministration.Controls.Clear();
            this.tabHeadStart.Controls.Clear();
            this.tabEnergyRI.Controls.Clear();
            this.tabEnergyCT.Controls.Clear();
            this.tabEmergencyAssistance.Controls.Clear();
            this.tabHousingWeatherization.Controls.Clear();
            this.tabAccountsReceivable.Controls.Clear();
            this.tabDashBoard.Controls.Clear();
            this.tabHealthyStart.Controls.Clear();
            this.tabAgencypartner.Controls.Clear();
            // this.pnlApplicationHeaderImage.Controls.Clear();
            this.pnlSearch.Controls.Clear();
            this.pnlButtonBar.Controls.Clear();
            this.pnlButtonBar.Controls.Add(this.MainToolbar);
            // pnlApplicationHeaderImage.BackgroundImage = new ImageResourceHandle(headerTitleImage);
            //  pnlApplicationHeaderImage.Width = 30;
            NavigationTreeView.Nodes.Clear();
            string HIE = string.Empty;

            if ((!treeViewType.Equals(TreeType.Administration)) && (!treeViewType.Equals(TreeType.DashBoard)))
            {
                if (_model.lookupDataAccess.CheckDefaultHierachy(BaseAgency, BaseDept, BaseProg, UserProfile.UserID) == Consts.Common.Exists)
                {
                    HIE = BaseAgency + BaseDept + BaseProg;
                    treeViewControllerParameter = new TreeViewControllerParameter()
                    {
                        TreeType = treeViewType,
                        TreeView = NavigationTreeView,
                        Hierarchy = HIE
                    };
                    BaseTopApplSelect = "N";
                    ShowHierachyandApplNo(BaseAgency, BaseDept, BaseProg, BaseYear, BaseApplicationNo, string.Empty);
                    MainmenuAddTab();
                }
                else
                {
                    _defaultHierchyform = true;
                    MainmenuAddTab();
                    //AdvancedMainMenuSearch advancedMainMenuSearch = new AdvancedMainMenuSearch(this, false, true);
                    //advancedMainMenuSearch.FormClosed += new Form.FormClosedEventHandler(On_ADV_SerachFormClosed);
                    //advancedMainMenuSearch.ShowDialog();
                }

            }
            else
            {
                //this.pnlApplicationHeaderImage.Size = new System.Drawing.Size(305, 30);
                //this.pnlApplicationHeader.Size = new System.Drawing.Size(305, 30);

                treeViewControllerParameter = new TreeViewControllerParameter()
                {
                    TreeType = treeViewType,
                    TreeView = NavigationTreeView,
                    Hierarchy = HIE
                };
            }



            switch (treeViewType)
            {
                case TreeType.Administration:
                    this.tabAdministration.Controls.Add(this.NavigationTreeView);
                    break;
                case TreeType.HeadStart:
                    this.tabHeadStart.Controls.Add(this.NavigationTreeView);
                    break;
                case TreeType.CaseManagement:
                    this.tabCaseManagement.Controls.Add(this.NavigationTreeView);
                    break;
                case TreeType.EnergyRI:
                    this.tabEnergyRI.Controls.Add(this.NavigationTreeView);
                    break;
                case TreeType.EnergyCT:
                    this.tabEnergyCT.Controls.Add(this.NavigationTreeView);
                    break;
                case TreeType.EmergencyAssistance:
                    this.tabEmergencyAssistance.Controls.Add(this.NavigationTreeView);
                    break;
                case TreeType.AccountsReceivable:
                    this.tabAccountsReceivable.Controls.Add(this.NavigationTreeView);
                    break;
                case TreeType.HousingWeatherization:
                    this.tabHousingWeatherization.Controls.Add(this.NavigationTreeView);
                    break;
                case TreeType.DashBoard:
                    this.tabDashBoard.Controls.Add(this.NavigationTreeView);
                    break;
                case TreeType.HealthyStart:
                    this.tabHealthyStart.Controls.Add(this.NavigationTreeView);
                    break;
                case TreeType.AgencyPartner:
                    this.tabAgencypartner.Controls.Add(this.NavigationTreeView);
                    break;
            }

            TreeViewController tv = new TreeViewController(this);
            tv.Initialize(treeViewControllerParameter);
            this.TreeViewController = tv;
        }

        #endregion

        #region Handled Event Calls

        /// <summary>
        /// OnTreeViewDoubleClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>TreeView Method</remarks>
        public override void OnTreeViewDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            DateTime beforeCall = DateTime.Now;

            base.OnTreeViewDoubleClick(sender, e);

            PrivilegeEntity privilegeEntity = e.Node.Tag as PrivilegeEntity;
            switch (privilegeEntity.Program)
            {

            }
        }

        /// <summary>
        /// OnTreeViewClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>TreeView Method</remarks>
        public override void OnTreeViewClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            base.OnTreeViewClick(sender, e);
            string nodeLabel = string.Empty;
            PrivilegeEntity privilegeEntity = e.Node.Tag as PrivilegeEntity;
            if (privilegeEntity == null) return;
            switch (privilegeEntity.Program.Trim())
            {
                //case "ADMN0005": //Users
                //    UserListControl ulc = new UserListControl(this, privilegeEntity);
                //    AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, ulc);
                //    break;
                //case "ADMN0006": //Agency Table Codes
                //    AgencyTableControl agencyTabelControl = new AgencyTableControl(this, privilegeEntity);
                //    AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, agencyTabelControl);
                //    break;
                //case "ADMN0012": //Agency Control file Maintanence
                //    AgencyHierarchyForm agencyForm = new AgencyHierarchyForm(this, "ADMN0012", "AGENCY", "00", privilegeEntity);
                //    agencyForm.ShowDialog();
                //    break;
                //case "ADMN0010": //Master Poverty Guidelines 
                //    //MasterPovertyGuidelinesForm masterPovertyForm = new MasterPovertyGuidelinesForm(this, privilegeEntity);
                //    //masterPovertyForm.ShowDialog();                      
                //    MasterPoverityGuidelineControl masterPovertyControl = new MasterPoverityGuidelineControl(this, privilegeEntity);
                //    AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, masterPovertyControl);
                //    break;
                //case "ADMN0013": //Zipcode
                //    ADMN0013 ADMN0013 = new ADMN0013(this, privilegeEntity);
                //    ////AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, zipCodeControl);
                //    AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, ADMN0013);
                //    break;
                //case "ADMN0009": //Hierarchy Definition
                //    HierarchyDefinitionControl hierarchyDefinitionControl = new HierarchyDefinitionControl(this, privilegeEntity);
                //    AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, hierarchyDefinitionControl);
                //    break;
                //case "CASE0007": //Hierarchy Definition                                     
                //    ProgramDefinition programdefinitioncontrol = new ProgramDefinition(this, privilegeEntity);
                //    AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, programdefinitioncontrol);
                //    break;
                case "CASE2001":
                    if (!string.IsNullOrEmpty(BaseApplicationNo))
                    {
                        _privilegeEntity = privilegeEntity;
                        if (BaseTopApplSelect == "Y")
                        {
                            Case3001Control clientIntakeControl = new Case3001Control(this, privilegeEntity);
                            // ClientIntakeControl clientIntakeControl = new ClientIntakeControl(this, privilegeEntity);
                            AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, clientIntakeControl);
                        }
                        else
                            CommonFunctions.MessageBoxDisplay(Consts.Messages.AplicantSelectionMsg);
                    }
                    else
                    {
                        CommonFunctions.MessageBoxDisplay(Consts.Messages.Applicantdoesntexist);
                    }
                    break;
                case "CASE2002":
                    if (!string.IsNullOrEmpty(BaseApplicationNo))
                    {
                        _privilegeEntity = privilegeEntity;
                        if (BaseTopApplSelect == "Y")
                        {
                            Case3001Control clientIntakeControl = new Case3001Control(this, privilegeEntity);
                            // ClientIntakeControl clientIntakeControl = new ClientIntakeControl(this, privilegeEntity);
                            AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, clientIntakeControl);
                        }
                        else
                            CommonFunctions.MessageBoxDisplay(Consts.Messages.AplicantSelectionMsg);
                    }
                    else
                    {
                        CommonFunctions.MessageBoxDisplay(Consts.Messages.Applicantdoesntexist);
                    }
                    break;
                //case "TMSB4016":
                //    TMSB4601 TMSBForm = new TMSB4601();
                //    TMSBForm.ShowDialog();
                //    break;

                //case "TMSB0000":
                //    TMSB0000_ActSum_Report Act_Report = new TMSB0000_ActSum_Report(this, privilegeEntity);
                //    Act_Report.ShowDialog();
                //    break;

                //case "TMSB0020":
                //    TMSB0020_CheckProcessing Check_Proc = new TMSB0020_CheckProcessing(this, privilegeEntity);
                //    Check_Proc.ShowDialog();
                //    break;
                //case "TMSB0025":
                //    TMSB0025_Report oTMSB0025_Report = new TMSB0025_Report(this, privilegeEntity);
                //    oTMSB0025_Report.ShowDialog();
                //    break;

                //case "TMS00100":
                //    TMS00100 tms00100 = new TMS00100(this, privilegeEntity);
                //    AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, tms00100);
                //    break;
                //case "CASE0008":
                //    FLDCNTLMaintenanceControl FLDControl = new FLDCNTLMaintenanceControl(this, privilegeEntity);
                //    AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, FLDControl);
                //    break;
                //case "TMS00110":
                //    TMS00110Control TMS00110 = new TMS00110Control(this, privilegeEntity);
                //    AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, TMS00110);
                //    break;
                //case "REPMNT20":
                //    PdfListForm pdfListForm = new PdfListForm(this, privilegeEntity, true);
                //    pdfListForm.ShowDialog();
                //    break;
                //case "TMS00300":
                //    TMS00300Control TMS00300 = new TMS00300Control(this, privilegeEntity);
                //    AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, TMS00300);
                //    break;
                //case "ADMNB002":
                //    ADMNB002 ADMNB002Form = new ADMNB002(this, privilegeEntity);
                //    ADMNB002Form.ShowDialog();
                //    break;
                //case "ADMNB001":
                //    ADMNB001 ADMNB001Form = new ADMNB001(this, privilegeEntity);
                //    ADMNB001Form.ShowDialog();
                //    break;
                //case "TMS00310":
                //    TMS00310Control TMS00310 = new TMS00310Control(this, privilegeEntity);
                //    AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, TMS00310);
                //    break;
                //case "ADMN0016":
                //    CriticalActivity ADMN0016 = new CriticalActivity(this, privilegeEntity);
                //    AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, ADMN0016);
                //    break;

                //case "CASB2012":
                //    CASB2012Control CASB2012 = new CASB2012Control(this, privilegeEntity);
                //    AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, CASB2012);
                //    break;
                //case "ADMN0020":
                //    ADMN0020control ADMN0020 = new ADMN0020control(this, privilegeEntity);
                //    AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, ADMN0020);
                //    break;
                //case "TMS00120":
                //    TMS00120Control TMS00120 = new TMS00120Control(this, privilegeEntity);
                //    AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, TMS00120);
                //    break;
                //case "CASE2004":
                //    if (!string.IsNullOrEmpty(BaseApplicationNo))
                //    {
                //        if (BaseTopApplSelect == "Y")
                //        {
                //            CaseSumControl Case2004 = new CaseSumControl(this, privilegeEntity);
                //            AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, Case2004);
                //        }
                //        else
                //            CommonFunctions.MessageBoxDisplay(Consts.Messages.AplicantSelectionMsg);
                //    }
                //    else
                //    {
                //        CommonFunctions.MessageBoxDisplay(Consts.Messages.Applicantdoesntexist);
                //    }
                //    break;
                //case "CASE0009":
                //    Case0009Control Case0009 = new Case0009Control(this, privilegeEntity);
                //    AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, Case0009);
                //    break;
                //case "CASE0006":
                //    if (!string.IsNullOrEmpty(BaseApplicationNo))
                //    {
                //        if (BaseTopApplSelect == "Y")
                //        {
                //            if (BaseAgencyControlDetails.CAOBO.Trim() == "Y" && BaseAgencyControlDetails.QuickPostServices.Trim() != "Y")
                //            {
                //                CASE5006Control CASE5006 = new CASE5006Control(this, privilegeEntity);
                //                AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, CASE5006);
                //            }
                //            else
                //            {
                //                CASE4006Control CASE4006 = new CASE4006Control(this, privilegeEntity);
                //                AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, CASE4006);
                //            }
                //        }
                //        else
                //            CommonFunctions.MessageBoxDisplay(Consts.Messages.AplicantSelectionMsg);
                //    }
                //    else
                //    {
                //        CommonFunctions.MessageBoxDisplay(Consts.Messages.Applicantdoesntexist);
                //    }
                //    break;
                //case "CASE1006":
                //    if (!string.IsNullOrEmpty(BaseApplicationNo) && BaseAgencyControlDetails.MemberActivity == "Y")
                //    {
                //        if (BaseTopApplSelect == "Y")
                //        {
                //            CASE6006Control CASE4006 = new CASE6006Control(this, privilegeEntity);
                //            AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, CASE4006);
                //        }
                //        else
                //            CommonFunctions.MessageBoxDisplay(Consts.Messages.AplicantSelectionMsg);
                //    }
                //    else
                //    {
                //        CommonFunctions.MessageBoxDisplay(Consts.Messages.Applicantdoesntexist);
                //    }
                //    break;

                //case "CASB0012":
                //    CASB2012_AdhocForm AdhocForm = new CASB2012_AdhocForm(this, privilegeEntity);
                //    AdhocForm.ShowDialog();
                //    break;
                //case "MAT00001":
                //    MAT00001Control MAT00001 = new MAT00001Control(this, privilegeEntity);
                //    AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, MAT00001);
                //    break;
                //case "MAT00002":
                //    MAT00002Control MAT00002 = new MAT00002Control(this, privilegeEntity);
                //    AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, MAT00002);
                //    break;
                //case "MAT00003":
                //    if (!string.IsNullOrEmpty(BaseApplicationNo))
                //    {
                //        if (BaseTopApplSelect == "Y")
                //        {
                //            MAT00003Control MAT00003 = new MAT00003Control(this, privilegeEntity);
                //            AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, MAT00003);
                //        }
                //        else
                //            CommonFunctions.MessageBoxDisplay(Consts.Messages.AplicantSelectionMsg);
                //    }
                //    else
                //    {
                //        CommonFunctions.MessageBoxDisplay(Consts.Messages.Applicantdoesntexist);
                //    }
                //    break;

                //case "CASB0004":
                //    CASB0004Form Casb0004Form = new CASB0004Form(this, privilegeEntity); ;
                //    Casb0004Form.ShowDialog();
                //    break;
                //case "CASE0011":
                //    Case2011Control AgencyReferal = new Case2011Control(this, privilegeEntity);
                //    AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, AgencyReferal);

                //    break;
                //case "TMS00009":
                //    Vendor_Maintainance Vendor = new Vendor_Maintainance(this, privilegeEntity);
                //    AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, Vendor);
                //    break;
                //case "ADMN0015":
                //    ADMN0015Control CaseSite = new ADMN0015Control(this, privilegeEntity);
                //    AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, CaseSite);
                //    break;
                //case "HSS00135":
                //    if (!string.IsNullOrEmpty(BaseYear.Trim()))
                //    {
                //        Site_ScheduleControl sitesch = new Site_ScheduleControl(this, privilegeEntity);
                //        AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, sitesch);
                //    }
                //    else
                //    {
                //        CommonFunctions.MessageBoxDisplay("Year Should not be blank for this hierachy in Program Definition");
                //    }
                //    break;
                //case "HSS00138":
                //    HSS00138_Control busMaintenance = new HSS00138_Control(this, privilegeEntity);
                //    AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, busMaintenance);
                //    break;

                //case "CASE2330":
                //    if (!string.IsNullOrEmpty(BaseApplicationNo))
                //    {
                //        if (BaseTopApplSelect == "Y")
                //        {
                //            Case2330Form case2330form = new Case2330Form(this, privilegeEntity);
                //            case2330form.ShowDialog();
                //        }
                //        else
                //            CommonFunctions.MessageBoxDisplay(Consts.Messages.AplicantSelectionMsg);
                //    }
                //    else
                //    {
                //        CommonFunctions.MessageBoxDisplay(Consts.Messages.Applicantdoesntexist);
                //    }
                //    break;

                //case "HSS00133":
                //    if (!UserProfile.Components.Contains("None"))
                //    {
                //        HSS00133_Control HSS00133 = new HSS00133_Control(this, privilegeEntity);
                //        AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, HSS00133);
                //    }
                //    else
                //    {
                //        CommonFunctions.MessageBoxDisplay("You can't Access any Component \n Please Contact Your System Administrator");
                //    }
                //    break;
                //case "STFMST10":
                //    STFMST10Control staffControl = new STFMST10Control(this, privilegeEntity);
                //    AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, staffControl);
                //    break;
                //case "STFBLK10":
                //    STFBLK10Control staffBulkControl = new STFBLK10Control(this, privilegeEntity);
                //    AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, staffBulkControl);
                //    break;
                //case "HSS00140":
                //    HSS00140_Control busClient = new HSS00140_Control(this, privilegeEntity);
                //    AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, busClient);
                //    break;

                //case "CASE0010":
                //    CASE0010_Control Enrollment = new CASE0010_Control(this, privilegeEntity);
                //    AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, Enrollment);
                //    break;
                //case "HSSB0118":
                //    HSSB0118_ReportForm BusLists = new HSSB0118_ReportForm(this, privilegeEntity);
                //    BusLists.ShowDialog();
                //    break;
                //case "CASB0007":
                //    CASB4007_FunnelReport Funnel_Form = new CASB4007_FunnelReport(this, privilegeEntity);
                //    Funnel_Form.ShowDialog();
                //    break;
                //case "HSSB0110":
                //    HSSB2110 Class_Report = new HSSB2110(this, privilegeEntity);
                //    Class_Report.ShowDialog();
                //    break;
                //case "HSS00134":
                //    if (!string.IsNullOrEmpty(BaseApplicationNo))
                //    {
                //        if (BaseTopApplSelect == "Y")
                //        {
                //            if (!UserProfile.Components.Contains("None"))
                //            {
                //                HSS00134Control HSS00134 = new HSS00134Control(this, privilegeEntity);
                //                AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, HSS00134);
                //            }
                //            else
                //            {
                //                CommonFunctions.MessageBoxDisplay("You can't Access any Component \n Please Contact Your System Administrator");
                //            }
                //        }
                //        else
                //            CommonFunctions.MessageBoxDisplay(Consts.Messages.AplicantSelectionMsg);
                //    }
                //    else
                //    {
                //        CommonFunctions.MessageBoxDisplay(Consts.Messages.Applicantdoesntexist);
                //    }
                //    break;
                //case "HSS00137":
                //    if (!string.IsNullOrEmpty(BaseYear.Trim()))
                //    {
                //        HSS00137Control hss00137control = new HSS00137Control(this, privilegeEntity);
                //        AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, hss00137control);
                //    }
                //    else
                //    {
                //        CommonFunctions.MessageBoxDisplay("Year Should not be blank for this hierachy in Program Definition");
                //    }
                //    break;
                //case "HSSB0100":
                //    HSSB2100 ChildLists = new HSSB2100(this, privilegeEntity);
                //    ChildLists.ShowDialog();
                //    break;
                //case "HSSB0102":
                //    HSSB2102_TrackReport Track_Report = new HSSB2102_TrackReport(this, privilegeEntity);
                //    Track_Report.ShowDialog();
                //    break;
                //case "CASB0530":
                //    Casb2530Form casb2530form = new Casb2530Form(this, privilegeEntity);
                //    casb2530form.ShowDialog();
                //    break;
                //case "HSSB0108":
                //    HSSB2108ReportForm HSSB2108form = new HSSB2108ReportForm(this, privilegeEntity);
                //    HSSB2108form.ShowDialog();
                //    break;
                //case "HSSB2108":
                //    HSSB2108ReportFormVer2 HSSB2108form2 = new HSSB2108ReportFormVer2(this, privilegeEntity);
                //    HSSB2108form2.ShowDialog();
                //    break;
                //case "HSSB0111":
                //    HSSB2111ReportForm HSSB2111form = new HSSB2111ReportForm(this, privilegeEntity);
                //    HSSB2111form.ShowDialog();
                //    break;
                //case "HSSB0109":
                //    HSSB2109ReportForm HSSB2109form = new HSSB2109ReportForm(this, privilegeEntity);
                //    HSSB2109form.ShowDialog();
                //    break;
                //case "HSSB0103":
                //    HSSB2103ReportForm HSSB2103form = new HSSB2103ReportForm(this, privilegeEntity);
                //    HSSB2103form.ShowDialog();
                //    break;
                //case "HSSB0106":
                //    HSSB2106_ChildTrackReport ChildTrack = new HSSB2106_ChildTrackReport(this, privilegeEntity);
                //    ChildTrack.ShowDialog();
                //    break;
                //case "HSSB0114":
                //    HSSB2114ReportForm Hssb2114form = new HSSB2114ReportForm(this, privilegeEntity);
                //    Hssb2114form.ShowDialog();
                //    break;
                //case "HSSB0112":
                //    HSSB2112_Report Hssb2112form = new HSSB2112_Report(this, privilegeEntity);
                //    Hssb2112form.ShowDialog();
                //    break;
                //case "PIR00000":
                //    PIR20000Form PIR20000form = new PIR20000Form(this, privilegeEntity);
                //    PIR20000form.ShowDialog();
                //    break;
                //case "PIR00001":
                //    PIR20001Control Pir20001Control = new PIR20001Control(this, privilegeEntity);
                //    AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, Pir20001Control);
                //    break;
                //case "MATB0002":
                //    MATB0002_Form MATB0002Form = new MATB0002_Form(this, privilegeEntity); ;
                //    MATB0002Form.ShowDialog();
                //    break;
                //case "ENRLHIST":
                //    if (!string.IsNullOrEmpty(BaseApplicationNo))
                //    {
                //        _privilegeEntity = privilegeEntity;
                //        if (BaseTopApplSelect == "Y")
                //        {
                //            CASE0010_StatusChange_Form EnrlHist_Form = new CASE0010_StatusChange_Form(this, privilegeEntity); ;
                //            EnrlHist_Form.ShowDialog();
                //        }
                //        else
                //            CommonFunctions.MessageBoxDisplay(Consts.Messages.AplicantSelectionMsg);
                //    }
                //    else
                //        CommonFunctions.MessageBoxDisplay(Consts.Messages.Applicantdoesntexist);
                //    break;

                //case "HSSB0026":
                //    HSSB0026_PIRCounting_From PIR_Counting_Form = new HSSB0026_PIRCounting_From(this, privilegeEntity); ;
                //    PIR_Counting_Form.ShowDialog();

                //    break;
                //case "HSSB0123":
                //    HSSB0123 GrowthCharts = new HSSB0123(this, privilegeEntity);
                //    GrowthCharts.ShowDialog();
                //    break;
                //case "HSS00001":
                //    Hss20001Control hss20001Control = new Hss20001Control(this, privilegeEntity);
                //    AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, hss20001Control);
                //    break;
                //case "HSSB0115":
                //    HSSB0115_WaitingList_Report WaitList = new HSSB0115_WaitingList_Report(this, privilegeEntity);
                //    WaitList.ShowDialog();
                //    break;
                //case "TMSB6B01":
                //    TMSB6B01_Report Vendor_list = new TMSB6B01_Report(this, privilegeEntity);
                //    Vendor_list.ShowDialog();
                //    break;
                //case "TMS00081":
                //    if (!string.IsNullOrEmpty(BaseApplicationNo))
                //    {
                //        _privilegeEntity = privilegeEntity;
                //        if (BaseTopApplSelect == "Y")
                //        {
                //            TMS00081_Control TMS00081 = new TMS00081_Control(this, privilegeEntity);
                //            AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, TMS00081);
                //        }
                //        else
                //            CommonFunctions.MessageBoxDisplay(Consts.Messages.AplicantSelectionMsg);
                //    }
                //    else
                //        CommonFunctions.MessageBoxDisplay(Consts.Messages.Applicantdoesntexist);
                //    break;
                //case "CASE0012":
                //    INKIND20_control INKIND20 = new INKIND20_control(this, privilegeEntity);
                //    AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, INKIND20);
                //    break;
                //case "FUELCNTL":
                //    FuelControl Fuel = new FuelControl(this, privilegeEntity);
                //    Fuel.ShowDialog();
                //    break;
                //case "ARS00120":
                //    if (!string.IsNullOrEmpty(BaseApplicationNo))
                //    {
                //        _privilegeEntity = privilegeEntity;
                //        if (BaseTopApplSelect == "Y")
                //        {
                //            ARS20120 ARS20120 = new ARS20120(this, privilegeEntity);
                //            AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, ARS20120);
                //        }
                //        else
                //            CommonFunctions.MessageBoxDisplay(Consts.Messages.AplicantSelectionMsg);
                //    }
                //    else
                //    {
                //        CommonFunctions.MessageBoxDisplay(Consts.Messages.Applicantdoesntexist);
                //    }
                //    break;
                //case "ARS00115":
                //    Ars20115Control ARS20115control = new Ars20115Control(this, privilegeEntity);
                //    AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, ARS20115control);
                //    break;
                //case "ARSB0150":
                //    ARSB2150_ReportForm CustStatement = new ARSB2150_ReportForm(this, privilegeEntity);
                //    CustStatement.ShowDialog();
                //    break;
                //case "ARSB0140":
                //    ARSB2140_ReportForm custReport = new ARSB2140_ReportForm(this, privilegeEntity);
                //    custReport.ShowDialog();
                //    break;
                //case "ARSB0160":
                //    ARSB2160_Report invoice = new ARSB2160_Report(this, privilegeEntity);
                //    invoice.ShowDialog();
                //    break;
                //case "ARSB0120":
                //    ARSB2120_ReportForm Billing = new ARSB2120_ReportForm(this, privilegeEntity);
                //    Billing.ShowDialog();
                //    break;
                //case "TMSB0019":
                //    TMSB0019Form tMSB0019Form = new TMSB0019Form(this, privilegeEntity);
                //    tMSB0019Form.ShowDialog();
                //    break;
                //case "TMSBLTRB":
                //    TMSBLTRB tMSBLTRBReport = new TMSBLTRB(this, privilegeEntity);
                //    tMSBLTRBReport.ShowDialog();
                //    break;
                //case "TMSB0002":
                //    TMSB0002Form tMSB0002Form = new TMSB0002Form(this, privilegeEntity);
                //    tMSB0002Form.ShowDialog();
                //    break;
                //case "TMSB0015":
                //    TMSB4015_SSNReport TMSB4015 = new TMSB4015_SSNReport(this, privilegeEntity);
                //    TMSB4015.ShowDialog();
                //    break;
                //case "HSSB0104":
                //    HSSB2104 HSSB2104 = new HSSB2104(this, privilegeEntity);
                //    HSSB2104.ShowDialog();
                //    break;
                //case "HSSB0124":
                //    HSSB0124_Report HSSB0124 = new HSSB0124_Report(this, privilegeEntity);
                //    HSSB0124.ShowDialog();
                //    break;
                //case "TMSB0017":
                //    TMSB4017 TMS4017_Report = new TMSB4017(this, privilegeEntity);
                //    TMS4017_Report.ShowDialog();
                //    break;
                //case "TMSB0003":
                //    TMSB4003 tmsb4003 = new TMSB4003(this, privilegeEntity);
                //    tmsb4003.ShowDialog();
                //    break;
                //case "TMSB0001":
                //    TMSB0001_Report tmsb4001 = new TMSB0001_Report(this, privilegeEntity);
                //    tmsb4001.ShowDialog();
                //    break;
                //case "TMSB0007":
                //    TMSB4007 tmsb4007 = new TMSB4007(this, privilegeEntity);
                //    tmsb4007.ShowDialog();
                //    break;
                //case "TMSB0005":
                //    TMSB0005_Report TMSB4005_ReportForm = new TMSB0005_Report(this, privilegeEntity);
                //    TMSB4005_ReportForm.ShowDialog();
                //    break;
                //case "TMSB0006":
                //    TMSB0006_Report TMSB4006_ReportForm = new TMSB0006_Report(this, privilegeEntity);
                //    TMSB4006_ReportForm.ShowDialog();
                //    break;
                //case "TMSB0004":
                //    TMSB0004_Report TMSB4004_ReportForm = new TMSB0004_Report(this, privilegeEntity);
                //    TMSB4004_ReportForm.ShowDialog();
                //    break;
                //case "TMSB0011":
                //    TMSB0011_Report TMSB4011_ReportForm = new TMSB0011_Report(this, privilegeEntity);
                //    TMSB4011_ReportForm.ShowDialog();
                //    break;
                //case "ARS00130":
                //    if (!string.IsNullOrEmpty(BaseApplicationNo))
                //    {
                //        _privilegeEntity = privilegeEntity;
                //        if (BaseTopApplSelect == "Y")
                //        {
                //            Ars20130Control ARS20130 = new Ars20130Control(this, privilegeEntity);
                //            AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, ARS20130);
                //        }
                //        else
                //            CommonFunctions.MessageBoxDisplay(Consts.Messages.AplicantSelectionMsg);
                //    }
                //    else
                //    {
                //        CommonFunctions.MessageBoxDisplay(Consts.Messages.Applicantdoesntexist);
                //    }
                //    break;
                //case "EMS00010":
                //    EMS00010Control Ems30010control = new EMS00010Control(this, privilegeEntity);
                //    AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, Ems30010control);
                //    break;

                //case "EMS00020":
                //    if (!string.IsNullOrEmpty(BaseApplicationNo))
                //    {
                //        _privilegeEntity = privilegeEntity;
                //        if (BaseTopApplSelect == "Y")
                //        {
                //            EMS00020Control ems00020Control = new EMS00020Control(this, privilegeEntity);
                //            AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, ems00020Control);
                //        }
                //        else
                //            CommonFunctions.MessageBoxDisplay(Consts.Messages.AplicantSelectionMsg);
                //    }
                //    else
                //    {
                //        CommonFunctions.MessageBoxDisplay(Consts.Messages.Applicantdoesntexist);
                //    }
                //    break;
                //case "TMSBCHCT":
                //    TMSBCHCT TMSBChCt_ReportForm = new TMSBCHCT(this, privilegeEntity);
                //    TMSBChCt_ReportForm.ShowDialog();
                //    break;
                //case "TMSB0010":
                //    TMSB0010_Bundling TMSB0010_ReportForm = new TMSB0010_Bundling(this, privilegeEntity);
                //    TMSB0010_ReportForm.ShowDialog();
                //    break;
                //case "TMS00090":
                //    TMS20090 TMS20090_FORM = new TMS20090(this, privilegeEntity);
                //    TMS20090_FORM.ShowDialog();
                //    break;
                //case "ADMN0021":
                //    Admn0021Form admn0021form = new Admn0021Form(this, privilegeEntity);
                //    admn0021form.ShowDialog();
                //    break;
                //case "EMSB0014":
                //    EMSB0014_BudgetReport Budget_report = new EMSB0014_BudgetReport(this, privilegeEntity);
                //    Budget_report.ShowDialog();
                //    break;
                //case "EMSB0003":
                //    EMSB0003_PendingCases Pending_report = new EMSB0003_PendingCases(this, privilegeEntity);
                //    Pending_report.ShowDialog();
                //    break;
                //case "EMSB0007":
                //    EMSB0007_NoInvoiceReport NoInvoice_report = new EMSB0007_NoInvoiceReport(this, privilegeEntity);
                //    NoInvoice_report.ShowDialog();
                //    break;
                //case "EMSB0010":
                //    EMSB0010_FollowUp FolowUp_report = new EMSB0010_FollowUp(this, privilegeEntity);
                //    FolowUp_report.ShowDialog();
                //    break;
                //case "EMSB0012":
                //    EMSB0012_Report DeptRej_report = new EMSB0012_Report(this, privilegeEntity);
                //    DeptRej_report.ShowDialog();
                //    break;
                //case "EMSB0018":
                //    EMS0018_Report ReFHs_report = new EMS0018_Report(this, privilegeEntity);
                //    ReFHs_report.ShowDialog();
                //    break;
                //case "EMSB0011":
                //    EMSB0011_PaidInvoices Paidinvoices_report = new EMSB0011_PaidInvoices(this, privilegeEntity);
                //    Paidinvoices_report.ShowDialog();
                //    break;
                //case "EMSB0017":
                //    EMSB3017_Zipcode ZipCode_report = new EMSB3017_Zipcode(this, privilegeEntity);
                //    ZipCode_report.ShowDialog();
                //    break;
                //case "EMS00040":
                //    if (!string.IsNullOrEmpty(BaseApplicationNo))
                //    {
                //        _privilegeEntity = privilegeEntity;
                //        if (BaseTopApplSelect == "Y")
                //        {
                //            EMS00040Control ems00040Control = new EMS00040Control(this, privilegeEntity);
                //            AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, ems00040Control);
                //        }
                //        else
                //            CommonFunctions.MessageBoxDisplay(Consts.Messages.AplicantSelectionMsg);
                //    }
                //    else
                //    {
                //        CommonFunctions.MessageBoxDisplay(Consts.Messages.Applicantdoesntexist);
                //    }
                //    break;

                //case "HSS00430":
                //    if (!string.IsNullOrEmpty(BaseApplicationNo))
                //    {
                //        if (BaseTopApplSelect == "Y")
                //        {
                //            HSS00430Form hss00430Form = new HSS00430Form(this, privilegeEntity);
                //            hss00430Form.ShowDialog();
                //        }
                //        else
                //            CommonFunctions.MessageBoxDisplay(Consts.Messages.AplicantSelectionMsg);
                //    }
                //    else
                //    {
                //        CommonFunctions.MessageBoxDisplay(Consts.Messages.Applicantdoesntexist);
                //    }
                //    break;

                //case "EMS00030":
                //    EMS00030Control Ems30030control = new EMS00030Control(this, privilegeEntity);
                //    AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, Ems30030control);
                //    break;
                //case "TMSB0018":
                //    TMSB0018_ReCalc_Benefit Benefit_report = new TMSB0018_ReCalc_Benefit(this, privilegeEntity);
                //    Benefit_report.ShowDialog();
                //    break;
                //case "EMSB0008":
                //    EMSB0008_Presets Presets_report = new EMSB0008_Presets(this, privilegeEntity);
                //    Presets_report.ShowDialog();
                //    break;

                //case "TMS00301":
                //    if (!string.IsNullOrEmpty(BaseApplicationNo))
                //    {
                //        if (BaseTopApplSelect == "Y")
                //        {
                //            TMSB0030_ABCcalcControl CASE4006 = new TMSB0030_ABCcalcControl(this, privilegeEntity);
                //            AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, CASE4006);
                //        }
                //        else
                //            CommonFunctions.MessageBoxDisplay(Consts.Messages.AplicantSelectionMsg);
                //    }
                //    else
                //    {
                //        CommonFunctions.MessageBoxDisplay(Consts.Messages.Applicantdoesntexist);
                //    }
                //    break;
                //case "TMSB0022":
                //    TMSB0022Form tMSB0022Form = new TMSB0022Form(this, privilegeEntity);
                //    tMSB0022Form.ShowDialog();
                //    break;
                //case "TMSB0023":
                //    TMSB0023Form tMSB0023Form = new TMSB0023Form(this, privilegeEntity);
                //    tMSB0023Form.ShowDialog();
                //    break;
                //case "TMSB0024":
                //    TMSB0022Form tMSB2022Form = new TMSB0022Form(this, privilegeEntity);
                //    tMSB2022Form.ShowDialog();
                //    break;
                //case "TMSB3022":
                //    TMSB0022Form tMSB3022Form = new TMSB0022Form(this, privilegeEntity);
                //    tMSB3022Form.ShowDialog();
                //    break;
                //case "EMSB0021":
                //    EMSB0021_ActivityReport EMSB0021Form = new EMSB0021_ActivityReport(this, privilegeEntity);
                //    EMSB0021Form.ShowDialog();
                //    break;
                //case "TMSB0110":
                //    TMSB0110_Report TMSB0110Form = new TMSB0110_Report(this, privilegeEntity);
                //    TMSB0110Form.ShowDialog();
                //    break;
                //case "ARSB0130":
                //    ARSB2130_ReportForm Daycareexclusion = new ARSB2130_ReportForm(this, privilegeEntity);
                //    Daycareexclusion.ShowDialog();
                //    break;
                //case "FIXCLINT":
                //    FIXCLIENTForm fixClientForm = new FIXCLIENTForm(this, privilegeEntity);
                //    fixClientForm.ShowDialog();
                //    break;
                //case "FIXFAMID":
                //    FIXFAMILYIDForm fixfamidForm = new FIXFAMILYIDForm(this, privilegeEntity, string.Empty);
                //    fixfamidForm.ShowDialog();
                //    break;
                ////case "FIXFAMID":
                ////    FIXFAMILYIDForm2 fixfamidForm2 = new FIXFAMILYIDForm2(this, privilegeEntity, string.Empty);
                ////    fixfamidForm2.ShowDialog();
                ////    break;

                //case "FIXSSNUM":
                //    FIXSSNFORM fixSSNForm = new FIXSSNFORM(this, privilegeEntity);
                //    fixSSNForm.ShowDialog();
                //    break;
                //case "TMSB0012":
                //    TMSB0012_Report TMSB0012Form = new TMSB0012_Report(this, privilegeEntity);
                //    TMSB0012Form.ShowDialog();
                //    break;
                //case "EMSB0024":
                //    EMSB0024_ReportForm EMSB0024Form = new EMSB0024_ReportForm(this, privilegeEntity);
                //    EMSB0024Form.ShowDialog();
                //    break;
                //case "EMSB0004":
                //    EMSB0004_ReportForm EMSB0004Form = new EMSB0004_ReportForm(this, privilegeEntity);
                //    EMSB0004Form.ShowDialog();
                //    break;
                //case "EMSB0026":
                //    EMSB0026_SweepResources EMSB3026Form = new EMSB0026_SweepResources(this, privilegeEntity);
                //    EMSB3026Form.ShowDialog();
                //    break;
                //case "EMSB0009":
                //    EMSB0009_Report EMSB3009Form = new EMSB0009_Report(this, privilegeEntity);
                //    EMSB3009Form.ShowDialog();
                //    break;
                //case "EMSB0015":
                //    EMSB0015_ReportForm EMSB3015Form = new EMSB0015_ReportForm(this, privilegeEntity);
                //    EMSB3015Form.ShowDialog();
                //    break;
                //case "EMSB0002":
                //    EMSB0002_Report EMSB3002Form = new EMSB0002_Report(this, privilegeEntity);
                //    EMSB3002Form.ShowDialog();
                //    break;
                //case "EMSB0001":
                //    EMSB0001_Report EMSB3001Form = new EMSB0001_Report(this, privilegeEntity);
                //    EMSB3001Form.ShowDialog();
                //    break;
                //case "EMSB0025":
                //    EMSB0025_Report EMSB3025Form = new EMSB0025_Report(this, privilegeEntity);
                //    EMSB3025Form.ShowDialog();
                //    break;
                //case "TOOL0001":
                //    TOOL0001_ChangeReport SITEForm = new TOOL0001_ChangeReport(this, privilegeEntity);
                //    SITEForm.ShowDialog();
                //    break;
                //case "EMSB0023":
                //    EMSB0023_Report EMSB3023Form = new EMSB0023_Report(this, privilegeEntity);
                //    EMSB3023Form.ShowDialog();
                //    break;
                //case "EMSB0006":
                //    EMSB0006_Report EMSB3006Form = new EMSB0006_Report(this, privilegeEntity);
                //    EMSB3006Form.ShowDialog();
                //    break;
                //case "TMSBAPPB":
                //    TMSBAPPBReport tMSBAPPBReport = new TMSBAPPBReport(this, privilegeEntity);
                //    tMSBAPPBReport.ShowDialog();
                //    break;
                //case "ARSB0170":
                //    ARSB2170_ReportForm ARSb0170Form = new ARSB2170_ReportForm(this, privilegeEntity);
                //    ARSb0170Form.ShowDialog();
                //    break;
                //case "EMSB0027":
                //    EMSB0027_Report EMSB3027Form = new EMSB0027_Report(this, privilegeEntity);
                //    EMSB3027Form.ShowDialog();
                //    break;
                //case "TMSB0044":
                //    TMSB0044_Report TMSB0044Form = new TMSB0044_Report(this, privilegeEntity);
                //    TMSB0044Form.ShowDialog();
                //    break;
                //case "ARS00125":
                //    if (!string.IsNullOrEmpty(BaseApplicationNo))
                //    {
                //        if (BaseTopApplSelect == "Y")
                //        {
                //            List<ARSCUSTEntity> CustDetails = _model.ArsData.Browse_ARSCUST(BaseAgency, BaseDept, BaseProg, BaseApplicationNo.Trim(), string.Empty);
                //            if (CustDetails.Count > 0)
                //            {
                //                ARS00125Form ars0012form = new ARS00125Form(this, privilegeEntity);
                //                ars0012form.ShowDialog();
                //            }
                //            else MessageBox.Show("Customer not found in ARSCUST", "ARS00125");
                //        }
                //        else
                //            CommonFunctions.MessageBoxDisplay(Consts.Messages.AplicantSelectionMsg);
                //    }
                //    else
                //    {
                //        CommonFunctions.MessageBoxDisplay(Consts.Messages.Applicantdoesntexist);
                //    }
                //    break;
                //case "TMSTRIGG":
                //    CTTriggersControl CTTriggercontrol = new CTTriggersControl(this, privilegeEntity);
                //    AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, CTTriggercontrol);
                //    break;
                //case "RPMEMBER":
                //    ReportControl reportControl = new ReportControl(this, privilegeEntity, string.Empty);
                //    AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, reportControl);
                //    break;
                //case "RPINTAKE":
                //    ReportControl RPINTAKE = new ReportControl(this, privilegeEntity, "RPINTAKE");
                //    AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, RPINTAKE);
                //    break;
                //case "RPREPORT":
                //    ReportControl RPREPORT = new ReportControl(this, privilegeEntity, "RPREPORT");
                //    AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, RPREPORT);
                //    break;
                case "RPREPOR1":
                    ReportControl RPREPORT1 = new ReportControl(this, privilegeEntity, "RPREPORT1");
                    AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, RPREPORT1);
                    break;
                case "RPREPOR2":
                    ReportGridControl RPREPORT2 = new ReportGridControl(this, privilegeEntity, "RPREPORT2");
                    AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, RPREPORT2);
                    break;
                case "RPREPOR3":
                    ReportGridControl1 RPREPOR3 = new ReportGridControl1(this, privilegeEntity, "RPREPOR3");
                    AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, RPREPOR3);
                    break;
                //case "AGYXML":
                //    TMSB00AGYTABFORM AGYXML = new TMSB00AGYTABFORM(this, privilegeEntity);
                //    AGYXML.ShowDialog();
                //    break;
                //case "LPMQ0001":
                //    LPMQ0001_Report LPMQ0001Form = new LPMQ0001_Report(this, privilegeEntity);
                //    LPMQ0001Form.ShowDialog();
                //    break;
                //case "TRIGBULK":
                //    Trig_BulkPosting trigbulk = new Trig_BulkPosting(this, privilegeEntity);
                //    trigbulk.ShowDialog();
                //    break;
                //case "EMSB0028":
                //    EMSB0028_Report EMS0028Form = new EMSB0028_Report(this, privilegeEntity);
                //    EMS0028Form.ShowDialog();
                //    break;
                //case "EMSB2028":
                //    EMSB2028_Report EMS2028Form = new EMSB2028_Report(this, privilegeEntity);
                //    EMS2028Form.ShowDialog();
                //    break;
                //case "EMSB0029":
                //    EMSB0029_Report EMS0029Form = new EMSB0029_Report(this, privilegeEntity);
                //    EMS0029Form.ShowDialog();
                //    break;
                //case "ADMNB003":
                //    ADMNB003 ADMNB003Form = new ADMNB003(this, privilegeEntity);
                //    ADMNB003Form.ShowDialog();
                //    break;
                //case "HSSB0150":
                //    HSSB0150_Report HSSB00150Form = new HSSB0150_Report(this, privilegeEntity);
                //    HSSB00150Form.ShowDialog();
                //    break;
                //case "EMSUNLOK":
                //    EmsUnlockScreen EmsUnlockScreenform = new EmsUnlockScreen(this, privilegeEntity);
                //    EmsUnlockScreenform.ShowDialog();
                //    break;
                //case "TRIGPARA":
                //    Trigger_Params Trigger_ParamsForm = new Trigger_Params(this, privilegeEntity);
                //    Trigger_ParamsForm.ShowDialog();
                //    break;
                //case "ADMN0025":
                //    SSBGParams_Control SSBGParamscontrol = new SSBGParams_Control(this, privilegeEntity);
                //    AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, SSBGParamscontrol);
                //    break;
                //case "CASB0014":
                //    SSBG_Report SSBGRep = new SSBG_Report(this, privilegeEntity);
                //    SSBGRep.ShowDialog();
                //    break;
                //case "MATB0003":
                //    MATB0003_Form MATB0003Form = new MATB0003_Form(this, privilegeEntity); ;
                //    MATB0003Form.ShowDialog();
                //    break;
                //case "HLS00133":
                //    if (!UserProfile.Components.Contains("None"))
                //    {
                //        HLS00133_Control HLS00133 = new HLS00133_Control(this, privilegeEntity);
                //        AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, HLS00133);
                //    }
                //    else
                //    {
                //        CommonFunctions.MessageBoxDisplay("You can't Access any Component \n Please Contact Your System Administrator");
                //    }
                //    break;
                //case "SCHAUDIT":
                //    RIXMLADTControl RIXMLADT = new RIXMLADTControl(this, privilegeEntity);
                //    AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, RIXMLADT);
                //    break;
                //case "RNG00001":
                //    RNG00001 RNG00001 = new RNG00001(this, privilegeEntity);
                //    AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, RNG00001);
                //    break;
                //case "RNGB0004":
                //    RNGB0004Form RNGb0004Form = new RNGB0004Form(this, privilegeEntity); ;
                //    RNGb0004Form.ShowDialog();
                //    break;
                //case "RNGB0014":
                //    RNGB0014Form RNGb0014Form = new RNGB0014Form(this, privilegeEntity); ;
                //    RNGb0014Form.ShowDialog();
                //    break;
                //case "RNGS0014":
                //    RNGS0014 RNGS0014 = new RNGS0014(this, privilegeEntity); ;
                //    RNGS0014.ShowDialog();
                //    break;
                //case "ADMNCONT":
                //    AdminScreenControls ADMNCONT = new AdminScreenControls(this, privilegeEntity);
                //    AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, ADMNCONT);
                //    break;
                //case "HLS00134":
                //    if (!string.IsNullOrEmpty(BaseApplicationNo))
                //    {
                //        if (BaseTopApplSelect == "Y")
                //        {
                //            if (!UserProfile.Components.Contains("None"))
                //            {
                //                HLS00134Control HSS00134 = new HLS00134Control(this, privilegeEntity);
                //                AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, HSS00134);
                //            }
                //            else
                //            {
                //                CommonFunctions.MessageBoxDisplay("You can't Access any Component \n Please Contact Your System Administrator");
                //            }
                //        }
                //        else
                //            CommonFunctions.MessageBoxDisplay(Consts.Messages.AplicantSelectionMsg);
                //    }
                //    else
                //    {
                //        CommonFunctions.MessageBoxDisplay(Consts.Messages.Applicantdoesntexist);
                //    }
                //    break;
                //case "MERGFILE":
                //    PdfListForm pdfMergeListForm = new PdfListForm(this);
                //    pdfMergeListForm.ShowDialog();
                //    break;
                //case "ADMNB004":
                //    ADMNB004 ADMNB004Form = new ADMNB004(this, privilegeEntity);
                //    ADMNB004Form.ShowDialog();
                //    break;
                //case "DIMSCORE":
                //    DIMSCOREREPORT DIMSCOREREPORTForm = new DIMSCOREREPORT(this, privilegeEntity);
                //    DIMSCOREREPORTForm.ShowDialog();
                //    break;
                //case "HLSB0001":
                //    HLSB0001_Report HLSB0001Form = new HLSB0001_Report(this, privilegeEntity);
                //    HLSB0001Form.ShowDialog();
                //    break;
                //case "AGYXMLRG":
                //    TMSB00AGYTABFORM AGRNGXML = new TMSB00AGYTABFORM(this, privilegeEntity);
                //    AGRNGXML.ShowDialog();
                //    break;
                //case "CASE0005":
                //    CASE0006CLOSESCREEN CASE0006CLOSESCREENFrom = new CASE0006CLOSESCREEN(this, privilegeEntity);
                //    CASE0006CLOSESCREENFrom.ShowDialog();
                //    break;
                //case "TMSB0026":
                //    TMSB0026_Report TMSB0026_Report = new TMSB0026_Report(this, privilegeEntity);
                //    TMSB0026_Report.ShowDialog();
                //    break;
                //case "CASB0008":
                //    CASB0008 CASB0008_Report = new CASB0008(this, privilegeEntity);
                //    CASB0008_Report.ShowDialog();
                //    break;
                //case "CUST0001":
                //    if (BaseAgencyControlDetails.SpanishSwitch == "Y")
                //    {
                //        SpanishCustomQuestions spanishForm = new SpanishCustomQuestions(this, privilegeEntity, string.Empty, "CUSTOM");
                //        spanishForm.ShowDialog();
                //    }
                //    else
                //    {
                //        CommonFunctions.MessageBoxDisplay("AGENCY CONTROL SPANISH SWITCH NOT DEFINED");
                //    }
                //    break;
                //case "PIPADMIN":
                //    try
                //    {
                //        SqlConnection connect = new SqlConnection();
                //        connect.ConnectionString = this.BaseLeanDataBaseConnectionString;
                //        connect.Open();
                //        if (connect.State == ConnectionState.Open)
                //        {
                //            connect.Close();
                //            PIPAdmin pipAdminForm = new PIPAdmin(this, privilegeEntity, string.Empty, "CUSTOM");
                //            pipAdminForm.ShowDialog();
                //        }

                //        else { MessageBox.Show("Connection issue with Server \n Please contact CAPSYSTEMS INC", "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                //    }
                //    catch (Exception)
                //    {

                //        MessageBox.Show("Connection issue with Server \n Please contact CAPSYSTEMS INC", "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    }

                //    break;
                //case "LAGY0001":
                //    if (BaseAgencyControlDetails.SpanishSwitch == "Y")
                //    {
                //        SpanishCustomQuestions spanishForm = new SpanishCustomQuestions(this, privilegeEntity, string.Empty, "LEANAGYTABS");
                //        spanishForm.ShowDialog();
                //    }
                //    else
                //    {
                //        CommonFunctions.MessageBoxDisplay("AGENCY CONTROL SPANISH SWITCH NOT DEFINED");
                //    }
                //    break;
                //case "CASEHIE1":
                //    SpanishCustomQuestions spanishhieForm = new SpanishCustomQuestions(this, privilegeEntity, string.Empty, "CASEHIE");
                //    spanishhieForm.ShowDialog();

                //    break;
                //case "CAMAST01":
                //    SpanishCustomQuestions spanishCAMASTForm = new SpanishCustomQuestions(this, privilegeEntity, string.Empty, "CAMAST");
                //    spanishCAMASTForm.ShowDialog();
                //    break;
                //case "LEANMESS":
                //    PIPEmailForm pipEmailForm = new PIPEmailForm(this, privilegeEntity);
                //    pipEmailForm.ShowDialog();
                //    break;
                //case "PIPB0001":
                //    PIPB0003 PIPB003Form = new PIPB0003(this, privilegeEntity);
                //    PIPB003Form.ShowDialog();
                //    break;
                //case "PIPB0002":
                //    PIPB0004 PIPB004Form = new PIPB0004(this, privilegeEntity);
                //    PIPB004Form.ShowDialog();
                //    break;
                //case "PIPB0005":
                //    PIPB0005 PIPB005Form = new PIPB0005(this, privilegeEntity);
                //    PIPB005Form.ShowDialog();
                //    break;
                ////case "CASE0023":
                ////    VouchGen_Control VouchControl = new VouchGen_Control(this, privilegeEntity);
                ////    AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, VouchControl);
                ////    break;
                //case "ADMN0023":
                //    VoucherDefinitionControl VouchDefControl = new VoucherDefinitionControl(this, privilegeEntity);
                //    AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, VouchDefControl);
                //    break;
                //case "ADMN0022":
                //    ADMN0022Control ADMN0022 = new ADMN0022Control(this, privilegeEntity);
                //    AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, ADMN0022);
                //    break;
                //case "CASB0009":
                //    CASB0009_Report CASB0009_Report = new CASB0009_Report(this, privilegeEntity);
                //    CASB0009_Report.ShowDialog();
                //    break;
                //case "TMS10100":
                //    TMS10100 tms10100 = new TMS10100(this, privilegeEntity);
                //    AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, tms10100);
                //    break;
                //case "APPT0001":
                //    TMS20100 tms20100 = new TMS20100(this, privilegeEntity);
                //    AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, tms20100);
                //    break;
                //case "TMS10110":
                //    TMS10110Control TMS10110 = new TMS10110Control(this, privilegeEntity);
                //    AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, TMS10110);
                //    break;
                //case "TMS10120":
                //    TMS00120Control TMS10120 = new TMS00120Control(this, privilegeEntity);
                //    AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, TMS10120);
                //    break;
                //case "APPT0003":
                //    APPT0003Control APPT0003 = new APPT0003Control(this, privilegeEntity);
                //    AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, APPT0003);
                //    break;
                //case "APPT0002":
                //    APPT0002Control APPT0002 = new APPT0002Control(this, privilegeEntity);
                //    AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, APPT0002);
                //    break;
                //case "ADMN0011":
                //    AGCYPARTControl AgencyPartner = new AGCYPARTControl(this, privilegeEntity);
                //    AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, AgencyPartner);
                //    break;
                //case "APPTB001":
                //    APPTB001_Report APPTB001Form = new APPTB001_Report(this, privilegeEntity);
                //    APPTB001Form.ShowDialog();
                //    break;
                //case "MATB1002":
                //    MATB1002_Form MATB1002Form = new MATB1002_Form(this, privilegeEntity); ;
                //    MATB1002Form.ShowDialog();
                //    break;
                //case "ADMN0014":
                //    ADMN0014SettingsForm admn0014Settings = new ADMN0014SettingsForm(this, privilegeEntity); ;
                //    admn0014Settings.ShowDialog();
                //    break;
                //case "CASE0013":
                //    if (!string.IsNullOrEmpty(BaseApplicationNo))
                //    {
                //        if (BaseTopApplSelect == "Y")
                //        {
                //            CASE0013Control CASE0013 = new CASE0013Control(this, privilegeEntity);
                //            AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, CASE0013);
                //        }
                //        else
                //            CommonFunctions.MessageBoxDisplay(Consts.Messages.AplicantSelectionMsg);
                //    }
                //    else
                //    {
                //        CommonFunctions.MessageBoxDisplay(Consts.Messages.Applicantdoesntexist);
                //    }
                //    break;
                //case "EMS00050":
                //    EMS00050Control Ems30050control = new EMS00050Control(this, privilegeEntity);
                //    AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, Ems30050control);
                //    break;
                //case "ADMN0024":
                //    ADMN0024Control Admn0024control = new ADMN0024Control(this, privilegeEntity);
                //    AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, Admn0024control);
                //    break;
                //case "TMSB0027":
                //    TMSB0027_DeniedReport TMSB0027_Report = new TMSB0027_DeniedReport(this, privilegeEntity);
                //    TMSB0027_Report.ShowDialog();
                //    break;
                //case "PIP00001":
                //    if (!string.IsNullOrEmpty(BaseApplicationNo))
                //    {
                //        if (BaseTopApplSelect == "Y")
                //        {
                //            PIP00001Form _PIP00001Form = new PIP00001Form(this, privilegeEntity, this.BaseAgency, this.BaseDept, this.BaseProg, this.BaseYear, this.BaseApplicationNo, string.Empty, string.Empty);
                //            _PIP00001Form.ShowDialog();
                //        }
                //        else
                //            CommonFunctions.MessageBoxDisplay(Consts.Messages.AplicantSelectionMsg);
                //    }
                //    else
                //    {
                //        CommonFunctions.MessageBoxDisplay(Consts.Messages.Applicantdoesntexist);
                //    }
                //    break;
                //case "TMS00085":
                //    TMSELIG_Control TMS00085control = new TMSELIG_Control(this, privilegeEntity);
                //    AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, TMS00085control);
                //    break;

                //case "PIP00000":
                //    try
                //    {
                //        SqlConnection connect = new SqlConnection();
                //        connect.ConnectionString = this.BaseLeanDataBaseConnectionString;
                //        connect.Open();
                //        if (connect.State == ConnectionState.Open)
                //        {
                //            connect.Close();
                //            PIP00000Control pIP00000Control = new PIP00000Control(this, privilegeEntity);
                //            AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, pIP00000Control);
                //        }

                //        else { MessageBox.Show("Connection issue with Server \n Please contact CAPSYSTEMS INC", "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                //    }
                //    catch (Exception)
                //    {

                //        MessageBox.Show("Connection issue with Server \n Please contact CAPSYSTEMS INC", "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    }
                //    break;
                //case "CASE0025":
                //    if (UserProfile.EMS_Access == "S" || UserProfile.EMS_Access == "D")
                //    {
                //        if (BaseAgencyControlDetails.PaymentCategorieService == "Y")
                //        {
                //            ProgramDefinitionEntity programEntity = _model.HierarchyAndPrograms.GetCaseDepadp(BaseAgency, BaseDept, BaseProg);

                //            if (programEntity != null)
                //            {
                //                if (programEntity.DepSerpostPAYCAT != string.Empty)
                //                {
                //                    CASE0025Control _case0025control = new CASE0025Control(this, privilegeEntity);
                //                    AddContentTab(privilegeEntity.PrivilegeName.Trim(), privilegeEntity.Program, _case0025control);
                //                }
                //                else
                //                {
                //                    CommonFunctions.MessageBoxDisplay("This Program is not set for Payment Category");
                //                }
                //            }
                //        }
                //    }
                //    else
                //    {
                //        CommonFunctions.MessageBoxDisplay("You are not Authorized to Operate this Screen. Contact Your Administrator");
                //    }
                //    break;
                //case "CASB0015":

                //    if (UserProfile.EMS_Access == "S" || UserProfile.EMS_Access == "D")
                //    {
                //        CASB0015_Form CASB0015_Report = new CASB0015_Form(this, privilegeEntity);
                //        CASB0015_Report.ShowDialog();
                //    }
                //    else
                //    {
                //        CommonFunctions.MessageBoxDisplay("You are not Authorized to Operate this Report. Contact Your Administrator");
                //    }
                //    break;
                //case "CASBLTRB":

                //    if (UserProfile.EMS_Access == "S" || UserProfile.EMS_Access == "D")
                //    {
                //        CASBLTRB CASBLTRB_Report = new CASBLTRB(this, privilegeEntity);
                //        CASBLTRB_Report.ShowDialog();
                //    }
                //    else
                //    {
                //        CommonFunctions.MessageBoxDisplay("You are not Authorized to Operate this Report. Contact Your Administrator");
                //    }
                //    break;
                //case "ADMNB005":
                //    try
                //    {
                //        SqlConnection connect = new SqlConnection();
                //        connect.ConnectionString = this.BaseLeanDataBaseConnectionString;
                //        connect.Open();
                //        if (connect.State == ConnectionState.Open)
                //        {
                //            connect.Close();
                //            ADMNB005 ADMNB005_Report = new ADMNB005(this, privilegeEntity);
                //            ADMNB005_Report.ShowDialog();
                //        }

                //        else { MessageBox.Show("Connection issue with Server \n Please contact CAPSYSTEMS INC", "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                //    }
                //    catch (Exception)
                //    {

                //        MessageBox.Show("Connection issue with Server \n Please contact CAPSYSTEMS INC", "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    }
                //    break;
                //case "EMSB1009":
                //    EMSB1009_Report EMSB1009Form = new EMSB1009_Report(this, privilegeEntity);
                //    EMSB1009Form.ShowDialog();
                //    break;
                default:
                    HelpForm2 helpForm = new HelpForm2();
                    //FrmUploadFtp helpForm = new FrmUploadFtp();
                    helpForm.ShowDialog();
                    Consts.Messages.UserCreatedSuccesssfully.DisplayFirendlyMessage(Captain.Common.Exceptions.ExceptionSeverityLevel.Information);
                    break;
            }


        }

        public override void OnProcessMenuItemEvents(object sender, MenuManagerEventArgs e)
        {
            try
            {
                MenuItem menuItem = (MenuItem)sender;
                switch (menuItem.Text)
                {
                    case "Change Password":
                        //ChangePassword changePassword = new ChangePassword(this);
                        //changePassword.ShowDialog();
                        break;
                    case "Captain Help":
                        Help.ShowHelp(this, Context.Server.MapPath("~\\Resources\\HelpFiles\\Captain_Help.chm"));
                        break;
                }
            }
            catch (Exception ex)
            {
                StackFrame stackFrame = new StackFrame();
                ExceptionLogger.LogAndDisplayMessageToUser(stackFrame, ex, QuantumFaults.None, ExceptionSeverityLevel.High);
            }
        }

        /// <summary>
        /// MainForm_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 

        //static int sInstanceCount = 0;
        private void OnMainFormLoad(object sender, EventArgs e)
        {
            //if ((Context.HttpContext.Request.QueryString["vwginstance"].ToString() == "0"))
            //{
            //    sInstanceCount++;
            //    Context.Redirect(("MainForm.wgx?vwginstance=" + sInstanceCount.ToString()));
            //    Context.Terminate(true);
            //    return;
            //}

            UserEntity userInfo = Captain<UserEntity>.Session[Consts.SessionVariables.UserProfile];
            string fullName = Captain<string>.Session[Consts.SessionVariables.UserID];
            lblWelcomeUser.Text = string.Concat(Consts.Controls.Welcome.GetControlName(), Consts.Common.Comma, Consts.Common.Space, fullName);

            LblLogin_details.Text = string.Concat("Previous Login was " + Captain<string>.Session[Consts.SessionVariables.LostLogin_Status], Consts.Common.Comma, " On  ", Captain<string>.Session[Consts.SessionVariables.LostLogin_Date]);
            if ((BusinessModuleID != Consts.Applications.Code.Administration) && (BusinessModuleID != Consts.Applications.Code.DashBoard))
            {
                if (BaseAgency == null || BaseAgency == string.Empty || _defaultHierchyform == true)
                {
                    //AdvancedMainMenuSearch advancedMainMenuSearch = new AdvancedMainMenuSearch(this, false, true);
                    //advancedMainMenuSearch.FormClosed += new Form.FormClosedEventHandler(On_ADV_SerachFormClosed);
                    //advancedMainMenuSearch.ShowDialog();
                }
            }
            if (userInfo.Successful.Equals("0"))
            {
                //ChangePassword changePassword = new ChangePassword(this, string.Empty);
                //changePassword.ShowDialog();
            }
            else
            {
                if (userInfo.PWDChangeDate != string.Empty)
                {
                    AgencyControlEntity agencycontroldata = _model.ZipCodeAndAgency.GetAgencyControlFile("00");
                    if (agencycontroldata != null)
                    {
                        if (agencycontroldata.ForcePwd.ToUpper() == "Y")
                        {
                            DateTime dt = Convert.ToDateTime(userInfo.PWDChangeDate).Date;
                            DateTime dtnew = DateTime.Now.Date;
                            int intdif = (dtnew - dt).Days;
                            if (intdif > Convert.ToInt32(agencycontroldata.ForcePwdDays))
                            {
                                //ChangePassword changePassword = new ChangePassword(this, string.Empty);
                                //changePassword.ShowDialog();
                            }
                        }
                    }
                }

            }
        }

        /// <summary>
        /// Called when a preference in the options form is updated.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void OnOptionsFormOnPreferanceUpdate(object sender, EventArgs args)
        {
            //StartPage.LoadStartPage();
        }

        /// <summary>
        /// Refreshes the tree at specified intervals.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnAutoRefreshTick(object sender, EventArgs e)
        {
            //
        }

        /// <summary>
        /// Handles the help click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnHelpClick(object sender, EventArgs e)
        {
            try
            {
                Help.ShowHelp(this, Context.Server.MapPath("~\\Resources\\HelpFiles\\Captain_Help.chm"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + Context.Server.MapPath("\\Resources\\HelpFiles\\Captain_Help.chm"));
            }
        }

        /// <summary>
        /// Handles the logout click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLogoutClick(object sender, EventArgs e)
        {
            if (Session["userlogid"] != null)
            {

                _model.UserProfileAccess.InsertUpdateLogUsers(string.Empty, string.Empty, string.Empty, "Edit", Session["userlogid"].ToString());
            }
            Context.Session.IsLoggedOn = false;
            HttpContext.Current.Session.Clear();



            Context.Terminate(true);
            // Context.Redirect(Context.HostContext.HttpContext.Request.UrlReferrer.ToString());
            Context.Redirect(System.IO.Path.Combine(HttpContext.Current.Request.ApplicationPath, Context.HostContext.Request.Info.PageName).Replace("\\", "/") + Context.Config.GetFeatureValue("Extension", ".wgx"));
            // Context.Redirect("/Default.aspx");
        }

        /// <summary>
        /// Handles the content tab onclose clicked event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void OnContentTabsCloseClicked(object sender, EventArgs e)
        {
            try
            {
                if (ContentTabs.SelectedItem.Text.Equals("MainMenu Search"))
                {
                    return;
                }
                if (ContentTabs.TabPages.Count == 1)
                {
                    AddWelcomeScreen(this.pnlTabs);
                    NavigationTreeView.SelectedNode = null;
                }
                MainToolbar.Buttons.Clear();

                CloseSelectedContentTab();
            }
            catch (Exception ex)
            {
                StackFrame stackFrame = new StackFrame();
                //ExceptionLogger.LogAndDisplayMessageToUser(stackFrame, ex, QuantumFaults.None, ExceptionSeverityLevel.High);
            }
        }

        /// <summary>
        /// Handles the content tab selected index changed event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnContentTabsSelectedIndexChanged(object sender, EventArgs e)
        {
            UserEntity userInfo = Captain<UserEntity>.Session[Consts.SessionVariables.UserProfile];
            try
            {
                if (BusinessModuleID != "01")
                    MainToolbar.Buttons.Clear();  // Rao

                int intSelect = ContentTabs.SelectedIndex;
                if (intSelect >= 0 || BusinessModuleID == "01")  // (intSelect > 0 )  No need to check the condition - Changed by Yeswanth on 02/04/2013
                {
                    CurrentTabPage = (WorkspaceTab)ContentTabs.TabPages[intSelect];
                    if (CurrentTabPage.Tag == null)
                    {
                        MainToolbar.Buttons.Clear();
                        return;
                    }

                    string tagClass = null;
                    if (CurrentTabPage.Tag is string)
                    {
                        tagClass = (string)CurrentTabPage.Tag;
                    }

                    if (tagClass != null)
                    {

                        MainToolbar.Buttons.Clear();
                        ContentTabs.ShowCloseButton = true;

                        BaseUserControl baseUserControl = GetBaseUserControl();
                        if (baseUserControl != null)
                        {
                            baseUserControl.PopulateToolbar(MainToolbar);
                            if (baseUserControl is MainMenuControl)
                            {
                                (baseUserControl as MainMenuControl).RefreshMainMenu();
                            }
                            
                            if (baseUserControl is Case3001Control)
                            {
                                (baseUserControl as Case3001Control).Refresh();
                            }
                            

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                StackFrame stackFrame = new StackFrame();
                //ExceptionLogger.LogAndDisplayMessageToUser(stackFrame, ex, QuantumFaults.None, ExceptionSeverityLevel.High);
            }
        }

        /// <summary>
        /// Called when a navigation tab is selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnNavigationTabsSelectedIndexChanged(object sender, EventArgs e)
        {
            string messagesName = string.Empty;

            NavigationTreeView.Nodes.Clear();
            NavigationTreeView.SelectedNode = null;

            try
            {
                MainToolbar.Buttons.Clear();
                ContentTabs.TabPages.Clear();
                AddWelcomeScreen(pnlTabs);

                //InvokeMethodWithId(Consts.Javascript.ExecuteParentChildMethod, new object[] { Consts.Javascript.PDFControl, Consts.Javascript.SetDisplayToNoneCode, Consts.Javascript.CloseAllDcoumentsCode });

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
                    case Consts.Applications.Code.AgencyPartner:
                        InitializeModule("MiddleBanner.gif", TreeType.AgencyPartner);
                        break;
                }

                //GenerateMenus(ref mainMenu, string.Empty);
                // pnlMainMenu.Controls.Add(mainMenu);
                // mainMenu.Location = new System.Drawing.Point(70, 3);
                // mainMenu.Dock = DockStyle.None;
                // mainMenu.Update();

                SetLogoBanner();
            }
            catch (Exception ex)
            {
                StackFrame stackFrame = new StackFrame();
                //ExceptionLogger.LogAndDisplayMessageToUser(stackFrame, ex, QuantumFaults.None, ExceptionSeverityLevel.High);
            }
        }


        /// <summary>
        /// Handles the history clicked event
        /// </summary>
        /// <param name="e"></param>
        public void OnHistoryClicked(TreeNodeMouseClickEventArgs e)
        {
            TagClass tagClass = null;
            tagClass = (TagClass)e.Node.Tag;
            OpenContentTab(tagClass);
        }

        #endregion

        private void MainToolbar_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {

        }

        private void lblWelcomeUser_Click(object sender, EventArgs e)
        {

        }

        private void lnktabview_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lnktabview.Text == "Hide Tree")
            {
                splitContainer.SplitterDistance = 0;
                lnktabview.Text = "View Tree";
            }
            else
            {
                splitContainer.SplitterDistance = 255;
                lnktabview.Text = "Hide Tree";

            }

        }

        private void lblChangePassword_Click(object sender, EventArgs e)
        {
            //ChangePassword changePassword = new ChangePassword(this);
            //changePassword.ShowDialog();
        }

        private void MainmenuAddTab()
        {
            MainMenuControl mainMenuControl = new MainMenuControl(this);
            AddContentTab("MainMenu Search", "MainMenu", mainMenuControl);

            pnlSearch.Controls.Add(hierachyNamecontrol);

            hierachyNamecontrol.Location = new System.Drawing.Point(200, 6);
            hierachyNamecontrol.Name = "hierachykeycontrol";
            hierachyNamecontrol.Size = new System.Drawing.Size(720, 20);

            pnlButtonBar.Controls.Add(applicationNameControl);

            applicationNameControl.Location = new System.Drawing.Point(225, 4);
            applicationNameControl.Name = "applicationNameControl";
            applicationNameControl.Size = new System.Drawing.Size(825, 20);
            applicationNameControl.lblApplicationName.Visible = true;
            applicationNameControl.Dock = Gizmox.WebGUI.Forms.DockStyle.None;



        }



        public void ShowHierachyandApplNo(string strAgency, string strDept, string strProg, string strYear1, string strApplicationNo, string strAppDisplay)
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
                BaseApplicationNo = strApplNo;
                caseSnpEntity = _model.CaseMstData.GetCaseSnpadpyn(strAgency, strDept, strProg, strYear, strApplNo);
                //string strAgencyName = strAgency + " - " + _model.lookupDataAccess.GetHierachyDescription("1", strAgency, strDept, strProg);
                //string strDeptName = strDept + " - " + _model.lookupDataAccess.GetHierachyDescription("2", strAgency, strDept, strProg);
                //string strProgName = strProg + " - " + _model.lookupDataAccess.GetHierachyDescription("3", strAgency, strDept, strProg);
                ////GetApplicantDetails(caseMstEntity, caseSnpEntity, strAgencyName, strDeptName, strProgName, strYear.ToString());

            }
            else
            {
                BaseApplicationNo = string.Empty; // null; Modified by Yeswanth on 01052013

                //////string strAgencyName = strAgency + " - " + _model.lookupDataAccess.GetHierachyDescription("1", strAgency, strDept, strProg);
                //////string strDeptName = strDept + " - " + _model.lookupDataAccess.GetHierachyDescription("2", strAgency, strDept, strProg);
                //////string strProgName = strProg + " - " + _model.lookupDataAccess.GetHierachyDescription("3", strAgency, strDept, strProg);

                //GetApplicantDetails(caseMstEntity, caseSnpEntity, strAgencyName, strDeptName, strProgName, strYear.ToString());
            }
            GetApplicantDetails(caseMstEntity, caseSnpEntity, strAgencyName, strDeptName, strProgName, strYear.ToString(), string.Empty, strAppDisplay);
        }





        private void On_ADV_SerachFormClosed(object sender, FormClosedEventArgs e)
        {
            //AdvancedMainMenuSearch form = sender as AdvancedMainMenuSearch;
            //if (form.DialogResult == DialogResult.OK)
            //{
            //    string Selected_App_key = null;
            //    Selected_App_key = form.GetSelectedApplicant();
            //    if (!string.IsNullOrEmpty(Selected_App_key))
            //    {
            //        BaseAgency = Selected_App_key.Substring(0, 2);
            //        BaseDept = Selected_App_key.Substring(2, 2);
            //        BaseProg = Selected_App_key.Substring(4, 2);
            //        BaseYear = (Selected_App_key.Length >= 10 ? Selected_App_key.Substring(6, 4) : "    ");
            //        BaseApplicationNo = (Selected_App_key.Length == 18 ? Selected_App_key.Substring(10, 8) : string.Empty);
            //        BaseTopApplSelect = (Selected_App_key.Length == 18 ? "Y" : "N");
            //        //MainmenuAddTab();
            //        //ShowHierachyandApplNo(BaseAgency, BaseDept, BaseProg, BaseYear, BaseApplicationNo, "Display");
            //        MainMenuControl MainMenu_Control = this.GetBaseUserControl() as MainMenuControl;
            //        //if (MainMenu_Control != null)
            //        MainMenu_Control.Set_DefHie_as_BaseHie(BaseAgency, BaseDept, BaseProg, BaseYear);
            //        TreeViewControllerParameter treeViewControllerParameter = new TreeViewControllerParameter()
            //        {
            //            TreeType = TreeType.CaseManagement,
            //            TreeView = NavigationTreeView,
            //            Hierarchy = BaseAgency + BaseDept + BaseProg
            //        };
            //        GetTreeView(treeViewControllerParameter);
            //    }
            //}

        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //
        }

        private void lnkAllClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.RemoveTabPages(string.Empty);
        }



    }
}
