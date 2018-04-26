using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Optimization;

namespace Insurance
{
    public partial class SiteMaster : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;
        public DataSet dsCus = new DataSet();

        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["CustomerID"] == null)
            {
                logout.Visible = false;
                Hype.Visible = false;
                lnkRegister.Visible = true;
                lnksignIn.Visible = true;
                lnkWelcome.Visible = false;
                LinkButton3.Visible = false;
                Hypeacc.Visible = false;
            }
            else
            {                
                ManageUserSVC.ManageUserClient Cl = new ManageUserSVC.ManageUserClient();
                dsCus = Cl.GetCustomerInfo(Guid.Parse(Session["CustomerID"].ToString()));
                if (dsCus != null)
                {
                    lnkWelcome.Text = dsCus.Tables[0].Rows[0]["FirstName"].ToString(); 
                    lnkWelcome.Visible = true;
                    LinkButton3.Visible = true;
                }
                signinli.Visible = false;
                string url = System.Configuration.ConfigurationManager.AppSettings["HostingPrefix"];
                logo.PostBackUrl = url + "Home.aspx";
                HyperLink1.NavigateUrl = url + "Home.aspx";
                logout.Visible = true;
                slash.Visible = false;
                Hype.Visible = true;
                lnksignIn.Visible = false;
                lnkRegister.Visible = false;
                Hypeacc.Visible = true;
            }
        }

        protected void hyLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Cookies.Clear();
            Response.Redirect("~/Login.aspx");
        }

        
    }
}