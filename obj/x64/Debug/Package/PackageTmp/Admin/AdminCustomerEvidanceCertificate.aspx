<%@ Page Title="Welcome to dscoverage.com - Customer's Information & Evidence & Certificate" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="~/AdminInsuranceMasterPage.Master" AutoEventWireup="true" CodeBehind="AdminCustomerEvidanceCertificate.aspx.cs" Inherits="Insurance.Admin.AdminCustomerEvidanceCertificate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

     <p class="validation-summary-errors">
            <asp:Literal runat="server" ID="ErrorMessage" />
            <asp:Label ID="lblError" runat="server"></asp:Label>
            <asp:Label ID="lblCerty" runat="server" Text="" Visible="false"></asp:Label>
        </p>

        <div>
            <hgroup class="title">
                <h1>Customer's Certificate :</h1>
            </hgroup>
            <fieldset>
                <legend>Customer's Certificate :</legend>
                <ol>
                    <li>
                        <asp:GridView ID="grdCertificate" CssClass="footable" CellPadding="5" AutoGenerateColumns="false" AllowPaging="true" PageSize="2" ToolTip="Customer's Certificate Information" runat="server" OnPageIndexChanging="grdCertificate_PageIndexChanging" BorderColor="#CACACA" BorderStyle="Solid" BorderWidth="1px" >
                            <PagerStyle CssClass="gridBorderStyle" />
                            <Columns>
                                <asp:BoundField DataField="CretiID" HeaderText="Certificate ID"></asp:BoundField>
                                <asp:BoundField DataField="CretiNo" HeaderText="Certificate No." />
                                <asp:BoundField DataField="HoldrName" HeaderText="Certificate Holder Name" />
                                <asp:BoundField DataField="CertiDate" HeaderText="Certificate Date" />
                                <asp:TemplateField HeaderText="View">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkView" runat="server" OnClick="lnkView_Click">View</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Download">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkDownload" runat="server" OnClick="lnkDownload_Click">Download</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Resend Certificate">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkSend" runat="server" OnClick="lnkSend_Click">Resend</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <script type="text/javascript">
                            $(function () {
                                $('#<%=grdCertificate.ClientID %>').bind('footable_breakpoint', function () {
                        $('#<%=grdCertificate.ClientID %>').trigger('footable_expand_first_row');
                    }).footable();
                });
    </script>
                    </li>
                </ol>
            </fieldset>
            
        </div>

        <div>
            <hgroup class="title">
                <h1>Proof of Evidence :</h1>
            </hgroup>
            <fieldset>
                <legend>Proof of Evidence :</legend>
                <ol>
                    <li>
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Regenerate Evidence" />
                        <asp:Label ID="Label2" runat="server" Text="Send Email :"></asp:Label>
                        <asp:CheckBox ID="Chkmail" Checked="true" runat="server" />
                    </li>
                    <li><asp:Label ID="lblEve" runat="server" Visible="false"></asp:Label></li>
                    <li>
                    <asp:GridView ID="grdEvedence" CssClass="footable" CellPadding="5" AutoGenerateColumns="false" ToolTip="Customer's evidence Information" runat="server" OnPageIndexChanging="grdEvedence_PageIndexChanging" AllowPaging="true" PageSize="2" BorderColor="#CACACA" BorderStyle="Solid" BorderWidth="1px">
                    <PagerStyle CssClass="gridBorderStyle" />
                        <Columns>
                    <asp:BoundField DataField="EvidenceID" HeaderText="evidence ID" />
                    <asp:BoundField DataField="EvideDate" HeaderText="Evidence Created Date" />
                    <asp:BoundField DataField="LastUpdatedDate" HeaderText="LastUpdated Date" />
                    <asp:BoundField DataField="Active" HeaderText="Active evidence" />
                    <asp:TemplateField HeaderText="View">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkEView" runat="server" OnClick="lnkEView_Click">View</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Download">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkEDownload" runat="server" OnClick="lnkEDownload_Click">Download</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Resend evidence">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkESend" runat="server" OnClick="lnkESend_Click">Resend</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    </Columns>
                    </asp:GridView>
                        <script type="text/javascript">
                            $(function () {
                                $('#<%=grdEvedence.ClientID %>').bind('footable_breakpoint', function () {
                        $('#<%=grdEvedence.ClientID %>').trigger('footable_expand_first_row');
                    }).footable();
                });
    </script>
                    </li>
                </ol>
            </fieldset>
            
        </div>

</asp:Content>
