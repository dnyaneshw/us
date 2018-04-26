<%@ Page Title="Welcome to dscoverage.com - Admin Contract List" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="~/AdminInsuranceMasterPage.Master" AutoEventWireup="true" CodeBehind="AdminContractsList.aspx.cs" Inherits="Insurance.Admin.AdminContractsList" %>
<%@ Register Src="~/Admin/UserControl/ucAdminUploadedDocument.ascx" TagPrefix="UC" TagName="ucAdminUploadedDocument" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
 <UC:ucAdminUploadedDocument runat="server" ID="ucAdminUploadedDocument" />
</asp:Content>
