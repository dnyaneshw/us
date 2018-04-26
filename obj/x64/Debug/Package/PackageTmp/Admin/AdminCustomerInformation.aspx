<%@ Page Title="Welcome to dscoverage.com - Customer's Information" Language="C#" MaintainScrollPositionOnPostback="true" MasterPageFile="~/AdminInsuranceMasterPage.Master" AutoEventWireup="true" CodeBehind="AdminCustomerInformation.aspx.cs" Inherits="Insurance.Admin.AdminCustomerInformation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
        <UC:ucCustomerInformation runat="server" ID="ucCustomerInformation" />
</asp:Content>
