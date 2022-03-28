using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Captain.Common.Views.Forms
{
    partial class CASEVERHISTORY
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CASEVERHISTORY));
            this.dataGridCaseIncomeVer = new Gizmox.WebGUI.Forms.DataGridView();
            this.gvtDate = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.gvtPIncome = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.gvtHouseHolds = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.gvtFedOmb = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.gvtCMI = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.gvtSmi = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.gvtHUD = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.pictureBox2 = new Gizmox.WebGUI.Forms.PictureBox();
            this.pictureBox1 = new Gizmox.WebGUI.Forms.PictureBox();
            this.lblHeader = new Gizmox.WebGUI.Forms.Label();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCaseIncomeVer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridCaseIncomeVer
            // 
            this.dataGridCaseIncomeVer.AllowUserToAddRows = false;
            this.dataGridCaseIncomeVer.AllowUserToDeleteRows = false;
            this.dataGridCaseIncomeVer.AllowUserToResizeColumns = false;
            this.dataGridCaseIncomeVer.AllowUserToResizeRows = false;
            this.dataGridCaseIncomeVer.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.FormatProvider = new System.Globalization.CultureInfo("en-US");
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.dataGridCaseIncomeVer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridCaseIncomeVer.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridCaseIncomeVer.Columns.AddRange(new Gizmox.WebGUI.Forms.DataGridViewColumn[] {
            this.gvtDate,
            this.gvtPIncome,
            this.gvtHouseHolds,
            this.gvtFedOmb,
            this.gvtCMI,
            this.gvtSmi,
            this.gvtHUD});
            this.dataGridCaseIncomeVer.Location = new System.Drawing.Point(0, 57);
            this.dataGridCaseIncomeVer.MultiSelect = false;
            this.dataGridCaseIncomeVer.Name = "dataGridCaseIncomeVer";
            this.dataGridCaseIncomeVer.RowHeadersWidth = 15;
            this.dataGridCaseIncomeVer.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("en-US");
            this.dataGridCaseIncomeVer.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical;
            this.dataGridCaseIncomeVer.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridCaseIncomeVer.Size = new System.Drawing.Size(605, 191);
            this.dataGridCaseIncomeVer.TabIndex = 1;
            // 
            // gvtDate
            // 
            this.gvtDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvtDate.HeaderText = "Date";
            this.gvtDate.Name = "gvtDate";
            this.gvtDate.ReadOnly = true;
            // 
            // gvtPIncome
            // 
            this.gvtPIncome.DefaultCellStyle = dataGridViewCellStyle3;
            this.gvtPIncome.HeaderText = "Program Income";
            this.gvtPIncome.Name = "gvtPIncome";
            this.gvtPIncome.ReadOnly = true;
            this.gvtPIncome.Width = 110;
            // 
            // gvtHouseHolds
            // 
            this.gvtHouseHolds.DefaultCellStyle = dataGridViewCellStyle4;
            this.gvtHouseHolds.HeaderText = "PRG#House";
            this.gvtHouseHolds.Name = "gvtHouseHolds";
            this.gvtHouseHolds.ReadOnly = true;
            this.gvtHouseHolds.Width = 75;
            // 
            // gvtFedOmb
            // 
            this.gvtFedOmb.DefaultCellStyle = dataGridViewCellStyle5;
            this.gvtFedOmb.HeaderText = "Fed OMB";
            this.gvtFedOmb.Name = "gvtFedOmb";
            this.gvtFedOmb.ReadOnly = true;
            this.gvtFedOmb.Width = 75;
            // 
            // gvtCMI
            // 
            this.gvtCMI.DefaultCellStyle = dataGridViewCellStyle6;
            this.gvtCMI.HeaderText = "CMI";
            this.gvtCMI.Name = "gvtCMI";
            this.gvtCMI.ReadOnly = true;
            this.gvtCMI.Width = 75;
            // 
            // gvtSmi
            // 
            this.gvtSmi.DefaultCellStyle = dataGridViewCellStyle7;
            this.gvtSmi.HeaderText = "SMI";
            this.gvtSmi.Name = "gvtSmi";
            this.gvtSmi.ReadOnly = true;
            this.gvtSmi.Width = 75;
            // 
            // gvtHUD
            // 
            this.gvtHUD.DefaultCellStyle = dataGridViewCellStyle8;
            this.gvtHUD.HeaderText = "HUD";
            this.gvtHUD.Name = "gvtHUD";
            this.gvtHUD.ReadOnly = true;
            this.gvtHUD.Width = 75;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Bottom) 
            | Gizmox.WebGUI.Forms.AnchorStyles.Left) 
            | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox2.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.pictureBox2.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("pictureBox2.Image"));
            this.pictureBox2.Location = new System.Drawing.Point(548, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(18, 16);
            this.pictureBox2.SizeMode = Gizmox.WebGUI.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox1.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("pictureBox1.Image"));
            this.pictureBox1.Location = new System.Drawing.Point(10, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 49);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Tahoma", 16F);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(71, 11);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(150, 13);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Income History";
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
            this.panel1.Size = new System.Drawing.Size(606, 55);
            this.panel1.TabIndex = 0;
            // 
            // CASEVERHISTORY
            // 
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridCaseIncomeVer);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(606, 251);
            this.Text = "CASEVERHISTORY";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCaseIncomeVer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dataGridCaseIncomeVer;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Label lblHeader;
        private Panel panel1;
        private DataGridViewTextBoxColumn gvtDate;
        private DataGridViewTextBoxColumn gvtPIncome;
        private DataGridViewTextBoxColumn gvtHouseHolds;
        private DataGridViewTextBoxColumn gvtFedOmb;
        private DataGridViewTextBoxColumn gvtSmi;
        private DataGridViewTextBoxColumn gvtCMI;
        private DataGridViewTextBoxColumn gvtHUD;


    }
}