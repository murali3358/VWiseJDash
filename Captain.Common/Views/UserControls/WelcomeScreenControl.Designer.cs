namespace Captain.Common.Views.UserControls
{
    partial class WelcomeScreenControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WelcomeScreenControl));
            this.picWelcomeScreenTopLeft = new Gizmox.WebGUI.Forms.PictureBox();
            this.pnlWelcomeScreenTop = new Gizmox.WebGUI.Forms.Panel();
            this.picWelcomeScreenTopMiddle = new Gizmox.WebGUI.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picWelcomeScreenTopLeft)).BeginInit();
            this.pnlWelcomeScreenTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWelcomeScreenTopMiddle)).BeginInit();
            this.SuspendLayout();
            // 
            // picWelcomeScreenTopLeft
            // 
            this.picWelcomeScreenTopLeft.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.picWelcomeScreenTopLeft.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("picWelcomeScreenTopLeft.Image"));
            this.picWelcomeScreenTopLeft.Location = new System.Drawing.Point(0, 0);
            this.picWelcomeScreenTopLeft.Name = "picWelcomeScreenTopLeft";
            this.picWelcomeScreenTopLeft.Size = new System.Drawing.Size(782, 600);
            this.picWelcomeScreenTopLeft.TabIndex = 0;
            this.picWelcomeScreenTopLeft.TabStop = false;
            this.picWelcomeScreenTopLeft.Text = "WelcomeScreenTopLeft.jpg";
            // 
            // pnlWelcomeScreenTop
            // 
            this.pnlWelcomeScreenTop.Controls.Add(this.picWelcomeScreenTopMiddle);
            this.pnlWelcomeScreenTop.Controls.Add(this.picWelcomeScreenTopLeft);
            this.pnlWelcomeScreenTop.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.pnlWelcomeScreenTop.Location = new System.Drawing.Point(0, 0);
            this.pnlWelcomeScreenTop.Name = "pnlWelcomeScreenTop";
            this.pnlWelcomeScreenTop.Size = new System.Drawing.Size(800, 600);
            this.pnlWelcomeScreenTop.TabIndex = 1;
            // 
            // picWelcomeScreenTopMiddle
            // 
            this.picWelcomeScreenTopMiddle.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.picWelcomeScreenTopMiddle.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("picWelcomeScreenTopMiddle.Image"));
            this.picWelcomeScreenTopMiddle.Location = new System.Drawing.Point(782, 0);
            this.picWelcomeScreenTopMiddle.Name = "picWelcomeScreenTopMiddle";
            this.picWelcomeScreenTopMiddle.Size = new System.Drawing.Size(18, 600);
            this.picWelcomeScreenTopMiddle.TabIndex = 2;
            this.picWelcomeScreenTopMiddle.TabStop = false;
            this.picWelcomeScreenTopMiddle.Text = "WelcomeScreenTopRight.jpg";
            // 
            // WelcomeScreenControl
            // 
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("$this.BackgroundImage"));
            this.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.pnlWelcomeScreenTop);
            this.Location = new System.Drawing.Point(15, 15);
            this.Size = new System.Drawing.Size(800, 600);
            ((System.ComponentModel.ISupportInitialize)(this.picWelcomeScreenTopLeft)).EndInit();
            this.pnlWelcomeScreenTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picWelcomeScreenTopMiddle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.PictureBox picWelcomeScreenTopLeft;
        private Gizmox.WebGUI.Forms.Panel pnlWelcomeScreenTop;
        private Gizmox.WebGUI.Forms.PictureBox picWelcomeScreenTopMiddle;

    }
}
