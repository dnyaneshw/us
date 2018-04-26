﻿Type.registerNamespace("Sys.Extended.UI.Animation");Sys.Extended.UI.Animation.UpdatePanelAnimationBehavior=function(n){Sys.Extended.UI.Animation.UpdatePanelAnimationBehavior.initializeBase(this,[n]);this._onUpdating=new Sys.Extended.UI.Animation.GenericAnimationBehavior(n);this._onUpdated=new Sys.Extended.UI.Animation.GenericAnimationBehavior(n);this._postBackPending=null;this._pageLoadedHandler=null;this._AlwaysFinishOnUpdatingAnimation=null};Sys.Extended.UI.Animation.UpdatePanelAnimationBehavior.prototype={initialize:function(){Sys.Extended.UI.Animation.UpdatePanelAnimationBehavior.callBaseMethod(this,"initialize");var t=this.get_element(),n=document.createElement(t.tagName);t.parentNode.insertBefore(n,t);n.appendChild(t);Array.remove(t._behaviors,this);Array.remove(t._behaviors,this._onUpdating);Array.remove(t._behaviors,this._onUpdated);n._behaviors?(Array.add(n._behaviors,this),Array.add(n._behaviors,this._onUpdating),Array.add(n._behaviors,this._onUpdated)):n._behaviors=[this,this._onUpdating,this._onUpdated];this._element=this._onUpdating._element=this._onUpdated._element=n;this._onUpdating.initialize();this._onUpdated.initialize();this.registerPartialUpdateEvents();this._pageLoadedHandler=Function.createDelegate(this,this._pageLoaded);this._pageRequestManager.add_pageLoaded(this._pageLoadedHandler)},dispose:function(){this._pageRequestManager&&this._pageLoadedHandler&&(this._pageRequestManager.remove_pageLoaded(this._pageLoadedHandler),this._pageLoadedHandler=null);Sys.Extended.UI.Animation.UpdatePanelAnimationBehavior.callBaseMethod(this,"dispose")},_partialUpdateBeginRequest:function(n,t){Sys.Extended.UI.Animation.UpdatePanelAnimationBehavior.callBaseMethod(this,"_partialUpdateBeginRequest",[n,t]);this._postBackPending||(this._postBackPending=!0,this._onUpdated.quit(),this._onUpdating.play())},_pageLoaded:function(n,t){var u,r,i;if(this._postBackPending)for(this._postBackPending=!1,u=this.get_element(),r=t.get_panelsUpdated(),i=0;i<r.length;i++){r[i].parentNode==u&&(this._AlwaysFinishOnUpdatingAnimation?this._tryAndStopOnUpdating():(this._onUpdating.quit(),this._onUpdated.play()));break}},_tryAndStopOnUpdating:function(){if(this._onUpdating.get_animation().get_isPlaying()){var n=this;window.setTimeout(function(){n._tryAndStopOnUpdating.apply(n)},200)}else this._onUpdating.quit(),this._onUpdated.play()},get_OnUpdating:function(){return this._onUpdating.get_json()},set_OnUpdating:function(n){this._onUpdating.set_json(n);this.raisePropertyChanged("OnUpdating")},get_OnUpdatingBehavior:function(){return this._onUpdating},get_OnUpdated:function(){return this._onUpdated.get_json()},set_OnUpdated:function(n){this._onUpdated.set_json(n);this.raisePropertyChanged("OnUpdated")},get_OnUpdatedBehavior:function(){return this._onUpdated},get_AlwaysFinishOnUpdatingAnimation:function(){return this._AlwaysFinishOnUpdatingAnimation},set_AlwaysFinishOnUpdatingAnimation:function(n){this._AlwaysFinishOnUpdatingAnimation!=n&&(this._AlwaysFinishOnUpdatingAnimation=n,this.raisePropertyChanged("AlwaysFinishOnUpdatingAnimation"))}};Sys.Extended.UI.Animation.UpdatePanelAnimationBehavior.registerClass("Sys.Extended.UI.Animation.UpdatePanelAnimationBehavior",Sys.Extended.UI.BehaviorBase);