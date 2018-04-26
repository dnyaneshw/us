<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucForgotPassword.ascx.cs" Inherits="Insurance.UserControl.ucForgotPassword" %>

<asp:Panel ID="pnlForgetPass" runat="server">
    <hgroup class="title">
        <h1>Please enter your registered email to receive your password.</h1>
    </hgroup>

    <p class="validation-summary-errors">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <fieldset>
        <legend>Forgot Password</legend>
        <ol>
            <li>
                <asp:Label ID="Label1" runat="server" AssociatedControlID="txtForgotEmail">*Email :</asp:Label>
                <asp:TextBox ID="txtForgotEmail" runat="server" ToolTip="Email ID" onKeyDown="makefalse();"></asp:TextBox>
                <asp:RegularExpressionValidator CssClass="message-error" Display="Dynamic" ID="regemalid1" runat="server" ControlToValidate="txtForgotEmail" ErrorMessage="Please Enter Valid Email Address" ValidationExpression="^([A-Za-z0-9._%+-]+@(?:[A-Za-z0-9-]+\.)+[A-Za-z]{2,4}\r\n)*([A-Za-z0-9._%+-]+@(?:[A-Za-z0-9-]+\.)+[A-Za-z]{2,4})$" ValidationGroup="Forget"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator CssClass="message-error" Display="Dynamic" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtForgotEmail" ErrorMessage="Please Enter Email Address." ValidationGroup="Forget"></asp:RequiredFieldValidator>
            </li>
            <li><asp:Label ID="lblPopError" runat="server" Text=""></asp:Label></li>            
        </ol>
        <div>
            <asp:Button ID="btnForgotPass" runat="server" Text="Submit" OnClick="btnForgotPass_Click" ValidationGroup="Forget" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
        </div>
    </fieldset>
</asp:Panel>
