<%@ Page Title="Welcome to dscoverage.com - Change Password" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="Insurance.Account.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <hgroup class="title">
        <h1>Change Password :</h1>
    </hgroup>
    <fieldset>
        <legend>Change Password :</legend>
        <ol>
             <li>
                 <asp:Label ID="lblChangePassError" runat="server" ></asp:Label>                
            </li>
            <li>
                <asp:Label ID="Label1" runat="server" AssociatedControlID="txtCurrentPass">*Current Password :</asp:Label>                
                <asp:TextBox ID="txtCurrentPass" TextMode="Password" runat="server" ToolTip="Current Password" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCurrentPass" ErrorMessage="Enter Current Password" ValidationGroup="ChangePass"></asp:RequiredFieldValidator>

            </li>
            <li>
                 <asp:Label ID="Label2" runat="server" AssociatedControlID="txtNewPass">*New Password :</asp:Label>                
                <asp:TextBox ID="txtNewPass" TextMode="Password" runat="server" ToolTip="New Password" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtNewPass" runat="server" ErrorMessage="Enter New Password" ValidationGroup="ChangePass"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="txtNewPass" ErrorMessage="Please Enter at least 8 characters one digit and one special character" ValidationExpression="^(?=.*\d)(?=.*[a-z])(?=.*[\W]).{8,20}$" ValidationGroup="REG" ></asp:RegularExpressionValidator>
           
            </li>
            <li>
                <asp:Label ID="Label3" runat="server" AssociatedControlID="txtConfirmPass">*Confirm Password :</asp:Label>                
                <asp:TextBox ID="txtConfirmPass" TextMode="Password" runat="server" ToolTip="Confirm Password" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtConfirmPass" ErrorMessage="Enter Confirm Password" ValidationGroup="ChangePass"></asp:RequiredFieldValidator>
               <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtNewPass" ControlToValidate="txtConfirmPass" ErrorMessage="Password doesn't Match." ValidationGroup="ChangePass"></asp:CompareValidator>
            </li>
        </ol>
    </fieldset>
    <div><asp:Button ID="btnChangePass" runat="server" ValidationGroup="ChangePass" Text="Submit" ToolTip="Change password" OnClick="btnChangePass_Click" /></div>
</asp:Content>
