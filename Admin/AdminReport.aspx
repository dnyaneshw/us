<%@ Page Title="Welcome to dscoverage.com - Admin Report" Language="C#" MaintainScrollPositionOnPostback="true" MasterPageFile="~/AdminInsuranceMasterPage.Master" AutoEventWireup="true" CodeBehind="AdminReport.aspx.cs" Inherits="Insurance.Admin.AdminReport" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>



<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">    
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
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <hgroup class="title"> 
        <h1>Report:</h1>
    </hgroup>
        <p class="validation-summary-errors">
            <asp:Literal runat="server" ID="ErrorMessage" />
        </p>
 <fieldset>
        <legend>Report</legend>
             <ol>
                 <li><asp:Label ID="lblError" runat="server" ForeColor="Red" ></asp:Label></li>
            <li>
                <asp:Label ID="Label1" runat="server" AssociatedControlID="txtfrom">Date From :</asp:Label>                
                <asp:TextBox ID="txtfrom" ToolTip="Date From" onkeypress="return isKey(event)" autocomplete="off" runat="server"></asp:TextBox>
                    <asp:CalendarExtender Enabled="True" Format="MM/dd/yyyy" OnClientDateSelectionChanged="dateSelectionChangedst" BehaviorID="startdate" ID="CalendarExtender1" runat="server" TargetControlID="txtfrom">
                    </asp:CalendarExtender>  
                <asp:RequiredFieldValidator CssClass="message-error" Display="Dynamic" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtfrom" ErrorMessage="Date From field is required." />             
            </li>
                 <li>
                     <asp:Label ID="Label2" runat="server" AssociatedControlID="txtto">Date To :</asp:Label> 
                     <asp:TextBox ID="txtto" ToolTip="Date To" onkeypress="return isKey(event)" autocomplete="off" runat="server"> </asp:TextBox>                   
                    <asp:CalendarExtender Enabled="True" Format="MM/dd/yyyy" OnClientDateSelectionChanged="dateSelectionChangedend"
                     BehaviorID="enddate" ID="CalendarExtender2" runat="server" TargetControlID="txtto">
                    </asp:CalendarExtender> 
                     <asp:RequiredFieldValidator CssClass="message-error" Display="Dynamic" ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtto" ErrorMessage="Date To field is required." />             
                 </li>
             </ol>
             </fieldset>
    <div>
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
    </div>
</asp:Content>
