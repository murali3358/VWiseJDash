using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Captain.Common.Views.Forms
{
    partial class HierarchieSelectionFormNew
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
            this.lblChoose = new Gizmox.WebGUI.Forms.Label();
            this.dataGridViewCheckBoxColumn1 = new Gizmox.WebGUI.Forms.DataGridViewCheckBoxColumn();
            this.lblSelected = new Gizmox.WebGUI.Forms.Label();
            this.btnCancel = new Gizmox.WebGUI.Forms.Button();
            this.cellDesc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.gvwHierarchie = new Gizmox.WebGUI.Forms.DataGridView();
            this.Item = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.CellCode = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.gvwSelectedHierarachies = new Gizmox.WebGUI.Forms.DataGridView();
            this.btnOk = new Gizmox.WebGUI.Forms.Button();
            this.SuspendLayout();
            // 
            // lblChoose
            // 
            this.lblChoose.AutoSize = true;
            this.lblChoose.Location = new System.Drawing.Point(6, 148);
            this.lblChoose.Name = "lblChoose";
            this.lblChoose.Size = new System.Drawing.Size(35, 13);
            this.lblChoose.TabIndex = 5;
            this.lblChoose.Text = "Choose Hierarchies Here";
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.dataGridViewCheckBoxColumn1.HeaderText = "Select";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Width = 50;
            // 
            // lblSelected
            // 
            this.lblSelected.AutoSize = true;
            this.lblSelected.Location = new System.Drawing.Point(8, 5);
            this.lblSelected.Name = "lblSelected";
            this.lblSelected.Size = new System.Drawing.Size(35, 13);
            this.lblSelected.TabIndex = 4;
            this.lblSelected.Text = "Selected Hierarchies";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(348, 374);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(73, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.OnCancelClick);
            // 
            // cellDesc
            // 
            this.cellDesc.HeaderText = "Description";
            this.cellDesc.Name = "cellDesc";
            this.cellDesc.ReadOnly = true;
            this.cellDesc.Width = 335;
            // 
            // gvwHierarchie
            // 
            this.gvwHierarchie.AllowUserToAddRows = false;
            this.gvwHierarchie.AllowUserToDeleteRows = false;
            this.gvwHierarchie.AllowUserToResizeRows = false;
            this.gvwHierarchie.BackgroundColor = System.Drawing.Color.White;
            this.gvwHierarchie.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            dataGridViewCellStyle1.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.FormatProvider = new System.Globalization.CultureInfo("en-IN");
            dataGridViewCellStyle1.Padding = new Gizmox.WebGUI.Forms.Padding(2, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.gvwHierarchie.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvwHierarchie.Columns.AddRange(new Gizmox.WebGUI.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1,
            this.Item});
            this.gvwHierarchie.ItemsPerPage = 100;
            this.gvwHierarchie.Location = new System.Drawing.Point(5, 166);
            this.gvwHierarchie.MultiSelect = false;
            this.gvwHierarchie.Name = "gvwHierarchie";
            this.gvwHierarchie.RowHeadersVisible = false;
            this.gvwHierarchie.RowHeadersWidth = 15;
            this.gvwHierarchie.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("en-IN");
            this.gvwHierarchie.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical;
            this.gvwHierarchie.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvwHierarchie.Size = new System.Drawing.Size(413, 201);
            this.gvwHierarchie.TabIndex = 0;
            // 
            // Item
            // 
            this.Item.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.Item.HeaderText = "Item";
            this.Item.Name = "Item";
            this.Item.ReadOnly = true;
            this.Item.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.Item.Width = 320;
            // 
            // CellCode
            // 
            this.CellCode.HeaderText = "Code";
            this.CellCode.Name = "CellCode";
            this.CellCode.ReadOnly = true;
            this.CellCode.Width = 70;
            // 
            // gvwSelectedHierarachies
            // 
            this.gvwSelectedHierarachies.AllowUserToAddRows = false;
            this.gvwSelectedHierarachies.AllowUserToDeleteRows = false;
            this.gvwSelectedHierarachies.AllowUserToResizeColumns = false;
            this.gvwSelectedHierarachies.AllowUserToResizeRows = false;
            this.gvwSelectedHierarachies.BackgroundColor = System.Drawing.Color.White;
            this.gvwSelectedHierarachies.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            dataGridViewCellStyle2.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.FormatProvider = new System.Globalization.CultureInfo("en-IN");
            dataGridViewCellStyle2.Padding = new Gizmox.WebGUI.Forms.Padding(2, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.gvwSelectedHierarachies.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gvwSelectedHierarachies.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvwSelectedHierarachies.Columns.AddRange(new Gizmox.WebGUI.Forms.DataGridViewColumn[] {
            this.CellCode,
            this.cellDesc});
            this.gvwSelectedHierarachies.Location = new System.Drawing.Point(5, 24);
            this.gvwSelectedHierarachies.Name = "gvwSelectedHierarachies";
            this.gvwSelectedHierarachies.ReadOnly = true;
            this.gvwSelectedHierarachies.RowHeadersVisible = false;
            this.gvwSelectedHierarachies.RowHeadersWidth = 15;
            this.gvwSelectedHierarachies.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("en-IN");
            this.gvwSelectedHierarachies.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical;
            this.gvwSelectedHierarachies.Size = new System.Drawing.Size(413, 120);
            this.gvwSelectedHierarachies.TabIndex = 3;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(269, 374);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(73, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Ok";
            this.btnOk.Click += new System.EventHandler(this.OnOkClick);
            // 
            // HierarchieSelectionFormNew
            // 
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.gvwSelectedHierarachies);
            this.Controls.Add(this.gvwHierarchie);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblSelected);
            this.Controls.Add(this.lblChoose);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(435, 402);
            this.Text = "Hierarchy Selection";
            this.ResumeLayout(false);

        }

        #endregion

        private Label lblChoose;
        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private Label lblSelected;
        private Button btnCancel;
        private DataGridViewTextBoxColumn cellDesc;
        private DataGridView gvwHierarchie;
        private DataGridViewTextBoxColumn Item;
        private DataGridViewTextBoxColumn CellCode;
        private DataGridView gvwSelectedHierarachies;
        private Button btnOk;


    }
}