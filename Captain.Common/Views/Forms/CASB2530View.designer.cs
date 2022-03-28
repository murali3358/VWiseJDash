using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Captain.Common.Views.Forms
{
    partial class CASB2530View
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
            this.listViewRanks = new Gizmox.WebGUI.Forms.ListView();
            this.lvtMain = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.lvtName = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.lvtPoints = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.lvtRiskDesc = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.lvtViews = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.btnUpdateRanks = new Gizmox.WebGUI.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewRanks
            // 
            this.listViewRanks.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.lvtMain,
            this.lvtName,
            this.lvtPoints,
            this.lvtRiskDesc,
            this.lvtViews});
            this.listViewRanks.DataMember = null;
            this.listViewRanks.Location = new System.Drawing.Point(0, 0);
            this.listViewRanks.Name = "listViewRanks";
            this.listViewRanks.Size = new System.Drawing.Size(677, 257);
            this.listViewRanks.TabIndex = 0;
            // 
            // lvtMain
            // 
            this.lvtMain.Text = "";
            this.lvtMain.Width = 5;
            // 
            // lvtName
            // 
            this.lvtName.Text = "Name";
            this.lvtName.Width = 250;
            // 
            // lvtPoints
            // 
            this.lvtPoints.Text = "Points";
            this.lvtPoints.Width = 70;
            // 
            // lvtRiskDesc
            // 
            this.lvtRiskDesc.Text = "Rank";
            this.lvtRiskDesc.Width = 270;
            // 
            // lvtViews
            // 
            this.lvtViews.PreferedItemHeight = 22;
            this.lvtViews.Text = " ";
            this.lvtViews.Type = Gizmox.WebGUI.Forms.ListViewColumnType.Control;
            this.lvtViews.Width = 22;
            // 
            // btnUpdateRanks
            // 
            this.btnUpdateRanks.Location = new System.Drawing.Point(579, 259);
            this.btnUpdateRanks.Name = "btnUpdateRanks";
            this.btnUpdateRanks.Size = new System.Drawing.Size(96, 23);
            this.btnUpdateRanks.TabIndex = 1;
            this.btnUpdateRanks.Text = "Update Ranks";
            this.btnUpdateRanks.Click += new System.EventHandler(this.btnUpdateRanks_Click);
            // 
            // CASB2530View
            // 
            this.Controls.Add(this.btnUpdateRanks);
            this.Controls.Add(this.listViewRanks);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(680, 288);
            this.Text = "CASB2530View";
            this.ResumeLayout(false);

        }

        #endregion

        private ListView listViewRanks;
        private ColumnHeader lvtMain;
        private ColumnHeader lvtName;
        private ColumnHeader lvtPoints;
        private ColumnHeader lvtViews;
        private Button btnUpdateRanks;
        private ColumnHeader lvtRiskDesc;


    }
}