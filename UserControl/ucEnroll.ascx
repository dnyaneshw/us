<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucEnroll.ascx.cs" Inherits="Insurance.UserControl.ucEnroll" %>
<div>
    
        <h2>TO ENROLL PLEASE FILL IN ALL THE INFORMATION BELOW</h2>        
   
   
    <asp:Label ID="lblGoToLogin" Visible="false" runat="server" Text=""></asp:Label><br />
    <asp:LinkButton ID="lnkLogin" runat="server" Visible="false" PostBackUrl="~/Login.aspx" ToolTip="Go For Login">Go For Login</asp:LinkButton>
    <asp:Label ID="lblError" Visible="false" runat="server" Text=""></asp:Label>
    <asp:Label ID="Label15"  runat="server" Text=""></asp:Label>
    
    <fieldset>
        <legend>Registration Form</legend>
        <ol>
            <li><asp:Label ID="Label16" CssClass="message-error" runat="server" AssociatedControlID="txtFirstName">(* Required Fields )</asp:Label></li>
            <li>
                <asp:Label ID="Label1" runat="server" AssociatedControlID="txtFirstName">*First Name :</asp:Label>
                <asp:TextBox runat="server" ID="txtFirstName" onkeypress="return isNumberKey(event)"/>
                <asp:RequiredFieldValidator CssClass="message-error" Display="Dynamic" ID="rqfFN3" runat="server" ControlToValidate="txtFirstName" ErrorMessage="Please Enter First Name" ValidationGroup="REG"></asp:RequiredFieldValidator>
            </li>
            <li>
                <asp:Label ID="Label2" runat="server" AssociatedControlID="txtLastName">*Last Name :</asp:Label>
                <asp:TextBox ID="txtLastName" runat="server" ToolTip="Last Name" onKeyUp="return morethat256(this)" onkeypress="return isNumberKey(event)"></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="message-error" Display="Dynamic" ID="RequiredFieldValidator21" runat="server" ControlToValidate="txtLastName" ErrorMessage="Please Enter Last Name" ValidationGroup="REG"></asp:RequiredFieldValidator>
            </li>
            <li>
                <asp:Label ID="Label3" runat="server" AssociatedControlID="txtCompany">Company Name (If Any) :</asp:Label>
                <asp:TextBox ID="txtCompany" runat="server" ToolTip="Company Name"></asp:TextBox>
            </li>
            <li>
                <asp:Label ID="Label4" runat="server" AssociatedControlID="txtEmailID">*Email Address :</asp:Label>
                <asp:TextBox ID="txtEmailID" runat="server" ToolTip="Email Address"></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="message-error" Display="Dynamic" ID="RequiredFieldValidator24" runat="server" ControlToValidate="txtEmailID" ErrorMessage="Please Enter EmailID" ValidationGroup="REG"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator CssClass="message-error" Display="Dynamic" ID="regemalid3" runat="server" ControlToValidate="txtEmailID" ErrorMessage="Enter Valid Email Address" ValidationExpression="^([A-Za-z0-9._%+-]+@(?:[A-Za-z0-9-]+\.)+[A-Za-z]{2,4}\r\n)*([A-Za-z0-9._%+-]+@(?:[A-Za-z0-9-]+\.)+[A-Za-z]{2,4})$" ValidationGroup="REG"></asp:RegularExpressionValidator>
            </li>
            <li>
                <asp:Label ID="Label5" runat="server" AssociatedControlID="txtConfirmEmailID">Confirm Email Address :</asp:Label>
                <asp:TextBox ID="txtConfirmEmailID" runat="server" ToolTip="Confirm Email Address"></asp:TextBox>
                <asp:CompareValidator CssClass="message-error" Display="Dynamic" ID="CompareValidator1" runat="server" ControlToCompare="txtEmailID" ControlToValidate="txtConfirmEmailID" ErrorMessage="Email ID doesn't Match." ValidationGroup="REG"></asp:CompareValidator>
            </li>
            <li>
                <asp:Label ID="Label6" runat="server" AssociatedControlID="txtAddress">*Address :</asp:Label>
                <asp:TextBox ID="txtAddress" runat="server" ToolTip="Address"></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="message-error" Display="Dynamic" ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtAddress" ErrorMessage="Please Enter Address" ValidationGroup="REG"></asp:RequiredFieldValidator>
            </li>
            <li>
                <asp:Label ID="Label7" runat="server" AssociatedControlID="txtphoneNo">*Phone Number :</asp:Label>
                <asp:TextBox ID="txtphoneNo" runat="server" ToolTip="Phone Number" onKeyUp="return PhoneConvert(this);" onKeyDown="return isNumberValidKey(event)" ></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="message-error" Display="Dynamic" ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtphoneNo" ErrorMessage="Please Enter Phone Number" ValidationGroup="REG"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator CssClass="message-error" Display="Dynamic" ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtphoneNo" ErrorMessage="Enter 10 digit Phone Number" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}" ValidationGroup="REG"></asp:RegularExpressionValidator>
            </li>
            <li>
                <asp:Label ID="Label8" runat="server" AssociatedControlID="txtCity">*City :</asp:Label>
                <asp:TextBox ID="txtCity" runat="server" class="textfiled" ToolTip="City" ></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="message-error" Display="Dynamic" ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtCity" ErrorMessage="Please Enter City" ValidationGroup="REG"></asp:RequiredFieldValidator>
            </li>
            <li>
                <asp:Label ID="Label9" runat="server" AssociatedControlID="drpStates">*State :</asp:Label>
                <asp:DropDownList ID="drpStates" runat="server" ToolTip="State">
                    <asp:ListItem Value="select" Selected="True">--Select--</asp:ListItem>
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
                <asp:RequiredFieldValidator CssClass="message-error" Display="Dynamic" ID="RequiredFieldValidator1" runat="server" ControlToValidate="drpStates" InitialValue="select" ErrorMessage="Please select State" ValidationGroup="REG"></asp:RequiredFieldValidator>
            <asp:Label ID="lblState" CssClass="message-error" runat="server" Visible="False"></asp:Label>
            </li>
            <li>
                <asp:Label ID="Label10" runat="server" AssociatedControlID="txtZipCode">*Zip Code :</asp:Label>
                <asp:TextBox ID="txtZipCode" MaxLength="5" runat="server" onkeypress="return isNumberValidKey(event);" ToolTip="Zip Code"></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="message-error" Display="Dynamic" ID="RequiredFieldValidator25" runat="server" ControlToValidate="txtZipCode" ErrorMessage="Please Enter Zip Code" ValidationGroup="REG"></asp:RequiredFieldValidator>
            <asp:Label ID="lbl1" CssClass="message-error" runat="server" Text="" Visible="false"></asp:Label>
            </li>
            <li>
                <asp:Label ID="Label11" runat="server" AssociatedControlID="drpCompnyAffil">*Company Affiliation :</asp:Label>
                <asp:DropDownList ID="drpCompnyAffil" runat="server" ToolTip="Company Affiliation" ></asp:DropDownList>
                <asp:RequiredFieldValidator CssClass="message-error" Display="Dynamic" ID="RequiredFieldValidator2" runat="server" ControlToValidate="drpCompnyAffil" InitialValue="select" ErrorMessage="Please select Company Affiliation" ValidationGroup="REG"></asp:RequiredFieldValidator>

                <asp:Label ID="Lblcmpny" runat="server" CssClass="message-error" Text="" Visible="false"></asp:Label>
            </li>
            <li>
                <asp:Label ID="Label12" runat="server" AssociatedControlID="txtuserid">*Consultant ID :</asp:Label>
                <asp:TextBox ID="txtuserid" runat="server" class="textfiled" ToolTip="Consultant ID"></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="message-error" Display="Dynamic" ID="RequiredFieldValidator22" runat="server" ControlToValidate="txtuserid" ErrorMessage="Please Enter Consultant ID" ValidationGroup="REG"></asp:RequiredFieldValidator>
            </li>
            <li>                
                    <asp:Label ID="Label13" runat="server" AssociatedControlID="termCondition" Text="Terms and Conditions :"></asp:Label>
            </li>
            <li>
                <section style="border:1px solid Black; padding:2px" id="termCondition" runat="server">
                <p>
                    <b> Scope of coverage description:</b>
                    Premises and Operations General Liability excluding professional and products liability. Your property coverage protects your business property at your premises and while in transit. No Cell phone, computer or tablet coverage afforded.
Note: Applicant must have paid premium, be in good standing with the represented company and doing a function as a sales representative for that company at the time of loss.
                </p>
                <p>
                    <b>Coverage Territory:</b> Coverage is available in all 48 Continental United States and Alaska.
                </p>
                <p>
                   <b>Disclaimer:</b> 
Any person who knowingly and with intent to defraud any insurance company or another person files an application for insurance or statement of claim containing any materially false information, or conceals for the purpose of misleading information concerning any fact material thereto, commits a fraudulent insurance act, which is a crime and subject to criminal and (NY: substantial) Civil Penalties. (not applicable in CO,HI,NE,OH,OK,OR. or VT: in DC, LA, ME, TN and VA, insurance benefits may also be denied.)
                </p>
                    </section>
            </li>
            <li>
                <asp:CheckBox ID="chkAgree" runat="server"/>
                <asp:Label ID="Label14" runat="server" >* I have Read and Agree with the Terms and Conditions Above</asp:Label>
                <asp:Label ID="lblAgreeError" runat="server" CssClass="message-error" Visible="false"></asp:Label>
            </li>
        </ol>
    </fieldset>
</div>