using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Captain.Common.Views.Forms
{
    partial class CaseNotes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CaseNotes));
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.cmbsize = new Gizmox.WebGUI.Forms.ComboBox();
            this.btnAdd = new Gizmox.WebGUI.Forms.Button();
            this.btnOk = new Gizmox.WebGUI.Forms.Button();
            this.btnClose = new Gizmox.WebGUI.Forms.Button();
            this.btnPrint = new Gizmox.WebGUI.Forms.Button();
            this.btnPreview = new Gizmox.WebGUI.Forms.Button();
            this.btnDelete = new Gizmox.WebGUI.Forms.Button();
            this.btnChange = new Gizmox.WebGUI.Forms.Button();
            this.panel3 = new Gizmox.WebGUI.Forms.Panel();
            this.txtDesc = new Gizmox.WebGUI.Forms.TextBox();
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.pictureBox2 = new Gizmox.WebGUI.Forms.PictureBox();
            this.lblYear = new Gizmox.WebGUI.Forms.Label();
            this.cmbYear = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblApplicationNo = new Gizmox.WebGUI.Forms.Label();
            this.lblClientNameD = new Gizmox.WebGUI.Forms.Label();
            this.lblApplicationNon = new Gizmox.WebGUI.Forms.Label();
            this.lblClientName = new Gizmox.WebGUI.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbsize);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.btnPreview);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnChange);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.ExcludeFromUniqueId = false;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.NextFocusId = ((long)(0));
            this.panel1.PerformLayoutEnabled = true;
            this.panel1.PreviousFocusId = ((long)(0));
            this.panel1.Size = new System.Drawing.Size(541, 341);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ExcludeFromUniqueId = false;
            this.label1.Location = new System.Drawing.Point(354, 320);
            this.label1.Name = "label1";
            this.label1.NextFocusId = ((long)(0));
            this.label1.PerformLayoutEnabled = true;
            this.label1.PreviousFocusId = ((long)(0));
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Size";
            // 
            // cmbsize
            // 
            this.cmbsize.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cmbsize.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cmbsize.ExcludeFromUniqueId = false;
            this.cmbsize.FormattingEnabled = true;
            this.cmbsize.Location = new System.Drawing.Point(383, 316);
            this.cmbsize.Name = "cmbsize";
            this.cmbsize.NextFocusId = ((long)(0));
            this.cmbsize.PerformLayoutEnabled = true;
            this.cmbsize.PreviousFocusId = ((long)(0));
            this.cmbsize.Size = new System.Drawing.Size(50, 21);
            this.cmbsize.TabIndex = 2;
            // 
            // btnAdd
            // 
            this.btnAdd.ExcludeFromUniqueId = false;
            this.btnAdd.Location = new System.Drawing.Point(2, 315);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.NextFocusId = ((long)(0));
            this.btnAdd.PerformLayoutEnabled = true;
            this.btnAdd.PreviousFocusId = ((long)(0));
            this.btnAdd.Size = new System.Drawing.Size(60, 23);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnOk
            // 
            this.btnOk.ExcludeFromUniqueId = false;
            this.btnOk.Location = new System.Drawing.Point(197, 315);
            this.btnOk.Name = "btnOk";
            this.btnOk.NextFocusId = ((long)(0));
            this.btnOk.PerformLayoutEnabled = true;
            this.btnOk.PreviousFocusId = ((long)(0));
            this.btnOk.Size = new System.Drawing.Size(60, 23);
            this.btnOk.TabIndex = 11;
            this.btnOk.Text = "Save";
            this.btnOk.Visible = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnClose
            // 
            this.btnClose.ExcludeFromUniqueId = false;
            this.btnClose.Location = new System.Drawing.Point(257, 315);
            this.btnClose.Name = "btnClose";
            this.btnClose.NextFocusId = ((long)(0));
            this.btnClose.PerformLayoutEnabled = true;
            this.btnClose.PreviousFocusId = ((long)(0));
            this.btnClose.Size = new System.Drawing.Size(60, 23);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Cancel";
            this.btnClose.Visible = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.ExcludeFromUniqueId = false;
            this.btnPrint.Location = new System.Drawing.Point(121, 315);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.NextFocusId = ((long)(0));
            this.btnPrint.PerformLayoutEnabled = true;
            this.btnPrint.PreviousFocusId = ((long)(0));
            this.btnPrint.Size = new System.Drawing.Size(60, 23);
            this.btnPrint.TabIndex = 9;
            this.btnPrint.Text = "Print";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.ExcludeFromUniqueId = false;
            this.btnPreview.Location = new System.Drawing.Point(471, 316);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.NextFocusId = ((long)(0));
            this.btnPreview.PerformLayoutEnabled = true;
            this.btnPreview.PreviousFocusId = ((long)(0));
            this.btnPreview.Size = new System.Drawing.Size(66, 23);
            this.btnPreview.TabIndex = 10;
            this.btnPreview.Text = "Print/View";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.ExcludeFromUniqueId = false;
            this.btnDelete.Location = new System.Drawing.Point(62, 315);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.NextFocusId = ((long)(0));
            this.btnDelete.PerformLayoutEnabled = true;
            this.btnDelete.PreviousFocusId = ((long)(0));
            this.btnDelete.Size = new System.Drawing.Size(60, 23);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnChange
            // 
            this.btnChange.ExcludeFromUniqueId = false;
            this.btnChange.Location = new System.Drawing.Point(2, 315);
            this.btnChange.Name = "btnChange";
            this.btnChange.NextFocusId = ((long)(0));
            this.btnChange.PerformLayoutEnabled = true;
            this.btnChange.PreviousFocusId = ((long)(0));
            this.btnChange.Size = new System.Drawing.Size(60, 23);
            this.btnChange.TabIndex = 7;
            this.btnChange.Text = "Change";
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.txtDesc);
            this.panel3.ExcludeFromUniqueId = false;
            this.panel3.Location = new System.Drawing.Point(-1, 35);
            this.panel3.Name = "panel3";
            this.panel3.NextFocusId = ((long)(0));
            this.panel3.PerformLayoutEnabled = true;
            this.panel3.PreviousFocusId = ((long)(0));
            this.panel3.Size = new System.Drawing.Size(542, 278);
            this.panel3.TabIndex = 5;
            // 
            // txtDesc
            // 
            this.txtDesc.ExcludeFromUniqueId = false;
            this.txtDesc.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesc.Location = new System.Drawing.Point(-1, -1);
            this.txtDesc.MaxLength = 150000;
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.NextFocusId = ((long)(0));
            this.txtDesc.PerformLayoutEnabled = true;
            this.txtDesc.PreviousFocusId = ((long)(0));
            this.txtDesc.ReadOnly = true;
            this.txtDesc.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical;
            this.txtDesc.Size = new System.Drawing.Size(543, 278);
            this.txtDesc.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.lblYear);
            this.panel2.Controls.Add(this.cmbYear);
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
            this.panel2.Size = new System.Drawing.Size(543, 37);
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
            this.pictureBox2.Location = new System.Drawing.Point(6, 9);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.NextFocusId = ((long)(0));
            this.pictureBox2.PerformLayoutEnabled = true;
            this.pictureBox2.PreviousFocusId = ((long)(0));
            this.pictureBox2.Size = new System.Drawing.Size(18, 20);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.ExcludeFromUniqueId = false;
            this.lblYear.Location = new System.Drawing.Point(437, 11);
            this.lblYear.Name = "lblYear";
            this.lblYear.NextFocusId = ((long)(0));
            this.lblYear.PerformLayoutEnabled = true;
            this.lblYear.PreviousFocusId = ((long)(0));
            this.lblYear.Size = new System.Drawing.Size(35, 13);
            this.lblYear.TabIndex = 5;
            this.lblYear.Text = "Year";
            this.lblYear.Visible = false;
            // 
            // cmbYear
            // 
            this.cmbYear.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cmbYear.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.ExcludeFromUniqueId = false;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(471, 7);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.NextFocusId = ((long)(0));
            this.cmbYear.PerformLayoutEnabled = true;
            this.cmbYear.PreviousFocusId = ((long)(0));
            this.cmbYear.Size = new System.Drawing.Size(61, 21);
            this.cmbYear.TabIndex = 4;
            this.cmbYear.Visible = false;
            this.cmbYear.SelectedIndexChanged += new System.EventHandler(this.cmbYear_SelectedIndexChanged);
            // 
            // lblApplicationNo
            // 
            this.lblApplicationNo.AutoSize = true;
            this.lblApplicationNo.ExcludeFromUniqueId = false;
            this.lblApplicationNo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationNo.Location = new System.Drawing.Point(30, 10);
            this.lblApplicationNo.Name = "lblApplicationNo";
            this.lblApplicationNo.NextFocusId = ((long)(0));
            this.lblApplicationNo.PerformLayoutEnabled = true;
            this.lblApplicationNo.PreviousFocusId = ((long)(0));
            this.lblApplicationNo.Size = new System.Drawing.Size(75, 13);
            this.lblApplicationNo.TabIndex = 0;
            this.lblApplicationNo.Text = "App#:";
            // 
            // lblClientNameD
            // 
            this.lblClientNameD.AutoSize = true;
            this.lblClientNameD.ExcludeFromUniqueId = false;
            this.lblClientNameD.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientNameD.Location = new System.Drawing.Point(241, 10);
            this.lblClientNameD.Name = "lblClientNameD";
            this.lblClientNameD.NextFocusId = ((long)(0));
            this.lblClientNameD.PerformLayoutEnabled = true;
            this.lblClientNameD.PreviousFocusId = ((long)(0));
            this.lblClientNameD.Size = new System.Drawing.Size(0, 13);
            this.lblClientNameD.TabIndex = 3;
            // 
            // lblApplicationNon
            // 
            this.lblApplicationNon.AutoSize = true;
            this.lblApplicationNon.ExcludeFromUniqueId = false;
            this.lblApplicationNon.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationNon.Location = new System.Drawing.Point(85, 10);
            this.lblApplicationNon.Name = "lblApplicationNon";
            this.lblApplicationNon.NextFocusId = ((long)(0));
            this.lblApplicationNon.PerformLayoutEnabled = true;
            this.lblApplicationNon.PreviousFocusId = ((long)(0));
            this.lblApplicationNon.Size = new System.Drawing.Size(0, 13);
            this.lblApplicationNon.TabIndex = 1;
            // 
            // lblClientName
            // 
            this.lblClientName.AutoSize = true;
            this.lblClientName.ExcludeFromUniqueId = false;
            this.lblClientName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientName.Location = new System.Drawing.Point(175, 10);
            this.lblClientName.Name = "lblClientName";
            this.lblClientName.NextFocusId = ((long)(0));
            this.lblClientName.PerformLayoutEnabled = true;
            this.lblClientName.PreviousFocusId = ((long)(0));
            this.lblClientName.Size = new System.Drawing.Size(64, 13);
            this.lblClientName.TabIndex = 2;
            this.lblClientName.Text = "Name :";
            // 
            // CaseNotes
            // 
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(541, 340);
            this.Text = "CaseNotes";
            this.FormClosing += new Gizmox.WebGUI.Forms.Form.FormClosingEventHandler(this.CaseNotes_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Button btnClose;
        private Button btnPrint;
        private Button btnPreview;
        private Button btnDelete;
        private Button btnChange;
        private Panel panel3;
        private Panel panel2;
        private Label lblApplicationNo;
        private Label lblClientNameD;
        private Label lblApplicationNon;
        private Label lblClientName;
        private TextBox txtDesc;
        private Button btnAdd;
        private Button btnOk;
        private Label lblYear;
        private ComboBox cmbYear;
        private PictureBox pictureBox2;
        private Label label1;
        private ComboBox cmbsize;


    }
}