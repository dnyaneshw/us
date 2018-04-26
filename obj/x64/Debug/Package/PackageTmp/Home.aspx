<%@ Page Title="Welcome to dscoverage.com - Generate Certificate and Evidence" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Insurance.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <hgroup class="title">
        <h1>Generate Certificate & Evidence :</h1>
    </hgroup>
    <div>
        <asp:Label ID="lblWarn" runat="server"></asp:Label>        
            <span id="Renewnote" runat="server" visible="false">Your policy is still active for
            <asp:Label ID="lblRemain" runat="server"></asp:Label>days. Please click<asp:LinkButton ID="LinkButton1" runat="server" OnClick="Unnamed1_Click" Font-Underline="true">here</asp:LinkButton>to view your current coverage or generate new certificates.</span>
            <span id="Renewspan" runat="server" visible="false">
            <asp:LinkButton ID="lnkRenew" runat="server" OnClick="lnkRenew_Click" Font-Underline="true">Click here</asp:LinkButton>to renew account</span>
        <br />
        <fieldset>
            <legend>Generate Certificate & Evidence :</legend>
            <ol id="Main" runat="server">
                <li>                                       
                </li>
                <li>
                    <asp:Label ID="Label3" AssociatedControlID="grdCertificate" runat="server" Text="Certificate Information :" ></asp:Label>
                    <asp:GridView ID="grdCertificate" CssClass="footable" CellPadding="5" AutoGenerateColumns="false" AllowPaging="true" PageSize="2" ToolTip="Customer's Certificate Information" runat="server" OnPageIndexChanging="grdCertificate_PageIndexChanging"  BorderColor="#CACACA" BorderStyle="Solid" BorderWidth="1px" >
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
                    <asp:Label ID="Label4" AssociatedControlID="grdEvedence" runat="server" Text="Evidence Information :" ></asp:Label>                     
                    <asp:GridView ID="grdEvedence" CssClass="footable" CellPadding="5" AutoGenerateColumns="false"
                        ToolTip="Customer's Evedence Information" AllowPaging="true" PageSize="2" runat="server"
                        OnPageIndexChanging="grdEvedence_PageIndexChanging"  BorderColor="#CACACA" BorderStyle="Solid" BorderWidth="1px">
                        <PagerStyle CssClass="gridBorderStyle" />
                        <Columns>
                            <asp:BoundField DataField="EvidenceID" HeaderText="Evedence ID" />
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
                <li>
                    <p><b>
                        <asp:Label ID="Label1" runat="server" Text="Generate Certificate :"></asp:Label></b></p>
                    <asp:ImageButton ID="imgCerty" CssClass="img-responsive" runat="server" ImageUrl="~/images/Evidence.jpg" PostBackUrl="~/FillCertiInfo.aspx" />
                </li>
                <li>
                    <p><b>
                        <asp:Label ID="Label2" runat="server" Text="Pay and Generate Evidence :"></asp:Label></b></p>
                    <asp:ImageButton ID="Imageevedence" CssClass="img-responsive" runat="server" ImageUrl="~/images/Evidence.jpg" OnClick="Imageevedence_Click" />
                </li>
            </ol>
        </fieldset>
    </div>

    <script type="text/javascript">
        $(function () {
            $('#<%=grdCertificate.ClientID %>').bind('footable_breakpoint', function () {
                                $('#<%=grdCertificate.ClientID %>').trigger('footable_expand_first_row');
                            }).footable();
        });

        $(function () {
            $('#<%=grdEvedence.ClientID %>').bind('footable_breakpoint', function () {
                        $('#<%=grdEvedence.ClientID %>').trigger('footable_expand_first_row');
            }).footable();
                });
    </script>
</asp:Content>
