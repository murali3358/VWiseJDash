using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Captain.Common.Views.Forms
{
    partial class CaseIncomeTypesForm
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.gvtInterval = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.Item = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new Gizmox.WebGUI.Forms.Button();
            this.Select = new Gizmox.WebGUI.Forms.DataGridViewCheckBoxColumn();
            this.btnOk = new Gizmox.WebGUI.Forms.Button();
            this.gvwIncomeTypes = new Gizmox.WebGUI.Forms.DataGridView();
            this.AlertCode = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.contextMenu1 = new Gizmox.WebGUI.Forms.ContextMenu();
            ((System.ComponentModel.ISupportInitialize)(this.gvwIncomeTypes)).BeginInit();
            this.SuspendLayout();
            // 
            // gvtInterval
            // 
            this.gvtInterval.HeaderText = "Interval";
            this.gvtInterval.Name = "gvtInterval";
            this.gvtInterval.ReadOnly = true;
            // 
            // Item
            // 
            this.Item.ContextMenu = this.contextMenu1;
            this.Item.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.Item.HeaderText = "Income Types";
            this.Item.Name = "Item";
            this.Item.ReadOnly = true;
            this.Item.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.Item.Width = 200;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(299, 211);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(49, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            // 
            // Select
            // 
            this.Select.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.Select.HeaderText = "  ";
            this.Select.Name = "Select";
            this.Select.Width = 25;
            // 
            // btnOk
            // 
            this.btnOk.Enabled = false;
            this.btnOk.Location = new System.Drawing.Point(242, 211);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(49, 23);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "OK";
            // 
            // gvwIncomeTypes
            // 
            this.gvwIncomeTypes.AllowUserToAddRows = false;
            this.gvwIncomeTypes.AllowUserToDeleteRows = false;
            this.gvwIncomeTypes.AllowUserToResizeRows = false;
            this.gvwIncomeTypes.BackgroundColor = System.Drawing.Color.White;
            this.gvwIncomeTypes.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            dataGridViewCellStyle2.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.FormatProvider = new System.Globalization.CultureInfo("en-IN");
            dataGridViewCellStyle2.Padding = new Gizmox.WebGUI.Forms.Padding(2, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.gvwIncomeTypes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gvwIncomeTypes.Columns.AddRange(new Gizmox.WebGUI.Forms.DataGridViewColumn[] {
            this.Select,
            this.Item,
            this.AlertCode,
            this.gvtInterval});
            this.gvwIncomeTypes.ItemsPerPage = 100;
            this.gvwIncomeTypes.Location = new System.Drawing.Point(3, 5);
            this.gvwIncomeTypes.MultiSelect = false;
            this.gvwIncomeTypes.Name = "gvwIncomeTypes";
            this.gvwIncomeTypes.RowHeadersVisible = false;
            this.gvwIncomeTypes.RowHeadersWidth = 15;
            this.gvwIncomeTypes.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("en-IN");
            this.gvwIncomeTypes.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical;
            this.gvwIncomeTypes.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvwIncomeTypes.Size = new System.Drawing.Size(345, 204);
            this.gvwIncomeTypes.TabIndex = 0;
            this.gvwIncomeTypes.MenuClick += new Gizmox.WebGUI.Forms.MenuEventHandler(this.gvwIncomeTypes_MenuClick);
            // 
            // AlertCode
            // 
            this.AlertCode.Name = "AlertCode";
            this.AlertCode.Visible = false;
            this.AlertCode.Width = 50;
            // 
            // CaseIncomeTypesForm
            // 
            this.Controls.Add(this.gvwIncomeTypes);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(361, 241);
            this.Text = "CaseIncomeTypesForm";
            ((System.ComponentModel.ISupportInitialize)(this.gvwIncomeTypes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridViewTextBoxColumn gvtInterval;
        private DataGridViewTextBoxColumn Item;
        private Button btnClose;
        private DataGridViewCheckBoxColumn Select;
        private Button btnOk;
        private DataGridView gvwIncomeTypes;
        private DataGridViewTextBoxColumn AlertCode;
        private ContextMenu contextMenu1;


    }
}