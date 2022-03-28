using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Captain.Common.Views.UserControls
{
    partial class ApplicationDetailsControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApplicationDetailsControl));
            this.dataGridAppNo = new Gizmox.WebGUI.Forms.DataGridView();
            this.MainName = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DOB = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.SuspendLayout();
            // 
            // dataGridAppNo
            // 
            this.dataGridAppNo.AllowUserToAddRows = false;
            this.dataGridAppNo.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridAppNo.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.White);
            this.dataGridAppNo.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.FormatProvider = new System.Globalization.CultureInfo("en-US");
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.dataGridAppNo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridAppNo.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridAppNo.ColumnHeadersVisible = false;
            this.dataGridAppNo.Columns.AddRange(new Gizmox.WebGUI.Forms.DataGridViewColumn[] {
            this.MainName,
            this.DOB});
            this.dataGridAppNo.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.dataGridAppNo.ItemsPerPage = 100;
            this.dataGridAppNo.Location = new System.Drawing.Point(0, 0);
            this.dataGridAppNo.MultiSelect = false;
            this.dataGridAppNo.Name = "dataGridAppNo";
            this.dataGridAppNo.RowHeadersVisible = false;
            this.dataGridAppNo.RowHeadersWidth = 14;
            this.dataGridAppNo.RowHeadersWidthSizeMode = Gizmox.WebGUI.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridAppNo.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("en-IN");
            this.dataGridAppNo.RowTemplate.Height = 19;
            this.dataGridAppNo.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical;
            this.dataGridAppNo.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridAppNo.Size = new System.Drawing.Size(232, 77);
            this.dataGridAppNo.TabIndex = 6;
            this.dataGridAppNo.VirtualBlockSize = 15;
            this.dataGridAppNo.Visible = false;
            // 
            // MainName
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.FormatProvider = new System.Globalization.CultureInfo("en-US");
            this.MainName.DefaultCellStyle = dataGridViewCellStyle2;
            this.MainName.HeaderText = "Name";
            this.MainName.MinimumWidth = 155;
            this.MainName.Name = "MainName";
            this.MainName.ReadOnly = true;
            this.MainName.Width = 155;
            // 
            // DOB
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.FormatProvider = new System.Globalization.CultureInfo("en-US");
            this.DOB.DefaultCellStyle = dataGridViewCellStyle3;
            this.DOB.HeaderText = "DOB";
            this.DOB.MinimumWidth = 10;
            this.DOB.Name = "DOB";
            this.DOB.ReadOnly = true;
            this.DOB.Width = 60;
            // 
            // ApplicationDetailsControl
            // 
            this.BackgroundImage = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("$this.BackgroundImage"));
            this.Controls.Add(this.dataGridAppNo);
            this.Size = new System.Drawing.Size(229, 77);
            this.Text = "ApplicationDetailsControl";
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridViewTextBoxColumn MainName;
        private DataGridViewTextBoxColumn DOB;
        public DataGridView dataGridAppNo;


    }
}