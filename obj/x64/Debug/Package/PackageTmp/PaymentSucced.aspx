<%@ Page Title="Welcome to dscoverage.com - Payment status Information " Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PaymentSucced.aspx.cs" Inherits="Insurance.PaymentSucced" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div>
     <hgroup class="title">
             <h1>Payment status Information !!</h1>
        </hgroup>

    <p class="validation-summary-errors">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <fieldset>
        <legend>Registration Form</legend>
        <ol>
            <li>
<asp:Label ID="lblMessage" runat="server" ></asp:Label>
<asp:Label ID="lblMessage1" runat="server"></asp:Label>
<span id="idspan" runat="server" visible="false">
Please click <asp:LinkButton ID="lnkEve"  runat="server" Onclick="lnkEve_Click">here </asp:LinkButton> to download or print your Evidence of Coverage. A link to your evidence has also been sent to your registered email address</span>
</li></ol></fieldset></div>
</asp:Content>
