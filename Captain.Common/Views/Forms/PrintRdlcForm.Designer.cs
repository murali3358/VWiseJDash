using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Captain.Common.Views.Forms
{
    partial class PrintRdlcForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintRdlcForm));
            this.rv = new Gizmox.WebGUI.Reporting.ReportViewer();
            this.SuspendLayout();
            // 
            // rv
            // 
            this.rv.AutoScroll = false;
            this.rv.ControlCode = resources.GetString("rv.ControlCode");
            this.rv.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.rv.ExcludeFromUniqueId = false;
            this.rv.Location = new System.Drawing.Point(0, 0);
            this.rv.Name = "rv";
            this.rv.PerformLayoutEnabled = true;
            this.rv.Size = new System.Drawing.Size(694, 533);
            this.rv.TabIndex = 3;
            this.rv.HostedPageLoad += new Gizmox.WebGUI.Forms.Hosts.AspPageEventHandler(this.rv_HostedPageLoad);
            // 
            // PrintRdlcForm
            // 
            this.Controls.Add(this.rv);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(694, 533);
            this.Text = "Report";
            this.Load += new System.EventHandler(this.PrintRdlcForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Reporting.ReportViewer rv;


    }
}