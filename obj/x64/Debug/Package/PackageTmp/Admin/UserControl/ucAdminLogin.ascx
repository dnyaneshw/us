<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucAdminLogin.ascx.cs" Inherits="Insurance.Admin.UserControl.ucAdminLogin" %>

<hgroup class="title">
        <h1>Login Administrator</h1>
    </hgroup>
    <p class="validation-summary-errors">
        <asp:Label ID="lblError" runat="server" ></asp:Label>
    </p>
<asp:Login ID="login1" runat="server" ViewStateMode="Disabled" RenderOuterTable="false" FailureText="">
            <LayoutTemplate>                
                <fieldset>
                    <legend>Login Administrator</legend>
                    <ol>                                          
                        <li>
                            <asp:Label ID="Label1" runat="server" AssociatedControlID="UserName">*User name</asp:Label>
                            <asp:TextBox runat="server" ID="UserName" />
                            <asp:RequiredFieldValidator CssClass="message-error" Display="Dynamic" ID="RequiredFieldValidator1" runat="server" ControlToValidate="UserName" ErrorMessage="The user name field is required." />
                        </li>
                        <li>
                            <asp:Label ID="Label2" runat="server" AssociatedControlID="Password">*Password</asp:Label>
                            <asp:TextBox runat="server" ID="Password" TextMode="Password" />
                            <asp:RequiredFieldValidator CssClass="message-error" Display="Dynamic" ID="RequiredFieldValidator2" runat="server" ControlToValidate="Password" ErrorMessage="The password field is required." />
                        </li>                        
                    </ol>
                    <asp:Button ID="btnAdminLogin" runat="server" CommandName="Login" Text="Log in" OnClick="btnAdminLogin_Click" />
                </fieldset>
            </LayoutTemplate>
        </asp:Login>