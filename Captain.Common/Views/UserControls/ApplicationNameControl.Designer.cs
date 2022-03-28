using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Captain.Common.Views.UserControls
{
    partial class ApplicationNameControl
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
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.btnAdvance = new Gizmox.WebGUI.Forms.Button();
            this.Btn_First = new Gizmox.WebGUI.Forms.Button();
            this.BtnPrev = new Gizmox.WebGUI.Forms.Button();
            this.BtnNxt = new Gizmox.WebGUI.Forms.Button();
            this.BtnN10 = new Gizmox.WebGUI.Forms.Button();
            this.BtnLast = new Gizmox.WebGUI.Forms.Button();
            this.BtnP10 = new Gizmox.WebGUI.Forms.Button();
            this.txtAppNo = new Gizmox.WebGUI.Forms.TextBox();
            this.lblAppHeader = new Gizmox.WebGUI.Forms.Label();
            this.lblApplicationName = new Gizmox.WebGUI.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btnAdvance);
            this.panel1.Controls.Add(this.Btn_First);
            this.panel1.Controls.Add(this.BtnPrev);
            this.panel1.Controls.Add(this.BtnNxt);
            this.panel1.Controls.Add(this.BtnN10);
            this.panel1.Controls.Add(this.BtnLast);
            this.panel1.Controls.Add(this.BtnP10);
            this.panel1.Controls.Add(this.txtAppNo);
            this.panel1.Controls.Add(this.lblAppHeader);
            this.panel1.Controls.Add(this.lblApplicationName);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel1.ExcludeFromUniqueId = false;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.PerformLayoutEnabled = true;
            this.panel1.Size = new System.Drawing.Size(849, 20);
            this.panel1.TabIndex = 0;
            // 
            // btnAdvance
            // 
            this.btnAdvance.ExcludeFromUniqueId = false;
            this.btnAdvance.Font = new System.Drawing.Font("Tahoma", 6.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdvance.Location = new System.Drawing.Point(370, 0);
            this.btnAdvance.Name = "btnAdvance";
            this.btnAdvance.PerformLayoutEnabled = true;
            this.btnAdvance.Size = new System.Drawing.Size(28, 20);
            this.btnAdvance.TabIndex = 3;
            this.btnAdvance.Text = "...";
            this.btnAdvance.Click += new System.EventHandler(this.btnAdvance_Click);
            // 
            // Btn_First
            // 
            this.Btn_First.ExcludeFromUniqueId = false;
            this.Btn_First.Font = new System.Drawing.Font("Tahoma", 6.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_First.Location = new System.Drawing.Point(402, 0);
            this.Btn_First.Name = "Btn_First";
            this.Btn_First.PerformLayoutEnabled = true;
            this.Btn_First.Size = new System.Drawing.Size(28, 20);
            this.Btn_First.TabIndex = 4;
            this.Btn_First.Text = "|<";
            this.Btn_First.Click += new System.EventHandler(this.Navigation_Click);
            // 
            // BtnPrev
            // 
            this.BtnPrev.ExcludeFromUniqueId = false;
            this.BtnPrev.Font = new System.Drawing.Font("Tahoma", 6.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPrev.Location = new System.Drawing.Point(456, 0);
            this.BtnPrev.Name = "BtnPrev";
            this.BtnPrev.PerformLayoutEnabled = true;
            this.BtnPrev.Size = new System.Drawing.Size(28, 20);
            this.BtnPrev.TabIndex = 6;
            this.BtnPrev.Text = "<";
            this.BtnPrev.Click += new System.EventHandler(this.Navigation_Click);
            // 
            // BtnNxt
            // 
            this.BtnNxt.ExcludeFromUniqueId = false;
            this.BtnNxt.Font = new System.Drawing.Font("Tahoma", 6.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNxt.Location = new System.Drawing.Point(483, 0);
            this.BtnNxt.Name = "BtnNxt";
            this.BtnNxt.PerformLayoutEnabled = true;
            this.BtnNxt.Size = new System.Drawing.Size(28, 20);
            this.BtnNxt.TabIndex = 7;
            this.BtnNxt.Text = ">";
            this.BtnNxt.Click += new System.EventHandler(this.Navigation_Click);
            // 
            // BtnN10
            // 
            this.BtnN10.ExcludeFromUniqueId = false;
            this.BtnN10.Font = new System.Drawing.Font("Tahoma", 6.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnN10.Location = new System.Drawing.Point(510, 0);
            this.BtnN10.Name = "BtnN10";
            this.BtnN10.PerformLayoutEnabled = true;
            this.BtnN10.Size = new System.Drawing.Size(28, 20);
            this.BtnN10.TabIndex = 8;
            this.BtnN10.Text = ">>";
            this.BtnN10.Click += new System.EventHandler(this.Navigation_Click);
            // 
            // BtnLast
            // 
            this.BtnLast.ExcludeFromUniqueId = false;
            this.BtnLast.Font = new System.Drawing.Font("Tahoma", 6.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLast.Location = new System.Drawing.Point(537, 0);
            this.BtnLast.Name = "BtnLast";
            this.BtnLast.PerformLayoutEnabled = true;
            this.BtnLast.Size = new System.Drawing.Size(28, 20);
            this.BtnLast.TabIndex = 9;
            this.BtnLast.Text = ">|";
            this.BtnLast.Click += new System.EventHandler(this.Navigation_Click);
            // 
            // BtnP10
            // 
            this.BtnP10.ExcludeFromUniqueId = false;
            this.BtnP10.Font = new System.Drawing.Font("Tahoma", 6.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnP10.Location = new System.Drawing.Point(429, 0);
            this.BtnP10.Name = "BtnP10";
            this.BtnP10.PerformLayoutEnabled = true;
            this.BtnP10.Size = new System.Drawing.Size(28, 20);
            this.BtnP10.TabIndex = 5;
            this.BtnP10.Text = "<<";
            this.BtnP10.Click += new System.EventHandler(this.Navigation_Click);
            // 
            // txtAppNo
            // 
            this.txtAppNo.ExcludeFromUniqueId = false;
            this.txtAppNo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtAppNo.Location = new System.Drawing.Point(43, 2);
            this.txtAppNo.Name = "txtAppNo";
            this.txtAppNo.PerformLayoutEnabled = true;
            this.txtAppNo.Size = new System.Drawing.Size(69, 15);
            this.txtAppNo.TabIndex = 2;
            this.txtAppNo.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Right;
            this.txtAppNo.EnterKeyDown += new Gizmox.WebGUI.Forms.KeyEventHandler(this.txtAppNo_EnterKeyDown);
            this.txtAppNo.LostFocus += new System.EventHandler(this.txtAppNo_LostFocus);
            // 
            // lblAppHeader
            // 
            this.lblAppHeader.AutoSize = true;
            this.lblAppHeader.ExcludeFromUniqueId = false;
            this.lblAppHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblAppHeader.Location = new System.Drawing.Point(4, 3);
            this.lblAppHeader.Name = "lblAppHeader";
            this.lblAppHeader.PerformLayoutEnabled = true;
            this.lblAppHeader.Size = new System.Drawing.Size(35, 13);
            this.lblAppHeader.TabIndex = 1;
            this.lblAppHeader.Text = "App#";
            // 
            // lblApplicationName
            // 
            this.lblApplicationName.AutoSize = true;
            this.lblApplicationName.ExcludeFromUniqueId = false;
            this.lblApplicationName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblApplicationName.Location = new System.Drawing.Point(114, 3);
            this.lblApplicationName.Name = "lblApplicationName";
            this.lblApplicationName.PerformLayoutEnabled = true;
            this.lblApplicationName.Size = new System.Drawing.Size(607, 20);
            this.lblApplicationName.TabIndex = 0;
            this.lblApplicationName.Text = "..";
            // 
            // ApplicationNameControl
            // 
            this.Controls.Add(this.panel1);
            this.Size = new System.Drawing.Size(849, 20);
            this.Text = "ApplicationNameControl";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        public Label lblApplicationName;
        public TextBox txtAppNo;
        public Label lblAppHeader;
        private Button btnAdvance;
        public Button Btn_First;
        public Button BtnPrev;
        public Button BtnNxt;
        public Button BtnN10;
        public Button BtnLast;
        public Button BtnP10;
    }
}