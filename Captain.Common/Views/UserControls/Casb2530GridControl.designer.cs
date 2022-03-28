using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Captain.Common.Views.UserControls
{
    partial class Casb2530GridControl
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

        #region Visual WebGui UserControl Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.gvwPoints = new Gizmox.WebGUI.Forms.DataGridView();
            this.gvtFldName = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.gvtDesc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.gvtPoints = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvwPoints)).BeginInit();
            this.SuspendLayout();
            // 
            // gvwPoints
            // 
            this.gvwPoints.AllowUserToAddRows = false;
            this.gvwPoints.AllowUserToDeleteRows = false;
            this.gvwPoints.AllowUserToResizeColumns = false;
            this.gvwPoints.AllowUserToResizeRows = false;
            this.gvwPoints.BackgroundColor = System.Drawing.Color.White;
            this.gvwPoints.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.None;
            this.gvwPoints.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvwPoints.Columns.AddRange(new Gizmox.WebGUI.Forms.DataGridViewColumn[] {
            this.gvtFldName,
            this.gvtDesc,
            this.gvtPoints});
            this.gvwPoints.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.gvwPoints.ItemsPerPage = 200;
            this.gvwPoints.Location = new System.Drawing.Point(0, 0);
            this.gvwPoints.MultiSelect = false;
            this.gvwPoints.Name = "gvwPoints";
            this.gvwPoints.ReadOnly = true;
            this.gvwPoints.RowHeadersWidth = 5;
            this.gvwPoints.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("en-US");
            this.gvwPoints.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical;
            this.gvwPoints.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvwPoints.Size = new System.Drawing.Size(339, 129);
            this.gvwPoints.TabIndex = 0;
            // 
            // gvtFldName
            // 
            this.gvtFldName.DefaultCellStyle = dataGridViewCellStyle1;
            this.gvtFldName.HeaderText = "Desc";
            this.gvtFldName.Name = "gvtFldName";
            this.gvtFldName.ReadOnly = true;
            this.gvtFldName.Width = 330;
            // 
            // gvtDesc
            // 
            this.gvtDesc.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvtDesc.HeaderText = "Relation";
            this.gvtDesc.Name = "gvtDesc";
            this.gvtDesc.ReadOnly = true;
            this.gvtDesc.Width = 75;
            // 
            // gvtPoints
            // 
            dataGridViewCellStyle3.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.FormatProvider = new System.Globalization.CultureInfo("en-US");
            this.gvtPoints.DefaultCellStyle = dataGridViewCellStyle3;
            this.gvtPoints.HeaderText = "Points";
            this.gvtPoints.Name = "gvtPoints";
            this.gvtPoints.ReadOnly = true;
            this.gvtPoints.Width = 50;
            // 
            // Casb2530GridControl
            // 
            this.Controls.Add(this.gvwPoints);
            this.Size = new System.Drawing.Size(500, 129);
            this.Text = "Casb2530GridControl";
            ((System.ComponentModel.ISupportInitialize)(this.gvwPoints)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView gvwPoints;
        private DataGridViewTextBoxColumn gvtFldName;
        private DataGridViewTextBoxColumn gvtDesc;
        private DataGridViewTextBoxColumn gvtPoints;


    }
}