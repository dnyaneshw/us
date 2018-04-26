using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Insurance.Account
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        char c = '"';
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string CusID = Guid.Parse(Session["CustomerID"].ToString()).ToString();
                BindInfo(CusID);
            }
        }
        private void BindInfo(string CusID)
        {
            Guid ID = Guid.Parse(CusID);
            DataSet dsCus = new DataSet();
            ManageUserSVC.ManageUserClient Client = new ManageUserSVC.ManageUserClient();
            dsCus = Client.GetCustomerInfo(ID);
            ViewState["CustomerData"] = dsCus;            
        }
        private bool IsValidateChangePass()
        {
            lblChangePassError.Visible = false;
            if (txtCurrentPass.Text == "")
            {
                lblChangePassError.Visible = true;
                lblChangePassError.Text = "Please Enter Current Password";
                return false;
            }
            else if (txtNewPass.Text == "")
            {
                lblChangePassError.Visible = true;
                lblChangePassError.Text = "Please Enter New Password";
                return false;
            }
            else if (txtConfirmPass.Text == "")
            {
                lblChangePassError.Visible = true;
                lblChangePassError.Text = "Please Confirm Password";
                return false;
            }
            else if (txtConfirmPass.Text != txtNewPass.Text)
            {
                lblChangePassError.Visible = true;
                lblChangePassError.Text = "Password doen't Match";
                return false;
            }

            return true;
        }
        protected void btnChangePass_Click(object sender, EventArgs e)
        {
            if (IsValidateChangePass())
            {
                ManageUserSVC.ManageUserClient Client = new ManageUserSVC.ManageUserClient();
                ManageUserSVC.ManageUserCustomerData User = new ManageUserSVC.ManageUserCustomerData();

                DataSet dsCus = ViewState["CustomerData"] as DataSet;

                if (dsCus.Tables[0].Rows[0]["SecurityCode"].ToString().Trim().Equals(txtCurrentPass.Text.Trim()))
                {
                    if (dsCus != null && dsCus.Tables[0].Rows.Count > 0)
                    {
                        User.ApplicationNo = dsCus.Tables[0].Rows[0]["ApplicationNo"].ToString();
                        User.CompanyAffilID = Guid.Parse(dsCus.Tables[0].Rows[0]["CompAffilationID"].ToString());
                        User.Country = dsCus.Tables[0].Rows[0]["Country"].ToString();
                        User.EmailID = dsCus.Tables[0].Rows[0]["EmailID"].ToString();
                        User.IsActive = Convert.ToBoolean(dsCus.Tables[0].Rows[0]["IsActive"].ToString());
                        User.IsActivePolicy = Convert.ToBoolean(dsCus.Tables[0].Rows[0]["IsActivePolicy"].ToString());

                        User.YourID = dsCus.Tables[0].Rows[0]["YID"].ToString();
                        User.ZipCode = dsCus.Tables[0].Rows[0]["ZipCode"].ToString();
                        User.SignUpDate = Convert.ToDateTime(dsCus.Tables[0].Rows[0]["SignUp_Date"].ToString());
                        User.Payment = decimal.Parse(dsCus.Tables[0].Rows[0]["Payment"].ToString());
                        User.IsSecCodeSent = Convert.ToBoolean(dsCus.Tables[0].Rows[0]["IsSecCodeSent"].ToString());
                        User.VerifyEmail = Convert.ToBoolean(dsCus.Tables[0].Rows[0]["VerifyEmail"].ToString());

                        User.Address = dsCus.Tables[0].Rows[0]["Address"].ToString();
                        User.City = dsCus.Tables[0].Rows[0]["City"].ToString();
                        User.CompanyName = dsCus.Tables[0].Rows[0]["Company_Name"].ToString();
                        User.EmailID = dsCus.Tables[0].Rows[0]["EmailID"].ToString();
                        User.FirstName = dsCus.Tables[0].Rows[0]["FirstName"].ToString();
                        User.LastName = dsCus.Tables[0].Rows[0]["LastName"].ToString();

                        User.PhoneNo = dsCus.Tables[0].Rows[0]["PhoneNo"].ToString();
                        User.ZipCode = dsCus.Tables[0].Rows[0]["ZipCode"].ToString();
                        User.State = dsCus.Tables[0].Rows[0]["State"].ToString();
                        User.PersonalID = dsCus.Tables[0].Rows[0]["PersonalID"].ToString();
                    }

                    User.CustID = Guid.Parse(Session["CustomerID"].ToString());
                    User.SecurityCode = txtConfirmPass.Text;
                    User.LastUpdated = DateTime.Now;

                    Client.InsertUser(User);


                    string url = System.Configuration.ConfigurationManager.AppSettings["HostingPrefix"];
                    string Name = dsCus.Tables[0].Rows[0]["FirstName"].ToString() + " " + dsCus.Tables[0].Rows[0]["LastName"].ToString();

                    //Sending verify email...
                    StringBuilder strVerifyBody = new StringBuilder();
                    string headurl = url + "images/image.png";
                    //header
                    strVerifyBody.Append("<p>&nbsp;</p>");
                    strVerifyBody.Append("<div style=" + c + "margin-left: auto;height:500px;margin-right: auto;position: absolute;text-align: center;top: 0;width: 100%;z-index: 999;" + c + ">");
                    strVerifyBody.Append("<div style=" + c + "background: url('" + headurl + "') repeat-x scroll 0 0 transparent;height: 75px; width:798px;  position: relative;top: 0;z-index: 999;" + c + ">" + "<br/>");

                    //body
                    strVerifyBody.Append("<p>&nbsp;</p><table style='font-family: Tahoma;' border='0' cellpadding='0' cellspacing='0' width='600'><tbody><tr><td><table style='font-family: Tahoma;' border='0' cellpadding='0' cellspacing='0' width='600'>");
                    strVerifyBody.Append("<tbody><tr style='font-family: Tahoma; font-size: 15px; color: rgb(33, 33, 33); text-align: left; ' valign='top'><td style='padding:35px 20px;font-family: Tahoma;'>");
                    strVerifyBody.Append("<br/>" + Name + "," + "<br /><br/>");
                    strVerifyBody.Append("Your Password is changed.<br /><br/>");
                    strVerifyBody.Append("Here is your Sign In information for your records:<br /><br/>");
                    strVerifyBody.Append("Email: " + dsCus.Tables[0].Rows[0]["EmailID"].ToString() + "<br />");
                    strVerifyBody.Append("Secure Password: " + txtConfirmPass.Text + "<br /><br/>");
                    strVerifyBody.Append("To start using dscoverage.com please click <a href='" + url + "Login.aspx' target='_blank'>here</a> <br/><br/>");
                    strVerifyBody.Append("If you are having trouble with the above link please copy and paste the following link into your browser:<br/><br/>");
                    strVerifyBody.Append("<span style='color:rgb(99,135,175)'>" + url + "Login.aspx </span><br/><br/>");
                    strVerifyBody.Append("Sincerely,<br/>");
                    strVerifyBody.Append("dscoverage.com<br/>");
                    strVerifyBody.Append("</tr></tbody></table><p>&nbsp;</p>");

                    //footer
                    string footurl = url + "images/footer-b.jpg";
                    strVerifyBody.Append("<div style=" + c + "background: url('" + url + "images/footer-b.jpg') no-repeat scroll 0 0 transparent;color: #939393;font-size: 10px;height: 60px;line-height: 44px;overflow: hidden;padding: 0 20px;width: 760px;margin-top: 5px;" + c + ">" + "<p style='float: left;color: white;'>Copyright © " + DateTime.Now.Year.ToString() + " <a href='https://dscoverage.com' target='_blank' style='color:white;font-weight: bolder;'>dscoverage.com</a>, Inc. All Rights Reserved.</p></div>");
                    string Subject = ConfigurationManager.AppSettings["PasswordChangeSubject"].ToString();
                    bool Sent1 = CommonFunction.SendEmail(dsCus.Tables[0].Rows[0]["EmailID"].ToString(), strVerifyBody.ToString(), Subject);

                    lblChangePassError.Visible = true;
                    lblChangePassError.ForeColor = System.Drawing.Color.Green;
                    lblChangePassError.Text = "Your password has been successfully changed.";

                    txtCurrentPass.Attributes.Add("value", "");
                    txtNewPass.Attributes.Add("value", "");
                    txtConfirmPass.Attributes.Add("value", "");
                    txtCurrentPass.Text = "";
                    txtNewPass.Text = "";
                    txtConfirmPass.Text = "";
                    BindInfo(Session["CustomerID"].ToString());
                }
                else
                {
                    lblChangePassError.Visible = true;
                    lblChangePassError.ForeColor = System.Drawing.Color.Red;
                    lblChangePassError.Text = "Invalid current Password. Please enter valid current password.";
                }
            }
        }
    }
}