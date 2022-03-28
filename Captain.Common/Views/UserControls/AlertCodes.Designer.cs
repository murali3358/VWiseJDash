using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Captain.Common.Views.UserControls
{
    partial class AlertCodes
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
            this.btnAlertCodes = new Gizmox.WebGUI.Forms.Button();
            this.contextMenu1 = new Gizmox.WebGUI.Forms.ContextMenu();
            this.txtAlertCodes = new Gizmox.WebGUI.Forms.TextBox();
            this.label52 = new Gizmox.WebGUI.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAlertCodes
            // 
            this.btnAlertCodes.Enabled = false;
            this.btnAlertCodes.Location = new System.Drawing.Point(168, 4);
            this.btnAlertCodes.Name = "btnAlertCodes";
            this.btnAlertCodes.Size = new System.Drawing.Size(29, 23);
            this.btnAlertCodes.TabIndex = 12;
            this.btnAlertCodes.Text = "...";
            this.btnAlertCodes.Click += new System.EventHandler(this.btnAlertCodes_Click);
            // 
            // txtAlertCodes
            // 
            this.txtAlertCodes.ContextMenu = this.contextMenu1;
            this.txtAlertCodes.Location = new System.Drawing.Point(73, 6);
            this.txtAlertCodes.MaxLength = 12;
            this.txtAlertCodes.Name = "txtAlertCodes";
            this.txtAlertCodes.ReadOnly = true;
            this.txtAlertCodes.Size = new System.Drawing.Size(87, 19);
            this.txtAlertCodes.TabIndex = 11;
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(6, 8);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(41, 13);
            this.label52.TabIndex = 10;
            this.label52.Text = "Alert Codes";
            // 
            // AlertCodes
            // 
            this.Controls.Add(this.label52);
            this.Controls.Add(this.txtAlertCodes);
            this.Controls.Add(this.btnAlertCodes);
            this.Size = new System.Drawing.Size(218, 30);
            this.Text = "AlertCodes";
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnAlertCodes;
        private TextBox txtAlertCodes;
        private Label label52;
        private ContextMenu contextMenu1;



    }
}