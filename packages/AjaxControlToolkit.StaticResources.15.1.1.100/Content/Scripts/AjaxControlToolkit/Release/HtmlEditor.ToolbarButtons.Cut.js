﻿Type.registerNamespace("Sys.Extended.UI.HtmlEditor.ToolbarButtons");Sys.Extended.UI.HtmlEditor.ToolbarButtons.Cut=function(n){Sys.Extended.UI.HtmlEditor.ToolbarButtons.Cut.initializeBase(this,[n])};Sys.Extended.UI.HtmlEditor.ToolbarButtons.Cut.prototype={callMethod:function(){if(!Sys.Extended.UI.HtmlEditor.ToolbarButtons.Cut.callBaseMethod(this,"callMethod"))return!1;var n=this._designPanel;Sys.Extended.UI.HtmlEditor.isIE?(n.openWait(),setTimeout(function(){n.isShadowed();n._copyCut("x",!0);n.closeWait()},0)):n._copyCut("x",!0)}};Sys.Extended.UI.HtmlEditor.ToolbarButtons.Cut.registerClass("Sys.Extended.UI.HtmlEditor.ToolbarButtons.Cut",Sys.Extended.UI.HtmlEditor.ToolbarButtons.MethodButton);