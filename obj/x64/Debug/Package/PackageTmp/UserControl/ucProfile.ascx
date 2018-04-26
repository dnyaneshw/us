<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucProfile.ascx.cs" Inherits="Insurance.UserControl.ucProfile" %>

<hgroup class="title">
    <h1>Your Profile :</h1>
</hgroup>
<asp:Panel ID="pnlEditProfile" runat="server" >
<fieldset>
    <legend>Change Email Address :</legend>
    <ol>
        <li><asp:Label ID="lblError" runat="server"></asp:Label></li>
        <li>
            <asp:Label ID="Label1" runat="server" AssociatedControlID="txtFname">Name :</asp:Label>             
                <asp:TextBox ID="txtFname" Enabled="false" ReadOnly="true" runat="server" ToolTip="First Name" ></asp:TextBox>
            <asp:TextBox ID="txtLname" Enabled="false" ReadOnly="true" runat="server" ToolTip="Last Name" ></asp:TextBox>
        </li>
         <li>
             <asp:Label ID="Label2" runat="server" AssociatedControlID="txtCompany">Company Name :</asp:Label>              
                <asp:TextBox ID="txtCompany" Enabled="false" ReadOnly="true" runat="server" ToolTip="Company Name" ></asp:TextBox>
         </li>
         <li>
             <asp:Label ID="Label3" runat="server" AssociatedControlID="txtAddress">Address :</asp:Label>
             <asp:TextBox ID="txtAddress" runat="server" ToolTip="Address" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="rqfFN2" runat="server" ControlToValidate="txtAddress" ErrorMessage="Please Enter Address"  ValidationGroup="REG"></asp:RequiredFieldValidator>
         </li>
         <li>
             <asp:Label ID="Label4" runat="server" AssociatedControlID="txtCity">City :</asp:Label>
                <asp:TextBox ID="txtCity" runat="server" ToolTip="City" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="rqfFN3" runat="server" ControlToValidate="txtCity" ErrorMessage="Please Enter City" ValidationGroup="REG"></asp:RequiredFieldValidator>
         </li>
         <li>
             <asp:Label ID="Label5" runat="server" AssociatedControlID="drpStates">State :</asp:Label>
            <asp:DropDownList ID="drpStates" runat="server" >
                    <asp:ListItem Selected="True" Value="select">--Select--</asp:ListItem>
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
                <asp:Label ID="lblStaterror" runat="server" Visible="False"></asp:Label>

         </li>
        <li>
            <asp:Label ID="Label9" runat="server" AssociatedControlID="ddlCompanyAffil">Company Affiliation :</asp:Label>
            <asp:DropDownList ID="ddlCompanyAffil" runat="server" Enabled="false" ></asp:DropDownList>
        </li>
        <li>
            <asp:Label ID="Label10" runat="server" AssociatedControlID="txtEmailID">Email ID :</asp:Label>
            <asp:TextBox ID="txtEmailID" Enabled="false" ReadOnly="true" runat="server" ToolTip="Email ID "></asp:TextBox>
        </li>
         <li>
              <asp:Label ID="Label6" runat="server" AssociatedControlID="txtZipCode">Zip Code :</asp:Label>
                <asp:TextBox ID="txtZipCode" runat="server" ToolTip="Zip Code" MaxLength="5" onkeypress="return isNumberValidKey(event);" class="textfiled"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rqfFN5" runat="server" ControlToValidate="txtZipCode" ErrorMessage="Please Enter Zip Code" ValidationGroup="REG"></asp:RequiredFieldValidator>
                <asp:Label ID="lbl1" runat="server" Text="" Visible="false"></asp:Label>
         </li>
         <li>
                <asp:Label ID="Label7" runat="server" AssociatedControlID="txtPhone">Phone Number :</asp:Label>
                <asp:TextBox ID="txtPhone" runat="server" ToolTip="Phone Number" onKeyUp="return PhoneConvert(this);" onKeyDown="return isNumberValidKey(event)"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtPhone" ErrorMessage="Please Enter Phone Number" ValidationGroup="REG"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txtPhone" ErrorMessage="Enter 10 digit Phone Number" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}" ValidationGroup="REG"></asp:RegularExpressionValidator>
         </li>
         <li>
             <asp:Label ID="Label8" runat="server" AssociatedControlID="txtPhone">Personal ID :</asp:Label>
         <asp:TextBox ID="txtPersonalID" Enabled="false" ReadOnly="true" runat="server" ToolTip="Personal ID"></asp:TextBox>
         </li>
    </ol>
</fieldset>
<div><asp:Button ID="btnSubmit" runat="server" Text="Submit" ValidationGroup="REG" OnClick="btnSubmit_Click" /></div>
</asp:Panel>