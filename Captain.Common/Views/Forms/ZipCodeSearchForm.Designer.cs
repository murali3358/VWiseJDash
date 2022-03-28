using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Captain.Common.Views.Forms
{
    partial class ZipCodeSearchForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZipCodeSearchForm));
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.dateTimePicker2 = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.panel7 = new Gizmox.WebGUI.Forms.Panel();
            this.lblHeader = new Gizmox.WebGUI.Forms.Label();
            this.pictureBox2 = new Gizmox.WebGUI.Forms.PictureBox();
            this.panel8 = new Gizmox.WebGUI.Forms.Panel();
            this.txtZipCode = new Gizmox.WebGUI.Forms.TextBox();
            this.onSearch = new Gizmox.WebGUI.Forms.Button();
            this.lblZipCode = new Gizmox.WebGUI.Forms.Label();
            this.cmbCounty = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblCounty = new Gizmox.WebGUI.Forms.Label();
            this.lblCity = new Gizmox.WebGUI.Forms.Label();
            this.txtCity = new Gizmox.WebGUI.Forms.TextBox();
            this.cmbTownship = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblTownship = new Gizmox.WebGUI.Forms.Label();
            this.groupBox1 = new Gizmox.WebGUI.Forms.GroupBox();
            this.gvwCustomer = new Gizmox.WebGUI.Forms.DataGridView();
            this.ZCRZIP = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.ZCRCITY = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.ZCRSTATE = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.ZCRCITYCODE = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.ZCRCOUNTY = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.btnSelect = new Gizmox.WebGUI.Forms.Button();
            this.panel8.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dateTimePicker2.CustomFormat = "";
            this.dateTimePicker2.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(417, -219);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(79, 21);
            this.dateTimePicker2.TabIndex = 15;
            // 
            // panel7
            // 
            this.panel7.Location = new System.Drawing.Point(124, -249);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(415, 64);
            this.panel7.TabIndex = 0;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(85, 15);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(35, 13);
            this.lblHeader.TabIndex = 1;
            this.lblHeader.Text = "Zip Code Search";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox2.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("pictureBox2.Image"));
            this.pictureBox2.Location = new System.Drawing.Point(20, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(50, 46);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel8.Controls.Add(this.dateTimePicker2);
            this.panel8.Controls.Add(this.panel7);
            this.panel8.Controls.Add(this.lblHeader);
            this.panel8.Controls.Add(this.pictureBox2);
            this.panel8.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(682, 55);
            this.panel8.TabIndex = 2;
            // 
            // txtZipCode
            // 
            this.txtZipCode.Location = new System.Drawing.Point(86, 17);
            this.txtZipCode.MaxLength = 9;
            this.txtZipCode.Name = "txtZipCode";
            this.txtZipCode.Size = new System.Drawing.Size(60, 20);
            this.txtZipCode.TabIndex = 1;
            // 
            // onSearch
            // 
            this.onSearch.Location = new System.Drawing.Point(571, 42);
            this.onSearch.Name = "onSearch";
            this.onSearch.Size = new System.Drawing.Size(81, 23);
            this.onSearch.TabIndex = 5;
            this.onSearch.Text = "Search";
            this.onSearch.Click += new System.EventHandler(this.onSearch_Click);
            // 
            // lblZipCode
            // 
            this.lblZipCode.AutoSize = true;
            this.lblZipCode.Location = new System.Drawing.Point(32, 18);
            this.lblZipCode.Name = "lblZipCode";
            this.lblZipCode.Size = new System.Drawing.Size(49, 13);
            this.lblZipCode.TabIndex = 1;
            this.lblZipCode.Text = "ZIP Code";
            // 
            // cmbCounty
            // 
            this.cmbCounty.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cmbCounty.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cmbCounty.FormattingEnabled = true;
            this.cmbCounty.Location = new System.Drawing.Point(412, 42);
            this.cmbCounty.MaxDropDownItems = 8;
            this.cmbCounty.Name = "cmbCounty";
            this.cmbCounty.Size = new System.Drawing.Size(140, 21);
            this.cmbCounty.TabIndex = 4;
            // 
            // lblCounty
            // 
            this.lblCounty.AutoSize = true;
            this.lblCounty.Location = new System.Drawing.Point(360, 46);
            this.lblCounty.Name = "lblCounty";
            this.lblCounty.Size = new System.Drawing.Size(42, 13);
            this.lblCounty.TabIndex = 7;
            this.lblCounty.Text = "County";
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(32, 44);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(26, 13);
            this.lblCity.TabIndex = 3;
            this.lblCity.Text = "City";
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(86, 40);
            this.txtCity.MaxLength = 30;
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(196, 21);
            this.txtCity.TabIndex = 2;
            // 
            // cmbTownship
            // 
            this.cmbTownship.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cmbTownship.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cmbTownship.FormattingEnabled = true;
            this.cmbTownship.Location = new System.Drawing.Point(412, 15);
            this.cmbTownship.MaxDropDownItems = 8;
            this.cmbTownship.Name = "cmbTownship";
            this.cmbTownship.Size = new System.Drawing.Size(140, 21);
            this.cmbTownship.TabIndex = 3;
            // 
            // lblTownship
            // 
            this.lblTownship.AutoSize = true;
            this.lblTownship.Location = new System.Drawing.Point(358, 17);
            this.lblTownship.Name = "lblTownship";
            this.lblTownship.Size = new System.Drawing.Size(52, 13);
            this.lblTownship.TabIndex = 5;
            this.lblTownship.Text = "Township";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtZipCode);
            this.groupBox1.Controls.Add(this.onSearch);
            this.groupBox1.Controls.Add(this.lblZipCode);
            this.groupBox1.Controls.Add(this.cmbCounty);
            this.groupBox1.Controls.Add(this.lblCounty);
            this.groupBox1.Controls.Add(this.lblCity);
            this.groupBox1.Controls.Add(this.txtCity);
            this.groupBox1.Controls.Add(this.cmbTownship);
            this.groupBox1.Controls.Add(this.lblTownship);
            this.groupBox1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(4, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(668, 69);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Zip Code Search";
            // 
            // gvwCustomer
            // 
            this.gvwCustomer.AllowUserToAddRows = false;
            this.gvwCustomer.AllowUserToDeleteRows = false;
            this.gvwCustomer.AllowUserToResizeColumns = false;
            this.gvwCustomer.AllowUserToResizeRows = false;
            this.gvwCustomer.BackgroundColor = System.Drawing.Color.White;
            this.gvwCustomer.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            dataGridViewCellStyle1.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.FormatProvider = new System.Globalization.CultureInfo("en-US");
            dataGridViewCellStyle1.Padding = new Gizmox.WebGUI.Forms.Padding(4, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.gvwCustomer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvwCustomer.Columns.AddRange(new Gizmox.WebGUI.Forms.DataGridViewColumn[] {
            this.ZCRZIP,
            this.ZCRCITY,
            this.ZCRSTATE,
            this.ZCRCITYCODE,
            this.ZCRCOUNTY});
            this.gvwCustomer.ItemsPerPage = 100;
            this.gvwCustomer.Location = new System.Drawing.Point(7, 130);
            this.gvwCustomer.MultiSelect = false;
            this.gvwCustomer.Name = "gvwCustomer";
            this.gvwCustomer.ReadOnly = true;
            this.gvwCustomer.RowHeadersWidth = 15;
            this.gvwCustomer.RowHeadersWidthSizeMode = Gizmox.WebGUI.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gvwCustomer.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("en-IN");
            this.gvwCustomer.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical;
            this.gvwCustomer.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvwCustomer.Size = new System.Drawing.Size(667, 206);
            this.gvwCustomer.StandardTab = true;
            this.gvwCustomer.TabIndex = 6;
            this.gvwCustomer.VirtualBlockSize = 15;
            this.gvwCustomer.DoubleClick += new System.EventHandler(this.gvwCustomer_DoubleClick);
            // 
            // ZCRZIP
            // 
            this.ZCRZIP.HeaderText = "ZIP Code *";
            this.ZCRZIP.MinimumWidth = 100;
            this.ZCRZIP.Name = "ZCRZIP";
            this.ZCRZIP.ReadOnly = true;
            // 
            // ZCRCITY
            // 
            this.ZCRCITY.HeaderText = "City *";
            this.ZCRCITY.MinimumWidth = 150;
            this.ZCRCITY.Name = "ZCRCITY";
            this.ZCRCITY.ReadOnly = true;
            this.ZCRCITY.Width = 150;
            // 
            // ZCRSTATE
            // 
            this.ZCRSTATE.HeaderText = "State *";
            this.ZCRSTATE.MinimumWidth = 100;
            this.ZCRSTATE.Name = "ZCRSTATE";
            this.ZCRSTATE.ReadOnly = true;
            // 
            // ZCRCITYCODE
            // 
            this.ZCRCITYCODE.HeaderText = "Township";
            this.ZCRCITYCODE.MinimumWidth = 150;
            this.ZCRCITYCODE.Name = "ZCRCITYCODE";
            this.ZCRCITYCODE.ReadOnly = true;
            this.ZCRCITYCODE.Width = 150;
            // 
            // ZCRCOUNTY
            // 
            this.ZCRCOUNTY.HeaderText = "County";
            this.ZCRCOUNTY.MinimumWidth = 150;
            this.ZCRCOUNTY.Name = "ZCRCOUNTY";
            this.ZCRCOUNTY.ReadOnly = true;
            this.ZCRCOUNTY.Width = 150;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(592, 338);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(83, 22);
            this.btnSelect.TabIndex = 11;
            this.btnSelect.Text = "Select";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // ZipCodeSearchForm
            // 
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.gvwCustomer);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel8);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(682, 365);
            this.Text = "ZipCodeSearchForm";
            this.panel8.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DateTimePicker dateTimePicker2;
        private Panel panel7;
        private Label lblHeader;
        private PictureBox pictureBox2;
        private Panel panel8;
        private TextBox txtZipCode;
        private Button onSearch;
        private Label lblZipCode;
        private ComboBox cmbCounty;
        private Label lblCounty;
        private Label lblCity;
        private TextBox txtCity;
        private ComboBox cmbTownship;
        private Label lblTownship;
        private GroupBox groupBox1;
        private DataGridView gvwCustomer;
        private DataGridViewTextBoxColumn ZCRZIP;
        private DataGridViewTextBoxColumn ZCRCITY;
        private DataGridViewTextBoxColumn ZCRSTATE;
        private DataGridViewTextBoxColumn ZCRCITYCODE;
        private DataGridViewTextBoxColumn ZCRCOUNTY;
        private Button btnSelect;


    }
}