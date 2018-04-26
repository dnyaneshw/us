<%@ Page Title="Welcome to dscoverage.com - Edit Profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditProfilePage.aspx.cs" Inherits="Insurance.Account.EditProfilePage" %>

<%@ Register Src="~/UserControl/ucProfile.ascx" TagPrefix="UC" TagName="ucProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <UC:ucProfile runat="server" id="ucProfile" />
</asp:Content>
