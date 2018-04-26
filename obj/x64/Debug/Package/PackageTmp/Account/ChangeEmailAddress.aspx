<%@ Page Title="Welcome to dscoverage.com - Change Email Address" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangeEmailAddress.aspx.cs" Inherits="Insurance.Account.ChangeEmailAddress" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <hgroup class="title">
        <h1>Change Email Address :</h1>
    </hgroup>
        
    <fieldset>
        <legend>Change Email Address :</legend>
        <ol>
            <li> <asp:Label ID="lblEmailError" runat="server" Text=""></asp:Label></li>
            <li>
                <asp:Label ID="Label1" runat="server" AssociatedControlID="txtCurrentEmail">*Current Email Address :</asp:Label>
               <asp:TextBox ID="txtCurrentEmail" runat="server" ToolTip="Current Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtCurrentEmail" ErrorMessage="Enter Current Email Address" ValidationGroup="ChangeEmail"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="regemalid4" runat="server" ControlToValidate="txtCurrentEmail" ErrorMessage="Enter Valid Email Address" ValidationExpression="^([A-Za-z0-9._%+-]+@(?:[A-Za-z0-9-]+\.)+[A-Za-z]{2,4}\r\n)*([A-Za-z0-9._%+-]+@(?:[A-Za-z0-9-]+\.)+[A-Za-z]{2,4})$" ValidationGroup="ChangeEmail"></asp:RegularExpressionValidator>
            </li>
            <li>
                <asp:Label ID="Label2" runat="server" AssociatedControlID="txtNewEmail">*New Email Address :</asp:Label>                
                <asp:TextBox ID="txtNewEmail" runat="server" ToolTip="New Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtNewEmail" ErrorMessage="Enter New Email Address" ValidationGroup="ChangeEmail"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="regemalid5" runat="server" ControlToValidate="txtNewEmail" ErrorMessage="Enter Valid Email Address" ValidationExpression="^([A-Za-z0-9._%+-]+@(?:[A-Za-z0-9-]+\.)+[A-Za-z]{2,4}\r\n)*([A-Za-z0-9._%+-]+@(?:[A-Za-z0-9-]+\.)+[A-Za-z]{2,4})$" ValidationGroup="ChangeEmail"></asp:RegularExpressionValidator>
            </li>
            <li>
                <asp:Label ID="Label3" runat="server" AssociatedControlID="txtConfirmEmail">*Confirm Email Address :</asp:Label> 
                <asp:TextBox ID="txtConfirmEmail" runat="server" ToolTip="Confirm Email Address"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtConfirmEmail" ErrorMessage="Enter Confirm Email Address" ValidationGroup="ChangeEmail"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="txtNewEmail" ControlToValidate="txtConfirmEmail" ErrorMessage="Email Address doesn't Match." ValidationGroup="ChangeEmail"></asp:CompareValidator>
            </li>           
        </ol>
    </fieldset>
    <div><asp:Button ID="btnEmail" runat="server" ValidationGroup="ChangeEmail" Text="Submit" ToolTip="Change Eamil Address" OnClick="btnEmail_Click" /></div>
</asp:Content>