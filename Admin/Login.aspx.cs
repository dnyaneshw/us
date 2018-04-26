using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Insurance.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Userdata"] != null)
                {
                    Response.Redirect("~/Admin/AdminCustomerList.aspx");
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                string Username = txtUsername.Text;
                string Password = txtPassword.Text;
                DataSet dsCustData = new DataSet();
                ManageUserSVC.ManageUserClient Client = new ManageUserSVC.ManageUserClient();
                dsCustData = Client.AdminLogin(Username, Password);

                if (dsCustData != null && dsCustData.Tables[0].Rows.Count > 0)
                {
                    Session["Userdata"] = dsCustData;
                    Response.Redirect("~/Admin/AdminCustomerList.aspx");
                }
                else
                {
                    lblError.Text = "Invalid Username or Password !";
                }
            }
        }

        private bool Validate()
        {
            if (txtUsername.Text == "")
            {
                lblError.Text = "Please Enter Username.";
                return false;
            }
            else if (txtPassword.Text == "")
            {
                lblError.Text = "Please Enter Password.";
                return false;
            }

            return true;
        }

    }
}