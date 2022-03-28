using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Captain.Common.Views.Forms
{
    partial class CASB2012_AdhocRDLCForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CASB2012_AdhocRDLCForm));
            this.rvViewer = new Gizmox.WebGUI.Reporting.ReportViewer();
            this.button1 = new Gizmox.WebGUI.Forms.Button();
            this.btnNotePad = new Gizmox.WebGUI.Forms.Button();
            this.btnPreviewReport = new Gizmox.WebGUI.Forms.Button();
            this.btnGenExcel = new Gizmox.WebGUI.Forms.Button();
            this.SuspendLayout();
            // 
            // rvViewer
            // 
            this.rvViewer.AutoScroll = false;
            this.rvViewer.ControlCode = resources.GetString("rvViewer.ControlCode");
            this.rvViewer.ExcludeFromUniqueId = false;
            this.rvViewer.Location = new System.Drawing.Point(3, 9);
            this.rvViewer.Name = "rvViewer";
            this.rvViewer.PerformLayoutEnabled = true;
            this.rvViewer.Size = new System.Drawing.Size(791, 536);
            this.rvViewer.TabIndex = 0;
            this.rvViewer.HostedPageLoad += new Gizmox.WebGUI.Forms.Hosts.AspPageEventHandler(this.rvViewer_HostedPageLoad);
            this.rvViewer.HostedControlLoad += new Gizmox.WebGUI.Forms.Hosts.AspControlEventHandler(this.rvViewer_HostedControlLoad);
            // 
            // button1
            // 
            this.button1.ExcludeFromUniqueId = false;
            this.button1.Location = new System.Drawing.Point(351, 547);
            this.button1.Name = "button1";
            this.button1.PerformLayoutEnabled = true;
            this.button1.Size = new System.Drawing.Size(107, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Get Summary";
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnNotePad
            // 
            this.btnNotePad.ExcludeFromUniqueId = false;
            this.btnNotePad.Location = new System.Drawing.Point(567, 548);
            this.btnNotePad.Name = "btnNotePad";
            this.btnNotePad.PerformLayoutEnabled = true;
            this.btnNotePad.Size = new System.Drawing.Size(108, 23);
            this.btnNotePad.TabIndex = 2;
            this.btnNotePad.Text = "Generate NotePad";
            this.btnNotePad.Visible = false;
            this.btnNotePad.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnPreviewReport
            // 
            this.btnPreviewReport.ExcludeFromUniqueId = false;
            this.btnPreviewReport.Location = new System.Drawing.Point(464, 548);
            this.btnPreviewReport.Name = "btnPreviewReport";
            this.btnPreviewReport.PerformLayoutEnabled = true;
            this.btnPreviewReport.Size = new System.Drawing.Size(100, 23);
            this.btnPreviewReport.TabIndex = 1;
            this.btnPreviewReport.Text = "Preview Reports";
            this.btnPreviewReport.Visible = false;
            this.btnPreviewReport.Click += new System.EventHandler(this.btnPreviewReport_Click);
            // 
            // btnGenExcel
            // 
            this.btnGenExcel.ExcludeFromUniqueId = false;
            this.btnGenExcel.Location = new System.Drawing.Point(681, 548);
            this.btnGenExcel.Name = "btnGenExcel";
            this.btnGenExcel.PerformLayoutEnabled = true;
            this.btnGenExcel.Size = new System.Drawing.Size(108, 23);
            this.btnGenExcel.TabIndex = 2;
            this.btnGenExcel.Text = "Generate Excel";
            this.btnGenExcel.Visible = false;
            this.btnGenExcel.Click += new System.EventHandler(this.btnGenExcel_Click);
            // 
            // CASB2012_AdhocRDLCForm
            // 
            this.Controls.Add(this.btnGenExcel);
            this.Controls.Add(this.btnPreviewReport);
            this.Controls.Add(this.btnNotePad);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.rvViewer);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedToolWindow;
            this.Size = new System.Drawing.Size(798, 572);
            this.Text = "CASB2012_AdhocRDLCForm";
            this.FormClosing += new Gizmox.WebGUI.Forms.Form.FormClosingEventHandler(this.CASB2012_AdhocRDLCForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Reporting.ReportViewer rvViewer;
        private Button button1;
        private Button btnNotePad;
        private Button btnPreviewReport;
        private Button btnGenExcel;


    }
}