using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Captain
{
    partial class LoginForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.chkRememberUserName = new Gizmox.WebGUI.Forms.CheckBox();
            this.btnLogin = new Gizmox.WebGUI.Forms.Button();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.txtPassword = new Gizmox.WebGUI.Forms.TextBox();
            this.txtUserName = new Gizmox.WebGUI.Forms.TextBox();
            this.pnlLoginBox = new Gizmox.WebGUI.Forms.Panel();
            this.linktryanotheruser = new Gizmox.WebGUI.Forms.LinkLabel();
            this.linkresend = new Gizmox.WebGUI.Forms.LinkLabel();
            this.lblOnetime = new Gizmox.WebGUI.Forms.Label();
            this.lblTimerLeft = new Gizmox.WebGUI.Forms.Label();
            this.btnValidCaptcher = new Gizmox.WebGUI.Forms.Button();
            this.txtverifytext = new Gizmox.WebGUI.Forms.TextBox();
            this.lblEntertext = new Gizmox.WebGUI.Forms.Label();
            this.lblMessage = new Gizmox.WebGUI.Forms.Label();
            this.pnlLogin = new Gizmox.WebGUI.Forms.Panel();
            this.timer1 = new Gizmox.WebGUI.Forms.Timer(this.components);
            this.pnlLoginBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkRememberUserName
            // 
            this.chkRememberUserName.AutoSize = true;
            this.chkRememberUserName.ExcludeFromUniqueId = false;
            this.chkRememberUserName.Location = new System.Drawing.Point(144, 167);
            this.chkRememberUserName.Name = "chkRememberUserName";
            this.chkRememberUserName.NextFocusId = ((long)(0));
            this.chkRememberUserName.PerformLayoutEnabled = true;
            this.chkRememberUserName.PreviousFocusId = ((long)(0));
            this.chkRememberUserName.Size = new System.Drawing.Size(116, 17);
            this.chkRememberUserName.TabIndex = 3;
            this.chkRememberUserName.Text = "Remember User ID";
            // 
            // btnLogin
            // 
            this.btnLogin.ExcludeFromUniqueId = false;
            this.btnLogin.Location = new System.Drawing.Point(354, 165);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.NextFocusId = ((long)(0));
            this.btnLogin.PerformLayoutEnabled = true;
            this.btnLogin.PreviousFocusId = ((long)(0));
            this.btnLogin.Size = new System.Drawing.Size(60, 26);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Login";
            this.btnLogin.Click += new System.EventHandler(this.LoginClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ExcludeFromUniqueId = false;
            this.label2.Location = new System.Drawing.Point(68, 145);
            this.label2.Name = "label2";
            this.label2.NextFocusId = ((long)(0));
            this.label2.PerformLayoutEnabled = true;
            this.label2.PreviousFocusId = ((long)(0));
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ExcludeFromUniqueId = false;
            this.label1.Location = new System.Drawing.Point(68, 114);
            this.label1.Name = "label1";
            this.label1.NextFocusId = ((long)(0));
            this.label1.PerformLayoutEnabled = true;
            this.label1.PreviousFocusId = ((long)(0));
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "User ID";
            // 
            // txtPassword
            // 
            this.txtPassword.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Black);
            this.txtPassword.ExcludeFromUniqueId = false;
            this.txtPassword.Location = new System.Drawing.Point(142, 139);
            this.txtPassword.MaxLength = 20;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.NextFocusId = ((long)(0));
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.PerformLayoutEnabled = true;
            this.txtPassword.PreviousFocusId = ((long)(0));
            this.txtPassword.Size = new System.Drawing.Size(271, 23);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.EnterKeyDown += new Gizmox.WebGUI.Forms.KeyEventHandler(this.PasswordEnterKeyDown);
            this.txtPassword.GotFocus += new System.EventHandler(this.txtPassword_GotFocus);
            // 
            // txtUserName
            // 
            this.txtUserName.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Black);
            this.txtUserName.CharacterCasing = Gizmox.WebGUI.Forms.CharacterCasing.Upper;
            this.txtUserName.ExcludeFromUniqueId = false;
            this.txtUserName.Location = new System.Drawing.Point(142, 109);
            this.txtUserName.MaxLength = 20;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.NextFocusId = ((long)(0));
            this.txtUserName.PerformLayoutEnabled = true;
            this.txtUserName.PreviousFocusId = ((long)(0));
            this.txtUserName.Size = new System.Drawing.Size(272, 22);
            this.txtUserName.TabIndex = 0;
            // 
            // pnlLoginBox
            // 
            this.pnlLoginBox.BackgroundImage = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("pnlLoginBox.BackgroundImage"));
            this.pnlLoginBox.Controls.Add(this.linktryanotheruser);
            this.pnlLoginBox.Controls.Add(this.linkresend);
            this.pnlLoginBox.Controls.Add(this.lblOnetime);
            this.pnlLoginBox.Controls.Add(this.lblTimerLeft);
            this.pnlLoginBox.Controls.Add(this.btnValidCaptcher);
            this.pnlLoginBox.Controls.Add(this.txtverifytext);
            this.pnlLoginBox.Controls.Add(this.lblEntertext);
            this.pnlLoginBox.Controls.Add(this.lblMessage);
            this.pnlLoginBox.Controls.Add(this.chkRememberUserName);
            this.pnlLoginBox.Controls.Add(this.btnLogin);
            this.pnlLoginBox.Controls.Add(this.label2);
            this.pnlLoginBox.Controls.Add(this.label1);
            this.pnlLoginBox.Controls.Add(this.txtPassword);
            this.pnlLoginBox.Controls.Add(this.txtUserName);
            this.pnlLoginBox.ExcludeFromUniqueId = false;
            this.pnlLoginBox.Location = new System.Drawing.Point(129, 60);
            this.pnlLoginBox.Name = "pnlLoginBox";
            this.pnlLoginBox.NextFocusId = ((long)(0));
            this.pnlLoginBox.PerformLayoutEnabled = true;
            this.pnlLoginBox.PreviousFocusId = ((long)(0));
            this.pnlLoginBox.Size = new System.Drawing.Size(484, 310);
            this.pnlLoginBox.TabIndex = 1;
            // 
            // linktryanotheruser
            // 
            this.linktryanotheruser.AutoSize = true;
            this.linktryanotheruser.ExcludeFromUniqueId = false;
            this.linktryanotheruser.LinkColor = System.Drawing.Color.Blue;
            this.linktryanotheruser.Location = new System.Drawing.Point(272, 253);
            this.linktryanotheruser.Name = "linktryanotheruser";
            this.linktryanotheruser.NextFocusId = ((long)(0));
            this.linktryanotheruser.PerformLayoutEnabled = true;
            this.linktryanotheruser.PreviousFocusId = ((long)(0));
            this.linktryanotheruser.Size = new System.Drawing.Size(66, 17);
            this.linktryanotheruser.TabIndex = 8;
            this.linktryanotheruser.TabStop = true;
            this.linktryanotheruser.Text = "Try with Another User";
            this.linktryanotheruser.Visible = false;
            this.linktryanotheruser.LinkClicked += new Gizmox.WebGUI.Forms.LinkLabelLinkClickedEventHandler(this.linktryanotheruser_LinkClicked);
            // 
            // linkresend
            // 
            this.linkresend.AutoSize = true;
            this.linkresend.ExcludeFromUniqueId = false;
            this.linkresend.LinkColor = System.Drawing.Color.Blue;
            this.linkresend.Location = new System.Drawing.Point(143, 253);
            this.linkresend.Name = "linkresend";
            this.linkresend.NextFocusId = ((long)(0));
            this.linkresend.PerformLayoutEnabled = true;
            this.linkresend.PreviousFocusId = ((long)(0));
            this.linkresend.Size = new System.Drawing.Size(66, 17);
            this.linkresend.TabIndex = 7;
            this.linkresend.TabStop = true;
            this.linkresend.Text = "Resend Text";
            this.linkresend.Visible = false;
            this.linkresend.LinkClicked += new Gizmox.WebGUI.Forms.LinkLabelLinkClickedEventHandler(this.linkresend_LinkClicked);
            // 
            // lblOnetime
            // 
            this.lblOnetime.AutoSize = true;
            this.lblOnetime.ExcludeFromUniqueId = false;
            this.lblOnetime.ForeColor = System.Drawing.Color.Red;
            this.lblOnetime.Location = new System.Drawing.Point(68, 195);
            this.lblOnetime.Name = "lblOnetime";
            this.lblOnetime.NextFocusId = ((long)(0));
            this.lblOnetime.PerformLayoutEnabled = true;
            this.lblOnetime.PreviousFocusId = ((long)(0));
            this.lblOnetime.Size = new System.Drawing.Size(35, 13);
            this.lblOnetime.TabIndex = 5;
            this.lblOnetime.Text = "One time Text sent to your email id : @r**@c********s.com ";
            this.lblOnetime.Visible = false;
            // 
            // lblTimerLeft
            // 
            this.lblTimerLeft.AutoSize = true;
            this.lblTimerLeft.ExcludeFromUniqueId = false;
            this.lblTimerLeft.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimerLeft.ForeColor = System.Drawing.Color.Red;
            this.lblTimerLeft.Location = new System.Drawing.Point(252, 227);
            this.lblTimerLeft.Name = "lblTimerLeft";
            this.lblTimerLeft.NextFocusId = ((long)(0));
            this.lblTimerLeft.PerformLayoutEnabled = true;
            this.lblTimerLeft.PreviousFocusId = ((long)(0));
            this.lblTimerLeft.Size = new System.Drawing.Size(42, 17);
            this.lblTimerLeft.TabIndex = 6;
            this.lblTimerLeft.Text = "Valid for 2 mins";
            this.lblTimerLeft.Visible = false;
            // 
            // btnValidCaptcher
            // 
            this.btnValidCaptcher.ExcludeFromUniqueId = false;
            this.btnValidCaptcher.Location = new System.Drawing.Point(354, 221);
            this.btnValidCaptcher.Name = "btnValidCaptcher";
            this.btnValidCaptcher.NextFocusId = ((long)(0));
            this.btnValidCaptcher.PerformLayoutEnabled = true;
            this.btnValidCaptcher.PreviousFocusId = ((long)(0));
            this.btnValidCaptcher.Size = new System.Drawing.Size(60, 26);
            this.btnValidCaptcher.TabIndex = 4;
            this.btnValidCaptcher.Text = "Submit";
            this.btnValidCaptcher.Visible = false;
            this.btnValidCaptcher.Click += new System.EventHandler(this.btnValidCaptcher_Click);
            // 
            // txtverifytext
            // 
            this.txtverifytext.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Black);
            this.txtverifytext.CharacterCasing = Gizmox.WebGUI.Forms.CharacterCasing.Upper;
            this.txtverifytext.ExcludeFromUniqueId = false;
            this.txtverifytext.Location = new System.Drawing.Point(143, 224);
            this.txtverifytext.MaxLength = 20;
            this.txtverifytext.Name = "txtverifytext";
            this.txtverifytext.NextFocusId = ((long)(0));
            this.txtverifytext.PerformLayoutEnabled = true;
            this.txtverifytext.PreviousFocusId = ((long)(0));
            this.txtverifytext.Size = new System.Drawing.Size(102, 22);
            this.txtverifytext.TabIndex = 0;
            this.txtverifytext.Visible = false;
            // 
            // lblEntertext
            // 
            this.lblEntertext.AutoSize = true;
            this.lblEntertext.ExcludeFromUniqueId = false;
            this.lblEntertext.Location = new System.Drawing.Point(68, 227);
            this.lblEntertext.Name = "lblEntertext";
            this.lblEntertext.NextFocusId = ((long)(0));
            this.lblEntertext.PerformLayoutEnabled = true;
            this.lblEntertext.PreviousFocusId = ((long)(0));
            this.lblEntertext.Size = new System.Drawing.Size(35, 13);
            this.lblEntertext.TabIndex = 2;
            this.lblEntertext.Text = "Enter Text";
            this.lblEntertext.Visible = false;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.ExcludeFromUniqueId = false;
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(145, 91);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.NextFocusId = ((long)(0));
            this.lblMessage.PerformLayoutEnabled = true;
            this.lblMessage.PreviousFocusId = ((long)(0));
            this.lblMessage.Size = new System.Drawing.Size(35, 13);
            this.lblMessage.TabIndex = 5;
            // 
            // pnlLogin
            // 
            this.pnlLogin.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.pnlLogin.ExcludeFromUniqueId = false;
            this.pnlLogin.Location = new System.Drawing.Point(0, 0);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.NextFocusId = ((long)(0));
            this.pnlLogin.PerformLayoutEnabled = true;
            this.pnlLogin.PreviousFocusId = ((long)(0));
            this.pnlLogin.Size = new System.Drawing.Size(1024, 577);
            this.pnlLogin.TabIndex = 3;
            // 
            // timer1
            // 
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // LoginForm
            // 
            this.BackgroundImage = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("$this.BackgroundImage"));
            this.Controls.Add(this.pnlLoginBox);
            this.Controls.Add(this.pnlLogin);
            this.Size = new System.Drawing.Size(1024, 577);
            this.Text = "LoginForm";
            this.Load += new System.EventHandler(this.LoginFormLoad);
            this.Resize += new System.EventHandler(this.LoginFormResize);
            this.RegisteredTimers = new Gizmox.WebGUI.Forms.Timer[] {
        this.timer1};
            this.pnlLoginBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CheckBox chkRememberUserName;
        private Button btnLogin;
        private Label label2;
        private Label label1;
        private TextBox txtPassword;
        private TextBox txtUserName;
        private Panel pnlLoginBox;
        private Panel pnlLogin;
        private Label lblMessage;
        private Button btnValidCaptcher;
        private TextBox txtverifytext;
        private Label lblEntertext;
        private Timer timer1;
        private Label lblTimerLeft;
        private LinkLabel linktryanotheruser;
        private LinkLabel linkresend;
        private Label lblOnetime;
    }
}