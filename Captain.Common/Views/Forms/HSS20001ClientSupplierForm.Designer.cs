using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Captain.Common.Views.Forms
{
    partial class HSS20001ClientSupplierForm
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

        #region Visual WebGui Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HSS20001ClientSupplierForm));
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.gvwSupplierDetails = new Gizmox.WebGUI.Forms.DataGridView();
            this.gvtSeq = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.gvtSupplierType = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.gvtVendorName = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.gvtPayfor = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.gvtAccountNo = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.gvtPrimaryCode = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.gvtPayforcode = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.gvPassFail = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.gviEdit = new Gizmox.WebGUI.Forms.DataGridViewImageColumn();
            this.gvtSelected = new Gizmox.WebGUI.Forms.DataGridViewImageColumn();
            this.gviDel = new Gizmox.WebGUI.Forms.DataGridViewImageColumn();
            this.contextMenu1 = new Gizmox.WebGUI.Forms.ContextMenu();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.lblReverified = new Gizmox.WebGUI.Forms.Label();
            this.chkReverify = new Gizmox.WebGUI.Forms.CheckBox();
            this.lblTypeReq = new Gizmox.WebGUI.Forms.Label();
            this.lblSupplierType = new Gizmox.WebGUI.Forms.Label();
            this.cmbSupplierType = new Gizmox.WebGUI.Forms.ComboBox();
            this.txtPrimary = new Gizmox.WebGUI.Forms.TextBox();
            this.lblAccountReq = new Gizmox.WebGUI.Forms.Label();
            this.lblBillingReq = new Gizmox.WebGUI.Forms.Label();
            this.txtVendorName = new Gizmox.WebGUI.Forms.TextBox();
            this.txtVendorId = new Gizmox.WebGUI.Forms.TextBox();
            this.lblPayforReq = new Gizmox.WebGUI.Forms.Label();
            this.lblVendor = new Gizmox.WebGUI.Forms.Label();
            this.picAddClient = new Gizmox.WebGUI.Forms.PictureBox();
            this.lblvendorReq = new Gizmox.WebGUI.Forms.Label();
            this.txtLast = new Gizmox.WebGUI.Forms.TextBox();
            this.btnvendor = new Gizmox.WebGUI.Forms.Button();
            this.lblLast = new Gizmox.WebGUI.Forms.Label();
            this.lblFirst = new Gizmox.WebGUI.Forms.Label();
            this.txtFirst = new Gizmox.WebGUI.Forms.TextBox();
            this.txtAccountNo = new Gizmox.WebGUI.Forms.TextBox();
            this.lblAccount = new Gizmox.WebGUI.Forms.Label();
            this.lblBillingName = new Gizmox.WebGUI.Forms.Label();
            this.cmbBilling = new Gizmox.WebGUI.Forms.ComboBox();
            this.cmbPayfor = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblPayfor = new Gizmox.WebGUI.Forms.Label();
            this.pnlAdd = new Gizmox.WebGUI.Forms.Panel();
            this.btnCancel = new Gizmox.WebGUI.Forms.Button();
            this.btnSave = new Gizmox.WebGUI.Forms.Button();
            this.lblMsg = new Gizmox.WebGUI.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gvwSupplierDetails)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAddClient)).BeginInit();
            this.pnlAdd.SuspendLayout();
            this.SuspendLayout();
            // 
            // gvwSupplierDetails
            // 
            this.gvwSupplierDetails.AllowUserToAddRows = false;
            this.gvwSupplierDetails.AllowUserToDeleteRows = false;
            this.gvwSupplierDetails.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.FormatProvider = new System.Globalization.CultureInfo("en-US");
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.gvwSupplierDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvwSupplierDetails.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvwSupplierDetails.Columns.AddRange(new Gizmox.WebGUI.Forms.DataGridViewColumn[] {
            this.gvtSeq,
            this.gvtSupplierType,
            this.gvtVendorName,
            this.gvtPayfor,
            this.gvtAccountNo,
            this.gvtPrimaryCode,
            this.gvtPayforcode,
            this.gvPassFail,
            this.gviEdit,
            this.gvtSelected,
            this.gviDel});
            this.gvwSupplierDetails.ContextMenu = this.contextMenu1;
            this.gvwSupplierDetails.ExcludeFromUniqueId = false;
            this.gvwSupplierDetails.Location = new System.Drawing.Point(1, 3);
            this.gvwSupplierDetails.Name = "gvwSupplierDetails";
            this.gvwSupplierDetails.NextFocusId = ((long)(0));
            this.gvwSupplierDetails.PerformLayoutEnabled = true;
            this.gvwSupplierDetails.PreviousFocusId = ((long)(0));
            this.gvwSupplierDetails.ReadOnly = true;
            this.gvwSupplierDetails.RenderCellPanelsAsText = false;
            this.gvwSupplierDetails.RowHeadersVisible = false;
            this.gvwSupplierDetails.RowHeadersWidth = 4;
            this.gvwSupplierDetails.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("en-US");
            this.gvwSupplierDetails.RowTemplate.Enabled = true;
            this.gvwSupplierDetails.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical;
            this.gvwSupplierDetails.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvwSupplierDetails.Size = new System.Drawing.Size(634, 131);
            this.gvwSupplierDetails.TabIndex = 0;
            this.gvwSupplierDetails.CellClick += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.gvwSupplierDetails_CellClick);
            this.gvwSupplierDetails.SelectionChanged += new System.EventHandler(this.gvwSupplierDetails_SelectionChanged);
            this.gvwSupplierDetails.MenuClick += new Gizmox.WebGUI.Forms.MenuEventHandler(this.gvwSupplierDetails_MenuClick);
            // 
            // gvtSeq
            // 
            this.gvtSeq.DefaultCellStyle = dataGridViewCellStyle25;
            this.gvtSeq.HeaderText = " ";
            this.gvtSeq.Name = "gvtSeq";
            this.gvtSeq.ReadOnly = true;
            this.gvtSeq.Visible = false;
            this.gvtSeq.Width = 5;
            // 
            // gvtSupplierType
            // 
            dataGridViewCellStyle26.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle26.FormatProvider = new System.Globalization.CultureInfo("en-US");
            this.gvtSupplierType.DefaultCellStyle = dataGridViewCellStyle26;
            this.gvtSupplierType.HeaderText = "Supplier Type";
            this.gvtSupplierType.Name = "gvtSupplierType";
            this.gvtSupplierType.ReadOnly = true;
            // 
            // gvtVendorName
            // 
            this.gvtVendorName.DefaultCellStyle = dataGridViewCellStyle27;
            this.gvtVendorName.HeaderText = "Vendor Name";
            this.gvtVendorName.Name = "gvtVendorName";
            this.gvtVendorName.ReadOnly = true;
            this.gvtVendorName.Width = 190;
            // 
            // gvtPayfor
            // 
            dataGridViewCellStyle28.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle28.FormatProvider = new System.Globalization.CultureInfo("en-US");
            this.gvtPayfor.DefaultCellStyle = dataGridViewCellStyle28;
            this.gvtPayfor.HeaderText = "Pay for";
            this.gvtPayfor.Name = "gvtPayfor";
            this.gvtPayfor.ReadOnly = true;
            this.gvtPayfor.Width = 80;
            // 
            // gvtAccountNo
            // 
            dataGridViewCellStyle29.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle29.FormatProvider = new System.Globalization.CultureInfo("en-US");
            this.gvtAccountNo.DefaultCellStyle = dataGridViewCellStyle29;
            this.gvtAccountNo.HeaderText = "Account Number";
            this.gvtAccountNo.Name = "gvtAccountNo";
            this.gvtAccountNo.ReadOnly = true;
            this.gvtAccountNo.Width = 150;
            // 
            // gvtPrimaryCode
            // 
            this.gvtPrimaryCode.DefaultCellStyle = dataGridViewCellStyle30;
            this.gvtPrimaryCode.HeaderText = " ";
            this.gvtPrimaryCode.Name = "gvtPrimaryCode";
            this.gvtPrimaryCode.ReadOnly = true;
            this.gvtPrimaryCode.Visible = false;
            // 
            // gvtPayforcode
            // 
            this.gvtPayforcode.DefaultCellStyle = dataGridViewCellStyle31;
            this.gvtPayforcode.HeaderText = "  ";
            this.gvtPayforcode.Name = "gvtPayforcode";
            this.gvtPayforcode.ReadOnly = true;
            this.gvtPayforcode.Visible = false;
            this.gvtPayforcode.Width = 20;
            // 
            // gvPassFail
            // 
            dataGridViewCellStyle32.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle32.FormatProvider = new System.Globalization.CultureInfo("en-US");
            this.gvPassFail.DefaultCellStyle = dataGridViewCellStyle32;
            this.gvPassFail.HeaderText = "P/F";
            this.gvPassFail.Name = "gvPassFail";
            this.gvPassFail.ReadOnly = true;
            this.gvPassFail.Width = 50;
            // 
            // gviEdit
            // 
            dataGridViewCellStyle33.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle33.NullValue = null;
            this.gviEdit.DefaultCellStyle = dataGridViewCellStyle33;
            this.gviEdit.HeaderText = "Edit";
            this.gviEdit.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("gviEdit.Image"));
            this.gviEdit.Name = "gviEdit";
            this.gviEdit.ReadOnly = true;
            this.gviEdit.Width = 32;
            // 
            // gvtSelected
            // 
            dataGridViewCellStyle34.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle34.NullValue = null;
            this.gvtSelected.DefaultCellStyle = dataGridViewCellStyle34;
            this.gvtSelected.HeaderText = "Verified";
            this.gvtSelected.Name = "gvtSelected";
            this.gvtSelected.ReadOnly = true;
            this.gvtSelected.Visible = false;
            this.gvtSelected.Width = 60;
            // 
            // gviDel
            // 
            dataGridViewCellStyle35.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle35.NullValue = null;
            this.gviDel.DefaultCellStyle = dataGridViewCellStyle35;
            this.gviDel.HeaderText = "Del";
            this.gviDel.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("gviDel.Image"));
            this.gviDel.Name = "gviDel";
            this.gviDel.ReadOnly = true;
            this.gviDel.Width = 32;
            // 
            // contextMenu1
            // 
            this.contextMenu1.ExcludeFromUniqueId = false;
            this.contextMenu1.Popup += new System.EventHandler(this.contextMenu1_Popup);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblMsg);
            this.panel1.Controls.Add(this.lblReverified);
            this.panel1.Controls.Add(this.chkReverify);
            this.panel1.Controls.Add(this.lblTypeReq);
            this.panel1.Controls.Add(this.lblSupplierType);
            this.panel1.Controls.Add(this.cmbSupplierType);
            this.panel1.Controls.Add(this.txtPrimary);
            this.panel1.Controls.Add(this.lblAccountReq);
            this.panel1.Controls.Add(this.lblBillingReq);
            this.panel1.Controls.Add(this.txtVendorName);
            this.panel1.Controls.Add(this.txtVendorId);
            this.panel1.Controls.Add(this.lblPayforReq);
            this.panel1.Controls.Add(this.lblVendor);
            this.panel1.Controls.Add(this.picAddClient);
            this.panel1.Controls.Add(this.lblvendorReq);
            this.panel1.Controls.Add(this.txtLast);
            this.panel1.Controls.Add(this.btnvendor);
            this.panel1.Controls.Add(this.lblLast);
            this.panel1.Controls.Add(this.lblFirst);
            this.panel1.Controls.Add(this.txtFirst);
            this.panel1.Controls.Add(this.txtAccountNo);
            this.panel1.Controls.Add(this.lblAccount);
            this.panel1.Controls.Add(this.lblBillingName);
            this.panel1.Controls.Add(this.cmbBilling);
            this.panel1.Controls.Add(this.cmbPayfor);
            this.panel1.Controls.Add(this.lblPayfor);
            this.panel1.ExcludeFromUniqueId = false;
            this.panel1.Location = new System.Drawing.Point(1, 139);
            this.panel1.Name = "panel1";
            this.panel1.NextFocusId = ((long)(0));
            this.panel1.PerformLayoutEnabled = true;
            this.panel1.PreviousFocusId = ((long)(0));
            this.panel1.Size = new System.Drawing.Size(633, 120);
            this.panel1.TabIndex = 1;
            // 
            // lblReverified
            // 
            this.lblReverified.AutoSize = true;
            this.lblReverified.ExcludeFromUniqueId = false;
            this.lblReverified.Location = new System.Drawing.Point(270, 95);
            this.lblReverified.Name = "lblReverified";
            this.lblReverified.NextFocusId = ((long)(0));
            this.lblReverified.PerformLayoutEnabled = true;
            this.lblReverified.PreviousFocusId = ((long)(0));
            this.lblReverified.Size = new System.Drawing.Size(35, 13);
            this.lblReverified.TabIndex = 31;
            this.lblReverified.Text = " .";
            this.lblReverified.Visible = false;
            // 
            // chkReverify
            // 
            this.chkReverify.AutoSize = true;
            this.chkReverify.Enabled = false;
            this.chkReverify.ExcludeFromUniqueId = false;
            this.chkReverify.Location = new System.Drawing.Point(84, 94);
            this.chkReverify.Name = "chkReverify";
            this.chkReverify.NextFocusId = ((long)(0));
            this.chkReverify.PerformLayoutEnabled = true;
            this.chkReverify.PreviousFocusId = ((long)(0));
            this.chkReverify.Size = new System.Drawing.Size(78, 17);
            this.chkReverify.TabIndex = 30;
            this.chkReverify.Text = "Re Verified";
            this.chkReverify.Visible = false;
            // 
            // lblTypeReq
            // 
            this.lblTypeReq.AutoSize = true;
            this.lblTypeReq.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Transparent);
            this.lblTypeReq.ExcludeFromUniqueId = false;
            this.lblTypeReq.ForeColor = System.Drawing.Color.Red;
            this.lblTypeReq.Location = new System.Drawing.Point(477, 3);
            this.lblTypeReq.Name = "lblTypeReq";
            this.lblTypeReq.NextFocusId = ((long)(0));
            this.lblTypeReq.PerformLayoutEnabled = true;
            this.lblTypeReq.PreviousFocusId = ((long)(0));
            this.lblTypeReq.Size = new System.Drawing.Size(13, 13);
            this.lblTypeReq.TabIndex = 28;
            this.lblTypeReq.Text = "*";
            this.lblTypeReq.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblSupplierType
            // 
            this.lblSupplierType.AutoSize = true;
            this.lblSupplierType.ExcludeFromUniqueId = false;
            this.lblSupplierType.Location = new System.Drawing.Point(488, 7);
            this.lblSupplierType.Name = "lblSupplierType";
            this.lblSupplierType.NextFocusId = ((long)(0));
            this.lblSupplierType.PerformLayoutEnabled = true;
            this.lblSupplierType.PreviousFocusId = ((long)(0));
            this.lblSupplierType.Size = new System.Drawing.Size(41, 13);
            this.lblSupplierType.TabIndex = 0;
            this.lblSupplierType.Text = "Type";
            // 
            // cmbSupplierType
            // 
            this.cmbSupplierType.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cmbSupplierType.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cmbSupplierType.Enabled = false;
            this.cmbSupplierType.ExcludeFromUniqueId = false;
            this.cmbSupplierType.FormattingEnabled = true;
            this.cmbSupplierType.Location = new System.Drawing.Point(522, 7);
            this.cmbSupplierType.Name = "cmbSupplierType";
            this.cmbSupplierType.NextFocusId = ((long)(0));
            this.cmbSupplierType.PerformLayoutEnabled = true;
            this.cmbSupplierType.PreviousFocusId = ((long)(0));
            this.cmbSupplierType.Size = new System.Drawing.Size(68, 21);
            this.cmbSupplierType.TabIndex = 3;
            this.cmbSupplierType.SelectedIndexChanged += new System.EventHandler(this.cmbSupplierType_SelectedIndexChanged);
            // 
            // txtPrimary
            // 
            this.txtPrimary.Enabled = false;
            this.txtPrimary.ExcludeFromUniqueId = false;
            this.txtPrimary.Location = new System.Drawing.Point(493, 6);
            this.txtPrimary.Name = "txtPrimary";
            this.txtPrimary.NextFocusId = ((long)(0));
            this.txtPrimary.PerformLayoutEnabled = true;
            this.txtPrimary.PreviousFocusId = ((long)(0));
            this.txtPrimary.Size = new System.Drawing.Size(20, 20);
            this.txtPrimary.TabIndex = 29;
            this.txtPrimary.Visible = false;
            // 
            // lblAccountReq
            // 
            this.lblAccountReq.AutoSize = true;
            this.lblAccountReq.ExcludeFromUniqueId = false;
            this.lblAccountReq.ForeColor = System.Drawing.Color.Red;
            this.lblAccountReq.Location = new System.Drawing.Point(234, 5);
            this.lblAccountReq.Name = "lblAccountReq";
            this.lblAccountReq.NextFocusId = ((long)(0));
            this.lblAccountReq.PerformLayoutEnabled = true;
            this.lblAccountReq.PreviousFocusId = ((long)(0));
            this.lblAccountReq.Size = new System.Drawing.Size(30, 10);
            this.lblAccountReq.TabIndex = 28;
            this.lblAccountReq.Text = "*";
            this.lblAccountReq.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblAccountReq.Visible = false;
            // 
            // lblBillingReq
            // 
            this.lblBillingReq.AutoSize = true;
            this.lblBillingReq.ExcludeFromUniqueId = false;
            this.lblBillingReq.ForeColor = System.Drawing.Color.Red;
            this.lblBillingReq.Location = new System.Drawing.Point(2, 66);
            this.lblBillingReq.Name = "lblBillingReq";
            this.lblBillingReq.NextFocusId = ((long)(0));
            this.lblBillingReq.PerformLayoutEnabled = true;
            this.lblBillingReq.PreviousFocusId = ((long)(0));
            this.lblBillingReq.Size = new System.Drawing.Size(30, 10);
            this.lblBillingReq.TabIndex = 28;
            this.lblBillingReq.Text = "*";
            this.lblBillingReq.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblBillingReq.Visible = false;
            // 
            // txtVendorName
            // 
            this.txtVendorName.ExcludeFromUniqueId = false;
            this.txtVendorName.Location = new System.Drawing.Point(235, 35);
            this.txtVendorName.Name = "txtVendorName";
            this.txtVendorName.NextFocusId = ((long)(0));
            this.txtVendorName.PerformLayoutEnabled = true;
            this.txtVendorName.PreviousFocusId = ((long)(0));
            this.txtVendorName.ReadOnly = true;
            this.txtVendorName.Size = new System.Drawing.Size(358, 20);
            this.txtVendorName.TabIndex = 6;
            // 
            // txtVendorId
            // 
            this.txtVendorId.Enabled = false;
            this.txtVendorId.ExcludeFromUniqueId = false;
            this.txtVendorId.Location = new System.Drawing.Point(84, 35);
            this.txtVendorId.MaxLength = 5;
            this.txtVendorId.Name = "txtVendorId";
            this.txtVendorId.NextFocusId = ((long)(0));
            this.txtVendorId.PerformLayoutEnabled = true;
            this.txtVendorId.PreviousFocusId = ((long)(0));
            this.txtVendorId.Size = new System.Drawing.Size(69, 20);
            this.txtVendorId.TabIndex = 4;
            this.txtVendorId.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.txtVendorId.TextChanged += new System.EventHandler(this.txtVendorId_TextChanged);
            // 
            // lblPayforReq
            // 
            this.lblPayforReq.AutoSize = true;
            this.lblPayforReq.ExcludeFromUniqueId = false;
            this.lblPayforReq.ForeColor = System.Drawing.Color.Red;
            this.lblPayforReq.Location = new System.Drawing.Point(2, 7);
            this.lblPayforReq.Name = "lblPayforReq";
            this.lblPayforReq.NextFocusId = ((long)(0));
            this.lblPayforReq.PerformLayoutEnabled = true;
            this.lblPayforReq.PreviousFocusId = ((long)(0));
            this.lblPayforReq.Size = new System.Drawing.Size(30, 10);
            this.lblPayforReq.TabIndex = 28;
            this.lblPayforReq.Text = "*";
            this.lblPayforReq.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblPayforReq.Visible = false;
            // 
            // lblVendor
            // 
            this.lblVendor.AutoSize = true;
            this.lblVendor.ExcludeFromUniqueId = false;
            this.lblVendor.Location = new System.Drawing.Point(13, 35);
            this.lblVendor.Name = "lblVendor";
            this.lblVendor.NextFocusId = ((long)(0));
            this.lblVendor.PerformLayoutEnabled = true;
            this.lblVendor.PreviousFocusId = ((long)(0));
            this.lblVendor.Size = new System.Drawing.Size(41, 13);
            this.lblVendor.TabIndex = 0;
            this.lblVendor.Text = "Vendor";
            // 
            // picAddClient
            // 
            this.picAddClient.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.picAddClient.ExcludeFromUniqueId = false;
            this.picAddClient.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("picAddClient.Image"));
            this.picAddClient.Location = new System.Drawing.Point(606, 7);
            this.picAddClient.Name = "picAddClient";
            this.picAddClient.NextFocusId = ((long)(0));
            this.picAddClient.PerformLayoutEnabled = true;
            this.picAddClient.PreviousFocusId = ((long)(0));
            this.picAddClient.Size = new System.Drawing.Size(16, 16);
            this.picAddClient.TabIndex = 2;
            this.picAddClient.TabStop = false;
            this.picAddClient.Text = "Add Supplier";
            this.picAddClient.Click += new System.EventHandler(this.picAddScale_Click);
            // 
            // lblvendorReq
            // 
            this.lblvendorReq.AutoSize = true;
            this.lblvendorReq.ExcludeFromUniqueId = false;
            this.lblvendorReq.ForeColor = System.Drawing.Color.Red;
            this.lblvendorReq.Location = new System.Drawing.Point(2, 35);
            this.lblvendorReq.Name = "lblvendorReq";
            this.lblvendorReq.NextFocusId = ((long)(0));
            this.lblvendorReq.PerformLayoutEnabled = true;
            this.lblvendorReq.PreviousFocusId = ((long)(0));
            this.lblvendorReq.Size = new System.Drawing.Size(13, 13);
            this.lblvendorReq.TabIndex = 28;
            this.lblvendorReq.Text = "*";
            this.lblvendorReq.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblvendorReq.Visible = false;
            // 
            // txtLast
            // 
            this.txtLast.Enabled = false;
            this.txtLast.ExcludeFromUniqueId = false;
            this.txtLast.Location = new System.Drawing.Point(449, 63);
            this.txtLast.MaxLength = 20;
            this.txtLast.Name = "txtLast";
            this.txtLast.NextFocusId = ((long)(0));
            this.txtLast.PerformLayoutEnabled = true;
            this.txtLast.PreviousFocusId = ((long)(0));
            this.txtLast.Size = new System.Drawing.Size(144, 20);
            this.txtLast.TabIndex = 9;
            // 
            // btnvendor
            // 
            this.btnvendor.Enabled = false;
            this.btnvendor.ExcludeFromUniqueId = false;
            this.btnvendor.Location = new System.Drawing.Point(193, 33);
            this.btnvendor.Name = "btnvendor";
            this.btnvendor.NextFocusId = ((long)(0));
            this.btnvendor.PerformLayoutEnabled = true;
            this.btnvendor.PreviousFocusId = ((long)(0));
            this.btnvendor.Size = new System.Drawing.Size(30, 23);
            this.btnvendor.TabIndex = 5;
            this.btnvendor.Text = "...";
            this.btnvendor.Click += new System.EventHandler(this.btnvendor_Click);
            // 
            // lblLast
            // 
            this.lblLast.AutoSize = true;
            this.lblLast.ExcludeFromUniqueId = false;
            this.lblLast.Location = new System.Drawing.Point(420, 66);
            this.lblLast.Name = "lblLast";
            this.lblLast.NextFocusId = ((long)(0));
            this.lblLast.PerformLayoutEnabled = true;
            this.lblLast.PreviousFocusId = ((long)(0));
            this.lblLast.Size = new System.Drawing.Size(35, 13);
            this.lblLast.TabIndex = 11;
            this.lblLast.Text = "Last";
            // 
            // lblFirst
            // 
            this.lblFirst.AutoSize = true;
            this.lblFirst.ExcludeFromUniqueId = false;
            this.lblFirst.Location = new System.Drawing.Point(270, 65);
            this.lblFirst.Name = "lblFirst";
            this.lblFirst.NextFocusId = ((long)(0));
            this.lblFirst.PerformLayoutEnabled = true;
            this.lblFirst.PreviousFocusId = ((long)(0));
            this.lblFirst.Size = new System.Drawing.Size(35, 13);
            this.lblFirst.TabIndex = 11;
            this.lblFirst.Text = "First";
            // 
            // txtFirst
            // 
            this.txtFirst.Enabled = false;
            this.txtFirst.ExcludeFromUniqueId = false;
            this.txtFirst.Location = new System.Drawing.Point(301, 63);
            this.txtFirst.MaxLength = 20;
            this.txtFirst.Name = "txtFirst";
            this.txtFirst.NextFocusId = ((long)(0));
            this.txtFirst.PerformLayoutEnabled = true;
            this.txtFirst.PreviousFocusId = ((long)(0));
            this.txtFirst.Size = new System.Drawing.Size(118, 20);
            this.txtFirst.TabIndex = 8;
            // 
            // txtAccountNo
            // 
            this.txtAccountNo.Enabled = false;
            this.txtAccountNo.ExcludeFromUniqueId = false;
            this.txtAccountNo.Location = new System.Drawing.Point(302, 7);
            this.txtAccountNo.MaxLength = 20;
            this.txtAccountNo.Name = "txtAccountNo";
            this.txtAccountNo.NextFocusId = ((long)(0));
            this.txtAccountNo.PerformLayoutEnabled = true;
            this.txtAccountNo.PreviousFocusId = ((long)(0));
            this.txtAccountNo.RightToLeft = Gizmox.WebGUI.Forms.RightToLeft.No;
            this.txtAccountNo.Size = new System.Drawing.Size(160, 20);
            this.txtAccountNo.TabIndex = 2;
            this.txtAccountNo.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.txtAccountNo.Leave += new System.EventHandler(this.txtAccountNo_Leave);
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.ExcludeFromUniqueId = false;
            this.lblAccount.Location = new System.Drawing.Point(244, 7);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.NextFocusId = ((long)(0));
            this.lblAccount.PerformLayoutEnabled = true;
            this.lblAccount.PreviousFocusId = ((long)(0));
            this.lblAccount.Size = new System.Drawing.Size(35, 13);
            this.lblAccount.TabIndex = 11;
            this.lblAccount.Text = "Account#";
            // 
            // lblBillingName
            // 
            this.lblBillingName.AutoSize = true;
            this.lblBillingName.ExcludeFromUniqueId = false;
            this.lblBillingName.Location = new System.Drawing.Point(13, 66);
            this.lblBillingName.Name = "lblBillingName";
            this.lblBillingName.NextFocusId = ((long)(0));
            this.lblBillingName.PerformLayoutEnabled = true;
            this.lblBillingName.PreviousFocusId = ((long)(0));
            this.lblBillingName.Size = new System.Drawing.Size(35, 13);
            this.lblBillingName.TabIndex = 11;
            this.lblBillingName.Text = "Billing Name";
            // 
            // cmbBilling
            // 
            this.cmbBilling.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cmbBilling.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cmbBilling.Enabled = false;
            this.cmbBilling.ExcludeFromUniqueId = false;
            this.cmbBilling.FormattingEnabled = true;
            this.cmbBilling.Location = new System.Drawing.Point(84, 62);
            this.cmbBilling.Name = "cmbBilling";
            this.cmbBilling.NextFocusId = ((long)(0));
            this.cmbBilling.PerformLayoutEnabled = true;
            this.cmbBilling.PreviousFocusId = ((long)(0));
            this.cmbBilling.Size = new System.Drawing.Size(139, 21);
            this.cmbBilling.TabIndex = 7;
            this.cmbBilling.SelectedIndexChanged += new System.EventHandler(this.cmbBilling_SelectedIndexChanged);
            // 
            // cmbPayfor
            // 
            this.cmbPayfor.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cmbPayfor.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cmbPayfor.Enabled = false;
            this.cmbPayfor.ExcludeFromUniqueId = false;
            this.cmbPayfor.FormattingEnabled = true;
            this.cmbPayfor.Location = new System.Drawing.Point(84, 7);
            this.cmbPayfor.Name = "cmbPayfor";
            this.cmbPayfor.NextFocusId = ((long)(0));
            this.cmbPayfor.PerformLayoutEnabled = true;
            this.cmbPayfor.PreviousFocusId = ((long)(0));
            this.cmbPayfor.Size = new System.Drawing.Size(139, 21);
            this.cmbPayfor.TabIndex = 1;
            this.cmbPayfor.SelectedIndexChanged += new System.EventHandler(this.cmbPayfor_SelectedIndexChanged);
            // 
            // lblPayfor
            // 
            this.lblPayfor.AutoSize = true;
            this.lblPayfor.ExcludeFromUniqueId = false;
            this.lblPayfor.Location = new System.Drawing.Point(13, 10);
            this.lblPayfor.Name = "lblPayfor";
            this.lblPayfor.NextFocusId = ((long)(0));
            this.lblPayfor.PerformLayoutEnabled = true;
            this.lblPayfor.PreviousFocusId = ((long)(0));
            this.lblPayfor.Size = new System.Drawing.Size(35, 13);
            this.lblPayfor.TabIndex = 11;
            this.lblPayfor.Text = "Pay For";
            // 
            // pnlAdd
            // 
            this.pnlAdd.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.pnlAdd.Controls.Add(this.btnCancel);
            this.pnlAdd.Controls.Add(this.btnSave);
            this.pnlAdd.ExcludeFromUniqueId = false;
            this.pnlAdd.Location = new System.Drawing.Point(1, 258);
            this.pnlAdd.Name = "pnlAdd";
            this.pnlAdd.NextFocusId = ((long)(0));
            this.pnlAdd.PerformLayoutEnabled = true;
            this.pnlAdd.PreviousFocusId = ((long)(0));
            this.pnlAdd.Size = new System.Drawing.Size(632, 31);
            this.pnlAdd.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.ExcludeFromUniqueId = false;
            this.btnCancel.Location = new System.Drawing.Point(564, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NextFocusId = ((long)(0));
            this.btnCancel.PerformLayoutEnabled = true;
            this.btnCancel.PreviousFocusId = ((long)(0));
            this.btnCancel.Size = new System.Drawing.Size(63, 26);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.ExcludeFromUniqueId = false;
            this.btnSave.Location = new System.Drawing.Point(490, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.NextFocusId = ((long)(0));
            this.btnSave.PerformLayoutEnabled = true;
            this.btnSave.PreviousFocusId = ((long)(0));
            this.btnSave.Size = new System.Drawing.Size(63, 26);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.ExcludeFromUniqueId = false;
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(13, 95);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.NextFocusId = ((long)(0));
            this.lblMsg.PerformLayoutEnabled = true;
            this.lblMsg.PreviousFocusId = ((long)(0));
            this.lblMsg.Size = new System.Drawing.Size(42, 17);
            this.lblMsg.TabIndex = 32;
            this.lblMsg.Text = "label1";
            this.lblMsg.Visible = false;
            // 
            // HSS20001ClientSupplierForm
            // 
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gvwSupplierDetails);
            this.Controls.Add(this.pnlAdd);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(641, 293);
            this.Text = "HSS20001ClientSupplierForm";
            this.Load += new System.EventHandler(this.HSS20001ClientSupplierForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvwSupplierDetails)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picAddClient)).EndInit();
            this.pnlAdd.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView gvwSupplierDetails;
        private DataGridViewTextBoxColumn gvtSupplierType;
        private DataGridViewTextBoxColumn gvtVendorName;
        private DataGridViewTextBoxColumn gvtPayfor;
        private DataGridViewTextBoxColumn gvtAccountNo;
        private DataGridViewImageColumn gviEdit;
        private DataGridViewImageColumn gviDel;
        private Panel panel1;
        private Panel pnlAdd;
        private TextBox txtLast;
        private Label lblLast;
        private Label lblFirst;
        private TextBox txtFirst;
        private TextBox txtAccountNo;
        private Label lblAccount;
        private Label lblBillingName;
        private ComboBox cmbBilling;
        private ComboBox cmbPayfor;
        private Label lblPayfor;
        private Button btnvendor;
        private TextBox txtVendorId;
        private Label lblVendor;
        private TextBox txtVendorName;
        private Button btnCancel;
        private Button btnSave;
        private PictureBox picAddClient;
        private Label lblPayforReq;
        private Label lblvendorReq;
        private DataGridViewTextBoxColumn gvtSeq;
        private ContextMenu contextMenu1;
        private DataGridViewTextBoxColumn gvtPrimaryCode;
        private Label lblAccountReq;
        private Label lblBillingReq;
        private TextBox txtPrimary;
        private DataGridViewTextBoxColumn gvtPayforcode;
        private Label lblTypeReq;
        private Label lblSupplierType;
        private ComboBox cmbSupplierType;
        private Label lblReverified;
        private CheckBox chkReverify;
        private DataGridViewImageColumn gvtSelected;
        private DataGridViewTextBoxColumn gvPassFail;
        private Label lblMsg;
    }
}