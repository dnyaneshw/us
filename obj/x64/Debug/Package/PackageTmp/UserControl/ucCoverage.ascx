<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucCoverage.ascx.cs" Inherits="Insurance.UserControl.ucCoverage" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<hgroup class="title">            
<h1>Please fill in all the information below to generate evidence:</h1>
</hgroup>

        <p class="validation-summary-errors">
            <asp:Literal runat="server" ID="ErrorMessage" />
        </p>


<fieldset>
            <legend>Registration Form</legend>
<ol>
    <li>
        <asp:Label ID="lbl" runat="server" Visible="false" />
        <asp:Label ID="lblPayment" runat="server" Visible="false" />
        <asp:Label ID="lblEmailValidate" Visible="false" runat="server" Text="Please Verify Your Email before go to Next Step." />
    </li>    
    <li>
        <asp:Label ID="Label1" runat="server" AssociatedControlID="txtCovrageDate">Coverage Start Date :</asp:Label>
        <asp:TextBox Enabled="false" ID="txtCovrageDate" runat="server" ToolTip="Coverage Start Date" autocomplete="off" onkeypress="return isKey(event)" /> 
        <asp:Label ID="lblCoverageDate" ToolTip="Coverage Start Date" runat="server"></asp:Label>
        <asp:CalendarExtender ID="txtCovrageDate_CalendarExtender" runat="server" Enabled="True" Format="MM/dd/yyyy" PopupPosition="BottomLeft" TargetControlID="txtCovrageDate" PopupButtonID="txtCovrageDate" />       
    </li>
    <li>
        <asp:CheckBox ID="chk5yrs" runat="server" />
        <asp:Label ID="Label3" runat="server" Font-Bold="true" >CHECK HERE IF YOU HAVE HAD A LIABILITY CLAIM IN THE LAST 5 YEARS?</asp:Label>
    </li>
    <li>
        <asp:CheckBox ID="chk3yrs" runat="server" />
        <asp:Label ID="Label2" runat="server" Font-Bold="true" >CHECK HERE IF YOU HAVE HAD A BUSINESS PROPERTY LOSS EXCEEDING $1,000 IN THE LAST 3 YEARS?</asp:Label>
    </li>
    <li>
        <asp:Label ID="lblError0" runat="server" />
    </li>   
</ol>
    </fieldset>

       