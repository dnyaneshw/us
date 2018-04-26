<%@ Page Title="Welcome to dscoverage.com - Admin Customer Search" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="~/AdminInsuranceMasterPage.Master" AutoEventWireup="true" CodeBehind="AdminCustomerList.aspx.cs" Inherits="Insurance.Admin.AdminCustomerList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script language="javascript" type="text/javascript">

        function AssureDelete() {
            return confirm("Are you Sure you want to delete??");
        }

        function clear() {
            return confirm("Are you Sure you want to delete??");
        }
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <hgroup class="title">
            <h1>Customer's Search :</h1>
        </hgroup>
        <p class="validation-summary-errors">
            <asp:Label ID="lblSuccess" runat="server" ></asp:Label>
            <asp:Label ID="lblsrcerror" runat="server" ForeColor="Red" ></asp:Label>
            <asp:Label ID="lblgrd" runat="server" ></asp:Label>
        </p>

        <fieldset>
            <legend>User's Information :</legend>
            <ol>               
                <li><asp:Label ID="Label1" runat="server" AssociatedControlID="ddlSearchBy">Search :</asp:Label>
                    <asp:DropDownList ID="ddlSearchBy" runat="server" OnSelectedIndexChanged="ddlSearchBy_SelectedIndexChanged" AutoPostBack="True" >
                    <asp:ListItem Selected="True">All Users</asp:ListItem>
                    <asp:ListItem>Application Number</asp:ListItem>
                    <asp:ListItem>Name</asp:ListItem>
                    <asp:ListItem>Email-ID</asp:ListItem>
                    <asp:ListItem>User ID</asp:ListItem>
                    <asp:ListItem>Coverage Start Date</asp:ListItem>
                </asp:DropDownList>
                    <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
                <asp:TextBox  autocomplete="off" onkeypress="return isKey(event)" ID="txtSerchDate" runat="server" Visible="false" ></asp:TextBox>
                <asp:CalendarExtender ID="txtSerchDate_CalendarExtender" runat="server" Format="MM-dd-yyyy"
                    Enabled="True" TargetControlID="txtSerchDate">
                </asp:CalendarExtender>
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" /></li>
            </ol>
        </fieldset>
        <hgroup class="title">
            <h1>Customer's Information List :</h1>
        </hgroup>
        <asp:GridView ID="grdCustomers" CssClass="footable" CellPadding="5" AutoGenerateColumns="false" AllowPaging="true" PageSize="20" runat="server" ToolTip="Customer's Information" OnPageIndexChanging="grdCustomers_PageIndexChanging" BorderColor="#CACACA" BorderStyle="Solid" BorderWidth="1px">
             <PagerStyle CssClass="gridBorderStyle" />         
            <Columns>                        
                        <asp:BoundField DataField="PersonalID" HeaderText="PersonalID" />
                        <asp:BoundField DataField="Name" HeaderText="Name" />
                        <asp:BoundField DataField="EmailID" HeaderText="Email Address" />
                        <asp:BoundField DataField="PhoneNo" HeaderText="Contact Number" />
                        <asp:BoundField DataField="Cust_ID" HeaderText="Customer ID" />
                        <asp:TemplateField HeaderText="View/Edit">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkEdit" runat="server" OnClick="lnkEdit_Click">View</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkDelete" runat="server" OnClick="lnkDelete_Click" OnClientClick="return AssureDelete();">Delete</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>                    
                </asp:GridView>
         <script type="text/javascript">
             $(function () {
                 $('#<%=grdCustomers.ClientID %>').bind('footable_breakpoint', function () {
                     $('#<%=grdCustomers.ClientID %>').trigger('footable_collapse_all');
            }).footable();
        });
    </script>
    </div>
   <br />
</asp:Content>
