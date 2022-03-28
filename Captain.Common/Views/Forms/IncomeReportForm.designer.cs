using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Captain.Common.Views.Forms
{
    partial class IncomeReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IncomeReportForm));
            this.BtnGenPdf = new Gizmox.WebGUI.Forms.Button();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.TxtFileName = new Gizmox.WebGUI.Forms.TextBox();
            this.pictureBox1 = new Gizmox.WebGUI.Forms.PictureBox();
            this.SuspendLayout();
            // 
            // BtnGenPdf
            // 
            this.BtnGenPdf.Location = new System.Drawing.Point(269, 22);
            this.BtnGenPdf.Name = "BtnGenPdf";
            this.BtnGenPdf.Size = new System.Drawing.Size(174, 38);
            this.BtnGenPdf.TabIndex = 0;
            this.BtnGenPdf.Text = "G&enerate PDF";
            this.BtnGenPdf.Click += new System.EventHandler(this.BtnGenPdf_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Save as";
            // 
            // TxtFileName
            // 
            this.TxtFileName.Location = new System.Drawing.Point(71, 159);
            this.TxtFileName.Name = "TxtFileName";
            this.TxtFileName.Size = new System.Drawing.Size(431, 18);
            this.TxtFileName.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("pictureBox1.Image"));
            this.pictureBox1.Location = new System.Drawing.Point(189, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(56, 57);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // IncomeReportForm
            // 
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.TxtFileName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnGenPdf);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Fixed3D;
            this.Size = new System.Drawing.Size(518, 397);
            this.Text = "IncomeReportForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Button BtnGenPdf;
        private Label label3;
        private TextBox TxtFileName;
        private PictureBox pictureBox1;


    }
}