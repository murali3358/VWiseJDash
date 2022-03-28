#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Captain.Common.Model.Objects;

#endregion

namespace Captain.Common.Views.UserControls
{
    public partial class Casb2530GridControl : UserControl
    {
        public Casb2530GridControl(DataTable dt)
        {
            InitializeComponent();
            foreach (DataRow item in dt.Rows)
            {
                gvwPoints.Rows.Add(item[0], item[1], item[2]);
            }
        }

        public Casb2530GridControl(List<CommonEntity> commonlist)
        {
            InitializeComponent();            
            foreach (CommonEntity item in commonlist)
            {
                gvwPoints.Rows.Add(item.Code,item.Desc,item.Extension);
            }
        }

        
    }
}