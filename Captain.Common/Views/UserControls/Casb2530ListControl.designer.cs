using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Captain.Common.Views.UserControls
{
    partial class Casb2530ListControl
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
            this.lvtMain = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.lvtName = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.lvtPoints = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.lvtViews = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.listViewRanks = new Gizmox.WebGUI.Forms.ListView();
            this.SuspendLayout();
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
            this.lvtPoints.Width = 45;
            // 
            // lvtViews
            // 
            this.lvtViews.PreferedItemHeight = 22;
            this.lvtViews.Text = " ";
            this.lvtViews.Type = Gizmox.WebGUI.Forms.ListViewColumnType.Control;
            this.lvtViews.Width = 300;
            // 
            // listViewRanks
            // 
            this.listViewRanks.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.lvtMain,
            this.lvtName,
            this.lvtPoints,
            this.lvtViews});
            this.listViewRanks.DataMember = null;
            this.listViewRanks.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.listViewRanks.HeaderStyle = Gizmox.WebGUI.Forms.ColumnHeaderStyle.None;
            this.listViewRanks.Location = new System.Drawing.Point(0, 0);
            this.listViewRanks.Name = "listViewRanks";
            this.listViewRanks.Size = new System.Drawing.Size(550, 129);
            this.listViewRanks.TabIndex = 0;
            // 
            // Casb2530ListControl
            // 
            this.Controls.Add(this.listViewRanks);
            this.Size = new System.Drawing.Size(670, 129);
            this.Text = "Casb2530ListControl";
            this.ResumeLayout(false);

        }

        #endregion

        private ColumnHeader lvtMain;
        private ColumnHeader lvtName;
        private ColumnHeader lvtPoints;
        private ColumnHeader lvtViews;
        private ListView listViewRanks;



    }
}