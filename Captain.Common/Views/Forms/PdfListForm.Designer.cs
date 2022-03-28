using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Captain.Common.Views.Forms
{
    partial class PdfListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PdfListForm));
            this.pictureBox2 = new Gizmox.WebGUI.Forms.PictureBox();
            this.dateTimePicker1 = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.panel4 = new Gizmox.WebGUI.Forms.Panel();
            this.lblHeader = new Gizmox.WebGUI.Forms.Label();
            this.pictureBox1 = new Gizmox.WebGUI.Forms.PictureBox();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.listViewPdf = new Gizmox.WebGUI.Forms.ListView();
            this.PdfName = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.contextMenu1 = new Gizmox.WebGUI.Forms.ContextMenu();
            this.PdfSize = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.ModifiedOn = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.PdfMark = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.btnDelete = new Gizmox.WebGUI.Forms.Button();
            this.btnDeleteAll = new Gizmox.WebGUI.Forms.Button();
            this.btnPreview = new Gizmox.WebGUI.Forms.Button();
            this.SavePanel = new Gizmox.WebGUI.Forms.Panel();
            this.BtnSave = new Gizmox.WebGUI.Forms.Button();
            this.CbmFileType = new Gizmox.WebGUI.Forms.ComboBox();
            this.TxtFileName = new Gizmox.WebGUI.Forms.TextBox();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.btnDownload = new Gizmox.WebGUI.Forms.Button();
            this.btnMerge = new Gizmox.WebGUI.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SavePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Bottom) 
            | Gizmox.WebGUI.Forms.AnchorStyles.Left) 
            | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox2.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.pictureBox2.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("pictureBox2.Image"));
            this.pictureBox2.Location = new System.Drawing.Point(511, 14);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(19, 18);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.OnHelpClick);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "";
            this.dateTimePicker1.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(417, -219);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(79, 21);
            this.dateTimePicker1.TabIndex = 15;
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(124, -249);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(415, 64);
            this.panel4.TabIndex = 0;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(66, 14);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(35, 13);
            this.lblHeader.TabIndex = 1;
            this.lblHeader.Text = "Report Preview/Maintenance";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox1.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("pictureBox1.Image"));
            this.pictureBox1.Location = new System.Drawing.Point(8, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 46);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.lblHeader);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(539, 55);
            this.panel1.TabIndex = 0;
            // 
            // listViewPdf
            // 
            this.listViewPdf.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.PdfName,
            this.PdfSize,
            this.ModifiedOn,
            this.PdfMark});
            this.listViewPdf.DataMember = null;
            this.listViewPdf.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.listViewPdf.HeaderStyle = Gizmox.WebGUI.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewPdf.Location = new System.Drawing.Point(3, 58);
            this.listViewPdf.Name = "listViewPdf";
            this.listViewPdf.Size = new System.Drawing.Size(534, 208);
            this.listViewPdf.TabIndex = 1;
            this.listViewPdf.SelectedIndexChanged += new System.EventHandler(this.listViewPdf_SelectedIndexChanged);
            this.listViewPdf.MenuClick += new Gizmox.WebGUI.Forms.MenuEventHandler(this.listViewPdf_MenuClick);
            // 
            // PdfName
            // 
            this.PdfName.ContextMenu = this.contextMenu1;
            this.PdfName.Tag = "Name";
            this.PdfName.Text = "Name";
            this.PdfName.Width = 265;
            // 
            // contextMenu1
            // 
            this.contextMenu1.Popup += new System.EventHandler(this.contextMenu1_Popup);
            // 
            // PdfSize
            // 
            this.PdfSize.ContextMenu = this.contextMenu1;
            this.PdfSize.Tag = "Size";
            this.PdfSize.Text = "Size";
            this.PdfSize.Width = 80;
            // 
            // ModifiedOn
            // 
            this.ModifiedOn.ContextMenu = this.contextMenu1;
            this.ModifiedOn.Tag = "Modified On";
            this.ModifiedOn.Text = "Modified On";
            this.ModifiedOn.Width = 120;
            // 
            // PdfMark
            // 
            this.PdfMark.ContextMenu = this.contextMenu1;
            this.PdfMark.Text = "  ";
            this.PdfMark.Width = 25;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(2, 267);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 25);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.Location = new System.Drawing.Point(76, 267);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(75, 25);
            this.btnDeleteAll.TabIndex = 2;
            this.btnDeleteAll.Text = "Delete All";
            this.btnDeleteAll.Visible = false;
            this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(458, 267);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 25);
            this.btnPreview.TabIndex = 2;
            this.btnPreview.Text = "Preview";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // SavePanel
            // 
            this.SavePanel.Controls.Add(this.BtnSave);
            this.SavePanel.Controls.Add(this.CbmFileType);
            this.SavePanel.Controls.Add(this.TxtFileName);
            this.SavePanel.Controls.Add(this.label2);
            this.SavePanel.Controls.Add(this.label1);
            this.SavePanel.Location = new System.Drawing.Point(179, 270);
            this.SavePanel.Name = "SavePanel";
            this.SavePanel.Size = new System.Drawing.Size(110, 23);
            this.SavePanel.TabIndex = 3;
            this.SavePanel.Visible = false;
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(444, 26);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(89, 26);
            this.BtnSave.TabIndex = 3;
            this.BtnSave.Text = "Save";
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // CbmFileType
            // 
            this.CbmFileType.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.CbmFileType.Enabled = false;
            this.CbmFileType.FormattingEnabled = true;
            this.CbmFileType.Items.AddRange(new object[] {
            "*.pdf",
            "*.txt"});
            this.CbmFileType.Location = new System.Drawing.Point(55, 28);
            this.CbmFileType.Name = "CbmFileType";
            this.CbmFileType.Size = new System.Drawing.Size(386, 21);
            this.CbmFileType.TabIndex = 2;
            // 
            // TxtFileName
            // 
            this.TxtFileName.Location = new System.Drawing.Point(56, 4);
            this.TxtFileName.MaxLength = 55;
            this.TxtFileName.Name = "TxtFileName";
            this.TxtFileName.Size = new System.Drawing.Size(385, 20);
            this.TxtFileName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Save as";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "File Name";
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(380, 267);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(75, 25);
            this.btnDownload.TabIndex = 2;
            this.btnDownload.Text = "Download";
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnMerge
            // 
            this.btnMerge.Location = new System.Drawing.Point(305, 266);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(75, 25);
            this.btnMerge.TabIndex = 2;
            this.btnMerge.Text = "Excel Merge";
            this.btnMerge.Visible = false;
            this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
            // 
            // PdfListForm
            // 
            this.Controls.Add(this.btnMerge);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.SavePanel);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.btnDeleteAll);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.listViewPdf);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedToolWindow;
            this.Size = new System.Drawing.Size(539, 294);
            this.Text = "PdfListForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.SavePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox pictureBox2;
        private DateTimePicker dateTimePicker1;
        private Panel panel4;
        private Label lblHeader;
        private PictureBox pictureBox1;
        private Panel panel1;
        private ListView listViewPdf;
        private ColumnHeader PdfName;
        private ColumnHeader PdfSize;
        private ColumnHeader ModifiedOn;
        private Button btnDelete;
        private Button btnDeleteAll;
        private Button btnPreview;
        private Panel SavePanel;
        private Button BtnSave;
        private ComboBox CbmFileType;
        private TextBox TxtFileName;
        private Label label2;
        private Label label1;
        private ColumnHeader PdfMark;
        private ContextMenu contextMenu1;
        private Button btnDownload;
        private Button btnMerge;


    }
}