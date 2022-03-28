// JScript source code for ScriptManagerControl control
var _returnValue = "";
var _queue = new ScriptManagerControl_Queue();

function ScriptManagerControl_ExecuteCommand(guid, controlID, scriptCommand)
{
    //debugger;
    try
    {
        eval(scriptCommand);
    }
    catch (e)
    {
        _returnValue = "errormessage=" + e.message;
    }

    if (Data_IsDisabled(guid)) return;

    var el = document.getElementById(controlID);

    Web_SetAttribute(el, "vwgcommand", _returnValue);

    Data_SetAttribute(guid, "Command", _returnValue);

    objEvent = Events_CreateEvent(guid, "SendCommand", null, true);
    Events_SetEventAttribute(objEvent, "Command", _returnValue);

    Events_RaiseEvents();

    _returnValue = "";
}

function ScriptManagerControl_CloseWindow(guid)
{
    try
    {
        var code = "document.getElementById('objectControl').CloseProcessor();";
        if (frames['VWG_CommonActions'].Execute) frames['VWG_CommonActions'].Execute(code);
    }
    catch (e)
    {
        // Do not throw errors at this stage
    }
}

//function ScriptManagerControl_ScrollToPosition(guid, gridGuid, targetRow)
//{
//    var gridHeight = parseInt(document.getElementById('VWG_' + gridGuid.toString()).height) - 23;
//    var visibleRows = gridHeight / 22;
//    var scrollToPosition = targetRow * 22;
//    if (targetRow < visibleRows) { return; }
//    document.getElementById('SCROLLER_' + gridGuid.toString()).scrollTop = scrollToPosition;
//}

function ScriptManagerControl_SetOracleFieldValue(guid, frame, fieldID, fieldValue, attempt)
{
    //debugger;
    try
    {
        if (attempt > 5) { return; }
        if (frames[frame])
        {
            var field = frames[frame].window.document.getElementById(fieldID);
            field.value = fieldValue;
        }
    }
    catch (e)
    {
        attempt++;
        window.setTimeout("ScriptManagerControl_SetOracleFieldValue('" + guid + "', '" + frame + "', '" + fieldID + "', '" + fieldValue + "', " + attempt.toString() + ")", 1000);
    }
}

function ScriptMangagerControl_SetFocusControl(guid, controlID)
{
    //debugger;
    var el = document.getElementById("VWG_" + controlID);
    if (el)
    {
        el.focus();
    }
    else
    {
        window.setTimeout("ScriptMangagerControl_SetFocusControlAsync('" + controlID + "');", 500);
    }
}

function ScriptMangagerControl_SetFocusControlAsync(controlID)
{
    var el = document.getElementById("VWG_" + controlID);
    if (el)
    {
        el.focus();
    }
}

function ScriptManagerControl_Queue()
{
    var queue = [];
    var queueSpace = 0;

    this.getSize = function()
    {
        return queue.length - queueSpace;
    }

    this.isEmpty = function()
    {
        return (queue.length == 0);
    }

    this.enqueue = function(element)
    {
        queue.push(element);
    }

    this.dequeue = function()
    {
        var element = undefined;

        if (queue.length)
        {
            element = queue[queueSpace];
            if (++queueSpace * 2 >= queue.length)
            {
                queue = queue.slice(queueSpace);
                queueSpace = 0;
            }
        }

        return element;
    }

    this.getOldestElement = function()
    {
        var element = undefined;

        if (queue.length) element = queue[queueSpace];

        return element;
    }
}

function ExecuteUnhandledCommand(guid, winControlGuid, controlID, command)
{
    //debugger;
    try
    {
        if (Data_IsDisabled(guid)) return;

        var el = document.getElementById("ScriptManagerControl_ScriptManager");

        Web_SetAttribute(el, "vwgwincontrolguid", winControlGuid);
        Web_SetAttribute(el, "vwgcommand", command);
        Web_SetAttribute(el, "vwgcontrolname", controlID);

        Data_SetAttribute(guid, "WinControlGuid", winControlGuid);
        Data_SetAttribute(guid, "Command", command);
        Data_SetAttribute(guid, "ControlName", controlID);

        objEvent = Events_CreateEvent(guid, "SendCommand", null, true);

        Events_SetEventAttribute(objEvent, "WinControlGuid", winControlGuid);
        Events_SetEventAttribute(objEvent, "Command", command);
        Events_SetEventAttribute(objEvent, "ControlName", controlID);

        if (Data_IsCriticalEvent(guid, mcntEventValueChangeId))
        {
            Events_RaiseEvents();
        }
    }
    catch (e) { }
}

function ProcessQueue(scriptManagerGuid, guid, controlID)
{
    //debugger;
    var isProcessing = document.getElementById("VWG_LoadingMessageBox").style.display != 'none';

    if (!isProcessing)
    {
        var command = _queue.dequeue();
        if (command != undefined)
        {
            mobjApp.ExecuteUnhandledCommand(scriptManagerGuid, guid, controlID, command);
        }
    }
    
    if (!_queue.isEmpty())
    {
        mobjApp.setTimeout("mobjApp.ProcessQueue('" + scriptManagerGuid + "', '" + guid + "', '" + controlID + "');", 1000);
    }
}
