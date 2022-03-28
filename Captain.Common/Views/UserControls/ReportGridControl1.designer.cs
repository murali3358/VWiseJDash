using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Captain.Common.Views.UserControls
{
    partial class ReportGridControl1
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

        #region Visual WebGui UserControl Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportGridControl1));
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.panel5 = new Gizmox.WebGUI.Forms.Panel();
            this.btnSummary = new Gizmox.WebGUI.Forms.Button();
            this.btnUserId = new Gizmox.WebGUI.Forms.Button();
            this.dtEndDate = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.lblTodate = new Gizmox.WebGUI.Forms.Label();
            this.lblStart = new Gizmox.WebGUI.Forms.Label();
            this.btnGetReport = new Gizmox.WebGUI.Forms.Button();
            this.dtStartDate = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.panel4 = new Gizmox.WebGUI.Forms.Panel();
            this.tabControl1 = new Gizmox.WebGUI.Forms.TabControl();
            this.tabPage2 = new Gizmox.WebGUI.Forms.TabPage();
            this.reportViewer2 = new Gizmox.WebGUI.Reporting.ReportViewer();
            this.tabPage1 = new Gizmox.WebGUI.Forms.TabPage();
            this.reportViewer1 = new Gizmox.WebGUI.Reporting.ReportViewer();
            this.panel3 = new Gizmox.WebGUI.Forms.Panel();
            this.gvwUserData = new Gizmox.WebGUI.Forms.DataGridView();
            this.gvIData = new Gizmox.WebGUI.Forms.DataGridViewImageColumn();
            this.gvtprogramCode = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.gvtProgram1 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.gvtSelectuser = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.gvwData = new Gizmox.WebGUI.Forms.DataGridView();
            this.gviImg = new Gizmox.WebGUI.Forms.DataGridViewImageColumn();
            this.gvtTableName = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.gvcDatetypes = new Gizmox.WebGUI.Forms.DataGridViewComboBoxColumn();
            this.gvtSelect = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.panel6 = new Gizmox.WebGUI.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvwUserData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwData)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel1.ExcludeFromUniqueId = false;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.PerformLayoutEnabled = true;
            this.panel1.Size = new System.Drawing.Size(824, 42);
            this.panel1.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.btnSummary);
            this.panel5.Controls.Add(this.btnUserId);
            this.panel5.Controls.Add(this.dtEndDate);
            this.panel5.Controls.Add(this.lblTodate);
            this.panel5.Controls.Add(this.lblStart);
            this.panel5.Controls.Add(this.btnGetReport);
            this.panel5.Controls.Add(this.dtStartDate);
            this.panel5.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel5.ExcludeFromUniqueId = false;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.PerformLayoutEnabled = true;
            this.panel5.Size = new System.Drawing.Size(824, 42);
            this.panel5.TabIndex = 11;
            // 
            // btnSummary
            // 
            this.btnSummary.ExcludeFromUniqueId = false;
            this.btnSummary.Location = new System.Drawing.Point(557, 7);
            this.btnSummary.Name = "btnSummary";
            this.btnSummary.PerformLayoutEnabled = true;
            this.btnSummary.Size = new System.Drawing.Size(85, 23);
            this.btnSummary.TabIndex = 10;
            this.btnSummary.Text = "Get Summary";
            this.btnSummary.Visible = false;
            this.btnSummary.Click += new System.EventHandler(this.btnSummary_Click);
            // 
            // btnUserId
            // 
            this.btnUserId.ExcludeFromUniqueId = false;
            this.btnUserId.Location = new System.Drawing.Point(388, 7);
            this.btnUserId.Name = "btnUserId";
            this.btnUserId.PerformLayoutEnabled = true;
            this.btnUserId.Size = new System.Drawing.Size(118, 23);
            this.btnUserId.TabIndex = 11;
            this.btnUserId.Text = "Select Parameters";
            this.btnUserId.Visible = false;
            this.btnUserId.Click += new System.EventHandler(this.btnUserId_Click);
            // 
            // dtEndDate
            // 
            this.dtEndDate.CustomFormat = "MM/dd/yyyy";
            this.dtEndDate.ExcludeFromUniqueId = false;
            this.dtEndDate.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtEndDate.IsEmpty = false;
            this.dtEndDate.IsEmptyAllowed = false;
            this.dtEndDate.Location = new System.Drawing.Point(170, 9);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.PerformLayoutEnabled = true;
            this.dtEndDate.ShowCheckBox = true;
            this.dtEndDate.Size = new System.Drawing.Size(106, 21);
            this.dtEndDate.TabIndex = 9;
            // 
            // lblTodate
            // 
            this.lblTodate.AutoSize = true;
            this.lblTodate.ExcludeFromUniqueId = false;
            this.lblTodate.Location = new System.Drawing.Point(152, 12);
            this.lblTodate.Name = "lblTodate";
            this.lblTodate.PerformLayoutEnabled = true;
            this.lblTodate.Size = new System.Drawing.Size(30, 13);
            this.lblTodate.TabIndex = 0;
            this.lblTodate.Text = "To";
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.ExcludeFromUniqueId = false;
            this.lblStart.Location = new System.Drawing.Point(7, 12);
            this.lblStart.Name = "lblStart";
            this.lblStart.PerformLayoutEnabled = true;
            this.lblStart.Size = new System.Drawing.Size(30, 13);
            this.lblStart.TabIndex = 0;
            this.lblStart.Text = "From";
            // 
            // btnGetReport
            // 
            this.btnGetReport.ExcludeFromUniqueId = false;
            this.btnGetReport.Location = new System.Drawing.Point(294, 7);
            this.btnGetReport.Name = "btnGetReport";
            this.btnGetReport.PerformLayoutEnabled = true;
            this.btnGetReport.Size = new System.Drawing.Size(75, 23);
            this.btnGetReport.TabIndex = 10;
            this.btnGetReport.Text = "Get Report";
            this.btnGetReport.Click += new System.EventHandler(this.btnGetReport_Click);
            // 
            // dtStartDate
            // 
            this.dtStartDate.CustomFormat = "MM/dd/yyyy";
            this.dtStartDate.ExcludeFromUniqueId = false;
            this.dtStartDate.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtStartDate.IsEmpty = false;
            this.dtStartDate.IsEmptyAllowed = false;
            this.dtStartDate.Location = new System.Drawing.Point(38, 9);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.PerformLayoutEnabled = true;
            this.dtStartDate.ShowCheckBox = true;
            this.dtStartDate.Size = new System.Drawing.Size(106, 21);
            this.dtStartDate.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel2.ExcludeFromUniqueId = false;
            this.panel2.Location = new System.Drawing.Point(0, 42);
            this.panel2.Name = "panel2";
            this.panel2.PerformLayoutEnabled = true;
            this.panel2.Size = new System.Drawing.Size(824, 482);
            this.panel2.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.tabControl1);
            this.panel4.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel4.ExcludeFromUniqueId = false;
            this.panel4.Location = new System.Drawing.Point(291, 0);
            this.panel4.Name = "panel4";
            this.panel4.PerformLayoutEnabled = true;
            this.panel4.Size = new System.Drawing.Size(533, 482);
            this.panel4.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tabControl1.ExcludeFromUniqueId = false;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.PerformLayoutEnabled = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.ShowCloseButton = true;
            this.tabControl1.Size = new System.Drawing.Size(533, 482);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.CloseClick += new System.EventHandler(this.tabControl1_CloseClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.reportViewer2);
            this.tabPage2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tabPage2.ExcludeFromUniqueId = false;
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.PerformLayoutEnabled = true;
            this.tabPage2.Size = new System.Drawing.Size(525, 456);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "User/Program View";
            // 
            // reportViewer2
            // 
            this.reportViewer2.AsyncRendering = false;
            this.reportViewer2.AutoScroll = false;
            this.reportViewer2.ControlCode = resources.GetString("reportViewer2.ControlCode");
            this.reportViewer2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.reportViewer2.ExcludeFromUniqueId = false;
            this.reportViewer2.Location = new System.Drawing.Point(3, 3);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.PerformLayoutEnabled = true;
            this.reportViewer2.Size = new System.Drawing.Size(525, 456);
            this.reportViewer2.TabIndex = 0;
            this.reportViewer2.HostedPageLoad += new Gizmox.WebGUI.Forms.Hosts.AspPageEventHandler(this.reportViewer2_HostedPageLoad);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.reportViewer1);
            this.tabPage1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tabPage1.ExcludeFromUniqueId = false;
            this.tabPage1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.PerformLayoutEnabled = true;
            this.tabPage1.Size = new System.Drawing.Size(525, 456);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "Summary Chart";
            // 
            // reportViewer1
            // 
            this.reportViewer1.AutoScroll = false;
            this.reportViewer1.ControlCode = resources.GetString("reportViewer1.ControlCode");
            this.reportViewer1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.reportViewer1.ExcludeFromUniqueId = false;
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.PerformLayoutEnabled = true;
            this.reportViewer1.Size = new System.Drawing.Size(525, 456);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.HostedPageLoad += new Gizmox.WebGUI.Forms.Hosts.AspPageEventHandler(this.reportViewer1_HostedPageLoad);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.gvwUserData);
            this.panel3.Controls.Add(this.gvwData);
            this.panel3.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.panel3.ExcludeFromUniqueId = false;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.PerformLayoutEnabled = true;
            this.panel3.Size = new System.Drawing.Size(291, 482);
            this.panel3.TabIndex = 0;
            // 
            // gvwUserData
            // 
            this.gvwUserData.AllowDrag = false;
            this.gvwUserData.AllowDragTargetsPropagation = false;
            this.gvwUserData.AllowUserToAddRows = false;
            this.gvwUserData.AllowUserToDeleteRows = false;
            this.gvwUserData.AllowUserToOrderColumns = true;
            this.gvwUserData.AllowUserToResizeColumns = false;
            this.gvwUserData.AllowUserToResizeRows = false;
            this.gvwUserData.BackgroundColor = System.Drawing.Color.White;
            this.gvwUserData.Columns.AddRange(new Gizmox.WebGUI.Forms.DataGridViewColumn[] {
            this.gvIData,
            this.gvtprogramCode,
            this.gvtProgram1,
            this.gvtSelectuser});
            this.gvwUserData.ExcludeFromUniqueId = false;
            this.gvwUserData.IsSelectionChangeCritical = true;
            this.gvwUserData.ItemsPerPage = 200;
            this.gvwUserData.Location = new System.Drawing.Point(-2, 321);
            this.gvwUserData.Name = "gvwUserData";
            this.gvwUserData.PerformLayoutEnabled = true;
            this.gvwUserData.RenderCellPanelsAsText = false;
            this.gvwUserData.RowHeadersVisible = false;
            this.gvwUserData.RowHeadersWidth = 4;
            this.gvwUserData.RowTemplate.Enabled = true;
            this.gvwUserData.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical;
            this.gvwUserData.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvwUserData.Size = new System.Drawing.Size(285, 144);
            this.gvwUserData.TabIndex = 0;
            this.gvwUserData.Visible = false;
            this.gvwUserData.CellClick += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.gvwUserData_CellClick);
            // 
            // gvIData
            // 
            dataGridViewCellStyle9.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.NullValue = null;
            this.gvIData.DefaultCellStyle = dataGridViewCellStyle9;
            this.gvIData.HeaderText = "  ";
            this.gvIData.Name = "gvIData";
            this.gvIData.Width = 35;
            // 
            // gvtprogramCode
            // 
            this.gvtprogramCode.DefaultCellStyle = dataGridViewCellStyle10;
            this.gvtprogramCode.HeaderText = "Code";
            this.gvtprogramCode.Name = "gvtprogramCode";
            this.gvtprogramCode.Width = 70;
            // 
            // gvtProgram1
            // 
            this.gvtProgram1.DefaultCellStyle = dataGridViewCellStyle11;
            this.gvtProgram1.HeaderText = "Program";
            this.gvtProgram1.Name = "gvtProgram1";
            this.gvtProgram1.Width = 175;
            // 
            // gvtSelectuser
            // 
            this.gvtSelectuser.DefaultCellStyle = dataGridViewCellStyle12;
            this.gvtSelectuser.HeaderText = "  ";
            this.gvtSelectuser.Name = "gvtSelectuser";
            this.gvtSelectuser.Visible = false;
            // 
            // gvwData
            // 
            this.gvwData.AllowDrag = false;
            this.gvwData.AllowDragTargetsPropagation = false;
            this.gvwData.AllowUserToAddRows = false;
            this.gvwData.AllowUserToDeleteRows = false;
            this.gvwData.AllowUserToOrderColumns = true;
            this.gvwData.AllowUserToResizeColumns = false;
            this.gvwData.AllowUserToResizeRows = false;
            this.gvwData.BackgroundColor = System.Drawing.Color.White;
            this.gvwData.Columns.AddRange(new Gizmox.WebGUI.Forms.DataGridViewColumn[] {
            this.gviImg,
            this.gvtTableName,
            this.gvcDatetypes,
            this.gvtSelect});
            this.gvwData.ExcludeFromUniqueId = false;
            this.gvwData.IsSelectionChangeCritical = true;
            this.gvwData.Location = new System.Drawing.Point(-1, -1);
            this.gvwData.Name = "gvwData";
            this.gvwData.PerformLayoutEnabled = true;
            this.gvwData.RenderCellPanelsAsText = false;
            this.gvwData.RowHeadersVisible = false;
            this.gvwData.RowHeadersWidth = 4;
            this.gvwData.RowTemplate.Enabled = true;
            this.gvwData.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical;
            this.gvwData.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvwData.Size = new System.Drawing.Size(284, 300);
            this.gvwData.TabIndex = 0;
            this.gvwData.CellClick += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.gvwData_CellClick);
            // 
            // gviImg
            // 
            dataGridViewCellStyle13.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.NullValue = null;
            this.gviImg.DefaultCellStyle = dataGridViewCellStyle13;
            this.gviImg.HeaderText = " ";
            this.gviImg.Name = "gviImg";
            this.gviImg.Width = 35;
            // 
            // gvtTableName
            // 
            this.gvtTableName.DefaultCellStyle = dataGridViewCellStyle14;
            this.gvtTableName.HeaderText = "Description";
            this.gvtTableName.Name = "gvtTableName";
            this.gvtTableName.ReadOnly = true;
            this.gvtTableName.Width = 160;
            // 
            // gvcDatetypes
            // 
            this.gvcDatetypes.AutoComplete = false;
            this.gvcDatetypes.DefaultCellStyle = dataGridViewCellStyle15;
            this.gvcDatetypes.DisplayStyle = Gizmox.WebGUI.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.gvcDatetypes.HeaderText = "Date";
            this.gvcDatetypes.Name = "gvcDatetypes";
            this.gvcDatetypes.Width = 80;
            // 
            // gvtSelect
            // 
            this.gvtSelect.DefaultCellStyle = dataGridViewCellStyle16;
            this.gvtSelect.Name = "gvtSelect";
            this.gvtSelect.Visible = false;
            this.gvtSelect.Width = 10;
            // 
            // panel6
            // 
            this.panel6.ExcludeFromUniqueId = false;
            this.panel6.Location = new System.Drawing.Point(492, 6);
            this.panel6.Name = "panel6";
            this.panel6.PerformLayoutEnabled = true;
            this.panel6.Size = new System.Drawing.Size(144, 26);
            this.panel6.TabIndex = 12;
            // 
            // ReportGridControl1
            // 
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Size = new System.Drawing.Size(824, 524);
            this.Text = "ReportGridControl";
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvwUserData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel4;
        private Panel panel3;
        private DateTimePicker dtStartDate;
        private Label lblStart;
        private DataGridView gvwData;
        private DataGridViewImageColumn gviImg;
        private DataGridViewTextBoxColumn gvtTableName;
        private DataGridViewComboBoxColumn gvcDatetypes;
        private DataGridViewTextBoxColumn gvtSelect;
        private Button btnGetReport;
        private Panel panel5;
        private DateTimePicker dtEndDate;
        private Label lblTodate;
        private DataGridView gvwUserData;
        private DataGridViewTextBoxColumn gvtprogramCode;
        private DataGridViewTextBoxColumn gvtProgram1;
        private TabControl tabControl1;
        private TabPage tabPage2;
        private Gizmox.WebGUI.Reporting.ReportViewer reportViewer2;
        private DataGridViewImageColumn gvIData;
        private Button btnUserId;
        private DataGridViewTextBoxColumn gvtSelectuser;
        private TabPage tabPage1;
        private Gizmox.WebGUI.Reporting.ReportViewer reportViewer1;
        private Button btnSummary;
        private Panel panel6;


    }
}