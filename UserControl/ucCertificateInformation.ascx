<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucCertificateInformation.ascx.cs" Inherits="Insurance.UserControl.ucCertificateInformation" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<script type="text/javascript">

    var StartDate = "";
    var EndDate = "";
    function dateSelectionChangedst(sender, args) {
        //alert($find("startdate"));

        selecteddate = sender.get_selectedDate();
        StartDate = new Date(selecteddate);
        //alert(StartDate);
        if (StartDate != "" && EndDate != "") {
            if (StartDate >= EndDate) {
                alert("Start date should be less than End Date.");
                sender.set_selectedDate();
            }
        }
    }

    function dateSelectionChangedend(sender, args) {
        // alert($find("startdate"));

        selecteddate = sender.get_selectedDate();
        EndDate = new Date(selecteddate);
        //alert(EndDate);
        //var n = new Date(d.getYear(), d.getMonth(), d.getDate() + 1, d.getHours(), d.getMinutes(), d.getSeconds(), d.getMilliseconds());
        if (StartDate != "" && EndDate != "") {
            if (StartDate >= EndDate) {
                alert("Start date should be less than End Date.");
                sender.set_selectedDate();
            }
        }
    }
    </script>

<div>
    <hgroup class="title">
        <h1>REQUEST FOR CERTIFICATE</h1>
    </hgroup>

    <p class="validation-summary-errors">
        <asp:Label ID="lblError" runat="server" ></asp:Label>
    </p>
    <div class="content-wrapper">
    <fieldset>
        <legend>Cettificate Information Form</legend>
        <ol>
            <li>
                <asp:Label ID="Label1" runat="server" AssociatedControlID="txtFirstName">*First Name :</asp:Label>
                <asp:TextBox runat="server" ID="txtFirstName" />
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
                <asp:Label ID="Label6" runat="server" AssociatedControlID="txtAddress">*Address :</asp:Label>
                <asp:TextBox ID="txtAddress" runat="server" ToolTip="Address" ></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="message-error" Display="Dynamic" ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtAddress" ErrorMessage="Please Enter Address" ValidationGroup="REG"></asp:RequiredFieldValidator>
            </li>
            <li>
                <asp:Label ID="Label7" runat="server" AssociatedControlID="txtphoneNo">*Phone Number :</asp:Label>
                <asp:TextBox ID="txtphoneNo" onKeyUp="return PhoneConvert(this);" onKeyDown="return isNumberValidKey(event)" runat="server" ToolTip="Phone Number"></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="message-error" Display="Dynamic" ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtphoneNo" ErrorMessage="Please Enter Phone Number" ValidationGroup="REG"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator CssClass="message-error" Display="Dynamic" ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtphoneNo" ErrorMessage="Enter 10 digit Phone Number" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}" ValidationGroup="REG"></asp:RegularExpressionValidator>
            </li>
            <li>
                <asp:Label ID="Label8" runat="server" AssociatedControlID="txtCity">*City :</asp:Label>
                <asp:TextBox ID="txtCity" runat="server" class="textfiled" ToolTip="City"></asp:TextBox>
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
            </li>
            <li>
                <asp:Label ID="Label10" runat="server" AssociatedControlID="txtZipCode">*Zip Code :</asp:Label>
                <asp:TextBox ID="txtZipCode" MaxLength="5" runat="server" onkeypress="return isNumberValidKey(event);" ToolTip="Zip Code"></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="message-error" Display="Dynamic" ID="RequiredFieldValidator25" runat="server" ControlToValidate="txtZipCode" ErrorMessage="Please Enter Zip Code" ValidationGroup="REG"></asp:RequiredFieldValidator>
            </li>
            <li><asp:Label ID="Label11" runat="server" AssociatedControlID="txtSecCode">*Password :</asp:Label>
                <asp:TextBox ID="txtSecCode" AutoCompleteType="None" autocomplete="off" TextMode="Password"
                            runat="server" ToolTip="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="message-error" Display="Dynamic" ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtSecCode"
                            ErrorMessage="Please Enter Password.You must provide your password to obtain a certificate." ValidationGroup="REG"></asp:RequiredFieldValidator>
                                    </li>
            <li><asp:Label ID="Label12" runat="server" Font-Bold="true" >Waiver of Subrogation :</asp:Label>
                <asp:CheckBox ID="chkWaiver" runat="server" />
            </li>
            <li>&nbsp</li>
            <li><hgroup class="title"><h1>Certificate Holder Information</h1></hgroup></li>
            <li><asp:Label ID="Label13" runat="server" AssociatedControlID="txtHodrName">*Name :</asp:Label>
                <asp:TextBox ID="txtHodrName" runat="server" MaxLength="70" ToolTip="Certificate Holder Name"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="message-error" Display="Dynamic" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtHodrName"
                            ErrorMessage="Please Enter Name" ValidationGroup="REG"></asp:RequiredFieldValidator>
            </li>
            <li><asp:Label ID="Label14" runat="server" AssociatedControlID="txtHodrAddress">*Address :</asp:Label>
                 <asp:TextBox ID="txtHodrAddress"  runat="server" ToolTip="Certificate Holder Address" TextMode="MultiLine"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="message-error" Display="Dynamic" ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtHodrAddress" ErrorMessage="Please Enter Address" ValidationGroup="REG"></asp:RequiredFieldValidator>
            </li>
            <li>
                <asp:Label ID="Label15" runat="server" AssociatedControlID="txtEventFrom" Text="*Date Of Event From :" />
                <asp:TextBox ID="txtEventFrom" class="textfiled" runat="server" ToolTip="Event From" autocomplete="off" onkeypress="return isKey(event)"></asp:TextBox>
                <asp:CalendarExtender ID="txtEventFrom_CalendarExtender" Format="MM/dd/yyyy" OnClientDateSelectionChanged="dateSelectionChangedst" BehaviorID="startdate" runat="server" Enabled="True" TargetControlID="txtEventFrom" />
                <asp:RequiredFieldValidator CssClass="message-error" Display="Dynamic" ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEventFrom" ErrorMessage="Please Select Date Of Event From." ValidationGroup="REG" ></asp:RequiredFieldValidator>
                <asp:CustomValidator runat="server" ID="cstmEventFrom" ControlToValidate="txtEventFrom" onservervalidate="cstmEventFrom_ServerValidate" ErrorMessage="Past date not allowed" CssClass="message-error" Display="Dynamic" ValidationGroup="REG" />
            </li>
            <li>
                <asp:Label ID="Label16" AssociatedControlID="txtEventTo" runat="server" Text="*Date Of Event To :" />
                <asp:TextBox ID="txtEventTo" runat="server" autocomplete="off" ToolTip="Event To" onkeypress="return isKey(event)"></asp:TextBox>
                <asp:CalendarExtender ID="txtEventTo_CalendarExtender" OnClientDateSelectionChanged="dateSelectionChangedend"  Format="MM/dd/yyyy" BehaviorID="enddate" runat="server" Enabled="True" TargetControlID="txtEventTo" />
                <asp:RequiredFieldValidator CssClass="message-error" Display="Dynamic" ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEventTo" ErrorMessage="Please Select Date Of Event To." ValidationGroup="REG"></asp:RequiredFieldValidator>
               <asp:CustomValidator runat="server" ID="cstmEventTo" ControlToValidate="txtEventTo" onservervalidate="cstmEventTo_ServerValidate" ErrorMessage="Past or Current date not allowed" CssClass="message-error" Display="Dynamic" ValidationGroup="REG" />

                 </li>            
            <li>
                <asp:Label ID="Label19" AssociatedControlID="txtAdditional" runat="server" Text="Additional Insured Language if Any :" />
                <asp:TextBox ID="txtAdditional" runat="server" ToolTip="Additional Insured Language" TextMode="MultiLine" ></asp:TextBox></li>
            <li>
                <asp:Label ID="Label17" runat="server" AssociatedControlID="termCondition">Terms and Conditions :</asp:Label>
                <section id="termCondition" runat="server" >
                <p>
                Scope of coverage description: 
                Premises and Operations General Liability excluding professional and products liability. If purchased, Sales representative property floater coverage at premises and while in transit. No Cell phone, computer or tablet coverage afforded. Note: Applicant
                must have paid premium, be in good standing with the represented company and doing a function as a sales representative for that company at the time of loss.
                Coverage Territory: 
                Coverage is available in all 48 Continental United States and Alaska.
                Disclaimer: 
                Any person who knowingly and with intent to defraud any insurance company or another person files an application for insurance or statement of claim containing any materially false information, or conceals for the purpose of misleading information concerning
                any fact material thereto, commits a fraudulent insurance act, which is a crime and subject to criminal and (NY: substantial) Civil Penalties. (not applicable in CO,HI,NE,OH,OK,OR. or VT: in DC, LA, ME, TN and VA, insurance benefits by also be denied.)
                </p>
                    </section>
            </li>
            <li>
                <asp:CheckBox ID="chkAgree" runat="server" />
                <asp:Label ID="Label18" Font-Bold="true" runat="server" Text="I have Read and Agree with the Terms and Conditions Above" />
            </li>
        </ol>
    </fieldset>
        <div><asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" ValidationGroup="REG" /></div>
    </div>
</div>