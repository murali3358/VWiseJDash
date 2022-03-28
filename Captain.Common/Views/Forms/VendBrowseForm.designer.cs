using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Captain.Common.Views.Forms
{
    partial class VendBrowseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VendBrowseForm));
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.btnEdit = new Gizmox.WebGUI.Forms.PictureBox();
            this.btnAdd = new Gizmox.WebGUI.Forms.PictureBox();
            this.btnSearch = new Gizmox.WebGUI.Forms.Button();
            this.cmbSource = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblSource = new Gizmox.WebGUI.Forms.Label();
            this.txtName = new Gizmox.WebGUI.Forms.TextBox();
            this.lblSearch = new Gizmox.WebGUI.Forms.Label();
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.gvwVendor = new Gizmox.WebGUI.Forms.DataGridView();
            this.gvchkSel = new Gizmox.WebGUI.Forms.DataGridViewCheckBoxColumn();
            this.gvtNumber = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.gvtName = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.gvtName2 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.gvtAddress = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.gvtActive = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.btnSelect = new Gizmox.WebGUI.Forms.Button();
            this.lblTotNoRec = new Gizmox.WebGUI.Forms.Label();
            this.lblTotal = new Gizmox.WebGUI.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvwVendor)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Black);
            this.panel1.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.cmbSource);
            this.panel1.Controls.Add(this.lblSource);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.lblSearch);
            this.panel1.ExcludeFromUniqueId = false;
            this.panel1.Location = new System.Drawing.Point(2, 1);
            this.panel1.Name = "panel1";
            this.panel1.NextFocusId = ((long)(0));
            this.panel1.PerformLayoutEnabled = true;
            this.panel1.PreviousFocusId = ((long)(0));
            this.panel1.Size = new System.Drawing.Size(887, 62);
            this.panel1.TabIndex = 0;
            // 
            // btnEdit
            // 
            this.btnEdit.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.btnEdit.ExcludeFromUniqueId = false;
            this.btnEdit.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnEdit.Image"));
            this.btnEdit.Location = new System.Drawing.Point(867, 9);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.NextFocusId = ((long)(0));
            this.btnEdit.PerformLayoutEnabled = true;
            this.btnEdit.PreviousFocusId = ((long)(0));
            this.btnEdit.Size = new System.Drawing.Size(16, 16);
            this.btnEdit.SizeMode = Gizmox.WebGUI.Forms.PictureBoxSizeMode.StretchImage;
            this.btnEdit.TabIndex = 2;
            this.btnEdit.TabStop = false;
            this.btnEdit.Visible = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.btnAdd.ExcludeFromUniqueId = false;
            this.btnAdd.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnAdd.Image"));
            this.btnAdd.Location = new System.Drawing.Point(867, 8);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.NextFocusId = ((long)(0));
            this.btnAdd.PerformLayoutEnabled = true;
            this.btnAdd.PreviousFocusId = ((long)(0));
            this.btnAdd.Size = new System.Drawing.Size(16, 16);
            this.btnAdd.SizeMode = Gizmox.WebGUI.Forms.PictureBoxSizeMode.StretchImage;
            this.btnAdd.TabIndex = 2;
            this.btnAdd.TabStop = false;
            this.btnAdd.Visible = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.ExcludeFromUniqueId = false;
            this.btnSearch.Location = new System.Drawing.Point(222, 29);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.NextFocusId = ((long)(0));
            this.btnSearch.PerformLayoutEnabled = true;
            this.btnSearch.PreviousFocusId = ((long)(0));
            this.btnSearch.Size = new System.Drawing.Size(72, 21);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Se&arch";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cmbSource
            // 
            this.cmbSource.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cmbSource.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cmbSource.ExcludeFromUniqueId = false;
            this.cmbSource.FormattingEnabled = true;
            this.cmbSource.Location = new System.Drawing.Point(79, 29);
            this.cmbSource.Name = "cmbSource";
            this.cmbSource.NextFocusId = ((long)(0));
            this.cmbSource.PerformLayoutEnabled = true;
            this.cmbSource.PreviousFocusId = ((long)(0));
            this.cmbSource.Size = new System.Drawing.Size(131, 21);
            this.cmbSource.TabIndex = 5;
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.ExcludeFromUniqueId = false;
            this.lblSource.Location = new System.Drawing.Point(6, 33);
            this.lblSource.Name = "lblSource";
            this.lblSource.NextFocusId = ((long)(0));
            this.lblSource.PerformLayoutEnabled = true;
            this.lblSource.PreviousFocusId = ((long)(0));
            this.lblSource.Size = new System.Drawing.Size(35, 13);
            this.lblSource.TabIndex = 4;
            this.lblSource.Text = "Source";
            // 
            // txtName
            // 
            this.txtName.ExcludeFromUniqueId = false;
            this.txtName.Location = new System.Drawing.Point(79, 5);
            this.txtName.Name = "txtName";
            this.txtName.NextFocusId = ((long)(0));
            this.txtName.PerformLayoutEnabled = true;
            this.txtName.PreviousFocusId = ((long)(0));
            this.txtName.Size = new System.Drawing.Size(785, 20);
            this.txtName.TabIndex = 3;
            this.txtName.EnterKeyDown += new Gizmox.WebGUI.Forms.KeyEventHandler(this.txtName_EnterKeyDown);
            this.txtName.Enter += new System.EventHandler(this.txtName_Enter);
            this.txtName.Leave += new System.EventHandler(this.txtName_Leave);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.ExcludeFromUniqueId = false;
            this.lblSearch.Location = new System.Drawing.Point(6, 7);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.NextFocusId = ((long)(0));
            this.lblSearch.PerformLayoutEnabled = true;
            this.lblSearch.PreviousFocusId = ((long)(0));
            this.lblSearch.Size = new System.Drawing.Size(35, 13);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Search By";
            // 
            // panel2
            // 
            this.panel2.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Black);
            this.panel2.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.gvwVendor);
            this.panel2.Controls.Add(this.btnSelect);
            this.panel2.Controls.Add(this.lblTotNoRec);
            this.panel2.Controls.Add(this.lblTotal);
            this.panel2.ExcludeFromUniqueId = false;
            this.panel2.Location = new System.Drawing.Point(2, 60);
            this.panel2.Name = "panel2";
            this.panel2.NextFocusId = ((long)(0));
            this.panel2.PerformLayoutEnabled = true;
            this.panel2.PreviousFocusId = ((long)(0));
            this.panel2.Size = new System.Drawing.Size(887, 321);
            this.panel2.TabIndex = 1;
            // 
            // gvwVendor
            // 
            this.gvwVendor.AllowUserToAddRows = false;
            this.gvwVendor.AllowUserToDeleteRows = false;
            this.gvwVendor.AllowUserToResizeRows = false;
            this.gvwVendor.BackgroundColor = System.Drawing.Color.White;
            this.gvwVendor.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.FormatProvider = new System.Globalization.CultureInfo("en-US");
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.gvwVendor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvwVendor.ColumnHeadersHeight = 25;
            this.gvwVendor.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gvwVendor.Columns.AddRange(new Gizmox.WebGUI.Forms.DataGridViewColumn[] {
            this.gvchkSel,
            this.gvtNumber,
            this.gvtName,
            this.gvtName2,
            this.gvtAddress,
            this.gvtActive});
            this.gvwVendor.ExcludeFromUniqueId = false;
            this.gvwVendor.ItemsPerPage = 100;
            this.gvwVendor.Location = new System.Drawing.Point(1, -2);
            this.gvwVendor.MultiSelect = false;
            this.gvwVendor.Name = "gvwVendor";
            this.gvwVendor.NextFocusId = ((long)(0));
            this.gvwVendor.PerformLayoutEnabled = true;
            this.gvwVendor.PreviousFocusId = ((long)(0));
            this.gvwVendor.RenderCellPanelsAsText = false;
            this.gvwVendor.RowHeadersWidth = 14;
            this.gvwVendor.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("en-US");
            this.gvwVendor.RowTemplate.Enabled = true;
            this.gvwVendor.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical;
            this.gvwVendor.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvwVendor.Size = new System.Drawing.Size(885, 290);
            this.gvwVendor.TabIndex = 6;
            // 
            // gvchkSel
            // 
            dataGridViewCellStyle2.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = false;
            this.gvchkSel.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvchkSel.HeaderText = "   ";
            this.gvchkSel.Name = "gvchkSel";
            this.gvchkSel.Visible = false;
            this.gvchkSel.Width = 40;
            // 
            // gvtNumber
            // 
            this.gvtNumber.DefaultCellStyle = dataGridViewCellStyle3;
            this.gvtNumber.HeaderText = "Number";
            this.gvtNumber.Name = "gvtNumber";
            this.gvtNumber.Width = 80;
            // 
            // gvtName
            // 
            this.gvtName.DefaultCellStyle = dataGridViewCellStyle4;
            this.gvtName.HeaderText = "Name";
            this.gvtName.Name = "gvtName";
            this.gvtName.Width = 210;
            // 
            // gvtName2
            // 
            this.gvtName2.DefaultCellStyle = dataGridViewCellStyle5;
            this.gvtName2.HeaderText = "Name2";
            this.gvtName2.Name = "gvtName2";
            this.gvtName2.Width = 228;
            // 
            // gvtAddress
            // 
            this.gvtAddress.DefaultCellStyle = dataGridViewCellStyle6;
            this.gvtAddress.HeaderText = "Address";
            this.gvtAddress.Name = "gvtAddress";
            this.gvtAddress.Width = 330;
            // 
            // gvtActive
            // 
            this.gvtActive.DefaultCellStyle = dataGridViewCellStyle7;
            this.gvtActive.Name = "gvtActive";
            this.gvtActive.Visible = false;
            this.gvtActive.Width = 5;
            // 
            // btnSelect
            // 
            this.btnSelect.ExcludeFromUniqueId = false;
            this.btnSelect.Location = new System.Drawing.Point(807, 291);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.NextFocusId = ((long)(0));
            this.btnSelect.PerformLayoutEnabled = true;
            this.btnSelect.PreviousFocusId = ((long)(0));
            this.btnSelect.Size = new System.Drawing.Size(72, 23);
            this.btnSelect.TabIndex = 3;
            this.btnSelect.Text = "Select";
            this.btnSelect.Visible = false;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // lblTotNoRec
            // 
            this.lblTotNoRec.AutoSize = true;
            this.lblTotNoRec.ExcludeFromUniqueId = false;
            this.lblTotNoRec.Location = new System.Drawing.Point(89, 295);
            this.lblTotNoRec.Name = "lblTotNoRec";
            this.lblTotNoRec.NextFocusId = ((long)(0));
            this.lblTotNoRec.PerformLayoutEnabled = true;
            this.lblTotNoRec.PreviousFocusId = ((long)(0));
            this.lblTotNoRec.Size = new System.Drawing.Size(35, 13);
            this.lblTotNoRec.TabIndex = 2;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.ExcludeFromUniqueId = false;
            this.lblTotal.Location = new System.Drawing.Point(7, 295);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.NextFocusId = ((long)(0));
            this.lblTotal.PerformLayoutEnabled = true;
            this.lblTotal.PreviousFocusId = ((long)(0));
            this.lblTotal.Size = new System.Drawing.Size(35, 13);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "Total Records";
            this.lblTotal.Visible = false;
            // 
            // VendBrowseForm
            // 
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(890, 383);
            this.Text = "Test";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvwVendor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Label lblSearch;
        private TextBox txtName;
        private ComboBox cmbSource;
        private Label lblSource;
        private Button btnSearch;
        private Panel panel2;
        private Button btnSelect;
        private Label lblTotNoRec;
        private Label lblTotal;
        private PictureBox btnEdit;
        private PictureBox btnAdd;
        private DataGridView gvwVendor;
        private DataGridViewCheckBoxColumn gvchkSel;
        private DataGridViewTextBoxColumn gvtNumber;
        private DataGridViewTextBoxColumn gvtName;
        private DataGridViewTextBoxColumn gvtName2;
        private DataGridViewTextBoxColumn gvtAddress;
        private DataGridViewTextBoxColumn gvtActive;
    }
}