using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Captain.Common.Views.Forms
{
    partial class HistoryForm
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.dataGridHistory = new Gizmox.WebGUI.Forms.DataGridView();
            this.DateTime = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.ChangedBy = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.gvtSubscr = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.Seq = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.lblChanges = new Gizmox.WebGUI.Forms.Label();
            this.btnExit = new Gizmox.WebGUI.Forms.Button();
            this.dataGridChangeFieds = new Gizmox.WebGUI.Forms.DataGridView();
            this.Field = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.OldValue = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.NewValue = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.gvtVendor = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.gvtInvdate = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.gvtAmount = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.gvtdetails = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridChangeFieds)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridHistory
            // 
            this.dataGridHistory.AllowUserToAddRows = false;
            this.dataGridHistory.AllowUserToDeleteRows = false;
            this.dataGridHistory.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.FormatProvider = new System.Globalization.CultureInfo("en-US");
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.dataGridHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridHistory.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridHistory.Columns.AddRange(new Gizmox.WebGUI.Forms.DataGridViewColumn[] {
            this.DateTime,
            this.ChangedBy,
            this.gvtSubscr,
            this.Seq,
            this.gvtVendor,
            this.gvtInvdate,
            this.gvtAmount,
            this.gvtdetails});
            this.dataGridHistory.ExcludeFromUniqueId = false;
            this.dataGridHistory.Location = new System.Drawing.Point(3, 6);
            this.dataGridHistory.Name = "dataGridHistory";
            this.dataGridHistory.NextFocusId = ((long)(0));
            this.dataGridHistory.PerformLayoutEnabled = true;
            this.dataGridHistory.PreviousFocusId = ((long)(0));
            this.dataGridHistory.RenderCellPanelsAsText = false;
            this.dataGridHistory.RowHeadersWidth = 15;
            this.dataGridHistory.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("en-IN");
            this.dataGridHistory.RowTemplate.Enabled = true;
            this.dataGridHistory.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical;
            this.dataGridHistory.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridHistory.Size = new System.Drawing.Size(507, 220);
            this.dataGridHistory.TabIndex = 0;
            this.dataGridHistory.SelectionChanged += new System.EventHandler(this.dataGridHistory_SelectionChanged);
            // 
            // DateTime
            // 
            this.DateTime.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DateTime.DefaultCellStyle = dataGridViewCellStyle2;
            this.DateTime.HeaderText = "Date & Time";
            this.DateTime.Name = "DateTime";
            this.DateTime.ReadOnly = true;
            this.DateTime.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.False;
            this.DateTime.Width = 150;
            // 
            // ChangedBy
            // 
            this.ChangedBy.DefaultCellStyle = dataGridViewCellStyle3;
            this.ChangedBy.HeaderText = "Changed By";
            this.ChangedBy.Name = "ChangedBy";
            this.ChangedBy.ReadOnly = true;
            this.ChangedBy.Width = 220;
            // 
            // gvtSubscr
            // 
            this.gvtSubscr.DefaultCellStyle = dataGridViewCellStyle4;
            this.gvtSubscr.HeaderText = "Screen";
            this.gvtSubscr.Name = "gvtSubscr";
            this.gvtSubscr.Width = 120;
            // 
            // Seq
            // 
            this.Seq.DefaultCellStyle = dataGridViewCellStyle5;
            this.Seq.Name = "Seq";
            this.Seq.ReadOnly = true;
            this.Seq.Visible = false;
            this.Seq.Width = 50;
            // 
            // lblChanges
            // 
            this.lblChanges.AutoSize = true;
            this.lblChanges.ExcludeFromUniqueId = false;
            this.lblChanges.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblChanges.Location = new System.Drawing.Point(0, 229);
            this.lblChanges.Name = "lblChanges";
            this.lblChanges.NextFocusId = ((long)(0));
            this.lblChanges.PerformLayoutEnabled = true;
            this.lblChanges.PreviousFocusId = ((long)(0));
            this.lblChanges.Size = new System.Drawing.Size(35, 13);
            this.lblChanges.TabIndex = 1;
            this.lblChanges.Text = "Changes";
            // 
            // btnExit
            // 
            this.btnExit.ExcludeFromUniqueId = false;
            this.btnExit.Location = new System.Drawing.Point(435, 396);
            this.btnExit.Name = "btnExit";
            this.btnExit.NextFocusId = ((long)(0));
            this.btnExit.PerformLayoutEnabled = true;
            this.btnExit.PreviousFocusId = ((long)(0));
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // dataGridChangeFieds
            // 
            this.dataGridChangeFieds.AllowUserToAddRows = false;
            this.dataGridChangeFieds.AllowUserToDeleteRows = false;
            this.dataGridChangeFieds.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.FormatProvider = new System.Globalization.CultureInfo("en-US");
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.dataGridChangeFieds.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridChangeFieds.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridChangeFieds.Columns.AddRange(new Gizmox.WebGUI.Forms.DataGridViewColumn[] {
            this.Field,
            this.OldValue,
            this.NewValue});
            this.dataGridChangeFieds.ExcludeFromUniqueId = false;
            this.dataGridChangeFieds.ItemsPerPage = 50;
            this.dataGridChangeFieds.Location = new System.Drawing.Point(3, 248);
            this.dataGridChangeFieds.Name = "dataGridChangeFieds";
            this.dataGridChangeFieds.NextFocusId = ((long)(0));
            this.dataGridChangeFieds.PerformLayoutEnabled = true;
            this.dataGridChangeFieds.PreviousFocusId = ((long)(0));
            this.dataGridChangeFieds.RenderCellPanelsAsText = false;
            this.dataGridChangeFieds.RowHeadersWidth = 15;
            this.dataGridChangeFieds.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("en-IN");
            this.dataGridChangeFieds.RowTemplate.Enabled = true;
            this.dataGridChangeFieds.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical;
            this.dataGridChangeFieds.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridChangeFieds.Size = new System.Drawing.Size(507, 146);
            this.dataGridChangeFieds.TabIndex = 0;
            this.dataGridChangeFieds.Click += new System.EventHandler(this.dataGridChangeFieds_Click);
            // 
            // Field
            // 
            this.Field.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Field.DefaultCellStyle = dataGridViewCellStyle11;
            this.Field.Name = "Field";
            this.Field.ReadOnly = true;
            this.Field.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.False;
            this.Field.Width = 150;
            // 
            // OldValue
            // 
            this.OldValue.DefaultCellStyle = dataGridViewCellStyle12;
            this.OldValue.Name = "OldValue";
            this.OldValue.ReadOnly = true;
            this.OldValue.Width = 175;
            // 
            // NewValue
            // 
            this.NewValue.DefaultCellStyle = dataGridViewCellStyle13;
            this.NewValue.Name = "NewValue";
            this.NewValue.ReadOnly = true;
            this.NewValue.Width = 175;
            // 
            // gvtVendor
            // 
            this.gvtVendor.DefaultCellStyle = dataGridViewCellStyle6;
            this.gvtVendor.HeaderText = "Vendor Name";
            this.gvtVendor.Name = "gvtVendor";
            this.gvtVendor.Width = 200;
            // 
            // gvtInvdate
            // 
            this.gvtInvdate.DefaultCellStyle = dataGridViewCellStyle7;
            this.gvtInvdate.HeaderText = "Inv Date";
            this.gvtInvdate.Name = "gvtInvdate";
            this.gvtInvdate.Width = 80;
            // 
            // gvtAmount
            // 
            dataGridViewCellStyle8.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.FormatProvider = new System.Globalization.CultureInfo("en-IN");
            this.gvtAmount.DefaultCellStyle = dataGridViewCellStyle8;
            this.gvtAmount.HeaderText = "Amount";
            this.gvtAmount.Name = "gvtAmount";
            this.gvtAmount.Width = 75;
            // 
            // gvtdetails
            // 
            this.gvtdetails.DefaultCellStyle = dataGridViewCellStyle9;
            this.gvtdetails.HeaderText = "details";
            this.gvtdetails.Name = "gvtdetails";
            this.gvtdetails.Visible = false;
            // 
            // HistoryForm
            // 
            this.Controls.Add(this.dataGridChangeFieds);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblChanges);
            this.Controls.Add(this.dataGridHistory);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(516, 422);
            this.Text = "History";
            this.Load += new System.EventHandler(this.HistoryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridChangeFieds)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dataGridHistory;
        private DataGridViewTextBoxColumn DateTime;
        private DataGridViewTextBoxColumn ChangedBy;
        private DataGridViewTextBoxColumn Seq;
        private Label lblChanges;
        private Button btnExit;
        private DataGridView dataGridChangeFieds;
        private DataGridViewTextBoxColumn Field;
        private DataGridViewTextBoxColumn OldValue;
        private DataGridViewTextBoxColumn NewValue;
        private DataGridViewTextBoxColumn gvtSubscr;
        private DataGridViewTextBoxColumn gvtVendor;
        private DataGridViewTextBoxColumn gvtInvdate;
        private DataGridViewTextBoxColumn gvtAmount;
        private DataGridViewTextBoxColumn gvtdetails;
    }
}