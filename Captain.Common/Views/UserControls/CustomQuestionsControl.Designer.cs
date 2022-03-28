using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Captain.Common.Views.UserControls
{
    partial class CustomQuestionsControl
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomQuestionsControl));
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.cmbQuestionAccess = new Gizmox.WebGUI.Forms.ComboBox();
            this.label44 = new Gizmox.WebGUI.Forms.Label();
            this.cmbQuestionType = new Gizmox.WebGUI.Forms.ComboBox();
            this.label43 = new Gizmox.WebGUI.Forms.Label();
            this.cmbSEQ = new Gizmox.WebGUI.Forms.ComboBox();
            this.label42 = new Gizmox.WebGUI.Forms.Label();
            this.gvwCustomQuestions = new Gizmox.WebGUI.Forms.DataGridView();
            this.gvtRequire = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.ImgSave = new Gizmox.WebGUI.Forms.DataGridViewImageColumn();
            this.Question = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.Response = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.contextMenu2 = new Gizmox.WebGUI.Forms.ContextMenu();
            this.ResponseCode = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.FamilySeq = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.ResponceSeq = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.Code = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.ResponceDelete = new Gizmox.WebGUI.Forms.DataGridViewImageColumn();
            this.gvtResponseQType = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.picMax = new Gizmox.WebGUI.Forms.PictureBox();
            this.panel3 = new Gizmox.WebGUI.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.gvwCustomQuestions)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMax)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbQuestionAccess
            // 
            this.cmbQuestionAccess.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cmbQuestionAccess.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cmbQuestionAccess.ExcludeFromUniqueId = false;
            this.cmbQuestionAccess.FormattingEnabled = true;
            this.cmbQuestionAccess.Location = new System.Drawing.Point(472, 4);
            this.cmbQuestionAccess.Name = "cmbQuestionAccess";
            this.cmbQuestionAccess.NextFocusId = ((long)(0));
            this.cmbQuestionAccess.PerformLayoutEnabled = true;
            this.cmbQuestionAccess.PreviousFocusId = ((long)(0));
            this.cmbQuestionAccess.Size = new System.Drawing.Size(260, 25);
            this.cmbQuestionAccess.TabIndex = 11;
            this.cmbQuestionAccess.SelectedIndexChanged += new System.EventHandler(this.cmbQuestionAccess_SelectedIndexChanged);
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.ExcludeFromUniqueId = false;
            this.label44.Location = new System.Drawing.Point(381, 8);
            this.label44.Name = "label44";
            this.label44.NextFocusId = ((long)(0));
            this.label44.PerformLayoutEnabled = true;
            this.label44.PreviousFocusId = ((long)(0));
            this.label44.Size = new System.Drawing.Size(90, 13);
            this.label44.TabIndex = 10;
            this.label44.Text = "Question Access:";
            // 
            // cmbQuestionType
            // 
            this.cmbQuestionType.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cmbQuestionType.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cmbQuestionType.ExcludeFromUniqueId = false;
            this.cmbQuestionType.FormattingEnabled = true;
            this.cmbQuestionType.Location = new System.Drawing.Point(302, 4);
            this.cmbQuestionType.Name = "cmbQuestionType";
            this.cmbQuestionType.NextFocusId = ((long)(0));
            this.cmbQuestionType.PerformLayoutEnabled = true;
            this.cmbQuestionType.PreviousFocusId = ((long)(0));
            this.cmbQuestionType.Size = new System.Drawing.Size(74, 21);
            this.cmbQuestionType.TabIndex = 9;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.ExcludeFromUniqueId = false;
            this.label43.Location = new System.Drawing.Point(224, 8);
            this.label43.Name = "label43";
            this.label43.NextFocusId = ((long)(0));
            this.label43.PerformLayoutEnabled = true;
            this.label43.PreviousFocusId = ((long)(0));
            this.label43.Size = new System.Drawing.Size(78, 13);
            this.label43.TabIndex = 8;
            this.label43.Text = "QuestionType:";
            // 
            // cmbSEQ
            // 
            this.cmbSEQ.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cmbSEQ.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cmbSEQ.ExcludeFromUniqueId = false;
            this.cmbSEQ.FormattingEnabled = true;
            this.cmbSEQ.Location = new System.Drawing.Point(108, 4);
            this.cmbSEQ.Name = "cmbSEQ";
            this.cmbSEQ.NextFocusId = ((long)(0));
            this.cmbSEQ.PerformLayoutEnabled = true;
            this.cmbSEQ.PreviousFocusId = ((long)(0));
            this.cmbSEQ.Size = new System.Drawing.Size(112, 21);
            this.cmbSEQ.TabIndex = 7;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.ExcludeFromUniqueId = false;
            this.label42.Location = new System.Drawing.Point(3, 7);
            this.label42.Name = "label42";
            this.label42.NextFocusId = ((long)(0));
            this.label42.PerformLayoutEnabled = true;
            this.label42.PreviousFocusId = ((long)(0));
            this.label42.Size = new System.Drawing.Size(104, 13);
            this.label42.TabIndex = 6;
            this.label42.Text = "Question Sequence:";
            // 
            // gvwCustomQuestions
            // 
            this.gvwCustomQuestions.AllowUserToAddRows = false;
            this.gvwCustomQuestions.AllowUserToDeleteRows = false;
            this.gvwCustomQuestions.AllowUserToResizeColumns = false;
            this.gvwCustomQuestions.AutoSizeRowsMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.gvwCustomQuestions.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.FormatProvider = new System.Globalization.CultureInfo("en-IN");
            dataGridViewCellStyle1.Padding = new Gizmox.WebGUI.Forms.Padding(2, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.gvwCustomQuestions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvwCustomQuestions.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvwCustomQuestions.Columns.AddRange(new Gizmox.WebGUI.Forms.DataGridViewColumn[] {
            this.gvtRequire,
            this.ImgSave,
            this.Question,
            this.Response,
            this.ResponseCode,
            this.FamilySeq,
            this.ResponceSeq,
            this.Code,
            this.ResponceDelete,
            this.gvtResponseQType});
            this.gvwCustomQuestions.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.gvwCustomQuestions.ExcludeFromUniqueId = false;
            this.gvwCustomQuestions.ItemsPerPage = 200;
            this.gvwCustomQuestions.Location = new System.Drawing.Point(0, 0);
            this.gvwCustomQuestions.MultiSelect = false;
            this.gvwCustomQuestions.Name = "gvwCustomQuestions";
            this.gvwCustomQuestions.NextFocusId = ((long)(0));
            this.gvwCustomQuestions.PerformLayoutEnabled = true;
            this.gvwCustomQuestions.PreviousFocusId = ((long)(0));
            this.gvwCustomQuestions.RenderCellPanelsAsText = false;
            this.gvwCustomQuestions.RowHeadersVisible = false;
            this.gvwCustomQuestions.RowHeadersWidth = 5;
            dataGridViewCellStyle12.FormatProvider = new System.Globalization.CultureInfo("en-IN");
            dataGridViewCellStyle12.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.gvwCustomQuestions.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.gvwCustomQuestions.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("en-IN");
            this.gvwCustomQuestions.RowTemplate.Enabled = true;
            this.gvwCustomQuestions.RowTemplate.Height = 30;
            this.gvwCustomQuestions.RowTemplate.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.gvwCustomQuestions.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical;
            this.gvwCustomQuestions.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvwCustomQuestions.Size = new System.Drawing.Size(771, 158);
            this.gvwCustomQuestions.TabIndex = 5;
            this.gvwCustomQuestions.CellClick += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.gvwCustomQuestions_CellClick);
            this.gvwCustomQuestions.DataError += new Gizmox.WebGUI.Forms.DataGridViewDataErrorEventHandler(this.gvwCustomQuestions_DataError);
            this.gvwCustomQuestions.MenuClick += new Gizmox.WebGUI.Forms.MenuEventHandler(this.gvwCustomQuestions_MenuClick);
            // 
            // gvtRequire
            // 
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle2.FormatProvider = new System.Globalization.CultureInfo("en-IN");
            this.gvtRequire.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvtRequire.HeaderText = "  ";
            this.gvtRequire.MinimumWidth = 15;
            this.gvtRequire.Name = "gvtRequire";
            this.gvtRequire.ReadOnly = true;
            this.gvtRequire.Width = 15;
            // 
            // ImgSave
            // 
            dataGridViewCellStyle3.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.NullValue = null;
            this.ImgSave.DefaultCellStyle = dataGridViewCellStyle3;
            this.ImgSave.HeaderText = " ";
            this.ImgSave.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("ImgSave.Image"));
            this.ImgSave.Name = "ImgSave";
            this.ImgSave.Width = 40;
            // 
            // Question
            // 
            dataGridViewCellStyle4.FormatProvider = new System.Globalization.CultureInfo("en-IN");
            dataGridViewCellStyle4.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.Question.DefaultCellStyle = dataGridViewCellStyle4;
            this.Question.HeaderText = "Question Description";
            this.Question.Name = "Question";
            this.Question.Width = 380;
            // 
            // Response
            // 
            this.Response.ContextMenu = this.contextMenu2;
            this.Response.DefaultCellStyle = dataGridViewCellStyle5;
            this.Response.Name = "Response";
            this.Response.Width = 300;
            // 
            // contextMenu2
            // 
            this.contextMenu2.ExcludeFromUniqueId = false;
            // 
            // ResponseCode
            // 
            this.ResponseCode.DefaultCellStyle = dataGridViewCellStyle6;
            this.ResponseCode.Name = "ResponseCode";
            this.ResponseCode.Visible = false;
            this.ResponseCode.Width = 5;
            // 
            // FamilySeq
            // 
            this.FamilySeq.DefaultCellStyle = dataGridViewCellStyle7;
            this.FamilySeq.Name = "FamilySeq";
            this.FamilySeq.Visible = false;
            this.FamilySeq.Width = 5;
            // 
            // ResponceSeq
            // 
            this.ResponceSeq.DefaultCellStyle = dataGridViewCellStyle8;
            this.ResponceSeq.Name = "ResponceSeq";
            this.ResponceSeq.Visible = false;
            this.ResponceSeq.Width = 5;
            // 
            // Code
            // 
            this.Code.DefaultCellStyle = dataGridViewCellStyle9;
            this.Code.Name = "Code";
            this.Code.Visible = false;
            this.Code.Width = 5;
            // 
            // ResponceDelete
            // 
            dataGridViewCellStyle10.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.NullValue = null;
            this.ResponceDelete.DefaultCellStyle = dataGridViewCellStyle10;
            this.ResponceDelete.HeaderText = "Delete";
            this.ResponceDelete.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("ResponceDelete.Image"));
            this.ResponceDelete.Name = "ResponceDelete";
            this.ResponceDelete.Width = 40;
            // 
            // gvtResponseQType
            // 
            this.gvtResponseQType.DefaultCellStyle = dataGridViewCellStyle11;
            this.gvtResponseQType.Name = "gvtResponseQType";
            this.gvtResponseQType.Visible = false;
            this.gvtResponseQType.Width = 10;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.picMax);
            this.panel1.Controls.Add(this.cmbQuestionAccess);
            this.panel1.Controls.Add(this.label44);
            this.panel1.Controls.Add(this.label42);
            this.panel1.Controls.Add(this.cmbQuestionType);
            this.panel1.Controls.Add(this.cmbSEQ);
            this.panel1.Controls.Add(this.label43);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel1.ExcludeFromUniqueId = false;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.NextFocusId = ((long)(0));
            this.panel1.PerformLayoutEnabled = true;
            this.panel1.PreviousFocusId = ((long)(0));
            this.panel1.Size = new System.Drawing.Size(771, 29);
            this.panel1.TabIndex = 12;
            // 
            // picMax
            // 
            this.picMax.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.picMax.ExcludeFromUniqueId = false;
            this.picMax.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("picMax.Image"));
            this.picMax.Location = new System.Drawing.Point(740, 3);
            this.picMax.Name = "picMax";
            this.picMax.NextFocusId = ((long)(0));
            this.picMax.PerformLayoutEnabled = true;
            this.picMax.PreviousFocusId = ((long)(0));
            this.picMax.Size = new System.Drawing.Size(19, 18);
            this.picMax.TabIndex = 12;
            this.picMax.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.gvwCustomQuestions);
            this.panel3.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel3.ExcludeFromUniqueId = false;
            this.panel3.Location = new System.Drawing.Point(0, 29);
            this.panel3.Name = "panel3";
            this.panel3.NextFocusId = ((long)(0));
            this.panel3.PerformLayoutEnabled = true;
            this.panel3.PreviousFocusId = ((long)(0));
            this.panel3.Size = new System.Drawing.Size(771, 158);
            this.panel3.TabIndex = 14;
            // 
            // CustomQuestionsControl
            // 
            this.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Size = new System.Drawing.Size(771, 187);
            this.Text = "CustomFields";
            ((System.ComponentModel.ISupportInitialize)(this.gvwCustomQuestions)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picMax)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComboBox cmbQuestionAccess;
        private Label label44;
        private ComboBox cmbQuestionType;
        private Label label43;
        private ComboBox cmbSEQ;
        private Label label42;
        private DataGridView gvwCustomQuestions;
        private DataGridViewImageColumn ImgSave;
        private DataGridViewTextBoxColumn Question;
        private DataGridViewTextBoxColumn Response;
        private Panel panel1;
        private PictureBox picMax;
        private ContextMenu contextMenu2;
        private DataGridViewTextBoxColumn ResponseCode;
        private Panel panel3;
        private DataGridViewImageColumn ResponceDelete;
        private DataGridViewTextBoxColumn FamilySeq;
        private DataGridViewTextBoxColumn ResponceSeq;
        private DataGridViewTextBoxColumn Code;
        private DataGridViewTextBoxColumn gvtRequire;
        private DataGridViewTextBoxColumn gvtResponseQType;



    }
}