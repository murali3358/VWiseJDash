using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Captain.Common.Views.Forms
{
    partial class SiteSearchForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SiteSearchForm));
            this.pictureBox2 = new Gizmox.WebGUI.Forms.PictureBox();
            this.pictureBox1 = new Gizmox.WebGUI.Forms.PictureBox();
            this.lblHeader = new Gizmox.WebGUI.Forms.Label();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.btnSelect = new Gizmox.WebGUI.Forms.Button();
            this.dataGridSiteSearch = new Gizmox.WebGUI.Forms.DataGridView();
            this.Code = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.Description = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.Active = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.pictureBox2.Location = new System.Drawing.Point(421, 15);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(17, 21);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.OnHelpClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox1.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("pictureBox1.Image"));
            this.pictureBox1.Location = new System.Drawing.Point(10, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(47, 43);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(71, 12);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(150, 13);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Site Selection";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lblHeader);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(464, 53);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSelect);
            this.panel2.Controls.Add(this.dataGridSiteSearch);
            this.panel2.Location = new System.Drawing.Point(9, 55);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(446, 238);
            this.panel2.TabIndex = 1;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(366, 210);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 1;
            this.btnSelect.Text = "Select";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // dataGridSiteSearch
            // 
            this.dataGridSiteSearch.AllowUserToAddRows = false;
            this.dataGridSiteSearch.AllowUserToDeleteRows = false;
            this.dataGridSiteSearch.BackgroundColor = System.Drawing.Color.White;
            this.dataGridSiteSearch.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.dataGridSiteSearch.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridSiteSearch.Columns.AddRange(new Gizmox.WebGUI.Forms.DataGridViewColumn[] {
            this.Code,
            this.Description,
            this.Active});
            this.dataGridSiteSearch.Location = new System.Drawing.Point(4, 4);
            this.dataGridSiteSearch.Name = "dataGridSiteSearch";
            this.dataGridSiteSearch.RowHeadersWidth = 14;
            this.dataGridSiteSearch.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("en-US");
            this.dataGridSiteSearch.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical;
            this.dataGridSiteSearch.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridSiteSearch.Size = new System.Drawing.Size(436, 202);
            this.dataGridSiteSearch.TabIndex = 0;
            this.dataGridSiteSearch.CellDoubleClick += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.dataGridSiteSearch_CellDoubleClick);
            // 
            // Code
            // 
            this.Code.MinimumWidth = 30;
            this.Code.Name = "Code";
            this.Code.ReadOnly = true;
            this.Code.Width = 50;
            // 
            // Description
            // 
            this.Description.MinimumWidth = 100;
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Width = 300;
            // 
            // Active
            // 
            this.Active.Name = "Active";
            this.Active.ReadOnly = true;
            this.Active.Visible = false;
            this.Active.Width = 40;
            // 
            // SiteSearchForm
            // 
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedToolWindow;
            this.Size = new System.Drawing.Size(464, 297);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterScreen;
            this.Text = "SiteSearchForm";
            this.Load += new System.EventHandler(this.SiteSearchForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Label lblHeader;
        private Panel panel1;
        private Panel panel2;
        private DataGridView dataGridSiteSearch;
        private DataGridViewTextBoxColumn Code;
        private DataGridViewTextBoxColumn Description;
        private Button btnSelect;
        private DataGridViewTextBoxColumn Active;


    }
}