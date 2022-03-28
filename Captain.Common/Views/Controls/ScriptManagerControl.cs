/************************************************************************************
* Class Name    : ScriptManagerControl
* Author        : 
* Created Date  : 
* Version       : 1.0
* Description   : 
*                                          
****************************************************************************************/
#region Using

using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Extensibility;
using Captain.Common.Handlers;
using Captain.Common.Utilities;

#endregion

namespace Captain.Common.Views.Controls
{
    /// <summary>
    /// Summary description for ScriptManagerControl
    /// </summary>
    [ToolboxItem(true)]
    [ToolboxBitmapAttribute(typeof(ScriptManagerControl), "Captain.Common.Views.Controls.ScriptManagerControl.bmp")]
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.PlaceHolderController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.PlaceHolderController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [MetadataTag("Captain.Common.Views.Controls.ScriptManagerControl")]
    public partial class ScriptManagerControl : Control
    {
        private string _command = string.Empty;
        private string _controlName = string.Empty;
        private string _controlID = string.Empty;

        public ScriptManagerControl()
        {
            InitializeComponent();
        }

        public string ControlID
        {
            get
            {
                return _controlID;
            }
            set
            {
                _controlID = value;
            }
        }

        [DefaultValue("")]
        public string Command
        {
            get
            {
                return _command;
            }
            set
            {
                _command = value;
                this.Update();
            }
        }

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                if (base.Text != value)
                {
                    base.Text = value;
                    this.Update();
                }
            }
        }

        protected override void RenderAttributes(IContext context, IAttributeWriter writer)
        {
            base.RenderAttributes(context, writer);

            writer.WriteAttributeString(WGAttributes.Text, Text);
            writer.WriteAttributeString("Command", _command);
            writer.WriteAttributeString("ControlID", _controlID);
        }

        protected override void FireEvent(IEvent objEvent)
        {
            try
            {
                _command = objEvent["Command"].ToString();
                _controlName = objEvent["ControlName"].ToString();
                CommonFunctions.LogToFile("ScriptManagerControl_Server - " + _command, "trace_server");

                switch (objEvent.Type)
                {
                    case "SendCommand":
                        string winControlGuid = objEvent["WinControlGuid"].ToString();
                        //if (OnSendCommand != null)
                        //{
                        //    OnSendCommand(this, new SendCommandEventArgs(_command, _controlName, winControlGuid));
                        //}
                        break;
                    default:
                        base.FireEvent(objEvent);
                        break;
                }
            }
            catch (Exception)
            {
                base.FireEvent(objEvent);
            }
        }

        //protected override EventTypes GetCriticalEvents()
        //{
        //    EventTypes enmEvents = base.GetCriticalEvents();
        //    //if (OnSendCommand != null) { enmEvents |= EventTypes.ValueChange; }
        //    return enmEvents;
        //}

        public void ExecuteCommand(string scriptCommand)
        {
            InvokeMethodWithId("mobjApp.ScriptManagerControl_ExecuteCommand", new object[] { _controlID, scriptCommand });
        }
    }
}