using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Captain.Common.Views.Forms
{
    partial class LiheapPerfQuestions
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.btnSave = new Gizmox.WebGUI.Forms.Button();
            this.btnCancel = new Gizmox.WebGUI.Forms.Button();
            this.gvwHouseingQues = new Gizmox.WebGUI.Forms.DataGridView();
            this.gvtHeadcode = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.gvtQuesDesc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.gvtResponseDesc = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.gvtQuesCode = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.gvtQType = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.contextMenu1 = new Gizmox.WebGUI.Forms.ContextMenu();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvwHouseingQues)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.gvwHouseingQues);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(727, 243);
            this.panel1.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(528, 215);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(617, 215);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // gvwHouseingQues
            // 
            this.gvwHouseingQues.AllowDrag = false;
            this.gvwHouseingQues.AllowDragTargetsPropagation = false;
            this.gvwHouseingQues.AllowUserToAddRows = false;
            this.gvwHouseingQues.AllowUserToDeleteRows = false;
            this.gvwHouseingQues.AllowUserToResizeColumns = false;
            this.gvwHouseingQues.AllowUserToResizeRows = false;
            this.gvwHouseingQues.BackgroundColor = System.Drawing.Color.White;
            this.gvwHouseingQues.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.gvwHouseingQues.Columns.AddRange(new Gizmox.WebGUI.Forms.DataGridViewColumn[] {
            this.gvtHeadcode,
            this.gvtQuesDesc,
            this.gvtResponseDesc,
            this.gvtQuesCode,
            this.gvtQType});
            this.gvwHouseingQues.ContextMenu = this.contextMenu1;
            this.gvwHouseingQues.Location = new System.Drawing.Point(2, 10);
            this.gvwHouseingQues.Name = "gvwHouseingQues";
            this.gvwHouseingQues.RowHeadersWidth = 10;
            this.gvwHouseingQues.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical;
            this.gvwHouseingQues.SelectionMode = Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvwHouseingQues.Size = new System.Drawing.Size(716, 202);
            this.gvwHouseingQues.TabIndex = 0;
            this.gvwHouseingQues.MenuClick += new Gizmox.WebGUI.Forms.MenuEventHandler(this.gvwHouseingQues_MenuClick);
            // 
            // gvtHeadcode
            // 
            this.gvtHeadcode.DefaultCellStyle = dataGridViewCellStyle6;
            this.gvtHeadcode.HeaderText = " ";
            this.gvtHeadcode.Name = "gvtHeadcode";
            this.gvtHeadcode.ReadOnly = true;
            this.gvtHeadcode.Visible = false;
            this.gvtHeadcode.Width = 10;
            // 
            // gvtQuesDesc
            // 
            this.gvtQuesDesc.DefaultCellStyle = dataGridViewCellStyle7;
            this.gvtQuesDesc.HeaderText = "Questions";
            this.gvtQuesDesc.Name = "gvtQuesDesc";
            this.gvtQuesDesc.ReadOnly = true;
            this.gvtQuesDesc.Width = 580;
            // 
            // gvtResponseDesc
            // 
            this.gvtResponseDesc.DefaultCellStyle = dataGridViewCellStyle8;
            this.gvtResponseDesc.HeaderText = "Response ";
            this.gvtResponseDesc.Name = "gvtResponseDesc";
            this.gvtResponseDesc.ReadOnly = true;
            // 
            // gvtQuesCode
            // 
            this.gvtQuesCode.DefaultCellStyle = dataGridViewCellStyle9;
            this.gvtQuesCode.HeaderText = " ";
            this.gvtQuesCode.Name = "gvtQuesCode";
            this.gvtQuesCode.ReadOnly = true;
            this.gvtQuesCode.Visible = false;
            // 
            // gvtQType
            // 
            this.gvtQType.DefaultCellStyle = dataGridViewCellStyle10;
            this.gvtQType.HeaderText = "QType";
            this.gvtQType.Name = "gvtQType";
            this.gvtQType.Visible = false;
            // 
            // contextMenu1
            // 
            this.contextMenu1.Popup += new System.EventHandler(this.contextMenu1_Popup);
            // 
            // LiheapPerfQuestions
            // 
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(727, 243);
            this.Text = "LiheapPerfQuestions";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvwHouseingQues)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private DataGridView gvwHouseingQues;
        private Button btnSave;
        private Button btnCancel;
        private DataGridViewTextBoxColumn gvtHeadcode;
        private DataGridViewTextBoxColumn gvtQuesDesc;
        private DataGridViewTextBoxColumn gvtResponseDesc;
        private DataGridViewTextBoxColumn gvtQuesCode;
        private ContextMenu contextMenu1;
        private DataGridViewTextBoxColumn gvtQType;


    }
}