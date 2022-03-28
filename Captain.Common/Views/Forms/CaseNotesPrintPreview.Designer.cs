using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Captain.Common.Views.Forms
{
    partial class CaseNotesPrintPreview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CaseNotesPrintPreview));
            this.lblApplicationNo = new Gizmox.WebGUI.Forms.Label();
            this.lblApplicationNon = new Gizmox.WebGUI.Forms.Label();
            this.lblClientNameD = new Gizmox.WebGUI.Forms.Label();
            this.lblClientName = new Gizmox.WebGUI.Forms.Label();
            this.txtDesc = new Gizmox.WebGUI.Forms.TextBox();
            this.panel3 = new Gizmox.WebGUI.Forms.Panel();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.dataGridCaseNotes = new Gizmox.WebGUI.Forms.DataGridView();
            this.categorychk = new Gizmox.WebGUI.Forms.DataGridViewCheckBoxColumn();
            this.ScreenName = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.ReceiveDate = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new Gizmox.WebGUI.Forms.Panel();
            this.radioButton2 = new Gizmox.WebGUI.Forms.RadioButton();
            this.radioButton1 = new Gizmox.WebGUI.Forms.RadioButton();
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.pictureBox2 = new Gizmox.WebGUI.Forms.PictureBox();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.panel5 = new Gizmox.WebGUI.Forms.Panel();
            this.cmbsize = new Gizmox.WebGUI.Forms.ComboBox();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.chkPrintName = new Gizmox.WebGUI.Forms.CheckBox();
            this.btnExit = new Gizmox.WebGUI.Forms.Button();
            this.btnPrint = new Gizmox.WebGUI.Forms.Button();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCaseNotes)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblApplicationNo
            // 
            this.lblApplicationNo.AutoSize = true;
            this.lblApplicationNo.ExcludeFromUniqueId = false;
            this.lblApplicationNo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationNo.Location = new System.Drawing.Point(38, 9);
            this.lblApplicationNo.Name = "lblApplicationNo";
            this.lblApplicationNo.NextFocusId = ((long)(0));
            this.lblApplicationNo.PerformLayoutEnabled = true;
            this.lblApplicationNo.PreviousFocusId = ((long)(0));
            this.lblApplicationNo.Size = new System.Drawing.Size(75, 13);
            this.lblApplicationNo.TabIndex = 0;
            this.lblApplicationNo.Text = "App#:";
            this.lblApplicationNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblApplicationNon
            // 
            this.lblApplicationNon.AutoSize = true;
            this.lblApplicationNon.ExcludeFromUniqueId = false;
            this.lblApplicationNon.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold);
            this.lblApplicationNon.Location = new System.Drawing.Point(81, 7);
            this.lblApplicationNon.Name = "lblApplicationNon";
            this.lblApplicationNon.NextFocusId = ((long)(0));
            this.lblApplicationNon.PerformLayoutEnabled = true;
            this.lblApplicationNon.PreviousFocusId = ((long)(0));
            this.lblApplicationNon.Size = new System.Drawing.Size(0, 13);
            this.lblApplicationNon.TabIndex = 1;
            // 
            // lblClientNameD
            // 
            this.lblClientNameD.AutoSize = true;
            this.lblClientNameD.ExcludeFromUniqueId = false;
            this.lblClientNameD.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold);
            this.lblClientNameD.Location = new System.Drawing.Point(249, 7);
            this.lblClientNameD.Name = "lblClientNameD";
            this.lblClientNameD.NextFocusId = ((long)(0));
            this.lblClientNameD.PerformLayoutEnabled = true;
            this.lblClientNameD.PreviousFocusId = ((long)(0));
            this.lblClientNameD.Size = new System.Drawing.Size(0, 13);
            this.lblClientNameD.TabIndex = 3;
            // 
            // lblClientName
            // 
            this.lblClientName.AutoSize = true;
            this.lblClientName.ExcludeFromUniqueId = false;
            this.lblClientName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientName.Location = new System.Drawing.Point(198, 9);
            this.lblClientName.Name = "lblClientName";
            this.lblClientName.NextFocusId = ((long)(0));
            this.lblClientName.PerformLayoutEnabled = true;
            this.lblClientName.PreviousFocusId = ((long)(0));
            this.lblClientName.Size = new System.Drawing.Size(64, 13);
            this.lblClientName.TabIndex = 2;
            this.lblClientName.Text = "Name:";
            this.lblClientName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDesc
            // 
            this.txtDesc.ExcludeFromUniqueId = false;
            this.txtDesc.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesc.Location = new System.Drawing.Point(-1, 212);
            this.txtDesc.MaxLength = 150000;
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.NextFocusId = ((long)(0));
            this.txtDesc.PerformLayoutEnabled = true;
            this.txtDesc.PreviousFocusId = ((long)(0));
            this.txtDesc.ReadOnly = true;
            this.txtDesc.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical;
            this.txtDesc.Size = new System.Drawing.Size(572, 200);
            this.txtDesc.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.dataGridCaseNotes);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.txtDesc);
            this.panel3.ExcludeFromUniqueId = false;
            this.panel3.Location = new System.Drawing.Point(-1, 34);
            this.panel3.Name = "panel3";
            this.panel3.NextFocusId = ((long)(0));
            this.panel3.PerformLayoutEnabled = true;
            this.panel3.PreviousFocusId = ((long)(0));
            this.panel3.Size = new System.Drawing.Size(573, 413);
            this.panel3.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ExcludeFromUniqueId = false;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(245, 190);
            this.label1.Name = "label1";
            this.label1.NextFocusId = ((long)(0));
            this.label1.PerformLayoutEnabled = true;
            this.label1.PreviousFocusId = ((long)(0));
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Case Notes";
            // 
            // dataGridCaseNotes
            // 
            this.dataGridCaseNotes.AllowUserToAddRows = false;
            this.dataGridCaseNotes.AllowUserToDeleteRows = false;
            this.dataGridCaseNotes.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.FormatProvider = new System.Globalization.CultureInfo("en-US");
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.dataGridCaseNotes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridCaseNotes.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridCaseNotes.Columns.AddRange(new Gizmox.WebGUI.Forms.DataGridViewColumn[] {
            this.categorychk,
            this.ScreenName,
            this.ReceiveDate,
            this.dataGridViewTextBoxColumn1});
            this.dataGridCaseNotes.ExcludeFromUniqueId = false;
            this.dataGridCaseNotes.Location = new System.Drawing.Point(-1, 27);
            this.dataGridCaseNotes.MultiSelect = false;
            this.dataGridCaseNotes.Name = "dataGridCaseNotes";
            this.dataGridCaseNotes.NextFocusId = ((long)(0));
            this.dataGridCaseNotes.PerformLayoutEnabled = true;
            this.dataGridCaseNotes.PreviousFocusId = ((long)(0));
            this.dataGridCaseNotes.RenderCellPanelsAsText = false;
            this.dataGridCaseNotes.RowHeadersVisible = false;
            this.dataGridCaseNotes.RowHeadersWidth = 14;
            this.dataGridCaseNotes.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("en-US");
            this.dataGridCaseNotes.RowTemplate.Enabled = true;
            this.dataGridCaseNotes.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical;
            this.dataGridCaseNotes.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridCaseNotes.Size = new System.Drawing.Size(573, 158);
            this.dataGridCaseNotes.TabIndex = 2;
            this.dataGridCaseNotes.SelectionChanged += new System.EventHandler(this.dataGridCaseNotes_SelectionChanged);
            // 
            // categorychk
            // 
            dataGridViewCellStyle2.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = false;
            this.categorychk.DefaultCellStyle = dataGridViewCellStyle2;
            this.categorychk.HeaderText = " ";
            this.categorychk.Name = "categorychk";
            this.categorychk.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.False;
            this.categorychk.Width = 25;
            // 
            // ScreenName
            // 
            this.ScreenName.DefaultCellStyle = dataGridViewCellStyle3;
            this.ScreenName.HeaderText = "Screen Name";
            this.ScreenName.Name = "ScreenName";
            this.ScreenName.ReadOnly = true;
            this.ScreenName.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ScreenName.Width = 300;
            // 
            // ReceiveDate
            // 
            this.ReceiveDate.DefaultCellStyle = dataGridViewCellStyle4;
            this.ReceiveDate.HeaderText = "On";
            this.ReceiveDate.Name = "ReceiveDate";
            this.ReceiveDate.ReadOnly = true;
            this.ReceiveDate.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.False;
            this.ReceiveDate.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ReceiveDate.Width = 80;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn1.HeaderText = "By";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.radioButton2);
            this.panel4.Controls.Add(this.radioButton1);
            this.panel4.ExcludeFromUniqueId = false;
            this.panel4.Location = new System.Drawing.Point(0, 2);
            this.panel4.Name = "panel4";
            this.panel4.NextFocusId = ((long)(0));
            this.panel4.PerformLayoutEnabled = true;
            this.panel4.PreviousFocusId = ((long)(0));
            this.panel4.Size = new System.Drawing.Size(259, 23);
            this.panel4.TabIndex = 1;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.ExcludeFromUniqueId = false;
            this.radioButton2.Location = new System.Drawing.Point(125, 3);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.NextFocusId = ((long)(0));
            this.radioButton2.PerformLayoutEnabled = true;
            this.radioButton2.PreviousFocusId = ((long)(0));
            this.radioButton2.Size = new System.Drawing.Size(124, 17);
            this.radioButton2.TabIndex = 0;
            this.radioButton2.Text = "Selected Case Notes";
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.ExcludeFromUniqueId = false;
            this.radioButton1.Location = new System.Drawing.Point(5, 3);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.NextFocusId = ((long)(0));
            this.radioButton1.PerformLayoutEnabled = true;
            this.radioButton1.PreviousFocusId = ((long)(0));
            this.radioButton1.Size = new System.Drawing.Size(94, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.Text = "All Case Notes";
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.lblApplicationNo);
            this.panel2.Controls.Add(this.lblClientNameD);
            this.panel2.Controls.Add(this.lblApplicationNon);
            this.panel2.Controls.Add(this.lblClientName);
            this.panel2.ExcludeFromUniqueId = false;
            this.panel2.Location = new System.Drawing.Point(-1, -1);
            this.panel2.Name = "panel2";
            this.panel2.NextFocusId = ((long)(0));
            this.panel2.PerformLayoutEnabled = true;
            this.panel2.PreviousFocusId = ((long)(0));
            this.panel2.Size = new System.Drawing.Size(573, 36);
            this.panel2.TabIndex = 4;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Bottom) 
            | Gizmox.WebGUI.Forms.AnchorStyles.Left) 
            | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox2.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.pictureBox2.ExcludeFromUniqueId = false;
            this.pictureBox2.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("pictureBox2.Image"));
            this.pictureBox2.Location = new System.Drawing.Point(13, 7);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.NextFocusId = ((long)(0));
            this.pictureBox2.PerformLayoutEnabled = true;
            this.pictureBox2.PreviousFocusId = ((long)(0));
            this.pictureBox2.Size = new System.Drawing.Size(18, 20);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.ExcludeFromUniqueId = false;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.NextFocusId = ((long)(0));
            this.panel1.PerformLayoutEnabled = true;
            this.panel1.PreviousFocusId = ((long)(0));
            this.panel1.Size = new System.Drawing.Size(571, 478);
            this.panel1.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.cmbsize);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.chkPrintName);
            this.panel5.Controls.Add(this.btnExit);
            this.panel5.Controls.Add(this.btnPrint);
            this.panel5.ExcludeFromUniqueId = false;
            this.panel5.Location = new System.Drawing.Point(-1, 446);
            this.panel5.Name = "panel5";
            this.panel5.NextFocusId = ((long)(0));
            this.panel5.PerformLayoutEnabled = true;
            this.panel5.PreviousFocusId = ((long)(0));
            this.panel5.Size = new System.Drawing.Size(573, 33);
            this.panel5.TabIndex = 6;
            // 
            // cmbsize
            // 
            this.cmbsize.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cmbsize.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cmbsize.ExcludeFromUniqueId = false;
            this.cmbsize.FormattingEnabled = true;
            this.cmbsize.Location = new System.Drawing.Point(267, 4);
            this.cmbsize.Name = "cmbsize";
            this.cmbsize.NextFocusId = ((long)(0));
            this.cmbsize.PerformLayoutEnabled = true;
            this.cmbsize.PreviousFocusId = ((long)(0));
            this.cmbsize.Size = new System.Drawing.Size(50, 21);
            this.cmbsize.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ExcludeFromUniqueId = false;
            this.label2.Location = new System.Drawing.Point(236, 7);
            this.label2.Name = "label2";
            this.label2.NextFocusId = ((long)(0));
            this.label2.PerformLayoutEnabled = true;
            this.label2.PreviousFocusId = ((long)(0));
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Size";
            // 
            // chkPrintName
            // 
            this.chkPrintName.ExcludeFromUniqueId = false;
            this.chkPrintName.Location = new System.Drawing.Point(334, 7);
            this.chkPrintName.Name = "chkPrintName";
            this.chkPrintName.NextFocusId = ((long)(0));
            this.chkPrintName.PerformLayoutEnabled = true;
            this.chkPrintName.PreviousFocusId = ((long)(0));
            this.chkPrintName.Size = new System.Drawing.Size(108, 18);
            this.chkPrintName.TabIndex = 8;
            this.chkPrintName.Text = "Print Client Name";
            // 
            // btnExit
            // 
            this.btnExit.AutoEllipsis = true;
            this.btnExit.ExcludeFromUniqueId = false;
            this.btnExit.Location = new System.Drawing.Point(509, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.NextFocusId = ((long)(0));
            this.btnExit.PerformLayoutEnabled = true;
            this.btnExit.PreviousFocusId = ((long)(0));
            this.btnExit.Size = new System.Drawing.Size(60, 26);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.AutoEllipsis = true;
            this.btnPrint.ExcludeFromUniqueId = false;
            this.btnPrint.Location = new System.Drawing.Point(448, 2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.NextFocusId = ((long)(0));
            this.btnPrint.PerformLayoutEnabled = true;
            this.btnPrint.PreviousFocusId = ((long)(0));
            this.btnPrint.Size = new System.Drawing.Size(60, 26);
            this.btnPrint.TabIndex = 6;
            this.btnPrint.Text = "Print";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click_1);
            // 
            // CaseNotesPrintPreview
            // 
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(571, 478);
            this.Text = "CaseNotesPrintPreview";
            this.Load += new System.EventHandler(this.CaseNotesPrintPreview_Load);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCaseNotes)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Label lblApplicationNo;
        private Label lblApplicationNon;
        private Label lblClientNameD;
        private Label lblClientName;
        private TextBox txtDesc;
        private Panel panel3;
        private Panel panel4;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Panel panel2;
        private Panel panel1;
        private DataGridView dataGridCaseNotes;
        private DataGridViewCheckBoxColumn categorychk;
        private DataGridViewTextBoxColumn ScreenName;
        private DataGridViewTextBoxColumn ReceiveDate;
        private Label label1;
        private Panel panel5;
        private Button btnExit;
        private Button btnPrint;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private CheckBox chkPrintName;
        private PictureBox pictureBox2;
        private ComboBox cmbsize;
        private Label label2;


    }
}