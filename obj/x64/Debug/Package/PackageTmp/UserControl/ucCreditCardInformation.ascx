<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucCreditCardInformation.ascx.cs" Inherits="Insurance.UserControl.ucCreditCardInformation" %>
<div>
    <hgroup class="title">
        <h1>Please enter your Credit card information Below</h1>
    </hgroup>
    <p class="validation-summary-errors">
        <asp:Literal runat="server" ID="ErrorMessage" />
        <asp:Label ID="lblError1" runat="server" Text=""></asp:Label>
    </p>
    <fieldset>
        <legend>Please enter your Credit card information Below:</legend>
        <ol>
            <li>
                <asp:Label ID="Label1" runat="server" AssociatedControlID="lblAmount">Amount to Charge :</asp:Label>
                <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="$"></asp:Label>
                <asp:Label ID="lblAmount" runat="server" ForeColor="Red"></asp:Label>
            </li>
            <li>
                <asp:Label ID="Label3" runat="server" AssociatedControlID="Image1">Accepted Cards :</asp:Label>
                <asp:Image ID="Image1" CssClass="img-responsive" runat="server" ImageUrl="~/images/CreditCardsUse.png" />
            </li>
            <li>
                <asp:Label ID="Label4" runat="server" AssociatedControlID="ddlCardType">*Card Type :</asp:Label>
                <asp:DropDownList class="textfiled" ID="ddlCardType" runat="server" ToolTip="Card Type">
                    <asp:ListItem Selected="True">--Select--</asp:ListItem>
                    <asp:ListItem>MasterCard</asp:ListItem>
                    <asp:ListItem>Visa</asp:ListItem>
                    <asp:ListItem Value="AMEX">American Express</asp:ListItem>
                    <asp:ListItem>Diners Club/Carte Blanche</asp:ListItem>
                    <asp:ListItem>Second Visa</asp:ListItem>
                    <asp:ListItem>Discover</asp:ListItem>
                    <asp:ListItem>JCB</asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="lbl4" CssClass="message-error" runat="server" Text="" Visible="false"></asp:Label>
            </li>
            <li>
                <asp:Label ID="Label5" runat="server" AssociatedControlID="txtCardNo">*Card Number :</asp:Label>
                <asp:TextBox ID="txtCardNo" autocomplete="off" runat="server" ToolTip="Card Number" onkeypress="return isNumberValidKey(event);"></asp:TextBox>
                <asp:Label ID="lblcheck" runat="server" CssClass="message-error" ></asp:Label>
                <asp:RequiredFieldValidator ID="rqfFN0" CssClass="message-error" Display="Dynamic" runat="server" ControlToValidate="txtCardNo" ErrorMessage="Enter Valid Card Number" ValidationGroup="REGPay"></asp:RequiredFieldValidator>
            </li>
            <li>
                <asp:Label ID="Label6" runat="server" AssociatedControlID="txtCardFirstName">*Name on Card :</asp:Label>
                <asp:TextBox ID="txtCardFirstName" autocomplete="off" runat="server" ToolTip="First Name on Card" onkeypress="return isNumberKey(event);" onKeyUp="return morethat256(this)"></asp:TextBox>
                <asp:TextBox ID="txtCardLastName" autocomplete="off" runat="server" ToolTip="Last Name on Card" onkeypress="return isNumberKey(event);" onKeyUp="return morethat256(this)"></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="message-error" Display="Dynamic" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCardFirstName" ErrorMessage="Enter Card First Name" ValidationGroup="REGPay"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator CssClass="message-error" Display="Dynamic" ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCardLastName" ErrorMessage="Enter Card Last Name" ValidationGroup="REGPay"></asp:RequiredFieldValidator>
             <asp:Label ID="lbl3" runat="server" CssClass="message-error" Visible="false"></asp:Label>
            </li>
            <li>
                <asp:Label ID="Label7" runat="server" AssociatedControlID="ddlMonth">*Expiration :</asp:Label>
                <asp:DropDownList ID="ddlMonth" runat="server" ToolTip="Expiration Month"></asp:DropDownList>
                <asp:DropDownList ID="ddlYear" runat="server" ToolTip="Expiration Year"></asp:DropDownList>
                <asp:Label ID="lbl5" runat="server" CssClass="message-error" Visible="false"></asp:Label>
            </li>
            <li>
                <asp:Label ID="Label8" runat="server" AssociatedControlID="txtPCity">*City :</asp:Label>
                <asp:TextBox ID="txtPCity" autocomplete="off" runat="server" ToolTip="City"></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="message-error" Display="Dynamic" ID="rqfFN1" runat="server" ControlToValidate="txtPCity" ErrorMessage="Please Enter City" ValidationGroup="REGPay"></asp:RequiredFieldValidator>
            </li>
            <li>
                <asp:Label ID="Label9" runat="server" AssociatedControlID="txtPZip">*Zip :</asp:Label>
                <asp:TextBox ID="txtPZip" autocomplete="off" MaxLength="5" onkeypress="return isNumberValidKey(event);" runat="server" ToolTip="Zip"></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="message-error" Display="Dynamic" ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtPZip"
                    ErrorMessage="Please Enter Zip Code" ValidationGroup="REGPay"></asp:RequiredFieldValidator>
                <asp:Label ID="lbl2" runat="server" CssClass="message-error" Visible="false"></asp:Label>
            </li>
            <li>
                <asp:Label ID="Label10" runat="server" AssociatedControlID="txtPEmail">*Email :</asp:Label>
                <asp:TextBox ID="txtPEmail" autocomplete="off" runat="server" ToolTip="Email"></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="message-error" Display="Dynamic" ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtPEmail" ErrorMessage="Please Enter EmailID" ValidationGroup="REGPay"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator CssClass="message-error" Display="Dynamic" ID="regemalid2" runat="server" ControlToValidate="txtPEmail" ErrorMessage="Please Enter Valid Email Address"
                    ValidationExpression="^([A-Za-z0-9._%+-]+@(?:[A-Za-z0-9-]+\.)+[A-Za-z]{2,4}\r\n)*([A-Za-z0-9._%+-]+@(?:[A-Za-z0-9-]+\.)+[A-Za-z]{2,4})$"
                    ValidationGroup="REGPay"></asp:RegularExpressionValidator>
                <asp:Label ID="lbl6" runat="server" ForeColor="Red" Text="" Visible="false"></asp:Label>
            </li>            
        </ol>
    </fieldset>
</div>
