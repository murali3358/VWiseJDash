/************************************************************************************
 * Class Name   : MessageEx
 * Author       : 
 * Created Date : 
 * Version      : 
 * Description  : This class file used to show the exception message
 *************************************************************************************/

using Gizmox.WebGUI.Forms;
using Captain.Common.Views.Controls;
using Captain.Common.Utilities;
using System.Collections.Generic;
using System.Drawing;

namespace Captain.Common.Exceptions
{
    public class MessageEx
    {
        private FriendlyMessage _friendlyMessageControl;

        public MessageEx()
        {
        }

        public FriendlyMessage FriendlyMessageControl
        {
            get { return _friendlyMessageControl; }
            set { _friendlyMessageControl = value; }
        }


        public void ShowMessage(string message, string foreColor, string gradientStartColor, string gradientEndColor)
        {
            if (_friendlyMessageControl == null)
            {
                _friendlyMessageControl = new FriendlyMessage();
            }
            
            int lines = 1;
            List<string> words = new List<string>();
            words.AddRange(message.Split(new string[] { "<br/>", "<br />" }, System.StringSplitOptions.None));

            lines = words.Count;
            if (lines == 0) { lines = 1; }

            _friendlyMessageControl.ShowMessage(message, lines, CommonFunctions.GetConfigValue(Consts.Common.FriendlyMessageDelay, 5000), foreColor, gradientStartColor, gradientEndColor);
        }

    }
}
