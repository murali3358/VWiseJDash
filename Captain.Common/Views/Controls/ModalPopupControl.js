// JScript source code for ModalInlinePopupControl control

function ModalPopupControl_ShowModalDialog(guid, modalHtml)
{
    frame = document.getElementById('VgwModalPopup');
    var thewindow = frame.contentWindow;
    thewindow.document.open();
    thewindow.document.write("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n");
    thewindow.document.write("<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n");
    thewindow.document.write("  <head>\r\n");
    thewindow.document.write("  <title></title>\r\n");
    thewindow.document.write("  </head>\r\n");
    thewindow.document.write("  <body scroll='no' style='border-style: outset 1px ; padding: 0px; margin: 0px;'>\r\n");
    thewindow.document.write(modalHtml);
    thewindow.document.write("</body>\r\n");
    thewindow.document.write("</html>");
    thewindow.document.close();
}