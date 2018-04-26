using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Insurance.Admin.UserControl
{
    public partial class ucAdminLogin : System.Web.UI.UserControl
    {
        public event EventHandler AdminLoginClick;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private bool Validate()
        {
            if (login1.UserName == "")
            {
                lblError.Text = "Please Enter Username.";
                return false;
            }
            else if (login1.Password == "")
            {
                lblError.Text = "Please Enter Password.";
                return false;
            }

            return true;
        }

        protected void btnAdminLogin_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                string Username = login1.UserName;
                string Password = login1.Password;
                DataSet dsCustData = new DataSet();
                ManageUserSVC.ManageUserClient Client = new ManageUserSVC.ManageUserClient();
                dsCustData = Client.AdminLogin(Username, Password);

                if (dsCustData != null && dsCustData.Tables[0].Rows.Count > 0)
                {
                    Session["Userdata"] = dsCustData;
                    if (this.AdminLoginClick != null)
                    {
                        AdminLoginClick(sender, e);
                    }                    
                }
                else
                {
                    lblError.Text = "Invalid Username or Password !";
                }
            }
                
            
        }
    }
}