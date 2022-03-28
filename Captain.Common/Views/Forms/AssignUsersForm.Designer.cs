namespace ViewPoint.Common.Views.Forms
{
    partial class AssignUsersForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Gizmox.WebGUI.Common.Resources.IconResourceHandle iconResourceHandle1 = new Gizmox.WebGUI.Common.Resources.IconResourceHandle();
            this.lblRole = new Gizmox.WebGUI.Forms.Label();
            this.cmbRole = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblAvailable = new Gizmox.WebGUI.Forms.Label();
            this.lblSelected = new Gizmox.WebGUI.Forms.Label();
            this.btnOK = new Gizmox.WebGUI.Forms.Button();
            this.btnCancel = new Gizmox.WebGUI.Forms.Button();
            this.btnMoveLeftRight = new Gizmox.WebGUI.Forms.Button();
            this.btnMoveAllLeftToRight = new Gizmox.WebGUI.Forms.Button();
            this.button2 = new Gizmox.WebGUI.Forms.Button();
            this.btnMoveRightToLeft = new Gizmox.WebGUI.Forms.Button();
            this.button7 = new Gizmox.WebGUI.Forms.Button();
            this.btnMoveAllRightToLeft = new Gizmox.WebGUI.Forms.Button();
            this.tvwAvailable = new Gizmox.WebGUI.Forms.TreeView();
            this.tvwSelected = new Gizmox.WebGUI.Forms.TreeView();
            this.pnlHeader = new Gizmox.WebGUI.Forms.Panel();
            this.HeaderLabel = new Gizmox.WebGUI.Forms.Label();
            this.IconPictureBox = new Gizmox.WebGUI.Forms.PictureBox();
            this.SuspendLayout();
            // 
            // lblRole
            // 
            this.lblRole.Location = new System.Drawing.Point(17, 94);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(65, 14);
            this.lblRole.TabIndex = 0;
            this.lblRole.Text = "Role:";
            // 
            // cmbRole
            // 
            this.cmbRole.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cmbRole.Location = new System.Drawing.Point(86, 91);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(386, 21);
            this.cmbRole.TabIndex = 1;
            this.cmbRole.SelectedIndexChanged += new System.EventHandler(this.RoleSelectedIndexChanged);
            // 
            // lblAvailable
            // 
            this.lblAvailable.Location = new System.Drawing.Point(15, 128);
            this.lblAvailable.Name = "lblAvailable";
            this.lblAvailable.Size = new System.Drawing.Size(147, 14);
            this.lblAvailable.TabIndex = 4;
            this.lblAvailable.Text = "Available Users / Groups";
            // 
            // lblSelected
            // 
            this.lblSelected.Location = new System.Drawing.Point(270, 128);
            this.lblSelected.Name = "lblSelected";
            this.lblSelected.Size = new System.Drawing.Size(147, 14);
            this.lblSelected.TabIndex = 5;
            this.lblSelected.Text = "Selected Users / Groups";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(314, 386);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.OKClick);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(397, 386);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.CancelClick);
            // 
            // btnMoveLeftRight
            // 
            this.btnMoveLeftRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveLeftRight.Location = new System.Drawing.Point(221, 223);
            this.btnMoveLeftRight.Name = "btnMoveLeftRight";
            this.btnMoveLeftRight.Size = new System.Drawing.Size(44, 25);
            this.btnMoveLeftRight.TabIndex = 18;
            this.btnMoveLeftRight.Text = ">";
            this.btnMoveLeftRight.Click += new System.EventHandler(this.MoveSelectedItemsLeftToRight);
            // 
            // btnMoveAllLeftToRight
            // 
            this.btnMoveAllLeftToRight.Controls.Add(this.button2);
            this.btnMoveAllLeftToRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveAllLeftToRight.Location = new System.Drawing.Point(221, 192);
            this.btnMoveAllLeftToRight.Name = "btnMoveAllLeftToRight";
            this.btnMoveAllLeftToRight.Size = new System.Drawing.Size(45, 25);
            this.btnMoveAllLeftToRight.TabIndex = 17;
            this.btnMoveAllLeftToRight.Text = ">>";
            this.btnMoveAllLeftToRight.Click += new System.EventHandler(this.MoveAllItemsLeftToRight);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(0, -29);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(44, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Up";
            // 
            // btnMoveRightToLeft
            // 
            this.btnMoveRightToLeft.Controls.Add(this.button7);
            this.btnMoveRightToLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveRightToLeft.Location = new System.Drawing.Point(221, 256);
            this.btnMoveRightToLeft.Name = "btnMoveRightToLeft";
            this.btnMoveRightToLeft.Size = new System.Drawing.Size(44, 25);
            this.btnMoveRightToLeft.TabIndex = 19;
            this.btnMoveRightToLeft.Text = "<";
            this.btnMoveRightToLeft.Click += new System.EventHandler(this.MoveSelectedItemsRightToLeft);
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(0, -29);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(44, 23);
            this.button7.TabIndex = 3;
            this.button7.Text = "Up";
            // 
            // btnMoveAllRightToLeft
            // 
            this.btnMoveAllRightToLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveAllRightToLeft.Location = new System.Drawing.Point(221, 290);
            this.btnMoveAllRightToLeft.Name = "btnMoveAllRightToLeft";
            this.btnMoveAllRightToLeft.Size = new System.Drawing.Size(44, 25);
            this.btnMoveAllRightToLeft.TabIndex = 20;
            this.btnMoveAllRightToLeft.Text = "<<";
            this.btnMoveAllRightToLeft.Click += new System.EventHandler(this.MoveAllItemsRightToLeft);
            // 
            // tvwAvailable
            // 
            this.tvwAvailable.Location = new System.Drawing.Point(15, 145);
            this.tvwAvailable.Name = "tvwAvailable";
            this.tvwAvailable.Size = new System.Drawing.Size(202, 225);
            this.tvwAvailable.TabIndex = 21;
            this.tvwAvailable.NodeMouseClick += new Gizmox.WebGUI.Forms.TreeNodeMouseClickEventHandler(this.TreeViewNodeClicked);
            // 
            // tvwSelected
            // 
            this.tvwSelected.Location = new System.Drawing.Point(270, 145);
            this.tvwSelected.Name = "tvwSelected";
            this.tvwSelected.Size = new System.Drawing.Size(202, 225);
            this.tvwSelected.TabIndex = 21;
            this.tvwSelected.NodeMouseClick += new Gizmox.WebGUI.Forms.TreeNodeMouseClickEventHandler(this.TreeViewNodeClicked);
            // 
            // pnlHeader
            // 
            this.pnlHeader.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(182)))), ((int)(((byte)(231)))));
            this.pnlHeader.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Clear;
            this.pnlHeader.Controls.Add(this.HeaderLabel);
            this.pnlHeader.Controls.Add(this.IconPictureBox);
            this.pnlHeader.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(479, 75);
            this.pnlHeader.TabIndex = 0;
            // 
            // HeaderLabel
            // 
            this.HeaderLabel.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.HeaderLabel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeaderLabel.ForeColor = System.Drawing.Color.White;
            this.HeaderLabel.Location = new System.Drawing.Point(82, 4);
            this.HeaderLabel.Name = "HeaderLabel";
            this.HeaderLabel.Size = new System.Drawing.Size(383, 67);
            this.HeaderLabel.TabIndex = 1;
            this.HeaderLabel.Text = "Select a role from which to pick users or groups to assign.";
            this.HeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // IconPictureBox
            // 
            iconResourceHandle1.File = "48X48.Users.gif";
            this.IconPictureBox.Image = iconResourceHandle1;
            this.IconPictureBox.Location = new System.Drawing.Point(16, 12);
            this.IconPictureBox.Name = "IconPictureBox";
            this.IconPictureBox.Size = new System.Drawing.Size(50, 50);
            this.IconPictureBox.SizeMode = Gizmox.WebGUI.Forms.PictureBoxSizeMode.CenterImage;
            this.IconPictureBox.TabIndex = 0;
            // 
            // AssignUsersForm
            // 
            this.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Bottom)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Left)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.tvwSelected);
            this.Controls.Add(this.tvwAvailable);
            this.Controls.Add(this.btnMoveAllRightToLeft);
            this.Controls.Add(this.btnMoveRightToLeft);
            this.Controls.Add(this.btnMoveAllLeftToRight);
            this.Controls.Add(this.btnMoveLeftRight);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblSelected);
            this.Controls.Add(this.lblAvailable);
            this.Controls.Add(this.cmbRole);
            this.Controls.Add(this.lblRole);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(479, 425);
            this.Text = "Assign Users / Groups";
            this.Load += new System.EventHandler(this.AssignUsersFormLoad);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label lblRole;
        private Gizmox.WebGUI.Forms.ComboBox cmbRole;
        private Gizmox.WebGUI.Forms.Label lblAvailable;
        private Gizmox.WebGUI.Forms.Label lblSelected;
        private Gizmox.WebGUI.Forms.Button btnOK;
        private Gizmox.WebGUI.Forms.Button btnCancel;
        private Gizmox.WebGUI.Forms.Button btnMoveLeftRight;
        private Gizmox.WebGUI.Forms.Button btnMoveAllLeftToRight;
        private Gizmox.WebGUI.Forms.Button button2;
        private Gizmox.WebGUI.Forms.Button btnMoveRightToLeft;
        private Gizmox.WebGUI.Forms.Button button7;
        private Gizmox.WebGUI.Forms.Button btnMoveAllRightToLeft;
        private Gizmox.WebGUI.Forms.TreeView tvwAvailable;
        private Gizmox.WebGUI.Forms.TreeView tvwSelected;
        private Gizmox.WebGUI.Forms.Panel pnlHeader;
        public Gizmox.WebGUI.Forms.Label HeaderLabel;
        public Gizmox.WebGUI.Forms.PictureBox IconPictureBox;


    }
}