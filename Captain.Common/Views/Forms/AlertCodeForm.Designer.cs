using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Captain.Common.Views.Forms
{
    partial class AlertCodeForm
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
            this.gvwAlertCode = new Gizmox.WebGUI.Forms.DataGridView();
            this.Select = new Gizmox.WebGUI.Forms.DataGridViewCheckBoxColumn();
            this.Item = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.AlertCode = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.btnOk = new Gizmox.WebGUI.Forms.Button();
            this.btnClose = new Gizmox.WebGUI.Forms.Button();
            this.gvtInterval = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvwAlertCode)).BeginInit();
            this.SuspendLayout();
            // 
            // gvwAlertCode
            // 
            this.gvwAlertCode.AllowUserToAddRows = false;
            this.gvwAlertCode.AllowUserToDeleteRows = false;
            this.gvwAlertCode.AllowUserToResizeRows = false;
            this.gvwAlertCode.BackgroundColor = System.Drawing.Color.White;
            this.gvwAlertCode.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            dataGridViewCellStyle1.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.FormatProvider = new System.Globalization.CultureInfo("en-IN");
            dataGridViewCellStyle1.Padding = new Gizmox.WebGUI.Forms.Padding(2, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.gvwAlertCode.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvwAlertCode.Columns.AddRange(new Gizmox.WebGUI.Forms.DataGridViewColumn[] {
            this.Select,
            this.Item,
            this.AlertCode,
            this.gvtInterval});
            this.gvwAlertCode.ItemsPerPage = 100;
            this.gvwAlertCode.Location = new System.Drawing.Point(6, 4);
            this.gvwAlertCode.MultiSelect = false;
            this.gvwAlertCode.Name = "gvwAlertCode";
            this.gvwAlertCode.RowHeadersVisible = false;
            this.gvwAlertCode.RowHeadersWidth = 15;
            this.gvwAlertCode.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("en-IN");
            this.gvwAlertCode.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical;
            this.gvwAlertCode.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvwAlertCode.Size = new System.Drawing.Size(345, 204);
            this.gvwAlertCode.TabIndex = 0;
            this.gvwAlertCode.CellClick += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.gvwAlertCode_CellClick);
            // 
            // Select
            // 
            this.Select.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.Select.HeaderText = "  ";
            this.Select.Name = "Select";
            this.Select.Width = 25;
            // 
            // Item
            // 
            this.Item.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.Item.HeaderText = "Income Types";
            this.Item.Name = "Item";
            this.Item.ReadOnly = true;
            this.Item.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.Item.Width = 200;
            // 
            // AlertCode
            // 
            this.AlertCode.Name = "AlertCode";
            this.AlertCode.Visible = false;
            this.AlertCode.Width = 50;
            // 
            // btnOk
            // 
            this.btnOk.Enabled = false;
            this.btnOk.Location = new System.Drawing.Point(245, 210);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(49, 23);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "OK";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(302, 210);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(49, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // gvtInterval
            // 
            this.gvtInterval.HeaderText = "Interval";
            this.gvtInterval.Name = "gvtInterval";
            this.gvtInterval.ReadOnly = true;
            // 
            // AlertCodeForm
            // 
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.gvwAlertCode);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(360, 234);
            this.Text = "Alert Codes";
            ((System.ComponentModel.ISupportInitialize)(this.gvwAlertCode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView gvwAlertCode;
        private DataGridViewCheckBoxColumn Select;
        private DataGridViewTextBoxColumn Item;
        private DataGridViewTextBoxColumn AlertCode;
        private Button btnOk;
        private Button btnClose;
        private DataGridViewTextBoxColumn gvtInterval;


    }
}