using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Captain.Common.Views.Forms
{
    partial class VoterSerachForm
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
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.lblTotal = new Gizmox.WebGUI.Forms.Label();
            this.btnSelect = new Gizmox.WebGUI.Forms.Button();
            this.gvwvoters = new Gizmox.WebGUI.Forms.DataGridView();
            this.gvtBlock = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.gvtEo = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.gvtCity = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.gvtDirection = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.gvtStreet = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.gvtSuffix = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.gvtPreint = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.onSearch = new Gizmox.WebGUI.Forms.Button();
            this.txtCity = new Gizmox.WebGUI.Forms.TextBox();
            this.cmbstreet = new Gizmox.WebGUI.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvwvoters)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTotal);
            this.panel1.Controls.Add(this.btnSelect);
            this.panel1.Controls.Add(this.gvwvoters);
            this.panel1.Controls.Add(this.onSearch);
            this.panel1.Controls.Add(this.txtCity);
            this.panel1.Controls.Add(this.cmbstreet);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(494, 291);
            this.panel1.TabIndex = 0;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(9, 266);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(49, 13);
            this.lblTotal.TabIndex = 1;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(405, 262);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(83, 22);
            this.btnSelect.TabIndex = 11;
            this.btnSelect.Text = "Select";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // gvwvoters
            // 
            this.gvwvoters.AllowUserToAddRows = false;
            this.gvwvoters.AllowUserToDeleteRows = false;
            this.gvwvoters.AllowUserToResizeColumns = false;
            this.gvwvoters.AllowUserToResizeRows = false;
            this.gvwvoters.BackgroundColor = System.Drawing.Color.White;
            this.gvwvoters.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            dataGridViewCellStyle1.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.FormatProvider = new System.Globalization.CultureInfo("en-US");
            dataGridViewCellStyle1.Padding = new Gizmox.WebGUI.Forms.Padding(4, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.gvwvoters.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvwvoters.Columns.AddRange(new Gizmox.WebGUI.Forms.DataGridViewColumn[] {
            this.gvtBlock,
            this.gvtEo,
            this.gvtCity,
            this.gvtDirection,
            this.gvtStreet,
            this.gvtSuffix,
            this.gvtPreint});
            this.gvwvoters.ItemsPerPage = 500;
            this.gvwvoters.Location = new System.Drawing.Point(9, 47);
            this.gvwvoters.MultiSelect = false;
            this.gvwvoters.Name = "gvwvoters";
            this.gvwvoters.ReadOnly = true;
            this.gvwvoters.RowHeadersWidth = 10;
            this.gvwvoters.RowHeadersWidthSizeMode = Gizmox.WebGUI.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gvwvoters.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("en-IN");
            this.gvwvoters.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical;
            this.gvwvoters.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvwvoters.Size = new System.Drawing.Size(477, 206);
            this.gvwvoters.StandardTab = true;
            this.gvwvoters.TabIndex = 6;
            this.gvwvoters.VirtualBlockSize = 15;
            // 
            // gvtBlock
            // 
            this.gvtBlock.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvtBlock.HeaderText = "Block";
            this.gvtBlock.Name = "gvtBlock";
            this.gvtBlock.ReadOnly = true;
            this.gvtBlock.Width = 60;
            // 
            // gvtEo
            // 
            this.gvtEo.DefaultCellStyle = dataGridViewCellStyle3;
            this.gvtEo.HeaderText = "  ";
            this.gvtEo.Name = "gvtEo";
            this.gvtEo.ReadOnly = true;
            this.gvtEo.Width = 15;
            // 
            // gvtCity
            // 
            this.gvtCity.DefaultCellStyle = dataGridViewCellStyle4;
            this.gvtCity.HeaderText = "City";
            this.gvtCity.Name = "gvtCity";
            this.gvtCity.ReadOnly = true;
            // 
            // gvtDirection
            // 
            this.gvtDirection.DefaultCellStyle = dataGridViewCellStyle5;
            this.gvtDirection.HeaderText = "Direction";
            this.gvtDirection.Name = "gvtDirection";
            this.gvtDirection.ReadOnly = true;
            this.gvtDirection.Width = 80;
            // 
            // gvtStreet
            // 
            this.gvtStreet.DefaultCellStyle = dataGridViewCellStyle6;
            this.gvtStreet.HeaderText = "Street";
            this.gvtStreet.Name = "gvtStreet";
            this.gvtStreet.ReadOnly = true;
            // 
            // gvtSuffix
            // 
            this.gvtSuffix.DefaultCellStyle = dataGridViewCellStyle7;
            this.gvtSuffix.HeaderText = "Suffix";
            this.gvtSuffix.Name = "gvtSuffix";
            this.gvtSuffix.ReadOnly = true;
            this.gvtSuffix.Width = 40;
            // 
            // gvtPreint
            // 
            this.gvtPreint.DefaultCellStyle = dataGridViewCellStyle8;
            this.gvtPreint.HeaderText = "Precinct";
            this.gvtPreint.Name = "gvtPreint";
            this.gvtPreint.ReadOnly = true;
            this.gvtPreint.Width = 53;
            // 
            // onSearch
            // 
            this.onSearch.Location = new System.Drawing.Point(405, 9);
            this.onSearch.Name = "onSearch";
            this.onSearch.Size = new System.Drawing.Size(81, 23);
            this.onSearch.TabIndex = 5;
            this.onSearch.Text = "Search";
            this.onSearch.Click += new System.EventHandler(this.onSearch_Click);
            // 
            // txtCity
            // 
            this.txtCity.CharacterCasing = Gizmox.WebGUI.Forms.CharacterCasing.Upper;
            this.txtCity.Location = new System.Drawing.Point(165, 9);
            this.txtCity.MaxLength = 30;
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(196, 21);
            this.txtCity.TabIndex = 2;
            // 
            // cmbstreet
            // 
            this.cmbstreet.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cmbstreet.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cmbstreet.FormattingEnabled = true;
            this.cmbstreet.Location = new System.Drawing.Point(9, 9);
            this.cmbstreet.Name = "cmbstreet";
            this.cmbstreet.Size = new System.Drawing.Size(140, 21);
            this.cmbstreet.TabIndex = 3;
            // 
            // VoterSerachForm
            // 
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(494, 288);
            this.Text = "Voter Registration Street Lookup";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvwvoters)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private ComboBox cmbstreet;
        private TextBox txtCity;
        private Button onSearch;
        private DataGridView gvwvoters;
        private Button btnSelect;
        private Label lblTotal;
        private DataGridViewTextBoxColumn gvtBlock;
        private DataGridViewTextBoxColumn gvtEo;
        private DataGridViewTextBoxColumn gvtCity;
        private DataGridViewTextBoxColumn gvtDirection;
        private DataGridViewTextBoxColumn gvtStreet;
        private DataGridViewTextBoxColumn gvtSuffix;
        private DataGridViewTextBoxColumn gvtPreint;


    }
}