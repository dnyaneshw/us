<%@ Page Title="Welcome to dscoverage.com - Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Insurance.Login" %>

<%@ Register Src="~/UserControl/ucLogin.ascx" TagPrefix="UC" TagName="ucLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <UC:ucLogin runat="server" id="ucLogin" />
</asp:Content>
