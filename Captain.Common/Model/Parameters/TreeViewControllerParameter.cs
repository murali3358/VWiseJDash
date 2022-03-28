using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gizmox.WebGUI.Forms;
using Captain.Common.Controllers;
using Captain.Common.Utilities;
using Captain.Common.Views.Forms.Base;


namespace Captain.Common.Model.Parameters
{
    public class TreeViewControllerParameter
    {
        public TreeViewControllerParameter()
        {
 
        }

        public TreeView TreeView { get; set; }

        public TreeType  TreeType { get; set; }

        public string BusinessModuleID { get; set; }

        public string Hierarchy { get; set; }

        public TagClass ExpectedRootNode { get; set; }
    }
}
