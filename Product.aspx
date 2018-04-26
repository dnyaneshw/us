<%@ Page Title="Welcome to dscoverage.com - Product" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="Insurance.Product" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    
    <UC:ucProducts ID="ucProducts1" runat="server" />
    <div class="float-right">
                    <asp:Button ID="btnBeginEnrollmentViaProductControl" runat="server" Text="Begin Enrollment" ToolTip="Start" OnClick="btnBeginEnrollmentViaProductControl_Click" />
                </div>
    
</asp:Content>
