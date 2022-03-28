#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Captain.Common.Utilities;

#endregion

namespace Captain.Common.Views.UserControls
{
    public partial class HierachykeyControl : UserControl
    {
        public HierachykeyControl()
        {
            InitializeComponent();
            try
            {
                HIE = txtMainHierchy;
              
            }
            catch
            {
            }
        }

        #region Public Properties        

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]      

        public TextBox HIE { get; set; }       

        #endregion                          


     
    }
}