<%@ Page Title="Welcome to dscoverage.com - Request for Certificate" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FillCertiInfo.aspx.cs" Inherits="Insurance.FillCertiInfo" %>
<%@ Register src="UserControl/ucCertificateInformation.ascx" tagname="ucCertificateInformation" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:ucCertificateInformation ID="ucCertificateInformation1" runat="server" />
</asp:Content>
