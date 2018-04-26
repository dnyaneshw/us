<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucAdminUploadedDocument.ascx.cs" Inherits="Insurance.Admin.UserControl.ucAdminUploadedDocument" %>

 <script language="javascript" type="text/javascript">

     function AssureDelete()
     {
         return confirm("Are you Sure you want to delete??");
     }
 </script> 

<div>
    <hgroup class="title">
        <h1>Document Details</h1>
    </hgroup>
    <fieldset>
        <legend>Document Details</legend>
        <ol>  
            <li>
                <asp:Button ID="btnUploadContract" OnClick="btnUploadContract_Click" runat="server" Text="Upload The File" />
            </li>
            <li><asp:Label ID="lblDocument" runat="server"></asp:Label></li>      
            <li>
<asp:GridView ID="grddocumentdata" CssClass="footable" CellPadding="5" AutoGenerateColumns="false" runat="server" AllowPaging="true" PageSize="20" ToolTip="Uploaded Documents "  OnPageIndexChanging="grddocumentdata_PageIndexChanging" BorderColor="#CACACA" BorderStyle="Solid" BorderWidth="1px">
        <PagerStyle CssClass="gridBorderStyle" />
        <Columns>
            <asp:BoundField DataField="DocumentName" HeaderText="File Name" />
            <asp:BoundField DataField="MainDocument" HeaderText="Document Name" />
            <%--<asp:BoundField DataField="DocumentPath" HeaderText="Document Path" ItemStyle-CssClass="displaynone" HeaderStyle-CssClass="displaynone" />--%>
            <asp:BoundField DataField="CreatedDate" HeaderText="Created Date" />
            <asp:BoundField DataField="Documentid" HeaderText="Document Id" ItemStyle-CssClass="displaynone" HeaderStyle-CssClass="displaynone"/>
            <asp:TemplateField HeaderText="Delete">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkDelete" runat="server" CausesValidation="false" OnClientClick="return AssureDelete();" OnClick="lnkDelete_Click" >Delete</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>        
    </asp:GridView>
            </li>            
        </ol>
    </fieldset>
    <script type="text/javascript">
        $(function () {
            $('#<%=grddocumentdata.ClientID %>').bind('footable_breakpoint', function () {
                $('#<%=grddocumentdata.ClientID %>').trigger('footable_collapse_all');
                 }).footable();
             });
    </script>
</div>