using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Captain.Common.Views.Forms
{
    partial class CaseIncomeTotDetails
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
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.lbl3 = new Gizmox.WebGUI.Forms.Label();
            this.lbl2 = new Gizmox.WebGUI.Forms.Label();
            this.lbl1 = new Gizmox.WebGUI.Forms.Label();
            this.lblTotal = new Gizmox.WebGUI.Forms.Label();
            this.txtTotal = new Gizmox.WebGUI.Forms.TextBox();
            this.lblIntervalType = new Gizmox.WebGUI.Forms.Label();
            this.gvwIncomeDetails = new Gizmox.WebGUI.Forms.DataGridView();
            this.gvtInterval = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.gvtDate = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.gvtAmount = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new Gizmox.WebGUI.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvwIncomeDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.lblTotal);
            this.panel1.Controls.Add(this.txtTotal);
            this.panel1.Controls.Add(this.lblIntervalType);
            this.panel1.Controls.Add(this.gvwIncomeDetails);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(423, 423);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbl3);
            this.panel2.Controls.Add(this.lbl2);
            this.panel2.Controls.Add(this.lbl1);
            this.panel2.Location = new System.Drawing.Point(16, 315);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(318, 100);
            this.panel2.TabIndex = 11;
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lbl3.Location = new System.Drawing.Point(11, 61);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(35, 13);
            this.lbl3.TabIndex = 2;
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lbl2.Location = new System.Drawing.Point(11, 37);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(35, 13);
            this.lbl2.TabIndex = 1;
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lbl1.Location = new System.Drawing.Point(11, 11);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(35, 13);
            this.lbl1.TabIndex = 0;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(254, 282);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(35, 13);
            this.lblTotal.TabIndex = 10;
            this.lblTotal.Text = "Total";
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(308, 279);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(100, 20);
            this.txtTotal.TabIndex = 9;
            this.txtTotal.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            // 
            // lblIntervalType
            // 
            this.lblIntervalType.AutoSize = true;
            this.lblIntervalType.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblIntervalType.Location = new System.Drawing.Point(20, 15);
            this.lblIntervalType.Name = "lblIntervalType";
            this.lblIntervalType.Size = new System.Drawing.Size(35, 13);
            this.lblIntervalType.TabIndex = 8;
            this.lblIntervalType.Text = "..";
            // 
            // gvwIncomeDetails
            // 
            this.gvwIncomeDetails.AllowUserToAddRows = false;
            this.gvwIncomeDetails.AllowUserToDeleteRows = false;
            this.gvwIncomeDetails.AllowUserToResizeColumns = false;
            this.gvwIncomeDetails.AllowUserToResizeRows = false;
            this.gvwIncomeDetails.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.gvwIncomeDetails.Columns.AddRange(new Gizmox.WebGUI.Forms.DataGridViewColumn[] {
            this.gvtInterval,
            this.gvtDate,
            this.gvtAmount});
            this.gvwIncomeDetails.Location = new System.Drawing.Point(135, 15);
            this.gvwIncomeDetails.Name = "gvwIncomeDetails";
            this.gvwIncomeDetails.ReadOnly = true;
            this.gvwIncomeDetails.RowHeadersWidth = 14;
            this.gvwIncomeDetails.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical;
            this.gvwIncomeDetails.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvwIncomeDetails.Size = new System.Drawing.Size(276, 261);
            this.gvwIncomeDetails.TabIndex = 7;
            // 
            // gvtInterval
            // 
            this.gvtInterval.DefaultCellStyle = dataGridViewCellStyle1;
            this.gvtInterval.HeaderText = "Interval";
            this.gvtInterval.Name = "gvtInterval";
            this.gvtInterval.ReadOnly = true;
            this.gvtInterval.Width = 80;
            // 
            // gvtDate
            // 
            this.gvtDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvtDate.HeaderText = "Date";
            this.gvtDate.Name = "gvtDate";
            this.gvtDate.ReadOnly = true;
            this.gvtDate.Width = 80;
            // 
            // gvtAmount
            // 
            dataGridViewCellStyle3.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.FormatProvider = new System.Globalization.CultureInfo("en-IN");
            this.gvtAmount.DefaultCellStyle = dataGridViewCellStyle3;
            this.gvtAmount.HeaderText = "Amount";
            this.gvtAmount.Name = "gvtAmount";
            this.gvtAmount.ReadOnly = true;
            this.gvtAmount.Width = 85;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(348, 392);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(60, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // CaseIncomeTotDetails
            // 
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(423, 423);
            this.Text = "CaseIncomeTotDetails";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvwIncomeDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Label lblTotal;
        private TextBox txtTotal;
        private Label lblIntervalType;
        private DataGridView gvwIncomeDetails;
        private DataGridViewTextBoxColumn gvtInterval;
        private DataGridViewTextBoxColumn gvtAmount;
        private Button btnClose;
        private DataGridViewTextBoxColumn gvtDate;
        private Panel panel2;
        private Label lbl3;
        private Label lbl2;
        private Label lbl1;


    }
}