using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Captain.Common.Views.Forms
{
    partial class SSNSearchForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SSNSearchForm));
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.label8 = new Gizmox.WebGUI.Forms.Label();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.pictureBox2 = new Gizmox.WebGUI.Forms.PictureBox();
            this.btnSSNSelect = new Gizmox.WebGUI.Forms.Button();
            this.gvwSSNSearch = new Gizmox.WebGUI.Forms.DataGridView();
            this.SsnNo = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.SsnName = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.phone = new Gizmox.WebGUI.Forms.DataGridViewMaskedTextBoxColumn();
            this.address = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.AppKey = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.MemSeq = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dateTimePicker2 = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.panel7 = new Gizmox.WebGUI.Forms.Panel();
            this.panel8 = new Gizmox.WebGUI.Forms.Panel();
            this.btnSearch = new Gizmox.WebGUI.Forms.Button();
            this.mskSSNNO = new Gizmox.WebGUI.Forms.MaskedTextBox();
            this.txtLastName = new Gizmox.WebGUI.Forms.TextBox();
            this.txtFirstName = new Gizmox.WebGUI.Forms.TextBox();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.txtAlias = new Gizmox.WebGUI.Forms.TextBox();
            this.mskTelePhone = new Gizmox.WebGUI.Forms.MaskedTextBox();
            this.Addresspanel = new Gizmox.WebGUI.Forms.Panel();
            this.lblDOB = new Gizmox.WebGUI.Forms.Label();
            this.DOBReq = new Gizmox.WebGUI.Forms.Label();
            this.dtBirth = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.lblssnreq = new Gizmox.WebGUI.Forms.Label();
            this.label6 = new Gizmox.WebGUI.Forms.Label();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.cbduplicates = new Gizmox.WebGUI.Forms.CheckBox();
            this.lblSSN = new Gizmox.WebGUI.Forms.Label();
            this.label11 = new Gizmox.WebGUI.Forms.Label();
            this.txtState = new Gizmox.WebGUI.Forms.TextBox();
            this.txtCity = new Gizmox.WebGUI.Forms.TextBox();
            this.label10 = new Gizmox.WebGUI.Forms.Label();
            this.label9 = new Gizmox.WebGUI.Forms.Label();
            this.txtStreet = new Gizmox.WebGUI.Forms.TextBox();
            this.txtHouseNo = new Gizmox.WebGUI.Forms.TextBox();
            this.label7 = new Gizmox.WebGUI.Forms.Label();
            this.lblFooter = new Gizmox.WebGUI.Forms.Label();
            this.lblApp = new Gizmox.WebGUI.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwSSNSearch)).BeginInit();
            this.panel8.SuspendLayout();
            this.Addresspanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ExcludeFromUniqueId = false;
            this.label8.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(85, 15);
            this.label8.Name = "label8";
            this.label8.NextFocusId = ((long)(0));
            this.label8.PerformLayoutEnabled = true;
            this.label8.PreviousFocusId = ((long)(0));
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "SSN Search";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ExcludeFromUniqueId = false;
            this.label4.Location = new System.Drawing.Point(-58, 68);
            this.label4.Name = "label4";
            this.label4.NextFocusId = ((long)(0));
            this.label4.PerformLayoutEnabled = true;
            this.label4.PreviousFocusId = ((long)(0));
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Site No";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox2.ExcludeFromUniqueId = false;
            this.pictureBox2.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("pictureBox2.Image"));
            this.pictureBox2.Location = new System.Drawing.Point(20, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.NextFocusId = ((long)(0));
            this.pictureBox2.PerformLayoutEnabled = true;
            this.pictureBox2.PreviousFocusId = ((long)(0));
            this.pictureBox2.Size = new System.Drawing.Size(50, 46);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // btnSSNSelect
            // 
            this.btnSSNSelect.ExcludeFromUniqueId = false;
            this.btnSSNSelect.Location = new System.Drawing.Point(592, 366);
            this.btnSSNSelect.Name = "btnSSNSelect";
            this.btnSSNSelect.NextFocusId = ((long)(0));
            this.btnSSNSelect.PerformLayoutEnabled = true;
            this.btnSSNSelect.PreviousFocusId = ((long)(0));
            this.btnSSNSelect.Size = new System.Drawing.Size(71, 20);
            this.btnSSNSelect.TabIndex = 4;
            this.btnSSNSelect.Text = "&Select";
            this.btnSSNSelect.Click += new System.EventHandler(this.btnSSNSelect_Click);
            // 
            // gvwSSNSearch
            // 
            this.gvwSSNSearch.AllowUserToAddRows = false;
            this.gvwSSNSearch.AllowUserToDeleteRows = false;
            this.gvwSSNSearch.AllowUserToResizeColumns = false;
            this.gvwSSNSearch.AllowUserToResizeRows = false;
            this.gvwSSNSearch.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.FormatProvider = new System.Globalization.CultureInfo("en-US");
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.gvwSSNSearch.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvwSSNSearch.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvwSSNSearch.Columns.AddRange(new Gizmox.WebGUI.Forms.DataGridViewColumn[] {
            this.SsnNo,
            this.SsnName,
            this.phone,
            this.address,
            this.AppKey,
            this.MemSeq});
            this.gvwSSNSearch.ExcludeFromUniqueId = false;
            this.gvwSSNSearch.ItemsPerPage = 200;
            this.gvwSSNSearch.Location = new System.Drawing.Point(7, 143);
            this.gvwSSNSearch.MultiSelect = false;
            this.gvwSSNSearch.Name = "gvwSSNSearch";
            this.gvwSSNSearch.NextFocusId = ((long)(0));
            this.gvwSSNSearch.PerformLayoutEnabled = true;
            this.gvwSSNSearch.PreviousFocusId = ((long)(0));
            this.gvwSSNSearch.ReadOnly = true;
            this.gvwSSNSearch.RenderCellPanelsAsText = false;
            this.gvwSSNSearch.RowHeadersWidth = 20;
            this.gvwSSNSearch.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("en-US");
            this.gvwSSNSearch.RowTemplate.Enabled = true;
            this.gvwSSNSearch.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical;
            this.gvwSSNSearch.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvwSSNSearch.Size = new System.Drawing.Size(657, 215);
            this.gvwSSNSearch.TabIndex = 0;
            this.gvwSSNSearch.SelectionChanged += new System.EventHandler(this.gvwSSNSearch_SelectionChanged);
            // 
            // SsnNo
            // 
            this.SsnNo.DefaultCellStyle = dataGridViewCellStyle2;
            this.SsnNo.HeaderText = "SSN";
            this.SsnNo.Name = "SsnNo";
            this.SsnNo.ReadOnly = true;
            // 
            // SsnName
            // 
            this.SsnName.DefaultCellStyle = dataGridViewCellStyle3;
            this.SsnName.HeaderText = "Name";
            this.SsnName.Name = "SsnName";
            this.SsnName.ReadOnly = true;
            this.SsnName.Width = 190;
            // 
            // phone
            // 
            this.phone.DefaultCellStyle = dataGridViewCellStyle4;
            this.phone.HeaderText = "Phone";
            this.phone.Mask = "(999) 000-0000";
            this.phone.Name = "phone";
            this.phone.ReadOnly = true;
            this.phone.Width = 90;
            // 
            // address
            // 
            this.address.DefaultCellStyle = dataGridViewCellStyle5;
            this.address.HeaderText = "Address";
            this.address.Name = "address";
            this.address.ReadOnly = true;
            this.address.Width = 242;
            // 
            // AppKey
            // 
            this.AppKey.DefaultCellStyle = dataGridViewCellStyle6;
            this.AppKey.Name = "AppKey";
            this.AppKey.ReadOnly = true;
            this.AppKey.Visible = false;
            // 
            // MemSeq
            // 
            this.MemSeq.DefaultCellStyle = dataGridViewCellStyle7;
            this.MemSeq.Name = "MemSeq";
            this.MemSeq.ReadOnly = true;
            this.MemSeq.Visible = false;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "";
            this.dateTimePicker2.ExcludeFromUniqueId = false;
            this.dateTimePicker2.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.IsEmpty = false;
            this.dateTimePicker2.IsEmptyAllowed = false;
            this.dateTimePicker2.Location = new System.Drawing.Point(417, -219);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.NextFocusId = ((long)(0));
            this.dateTimePicker2.PerformLayoutEnabled = true;
            this.dateTimePicker2.PreviousFocusId = ((long)(0));
            this.dateTimePicker2.Size = new System.Drawing.Size(79, 21);
            this.dateTimePicker2.TabIndex = 15;
            // 
            // panel7
            // 
            this.panel7.ExcludeFromUniqueId = false;
            this.panel7.Location = new System.Drawing.Point(124, -249);
            this.panel7.Name = "panel7";
            this.panel7.NextFocusId = ((long)(0));
            this.panel7.PerformLayoutEnabled = true;
            this.panel7.PreviousFocusId = ((long)(0));
            this.panel7.Size = new System.Drawing.Size(415, 64);
            this.panel7.TabIndex = 0;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel8.Controls.Add(this.dateTimePicker2);
            this.panel8.Controls.Add(this.panel7);
            this.panel8.Controls.Add(this.label8);
            this.panel8.Controls.Add(this.pictureBox2);
            this.panel8.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel8.ExcludeFromUniqueId = false;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.NextFocusId = ((long)(0));
            this.panel8.PerformLayoutEnabled = true;
            this.panel8.PreviousFocusId = ((long)(0));
            this.panel8.Size = new System.Drawing.Size(670, 55);
            this.panel8.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.ExcludeFromUniqueId = false;
            this.btnSearch.Location = new System.Drawing.Point(556, 52);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.NextFocusId = ((long)(0));
            this.btnSearch.PerformLayoutEnabled = true;
            this.btnSearch.PreviousFocusId = ((long)(0));
            this.btnSearch.Size = new System.Drawing.Size(71, 20);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "&Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // mskSSNNO
            // 
            this.mskSSNNO.CustomStyle = "Masked";
            this.mskSSNNO.ExcludeFromUniqueId = false;
            this.mskSSNNO.Location = new System.Drawing.Point(55, 5);
            this.mskSSNNO.Mask = "000-00-0000";
            this.mskSSNNO.Name = "mskSSNNO";
            this.mskSSNNO.NextFocusId = ((long)(0));
            this.mskSSNNO.PerformLayoutEnabled = true;
            this.mskSSNNO.PreviousFocusId = ((long)(0));
            this.mskSSNNO.Size = new System.Drawing.Size(74, 20);
            this.mskSSNNO.TabIndex = 1;
            this.mskSSNNO.TextMaskFormat = Gizmox.WebGUI.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // txtLastName
            // 
            this.txtLastName.ExcludeFromUniqueId = false;
            this.txtLastName.Location = new System.Drawing.Point(399, 5);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.NextFocusId = ((long)(0));
            this.txtLastName.PerformLayoutEnabled = true;
            this.txtLastName.PreviousFocusId = ((long)(0));
            this.txtLastName.Size = new System.Drawing.Size(150, 20);
            this.txtLastName.TabIndex = 3;
            // 
            // txtFirstName
            // 
            this.txtFirstName.ExcludeFromUniqueId = false;
            this.txtFirstName.Location = new System.Drawing.Point(231, 4);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.NextFocusId = ((long)(0));
            this.txtFirstName.PerformLayoutEnabled = true;
            this.txtFirstName.PreviousFocusId = ((long)(0));
            this.txtFirstName.Size = new System.Drawing.Size(109, 20);
            this.txtFirstName.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ExcludeFromUniqueId = false;
            this.label3.Location = new System.Drawing.Point(343, 6);
            this.label3.Name = "label3";
            this.label3.NextFocusId = ((long)(0));
            this.label3.PerformLayoutEnabled = true;
            this.label3.PreviousFocusId = ((long)(0));
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Last Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ExcludeFromUniqueId = false;
            this.label2.Location = new System.Drawing.Point(175, 6);
            this.label2.Name = "label2";
            this.label2.NextFocusId = ((long)(0));
            this.label2.PerformLayoutEnabled = true;
            this.label2.PreviousFocusId = ((long)(0));
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "First Name";
            // 
            // txtAlias
            // 
            this.txtAlias.ExcludeFromUniqueId = false;
            this.txtAlias.Location = new System.Drawing.Point(56, 52);
            this.txtAlias.Name = "txtAlias";
            this.txtAlias.NextFocusId = ((long)(0));
            this.txtAlias.PerformLayoutEnabled = true;
            this.txtAlias.PreviousFocusId = ((long)(0));
            this.txtAlias.Size = new System.Drawing.Size(73, 20);
            this.txtAlias.TabIndex = 8;
            // 
            // mskTelePhone
            // 
            this.mskTelePhone.CustomStyle = "Masked";
            this.mskTelePhone.ExcludeFromUniqueId = false;
            this.mskTelePhone.Location = new System.Drawing.Point(231, 52);
            this.mskTelePhone.Mask = "(999) 000-0000";
            this.mskTelePhone.Name = "mskTelePhone";
            this.mskTelePhone.NextFocusId = ((long)(0));
            this.mskTelePhone.PerformLayoutEnabled = true;
            this.mskTelePhone.PreviousFocusId = ((long)(0));
            this.mskTelePhone.Size = new System.Drawing.Size(84, 20);
            this.mskTelePhone.TabIndex = 9;
            this.mskTelePhone.TextMaskFormat = Gizmox.WebGUI.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // Addresspanel
            // 
            this.Addresspanel.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.Addresspanel.Controls.Add(this.lblDOB);
            this.Addresspanel.Controls.Add(this.DOBReq);
            this.Addresspanel.Controls.Add(this.dtBirth);
            this.Addresspanel.Controls.Add(this.lblssnreq);
            this.Addresspanel.Controls.Add(this.label6);
            this.Addresspanel.Controls.Add(this.mskTelePhone);
            this.Addresspanel.Controls.Add(this.label5);
            this.Addresspanel.Controls.Add(this.txtAlias);
            this.Addresspanel.Controls.Add(this.cbduplicates);
            this.Addresspanel.Controls.Add(this.lblSSN);
            this.Addresspanel.Controls.Add(this.txtLastName);
            this.Addresspanel.Controls.Add(this.btnSearch);
            this.Addresspanel.Controls.Add(this.mskSSNNO);
            this.Addresspanel.Controls.Add(this.txtFirstName);
            this.Addresspanel.Controls.Add(this.label11);
            this.Addresspanel.Controls.Add(this.label3);
            this.Addresspanel.Controls.Add(this.label2);
            this.Addresspanel.Controls.Add(this.txtState);
            this.Addresspanel.Controls.Add(this.txtCity);
            this.Addresspanel.Controls.Add(this.label10);
            this.Addresspanel.Controls.Add(this.label9);
            this.Addresspanel.Controls.Add(this.txtStreet);
            this.Addresspanel.Controls.Add(this.txtHouseNo);
            this.Addresspanel.Controls.Add(this.label7);
            this.Addresspanel.ExcludeFromUniqueId = false;
            this.Addresspanel.Location = new System.Drawing.Point(-1, 55);
            this.Addresspanel.Name = "Addresspanel";
            this.Addresspanel.NextFocusId = ((long)(0));
            this.Addresspanel.PerformLayoutEnabled = true;
            this.Addresspanel.PreviousFocusId = ((long)(0));
            this.Addresspanel.Size = new System.Drawing.Size(671, 78);
            this.Addresspanel.TabIndex = 12;
            // 
            // lblDOB
            // 
            this.lblDOB.AutoSize = true;
            this.lblDOB.ExcludeFromUniqueId = false;
            this.lblDOB.Location = new System.Drawing.Point(344, 56);
            this.lblDOB.Name = "lblDOB";
            this.lblDOB.NextFocusId = ((long)(0));
            this.lblDOB.PerformLayoutEnabled = true;
            this.lblDOB.PreviousFocusId = ((long)(0));
            this.lblDOB.Size = new System.Drawing.Size(68, 13);
            this.lblDOB.TabIndex = 0;
            this.lblDOB.Text = "DOB";
            // 
            // DOBReq
            // 
            this.DOBReq.AutoSize = true;
            this.DOBReq.ExcludeFromUniqueId = false;
            this.DOBReq.ForeColor = System.Drawing.Color.Red;
            this.DOBReq.Location = new System.Drawing.Point(333, 56);
            this.DOBReq.Name = "DOBReq";
            this.DOBReq.NextFocusId = ((long)(0));
            this.DOBReq.PerformLayoutEnabled = true;
            this.DOBReq.PreviousFocusId = ((long)(0));
            this.DOBReq.Size = new System.Drawing.Size(13, 13);
            this.DOBReq.TabIndex = 28;
            this.DOBReq.Text = "*";
            this.DOBReq.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.DOBReq.Visible = false;
            // 
            // dtBirth
            // 
            this.dtBirth.Checked = false;
            this.dtBirth.CustomFormat = "MM/dd/yyyy";
            this.dtBirth.ExcludeFromUniqueId = false;
            this.dtBirth.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtBirth.IsEmpty = false;
            this.dtBirth.IsEmptyAllowed = false;
            this.dtBirth.Location = new System.Drawing.Point(399, 52);
            this.dtBirth.Name = "dtBirth";
            this.dtBirth.NextFocusId = ((long)(0));
            this.dtBirth.PerformLayoutEnabled = true;
            this.dtBirth.PreviousFocusId = ((long)(0));
            this.dtBirth.ShowCheckBox = true;
            this.dtBirth.Size = new System.Drawing.Size(110, 21);
            this.dtBirth.TabIndex = 9;
            // 
            // lblssnreq
            // 
            this.lblssnreq.AutoSize = true;
            this.lblssnreq.ExcludeFromUniqueId = false;
            this.lblssnreq.ForeColor = System.Drawing.Color.Red;
            this.lblssnreq.Location = new System.Drawing.Point(-5, 5);
            this.lblssnreq.Name = "lblssnreq";
            this.lblssnreq.NextFocusId = ((long)(0));
            this.lblssnreq.PerformLayoutEnabled = true;
            this.lblssnreq.PreviousFocusId = ((long)(0));
            this.lblssnreq.Size = new System.Drawing.Size(35, 13);
            this.lblssnreq.TabIndex = 16;
            this.lblssnreq.Text = "*";
            this.lblssnreq.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ExcludeFromUniqueId = false;
            this.label6.Location = new System.Drawing.Point(174, 54);
            this.label6.Name = "label6";
            this.label6.NextFocusId = ((long)(0));
            this.label6.PerformLayoutEnabled = true;
            this.label6.PreviousFocusId = ((long)(0));
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Phone";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ExcludeFromUniqueId = false;
            this.label5.Location = new System.Drawing.Point(6, 55);
            this.label5.Name = "label5";
            this.label5.NextFocusId = ((long)(0));
            this.label5.PerformLayoutEnabled = true;
            this.label5.PreviousFocusId = ((long)(0));
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Alias";
            // 
            // cbduplicates
            // 
            this.cbduplicates.AutoSize = true;
            this.cbduplicates.ExcludeFromUniqueId = false;
            this.cbduplicates.Location = new System.Drawing.Point(553, 32);
            this.cbduplicates.Name = "cbduplicates";
            this.cbduplicates.NextFocusId = ((long)(0));
            this.cbduplicates.PerformLayoutEnabled = true;
            this.cbduplicates.PreviousFocusId = ((long)(0));
            this.cbduplicates.Size = new System.Drawing.Size(104, 17);
            this.cbduplicates.TabIndex = 10;
            this.cbduplicates.Text = "Show Duplicates";
            this.cbduplicates.Visible = false;
            // 
            // lblSSN
            // 
            this.lblSSN.AutoSize = true;
            this.lblSSN.ExcludeFromUniqueId = false;
            this.lblSSN.Location = new System.Drawing.Point(6, 5);
            this.lblSSN.Name = "lblSSN";
            this.lblSSN.NextFocusId = ((long)(0));
            this.lblSSN.PerformLayoutEnabled = true;
            this.lblSSN.PreviousFocusId = ((long)(0));
            this.lblSSN.Size = new System.Drawing.Size(35, 13);
            this.lblSSN.TabIndex = 3;
            this.lblSSN.Text = "SSN";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ExcludeFromUniqueId = false;
            this.label11.Location = new System.Drawing.Point(493, 31);
            this.label11.Name = "label11";
            this.label11.NextFocusId = ((long)(0));
            this.label11.PerformLayoutEnabled = true;
            this.label11.PreviousFocusId = ((long)(0));
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "State";
            // 
            // txtState
            // 
            this.txtState.ExcludeFromUniqueId = false;
            this.txtState.Location = new System.Drawing.Point(528, 29);
            this.txtState.Name = "txtState";
            this.txtState.NextFocusId = ((long)(0));
            this.txtState.PerformLayoutEnabled = true;
            this.txtState.PreviousFocusId = ((long)(0));
            this.txtState.Size = new System.Drawing.Size(21, 20);
            this.txtState.TabIndex = 7;
            // 
            // txtCity
            // 
            this.txtCity.ExcludeFromUniqueId = false;
            this.txtCity.Location = new System.Drawing.Point(399, 29);
            this.txtCity.Name = "txtCity";
            this.txtCity.NextFocusId = ((long)(0));
            this.txtCity.PerformLayoutEnabled = true;
            this.txtCity.PreviousFocusId = ((long)(0));
            this.txtCity.Size = new System.Drawing.Size(86, 20);
            this.txtCity.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ExcludeFromUniqueId = false;
            this.label10.Location = new System.Drawing.Point(343, 32);
            this.label10.Name = "label10";
            this.label10.NextFocusId = ((long)(0));
            this.label10.PerformLayoutEnabled = true;
            this.label10.PreviousFocusId = ((long)(0));
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "City";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ExcludeFromUniqueId = false;
            this.label9.Location = new System.Drawing.Point(175, 32);
            this.label9.Name = "label9";
            this.label9.NextFocusId = ((long)(0));
            this.label9.PerformLayoutEnabled = true;
            this.label9.PreviousFocusId = ((long)(0));
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Street";
            // 
            // txtStreet
            // 
            this.txtStreet.ExcludeFromUniqueId = false;
            this.txtStreet.Location = new System.Drawing.Point(231, 28);
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.NextFocusId = ((long)(0));
            this.txtStreet.PerformLayoutEnabled = true;
            this.txtStreet.PreviousFocusId = ((long)(0));
            this.txtStreet.Size = new System.Drawing.Size(108, 20);
            this.txtStreet.TabIndex = 5;
            // 
            // txtHouseNo
            // 
            this.txtHouseNo.ExcludeFromUniqueId = false;
            this.txtHouseNo.Location = new System.Drawing.Point(56, 28);
            this.txtHouseNo.Name = "txtHouseNo";
            this.txtHouseNo.NextFocusId = ((long)(0));
            this.txtHouseNo.PerformLayoutEnabled = true;
            this.txtHouseNo.PreviousFocusId = ((long)(0));
            this.txtHouseNo.Size = new System.Drawing.Size(72, 20);
            this.txtHouseNo.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ExcludeFromUniqueId = false;
            this.label7.Location = new System.Drawing.Point(6, 32);
            this.label7.Name = "label7";
            this.label7.NextFocusId = ((long)(0));
            this.label7.PerformLayoutEnabled = true;
            this.label7.PreviousFocusId = ((long)(0));
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "House No";
            // 
            // lblFooter
            // 
            this.lblFooter.AutoSize = true;
            this.lblFooter.ExcludeFromUniqueId = false;
            this.lblFooter.Location = new System.Drawing.Point(9, 368);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.NextFocusId = ((long)(0));
            this.lblFooter.PerformLayoutEnabled = true;
            this.lblFooter.PreviousFocusId = ((long)(0));
            this.lblFooter.Size = new System.Drawing.Size(41, 13);
            this.lblFooter.TabIndex = 13;
            // 
            // lblApp
            // 
            this.lblApp.AutoSize = true;
            this.lblApp.ExcludeFromUniqueId = false;
            this.lblApp.Location = new System.Drawing.Point(8, 369);
            this.lblApp.Name = "lblApp";
            this.lblApp.NextFocusId = ((long)(0));
            this.lblApp.PerformLayoutEnabled = true;
            this.lblApp.PreviousFocusId = ((long)(0));
            this.lblApp.Size = new System.Drawing.Size(41, 13);
            this.lblApp.TabIndex = 14;
            // 
            // SSNSearchForm
            // 
            this.Controls.Add(this.lblApp);
            this.Controls.Add(this.lblFooter);
            this.Controls.Add(this.Addresspanel);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.gvwSSNSearch);
            this.Controls.Add(this.btnSSNSelect);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(670, 393);
            this.Text = "SSN Search";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwSSNSearch)).EndInit();
            this.panel8.ResumeLayout(false);
            this.Addresspanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Label label8;
        private Label label4;
        private PictureBox pictureBox2;
        private Button btnSSNSelect;
        private DataGridView gvwSSNSearch;
        private DataGridViewTextBoxColumn SsnName;
        private DateTimePicker dateTimePicker2;
        private Panel panel7;
        private Panel panel8;
        private Button btnSearch;
        private MaskedTextBox mskSSNNO;
        private TextBox txtLastName;
        private TextBox txtFirstName;
        private Label label3;
        private Label label2;
        private TextBox txtAlias;
        private MaskedTextBox mskTelePhone;
        private Panel Addresspanel;
        private Label label11;
        private TextBox txtState;
        private TextBox txtCity;
        private Label label10;
        private Label label9;
        private TextBox txtStreet;
        private TextBox txtHouseNo;
        private Label label7;
        private DataGridViewTextBoxColumn address;
        private CheckBox cbduplicates;
        private DataGridViewTextBoxColumn AppKey;
        private DataGridViewTextBoxColumn MemSeq;
        private Label label6;
        private Label label5;
        private Label lblSSN;
        private Label lblFooter;
        private DataGridViewMaskedTextBoxColumn phone;
        private Label lblApp;
        private Label lblssnreq;
        private Label lblDOB;
        private Label DOBReq;
        private DateTimePicker dtBirth;
        private DataGridViewTextBoxColumn SsnNo;
    }
}