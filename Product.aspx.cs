using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Insurance
{
    public partial class Product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CustomerID"] != null)
            {
                btnBeginEnrollmentViaProductControl.Visible = false;
            }

        }
        protected void btnBeginEnrollmentViaProductControl_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}