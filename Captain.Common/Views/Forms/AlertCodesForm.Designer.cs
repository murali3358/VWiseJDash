using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Captain.Common.Views.Forms
{
    partial class AlertCodesForm
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
            this.checkedListBox = new Gizmox.WebGUI.Forms.CheckedListBox();
            this.btnOk = new Gizmox.WebGUI.Forms.Button();
            this.SuspendLayout();
            // 
            // checkedListBox
            // 
            this.checkedListBox.Location = new System.Drawing.Point(2, 5);
            this.checkedListBox.Name = "checkedListBox";
            this.checkedListBox.SelectionMode = Gizmox.WebGUI.Forms.SelectionMode.One;
            this.checkedListBox.Size = new System.Drawing.Size(221, 116);
            this.checkedListBox.TabIndex = 0;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(160, 123);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(53, 21);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Ok";
            this.btnOk.Click += new System.EventHandler(this.OnOkClick);
            // 
            // AlertCodesForm
            // 
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.checkedListBox);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(225, 148);
            this.Text = "Alert Codes Selection";
            this.ResumeLayout(false);

        }

        #endregion

        private CheckedListBox checkedListBox;
        private Button btnOk;


    }
}