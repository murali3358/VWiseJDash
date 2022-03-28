using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Captain.Common.Views.Forms
{
    partial class PreassesDimentionForm
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.cmbQuestionType = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblPQuestionType = new Gizmox.WebGUI.Forms.Label();
            this.gvwPreassesData = new Gizmox.WebGUI.Forms.DataGridView();
            this.gvtPQDesc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.gvtPDQid = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.contextDimetionId = new Gizmox.WebGUI.Forms.ContextMenu();
            this.gvtPEnable = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.contextEnable = new Gizmox.WebGUI.Forms.ContextMenu();
            this.gvtPDisable = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.contextDisable = new Gizmox.WebGUI.Forms.ContextMenu();
            this.gvtPDRequire = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.contextResult = new Gizmox.WebGUI.Forms.ContextMenu();
            this.gvtPQid = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.gvtDimetionId = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.gvtPoints = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.gvtDScore = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.lblCategory = new Gizmox.WebGUI.Forms.Label();
            this.lblPresTotal = new Gizmox.WebGUI.Forms.Label();
            this.Btn_Save = new Gizmox.WebGUI.Forms.Button();
            this.Btn_Cancel = new Gizmox.WebGUI.Forms.Button();
            this.contextMenu1 = new Gizmox.WebGUI.Forms.ContextMenu();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvwPreassesData)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cmbQuestionType);
            this.panel1.Controls.Add(this.lblPQuestionType);
            this.panel1.Controls.Add(this.gvwPreassesData);
            this.panel1.ExcludeFromUniqueId = false;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.NextFocusId = ((long)(0));
            this.panel1.PerformLayoutEnabled = true;
            this.panel1.PreviousFocusId = ((long)(0));
            this.panel1.Size = new System.Drawing.Size(729, 431);
            this.panel1.TabIndex = 0;
            // 
            // cmbQuestionType
            // 
            this.cmbQuestionType.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cmbQuestionType.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cmbQuestionType.ExcludeFromUniqueId = false;
            this.cmbQuestionType.FormattingEnabled = true;
            this.cmbQuestionType.Location = new System.Drawing.Point(352, 6);
            this.cmbQuestionType.Name = "cmbQuestionType";
            this.cmbQuestionType.NextFocusId = ((long)(0));
            this.cmbQuestionType.PerformLayoutEnabled = true;
            this.cmbQuestionType.PreviousFocusId = ((long)(0));
            this.cmbQuestionType.Size = new System.Drawing.Size(103, 21);
            this.cmbQuestionType.TabIndex = 9;
            this.cmbQuestionType.SelectedIndexChanged += new System.EventHandler(this.cmbQuestionType_SelectedIndexChanged);
            // 
            // lblPQuestionType
            // 
            this.lblPQuestionType.AutoSize = true;
            this.lblPQuestionType.ExcludeFromUniqueId = false;
            this.lblPQuestionType.Location = new System.Drawing.Point(259, 11);
            this.lblPQuestionType.Name = "lblPQuestionType";
            this.lblPQuestionType.NextFocusId = ((long)(0));
            this.lblPQuestionType.PerformLayoutEnabled = true;
            this.lblPQuestionType.PreviousFocusId = ((long)(0));
            this.lblPQuestionType.Size = new System.Drawing.Size(78, 13);
            this.lblPQuestionType.TabIndex = 8;
            this.lblPQuestionType.Text = "Questions Filter";
            // 
            // gvwPreassesData
            // 
            this.gvwPreassesData.AllowDrag = false;
            this.gvwPreassesData.AllowDragTargetsPropagation = false;
            this.gvwPreassesData.AllowDrop = true;
            this.gvwPreassesData.AllowUserToAddRows = false;
            this.gvwPreassesData.AllowUserToDeleteRows = false;
            this.gvwPreassesData.AllowUserToOrderColumns = true;
            this.gvwPreassesData.AllowUserToResizeColumns = false;
            this.gvwPreassesData.AllowUserToResizeRows = false;
            this.gvwPreassesData.BackgroundColor = System.Drawing.Color.White;
            this.gvwPreassesData.Columns.AddRange(new Gizmox.WebGUI.Forms.DataGridViewColumn[] {
            this.gvtPQDesc,
            this.gvtPDQid,
            this.gvtPEnable,
            this.gvtPDisable,
            this.gvtPDRequire,
            this.gvtPQid,
            this.gvtDimetionId,
            this.gvtPoints,
            this.gvtDScore});
            this.gvwPreassesData.ExcludeFromUniqueId = false;
            this.gvwPreassesData.ItemsPerPage = 100;
            this.gvwPreassesData.Location = new System.Drawing.Point(3, 36);
            this.gvwPreassesData.Name = "gvwPreassesData";
            this.gvwPreassesData.NextFocusId = ((long)(0));
            this.gvwPreassesData.PerformLayoutEnabled = true;
            this.gvwPreassesData.PreviousFocusId = ((long)(0));
            this.gvwPreassesData.ReadOnly = true;
            this.gvwPreassesData.RenderCellPanelsAsText = false;
            this.gvwPreassesData.RowHeadersWidth = 14;
            this.gvwPreassesData.RowTemplate.Enabled = true;
            this.gvwPreassesData.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical;
            this.gvwPreassesData.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvwPreassesData.Size = new System.Drawing.Size(721, 389);
            this.gvwPreassesData.TabIndex = 0;
            this.gvwPreassesData.MenuClick += new Gizmox.WebGUI.Forms.MenuEventHandler(this.gvwPreassessData_MenuClick);
            // 
            // gvtPQDesc
            // 
            this.gvtPQDesc.DefaultCellStyle = dataGridViewCellStyle1;
            this.gvtPQDesc.HeaderText = "Field Description ";
            this.gvtPQDesc.Name = "gvtPQDesc";
            this.gvtPQDesc.ReadOnly = true;
            this.gvtPQDesc.Width = 250;
            // 
            // gvtPDQid
            // 
            this.gvtPDQid.ContextMenu = this.contextDimetionId;
            this.gvtPDQid.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvtPDQid.HeaderText = "Next Question Control";
            this.gvtPDQid.Name = "gvtPDQid";
            this.gvtPDQid.ReadOnly = true;
            this.gvtPDQid.Width = 220;
            // 
            // contextDimetionId
            // 
            this.contextDimetionId.ExcludeFromUniqueId = false;
            this.contextDimetionId.Popup += new System.EventHandler(this.contextDimetionId_Popup);
            // 
            // gvtPEnable
            // 
            this.gvtPEnable.ContextMenu = this.contextEnable;
            this.gvtPEnable.DefaultCellStyle = dataGridViewCellStyle3;
            this.gvtPEnable.HeaderText = "Enable";
            this.gvtPEnable.Name = "gvtPEnable";
            this.gvtPEnable.ReadOnly = true;
            this.gvtPEnable.Width = 75;
            // 
            // contextEnable
            // 
            this.contextEnable.ExcludeFromUniqueId = false;
            this.contextEnable.Popup += new System.EventHandler(this.contextEnable_Popup);
            // 
            // gvtPDisable
            // 
            this.gvtPDisable.ContextMenu = this.contextDisable;
            this.gvtPDisable.DefaultCellStyle = dataGridViewCellStyle4;
            this.gvtPDisable.HeaderText = "Disable";
            this.gvtPDisable.Name = "gvtPDisable";
            this.gvtPDisable.ReadOnly = true;
            this.gvtPDisable.Width = 75;
            // 
            // contextDisable
            // 
            this.contextDisable.ExcludeFromUniqueId = false;
            this.contextDisable.Popup += new System.EventHandler(this.contextDisable_Popup);
            // 
            // gvtPDRequire
            // 
            this.gvtPDRequire.ContextMenu = this.contextResult;
            this.gvtPDRequire.DefaultCellStyle = dataGridViewCellStyle5;
            this.gvtPDRequire.HeaderText = "Require";
            this.gvtPDRequire.Name = "gvtPDRequire";
            this.gvtPDRequire.ReadOnly = true;
            this.gvtPDRequire.Width = 75;
            // 
            // contextResult
            // 
            this.contextResult.ExcludeFromUniqueId = false;
            this.contextResult.Popup += new System.EventHandler(this.contextResult_Popup);
            // 
            // gvtPQid
            // 
            this.gvtPQid.DefaultCellStyle = dataGridViewCellStyle6;
            this.gvtPQid.HeaderText = "Q ID";
            this.gvtPQid.Name = "gvtPQid";
            this.gvtPQid.ReadOnly = true;
            this.gvtPQid.Visible = false;
            this.gvtPQid.Width = 80;
            // 
            // gvtDimetionId
            // 
            this.gvtDimetionId.DefaultCellStyle = dataGridViewCellStyle7;
            this.gvtDimetionId.HeaderText = "DimetionId";
            this.gvtDimetionId.Name = "gvtDimetionId";
            this.gvtDimetionId.ReadOnly = true;
            this.gvtDimetionId.Visible = false;
            // 
            // gvtPoints
            // 
            dataGridViewCellStyle8.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.FormatProvider = new System.Globalization.CultureInfo("en-IN");
            this.gvtPoints.DefaultCellStyle = dataGridViewCellStyle8;
            this.gvtPoints.HeaderText = "Points";
            this.gvtPoints.Name = "gvtPoints";
            this.gvtPoints.ReadOnly = true;
            this.gvtPoints.Width = 60;
            // 
            // gvtDScore
            // 
            dataGridViewCellStyle9.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.FormatProvider = new System.Globalization.CultureInfo("en-IN");
            this.gvtDScore.DefaultCellStyle = dataGridViewCellStyle9;
            this.gvtDScore.HeaderText = "Score";
            this.gvtDScore.Name = "gvtDScore";
            this.gvtDScore.ReadOnly = true;
            this.gvtDScore.Width = 60;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblCategory);
            this.panel2.Controls.Add(this.lblPresTotal);
            this.panel2.Controls.Add(this.Btn_Save);
            this.panel2.Controls.Add(this.Btn_Cancel);
            this.panel2.ExcludeFromUniqueId = false;
            this.panel2.Location = new System.Drawing.Point(0, 430);
            this.panel2.Name = "panel2";
            this.panel2.NextFocusId = ((long)(0));
            this.panel2.PerformLayoutEnabled = true;
            this.panel2.PreviousFocusId = ((long)(0));
            this.panel2.Size = new System.Drawing.Size(729, 32);
            this.panel2.TabIndex = 1;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.ExcludeFromUniqueId = false;
            this.lblCategory.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblCategory.Location = new System.Drawing.Point(92, 10);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.NextFocusId = ((long)(0));
            this.lblCategory.PerformLayoutEnabled = true;
            this.lblCategory.PreviousFocusId = ((long)(0));
            this.lblCategory.Size = new System.Drawing.Size(35, 13);
            this.lblCategory.TabIndex = 13;
            this.lblCategory.Text = "Category : ";
            this.lblCategory.Visible = false;
            // 
            // lblPresTotal
            // 
            this.lblPresTotal.AutoSize = true;
            this.lblPresTotal.ExcludeFromUniqueId = false;
            this.lblPresTotal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblPresTotal.Location = new System.Drawing.Point(329, 10);
            this.lblPresTotal.Name = "lblPresTotal";
            this.lblPresTotal.NextFocusId = ((long)(0));
            this.lblPresTotal.PerformLayoutEnabled = true;
            this.lblPresTotal.PreviousFocusId = ((long)(0));
            this.lblPresTotal.Size = new System.Drawing.Size(35, 13);
            this.lblPresTotal.TabIndex = 12;
            this.lblPresTotal.Text = "Preasses Total :  ";
            this.lblPresTotal.Visible = false;
            // 
            // Btn_Save
            // 
            this.Btn_Save.ExcludeFromUniqueId = false;
            this.Btn_Save.Location = new System.Drawing.Point(567, 3);
            this.Btn_Save.Name = "Btn_Save";
            this.Btn_Save.NextFocusId = ((long)(0));
            this.Btn_Save.PerformLayoutEnabled = true;
            this.Btn_Save.PreviousFocusId = ((long)(0));
            this.Btn_Save.Size = new System.Drawing.Size(68, 26);
            this.Btn_Save.TabIndex = 10;
            this.Btn_Save.Text = "Save";
            this.Btn_Save.Click += new System.EventHandler(this.Btn_Save_Click);
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.ExcludeFromUniqueId = false;
            this.Btn_Cancel.Location = new System.Drawing.Point(646, 3);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.NextFocusId = ((long)(0));
            this.Btn_Cancel.PerformLayoutEnabled = true;
            this.Btn_Cancel.PreviousFocusId = ((long)(0));
            this.Btn_Cancel.Size = new System.Drawing.Size(68, 26);
            this.Btn_Cancel.TabIndex = 11;
            this.Btn_Cancel.Text = "Close";
            this.Btn_Cancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
            // 
            // contextMenu1
            // 
            this.contextMenu1.ExcludeFromUniqueId = false;
            this.contextMenu1.Popup += new System.EventHandler(this.contextResult_Popup);
            // 
            // PreassesDimentionForm
            // 
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(730, 462);
            this.Text = "PreassesDimensionForm";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvwPreassesData)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private DataGridView gvwPreassesData;
        private Panel panel2;
        private ContextMenu contextResult;
        private ContextMenu contextDimetionId;
        private DataGridViewTextBoxColumn gvtPQid;
        private DataGridViewTextBoxColumn gvtPQDesc;
        private DataGridViewTextBoxColumn gvtPDRequire;
        private DataGridViewTextBoxColumn gvtPDQid;
        private DataGridViewTextBoxColumn gvtDimetionId;
        private Button Btn_Save;
        private Button Btn_Cancel;
        private DataGridViewTextBoxColumn gvtPEnable;
        private DataGridViewTextBoxColumn gvtPDisable;
        private ContextMenu contextMenu1;
        private ContextMenu contextEnable;
        private ContextMenu contextDisable;
        private DataGridViewTextBoxColumn gvtPoints;
        private Label lblPresTotal;
        private DataGridViewTextBoxColumn gvtDScore;
        private Label lblCategory;
        private ComboBox cmbQuestionType;
        private Label lblPQuestionType;


    }
}