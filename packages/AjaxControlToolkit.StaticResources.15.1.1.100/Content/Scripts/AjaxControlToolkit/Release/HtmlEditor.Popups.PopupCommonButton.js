﻿Type.registerNamespace("Sys.Extended.UI.HtmlEditor.Popups");Sys.Extended.UI.HtmlEditor.Popups.PopupCommonButton=function(n){Sys.Extended.UI.HtmlEditor.Popups.PopupCommonButton.initializeBase(this,[n]);this._loaded=!1;this._activated=null;this._app_onload$delegate=Function.createDelegate(this,this._app_onload);this._cssClass="";this._name="";this._onmouseover$delegate=Function.createDelegate(this,this._onmouseover);this._onmouseout$delegate=Function.createDelegate(this,this._onmouseout);this._onmousedown$delegate=Function.createDelegate(this,this._onmousedown);this._onmouseup$delegate=Function.createDelegate(this,this._onmouseup);this._onclick$delegate=Function.createDelegate(this,this._onclick)};Sys.Extended.UI.HtmlEditor.Popups.PopupCommonButton.prototype={isImage:function(){return!0},set_toolTip:function(n){this.get_element().title=n},get_toolTip:function(){return this.get_element().title},set_name:function(n){this._name=n},get_name:function(){return this._name},initialize:function(){var n=this.get_element();if(Sys.Extended.UI.HtmlEditor.Popups.PopupCommonButton.callBaseMethod(this,"initialize"),Sys.Application.add_load(this._app_onload$delegate),this._cssClass=n.className.split(" ")[0],this.isImage()&&$addHandlers(n,{mouseover:this._onmouseover$delegate,mouseout:this._onmouseout$delegate,mousedown:this._onmousedown$delegate,mouseup:this._onmouseup$delegate,click:this._onclick$delegate}),Sys.Extended.UI.HtmlEditor.isIE){function t(n){var i,r;if(n.nodeType==1&&n.tagName)for(i=n.tagName.toUpperCase(),i!="INPUT"&&i!="TEXTAREA"&&i!="IFRAME"&&(n.unselectable="on"),r=0;r<n.childNodes.length;r++)t(n.childNodes.item(r))}t(n)}else try{n.style.MozUserSelect="none";n.parentNode.style.MozUserSelect="none"}catch(i){}},activate:function(n){this._activated=n;this.isImage()&&(Sys.Extended.UI.HtmlEditor._addEvent(this._activated,"mouseover",this._onmouseover$delegate),Sys.Extended.UI.HtmlEditor._addEvent(this._activated,"mouseout",this._onmouseout$delegate),Sys.Extended.UI.HtmlEditor._addEvent(this._activated,"mousedown",this._onmousedown$delegate),Sys.Extended.UI.HtmlEditor._addEvent(this._activated,"mouseup",this._onmouseup$delegate),Sys.Extended.UI.HtmlEditor._addEvent(this._activated,"click",this._onclick$delegate))},dispose:function(){this.isImage()&&this._activated!=null&&(Sys.Extended.UI.HtmlEditor._removeEvent(this._activated,"mouseover",this._onmouseover$delegate),Sys.Extended.UI.HtmlEditor._removeEvent(this._activated,"mouseout",this._onmouseout$delegate),Sys.Extended.UI.HtmlEditor._removeEvent(this._activated,"mousedown",this._onmousedown$delegate),Sys.Extended.UI.HtmlEditor._removeEvent(this._activated,"mouseup",this._onmouseup$delegate),Sys.Extended.UI.HtmlEditor._removeEvent(this._activated,"click",this._onclick$delegate));this._activated=null;this._loaded=!1;Sys.Application.remove_load(this._app_onload$delegate);Sys.Extended.UI.HtmlEditor.Popups.PopupCommonButton.callBaseMethod(this,"dispose")},_app_onload:function(){this._loaded||(this.onButtonLoaded(),this._loaded=!0)},onButtonLoaded:function(){},_onmouseover:function(){return this.isEnable()?(Sys.UI.DomElement.addCssClass(this._activated,this._cssClass+"_hover"),!0):!1},_onmouseout:function(n){if(!this.isEnable())return!1;var t=n.toElement||n.relatedTarget;try{while(t&&typeof t!="undefined")if(t==this._activated)break;else t=t.parentNode}catch(n){t=null}return t!=null?!0:(Sys.UI.DomElement.removeCssClass(this._activated,this._cssClass+"_hover"),Sys.UI.DomElement.removeCssClass(this._activated,this._cssClass+"_mousedown"),!0)},_onmousedown:function(){return this.isEnable()?(Sys.UI.DomElement.addCssClass(this._activated,this._cssClass+"_mousedown"),!1):null},_onmouseup:function(){return this.isEnable()?(Sys.UI.DomElement.removeCssClass(this._activated,this._cssClass+"_mousedown"),!0):!1},_onclick:function(n){return this.isEnable()?(this.callMethod(n),!0):!1},callMethod:function(){var n=this._activated.ownerDocument||this._activated.document||target,t=n.defaultView||n.parentWindow,i=t.popupMediator.get_callMethodByName(this._name);Function.createDelegate(this,i)(t)},isEnable:function(){return this._loaded?!0:!1}};Sys.Extended.UI.HtmlEditor.Popups.PopupCommonButton.registerClass("Sys.Extended.UI.HtmlEditor.Popups.PopupCommonButton",Sys.UI.Control);