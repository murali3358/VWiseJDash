using System;
using Captain.Common.Utilities;
using Captain.Common.Views.UserControls.Base;
using Gizmox.WebGUI.Forms;
using Captain.Common.Handlers;
using Gizmox.WebGUI.Common.Interfaces;
using Captain.Common.Controllers;

namespace Captain.Common.Interfaces
{
    public interface ICaptainModel
    {
        string Locale { get; }
        string UserId { get; }
        string UserName { get; }


    }
}
