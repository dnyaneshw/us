<%@ Page Title="Welcome to dscoverage.com - Admin Company Affilation" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="~/AdminInsuranceMasterPage.Master" AutoEventWireup="true" CodeBehind="AdminCompanyAffilation.aspx.cs" Inherits="Insurance.Admin.AdminCompanyAffilation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script language="javascript" type="text/javascript">
        function Assure() {
            var txt = document.getElementById("<%= ddlCompanyAffil.ClientID %>");
            if (txt.value.toString() != "--Select--") {
                return confirm("Are you Sure you want to delete??");
            }
        }


    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <hgroup class="title">
            <h1>Company Affiliation :</h1>
        </hgroup>
        <p class="validation-summary-errors">
            <asp:Label ID="lblSuccess" runat="server" Text=""></asp:Label>
        </p>
        <fieldset>
            <legend>Company Affiliation List :</legend>
            <ol>
                <li>
                    <asp:Label ID="Label1" runat="server" AssociatedControlID="ddlCompanyAffil">Company Affiliation :</asp:Label>
                </li>
                <li>
                    <asp:DropDownList ID="ddlCompanyAffil" runat="server" />                    
                </li>
            </ol>
            <div><asp:Button ID="lnkAdd" runat="server" OnClick="lnkAdd_Click" Text ="Add"></asp:Button>
                    <asp:Button ID="lnkEdit" runat="server" OnClick="lnkEdit_Click" Text="Edit"></asp:Button>
                    <asp:Button ID="lnkDelete" runat="server" Text="Delete" OnClientClick="return Assure();" OnClick="lnkDelete_Click"></asp:Button></div>
        </fieldset>
    </div>
    <asp:Panel ID="pnlCompantyAffil" runat="server" Visible="false">
        <hgroup class="title">
            <h1>Enter Name Of Company to add :</h1>
        </hgroup>
        <fieldset>
            <legend>Enter Name Of Company to add :</legend>
            
                <ol>
                    <li>
                        <asp:Label ID="Label2" runat="server" AssociatedControlID="txtCompayAff">Name :</asp:Label></li>
                    <li>
                        <asp:TextBox ID="txtCompayAff" CssClass="login" runat="server"></asp:TextBox></li>
                </ol>
                <asp:Button ID="btnAdd" runat="server" Text="Submit" OnClick="btnAdd_Click" />            
        </fieldset>
    </asp:Panel>
</asp:Content>
