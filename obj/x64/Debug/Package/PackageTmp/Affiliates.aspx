<%@ Page Title="Welcome to dscoverage.com - Affiliates" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Affiliates.aspx.cs" Inherits="Insurance.Affiliates" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <hgroup class="title">
            <h1>Affiliates :</h1>
        </hgroup>
    </div>
    <div class="content-wrapper">
        <ul>
            <li class="nav navbar-nav" style="padding:5px">
                <asp:ImageButton Height="200" PostBackUrl="http://www.dsassured.com/" AlternateText="www.assured.com" ImageUrl="~/Images/IDS_Logo.jpg" ID="lnkSite" runat="server" />
            </li>
            <li class="nav navbar-nav" style="padding:5px">
                <asp:ImageButton Height="200" PostBackUrl="http://www.waddellinsurance.com/" AlternateText="www.waddellinsurance.com" ImageUrl="~/Images/WaddellInsurance.jpg" ID="lnkWaddellInsurance" runat="server" />
            </li>
            <li class="nav navbar-nav" style="padding:5px">
             <asp:ImageButton PostBackUrl="http://www.atainins.com/" AlternateText="www.atainins.com" Height="200" ImageUrl="~/Images/Atainlogo.jpg" ID="lnkAtainlogo" runat="server" />   
            </li>
        </ul>
    </div>
</asp:Content>
