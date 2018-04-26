<%@ Page Title="Welcome to dscoverage.com - Admin Upload Contract" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="~/AdminInsuranceMasterPage.Master" AutoEventWireup="true" CodeBehind="AdminContracts.aspx.cs" Inherits="Insurance.Admin.AdminContracts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <script language="javascript" type="text/javascript">

       var validFilesTypes = ["pdf", "doc", "docx"];
       function ValidateFile()
       {

           var file = document.getElementById("<%=FileUpload1.ClientID%>");
         var label = document.getElementById("<%=lblerror.ClientID%>");
         var path = file.value;

         var ext = path.substring(path.lastIndexOf(".") + 1, path.length).toLowerCase();
         var isValidFile = false;
         for (var i = 0; i < validFilesTypes.length; i++)
         {
             if (ext == validFilesTypes[i])
             {
                 isValidFile = true;
                 break;
             }
         }

         if (!isValidFile)
         {
             alert("Invalid File. Please upload a File with extension pdf,doc,docx");
         }
         return isValidFile;
     }
    </script>
    <div>
        <hgroup class="title">
            <h1>Upload Files :</h1>
        </hgroup>
        <p class="validation-summary-errors">
            <asp:Literal runat="server" ID="ErrorMessage" />
        </p>

        <fieldset>
            <legend>Registration Form</legend>
            <ol>
                <li>
                    <asp:Label ID="lblerror" runat="server" Text="Label" ForeColor="Red"></asp:Label></li>
                <li>
                    <asp:Label ID="Label1" runat="server" AssociatedControlID="txtdocument">Document Name :</asp:Label>
                    <asp:TextBox runat="server" ID="txtdocument" />
                    <asp:RequiredFieldValidator CssClass="message-error" Display="Dynamic" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtdocument" ErrorMessage="The user name field is required." />
                </li>
                <li>
                    <asp:Label ID="Label3" runat="server" AssociatedControlID="FileUpload1">Upload Document :</asp:Label>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </li>
            </ol>
        </fieldset>
        <div>
            <asp:Button ID="btnSave" OnClientClick="return ValidateFile()" Text="Save" runat="server" OnClick="btnSave_Click" />
            <asp:Button ID="btnCancel" CausesValidation="false" Text="Cancel" runat="server" OnClick="btnCancel_Click"/>
        </div>        
    </div>  
</asp:Content>
