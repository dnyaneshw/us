<%@ Page Title="Welcome to dscoverage.com - Register Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Insurance.Register" %>
<%@ Register Src="~/UserControl/ucCreditCardInformation.ascx" TagPrefix="UC" TagName="ucCreditCardInformation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="content-wrapper">
        <asp:MultiView ID="multiViewRegistration" runat="server" ActiveViewIndex="0">
            <asp:View ID="viewEnrollDescription" runat="server">
                <UC:EnrollDescription ID="enrollDescription" runat="server" />
                <div class="float-right">
                    <asp:Button ID="btnCoverageInformation" runat="server" Text="Coverage Information" ToolTip="Coverage Information" OnClick="btnCoverageInformation_Click" />
                    <asp:Button ID="btnBeginEnrollment" runat="server" Text="Begin Enrollment" ToolTip="Start" OnClick="btnBeginEnrollment_Click" />
                </div>
            </asp:View>
            <asp:View ID="viewEnroll" runat="server">
                <UC:Enroll ID="customerEnrollment" runat="server" />
                <div class="float-right">
                    <asp:Button ID="btn2Back" runat="server" Text="Back" ToolTip="Back" OnClick="btn2Back_Click" />
                    <asp:Button ID="btn2Next" runat="server" ValidationGroup="REG" Text="Next" ToolTip="Next" OnClick="btn2Next_Click" />
                </div>
            </asp:View>
            <asp:View ID="viewCoverage" runat="server">
                <UC:Coverage ID="coverageInformation" runat="server" />
                <div class="float-right">
                    <asp:Button ID="btn3Back" runat="server" Text="Back" ToolTip="Back" OnClick="btn3Back_Click" />
                    <asp:Button ID="btn3Next" runat="server" Text="Next" ToolTip="Next" OnClick="btn3Next_Click" />
                </div>
            </asp:View>
            <asp:View ID="viewCreditCardPayment" runat="server">
                <UC:ucCreditCardInformation runat="server" id="creditCardInformation" />
<div><asp:Button ID="btn4Cancel" runat="server" Text="Cancel" ToolTip="Cancel" OnClick="btn4Cancel_Click1" />
<asp:Button ID="btn4AutoRize" runat="server" Text="Submit" ToolTip="Authorize.Net" OnClick="btn4AutoRize_Click" ValidationGroup="REGPay" />
<asp:Image ID="Image2" CssClass="img-responsive" runat="server" ImageUrl="~/images/comodo.png" ImageAlign="top" /></div>
            </asp:View>

            <asp:View ID="viewProduct" runat="server">
                <UC:ucProducts ID="ucProducts1" runat="server" />
                <div class="float-right">
                    <asp:Button ID="btnBeginEnrollmentViaProductControl" runat="server" Text="Begin Enrollment" ToolTip="Start" OnClick="btnBeginEnrollmentViaProductControl_Click" />
                </div>
            </asp:View>
        </asp:MultiView>
    </div>
</asp:Content>
