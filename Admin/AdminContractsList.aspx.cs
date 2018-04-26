using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Insurance.Admin
{
    public partial class AdminContractsList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Userdata"] != null)
            {
            }
            else
            {
                Response.Redirect("~/Admin/Login.aspx");
            }

        }
    }
}