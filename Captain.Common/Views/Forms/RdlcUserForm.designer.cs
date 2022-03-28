using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Captain.Common.Views.Forms
{
    partial class RdlcUserForm
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.gvwData = new Gizmox.WebGUI.Forms.DataGridView();
            this.gvISelect = new Gizmox.WebGUI.Forms.DataGridViewImageColumn();
            this.gvtPCode = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.gvtUserId = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.gvtSelect = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.btnOk = new Gizmox.WebGUI.Forms.Button();
            this.btnCancel = new Gizmox.WebGUI.Forms.Button();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.cmbChartType = new Gizmox.WebGUI.Forms.ComboBox();
            this.btnGeneraterpt = new Gizmox.WebGUI.Forms.Button();
            this.panel4 = new Gizmox.WebGUI.Forms.Panel();
            this.rdoPSelect = new Gizmox.WebGUI.Forms.RadioButton();
            this.rdoPAll = new Gizmox.WebGUI.Forms.RadioButton();
            this.lblProgram = new Gizmox.WebGUI.Forms.Label();
            this.panel3 = new Gizmox.WebGUI.Forms.Panel();
            this.rdoUSelect = new Gizmox.WebGUI.Forms.RadioButton();
            this.rdoUAll = new Gizmox.WebGUI.Forms.RadioButton();
            this.lblUsers = new Gizmox.WebGUI.Forms.Label();
            this.chkUnselectAll = new Gizmox.WebGUI.Forms.CheckBox();
            this.chkSelectAll = new Gizmox.WebGUI.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.gvwData)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
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
            this.gvwData.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.gvwData.Columns.AddRange(new Gizmox.WebGUI.Forms.DataGridViewColumn[] {
            this.gvISelect,
            this.gvtPCode,
            this.gvtUserId,
            this.gvtSelect});
            this.gvwData.ItemsPerPage = 200;
            this.gvwData.Location = new System.Drawing.Point(4, 3);
            this.gvwData.Name = "gvwData";
            this.gvwData.RowHeadersVisible = false;
            this.gvwData.RowHeadersWidth = 4;
            this.gvwData.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical;
            this.gvwData.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvwData.Size = new System.Drawing.Size(319, 395);
            this.gvwData.TabIndex = 0;
            this.gvwData.CellClick += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.gvwData_CellClick);
            // 
            // gvISelect
            // 
            dataGridViewCellStyle9.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.NullValue = null;
            this.gvISelect.DefaultCellStyle = dataGridViewCellStyle9;
            this.gvISelect.HeaderText = " ";
            this.gvISelect.ImageLayout = Gizmox.WebGUI.Forms.DataGridViewImageCellLayout.Normal;
            this.gvISelect.Name = "gvISelect";
            this.gvISelect.Width = 40;
            // 
            // gvtPCode
            // 
            this.gvtPCode.DefaultCellStyle = dataGridViewCellStyle10;
            this.gvtPCode.HeaderText = "Code";
            this.gvtPCode.Name = "gvtPCode";
            this.gvtPCode.Width = 60;
            // 
            // gvtUserId
            // 
            this.gvtUserId.DefaultCellStyle = dataGridViewCellStyle11;
            this.gvtUserId.HeaderText = "User Name";
            this.gvtUserId.Name = "gvtUserId";
            this.gvtUserId.Width = 200;
            // 
            // gvtSelect
            // 
            this.gvtSelect.DefaultCellStyle = dataGridViewCellStyle12;
            this.gvtSelect.HeaderText = " ";
            this.gvtSelect.Name = "gvtSelect";
            this.gvtSelect.Visible = false;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(193, 403);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(56, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Ok";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(259, 403);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(56, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkSelectAll);
            this.panel1.Controls.Add(this.chkUnselectAll);
            this.panel1.Controls.Add(this.gvwData);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Location = new System.Drawing.Point(265, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(323, 433);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmbChartType);
            this.panel2.Controls.Add(this.btnGeneraterpt);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(250, 141);
            this.panel2.TabIndex = 4;
            // 
            // cmbChartType
            // 
            this.cmbChartType.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cmbChartType.FormattingEnabled = true;
            this.cmbChartType.Location = new System.Drawing.Point(14, 93);
            this.cmbChartType.Name = "cmbChartType";
            this.cmbChartType.Size = new System.Drawing.Size(115, 21);
            this.cmbChartType.TabIndex = 0;
            // 
            // btnGeneraterpt
            // 
            this.btnGeneraterpt.Location = new System.Drawing.Point(147, 93);
            this.btnGeneraterpt.Name = "btnGeneraterpt";
            this.btnGeneraterpt.Size = new System.Drawing.Size(78, 23);
            this.btnGeneraterpt.TabIndex = 1;
            this.btnGeneraterpt.Text = "Process";
            this.btnGeneraterpt.Click += new System.EventHandler(this.btnGeneraterpt_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.rdoPSelect);
            this.panel4.Controls.Add(this.rdoPAll);
            this.panel4.Controls.Add(this.lblProgram);
            this.panel4.Location = new System.Drawing.Point(14, 48);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(224, 31);
            this.panel4.TabIndex = 0;
            // 
            // rdoPSelect
            // 
            this.rdoPSelect.AutoSize = true;
            this.rdoPSelect.Location = new System.Drawing.Point(147, 7);
            this.rdoPSelect.Name = "rdoPSelect";
            this.rdoPSelect.Size = new System.Drawing.Size(54, 17);
            this.rdoPSelect.TabIndex = 1;
            this.rdoPSelect.Text = "Select";
            this.rdoPSelect.Click += new System.EventHandler(this.rdoPSelect_Click);
            // 
            // rdoPAll
            // 
            this.rdoPAll.AutoSize = true;
            this.rdoPAll.Checked = true;
            this.rdoPAll.Location = new System.Drawing.Point(93, 7);
            this.rdoPAll.Name = "rdoPAll";
            this.rdoPAll.Size = new System.Drawing.Size(36, 17);
            this.rdoPAll.TabIndex = 1;
            this.rdoPAll.Text = "All";
            this.rdoPAll.Click += new System.EventHandler(this.rdoPSelect_Click);
            // 
            // lblProgram
            // 
            this.lblProgram.AutoSize = true;
            this.lblProgram.Location = new System.Drawing.Point(12, 10);
            this.lblProgram.Name = "lblProgram";
            this.lblProgram.Size = new System.Drawing.Size(35, 13);
            this.lblProgram.TabIndex = 0;
            this.lblProgram.Text = "Program";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rdoUSelect);
            this.panel3.Controls.Add(this.rdoUAll);
            this.panel3.Controls.Add(this.lblUsers);
            this.panel3.Location = new System.Drawing.Point(14, 18);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(224, 31);
            this.panel3.TabIndex = 0;
            // 
            // rdoUSelect
            // 
            this.rdoUSelect.AutoSize = true;
            this.rdoUSelect.Location = new System.Drawing.Point(147, 7);
            this.rdoUSelect.Name = "rdoUSelect";
            this.rdoUSelect.Size = new System.Drawing.Size(54, 17);
            this.rdoUSelect.TabIndex = 1;
            this.rdoUSelect.Text = "Select";
            this.rdoUSelect.Click += new System.EventHandler(this.rdoUSelect_Click);
            // 
            // rdoUAll
            // 
            this.rdoUAll.AutoSize = true;
            this.rdoUAll.Checked = true;
            this.rdoUAll.Location = new System.Drawing.Point(93, 7);
            this.rdoUAll.Name = "rdoUAll";
            this.rdoUAll.Size = new System.Drawing.Size(36, 17);
            this.rdoUAll.TabIndex = 1;
            this.rdoUAll.Text = "All";
            this.rdoUAll.Click += new System.EventHandler(this.rdoUSelect_Click);
            // 
            // lblUsers
            // 
            this.lblUsers.AutoSize = true;
            this.lblUsers.Location = new System.Drawing.Point(12, 10);
            this.lblUsers.Name = "lblUsers";
            this.lblUsers.Size = new System.Drawing.Size(35, 13);
            this.lblUsers.TabIndex = 0;
            this.lblUsers.Text = "User";
            // 
            // chkUnselectAll
            // 
            this.chkUnselectAll.Location = new System.Drawing.Point(99, 407);
            this.chkUnselectAll.Name = "chkUnselectAll";
            this.chkUnselectAll.Size = new System.Drawing.Size(81, 17);
            this.chkUnselectAll.TabIndex = 2;
            this.chkUnselectAll.Text = "Unselect All";
            this.chkUnselectAll.CheckedChanged += new System.EventHandler(this.chkUnselectAll_CheckedChanged);
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.Location = new System.Drawing.Point(20, 406);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(72, 18);
            this.chkSelectAll.TabIndex = 2;
            this.chkSelectAll.Text = "Select All";
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // RdlcUserForm
            // 
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(597, 452);
            this.Text = "RdlcUserForm";
            ((System.ComponentModel.ISupportInitialize)(this.gvwData)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView gvwData;
        private DataGridViewImageColumn gvISelect;
        private DataGridViewTextBoxColumn gvtUserId;
        private Button btnOk;
        private Button btnCancel;
        private DataGridViewTextBoxColumn gvtSelect;
        private DataGridViewTextBoxColumn gvtPCode;
        private Panel panel1;
        private Panel panel2;
        private Button btnGeneraterpt;
        private Panel panel4;
        private RadioButton rdoPSelect;
        private RadioButton rdoPAll;
        private Label lblProgram;
        private Panel panel3;
        private RadioButton rdoUSelect;
        private RadioButton rdoUAll;
        private Label lblUsers;
        private ComboBox cmbChartType;
        private CheckBox chkSelectAll;
        private CheckBox chkUnselectAll;


    }
}