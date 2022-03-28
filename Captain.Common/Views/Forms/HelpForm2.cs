#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

#endregion

namespace Captain.Common.Views.Forms
{
    public partial class HelpForm2 : Form
    {
        public HelpForm2()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, Context.Server.MapPath("~\\Resources\\HelpFiles\\AdminHelp.chm"), HelpNavigator.Topic, "Agency");

        }
    }
}