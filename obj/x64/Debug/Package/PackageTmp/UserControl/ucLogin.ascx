<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucLogin.ascx.cs" Inherits="Insurance.UserControl.ucLogin" %>
<h1>Login</h1>

<p class="validation-summary-errors">
    <asp:Literal runat="server" ID="ErrorMessage" />
</p>
<fieldset>
    <legend>Login </legend>
    <ol>
        <li><asp:Label ID="lblError" runat="server"></asp:Label></li>
        <li>
            <asp:Label ID="Label1" runat="server" AssociatedControlID="txtUsername">*Email :</asp:Label>
            <asp:TextBox ID="txtUsername" autocomplete="off" AutoCompleteType="None" runat="server" ToolTip="User Name"></asp:TextBox>        
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="message-error" Display="Dynamic" runat="server" ControlToValidate="txtUsername" ErrorMessage="Please Enter Email Address." ></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="regemalid1" runat="server" CssClass="message-error" Display="Dynamic" ControlToValidate="txtUsername" ErrorMessage="Please Enter Valid Email Address" ValidationExpression="^([A-Za-z0-9._%+-]+@(?:[A-Za-z0-9-]+\.)+[A-Za-z]{2,4}\r\n)*([A-Za-z0-9._%+-]+@(?:[A-Za-z0-9-]+\.)+[A-Za-z]{2,4})$" ></asp:RegularExpressionValidator>
        </li>
        <li>
            <asp:Label ID="Label2" runat="server" AssociatedControlID="txtSecuCode">*Password :</asp:Label>
            <asp:TextBox ID="txtSecuCode" autocomplete="off" runat="server" AutoCompleteType="None" ToolTip="Security Code" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="message-error" Display="Dynamic" ControlToValidate="txtSecuCode" ErrorMessage="Please Enter Password." ></asp:RequiredFieldValidator>
            
        </li>
        <li>
            <asp:LinkButton ID="lnkForgetPass" CausesValidation="false" runat="server" OnClick="lnkForgetPass_Click">Forgot your password?</asp:LinkButton>
        </li>
    </ol>
    <div><asp:Button ID="btnLogin" runat="server" Text="Sign In" OnClick="btnLogin_Click" /></div>
</fieldset>