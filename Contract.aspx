<%@ Page Title="Welcome to dscoverage.com - Policies" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contract.aspx.cs" Inherits="Insurance.Contract" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div>
         <hgroup class="title">
             <h1>Polices:</h1>
        </hgroup>
        <UC:ucUploadedDocument runat="server" id="ucUploadedDocument1" />
    </div>
</asp:Content>
