<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Recapcher_page.aspx.cs" Inherits="Captain.Recapcher_page" %>
<%@ Register TagPrefix="recaptcha" Namespace="Recaptcha" Assembly="Recaptcha" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="https://www.google.com/recaptcha/api.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:label id="lblResult" runat="server"></asp:label>
        <recaptcha:recaptchacontrol id="RecaptchaControl2" runat="server" publickey="6LcdMq4bAAAAAFSJ5mi5f6kHGQkneet6FrEOkGJW" privatekey="6LcdMq4bAAAAADLLk0q-Hsyxd5yDC0fMWs9hm3Ff" theme="blackglass"></recaptcha:recaptchacontrol>
        <asp:button id="btnSubmit" runat="server" text="Submit" onclick="btnSubmit_Click"></asp:button>

    </div>
    </form>
</body>
</html>
