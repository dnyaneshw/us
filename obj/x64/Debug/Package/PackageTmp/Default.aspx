<%@ Page Title="Welcome to dscoverage.com - Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Insurance._Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <script type="text/javascript" src="wthvideo/wthvideo.js"></script>
   <hgroup class="title">
    <h1>We suggest the following:</h1>
   </hgroup>
    <div class="content-wrapper">
        <ul>
            <li class="nav navbar-nav" style="padding:5px">
                <p><b>Enroll:</b></p>               
                <asp:ImageButton Height="200" ImageAlign="Middle" OnClick="btnReg_Click" ImageUrl="~/Images/Enroll.jpg" ID="ImageButton1" runat="server" alt="register" />
            </li>
            <li class="nav navbar-nav" style="padding:5px">
                <p><b>Generate A Certificate:</b></p>
                <asp:ImageButton Height="200" ImageAlign="Middle" OnClick="btnLogin_Click" ImageUrl="~/Images/Print.jpg" ID="ImageButton2" runat="server" alt="register" />
            </li>
            <li class="nav navbar-nav" style="padding:5px">
                <p><b>Renew:</b></p>
                <asp:ImageButton Height="200" ImageAlign="Middle" OnClick="btnRenew_Click" ImageUrl="~/Images/Renew.jpg" ID="ImageButton4" runat="server" alt="register" />
            </li>
        </ul>
    </div>
</asp:Content>
