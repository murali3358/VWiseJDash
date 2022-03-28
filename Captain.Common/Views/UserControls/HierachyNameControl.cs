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
    public partial class HierachyNameControl : UserControl
    {
        public HierachyNameControl()
        {
            InitializeComponent();
            try
            {
                HIE = lblHierchy;
              
            }
            catch
            {
            }
        }

       

        #region Public Properties        

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]      

        public Label HIE { get; set; }       

        #endregion                          


     
    }
}