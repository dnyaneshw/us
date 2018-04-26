<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucCustomerInformation.ascx.cs" Inherits="Insurance.Admin.UserControl.ucCustomerInformation" %>
<div>
    <hgroup class="title">
        <h1>Customer Information</h1>
    </hgroup>

    <p class="validation-summary-errors">
        <asp:Literal runat="server" ID="ErrorMessage" />
        <asp:Label ID="lblError" runat="server" ></asp:Label>
    </p>

    <fieldset>
        <legend>Customer Information Form</legend>
        <ol>
            <li>
                <asp:Label ID="Label1" runat="server" AssociatedControlID="txtFirstName">*First Name :</asp:Label>
                <asp:TextBox runat="server" ID="txtFirstName" onkeypress="return isNumberKey(event)" />
                <asp:RequiredFieldValidator ID="rqfFN3" CssClass="message-error" Display="Dynamic" runat="server" ControlToValidate="txtFirstName" ErrorMessage="Please Enter First Name" ValidationGroup="REG"></asp:RequiredFieldValidator>
            </li>
            <li>
                <asp:Label ID="Label2" runat="server" AssociatedControlID="txtLastName">*Last Name :</asp:Label>
                <asp:TextBox ID="txtLastName" runat="server" ToolTip="Last Name" onkeypress="return isNumberKey(event)" ></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="message-error" Display="Dynamic" ID="RequiredFieldValidator21" runat="server" ControlToValidate="txtLastName" ErrorMessage="Please Enter Last Name" ValidationGroup="REG"></asp:RequiredFieldValidator>
            </li>
            <li>
                <asp:Label ID="Label3" runat="server" AssociatedControlID="txtCustomerID">Customer ID :</asp:Label>                
                <asp:TextBox ID="txtCustomerID" runat="server" ToolTip="Customer ID" Enabled="False"></asp:TextBox>
            </li>
            <li><asp:Label ID="Label4" runat="server" AssociatedControlID="txtCompany">Company Name :</asp:Label>
                <asp:TextBox ID="txtCompany" runat="server" ToolTip="Company Name"></asp:TextBox></li>
            <li>
                <asp:Label ID="Label5" runat="server" AssociatedControlID="txtEmailID">*Email Address :</asp:Label>
                <asp:TextBox ID="txtEmailID" runat="server" ToolTip="Email Address"></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="message-error" Display="Dynamic" ID="RequiredFieldValidator24" runat="server" ControlToValidate="txtEmailID" ErrorMessage="Please Enter EmailID" ValidationGroup="REG"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator CssClass="message-error" Display="Dynamic" ID="regemalid3" runat="server" ControlToValidate="txtEmailID" ErrorMessage="Enter Valid Email Address" ValidationExpression="^([A-Za-z0-9._%+-]+@(?:[A-Za-z0-9-]+\.)+[A-Za-z]{2,4}\r\n)*([A-Za-z0-9._%+-]+@(?:[A-Za-z0-9-]+\.)+[A-Za-z]{2,4})$" ValidationGroup="REG"></asp:RegularExpressionValidator>
            </li>
            <li>
                <asp:Label ID="Label7" runat="server" AssociatedControlID="txtphoneNo">*Phone Number :</asp:Label>
                <asp:TextBox ID="txtphoneNo" onKeyUp="return PhoneConvert(this);" onKeyDown="return isNumberValidKey(event)" runat="server" ToolTip="Phone Number"></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="message-error" Display="Dynamic" ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtphoneNo" ErrorMessage="Please Enter Phone Number" ValidationGroup="REG"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator CssClass="message-error" Display="Dynamic" ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtphoneNo" ErrorMessage="Enter 10 digit Phone Number" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}" ValidationGroup="REG"></asp:RegularExpressionValidator>
            </li>
            <li>
                <asp:Label ID="Label6" runat="server" AssociatedControlID="txtAddress">*Address :</asp:Label>
                <asp:TextBox ID="txtAddress" runat="server" ToolTip="Address"></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="message-error" Display="Dynamic" ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtAddress" ErrorMessage="Please Enter Address" ValidationGroup="REG"></asp:RequiredFieldValidator>
            </li>
            <li>
                <asp:Label ID="Label8" runat="server" AssociatedControlID="txtCity">*City :</asp:Label>
                <asp:TextBox ID="txtCity" runat="server" class="textfiled" ToolTip="City" ></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="message-error" Display="Dynamic" ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtCity" ErrorMessage="Please Enter City" ValidationGroup="REG"></asp:RequiredFieldValidator>
            </li>
            <li>
                <asp:Label ID="Label9" runat="server" AssociatedControlID="drpStates">*State :</asp:Label>
                <asp:DropDownList ID="drpStates" runat="server" ToolTip="State">
                    <asp:ListItem Value="Select" Text="--Select--" Selected="True"></asp:ListItem>
                    <asp:ListItem Value="AL">AL</asp:ListItem>
                    <asp:ListItem Value="AK">AK</asp:ListItem>
                    <asp:ListItem Value="AZ">AZ</asp:ListItem>
                    <asp:ListItem Value="AR">AR</asp:ListItem>
                    <asp:ListItem Value="CA">CA</asp:ListItem>
                    <asp:ListItem Value="CO">CO</asp:ListItem>
                    <asp:ListItem Value="CT">CT</asp:ListItem>
                    <asp:ListItem Value="DE">DE</asp:ListItem>
                    <asp:ListItem Value="DC">DC</asp:ListItem>
                    <asp:ListItem Value="FL">FL</asp:ListItem>
                    <asp:ListItem Value="GA">GA</asp:ListItem>
                    <asp:ListItem Value="HI">HI</asp:ListItem>
                    <asp:ListItem Value="ID">ID</asp:ListItem>
                    <asp:ListItem Value="IL">IL</asp:ListItem>
                    <asp:ListItem Value="IN">IN</asp:ListItem>
                    <asp:ListItem Value="IA">IA</asp:ListItem>
                    <asp:ListItem Value="KS">KS</asp:ListItem>
                    <asp:ListItem Value="KY">KY</asp:ListItem>
                    <asp:ListItem Value="LA">LA</asp:ListItem>
                    <asp:ListItem Value="ME">ME</asp:ListItem>
                    <asp:ListItem Value="MD">MD</asp:ListItem>
                    <asp:ListItem Value="MA">MA</asp:ListItem>
                    <asp:ListItem Value="MI">MI</asp:ListItem>
                    <asp:ListItem Value="MN">MN</asp:ListItem>
                    <asp:ListItem Value="MS">MS</asp:ListItem>
                    <asp:ListItem Value="MO">MO</asp:ListItem>
                    <asp:ListItem Value="MT">MT</asp:ListItem>
                    <asp:ListItem Value="NE">NE</asp:ListItem>
                    <asp:ListItem Value="NV">NV</asp:ListItem>
                    <asp:ListItem Value="NH">NH</asp:ListItem>
                    <asp:ListItem Value="NJ">NJ</asp:ListItem>
                    <asp:ListItem Value="NM">NM</asp:ListItem>
                    <asp:ListItem Value="NY">NY</asp:ListItem>
                    <asp:ListItem Value="NC">NC</asp:ListItem>
                    <asp:ListItem Value="ND">ND</asp:ListItem>
                    <asp:ListItem Value="OH">OH</asp:ListItem>
                    <asp:ListItem Value="OK">OK</asp:ListItem>
                    <asp:ListItem Value="OR">OR</asp:ListItem>
                    <asp:ListItem Value="PA">PA</asp:ListItem>
                    <asp:ListItem Value="RI">RI</asp:ListItem>
                    <asp:ListItem Value="SC">SC</asp:ListItem>
                    <asp:ListItem Value="SD">SD</asp:ListItem>
                    <asp:ListItem Value="TN">TN</asp:ListItem>
                    <asp:ListItem Value="TX">TX</asp:ListItem>
                    <asp:ListItem Value="UT">UT</asp:ListItem>
                    <asp:ListItem Value="VT">VT</asp:ListItem>
                    <asp:ListItem Value="VA">VA</asp:ListItem>
                    <asp:ListItem Value="WA">WA</asp:ListItem>
                    <asp:ListItem Value="WV">WV</asp:ListItem>
                    <asp:ListItem Value="WI">WI</asp:ListItem>
                    <asp:ListItem Value="WY">WY</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator CssClass="message-error" Display="Dynamic" ID="RequiredFieldValidator1" runat="server" ControlToValidate="drpStates" InitialValue="Select" ErrorMessage="Please select State" ValidationGroup="REG"></asp:RequiredFieldValidator>
            </li>
            <li>
                <asp:Label ID="Label10" runat="server" AssociatedControlID="txtZipCode">*Zip Code :</asp:Label>
                <asp:TextBox ID="txtZipCode" MaxLength="5" runat="server" onkeypress="return isNumberValidKey(event);" ToolTip="Zip Code"></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="message-error" Display="Dynamic" ID="RequiredFieldValidator25" runat="server" ControlToValidate="txtZipCode" ErrorMessage="Please Enter Zip Code" ValidationGroup="REG"></asp:RequiredFieldValidator>
            </li>
            <li>
                <asp:Label ID="Label11" runat="server" AssociatedControlID="txtCountry">*Country :</asp:Label>
                <asp:TextBox ID="txtCountry" runat="server" ToolTip="Country"></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="message-error" Display="Dynamic" ID="rqfFN6" runat="server" ControlToValidate="txtCountry"
                    ErrorMessage="Please Enter Country" ValidationGroup="REG"></asp:RequiredFieldValidator>
            </li>
            <li>
                <asp:Label ID="Label12" runat="server" AssociatedControlID="drpCompnyAffil">*Company Affiliation :</asp:Label>
                <asp:DropDownList ID="drpCompnyAffil" runat="server" ToolTip="Company Affiliation" >
                </asp:DropDownList>
                <asp:RequiredFieldValidator CssClass="message-error" Display="Dynamic" ID="RequiredFieldValidator2" runat="server" ControlToValidate="drpCompnyAffil" InitialValue="Select" ErrorMessage="Please select Company Affiliation" ValidationGroup="REG"></asp:RequiredFieldValidator>

            </li>
            <li>                
                <asp:Label ID="Label13" runat="server" AssociatedControlID="txtSecCode">*Security Code :</asp:Label>
                <asp:TextBox ID="txtSecCode" runat="server" ToolTip="Security Code"></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="message-error" Display="Dynamic" ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtSecCode"
                    ErrorMessage="Please Enter Security Code" ValidationGroup="REG"></asp:RequiredFieldValidator>
            </li>
            <li>
                <asp:Label ID="Label14" runat="server" AssociatedControlID="txtApplicationNo">Application Number :</asp:Label>                
                 <asp:TextBox ID="txtApplicationNo" runat="server" ToolTip="Application Number" Enabled="False"></asp:TextBox>
            </li>
            <li>
                <asp:CheckBox ID="chkIsActivePolicy" runat="server" />
                <asp:Label ID="Label15" runat="server" Font-Bold="true" >Is Policy Active?? :</asp:Label>                
            </li>
            <li>
                <asp:CheckBox ID="chkIsActive" runat="server" />
                <asp:Label ID="Label16" runat="server" Font-Bold="true" >Is Customer Active?? :</asp:Label>
            </li>
        </ol>
    </fieldset>
    <div>
         <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" ValidationGroup="REG" />
        <asp:Button ID="btnEvidanceCertificate" runat="server" Text="Evidances & Certificates" ValidationGroup="REG" OnClick="btnEvidanceCertificate_Click" />
    </div>


    <asp:TextBox ID="txtPayment" Visible="false" runat="server" ToolTip="Payment"></asp:TextBox>
    <asp:TextBox ID="txtpersonalid" Visible="false" runat="server"></asp:TextBox>
    <asp:TextBox ID="txtSignup" CssClass="login" Visible="false" runat="server"></asp:TextBox>
    <asp:CheckBox ID="chkIscedeSent" Visible="false" runat="server" />
    <asp:CheckBox ID="chkVerify" Visible="false" runat="server" />


</div>
