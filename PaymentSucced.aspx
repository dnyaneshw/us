<%@ Page Title="Welcome to dscoverage.com - Payment" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PaymentSucced.aspx.cs" Inherits="Insurance.PaymentSucced" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Insurance - Payment</title>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div>     
    <p class="validation-summary-errors">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <fieldset>
        <legend>Registration Form</legend>
        <ol>
            <li>
<asp:Label ID="lblMessage" style="margin-top:30px; font-size:14px;  font-family:Tahoma; font-weight: normal;"  runat="server" Text="" ForeColor="#5C5B5B" ></asp:Label>
<asp:Label ID="lblMessage1" style="margin-top:30px; font-size:14px;  font-family:Tahoma; font-weight: normal;"  runat="server" Text="" ForeColor="#5C5B5B" ></asp:Label>
<span id="idspan" runat="server" visible="false" style="margin-top:30px; font-size:14px;  font-family:Tahoma; font-weight: normal;"  Text="" ForeColor="#5C5B5B">
Please click <asp:LinkButton ID="lnkEve"  runat="server" Onclick="lnkEve_Click">here </asp:LinkButton> to download or print your Evidence of Coverage. A link to your evidence has also been sent to your registered email address</span>
</li></ol></fieldset></div>
</asp:Content>
