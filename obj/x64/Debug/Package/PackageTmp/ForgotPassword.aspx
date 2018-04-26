<%@ Page Title="Welcome to dscoverage.com - Forgot Password" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="Insurance.ForgotPassword" %>

<%@ Register Src="~/UserControl/ucForgotPassword.ascx" TagPrefix="UC" TagName="ucForgotPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <UC:ucForgotPassword runat="server" id="ucForgotPassword" />
</asp:Content>
