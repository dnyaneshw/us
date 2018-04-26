<%@ Page Title="Welcome to dscoverage.com - Error Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="Insurance.ErrorPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div>
    <hgroup class="title">
             <h1>Error Page</h1>
        </hgroup>
  <p class="validation-summary-errors"></p>

<div class="content-wrapper">
        <ul>
            <li class="nav navbar-nav" style="padding:5px">
        <asp:Image ID="imgError" AlternateText="Error" ImageUrl="~/images/error.jpg"  runat="server" />
        </li>
        </ul>
    </div>
        </div>
</asp:Content>
