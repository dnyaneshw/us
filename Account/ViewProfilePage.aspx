<%@ Page Title="Welcome to dscoverage.com - View Profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewProfilePage.aspx.cs" Inherits="Insurance.Account.ViewProfilePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="pnlReadOnly" Enabled="false" runat="server">
        <UC:ucProfile runat="server" id="ucProfile" />
    </asp:Panel>    
</asp:Content>
