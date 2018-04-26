<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Insurance.Admin.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Admin Login</title>
    <link rel="Stylesheet" type="text/css" href="Style/mos-style.css" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="Copyright" content="arirusmanto.com">
    <meta name="description" content="Admin MOS Template">
    <meta name="keywords" content="Admin Page">
    <meta name="author" content="Ari Rusmanto">
    <meta name="language" content="Bahasa Indonesia">
    <%--<link rel="shortcut icon" href="stylesheet/img/devil-icon.png">--%>
</head>
<body>
    <form id="form1" runat="server">
    <%--<div id="header">
        <div class="inHeaderLogin">
        </div>
    </div>--%>
    <div id="loginForm">
        <div class="headLoginForm" style="font-family:Tahoma; font-weight:normal;">
            Login Administrator
        </div>
        <div class="fieldLogin">
            <label>
                User Name</label><br />
            <asp:TextBox ID="txtUsername" runat="server" CssClass="login"></asp:TextBox>
            <br />
            <label>
                Password</label><br />
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="login"></asp:TextBox><br />
            <asp:Button ID="btnSubmit" runat="server" Text="Login" CssClass="button logbtn" 
                onclick="btnSubmit_Click" />
        </div>
        <div style="text-align:center">
        <asp:Label ID="lblError" runat="server"  style="font-family:Tahoma; font-size:14px; font-weight: normal;" Text="" ForeColor="#5C5B5B"></asp:Label>
        </div>
        
    </div>
    </form>
</body>
</html>
