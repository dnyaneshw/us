<%@ Page Title="Welcome to dscoverage.com - Generate Certificate and Evidence" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Insurance.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:Label ID="lblWarn" CssClass="message-error" runat="server"></asp:Label>
        <span id="Renewnote" runat="server" style="font-family: Tahoma; font-size: 14px; font-weight: normal;" visible="false">Your policy is still active for
            <asp:Label ID="lblRemain" runat="server"></asp:Label>days. Please click<asp:LinkButton ID="LinkButton1" runat="server" OnClick="Unnamed1_Click" Font-Underline="true">here</asp:LinkButton>to view your current coverage or generate new certificates.</span>
        <span id="Renewspan" runat="server" style="font-family: Tahoma; font-size: 14px; font-weight: normal;" visible="false">
            <br />
            <asp:LinkButton ID="lnkRenew" runat="server" OnClick="lnkRenew_Click" Font-Underline="true">Click here</asp:LinkButton>to renew account</span>
        <br />
        <fieldset>
            <legend></legend>
            <ol id="Main" runat="server">
                <li></li>
                <li>
                    <h3>
                        <asp:Label ID="Label3" AssociatedControlID="grdCertificate" runat="server" Text="Certificate Information :"></asp:Label></h3>
                    <asp:GridView ID="grdCertificate" CssClass="footable" CellPadding="5" AutoGenerateColumns="false" AllowPaging="true" PageSize="20" ToolTip="Customer's Certificate Information" runat="server" OnPageIndexChanging="grdCertificate_PageIndexChanging" BorderColor="#CACACA" BorderStyle="Solid" BorderWidth="1px">
                        <PagerStyle CssClass="gridBorderStyle" />
                        <Columns>
                            <asp:BoundField DataField="CretiNo" HeaderText="Certificate Number" />
                            <asp:BoundField DataField="HoldrName" HeaderText="Holder Name" />
                            <asp:BoundField DataField="CertiDate" HeaderText="Certificate Date" />
                            <asp:BoundField DataField="CretiID" HeaderText="Certificate ID" />
                            <asp:TemplateField HeaderText="View">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkDownload" runat="server" OnClick="lnkView_Click">View</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Download">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkDown" runat="server" OnClick="lnkDownload_Click">Download</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:Label ID="lblCerty" runat="server" Visible="false"></asp:Label>
                </li>
                <li>
                    <h3>
                        <asp:Label ID="Label4" AssociatedControlID="grdEvedence" runat="server" Text="Evidence Information :"></asp:Label>
                    </h3>
                    <asp:GridView ID="grdEvedence" CssClass="footable" CellPadding="5" AutoGenerateColumns="false"
                        ToolTip="Customer's Evedence Information" AllowPaging="true" PageSize="20" runat="server"
                        OnPageIndexChanging="grdEvedence_PageIndexChanging" BorderColor="#CACACA" BorderStyle="Solid" BorderWidth="1px">
                        <PagerStyle CssClass="gridBorderStyle" />
                        <Columns>
                            <asp:BoundField DataField="EvidenceID" HeaderText="Evidence ID" />
                            <asp:BoundField DataField="EvideDate" HeaderText="Created Date" />
                            <asp:BoundField DataField="LastUpdatedDate" Visible="false" HeaderText="LastUpdated Date" />
                            <asp:BoundField DataField="Active" HeaderText="Active" />
                            <asp:TemplateField HeaderText="View">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkEDownload" OnClientClick="click();" runat="server" OnClick="lnkEView_Click">View</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Download">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkEDown" OnClientClick="click();" runat="server" OnClick="lnkEDownload_Click">Download</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:Label ID="lblEve" runat="server" Visible="false"></asp:Label>
                </li>
                <li class="float-right">
                    <div>
                        <div style="margin-left:auto; margin-right:auto;width:70%;">
                            <asp:ImageButton ID="imgCerty" CssClass="img-responsive evidCertificare" runat="server" ImageUrl="~/Images/GenerateCertificate.jpg" PostBackUrl="~/FillCertiInfo.aspx" />
                        </div>
                        <%--<div style="text-align:center">
                            <asp:Label ID="Label1" CssClass="EvidenceCertificareHeading" runat="server" Text="Generate Certificate"></asp:Label>
                        </div>--%>
                    </div>
                </li>
                <li class="float-right">
                    <div>
                        <div style="margin-left:auto; margin-right:auto;width:70%;">
                            <asp:ImageButton ID="Imageevedence" CssClass="img-responsive evidCertificare" runat="server" ImageUrl="~/Images/PayAndGenerateEvidence.jpg" OnClick="Imageevedence_Click" />
                        </div>
                        <%--<div style="text-align:center">
                            <asp:Label ID="Label2" CssClass="EvidenceCertificareHeading" runat="server" Text="Pay <br/> and Generate Evidence"></asp:Label>
                        </div>--%>
                    </div>
                </li>
                <li>
                    <asp:Panel ID="pnlRenewBeforeOneMonth" runat="server" Visible="false">
                        <asp:Label ID="lblMessageOneMonthAdvance" runat="server" CssClass="message-error" Text="" />
                        <asp:LinkButton ID="lnkRenewBeforeOneMonth" runat="server" Style="font-family: Tahoma; font-size: 14px; font-weight: normal;" Font-Underline="true" OnClick="lnkRenewBeforeOneMonth_Click">Click here</asp:LinkButton>
                        <asp:Label ID="lblMessageOneMonthAdvance1" runat="server" CssClass="message-error" Text="to Renew the Account" />
                    </asp:Panel>
                </li>
            </ol>
        </fieldset>
    </div>

    <script type="text/javascript">
        $(function () {
            $('#<%=grdCertificate.ClientID %>').bind('footable_breakpoint', function () {
                $('#<%=grdCertificate.ClientID %>').trigger('footable_collapse_all');
            }).footable();
        });

        $(function () {
            $('#<%=grdEvedence.ClientID %>').bind('footable_breakpoint', function () {
                $('#<%=grdEvedence.ClientID %>').trigger('footable_collapse_all');
            }).footable();
        });
    </script>
</asp:Content>
