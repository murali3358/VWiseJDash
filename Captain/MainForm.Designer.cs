namespace Captain
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pnlBanner = new Gizmox.WebGUI.Forms.Panel();
            this.pnlMiddleBanner = new Gizmox.WebGUI.Forms.Panel();
            this.LblLogin_details = new Gizmox.WebGUI.Forms.Label();
            this.lblWelcomeUser = new Gizmox.WebGUI.Forms.Label();
            this.pnlRightBanner = new Gizmox.WebGUI.Forms.Panel();
            this.lblChangePassword = new Gizmox.WebGUI.Forms.Label();
            this.lblHelp = new Gizmox.WebGUI.Forms.Label();
            this.lblLogout = new Gizmox.WebGUI.Forms.Label();
            this.pnlLeftBanner = new Gizmox.WebGUI.Forms.Panel();
            this.splitContainer = new Gizmox.WebGUI.Forms.SplitContainer();
            this.pnlApplicationHeader = new Gizmox.WebGUI.Forms.Panel();
            this.pnlApplicationHeaderImage = new Gizmox.WebGUI.Forms.Panel();
            this.pnlSmallBanner = new Gizmox.WebGUI.Forms.Panel();
            this.pnlSmallBannerLogo = new Gizmox.WebGUI.Forms.Panel();
            this.pnlTabs = new Gizmox.WebGUI.Forms.Panel();
            this.pnlButtonBar = new Gizmox.WebGUI.Forms.Panel();
            this.pnlMenuSearch = new Gizmox.WebGUI.Forms.Panel();
            this.pnlMainMenu = new Gizmox.WebGUI.Forms.Panel();
            this.lnkAllClose = new Gizmox.WebGUI.Forms.LinkLabel();
            this.lnktabview = new Gizmox.WebGUI.Forms.LinkLabel();
            this.pnlSearch = new Gizmox.WebGUI.Forms.Panel();
            this.lblAgency = new Gizmox.WebGUI.Forms.Label();
            this.tabWelcome = new Gizmox.WebGUI.Forms.NavigationTab();
            this.tabAdministration = new Gizmox.WebGUI.Forms.NavigationTab();
            this.tabHeadStart = new Gizmox.WebGUI.Forms.NavigationTab();
            this.tabCaseManagement = new Gizmox.WebGUI.Forms.NavigationTab();
            this.tabEnergyRI = new Gizmox.WebGUI.Forms.NavigationTab();
            this.tabEnergyCT = new Gizmox.WebGUI.Forms.NavigationTab();
            this.tabAccountsReceivable = new Gizmox.WebGUI.Forms.NavigationTab();
            this.tabEmergencyAssistance = new Gizmox.WebGUI.Forms.NavigationTab();
            this.tabHousingWeatherization = new Gizmox.WebGUI.Forms.NavigationTab();
            this.tabDashBoard = new Gizmox.WebGUI.Forms.NavigationTab();
            this.tabHealthyStart = new Gizmox.WebGUI.Forms.NavigationTab();
            this.tabAgencypartner = new Gizmox.WebGUI.Forms.NavigationTab();
            this.treeMenu = new Gizmox.WebGUI.Forms.ContextMenu();
            this.pnlParent = new Gizmox.WebGUI.Forms.Panel();
            this.picBacground = new Gizmox.WebGUI.Forms.PictureBox();
            this.mainMenu = new Gizmox.WebGUI.Forms.MainMenu();
            this.obsoleteLinkContextMenu = new Gizmox.WebGUI.Forms.ContextMenu();
            this.toolBarButton1 = new Gizmox.WebGUI.Forms.ToolBarButton();
            ((System.ComponentModel.ISupportInitialize)(this.ContentTabs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NavigationTabs)).BeginInit();
            this.pnlBanner.SuspendLayout();
            this.pnlMiddleBanner.SuspendLayout();
            this.pnlRightBanner.SuspendLayout();
            this.pnlApplicationHeader.SuspendLayout();
            this.pnlSmallBanner.SuspendLayout();
            this.pnlTabs.SuspendLayout();
            this.pnlButtonBar.SuspendLayout();
            this.pnlMenuSearch.SuspendLayout();
            this.pnlMainMenu.SuspendLayout();
            this.pnlParent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBacground)).BeginInit();
            this.SuspendLayout();
            // 
            // NavigationTreeView
            // 
            this.NavigationTreeView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(228)))), ((int)(((byte)(240)))));
            this.NavigationTreeView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.NavigationTreeView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(51)))), ((int)(((byte)(101)))));
            this.NavigationTreeView.Size = new System.Drawing.Size(310, 579);
            this.NavigationTreeView.TabIndex = 0;
            this.NavigationTreeView.NodeMouseClick += new Gizmox.WebGUI.Forms.TreeNodeMouseClickEventHandler(this.OnTreeViewClick);
            // 
            // ContentTabs
            // 
            this.ContentTabs.Alignment = Gizmox.WebGUI.Forms.TabAlignment.Top;
            this.ContentTabs.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ContentTabs.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.ContentTabs.Size = new System.Drawing.Size(795, 632);
            this.ContentTabs.TabIndex = 2;
            this.ContentTabs.CloseClick += new System.EventHandler(this.OnContentTabsCloseClicked);
            this.ContentTabs.SelectedIndexChanged += new System.EventHandler(this.OnContentTabsSelectedIndexChanged);
            // 
            // NavigationTabs
            // 
            this.NavigationTabs.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.NavigationTabs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NavigationTabs.ForeColor = System.Drawing.Color.White;
            this.NavigationTabs.Location = new System.Drawing.Point(0, 116);
            this.NavigationTabs.Size = new System.Drawing.Size(225, 659);
            this.NavigationTabs.TabIndex = 0;
            this.NavigationTabs.SelectedIndexChanged += new System.EventHandler(this.OnNavigationTabsSelectedIndexChanged);
            // 
            // MainToolbar
            // 
            this.MainToolbar.Appearance = Gizmox.WebGUI.Forms.ToolBarAppearance.Flat;
            this.MainToolbar.BackColor = System.Drawing.Color.Gainsboro;
            this.MainToolbar.Buttons.AddRange(new Gizmox.WebGUI.Forms.ToolBarButton[] {
            this.toolBarButton1});
            this.MainToolbar.Size = new System.Drawing.Size(795, 27);
            this.MainToolbar.TabIndex = 0;
            this.MainToolbar.ButtonClick += new Gizmox.WebGUI.Forms.ToolBarButtonClickEventHandler(this.MainToolbar_ButtonClick);
            // 
            // NoTabs
            // 
            this.NoTabs.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Clear;
            // 
            // pnlBanner
            // 
            this.pnlBanner.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Clear;
            this.pnlBanner.Controls.Add(this.pnlMiddleBanner);
            this.pnlBanner.Controls.Add(this.pnlRightBanner);
            this.pnlBanner.Controls.Add(this.pnlLeftBanner);
            this.pnlBanner.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.pnlBanner.ExcludeFromUniqueId = false;
            this.pnlBanner.Location = new System.Drawing.Point(0, 0);
            this.pnlBanner.Name = "pnlBanner";
            this.pnlBanner.NextFocusId = ((long)(0));
            this.pnlBanner.PerformLayoutEnabled = true;
            this.pnlBanner.PreviousFocusId = ((long)(0));
            this.pnlBanner.Size = new System.Drawing.Size(1024, 60);
            this.pnlBanner.TabIndex = 0;
            // 
            // pnlMiddleBanner
            // 
            this.pnlMiddleBanner.BackgroundImage = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("pnlMiddleBanner.BackgroundImage"));
            this.pnlMiddleBanner.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Clear;
            this.pnlMiddleBanner.Controls.Add(this.LblLogin_details);
            this.pnlMiddleBanner.Controls.Add(this.lblWelcomeUser);
            this.pnlMiddleBanner.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.pnlMiddleBanner.ExcludeFromUniqueId = false;
            this.pnlMiddleBanner.Location = new System.Drawing.Point(143, 0);
            this.pnlMiddleBanner.Name = "pnlMiddleBanner";
            this.pnlMiddleBanner.NextFocusId = ((long)(0));
            this.pnlMiddleBanner.PerformLayoutEnabled = true;
            this.pnlMiddleBanner.PreviousFocusId = ((long)(0));
            this.pnlMiddleBanner.RightToLeft = Gizmox.WebGUI.Forms.RightToLeft.Yes;
            this.pnlMiddleBanner.Size = new System.Drawing.Size(473, 60);
            this.pnlMiddleBanner.TabIndex = 2;
            // 
            // LblLogin_details
            // 
            this.LblLogin_details.ExcludeFromUniqueId = false;
            this.LblLogin_details.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblLogin_details.ForeColor = System.Drawing.Color.White;
            this.LblLogin_details.Location = new System.Drawing.Point(77, 20);
            this.LblLogin_details.Name = "LblLogin_details";
            this.LblLogin_details.NextFocusId = ((long)(0));
            this.LblLogin_details.PerformLayoutEnabled = true;
            this.LblLogin_details.PreviousFocusId = ((long)(0));
            this.LblLogin_details.Size = new System.Drawing.Size(377, 25);
            this.LblLogin_details.TabIndex = 1;
            this.LblLogin_details.Text = "...";
            this.LblLogin_details.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblWelcomeUser
            // 
            this.lblWelcomeUser.ExcludeFromUniqueId = false;
            this.lblWelcomeUser.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcomeUser.ForeColor = System.Drawing.Color.White;
            this.lblWelcomeUser.Location = new System.Drawing.Point(77, 0);
            this.lblWelcomeUser.Name = "lblWelcomeUser";
            this.lblWelcomeUser.NextFocusId = ((long)(0));
            this.lblWelcomeUser.PerformLayoutEnabled = true;
            this.lblWelcomeUser.PreviousFocusId = ((long)(0));
            this.lblWelcomeUser.Size = new System.Drawing.Size(377, 25);
            this.lblWelcomeUser.TabIndex = 1;
            this.lblWelcomeUser.Text = "...";
            this.lblWelcomeUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblWelcomeUser.Click += new System.EventHandler(this.lblWelcomeUser_Click);
            // 
            // pnlRightBanner
            // 
            this.pnlRightBanner.BackgroundImage = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("pnlRightBanner.BackgroundImage"));
            this.pnlRightBanner.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Clear;
            this.pnlRightBanner.Controls.Add(this.lblChangePassword);
            this.pnlRightBanner.Controls.Add(this.lblHelp);
            this.pnlRightBanner.Controls.Add(this.lblLogout);
            this.pnlRightBanner.Dock = Gizmox.WebGUI.Forms.DockStyle.Right;
            this.pnlRightBanner.ExcludeFromUniqueId = false;
            this.pnlRightBanner.Location = new System.Drawing.Point(638, 0);
            this.pnlRightBanner.Name = "pnlRightBanner";
            this.pnlRightBanner.NextFocusId = ((long)(0));
            this.pnlRightBanner.PerformLayoutEnabled = true;
            this.pnlRightBanner.PreviousFocusId = ((long)(0));
            this.pnlRightBanner.Size = new System.Drawing.Size(386, 60);
            this.pnlRightBanner.TabIndex = 1;
            // 
            // lblChangePassword
            // 
            this.lblChangePassword.ExcludeFromUniqueId = false;
            this.lblChangePassword.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChangePassword.ForeColor = System.Drawing.Color.White;
            this.lblChangePassword.Location = new System.Drawing.Point(126, 1);
            this.lblChangePassword.Name = "lblChangePassword";
            this.lblChangePassword.NextFocusId = ((long)(0));
            this.lblChangePassword.PerformLayoutEnabled = true;
            this.lblChangePassword.PreviousFocusId = ((long)(0));
            this.lblChangePassword.Size = new System.Drawing.Size(111, 16);
            this.lblChangePassword.TabIndex = 1;
            this.lblChangePassword.Text = "Change Password";
            this.lblChangePassword.Click += new System.EventHandler(this.lblChangePassword_Click);
            // 
            // lblHelp
            // 
            this.lblHelp.ExcludeFromUniqueId = false;
            this.lblHelp.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHelp.ForeColor = System.Drawing.Color.White;
            this.lblHelp.Location = new System.Drawing.Point(80, 0);
            this.lblHelp.Name = "lblHelp";
            this.lblHelp.NextFocusId = ((long)(0));
            this.lblHelp.PerformLayoutEnabled = true;
            this.lblHelp.PreviousFocusId = ((long)(0));
            this.lblHelp.Size = new System.Drawing.Size(51, 16);
            this.lblHelp.TabIndex = 1;
            this.lblHelp.Text = "Help";
            this.lblHelp.Click += new System.EventHandler(this.OnHelpClick);
            // 
            // lblLogout
            // 
            this.lblLogout.ExcludeFromUniqueId = false;
            this.lblLogout.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogout.ForeColor = System.Drawing.Color.White;
            this.lblLogout.Location = new System.Drawing.Point(20, 0);
            this.lblLogout.Name = "lblLogout";
            this.lblLogout.NextFocusId = ((long)(0));
            this.lblLogout.PerformLayoutEnabled = true;
            this.lblLogout.PreviousFocusId = ((long)(0));
            this.lblLogout.Size = new System.Drawing.Size(51, 16);
            this.lblLogout.TabIndex = 1;
            this.lblLogout.Text = "Logout";
            this.lblLogout.Click += new System.EventHandler(this.OnLogoutClick);
            // 
            // pnlLeftBanner
            // 
            this.pnlLeftBanner.BackgroundImage = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("pnlLeftBanner.BackgroundImage"));
            this.pnlLeftBanner.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Clear;
            this.pnlLeftBanner.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.pnlLeftBanner.ExcludeFromUniqueId = false;
            this.pnlLeftBanner.Location = new System.Drawing.Point(0, 0);
            this.pnlLeftBanner.Name = "pnlLeftBanner";
            this.pnlLeftBanner.NextFocusId = ((long)(0));
            this.pnlLeftBanner.PerformLayoutEnabled = true;
            this.pnlLeftBanner.PreviousFocusId = ((long)(0));
            this.pnlLeftBanner.Size = new System.Drawing.Size(131, 60);
            this.pnlLeftBanner.TabIndex = 0;
            // 
            // splitContainer
            // 
            this.splitContainer.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.splitContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(215)))), ((int)(((byte)(210)))));
            this.splitContainer.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Clear;
            this.splitContainer.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.splitContainer.ExcludeFromUniqueId = false;
            this.splitContainer.ForeColor = System.Drawing.SystemColors.Control;
            this.splitContainer.Location = new System.Drawing.Point(0, 60);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.NextFocusId = ((long)(0));
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer.Panel1.Controls.Add(this.NavigationTabs);
            this.splitContainer.Panel1.Controls.Add(this.pnlApplicationHeader);
            this.splitContainer.Panel1.Controls.Add(this.pnlSmallBanner);
            this.splitContainer.Panel1.ExcludeFromUniqueId = false;
            this.splitContainer.Panel1.NextFocusId = ((long)(0));
            this.splitContainer.Panel1.PerformLayoutEnabled = true;
            this.splitContainer.Panel1.PreviousFocusId = ((long)(0));
            this.splitContainer.Panel1MinSize = 0;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.pnlTabs);
            this.splitContainer.Panel2.Controls.Add(this.pnlButtonBar);
            this.splitContainer.Panel2.Controls.Add(this.pnlMenuSearch);
            this.splitContainer.Panel2.ExcludeFromUniqueId = false;
            this.splitContainer.Panel2.NextFocusId = ((long)(0));
            this.splitContainer.Panel2.PerformLayoutEnabled = true;
            this.splitContainer.Panel2.PreviousFocusId = ((long)(0));
            this.splitContainer.Panel2MinSize = 10;
            this.splitContainer.PerformLayoutEnabled = true;
            this.splitContainer.PreviousFocusId = ((long)(0));
            this.splitContainer.Size = new System.Drawing.Size(1024, 689);
            this.splitContainer.SplitterDistance = 225;
            this.splitContainer.TabIndex = 2;
            // 
            // pnlApplicationHeader
            // 
            this.pnlApplicationHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.pnlApplicationHeader.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Clear;
            this.pnlApplicationHeader.Controls.Add(this.pnlApplicationHeaderImage);
            this.pnlApplicationHeader.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.pnlApplicationHeader.ExcludeFromUniqueId = false;
            this.pnlApplicationHeader.Location = new System.Drawing.Point(0, 30);
            this.pnlApplicationHeader.Name = "pnlApplicationHeader";
            this.pnlApplicationHeader.NextFocusId = ((long)(0));
            this.pnlApplicationHeader.PerformLayoutEnabled = true;
            this.pnlApplicationHeader.PreviousFocusId = ((long)(0));
            this.pnlApplicationHeader.Size = new System.Drawing.Size(225, 0);
            this.pnlApplicationHeader.TabIndex = 2;
            // 
            // pnlApplicationHeaderImage
            // 
            this.pnlApplicationHeaderImage.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Clear;
            this.pnlApplicationHeaderImage.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.pnlApplicationHeaderImage.ExcludeFromUniqueId = false;
            this.pnlApplicationHeaderImage.Location = new System.Drawing.Point(0, 0);
            this.pnlApplicationHeaderImage.Name = "pnlApplicationHeaderImage";
            this.pnlApplicationHeaderImage.NextFocusId = ((long)(0));
            this.pnlApplicationHeaderImage.PerformLayoutEnabled = true;
            this.pnlApplicationHeaderImage.PreviousFocusId = ((long)(0));
            this.pnlApplicationHeaderImage.Size = new System.Drawing.Size(225, 0);
            this.pnlApplicationHeaderImage.TabIndex = 0;
            // 
            // pnlSmallBanner
            // 
            this.pnlSmallBanner.BackgroundImage = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("pnlSmallBanner.BackgroundImage"));
            this.pnlSmallBanner.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Clear;
            this.pnlSmallBanner.Controls.Add(this.pnlSmallBannerLogo);
            this.pnlSmallBanner.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.pnlSmallBanner.ExcludeFromUniqueId = false;
            this.pnlSmallBanner.Location = new System.Drawing.Point(0, 0);
            this.pnlSmallBanner.Name = "pnlSmallBanner";
            this.pnlSmallBanner.NextFocusId = ((long)(0));
            this.pnlSmallBanner.PerformLayoutEnabled = true;
            this.pnlSmallBanner.PreviousFocusId = ((long)(0));
            this.pnlSmallBanner.Size = new System.Drawing.Size(225, 30);
            this.pnlSmallBanner.TabIndex = 1;
            this.pnlSmallBanner.Visible = false;
            // 
            // pnlSmallBannerLogo
            // 
            this.pnlSmallBannerLogo.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Bottom)));
            this.pnlSmallBannerLogo.BackgroundImage = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("pnlSmallBannerLogo.BackgroundImage"));
            this.pnlSmallBannerLogo.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Clear;
            this.pnlSmallBannerLogo.ExcludeFromUniqueId = false;
            this.pnlSmallBannerLogo.Location = new System.Drawing.Point(22, 0);
            this.pnlSmallBannerLogo.Name = "pnlSmallBannerLogo";
            this.pnlSmallBannerLogo.NextFocusId = ((long)(0));
            this.pnlSmallBannerLogo.PerformLayoutEnabled = true;
            this.pnlSmallBannerLogo.PreviousFocusId = ((long)(0));
            this.pnlSmallBannerLogo.Size = new System.Drawing.Size(181, 30);
            this.pnlSmallBannerLogo.TabIndex = 0;
            this.pnlSmallBannerLogo.Visible = false;
            // 
            // pnlTabs
            // 
            this.pnlTabs.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Clear;
            this.pnlTabs.Controls.Add(this.ContentTabs);
            this.pnlTabs.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.pnlTabs.ExcludeFromUniqueId = false;
            this.pnlTabs.Location = new System.Drawing.Point(0, 57);
            this.pnlTabs.Name = "pnlTabs";
            this.pnlTabs.NextFocusId = ((long)(0));
            this.pnlTabs.PerformLayoutEnabled = true;
            this.pnlTabs.PreviousFocusId = ((long)(0));
            this.pnlTabs.Size = new System.Drawing.Size(795, 632);
            this.pnlTabs.TabIndex = 2;
            // 
            // pnlButtonBar
            // 
            this.pnlButtonBar.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Stretch;
            this.pnlButtonBar.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Clear;
            this.pnlButtonBar.Controls.Add(this.MainToolbar);
            this.pnlButtonBar.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.pnlButtonBar.ExcludeFromUniqueId = false;
            this.pnlButtonBar.Location = new System.Drawing.Point(0, 30);
            this.pnlButtonBar.Name = "pnlButtonBar";
            this.pnlButtonBar.NextFocusId = ((long)(0));
            this.pnlButtonBar.PerformLayoutEnabled = true;
            this.pnlButtonBar.PreviousFocusId = ((long)(0));
            this.pnlButtonBar.Size = new System.Drawing.Size(795, 27);
            this.pnlButtonBar.TabIndex = 0;
            // 
            // pnlMenuSearch
            // 
            this.pnlMenuSearch.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Clear;
            this.pnlMenuSearch.Controls.Add(this.pnlMainMenu);
            this.pnlMenuSearch.Controls.Add(this.pnlSearch);
            this.pnlMenuSearch.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.pnlMenuSearch.ExcludeFromUniqueId = false;
            this.pnlMenuSearch.Location = new System.Drawing.Point(0, 0);
            this.pnlMenuSearch.Name = "pnlMenuSearch";
            this.pnlMenuSearch.NextFocusId = ((long)(0));
            this.pnlMenuSearch.PerformLayoutEnabled = true;
            this.pnlMenuSearch.PreviousFocusId = ((long)(0));
            this.pnlMenuSearch.Size = new System.Drawing.Size(795, 30);
            this.pnlMenuSearch.TabIndex = 1;
            // 
            // pnlMainMenu
            // 
            this.pnlMainMenu.BackColor = System.Drawing.Color.Transparent;
            this.pnlMainMenu.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Clear;
            this.pnlMainMenu.Controls.Add(this.lnkAllClose);
            this.pnlMainMenu.Controls.Add(this.lnktabview);
            this.pnlMainMenu.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.pnlMainMenu.DockPadding.All = 4;
            this.pnlMainMenu.ExcludeFromUniqueId = false;
            this.pnlMainMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMainMenu.Name = "pnlMainMenu";
            this.pnlMainMenu.NextFocusId = ((long)(0));
            this.pnlMainMenu.Padding = new Gizmox.WebGUI.Forms.Padding(4);
            this.pnlMainMenu.PerformLayoutEnabled = true;
            this.pnlMainMenu.PreviousFocusId = ((long)(0));
            this.pnlMainMenu.Size = new System.Drawing.Size(106, 30);
            this.pnlMainMenu.TabIndex = 1;
            // 
            // lnkAllClose
            // 
            this.lnkAllClose.AutoSize = true;
            this.lnkAllClose.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.lnkAllClose.ExcludeFromUniqueId = false;
            this.lnkAllClose.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lnkAllClose.LinkColor = System.Drawing.Color.DodgerBlue;
            this.lnkAllClose.Location = new System.Drawing.Point(13, 15);
            this.lnkAllClose.Name = "lnkAllClose";
            this.lnkAllClose.NextFocusId = ((long)(0));
            this.lnkAllClose.PerformLayoutEnabled = true;
            this.lnkAllClose.PreviousFocusId = ((long)(0));
            this.lnkAllClose.Size = new System.Drawing.Size(29, 13);
            this.lnkAllClose.TabIndex = 0;
            this.lnkAllClose.TabStop = true;
            this.lnkAllClose.Text = "Close All Tabs";
            this.lnkAllClose.LinkClicked += new Gizmox.WebGUI.Forms.LinkLabelLinkClickedEventHandler(this.lnkAllClose_LinkClicked);
            // 
            // lnktabview
            // 
            this.lnktabview.AutoSize = true;
            this.lnktabview.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.lnktabview.ExcludeFromUniqueId = false;
            this.lnktabview.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lnktabview.LinkColor = System.Drawing.Color.DodgerBlue;
            this.lnktabview.Location = new System.Drawing.Point(15, 1);
            this.lnktabview.Name = "lnktabview";
            this.lnktabview.NextFocusId = ((long)(0));
            this.lnktabview.PerformLayoutEnabled = true;
            this.lnktabview.PreviousFocusId = ((long)(0));
            this.lnktabview.Size = new System.Drawing.Size(29, 13);
            this.lnktabview.TabIndex = 0;
            this.lnktabview.TabStop = true;
            this.lnktabview.Text = "Hide Tree";
            this.lnktabview.LinkClicked += new Gizmox.WebGUI.Forms.LinkLabelLinkClickedEventHandler(this.lnktabview_LinkClicked);
            // 
            // pnlSearch
            // 
            this.pnlSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(231)))), ((int)(((byte)(247)))));
            this.pnlSearch.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Clear;
            this.pnlSearch.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.pnlSearch.DockPadding.Bottom = 5;
            this.pnlSearch.DockPadding.Left = 4;
            this.pnlSearch.DockPadding.Right = 4;
            this.pnlSearch.DockPadding.Top = 3;
            this.pnlSearch.ExcludeFromUniqueId = false;
            this.pnlSearch.Location = new System.Drawing.Point(0, 0);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.NextFocusId = ((long)(0));
            this.pnlSearch.Padding = new Gizmox.WebGUI.Forms.Padding(4, 3, 4, 5);
            this.pnlSearch.PerformLayoutEnabled = true;
            this.pnlSearch.PreviousFocusId = ((long)(0));
            this.pnlSearch.Size = new System.Drawing.Size(795, 30);
            this.pnlSearch.TabIndex = 0;
            // 
            // lblAgency
            // 
            this.lblAgency.AutoSize = true;
            this.lblAgency.ExcludeFromUniqueId = false;
            this.lblAgency.Location = new System.Drawing.Point(56, 7);
            this.lblAgency.Name = "lblAgency";
            this.lblAgency.NextFocusId = ((long)(0));
            this.lblAgency.PerformLayoutEnabled = true;
            this.lblAgency.PreviousFocusId = ((long)(0));
            this.lblAgency.Size = new System.Drawing.Size(35, 13);
            this.lblAgency.TabIndex = 0;
            this.lblAgency.Text = "label1";
            this.lblAgency.Visible = false;
            // 
            // tabWelcome
            // 
            this.tabWelcome.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tabWelcome.ExcludeFromUniqueId = false;
            this.tabWelcome.Extra = false;
            this.tabWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(51)))), ((int)(((byte)(101)))));
            this.tabWelcome.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("tabWelcome.Image"));
            this.tabWelcome.Location = new System.Drawing.Point(4, 22);
            this.tabWelcome.Name = "tabWelcome";
            this.tabWelcome.NextFocusId = ((long)(0));
            this.tabWelcome.PerformLayoutEnabled = true;
            this.tabWelcome.PreviousFocusId = ((long)(0));
            this.tabWelcome.Size = new System.Drawing.Size(310, 625);
            this.tabWelcome.TabIndex = 0;
            this.tabWelcome.Tag = "Inbox";
            this.tabWelcome.Text = "Welcome";
            // 
            // tabAdministration
            // 
            this.tabAdministration.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tabAdministration.ExcludeFromUniqueId = false;
            this.tabAdministration.Extra = false;
            this.tabAdministration.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(51)))), ((int)(((byte)(101)))));
            this.tabAdministration.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("tabAdministration.Image"));
            this.tabAdministration.Location = new System.Drawing.Point(4, 22);
            this.tabAdministration.Name = "tabAdministration";
            this.tabAdministration.NextFocusId = ((long)(0));
            this.tabAdministration.PerformLayoutEnabled = true;
            this.tabAdministration.PreviousFocusId = ((long)(0));
            this.tabAdministration.Size = new System.Drawing.Size(310, 625);
            this.tabAdministration.TabIndex = 1;
            this.tabAdministration.Tag = "Administration";
            this.tabAdministration.Text = "Administration                                            ";
            // 
            // tabHeadStart
            // 
            this.tabHeadStart.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tabHeadStart.ExcludeFromUniqueId = false;
            this.tabHeadStart.Extra = false;
            this.tabHeadStart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(51)))), ((int)(((byte)(101)))));
            this.tabHeadStart.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("tabHeadStart.Image"));
            this.tabHeadStart.Location = new System.Drawing.Point(4, 22);
            this.tabHeadStart.Name = "tabHeadStart";
            this.tabHeadStart.NextFocusId = ((long)(0));
            this.tabHeadStart.PerformLayoutEnabled = true;
            this.tabHeadStart.PreviousFocusId = ((long)(0));
            this.tabHeadStart.Size = new System.Drawing.Size(310, 625);
            this.tabHeadStart.TabIndex = 2;
            this.tabHeadStart.Tag = "SubmissionManager";
            this.tabHeadStart.Text = "HeadStart                                                    ";
            // 
            // tabCaseManagement
            // 
            this.tabCaseManagement.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tabCaseManagement.ExcludeFromUniqueId = false;
            this.tabCaseManagement.Extra = false;
            this.tabCaseManagement.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(51)))), ((int)(((byte)(101)))));
            this.tabCaseManagement.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("tabCaseManagement.Image"));
            this.tabCaseManagement.Location = new System.Drawing.Point(4, 22);
            this.tabCaseManagement.Name = "tabCaseManagement";
            this.tabCaseManagement.NextFocusId = ((long)(0));
            this.tabCaseManagement.PerformLayoutEnabled = true;
            this.tabCaseManagement.PreviousFocusId = ((long)(0));
            this.tabCaseManagement.Size = new System.Drawing.Size(310, 625);
            this.tabCaseManagement.TabIndex = 3;
            this.tabCaseManagement.Tag = "CaseManagement";
            this.tabCaseManagement.Text = "Case Management                                         ";
            // 
            // tabEnergyRI
            // 
            this.tabEnergyRI.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tabEnergyRI.ExcludeFromUniqueId = false;
            this.tabEnergyRI.Extra = false;
            this.tabEnergyRI.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(51)))), ((int)(((byte)(101)))));
            this.tabEnergyRI.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("tabEnergyRI.Image"));
            this.tabEnergyRI.Location = new System.Drawing.Point(4, 22);
            this.tabEnergyRI.Name = "tabEnergyRI";
            this.tabEnergyRI.NextFocusId = ((long)(0));
            this.tabEnergyRI.PerformLayoutEnabled = true;
            this.tabEnergyRI.PreviousFocusId = ((long)(0));
            this.tabEnergyRI.Size = new System.Drawing.Size(310, 625);
            this.tabEnergyRI.TabIndex = 9;
            this.tabEnergyRI.Tag = "EnergyRI";
            this.tabEnergyRI.Text = "Energy Assistance-RI                                      ";
            // 
            // tabEnergyCT
            // 
            this.tabEnergyCT.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tabEnergyCT.ExcludeFromUniqueId = false;
            this.tabEnergyCT.Extra = false;
            this.tabEnergyCT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(51)))), ((int)(((byte)(101)))));
            this.tabEnergyCT.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("tabEnergyCT.Image"));
            this.tabEnergyCT.Location = new System.Drawing.Point(4, 22);
            this.tabEnergyCT.Name = "tabEnergyCT";
            this.tabEnergyCT.NextFocusId = ((long)(0));
            this.tabEnergyCT.PerformLayoutEnabled = true;
            this.tabEnergyCT.PreviousFocusId = ((long)(0));
            this.tabEnergyCT.Size = new System.Drawing.Size(310, 625);
            this.tabEnergyCT.TabIndex = 8;
            this.tabEnergyCT.Tag = "EnergyCT";
            this.tabEnergyCT.Text = "Energy Assistance-CT                             ";
            // 
            // tabAccountsReceivable
            // 
            this.tabAccountsReceivable.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tabAccountsReceivable.ExcludeFromUniqueId = false;
            this.tabAccountsReceivable.Extra = false;
            this.tabAccountsReceivable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(51)))), ((int)(((byte)(101)))));
            this.tabAccountsReceivable.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("tabAccountsReceivable.Image"));
            this.tabAccountsReceivable.Location = new System.Drawing.Point(4, 22);
            this.tabAccountsReceivable.Name = "tabAccountsReceivable";
            this.tabAccountsReceivable.NextFocusId = ((long)(0));
            this.tabAccountsReceivable.PerformLayoutEnabled = true;
            this.tabAccountsReceivable.PreviousFocusId = ((long)(0));
            this.tabAccountsReceivable.Size = new System.Drawing.Size(310, 625);
            this.tabAccountsReceivable.TabIndex = 94;
            this.tabAccountsReceivable.Tag = "AccountsReceivable";
            this.tabAccountsReceivable.Text = "AccountsReceivable                                       ";
            // 
            // tabEmergencyAssistance
            // 
            this.tabEmergencyAssistance.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tabEmergencyAssistance.ExcludeFromUniqueId = false;
            this.tabEmergencyAssistance.Extra = false;
            this.tabEmergencyAssistance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(51)))), ((int)(((byte)(101)))));
            this.tabEmergencyAssistance.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("tabEmergencyAssistance.Image"));
            this.tabEmergencyAssistance.Location = new System.Drawing.Point(4, 22);
            this.tabEmergencyAssistance.Name = "tabEmergencyAssistance";
            this.tabEmergencyAssistance.NextFocusId = ((long)(0));
            this.tabEmergencyAssistance.PerformLayoutEnabled = true;
            this.tabEmergencyAssistance.PreviousFocusId = ((long)(0));
            this.tabEmergencyAssistance.Size = new System.Drawing.Size(310, 625);
            this.tabEmergencyAssistance.TabIndex = 5;
            this.tabEmergencyAssistance.Tag = "EmergencyAssistance";
            this.tabEmergencyAssistance.Text = "EmergencyAssistance                             ";
            // 
            // tabHousingWeatherization
            // 
            this.tabHousingWeatherization.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tabHousingWeatherization.ExcludeFromUniqueId = false;
            this.tabHousingWeatherization.Extra = false;
            this.tabHousingWeatherization.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(51)))), ((int)(((byte)(101)))));
            this.tabHousingWeatherization.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("tabHousingWeatherization.Image"));
            this.tabHousingWeatherization.Location = new System.Drawing.Point(4, 22);
            this.tabHousingWeatherization.Name = "tabHousingWeatherization";
            this.tabHousingWeatherization.NextFocusId = ((long)(0));
            this.tabHousingWeatherization.PerformLayoutEnabled = true;
            this.tabHousingWeatherization.PreviousFocusId = ((long)(0));
            this.tabHousingWeatherization.Size = new System.Drawing.Size(310, 625);
            this.tabHousingWeatherization.TabIndex = 10;
            this.tabHousingWeatherization.Tag = "HousingWeatherization";
            this.tabHousingWeatherization.Text = "HousingWeatherization                              ";
            // 
            // tabDashBoard
            // 
            this.tabDashBoard.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tabDashBoard.ExcludeFromUniqueId = false;
            this.tabDashBoard.Extra = false;
            this.tabDashBoard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(51)))), ((int)(((byte)(101)))));
            this.tabDashBoard.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("tabDashBoard.Image"));
            this.tabDashBoard.Location = new System.Drawing.Point(4, 22);
            this.tabDashBoard.Name = "tabDashBoard";
            this.tabDashBoard.NextFocusId = ((long)(0));
            this.tabDashBoard.PerformLayoutEnabled = true;
            this.tabDashBoard.PreviousFocusId = ((long)(0));
            this.tabDashBoard.Size = new System.Drawing.Size(310, 625);
            this.tabDashBoard.TabIndex = 6;
            this.tabDashBoard.Tag = "Executive Dashboard";
            this.tabDashBoard.Text = "Executive Dashboard                     ";
            // 
            // tabHealthyStart
            // 
            this.tabHealthyStart.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tabHealthyStart.ExcludeFromUniqueId = false;
            this.tabHealthyStart.Extra = false;
            this.tabHealthyStart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(51)))), ((int)(((byte)(101)))));
            this.tabHealthyStart.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("tabHealthyStart.Image"));
            this.tabHealthyStart.Location = new System.Drawing.Point(4, 22);
            this.tabHealthyStart.Name = "tabHealthStart";
            this.tabHealthyStart.NextFocusId = ((long)(0));
            this.tabHealthyStart.PerformLayoutEnabled = true;
            this.tabHealthyStart.PreviousFocusId = ((long)(0));
            this.tabHealthyStart.Size = new System.Drawing.Size(310, 625);
            this.tabHealthyStart.TabIndex = 7;
            this.tabHealthyStart.Tag = "Healthy Start";
            this.tabHealthyStart.Text = "Healthy Start                     ";
            //
            // tabAgencypartner
            // 
            this.tabAgencypartner.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tabAgencypartner.ExcludeFromUniqueId = false;
            this.tabAgencypartner.Extra = false;
            this.tabAgencypartner.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(51)))), ((int)(((byte)(101)))));
            this.tabAgencypartner.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("tabAgencypartner.Image"));
            this.tabAgencypartner.Location = new System.Drawing.Point(4, 22);
            this.tabAgencypartner.Name = "tabAgencypartner";
            this.tabAgencypartner.NextFocusId = ((long)(0));
            this.tabAgencypartner.PerformLayoutEnabled = true;
            this.tabAgencypartner.PreviousFocusId = ((long)(0));
            this.tabAgencypartner.Size = new System.Drawing.Size(310, 625);
            this.tabAgencypartner.TabIndex = 8;
            this.tabAgencypartner.Tag = "Agency Partners";
            this.tabAgencypartner.Text = "Agency Partners                      ";
            // 
            //
            // treeMenu
            // 
            this.treeMenu.ExcludeFromUniqueId = false;
            // 
            // pnlParent
            // 
            this.pnlParent.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Clear;
            this.pnlParent.Controls.Add(this.splitContainer);
            this.pnlParent.Controls.Add(this.pnlBanner);
            this.pnlParent.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.pnlParent.ExcludeFromUniqueId = false;
            this.pnlParent.Location = new System.Drawing.Point(0, 0);
            this.pnlParent.Name = "pnlParent";
            this.pnlParent.NextFocusId = ((long)(0));
            this.pnlParent.PerformLayoutEnabled = true;
            this.pnlParent.PreviousFocusId = ((long)(0));
            this.pnlParent.Size = new System.Drawing.Size(1024, 749);
            this.pnlParent.TabIndex = 3;
            // 
            // picBacground
            // 
            this.picBacground.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.picBacground.ExcludeFromUniqueId = false;
            this.picBacground.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("picBacground.Image"));
            this.picBacground.Location = new System.Drawing.Point(0, 0);
            this.picBacground.Name = "picBacground";
            this.picBacground.NextFocusId = ((long)(0));
            this.picBacground.PerformLayoutEnabled = true;
            this.picBacground.PreviousFocusId = ((long)(0));
            this.picBacground.Size = new System.Drawing.Size(1024, 749);
            this.picBacground.SizeMode = Gizmox.WebGUI.Forms.PictureBoxSizeMode.StretchImage;
            this.picBacground.TabIndex = 4;
            this.picBacground.TabStop = false;
            // 
            // mainMenu
            // 
            this.mainMenu.ExcludeFromUniqueId = false;
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.NextFocusId = ((long)(0));
            this.mainMenu.PerformLayoutEnabled = true;
            this.mainMenu.PreviousFocusId = ((long)(0));
            this.mainMenu.Size = new System.Drawing.Size(100, 22);
            // 
            // obsoleteLinkContextMenu
            // 
            this.obsoleteLinkContextMenu.ExcludeFromUniqueId = false;
            // 
            // toolBarButton1
            // 
            this.toolBarButton1.CustomStyle = "";
            this.toolBarButton1.ExcludeFromUniqueId = false;
            this.toolBarButton1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.toolBarButton1.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("toolBarButton1.Image"));
            this.toolBarButton1.Name = "toolBarButton1";
            this.toolBarButton1.Size = 24;
            this.toolBarButton1.Text = "New User";
            this.toolBarButton1.ToolTipText = "";
            // 
            // MainForm
            // 
            this.BackgroundImage = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("$this.BackgroundImage"));
            this.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.pnlParent);
            this.Controls.Add(this.picBacground);
            this.Location = new System.Drawing.Point(15, 15);
            this.Size = new System.Drawing.Size(1024, 815);
            this.Text = "CAPTAIN";
            this.Load += new System.EventHandler(this.OnMainFormLoad);
            this.FormClosed += new Gizmox.WebGUI.Forms.Form.FormClosedEventHandler(this.MainForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.ContentTabs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NavigationTabs)).EndInit();
            this.pnlBanner.ResumeLayout(false);
            this.pnlMiddleBanner.ResumeLayout(false);
            this.pnlRightBanner.ResumeLayout(false);
            this.pnlApplicationHeader.ResumeLayout(false);
            this.pnlSmallBanner.ResumeLayout(false);
            this.pnlTabs.ResumeLayout(false);
            this.pnlButtonBar.ResumeLayout(false);
            this.pnlMenuSearch.ResumeLayout(false);
            this.pnlMainMenu.ResumeLayout(false);
            this.pnlParent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBacground)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
         
        private Gizmox.WebGUI.Forms.Panel pnlBanner;
        private Gizmox.WebGUI.Forms.Panel pnlLeftBanner;
        private Gizmox.WebGUI.Forms.Panel pnlRightBanner;
        private Gizmox.WebGUI.Forms.Panel pnlMiddleBanner;
        private Gizmox.WebGUI.Forms.NavigationTab tabWelcome;
        private Gizmox.WebGUI.Forms.NavigationTab tabAdministration;
        private Gizmox.WebGUI.Forms.NavigationTab tabHeadStart;
        private Gizmox.WebGUI.Forms.NavigationTab tabCaseManagement;
        private Gizmox.WebGUI.Forms.NavigationTab tabEnergyRI;
        private Gizmox.WebGUI.Forms.NavigationTab tabEnergyCT;
        private Gizmox.WebGUI.Forms.NavigationTab tabHousingWeatherization;
        private Gizmox.WebGUI.Forms.NavigationTab tabAccountsReceivable;
        private Gizmox.WebGUI.Forms.NavigationTab tabEmergencyAssistance;
        private Gizmox.WebGUI.Forms.NavigationTab tabDashBoard;
        private Gizmox.WebGUI.Forms.NavigationTab tabHealthyStart;
        private Gizmox.WebGUI.Forms.NavigationTab tabAgencypartner;
        private Gizmox.WebGUI.Forms.Panel pnlParent;
        private Gizmox.WebGUI.Forms.PictureBox picBacground;
        private Gizmox.WebGUI.Forms.Panel pnlMenuSearch;
        private Gizmox.WebGUI.Forms.Panel pnlMainMenu;
        private Gizmox.WebGUI.Forms.Panel pnlButtonBar;
        private Gizmox.WebGUI.Forms.ContextMenu treeMenu;
        private Gizmox.WebGUI.Forms.MainMenu mainMenu;
        private Gizmox.WebGUI.Forms.Panel pnlTabs;
        public Gizmox.WebGUI.Forms.SplitContainer splitContainer;
        private Gizmox.WebGUI.Forms.Label lblLogout;
        private Gizmox.WebGUI.Forms.Label lblHelp;
        private Gizmox.WebGUI.Forms.Panel pnlSmallBanner;
        private Gizmox.WebGUI.Forms.Panel pnlSmallBannerLogo;
        private Gizmox.WebGUI.Forms.Panel pnlApplicationHeader;
        private Gizmox.WebGUI.Forms.Panel pnlApplicationHeaderImage;
        private Gizmox.WebGUI.Forms.ContextMenu obsoleteLinkContextMenu;
        private Gizmox.WebGUI.Forms.Label lblWelcomeUser;
        private Gizmox.WebGUI.Forms.ToolBarButton toolBarButton1;
        public Gizmox.WebGUI.Forms.Panel pnlSearch;
        private Gizmox.WebGUI.Forms.Label lblAgency;
        private Gizmox.WebGUI.Forms.LinkLabel lnktabview;
        private Gizmox.WebGUI.Forms.Label lblChangePassword;
        private Gizmox.WebGUI.Forms.Label LblLogin_details;
        private Gizmox.WebGUI.Forms.LinkLabel lnkAllClose;
        //private Gizmox.WebGUI.Forms.LinkLabel lnkAllClose;
      
       
    }
}
