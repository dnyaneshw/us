<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucUploadedDocument.ascx.cs" Inherits="Insurance.UserControl.ucUploadedDocument" %>
<div>    
    <fieldset>
        <legend>Document Details</legend>
        <ol>
            <li>
                <asp:GridView ID="grddocument" CssClass="footable" CellPadding="5" AutoGenerateColumns="False" AllowPaging="True" PageSize="20" 
                    ToolTip="Document's Information" runat="server" OnPageIndexChanging="grddocument_PageIndexChanging" BorderColor="#CACACA" 
                    BorderStyle="Solid" BorderWidth="1px" >
                    <PagerStyle CssClass="gridBorderStyle" />
                    <Columns>
                            <asp:BoundField DataField="DocumentName" HeaderText="Document Name" />
                            <asp:BoundField DataField="MainDocument" HeaderText="File" />
                            <asp:BoundField DataField="DocumentPath" HeaderText="Path" />
                            <asp:BoundField DataField="Documentid" HeaderText="ID" /> 
                            <asp:BoundField Visible="false" DataField="DocumentName" HeaderText="File Name" />
                            <asp:BoundField Visible="false" DataField="CreatedDate" HeaderText="Updated Date" />
                            <asp:TemplateField HeaderText="View">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkView" runat="server" OnClick="lnkView_Click" OnClientClick="window.document.forms[0].target='_blank';" >View</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>                            
                            <asp:TemplateField HeaderText="Download">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkdownload" runat="server" onclick="lnkdownload_Click" >Download</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>                                        
                    </asp:GridView>
            </li>            
        </ol>
    </fieldset>
     <script type="text/javascript">
         $(function () {
             $('#<%=grddocument.ClientID %>').bind('footable_breakpoint', function () {
                 $('#<%=grddocument.ClientID %>').trigger('footable_collapse_all');
            }).footable();
        });
    </script>
</div>
