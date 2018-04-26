using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Insurance
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Request.Browser.IsMobileDevice)
            {
                // Define the name and type of the client scripts on the page.
                String csname1 = "PopupScript";
                Type cstype = this.GetType();

                // Get a ClientScriptManager reference from the Page class.
                ClientScriptManager cs = Page.ClientScript;

                // Check to see if the startup script is already registered.
                if (!cs.IsStartupScriptRegistered(cstype, csname1))
                {
                    StringBuilder cstext1 = new StringBuilder();
                    cstext1.Append("<script type=text/javascript src=wthvideo/wthvideo.js></script>");
                    cs.RegisterStartupScript(cstype, csname1, cstext1.ToString());
                }

            }

            if (Session["CustomerID"] != null)
            {
                main.Visible = false;
            }
        }

        protected void btnReg_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void btnGenerateCertificate_Click(object sender, EventArgs e)
        {
            Session["GenerateCertificateFromDefaultPage"] = 1;
            Response.Redirect("Login.aspx");
        }

        protected void btnRenew_Click(object sender, EventArgs e)
        {
            Session["tryRenewAccount"] = 1;
            Response.Redirect("Login.aspx");
        }
    }
}