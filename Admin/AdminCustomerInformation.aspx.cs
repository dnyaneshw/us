using Insurance.ManageUserSVC;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Insurance.Admin
{
    public partial class AdminCustomerInformation : System.Web.UI.Page
    {      
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (Session["Userdata"] == null)
            {
                Response.Redirect("~/Admin/Login.aspx");
            }
            else
            {
            }           
        }
    }
}