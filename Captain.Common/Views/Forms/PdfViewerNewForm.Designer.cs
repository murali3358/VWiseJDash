using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Captain.Common.Views.Forms
{
    partial class PdfViewerNewForm
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
            this.htmlBox1 = new Gizmox.WebGUI.Forms.HtmlBox();
            this.pnlDetails = new Gizmox.WebGUI.Forms.Panel();
            this.Btn_Bypass = new Gizmox.WebGUI.Forms.Button();
            this.Btn_SNP_Details = new Gizmox.WebGUI.Forms.Button();
            this.Btn_MST_Details = new Gizmox.WebGUI.Forms.Button();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.panel3 = new Gizmox.WebGUI.Forms.Panel();
            this.pnlDetails.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // htmlBox1
            // 
            this.htmlBox1.ContentType = "text/html";
            this.htmlBox1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.htmlBox1.Html = "<HTML>No content.</HTML>";
            this.htmlBox1.Location = new System.Drawing.Point(0, 0);
            this.htmlBox1.Name = "htmlBox1";
            this.htmlBox1.Size = new System.Drawing.Size(767, 465);
            this.htmlBox1.TabIndex = 0;
            // 
            // pnlDetails
            // 
            this.pnlDetails.Controls.Add(this.Btn_Bypass);
            this.pnlDetails.Controls.Add(this.Btn_SNP_Details);
            this.pnlDetails.Controls.Add(this.Btn_MST_Details);
            this.pnlDetails.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.pnlDetails.Location = new System.Drawing.Point(0, 465);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new System.Drawing.Size(767, 42);
            this.pnlDetails.TabIndex = 1;
            this.pnlDetails.Visible = false;
            // 
            // Btn_Bypass
            // 
            this.Btn_Bypass.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Btn_Bypass.Location = new System.Drawing.Point(289, 2);
            this.Btn_Bypass.Name = "Btn_Bypass";
            this.Btn_Bypass.Size = new System.Drawing.Size(119, 38);
            this.Btn_Bypass.TabIndex = 1;
            this.Btn_Bypass.Text = "Get Bypass Report";
            this.Btn_Bypass.Visible = false;
            this.Btn_Bypass.Click += new System.EventHandler(this.Btn_Bypass_Click);
            // 
            // Btn_SNP_Details
            // 
            this.Btn_SNP_Details.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Btn_SNP_Details.Location = new System.Drawing.Point(20, 2);
            this.Btn_SNP_Details.Name = "Btn_SNP_Details";
            this.Btn_SNP_Details.Size = new System.Drawing.Size(136, 38);
            this.Btn_SNP_Details.TabIndex = 1;
            this.Btn_SNP_Details.Text = "Get Individual Details Report";
            this.Btn_SNP_Details.Visible = false;
            this.Btn_SNP_Details.Click += new System.EventHandler(this.Btn_SNP_Details_Click);
            // 
            // Btn_MST_Details
            // 
            this.Btn_MST_Details.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Btn_MST_Details.Location = new System.Drawing.Point(156, 2);
            this.Btn_MST_Details.Name = "Btn_MST_Details";
            this.Btn_MST_Details.Size = new System.Drawing.Size(133, 38);
            this.Btn_MST_Details.TabIndex = 1;
            this.Btn_MST_Details.Text = "Get Family Details Report";
            this.Btn_MST_Details.Visible = false;
            this.Btn_MST_Details.Click += new System.EventHandler(this.Btn_MST_Details_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.pnlDetails);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(767, 507);
            this.panel1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.htmlBox1);
            this.panel3.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(767, 465);
            this.panel3.TabIndex = 2;
            // 
            // PdfViewerNewForm
            // 
            this.Controls.Add(this.panel1);
            this.Size = new System.Drawing.Size(767, 507);
            this.Text = "Viewer";
            this.pnlDetails.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private HtmlBox htmlBox1;
        private Panel pnlDetails;
        private Button Btn_Bypass;
        private Button Btn_SNP_Details;
        private Button Btn_MST_Details;
        private Panel panel1;
        private Panel panel3;


    }
}