using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Captain.Common.Views.Forms
{
    partial class ProgressNotes_Form
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
            this.panel5 = new Gizmox.WebGUI.Forms.Panel();
            this.panel8 = new Gizmox.WebGUI.Forms.Panel();
            this.Btn_Close = new Gizmox.WebGUI.Forms.Button();
            this.btnAdd = new Gizmox.WebGUI.Forms.Button();
            this.Btn_Cancel = new Gizmox.WebGUI.Forms.Button();
            this.Btn_Save = new Gizmox.WebGUI.Forms.Button();
            this.panel4 = new Gizmox.WebGUI.Forms.Panel();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.Txt_ProgEdit = new Gizmox.WebGUI.Forms.TextBox();
            this.panel6 = new Gizmox.WebGUI.Forms.Panel();
            this.panel7 = new Gizmox.WebGUI.Forms.Panel();
            this.Btn_Print = new Gizmox.WebGUI.Forms.Button();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.Txt_ProgText = new Gizmox.WebGUI.Forms.TextBox();
            this.LblApp_Name = new Gizmox.WebGUI.Forms.Label();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.LblAppNo = new Gizmox.WebGUI.Forms.Label();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.panel9 = new Gizmox.WebGUI.Forms.Panel();
            this.chkSelectAll = new Gizmox.WebGUI.Forms.CheckBox();
            this.pnlMain = new Gizmox.WebGUI.Forms.Panel();
            this.panel10 = new Gizmox.WebGUI.Forms.Panel();
            this.gvCA = new Gizmox.WebGUI.Forms.DataGridView();
            this.CA_Sel = new Gizmox.WebGUI.Forms.DataGridViewCheckBoxColumn();
            this.CA_Code = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.CA_Desc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.Notes_key = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.CAMS_Type = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.panel11 = new Gizmox.WebGUI.Forms.Panel();
            this.panel5.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel9.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCA)).BeginInit();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Black);
            this.panel5.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.panel8);
            this.panel5.Controls.Add(this.btnAdd);
            this.panel5.Controls.Add(this.Btn_Cancel);
            this.panel5.Controls.Add(this.Btn_Save);
            this.panel5.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.panel5.ExcludeFromUniqueId = false;
            this.panel5.Location = new System.Drawing.Point(0, 165);
            this.panel5.Name = "panel5";
            this.panel5.NextFocusId = ((long)(0));
            this.panel5.PerformLayoutEnabled = true;
            this.panel5.PreviousFocusId = ((long)(0));
            this.panel5.Size = new System.Drawing.Size(585, 34);
            this.panel5.TabIndex = 2;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.Btn_Close);
            this.panel8.Dock = Gizmox.WebGUI.Forms.DockStyle.Right;
            this.panel8.ExcludeFromUniqueId = false;
            this.panel8.Location = new System.Drawing.Point(451, 0);
            this.panel8.Name = "panel8";
            this.panel8.NextFocusId = ((long)(0));
            this.panel8.PerformLayoutEnabled = true;
            this.panel8.PreviousFocusId = ((long)(0));
            this.panel8.Size = new System.Drawing.Size(132, 32);
            this.panel8.TabIndex = 4;
            // 
            // Btn_Close
            // 
            this.Btn_Close.ExcludeFromUniqueId = false;
            this.Btn_Close.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Btn_Close.Location = new System.Drawing.Point(37, 2);
            this.Btn_Close.Name = "Btn_Close";
            this.Btn_Close.NextFocusId = ((long)(0));
            this.Btn_Close.PerformLayoutEnabled = true;
            this.Btn_Close.PreviousFocusId = ((long)(0));
            this.Btn_Close.Size = new System.Drawing.Size(80, 28);
            this.Btn_Close.TabIndex = 3;
            this.Btn_Close.Text = "Close";
            this.Btn_Close.Click += new System.EventHandler(this.Btn_Close_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.ExcludeFromUniqueId = false;
            this.btnAdd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnAdd.Location = new System.Drawing.Point(5, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.NextFocusId = ((long)(0));
            this.btnAdd.PerformLayoutEnabled = true;
            this.btnAdd.PreviousFocusId = ((long)(0));
            this.btnAdd.Size = new System.Drawing.Size(80, 28);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.ExcludeFromUniqueId = false;
            this.Btn_Cancel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Btn_Cancel.Location = new System.Drawing.Point(178, 2);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.NextFocusId = ((long)(0));
            this.Btn_Cancel.PerformLayoutEnabled = true;
            this.Btn_Cancel.PreviousFocusId = ((long)(0));
            this.Btn_Cancel.Size = new System.Drawing.Size(80, 28);
            this.Btn_Cancel.TabIndex = 2;
            this.Btn_Cancel.Text = "Cancel";
            this.Btn_Cancel.Visible = false;
            this.Btn_Cancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
            // 
            // Btn_Save
            // 
            this.Btn_Save.ExcludeFromUniqueId = false;
            this.Btn_Save.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Btn_Save.Location = new System.Drawing.Point(98, 2);
            this.Btn_Save.Name = "Btn_Save";
            this.Btn_Save.NextFocusId = ((long)(0));
            this.Btn_Save.PerformLayoutEnabled = true;
            this.Btn_Save.PreviousFocusId = ((long)(0));
            this.Btn_Save.Size = new System.Drawing.Size(80, 28);
            this.Btn_Save.TabIndex = 1;
            this.Btn_Save.Text = "Save";
            this.Btn_Save.Visible = false;
            this.Btn_Save.Click += new System.EventHandler(this.Btn_Save_Click);
            // 
            // panel4
            // 
            this.panel4.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Black);
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.panel4.ExcludeFromUniqueId = false;
            this.panel4.Location = new System.Drawing.Point(0, 265);
            this.panel4.Name = "panel4";
            this.panel4.NextFocusId = ((long)(0));
            this.panel4.PerformLayoutEnabled = true;
            this.panel4.PreviousFocusId = ((long)(0));
            this.panel4.Size = new System.Drawing.Size(585, 199);
            this.panel4.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Txt_ProgEdit);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.panel1.ExcludeFromUniqueId = false;
            this.panel1.Location = new System.Drawing.Point(0, 36);
            this.panel1.Name = "panel1";
            this.panel1.NextFocusId = ((long)(0));
            this.panel1.PerformLayoutEnabled = true;
            this.panel1.PreviousFocusId = ((long)(0));
            this.panel1.Size = new System.Drawing.Size(585, 129);
            this.panel1.TabIndex = 7;
            // 
            // Txt_ProgEdit
            // 
            this.Txt_ProgEdit.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.Txt_ProgEdit.ExcludeFromUniqueId = false;
            this.Txt_ProgEdit.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_ProgEdit.Location = new System.Drawing.Point(0, 0);
            this.Txt_ProgEdit.Multiline = true;
            this.Txt_ProgEdit.Name = "Txt_ProgEdit";
            this.Txt_ProgEdit.NextFocusId = ((long)(0));
            this.Txt_ProgEdit.PerformLayoutEnabled = true;
            this.Txt_ProgEdit.PreviousFocusId = ((long)(0));
            this.Txt_ProgEdit.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical;
            this.Txt_ProgEdit.Size = new System.Drawing.Size(585, 129);
            this.Txt_ProgEdit.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Controls.Add(this.label4);
            this.panel6.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel6.ExcludeFromUniqueId = false;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.NextFocusId = ((long)(0));
            this.panel6.PerformLayoutEnabled = true;
            this.panel6.PreviousFocusId = ((long)(0));
            this.panel6.Size = new System.Drawing.Size(585, 31);
            this.panel6.TabIndex = 6;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.Btn_Print);
            this.panel7.Dock = Gizmox.WebGUI.Forms.DockStyle.Right;
            this.panel7.ExcludeFromUniqueId = false;
            this.panel7.Location = new System.Drawing.Point(399, 0);
            this.panel7.Name = "panel7";
            this.panel7.NextFocusId = ((long)(0));
            this.panel7.PerformLayoutEnabled = true;
            this.panel7.PreviousFocusId = ((long)(0));
            this.panel7.Size = new System.Drawing.Size(186, 31);
            this.panel7.TabIndex = 1;
            // 
            // Btn_Print
            // 
            this.Btn_Print.ExcludeFromUniqueId = false;
            this.Btn_Print.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Btn_Print.Location = new System.Drawing.Point(95, 6);
            this.Btn_Print.Name = "Btn_Print";
            this.Btn_Print.NextFocusId = ((long)(0));
            this.Btn_Print.PerformLayoutEnabled = true;
            this.Btn_Print.PreviousFocusId = ((long)(0));
            this.Btn_Print.Size = new System.Drawing.Size(76, 26);
            this.Btn_Print.TabIndex = 5;
            this.Btn_Print.Text = "Print/View";
            this.Btn_Print.Click += new System.EventHandler(this.Btn_Print_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ExcludeFromUniqueId = false;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 6);
            this.label4.Name = "label4";
            this.label4.NextFocusId = ((long)(0));
            this.label4.PerformLayoutEnabled = true;
            this.label4.PreviousFocusId = ((long)(0));
            this.label4.Size = new System.Drawing.Size(222, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Enter New Progress Notes Here";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ExcludeFromUniqueId = false;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 5);
            this.label3.Name = "label3";
            this.label3.NextFocusId = ((long)(0));
            this.label3.PerformLayoutEnabled = true;
            this.label3.PreviousFocusId = ((long)(0));
            this.label3.Size = new System.Drawing.Size(86, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Older Posts";
            // 
            // Txt_ProgText
            // 
            this.Txt_ProgText.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.Txt_ProgText.ExcludeFromUniqueId = false;
            this.Txt_ProgText.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_ProgText.Location = new System.Drawing.Point(0, 25);
            this.Txt_ProgText.Multiline = true;
            this.Txt_ProgText.Name = "Txt_ProgText";
            this.Txt_ProgText.NextFocusId = ((long)(0));
            this.Txt_ProgText.PerformLayoutEnabled = true;
            this.Txt_ProgText.PreviousFocusId = ((long)(0));
            this.Txt_ProgText.ReadOnly = true;
            this.Txt_ProgText.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical;
            this.Txt_ProgText.Size = new System.Drawing.Size(585, 200);
            this.Txt_ProgText.TabIndex = 6;
            this.Txt_ProgText.TextChanged += new System.EventHandler(this.Txt_ProgText_TextChanged);
            // 
            // LblApp_Name
            // 
            this.LblApp_Name.AutoSize = true;
            this.LblApp_Name.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Transparent);
            this.LblApp_Name.ExcludeFromUniqueId = false;
            this.LblApp_Name.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold);
            this.LblApp_Name.Location = new System.Drawing.Point(239, 12);
            this.LblApp_Name.Name = "LblApp_Name";
            this.LblApp_Name.NextFocusId = ((long)(0));
            this.LblApp_Name.PerformLayoutEnabled = true;
            this.LblApp_Name.PreviousFocusId = ((long)(0));
            this.LblApp_Name.Size = new System.Drawing.Size(35, 13);
            this.LblApp_Name.TabIndex = 0;
            this.LblApp_Name.Text = "00000000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ExcludeFromUniqueId = false;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(138, 11);
            this.label2.Name = "label2";
            this.label2.NextFocusId = ((long)(0));
            this.label2.PerformLayoutEnabled = true;
            this.label2.PreviousFocusId = ((long)(0));
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Client Name";
            // 
            // LblAppNo
            // 
            this.LblAppNo.AutoSize = true;
            this.LblAppNo.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Transparent);
            this.LblAppNo.CausesValidation = false;
            this.LblAppNo.ExcludeFromUniqueId = false;
            this.LblAppNo.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold);
            this.LblAppNo.Location = new System.Drawing.Point(50, 11);
            this.LblAppNo.Name = "LblAppNo";
            this.LblAppNo.NextFocusId = ((long)(0));
            this.LblAppNo.PerformLayoutEnabled = true;
            this.LblAppNo.PreviousFocusId = ((long)(0));
            this.LblAppNo.Size = new System.Drawing.Size(35, 13);
            this.LblAppNo.TabIndex = 0;
            this.LblAppNo.Text = "00000000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ExcludeFromUniqueId = false;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(1, 11);
            this.label1.Name = "label1";
            this.label1.NextFocusId = ((long)(0));
            this.label1.PerformLayoutEnabled = true;
            this.label1.PreviousFocusId = ((long)(0));
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "App #";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel2.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Black);
            this.panel2.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.LblApp_Name);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.LblAppNo);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel2.ExcludeFromUniqueId = false;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.NextFocusId = ((long)(0));
            this.panel2.PerformLayoutEnabled = true;
            this.panel2.PreviousFocusId = ((long)(0));
            this.panel2.Size = new System.Drawing.Size(585, 45);
            this.panel2.TabIndex = 0;
            this.panel2.Click += new System.EventHandler(this.panel2_Click);
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.chkSelectAll);
            this.panel9.Controls.Add(this.label3);
            this.panel9.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel9.ExcludeFromUniqueId = false;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.NextFocusId = ((long)(0));
            this.panel9.PerformLayoutEnabled = true;
            this.panel9.PreviousFocusId = ((long)(0));
            this.panel9.Size = new System.Drawing.Size(585, 25);
            this.panel9.TabIndex = 7;
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.ExcludeFromUniqueId = false;
            this.chkSelectAll.Location = new System.Drawing.Point(346, 1);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.NextFocusId = ((long)(0));
            this.chkSelectAll.PerformLayoutEnabled = true;
            this.chkSelectAll.PreviousFocusId = ((long)(0));
            this.chkSelectAll.Size = new System.Drawing.Size(82, 21);
            this.chkSelectAll.TabIndex = 1;
            this.chkSelectAll.Text = "Select All";
            this.chkSelectAll.Visible = false;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.Transparent;
            this.pnlMain.Controls.Add(this.panel4);
            this.pnlMain.Controls.Add(this.panel10);
            this.pnlMain.Controls.Add(this.panel2);
            this.pnlMain.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.pnlMain.ExcludeFromUniqueId = false;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.NextFocusId = ((long)(0));
            this.pnlMain.PerformLayoutEnabled = true;
            this.pnlMain.PreviousFocusId = ((long)(0));
            this.pnlMain.Size = new System.Drawing.Size(585, 464);
            this.pnlMain.TabIndex = 1;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.gvCA);
            this.panel10.Controls.Add(this.Txt_ProgText);
            this.panel10.Controls.Add(this.panel9);
            this.panel10.Controls.Add(this.panel11);
            this.panel10.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel10.ExcludeFromUniqueId = false;
            this.panel10.Location = new System.Drawing.Point(0, 45);
            this.panel10.Name = "panel10";
            this.panel10.NextFocusId = ((long)(0));
            this.panel10.PerformLayoutEnabled = true;
            this.panel10.PreviousFocusId = ((long)(0));
            this.panel10.Size = new System.Drawing.Size(585, 419);
            this.panel10.TabIndex = 0;
            // 
            // gvCA
            // 
            this.gvCA.AllowUserToAddRows = false;
            this.gvCA.AllowUserToDeleteRows = false;
            this.gvCA.AllowUserToResizeColumns = false;
            this.gvCA.AllowUserToResizeRows = false;
            this.gvCA.Columns.AddRange(new Gizmox.WebGUI.Forms.DataGridViewColumn[] {
            this.CA_Sel,
            this.CA_Code,
            this.CA_Desc,
            this.Notes_key,
            this.CAMS_Type});
            this.gvCA.ExcludeFromUniqueId = false;
            this.gvCA.Location = new System.Drawing.Point(585, 26);
            this.gvCA.Name = "gvCA";
            this.gvCA.NextFocusId = ((long)(0));
            this.gvCA.PerformLayoutEnabled = true;
            this.gvCA.PreviousFocusId = ((long)(0));
            this.gvCA.RenderCellPanelsAsText = false;
            this.gvCA.RowHeadersWidth = 25;
            this.gvCA.RowTemplate.Enabled = true;
            this.gvCA.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvCA.Size = new System.Drawing.Size(585, 200);
            this.gvCA.TabIndex = 8;
            this.gvCA.Visible = false;
            // 
            // CA_Sel
            // 
            dataGridViewCellStyle1.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = false;
            this.CA_Sel.DefaultCellStyle = dataGridViewCellStyle1;
            this.CA_Sel.HeaderText = " ";
            this.CA_Sel.Name = "CA_Sel";
            this.CA_Sel.Width = 24;
            // 
            // CA_Code
            // 
            this.CA_Code.DefaultCellStyle = dataGridViewCellStyle2;
            this.CA_Code.HeaderText = "CA Code";
            this.CA_Code.Name = "CA_Code";
            this.CA_Code.ReadOnly = true;
            this.CA_Code.Visible = false;
            this.CA_Code.Width = 80;
            // 
            // CA_Desc
            // 
            this.CA_Desc.DefaultCellStyle = dataGridViewCellStyle3;
            this.CA_Desc.HeaderText = "Description";
            this.CA_Desc.Name = "CA_Desc";
            this.CA_Desc.ReadOnly = true;
            this.CA_Desc.Width = 520;
            // 
            // Notes_key
            // 
            this.Notes_key.DefaultCellStyle = dataGridViewCellStyle4;
            this.Notes_key.Name = "Notes_key";
            this.Notes_key.Visible = false;
            // 
            // CAMS_Type
            // 
            this.CAMS_Type.DefaultCellStyle = dataGridViewCellStyle5;
            this.CAMS_Type.Name = "CAMS_Type";
            this.CAMS_Type.Visible = false;
            // 
            // panel11
            // 
            this.panel11.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.panel11.ExcludeFromUniqueId = false;
            this.panel11.Location = new System.Drawing.Point(0, 225);
            this.panel11.Name = "panel11";
            this.panel11.NextFocusId = ((long)(0));
            this.panel11.PerformLayoutEnabled = true;
            this.panel11.PreviousFocusId = ((long)(0));
            this.panel11.Size = new System.Drawing.Size(585, 194);
            this.panel11.TabIndex = 0;
            // 
            // ProgressNotes_Form
            // 
            this.Controls.Add(this.pnlMain);
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(585, 464);
            this.Text = "ProgressNotes_Form";
            this.Load += new System.EventHandler(this.ProgressNotes_Form_Load);
            this.FormClosing += new Gizmox.WebGUI.Forms.Form.FormClosingEventHandler(this.ProgressNotes_Form_FormClosing);
            this.panel5.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvCA)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Label LblApp_Name;
        private Label label2;
        private Label LblAppNo;
        private Label label1;
        private Panel panel2;
        private Panel panel4;
        private Panel panel5;
        private Button Btn_Close;
        private Button Btn_Cancel;
        private Button Btn_Save;
        private TextBox Txt_ProgEdit;
        private TextBox Txt_ProgText;
        private Label label3;
        private Label label4;
        private Button Btn_Print;
        private Button btnAdd;
        private Panel panel6;
        private Panel panel7;
        private Panel panel8;
        private Panel panel9;
        private Panel pnlMain;
        private Panel panel10;
        private Panel panel11;
        private Panel panel1;
        private DataGridView gvCA;
        private DataGridViewCheckBoxColumn CA_Sel;
        private DataGridViewTextBoxColumn CA_Code;
        private DataGridViewTextBoxColumn CA_Desc;
        private DataGridViewTextBoxColumn Notes_key;
        private DataGridViewTextBoxColumn CAMS_Type;
        private CheckBox chkSelectAll;
    }
}