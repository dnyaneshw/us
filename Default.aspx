<%@ Page Title="Welcome to dscoverage.com - Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Insurance._Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
        <div >
    <div id="main" runat="server" style="padding-bottom:15px; margin-left:auto; margin-right:auto;width:95%;">
        <div style="margin-left:auto; margin-right:auto;width:95%;" >
            <fieldset>
                <legend></legend>
                <ol style="margin: auto !important">
                    <li class="nav navbar-nav" style="padding: 1px">
                        <div style="border: 1px solid #999999;">
                            <div>
                                <h1 class="ImageHeading">Enroll</h1>
                            </div>
                            <div class="ImageDivPadding">
                                <asp:ImageButton CssClass="image-Padding img-responsive" OnClick="btnReg_Click" ImageUrl="~/Images/Enroll.jpg" ID="btnReg" runat="server" alt="register" />
                            </div>
                        </div>
                    </li>
                    <li class="nav navbar-nav" style="padding: 1px">
                        <div style="border: 1px solid #999999;">
                            <div>
                                <h1 class="ImageHeading">Generate A Certificate:</h1>
                            </div>
                            <div class="ImageDivPadding">
                                <asp:ImageButton CssClass="image-Padding img-responsive" OnClick="btnGenerateCertificate_Click" ImageUrl="~/Images/Print.jpg" ID="btnGenerateCertificate" runat="server" alt="Generate A Certificate" />
                            </div>
                        </div>
                    </li>
                    <li class="nav navbar-nav" style="padding: 1px">
                        <div style="border: 1px solid #999999;">
                            <div>
                                <h1 class="ImageHeading">Renew:</h1>
                            </div>
                            <div class="ImageDivPadding">
                                <asp:ImageButton CssClass="image-Padding img-responsive" OnClick="btnRenew_Click" ImageUrl="~/Images/Renew.jpg" ID="btnRenew" runat="server" alt="Renew" />
                            </div>
                        </div>
                    </li>
                </ol>
            </fieldset>
        </div>
    </div>
            </div>
    <UC:ucPopUpControl runat="server" ID="ucPopUpControl" />
</asp:Content>
