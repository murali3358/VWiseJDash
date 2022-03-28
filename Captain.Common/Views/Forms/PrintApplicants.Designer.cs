using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Captain.Common.Views.Forms
{
    partial class PrintApplicants
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
            this.lblName = new Gizmox.WebGUI.Forms.Label();
            this.lblAppNo = new Gizmox.WebGUI.Forms.Label();
            this.lblN = new Gizmox.WebGUI.Forms.Label();
            this.lblApp = new Gizmox.WebGUI.Forms.Label();
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.gvApp = new Gizmox.WebGUI.Forms.DataGridView();
            this.Check = new Gizmox.WebGUI.Forms.DataGridViewCheckBoxColumn();
            this.AppDet = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.btnPrev = new Gizmox.WebGUI.Forms.Button();
            this.btnExit = new Gizmox.WebGUI.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvApp)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Black);
            this.panel1.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Controls.Add(this.lblAppNo);
            this.panel1.Controls.Add(this.lblN);
            this.panel1.Controls.Add(this.lblApp);
            this.panel1.Location = new System.Drawing.Point(1, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(306, 56);
            this.panel1.TabIndex = 0;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(60, 33);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // lblAppNo
            // 
            this.lblAppNo.AutoSize = true;
            this.lblAppNo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppNo.Location = new System.Drawing.Point(60, 8);
            this.lblAppNo.Name = "lblAppNo";
            this.lblAppNo.Size = new System.Drawing.Size(35, 13);
            this.lblAppNo.TabIndex = 0;
            this.lblAppNo.Text = "App#";
            // 
            // lblN
            // 
            this.lblN.AutoSize = true;
            this.lblN.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblN.Location = new System.Drawing.Point(8, 33);
            this.lblN.Name = "lblN";
            this.lblN.Size = new System.Drawing.Size(35, 13);
            this.lblN.TabIndex = 0;
            this.lblN.Text = "Name :";
            // 
            // lblApp
            // 
            this.lblApp.AutoSize = true;
            this.lblApp.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApp.Location = new System.Drawing.Point(8, 8);
            this.lblApp.Name = "lblApp";
            this.lblApp.Size = new System.Drawing.Size(35, 13);
            this.lblApp.TabIndex = 0;
            this.lblApp.Text = "App# :";
            // 
            // panel2
            // 
            this.panel2.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Black);
            this.panel2.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.gvApp);
            this.panel2.Location = new System.Drawing.Point(1, 58);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(306, 165);
            this.panel2.TabIndex = 1;
            // 
            // gvApp
            // 
            this.gvApp.AllowUserToAddRows = false;
            this.gvApp.AllowUserToDeleteRows = false;
            this.gvApp.BackgroundColor = System.Drawing.Color.White;
            this.gvApp.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Transparent);
            this.gvApp.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            dataGridViewCellStyle1.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.FormatProvider = new System.Globalization.CultureInfo("en-IN");
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.gvApp.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvApp.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvApp.ColumnHeadersVisible = false;
            this.gvApp.Columns.AddRange(new Gizmox.WebGUI.Forms.DataGridViewColumn[] {
            this.Check,
            this.AppDet});
            this.gvApp.Location = new System.Drawing.Point(1, 1);
            this.gvApp.Name = "gvApp";
            this.gvApp.RowHeadersVisible = false;
            this.gvApp.RowHeadersWidth = 25;
            this.gvApp.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("en-US");
            this.gvApp.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvApp.Size = new System.Drawing.Size(301, 161);
            this.gvApp.TabIndex = 0;
            this.gvApp.CellClick += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.gvApp_CellClick);
            this.gvApp.CellValueChanged += new Gizmox.WebGUI.Forms.DataGridViewCellEventHandler(this.gvApp_CellValueChanged);
            // 
            // Check
            // 
            dataGridViewCellStyle2.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = false;
            this.Check.DefaultCellStyle = dataGridViewCellStyle2;
            this.Check.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.Check.HeaderText = " ";
            this.Check.Name = "Check";
            this.Check.Width = 30;
            // 
            // AppDet
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.FormatProvider = new System.Globalization.CultureInfo("en-IN");
            this.AppDet.DefaultCellStyle = dataGridViewCellStyle3;
            this.AppDet.HeaderText = "Application Details";
            this.AppDet.Name = "AppDet";
            this.AppDet.ReadOnly = true;
            this.AppDet.Width = 265;
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(191, 224);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(59, 25);
            this.btnPrev.TabIndex = 2;
            this.btnPrev.Text = "Pre&view";
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(249, 224);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(57, 25);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.button1_Click);
            // 
            // PrintApplicants
            // 
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(308, 249);
            this.Text = "PrintApplicants";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvApp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Label lblName;
        private Label lblAppNo;
        private Label lblN;
        private Label lblApp;
        private Panel panel2;
        private DataGridView gvApp;
        private DataGridViewCheckBoxColumn Check;
        private DataGridViewTextBoxColumn AppDet;
        private Button btnPrev;
        private Button btnExit;


    }
}