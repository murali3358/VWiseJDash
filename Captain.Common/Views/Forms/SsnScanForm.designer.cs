using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
namespace Captain.Common.Views.Forms
{
    partial class SsnScanForm
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
            this.btnSelect = new Gizmox.WebGUI.Forms.Button();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.gvwssnscansearch = new Gizmox.WebGUI.Forms.DataGridView();
            this.ApplicantNumber = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.NameOftheHHMember = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DOB = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.LastUpdate = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.SsnNo = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.MemSeq = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.dateTimePicker2 = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.panel7 = new Gizmox.WebGUI.Forms.Panel();
            this.label8 = new Gizmox.WebGUI.Forms.Label();
            this.pictureBox2 = new Gizmox.WebGUI.Forms.PictureBox();
            this.panel8 = new Gizmox.WebGUI.Forms.Panel();
            this.btnSSNSelect = new Gizmox.WebGUI.Forms.Button();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(351, 385);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 7;
            this.btnSelect.Text = "&Select";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(514, 55);
            this.panel1.TabIndex = 2;
            // 
            // gvwssnscansearch
            // 
            this.gvwssnscansearch.AllowUserToAddRows = false;
            this.gvwssnscansearch.AllowUserToDeleteRows = false;
            this.gvwssnscansearch.AllowUserToResizeColumns = false;
            this.gvwssnscansearch.AllowUserToResizeRows = false;
            this.gvwssnscansearch.BackgroundColor = System.Drawing.Color.White;
            this.gvwssnscansearch.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.FormatProvider = new System.Globalization.CultureInfo("en-US");
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.gvwssnscansearch.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvwssnscansearch.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvwssnscansearch.Columns.AddRange(new Gizmox.WebGUI.Forms.DataGridViewColumn[] {
            this.ApplicantNumber,
            this.NameOftheHHMember,
            this.DOB,
            this.LastUpdate,
            this.SsnNo,
            this.MemSeq});
            this.gvwssnscansearch.Location = new System.Drawing.Point(4, 61);
            this.gvwssnscansearch.MultiSelect = false;
            this.gvwssnscansearch.Name = "gvwssnscansearch";
            this.gvwssnscansearch.ReadOnly = true;
            this.gvwssnscansearch.RowHeadersWidth = 20;
            this.gvwssnscansearch.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("en-US");
            this.gvwssnscansearch.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical;
            this.gvwssnscansearch.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvwssnscansearch.Size = new System.Drawing.Size(562, 215);
            this.gvwssnscansearch.TabIndex = 0;
            // 
            // ApplicantNumber
            // 
            this.ApplicantNumber.HeaderText = "Applicant Number";
            this.ApplicantNumber.Name = "ApplicantNumber";
            this.ApplicantNumber.ReadOnly = true;
            this.ApplicantNumber.Width = 160;
            // 
            // NameOftheHHMember
            // 
            this.NameOftheHHMember.HeaderText = "Name Of The HH Member";
            this.NameOftheHHMember.Name = "NameOftheHHMember";
            this.NameOftheHHMember.ReadOnly = true;
            this.NameOftheHHMember.Width = 200;
            // 
            // DOB
            // 
            this.DOB.Name = "DOB";
            this.DOB.ReadOnly = true;
            this.DOB.Width = 75;
            // 
            // LastUpdate
            // 
            this.LastUpdate.HeaderText = "Last Update";
            this.LastUpdate.Name = "LastUpdate";
            this.LastUpdate.ReadOnly = true;
            // 
            // SsnNo
            // 
            this.SsnNo.Name = "SsnNo";
            this.SsnNo.ReadOnly = true;
            this.SsnNo.Visible = false;
            // 
            // MemSeq
            // 
            this.MemSeq.Name = "MemSeq";
            this.MemSeq.ReadOnly = true;
            this.MemSeq.Visible = false;
            this.MemSeq.Width = 5;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dateTimePicker2.CustomFormat = "";
            this.dateTimePicker2.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(417, -219);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(79, 21);
            this.dateTimePicker2.TabIndex = 15;
            // 
            // panel7
            // 
            this.panel7.Location = new System.Drawing.Point(124, -249);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(415, 64);
            this.panel7.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(81, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Ssn Scan Search";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox2.Location = new System.Drawing.Point(20, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(50, 46);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel8.Controls.Add(this.dateTimePicker2);
            this.panel8.Controls.Add(this.panel7);
            this.panel8.Controls.Add(this.label8);
            this.panel8.Controls.Add(this.pictureBox2);
            this.panel8.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(573, 55);
            this.panel8.TabIndex = 2;
            // 
            // btnSSNSelect
            // 
            this.btnSSNSelect.Location = new System.Drawing.Point(496, 281);
            this.btnSSNSelect.Name = "btnSSNSelect";
            this.btnSSNSelect.Size = new System.Drawing.Size(71, 20);
            this.btnSSNSelect.TabIndex = 4;
            this.btnSSNSelect.Text = "&Select";
            this.btnSSNSelect.Click += new System.EventHandler(this.btnSSNSelect_Click);
            // 
            // SsnScanForm
            // 
            this.Controls.Add(this.btnSSNSelect);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.gvwssnscansearch);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(573, 306);
            this.Text = "SSN ScanSearchForm";
            this.panel8.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnSelect;
        private Panel panel1;
        private DataGridView gvwssnscansearch;
        private DateTimePicker dateTimePicker2;
        private Panel panel7;
        private Label label8;
        private PictureBox pictureBox2;
        private Panel panel8;
        private Button btnSSNSelect;
        private DataGridViewTextBoxColumn ApplicantNumber;
        private DataGridViewTextBoxColumn NameOftheHHMember;
        private DataGridViewTextBoxColumn DOB;
        private DataGridViewTextBoxColumn LastUpdate;
        private DataGridViewTextBoxColumn SsnNo;
        private DataGridViewTextBoxColumn MemSeq;


    }
}