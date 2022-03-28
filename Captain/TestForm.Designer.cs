using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Captain
{
    partial class TestForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestForm));
            this.button1 = new Gizmox.WebGUI.Forms.Button();
            this.txtEmailId = new Gizmox.WebGUI.Forms.TextBox();
            this.contextMenuStrip1 = new Gizmox.WebGUI.Forms.ContextMenuStrip(this.components);
            this.txtBody = new Gizmox.WebGUI.Forms.TextBox();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.txtSubject = new Gizmox.WebGUI.Forms.TextBox();
            this.lblMsg = new Gizmox.WebGUI.Forms.Label();
            this.button2 = new Gizmox.WebGUI.Forms.Button();
            this.button3 = new Gizmox.WebGUI.Forms.Button();
            this.button4 = new Gizmox.WebGUI.Forms.Button();
            this.button5 = new Gizmox.WebGUI.Forms.Button();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.tabControl1 = new Gizmox.WebGUI.Forms.TabControl();
            this.tabPage1 = new Gizmox.WebGUI.Forms.TabPage();
            this.tabPage2 = new Gizmox.WebGUI.Forms.TabPage();
            this.textBox1 = new Gizmox.WebGUI.Forms.TextBox();
            this.textBox2 = new Gizmox.WebGUI.Forms.TextBox();
            this.textBox3 = new Gizmox.WebGUI.Forms.TextBox();
            this.contextMenu1 = new Gizmox.WebGUI.Forms.ContextMenu();
            this.maskedTextBox1 = new Gizmox.WebGUI.Forms.MaskedTextBox();
            this.workspaceTabs1 = new Gizmox.WebGUI.Forms.WorkspaceTabs();
            this.contextualTabGroup1 = new Gizmox.WebGUI.Forms.ContextualTabGroup();
            this.contextualTabGroup2 = new Gizmox.WebGUI.Forms.ContextualTabGroup();
            this.contextualTabGroup3 = new Gizmox.WebGUI.Forms.ContextualTabGroup();
            this.workspaceTab1 = new Gizmox.WebGUI.Forms.WorkspaceTab();
            this.workspaceTab2 = new Gizmox.WebGUI.Forms.WorkspaceTab();
            this.workspaceTab3 = new Gizmox.WebGUI.Forms.WorkspaceTab();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.workspaceTabs1)).BeginInit();
            this.workspaceTabs1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(76, 148);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Send Mail";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtEmailId
            // 
            this.txtEmailId.ContextMenuStrip = this.contextMenuStrip1;
            this.txtEmailId.Location = new System.Drawing.Point(62, 56);
            this.txtEmailId.Name = "txtEmailId";
            this.txtEmailId.Size = new System.Drawing.Size(220, 20);
            this.txtEmailId.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
            this.contextMenuStrip1.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207))))));
            this.contextMenuStrip1.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.None;
            this.contextMenuStrip1.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(1);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(100, 25);
            // 
            // txtBody
            // 
            this.txtBody.Location = new System.Drawing.Point(-2, 0);
            this.txtBody.Multiline = true;
            this.txtBody.Name = "txtBody";
            this.txtBody.Size = new System.Drawing.Size(180, 200);
            this.txtBody.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Body";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Subject";
            // 
            // txtSubject
            // 
            this.txtSubject.Location = new System.Drawing.Point(62, 85);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(220, 20);
            this.txtSubject.TabIndex = 1;
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(19, 30);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(35, 13);
            this.lblMsg.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(171, 148);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Sms";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(90, 206);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "button3";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(185, 211);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(61, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "button4";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(15, 206);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 8;
            this.button5.Text = "button5";
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Location = new System.Drawing.Point(15, 313);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(189, 122);
            this.panel1.TabIndex = 9;
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = Gizmox.WebGUI.Forms.TabAlignment.Top;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.ShowCloseButton = true;
            this.tabControl1.Size = new System.Drawing.Size(189, 122);
            this.tabControl1.TabIndex = 10;
            this.tabControl1.CloseClick += new System.EventHandler(this.tabControl1_CloseClick);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtBody);
            this.tabPage1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(181, 96);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            // 
            // tabPage2
            // 
            this.tabPage2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(181, 96);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "tabPage2";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(146, 273);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 10;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(52, 111);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(250, 34);
            this.textBox2.TabIndex = 11;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(29, 174);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(217, 20);
            this.textBox3.TabIndex = 12;
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.CustomStyle = "Masked";
            this.maskedTextBox1.Location = new System.Drawing.Point(22, 257);
            this.maskedTextBox1.Mask = "00/00/0000";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(75, 20);
            this.maskedTextBox1.TabIndex = 3;
            this.maskedTextBox1.Validated += new System.EventHandler(this.maskedTextBox1_Validated);
            this.maskedTextBox1.Validating += new System.ComponentModel.CancelEventHandler(this.maskedTextBox1_Validating);
            // 
            // workspaceTabs1
            // 
            this.workspaceTabs1.Alignment = Gizmox.WebGUI.Forms.TabAlignment.Top;
            this.workspaceTabs1.ContextualTabGroups.AddRange(new Gizmox.WebGUI.Forms.ContextualTabGroup[] {
            this.contextualTabGroup1,
            this.contextualTabGroup2,
            this.contextualTabGroup3});
            this.workspaceTabs1.Controls.Add(this.workspaceTab1);
            this.workspaceTabs1.Controls.Add(this.workspaceTab2);
            this.workspaceTabs1.Controls.Add(this.workspaceTab3);
            this.workspaceTabs1.Location = new System.Drawing.Point(351, 226);
            this.workspaceTabs1.Name = "workspaceTabs1";
            this.workspaceTabs1.SelectedIndex = 0;
            this.workspaceTabs1.Size = new System.Drawing.Size(353, 100);
            this.workspaceTabs1.TabIndex = 13;
            this.workspaceTabs1.VisualEffect = new Gizmox.WebGUI.Forms.VisualEffects.EmptyVisualEffect();
            // 
            // workspaceTab1
            // 
            this.workspaceTab1.CustomStyle = "Workspace";
            this.workspaceTab1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.workspaceTab1.Location = new System.Drawing.Point(0, 0);
            this.workspaceTab1.Name = "workspaceTab1";
            this.workspaceTab1.Size = new System.Drawing.Size(345, 74);
            this.workspaceTab1.TabIndex = 0;
            this.workspaceTab1.Text = "workspaceTab1";
            // 
            // workspaceTab2
            // 
            this.workspaceTab2.CustomStyle = "Workspace";
            this.workspaceTab2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.workspaceTab2.Location = new System.Drawing.Point(0, 0);
            this.workspaceTab2.Name = "workspaceTab2";
            this.workspaceTab2.Size = new System.Drawing.Size(345, 74);
            this.workspaceTab2.TabIndex = 1;
            this.workspaceTab2.Text = "workspaceTab2";
            // 
            // workspaceTab3
            // 
            this.workspaceTab3.CustomStyle = "Workspace";
            this.workspaceTab3.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.workspaceTab3.Location = new System.Drawing.Point(0, 0);
            this.workspaceTab3.Name = "workspaceTab3";
            this.workspaceTab3.Size = new System.Drawing.Size(206, 74);
            this.workspaceTab3.TabIndex = 2;
            this.workspaceTab3.Text = "workspaceTab3";
            // 
            // TestForm
            // 
            this.Controls.Add(this.workspaceTabs1);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.txtSubject);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEmailId);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("$this.Icon"));
            this.Size = new System.Drawing.Size(916, 466);
            this.Text = "TestForm Captain";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.workspaceTabs1)).EndInit();
            this.workspaceTabs1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Button button1;
        private TextBox txtEmailId;
        private TextBox txtBody;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtSubject;
        private Label lblMsg;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Panel panel1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private ContextMenuStrip contextMenuStrip1;
        private ContextMenu contextMenu1;
        private MaskedTextBox maskedTextBox1;
        private WorkspaceTabs workspaceTabs1;
        private ContextualTabGroup contextualTabGroup1;
        private ContextualTabGroup contextualTabGroup2;
        private ContextualTabGroup contextualTabGroup3;
        private WorkspaceTab workspaceTab1;
        private WorkspaceTab workspaceTab2;
        private WorkspaceTab workspaceTab3;



    }
}