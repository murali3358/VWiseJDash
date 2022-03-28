using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Captain.Common.Views.UserControls
{
    partial class CustomFieldsControl
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomFieldsControl));
            this.cmbQuestionAccess = new Gizmox.WebGUI.Forms.ComboBox();
            this.label44 = new Gizmox.WebGUI.Forms.Label();
            this.cmbQuestionType = new Gizmox.WebGUI.Forms.ComboBox();
            this.label43 = new Gizmox.WebGUI.Forms.Label();
            this.cmbSEQ = new Gizmox.WebGUI.Forms.ComboBox();
            this.label42 = new Gizmox.WebGUI.Forms.Label();
            this.gvwCustomQuestions = new Gizmox.WebGUI.Forms.DataGridView();
            this.ImgSave = new Gizmox.WebGUI.Forms.DataGridViewImageColumn();
            this.Question = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.Response = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.ResponseCode = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.contextMenu2 = new Gizmox.WebGUI.Forms.ContextMenu();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.picMax = new Gizmox.WebGUI.Forms.PictureBox();
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbQuestionAccess
            // 
            this.cmbQuestionAccess.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cmbQuestionAccess.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cmbQuestionAccess.FormattingEnabled = true;
            this.cmbQuestionAccess.Location = new System.Drawing.Point(518, 5);
            this.cmbQuestionAccess.MaxDropDownItems = 8;
            this.cmbQuestionAccess.Name = "cmbQuestionAccess";
            this.cmbQuestionAccess.Size = new System.Drawing.Size(147, 21);
            this.cmbQuestionAccess.TabIndex = 11;
            this.cmbQuestionAccess.SelectedIndexChanged += new System.EventHandler(this.OnAccessSelectedIndexChanged);
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(426, 8);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(90, 13);
            this.label44.TabIndex = 10;
            this.label44.Text = "Question Access:";
            // 
            // cmbQuestionType
            // 
            this.cmbQuestionType.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cmbQuestionType.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cmbQuestionType.FormattingEnabled = true;
            this.cmbQuestionType.Location = new System.Drawing.Point(313, 4);
            this.cmbQuestionType.MaxDropDownItems = 8;
            this.cmbQuestionType.Name = "cmbQuestionType";
            this.cmbQuestionType.Size = new System.Drawing.Size(113, 21);
            this.cmbQuestionType.TabIndex = 9;
            this.cmbQuestionType.SelectedIndexChanged += new System.EventHandler(this.OnTypeSelectedIndexChanged);
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(235, 8);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(78, 13);
            this.label43.TabIndex = 8;
            this.label43.Text = "QuestionType:";
            // 
            // cmbSEQ
            // 
            this.cmbSEQ.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cmbSEQ.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cmbSEQ.FormattingEnabled = true;
            this.cmbSEQ.Location = new System.Drawing.Point(108, 4);
            this.cmbSEQ.MaxDropDownItems = 8;
            this.cmbSEQ.Name = "cmbSEQ";
            this.cmbSEQ.Size = new System.Drawing.Size(115, 21);
            this.cmbSEQ.TabIndex = 7;
            this.cmbSEQ.SelectedIndexChanged += new System.EventHandler(this.OnSequenceSelectedIndexChanged);
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(3, 7);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(104, 13);
            this.label42.TabIndex = 6;
            this.label42.Text = "Question Sequence:";
            // 
            // gvwCustomQuestions
            // 
            this.gvwCustomQuestions.AllowUserToAddRows = false;
            this.gvwCustomQuestions.AutoSizeRowsMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.gvwCustomQuestions.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.gvwCustomQuestions.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvwCustomQuestions.Columns.AddRange(new Gizmox.WebGUI.Forms.DataGridViewColumn[] {
            this.ImgSave,
            this.Question,
            this.Response,
            this.ResponseCode});
            this.gvwCustomQuestions.ContextMenu = this.contextMenu2;
            this.gvwCustomQuestions.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.gvwCustomQuestions.ItemsPerPage = 200;
            this.gvwCustomQuestions.Location = new System.Drawing.Point(0, 0);
            this.gvwCustomQuestions.MultiSelect = false;
            this.gvwCustomQuestions.Name = "gvwCustomQuestions";
            this.gvwCustomQuestions.RowHeadersWidth = 5;
            dataGridViewCellStyle2.FormatProvider = new System.Globalization.CultureInfo("en-IN");
            dataGridViewCellStyle2.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.gvwCustomQuestions.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gvwCustomQuestions.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("en-IN");
            this.gvwCustomQuestions.RowTemplate.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.gvwCustomQuestions.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical;
            this.gvwCustomQuestions.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvwCustomQuestions.Size = new System.Drawing.Size(702, 158);
            this.gvwCustomQuestions.TabIndex = 5;
            this.gvwCustomQuestions.DataError += new Gizmox.WebGUI.Forms.DataGridViewDataErrorEventHandler(this.gvwCustomQuestions_DataError);
            this.gvwCustomQuestions.MenuClick += new Gizmox.WebGUI.Forms.MenuEventHandler(this.gvwCustomQuestions_MenuClick);
            // 
            // ImgSave
            // 
            this.ImgSave.HeaderText = " ";
            this.ImgSave.ImageLayout = Gizmox.WebGUI.Forms.DataGridViewImageCellLayout.Normal;
            this.ImgSave.Name = "ImgSave";
            this.ImgSave.Width = 40;
            // 
            // Question
            // 
            dataGridViewCellStyle1.FormatProvider = new System.Globalization.CultureInfo("en-IN");
            dataGridViewCellStyle1.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.Question.DefaultCellStyle = dataGridViewCellStyle1;
            this.Question.HeaderText = "Question Description";
            this.Question.Name = "Question";
            this.Question.Width = 300;
            // 
            // Response
            // 
            this.Response.Name = "Response";
            this.Response.Width = 355;
            // 
            // ResponseCode
            // 
            this.ResponseCode.Name = "ResponseCode";
            this.ResponseCode.Visible = false;
            this.ResponseCode.Width = 5;
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
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(702, 29);
            this.panel1.TabIndex = 12;
            // 
            // picMax
            // 
            this.picMax.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.picMax.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("picMax.Image"));
            this.picMax.Location = new System.Drawing.Point(681, 3);
            this.picMax.Name = "picMax";
            this.picMax.Size = new System.Drawing.Size(19, 18);
            this.picMax.TabIndex = 12;
            this.picMax.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gvwCustomQuestions);
            this.panel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 29);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(702, 158);
            this.panel2.TabIndex = 13;
            // 
            // CustomFieldsControl
            // 
            this.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Size = new System.Drawing.Size(702, 187);
            this.Text = "CustomFields";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
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
        private Panel panel2;
        private PictureBox picMax;
        private ContextMenu contextMenu2;
        private DataGridViewTextBoxColumn ResponseCode;



    }
}