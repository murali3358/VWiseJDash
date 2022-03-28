using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Captain
{
    partial class ReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportForm));
            this.rvViewer = new Gizmox.WebGUI.Reporting.ReportViewer();
            this.button1 = new Gizmox.WebGUI.Forms.Button();
            this.button2 = new Gizmox.WebGUI.Forms.Button();
            this.btnZipCode = new Gizmox.WebGUI.Forms.Button();
            this.button3 = new Gizmox.WebGUI.Forms.Button();
            this.button4 = new Gizmox.WebGUI.Forms.Button();
            this.button5 = new Gizmox.WebGUI.Forms.Button();
            this.button6 = new Gizmox.WebGUI.Forms.Button();
            this.SuspendLayout();
            // 
            // rvViewer
            // 
            this.rvViewer.AutoScroll = false;
            this.rvViewer.ControlCode = resources.GetString("rvViewer.ControlCode");
            this.rvViewer.Location = new System.Drawing.Point(202, 31);
            this.rvViewer.Name = "rvViewer";
            this.rvViewer.Size = new System.Drawing.Size(705, 401);
            this.rvViewer.TabIndex = 0;
            this.rvViewer.HostedPageLoad += new Gizmox.WebGUI.Forms.Hosts.AspPageEventHandler(this.rvViewer_HostedPageLoad);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(41, 61);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Sample Report";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(41, 103);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "CAMAST REPORT";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnZipCode
            // 
            this.btnZipCode.Location = new System.Drawing.Point(41, 153);
            this.btnZipCode.Name = "btnZipCode";
            this.btnZipCode.Size = new System.Drawing.Size(130, 23);
            this.btnZipCode.TabIndex = 3;
            this.btnZipCode.Text = "ZipCode Report";
            this.btnZipCode.Click += new System.EventHandler(this.btnZipCode_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(41, 193);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(130, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "AgyTab Report";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(41, 230);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(130, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "Case Income";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(41, 268);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(130, 23);
            this.button5.TabIndex = 3;
            this.button5.Text = "Case Mst";
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(41, 312);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(130, 23);
            this.button6.TabIndex = 3;
            this.button6.Text = "Case Sum XML";
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // ReportForm
            // 
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnZipCode);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.rvViewer);
            this.Size = new System.Drawing.Size(926, 466);
            this.Text = "ReportForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Reporting.ReportViewer rvViewer;
        private Button button1;
        private Button button2;
        private Button btnZipCode;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;


    }
}