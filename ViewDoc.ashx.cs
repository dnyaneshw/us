using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace Insurance
{
    /// <summary>
    /// Summary description for ViewDoc
    /// </summary>
    public class ViewDoc : IHttpHandler, IRequiresSessionState
    {
        string url = System.Configuration.ConfigurationManager.AppSettings["HostingPrefix"];
        public void ProcessRequest(HttpContext context)
        {
            string id = string.Empty;
            string type = string.Empty;

            try
            {
                id = context.Request.QueryString[Crypto.ArgumentEncrypt("ching")].ToString();
                id = Crypto.Decrypt(id, true);
            }
            catch (Exception)
            {
                HttpContext.Current.Response.Redirect("ErrorPage.aspx", true);
            }

            try
            {
                type = Crypto.Decrypt(context.Request.QueryString[Crypto.ArgumentEncrypt("type")].ToString(), true);
            }
            catch (Exception)
            {
                HttpContext.Current.Response.Redirect("ErrorPage.aspx", true);
            }

            context.Response.Redirect(url + "View.aspx?" + Crypto.ArgumentEncrypt("id") + "=" + Crypto.Encrypt(id, true) + "&" + Crypto.ArgumentEncrypt("type") + "=" + Crypto.Encrypt(type, true));

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}