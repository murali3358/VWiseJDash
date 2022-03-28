// JScript source code for FriendlyMessage control
iens6 = document.all || document.getElementById;

var _friendlyMessageName = "VWG_FirendlyMessage";
var _winHeight = 0;
var _winPositionFromTop = 0;
var _errorCount = 0;
var _lines = 0;
var _openTimer = 0;
var _closeTimer = 0;
var _errorMessages = new Array();

function ClientBody()
{
    return (document.compatMode && document.compatMode!="BackCompat") ? document.documentElement : document.body;
}

function MakeFirendlyMessage() 
{
    //debugger;
    var frienlyMessage = null;

    if (!document.getElementById(_friendlyMessageName))
    {
        frienlyMessage = document.createElement("DIV");
        frienlyMessage.onclick = function() { mobjApp.HideFriendlyMessage(); };
        frienlyMessage.setAttribute("id", _friendlyMessageName);
        frienlyMessage.setAttribute("name", _friendlyMessageName);
	    frienlyMessage.style.position = 'absolute';
	    frienlyMessage.style.backgroundColor = '#FFFFCC';
	    frienlyMessage.style.display = 'none';
	    frienlyMessage.style.left = 0;
	    frienlyMessage.style.width = 0;
	    frienlyMessage.style.height = 0;
	    frienlyMessage.style.zIndex = 1;
	    frienlyMessage.style.overflowX = 'hidden';
	    frienlyMessage.style.overflowY = 'auto';
	    frienlyMessage.style.borderTop = '1px solid black';
	    
	    document.body.appendChild(frienlyMessage);
	}
}

function AddRowToTable(message, foreColor, gradientStart, gradientEnd)
{
    //debugger;
    
    var tbl = document.getElementById(_friendlyMessageName + '_Table');
    var lastRow = tbl.rows.length;
    var iteration = lastRow + 1;

    var row = tbl.insertRow(lastRow);

    var cell = row.insertCell(0);
    cell.style.fontFamily = "Verdana";
    cell.style.fontSize = "8pt";
    cell.style.width = "2%";
    cell.style.fontWeight = "normal";
    cell.style.verticalAlign = "top";
    cell.style.backgroundColor = "#" + gradientStart;
    cell.style.color = "#" + foreColor;
    cell.style.filter = "progid:DXImageTransform.Microsoft.Gradient(GradientType=0, StartColorStr='#FF" + gradientStart + "', EndColorStr='#FF" + gradientEnd + "')";
    cell.innerHTML = iteration + ".&nbsp;";
    
    cell = row.insertCell(1);
    cell.style.fontFamily = "Verdana";
    cell.style.fontSize = "8pt";
    cell.style.width = "98%";
    cell.style.fontWeight = "normal";
    cell.style.verticalAlign = "top";
    cell.style.backgroundColor = "#" + gradientStart;
    cell.style.color = "#" + foreColor;
    cell.style.filter = "progid:DXImageTransform.Microsoft.Gradient(GradientType=0, StartColorStr='#FF" + gradientStart + "', EndColorStr='#FF" + gradientEnd + "')";
    cell.innerHTML = message;
}

function ShowFriendlyMessage(guid, message, stackMessages, lines, timeout, foreColor, gradientStart, gradientEnd)
{
    //debugger;
    var friendlyMessage = document.getElementById(_friendlyMessageName);

    _winPositionFromTop = Common_GetClientHeight() + 1;

    var currentLines = parseInt(lines);
    _lines += currentLines;

    var multiplier = _lines == 1 ? 34 : 20;

    _winHeight = (_lines > 20 ? 20 : _lines) * multiplier;

    for (i = 0; i < _errorMessages.length; i++)
    {
        if (_errorMessages[i] == message) { return; }
    } 
    
    _errorMessages.splice(_errorMessages.length, 0, message); 

    _errorCount++;

    friendlyMessage.style.height = _winHeight + "px";
    friendlyMessage.style.width = "100%";
    friendlyMessage.style.top = (ClientBody().scrollTop + _winPositionFromTop) - _winHeight + "px";

    if (stackMessages != "true")
    {
        friendlyMessage.innerHTML = "";
        friendlyMessage.insertAdjacentHTML("BeforeEnd", "<table id='" + _friendlyMessageName + "_Table' cellspacing='0' cellpadding='0' width='100%' height='100%' border='0' style='line-height:120%'><tr><td valign='top' style=\"width:2%;background-color:#" + gradientStart + ";filter:progid:DXImageTransform.Microsoft.Gradient(GradientType=0, StartColorStr='#FF" + gradientStart + "', EndColorStr='#FF" + gradientEnd + "');font-family:Verdana;font-size:8pt;color:" + foreColor + ";font-weight:normal\">" + _errorCount.toString() + ".&nbsp;</td><td valign='top' style=\"width:98%;background-color:#" + gradientStart + ";filter:progid:DXImageTransform.Microsoft.Gradient(GradientType=0, StartColorStr='#FF" + gradientStart + "', EndColorStr='#FF" + gradientEnd + "');font-family:Verdana;font-size:8pt;color:" + foreColor + ";font-weight:normal\">" + message + "</td></tr></table>");
    }
    else
    {
        if (friendlyMessage.innerHTML == "")
        {
            friendlyMessage.insertAdjacentHTML("BeforeEnd", "<table id='" + _friendlyMessageName + "_Table' cellspacing='0' cellpadding='0' width='100%' height='100%' border='0' style='line-height:120%'><tr><td valign='top' style=\"width:2%;background-color:#" + gradientStart + ";filter:progid:DXImageTransform.Microsoft.Gradient(GradientType=0, StartColorStr='#FF" + gradientStart + "', EndColorStr='#FF" + gradientEnd + "');font-family:Verdana;font-size:8pt;color:" + foreColor + ";font-weight:normal\">" + _errorCount.toString() + ".&nbsp;</td><td valign='top' style=\"width:98%;background-color:#" + gradientStart + ";filter:progid:DXImageTransform.Microsoft.Gradient(GradientType=0, StartColorStr='#FF" + gradientStart + "', EndColorStr='#FF" + gradientEnd + "');font-family:Verdana;font-size:8pt;color:" + foreColor + ";font-weight:normal\">" + message + "</td></tr></table>");
        }
        else
        {
            AddRowToTable(message, foreColor, gradientStart, gradientEnd);
        }
    }

    if (message != "")
    {
        mobjApp.ViewFriendlyMessage();
        window.clearTimeout(_closeTimer);
        _closeTimer = window.setTimeout('mobjApp.HideFriendlyMessage();', timeout);
    }
}

function ViewFriendlyMessage() 
{
    var friendlyMessage = document.getElementById(_friendlyMessageName);
	friendlyMessage.style.display = "block";
}

function HideFriendlyMessage()
{
    var friendlyMessage = document.getElementById(_friendlyMessageName);
    if (friendlyMessage)
    {
        friendlyMessage.innerHTML = "";
        friendlyMessage.style.display = "none";
    }

    _errorMessages.splice(0,_errorMessages.length);
    _errorCount = 0;

    _winHeight = 0;
    _lines = 0;
}

mobjApp.MakeFirendlyMessage();