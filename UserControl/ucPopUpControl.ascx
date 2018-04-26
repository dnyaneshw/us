<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucPopUpControl.ascx.cs" Inherits="Insurance.UserControl.ucPopUpControl" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<script>    
    $('#<%=vedioframe.ID %>').attr('src', '');
</script>
<div title="Help" class="VedioTabRight" id="VedioTab"  >
        <asp:Image ID="Image1" CssClass="VedioTabImage img-responsive" runat="server" />
    </div>
    <cc1:ModalPopupExtender ID="ModalPopupExtender1" BackgroundCssClass="ModalPopupBG"
            runat="server" TargetControlID="Image1"
            PopupControlID="Panel1" Drag="true" PopupDragHandleControlID="PopupHeader">
        </cc1:ModalPopupExtender>
    <div class="popup_Container" id="Panel1" >
        <div class="popup_Titlebar" id="PopupHeader">
            <div class="TitlebarLeft">                
                DSCOVERAGE.com
            </div>
             <asp:Button ID="btnCancel"  CssClass="TitlebarRight" runat="server" />
        </div>
       
        <div class="Vedio_Frame">
                <iframe id="vedioframe" runat="server" width="500" height="281" frameborder="0" webkitallowfullscreen mozallowfullscreen allowfullscreen></iframe>
            </div>        
    </div>