namespace Captain.Common.Views.Forms.Base
{
    partial class BaseForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ScriptManager = new Captain.Common.Views.Controls.ScriptManagerControl();
            this.FriendlyMessage = new Captain.Common.Views.Controls.FriendlyMessage();
            this.SuspendLayout();
            // 
            // ScriptManager
            // 
            this.ScriptManager.ControlID = "";
            this.ScriptManager.Location = new System.Drawing.Point(25, 43);
            this.ScriptManager.Name = "ScriptManager";
            this.ScriptManager.Size = new System.Drawing.Size(75, 23);
            this.ScriptManager.TabIndex = 0;
            // 
            // FriendlyMessage
            // 
            this.FriendlyMessage.Location = new System.Drawing.Point(104, 43);
            this.FriendlyMessage.Name = "FriendlyMessage";
            this.FriendlyMessage.Size = new System.Drawing.Size(75, 23);
            this.FriendlyMessage.TabIndex = 1;
            // 
            // BaseForm
            // 
            this.Controls.Add(this.FriendlyMessage);
            this.Controls.Add(this.ScriptManager);
            this.Size = new System.Drawing.Size(853, 491);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ScriptManagerControl ScriptManager;
        private Controls.FriendlyMessage FriendlyMessage;

        //public Captain.Common.Views.Controls.ScriptManagerControl ScriptManager;
        //public Gizmox.WebGUI.Forms.ToolTip ControlsTooltip;
        //public Captain.Common.Views.Controls.FriendlyMessage FriendlyMessage;
    }
}