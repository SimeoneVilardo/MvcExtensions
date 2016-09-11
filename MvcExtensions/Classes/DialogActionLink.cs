using MvcExtensions.Enumerations;
using MvcExtensions.Structs;
using Newtonsoft.Json;
using System;
using System.Web.Mvc;
using Yahoo.Yui.Compressor;

namespace MvcExtensions.Classes
{
    public static class DialogActionLink
    {
        private static DialogSize mDefaultSize = DialogSize.Normal;
        private static ClientMessageType mDefaultMessageType = ClientMessageType.Warning;
        private static AjaxMethod mDefaultAjaxMethod = AjaxMethod.GET;
        private static AjaxInsertionMode mDefaultInsertionMode = AjaxInsertionMode.Replace;

        public static MvcHtmlString DialogAjaxViewActionLink(this HtmlHelper html, string ActionName, object Data, string ControllerName, string AjaxFunctionCodeExtension, string ButtonText, string ButtonIcon, ClientMessageType MessageType, string DialogTitle, string DialogMessage, DialogSize Size, string DialogOkButtonText, string DialogCloseButtonText, AjaxMethod AjaxMethod, string UpdateTargetId, AjaxInsertionMode InsertionMode)
        {
            string dialogFunction = createPartialViewDialogFunction(ActionName, ControllerName, Data, AjaxMethod, UpdateTargetId, InsertionMode, AjaxFunctionCodeExtension);
            return DialogGenericActionLink(html, ButtonText, ButtonIcon, MessageType, DialogTitle, DialogMessage, Size, DialogOkButtonText, DialogCloseButtonText, dialogFunction);
        }


        public static MvcHtmlString DialogAjaxViewActionLink(this HtmlHelper html, string ActionName, object Data, string ControllerName, string AjaxFunctionCodeExtension, string ButtonText, string ButtonIcon, ClientMessageType MessageType, string DialogTitle, string DialogMessage, DialogSize Size, string DialogOkButtonText, string DialogCloseButtonText, AjaxMethod AjaxMethod, string UpdateTargetId)
        {
            string dialogFunction = createPartialViewDialogFunction(ActionName, ControllerName, Data, AjaxMethod, UpdateTargetId, mDefaultInsertionMode, AjaxFunctionCodeExtension);
            return DialogGenericActionLink(html, ButtonText, ButtonIcon, MessageType, DialogTitle, DialogMessage, Size, DialogOkButtonText, DialogCloseButtonText, dialogFunction);
        }

        public static MvcHtmlString DialogAjaxActionLink(this HtmlHelper html, string ActionName, object Data, string ControllerName, string AjaxFunctionCodeExtension, string ButtonText, string ButtonIcon, ClientMessageType MessageType, string DialogTitle, string DialogMessage, DialogSize Size, string DialogOkButtonText, string DialogCloseButtonText, AjaxMethod AjaxMethod)
        {
            string dialogFunction = createSimpleDialogFunction(ActionName, ControllerName, Data, AjaxMethod, AjaxFunctionCodeExtension);
            return DialogGenericActionLink(html, ButtonText, ButtonIcon, MessageType, DialogTitle, DialogMessage, Size, DialogOkButtonText, DialogCloseButtonText, dialogFunction);
        }

        public static MvcHtmlString DialogAjaxActionLink(this HtmlHelper html, string ActionName, object Data, string ControllerName, string AjaxFunctionCodeExtension, string ButtonText, string ButtonIcon, ClientMessageType MessageType, string DialogTitle, string DialogMessage, DialogSize Size, string DialogOkButtonText, string DialogCloseButtonText)
        {
            string dialogFunction = createSimpleDialogFunction(ActionName, ControllerName, Data, mDefaultAjaxMethod, AjaxFunctionCodeExtension);
            return DialogGenericActionLink(html, ButtonText, ButtonIcon, MessageType, DialogTitle, DialogMessage, Size, DialogOkButtonText, DialogCloseButtonText, dialogFunction);
        }

        public static MvcHtmlString DialogAjaxActionLink(this HtmlHelper html, string ActionName, object Data, string ControllerName, string AjaxFunctionCodeExtension, string ButtonText, string ButtonIcon, ClientMessageType MessageType, string DialogTitle, string DialogMessage, DialogSize Size, string DialogOkButtonText)
        {
            string dialogFunction = createSimpleDialogFunction(ActionName, ControllerName, Data, mDefaultAjaxMethod, AjaxFunctionCodeExtension);
            return DialogGenericActionLink(html, ButtonText, ButtonIcon, MessageType, DialogTitle, DialogMessage, Size, DialogOkButtonText, Constants.DialogActionLink.DIALOG_CLOSE_BUTTON_TEXT, dialogFunction);
        }

        public static MvcHtmlString DialogAjaxActionLink(this HtmlHelper html, string ActionName, object Data, string ControllerName, string AjaxFunctionCodeExtension, string ButtonText, string ButtonIcon, ClientMessageType MessageType, string DialogTitle, string DialogMessage, DialogSize Size)
        {
            string dialogFunction = createSimpleDialogFunction(ActionName, ControllerName, Data, mDefaultAjaxMethod, AjaxFunctionCodeExtension);
            return DialogGenericActionLink(html, ButtonText, ButtonIcon, MessageType, DialogTitle, DialogMessage, Size, Constants.DialogActionLink.DIALOG_OK_BUTTON_TEXT, Constants.DialogActionLink.DIALOG_CLOSE_BUTTON_TEXT, dialogFunction);
        }

        public static MvcHtmlString DialogAjaxActionLink(this HtmlHelper html, string ActionName, object Data, string ControllerName, string AjaxFunctionCodeExtension, string ButtonText, string ButtonIcon, ClientMessageType MessageType, string DialogTitle, string DialogMessage)
        {
            string dialogFunction = createSimpleDialogFunction(ActionName, ControllerName, Data, mDefaultAjaxMethod, AjaxFunctionCodeExtension);
            return DialogGenericActionLink(html, ButtonText, ButtonIcon, MessageType, DialogTitle, DialogMessage, mDefaultSize, Constants.DialogActionLink.DIALOG_OK_BUTTON_TEXT, Constants.DialogActionLink.DIALOG_CLOSE_BUTTON_TEXT, dialogFunction);
        }

        public static MvcHtmlString DialogAjaxActionLink(this HtmlHelper html, string ActionName, object Data, string ControllerName, string AjaxFunctionCodeExtension, string ButtonText, string ButtonIcon, ClientMessageType MessageType, string DialogTitle)
        {
            string dialogFunction = createSimpleDialogFunction(ActionName, ControllerName, Data, mDefaultAjaxMethod, AjaxFunctionCodeExtension);
            return DialogGenericActionLink(html, ButtonText, ButtonIcon, MessageType, DialogTitle, Constants.DialogActionLink.DIALOG_MESSAGE, mDefaultSize, Constants.DialogActionLink.DIALOG_OK_BUTTON_TEXT, Constants.DialogActionLink.DIALOG_CLOSE_BUTTON_TEXT, dialogFunction);
        }

        public static MvcHtmlString DialogAjaxActionLink(this HtmlHelper html, string ActionName, object Data, string ControllerName, string AjaxFunctionCodeExtension, string ButtonText, string ButtonIcon, ClientMessageType MessageType)
        {
            string dialogFunction = createSimpleDialogFunction(ActionName, ControllerName, Data, mDefaultAjaxMethod, AjaxFunctionCodeExtension);
            return DialogGenericActionLink(html, ButtonText, ButtonIcon, MessageType, Constants.DialogActionLink.DIALOG_TITLE, Constants.DialogActionLink.DIALOG_MESSAGE, mDefaultSize, Constants.DialogActionLink.DIALOG_OK_BUTTON_TEXT, Constants.DialogActionLink.DIALOG_CLOSE_BUTTON_TEXT, dialogFunction);
        }

        public static MvcHtmlString DialogAjaxActionLink(this HtmlHelper html, string ActionName, object Data, string ControllerName, string AjaxFunctionCodeExtension, string ButtonText, string ButtonIcon)
        {
            string dialogFunction = createSimpleDialogFunction(ActionName, ControllerName, Data, mDefaultAjaxMethod, AjaxFunctionCodeExtension);
            return DialogGenericActionLink(html, ButtonText, ButtonIcon, mDefaultMessageType, Constants.DialogActionLink.DIALOG_TITLE, Constants.DialogActionLink.DIALOG_MESSAGE, mDefaultSize, Constants.DialogActionLink.DIALOG_OK_BUTTON_TEXT, Constants.DialogActionLink.DIALOG_CLOSE_BUTTON_TEXT, dialogFunction);
        }

        public static MvcHtmlString DialogAjaxActionLink(this HtmlHelper html, string ActionName, object Data, string ControllerName, string AjaxFunctionCodeExtension, string ButtonText)
        {
            string dialogFunction = createSimpleDialogFunction(ActionName, ControllerName, Data, mDefaultAjaxMethod, AjaxFunctionCodeExtension);
            return DialogGenericActionLink(html, ButtonText, string.Empty, mDefaultMessageType, Constants.DialogActionLink.DIALOG_TITLE, Constants.DialogActionLink.DIALOG_MESSAGE, mDefaultSize, Constants.DialogActionLink.DIALOG_OK_BUTTON_TEXT, Constants.DialogActionLink.DIALOG_CLOSE_BUTTON_TEXT, dialogFunction);
        }

        public static MvcHtmlString DialogAjaxActionLink(this HtmlHelper html, string ActionName, object Data, string ControllerName, string AjaxFunctionCodeExtension)
        {
            string dialogFunction = createSimpleDialogFunction(ActionName, ControllerName, Data, mDefaultAjaxMethod, AjaxFunctionCodeExtension);
            return DialogGenericActionLink(html, Constants.DialogActionLink.DIALOG_OPEN_BUTTON_TEXT, string.Empty, mDefaultMessageType, Constants.DialogActionLink.DIALOG_TITLE, Constants.DialogActionLink.DIALOG_MESSAGE, mDefaultSize, Constants.DialogActionLink.DIALOG_OK_BUTTON_TEXT, Constants.DialogActionLink.DIALOG_CLOSE_BUTTON_TEXT, dialogFunction);
        }

        public static MvcHtmlString DialogAjaxActionLink(this HtmlHelper html, string ActionName, object Data, string ControllerName)
        {
            string dialogFunction = createSimpleDialogFunction(ActionName, ControllerName, Data, mDefaultAjaxMethod, string.Empty);
            return DialogGenericActionLink(html, Constants.DialogActionLink.DIALOG_OPEN_BUTTON_TEXT, string.Empty, mDefaultMessageType, Constants.DialogActionLink.DIALOG_TITLE, Constants.DialogActionLink.DIALOG_MESSAGE, mDefaultSize, Constants.DialogActionLink.DIALOG_OK_BUTTON_TEXT, Constants.DialogActionLink.DIALOG_CLOSE_BUTTON_TEXT, dialogFunction);
        }

        public static MvcHtmlString DialogAjaxActionLink(this HtmlHelper html, string ActionName, object Data)
        {
            string dialogFunction = createSimpleDialogFunction(ActionName, System.Web.HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString(), Data, mDefaultAjaxMethod, string.Empty);
            return DialogGenericActionLink(html, Constants.DialogActionLink.DIALOG_OPEN_BUTTON_TEXT, string.Empty, mDefaultMessageType, Constants.DialogActionLink.DIALOG_TITLE, Constants.DialogActionLink.DIALOG_MESSAGE, mDefaultSize, Constants.DialogActionLink.DIALOG_OK_BUTTON_TEXT, Constants.DialogActionLink.DIALOG_CLOSE_BUTTON_TEXT, dialogFunction);
        }

        public static MvcHtmlString DialogAjaxActionLink(this HtmlHelper html, string ActionName)
        {
            string dialogFunction = createSimpleDialogFunction(ActionName, System.Web.HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString(), null, mDefaultAjaxMethod, string.Empty);
            return DialogGenericActionLink(html, Constants.DialogActionLink.DIALOG_OPEN_BUTTON_TEXT, string.Empty, mDefaultMessageType, Constants.DialogActionLink.DIALOG_TITLE, Constants.DialogActionLink.DIALOG_MESSAGE, mDefaultSize, Constants.DialogActionLink.DIALOG_OK_BUTTON_TEXT, Constants.DialogActionLink.DIALOG_CLOSE_BUTTON_TEXT, dialogFunction);
        }

        public static MvcHtmlString DialogAjaxJsonActionLink(this HtmlHelper html, string ActionName, object Data, string ControllerName, string AjaxFunctionCodeExtension, string ButtonText, string ButtonIcon, ClientMessageType MessageType, string DialogTitle, string DialogMessage, DialogSize Size, string DialogOkButtonText, string DialogCloseButtonText, AjaxMethod AjaxMethod, string[] JsonProps)
        {
            string dialogFunction = createJsonDialogFunction(ActionName, ControllerName, Data, AjaxMethod, JsonProps, AjaxFunctionCodeExtension);
            return DialogGenericActionLink(html, ButtonText, ButtonIcon, MessageType, DialogTitle, DialogMessage, Size, DialogOkButtonText, DialogCloseButtonText, dialogFunction);
        }

        public static MvcHtmlString DialogAjaxJsonActionLink(this HtmlHelper html, string ActionName, object Data, string ControllerName, string AjaxFunctionCodeExtension, string ButtonText, string ButtonIcon, ClientMessageType MessageType, string DialogTitle, string DialogMessage, DialogSize Size, string DialogOkButtonText, string DialogCloseButtonText, AjaxMethod AjaxMethod)
        {
            string dialogFunction = createJsonDialogFunction(ActionName, ControllerName, Data, AjaxMethod, null, AjaxFunctionCodeExtension);
            return DialogGenericActionLink(html, ButtonText, ButtonIcon, MessageType, DialogTitle, DialogMessage, Size, DialogOkButtonText, DialogCloseButtonText, dialogFunction);
        }

        public static MvcHtmlString DialogHtmlActionLink(this HtmlHelper html, string ActionName, object Data, string ControllerName, string ButtonText, string ButtonIcon, ClientMessageType MessageType, string DialogTitle, string DialogMessage, DialogSize Size, string DialogOkButtonText, string DialogCloseButtonText)
        {
            string dialogFunction = createFullReqDialogFunction(ActionName, ControllerName, Data);
            return DialogGenericActionLink(html, ButtonText, ButtonIcon, MessageType, DialogTitle, DialogMessage, Size, DialogOkButtonText, DialogCloseButtonText, dialogFunction);
        }

        public static MvcHtmlString DialogGenericActionLink(this HtmlHelper html, string ButtonText, string ButtonIcon, ClientMessageType MessageType, string DialogTitle, string DialogMessage, DialogSize Size, string DialogOkButtonText, string DialogCloseButtonText, string DialogFunction)
        {
            string buttonId = string.Format("btn-dialog-{0}", Guid.NewGuid().ToString("N"));
            string button = createButton(buttonId, ButtonText, ButtonIcon, MessageType);
            bool closable = !(MessageType.Equals(ClientMessageType.Warning) || MessageType.Equals(ClientMessageType.Danger));
            string buttons = string.Format(@"
                [
                    {{ label: '{0}', cssClass: '{1}', action: {2} }},
                    {{ label: '{3}', action: function(dialogItself) {{ dialogItself.close(); }} }}
                ]",
                DialogOkButtonText, MessageType.ButtonValue, DialogFunction, DialogCloseButtonText);
            string bootstrapDialog = createBootstrapDialog(DialogTitle, DialogMessage, MessageType, closable, closable, Size, buttons);
            string script = string.Format(@"
                document.getElementById('{0}').addEventListener('click', function(){{
                    {1}
                }});",
                buttonId, bootstrapDialog);
            string scriptMin = string.Concat("<script>", new JavaScriptCompressor().Compress(script), @"</script>");
            string buttonDialog = string.Concat(button, scriptMin);
            return MvcHtmlString.Create(buttonDialog);
        }

        private static string createSimpleDialogFunction(string ActionName, string ControllerName, object Data, AjaxMethod AjaxMethod, string AjaxFunctionCodeExtension)
        {
            string buttons = @"
                [
                    { label: 'Ok', action: function(dialogItself) { dialogItself.close(); } }
                ]";
            string bootstrapDialog = createBootstrapDialog("Operazione Completata", "Operazione Completata", ClientMessageType.Success, true, true, DialogSize.Normal, buttons);
            string callbackFunction = string.Format(@"dialogItself.close(); {0}", bootstrapDialog);
            string dialogFunction = createAjaxDialogFunction(ActionName, ControllerName, Data, AjaxMethod, callbackFunction, AjaxFunctionCodeExtension);
            return dialogFunction;
        }

        private static string createPartialViewDialogFunction(string ActionName, string ControllerName, object Data, AjaxMethod AjaxMethod, string UpdateTargetId, AjaxInsertionMode InsertionMode, string AjaxFunctionCodeExtension)
        {
            string callbackFunction = string.Format(@"
                dialogItself.close();
                $('#{0}').{1}(data);",
                UpdateTargetId, InsertionMode.Value);
            string dialogFunction = createAjaxDialogFunction(ActionName, ControllerName, Data, AjaxMethod, callbackFunction, AjaxFunctionCodeExtension);
            return dialogFunction;
        }

        private static string createJsonDialogFunction(string ActionName, string ControllerName, object Data, AjaxMethod AjaxMethod, string[] JsonProps, string AjaxFunctionCodeExtension)
        {
            string dialogJsonMessage = string.Empty;
            bool jsonPropsHasValue = JsonProps != null;
            if (jsonPropsHasValue)
                for (int i = 0; i < JsonProps.Length; i++)
                    dialogJsonMessage += string.Format("{0}: ' + {1}", JsonProps[i], string.Format("data['{0}'] + '<br>", JsonProps[i]));
            else
                dialogJsonMessage = @"
                    function(){
                        var dialogMsg = '';
                        for(var propName in data) {
                            dialogMsg += propName + ': ' + data[propName] + '<br>';
                        }
                        return dialogMsg;
                    }";
            string buttons = @"
                [
                    { label: 'Ok', action: function(dialogItself) { dialogItself.close(); } }
                ]";
            string bootstrapDialog = createBootstrapDialog("Operazione Completata", dialogJsonMessage, ClientMessageType.Primary, true, true, DialogSize.Normal, buttons, !jsonPropsHasValue);
            string callbackFunction = string.Format(@"dialogItself.close(); {0}", bootstrapDialog);
            string dialogFunction = createAjaxDialogFunction(ActionName, ControllerName, Data, AjaxMethod, callbackFunction, AjaxFunctionCodeExtension);
            return dialogFunction;
        }

        private static string createAjaxDialogFunction(string ActionName, string ControllerName, object Data, AjaxMethod AjaxMethod, string CallbackFunction, string AjaxFunctionCodeExtension)
        {
            var jsonData = JsonConvert.SerializeObject(Data);
            string dialogFunction = string.Format(@"
                function(dialogItself) {{
                    $.ajax({{
                    url: '/{0}/{1}',
                    method: '{2}',
                    data: {3}
                }}).done(function(data, textStatus, jqXHR){{
                    {4}
                    {5}
                }});}}",
                ControllerName, ActionName, AjaxMethod.Value, jsonData, CallbackFunction, AjaxFunctionCodeExtension);
            return dialogFunction;
        }

        private static string createFullReqDialogFunction(string ActionName, string ControllerName, object Data)
        {
            string queryString = Data.GetQueryString();
            string dialogFunction = string.Format(@"
                function(){{
                    window.location.href = '/{0}/{1}{2}'
                }}",
                ControllerName, ActionName, Data != null ? string.Concat("?", Data.GetQueryString()) : string.Empty);
            return dialogFunction;
        }

        private static string createBootstrapDialog(string Title, string Message, ClientMessageType Type, bool Closable, bool Draggable, DialogSize Size, string Buttons, bool IsMessageFunction = false)
        {
            Title = Title.Replace("'", "\\'");
            if (!IsMessageFunction)
                Message = Message.Replace("'", "\\'");
            string bootstrapDialog = string.Format(@"
                BootstrapDialog.show({{
                    title: '{0}',
                    message: {1},
                    type: {2},
                    closable: {3},
                    draggable: {4},
                    size: {5},
                    buttons: {6}
                }});",
                Title, IsMessageFunction ? Message : string.Concat("'", Message, "'"), Type.DialogValue, Closable.ToString().ToLower(), Draggable.ToString().ToLower(), Size.Value, Buttons);
            return bootstrapDialog;
        }

        private static string createButton(string ButtonId, string ButtonText, string ButtonIcon, ClientMessageType MessageType)
        {
            string icon = string.IsNullOrEmpty(ButtonIcon) ? string.Empty : string.Format("<i class='{0}'></i> ", ButtonIcon);
            string button = string.Format("<button id='{0}' class='btn btn-dialog {1}'>{2}{3}</button>", ButtonId, MessageType.ButtonValue, icon, ButtonText);
            return button;
        }
    }
}
