using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Insurance.Account
{
    public partial class ChangeEmailAddress : System.Web.UI.Page
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
        private bool IsValidateChangeEmail()
        {
            lblEmailError.Visible = false;

            if (txtCurrentEmail.Text == "")
            {
                lblEmailError.Visible = true;
                lblEmailError.Text = "Enter Current Email ID";
                return false;
            }
            else if (!Regex.IsMatch(txtCurrentEmail.Text, @"^([A-Za-z0-9._%+-]+@(?:[A-Za-z0-9-]+\.)+[A-Za-z]{2,4}\r\n)*([A-Za-z0-9._%+-]+@(?:[A-Za-z0-9-]+\.)+[A-Za-z]{2,4})$"))
            {
                lblEmailError.Visible = true;
                lblEmailError.Text = "Enter Valid Current Email ID";
                return false;
            }
            else if (txtNewEmail.Text == "")
            {
                lblEmailError.Visible = true;
                lblEmailError.Text = "Enter Valid New Email ID";
                return false;
            }
            else if (!Regex.IsMatch(txtNewEmail.Text, @"^([A-Za-z0-9._%+-]+@(?:[A-Za-z0-9-]+\.)+[A-Za-z]{2,4}\r\n)*([A-Za-z0-9._%+-]+@(?:[A-Za-z0-9-]+\.)+[A-Za-z]{2,4})$"))
            {
                lblEmailError.Visible = true;
                lblEmailError.Text = "Enter Valid New Email ID";
                return false;
            }
            else if (txtConfirmEmail.Text == "")
            {
                lblEmailError.Visible = true;
                lblEmailError.Text = "Enter confirm Email ID";
                return false;
            }
            else if (txtConfirmEmail.Text != txtNewEmail.Text)
            {
                lblEmailError.Visible = true;
                lblEmailError.Text = "Email ID doen't Match";
                return false;
            }

            return true;
        }
        private bool EmailCrossCheck(string EmailID)
        {
            ManageUserSVC.ManageUserClient Client = new ManageUserSVC.ManageUserClient();
            string Chk = Client.CheckEmailID(EmailID);
            if (Chk.Equals("EXIST"))
            {
                lblEmailError.Visible = true;
                lblEmailError.ForeColor = System.Drawing.Color.Red;
                lblEmailError.Text = "The Email entered already exists in our database";
                return false;
            }

            return true;
        }
        protected void btnEmail_Click(object sender, EventArgs e)
        {
            if (IsValidateChangeEmail())
            {
                ManageUserSVC.ManageUserClient Client = new ManageUserSVC.ManageUserClient();
                ManageUserSVC.ManageUserCustomerData User = new ManageUserSVC.ManageUserCustomerData();

                DataSet dsCus = ViewState["CustomerData"] as DataSet;
                string Email = txtConfirmEmail.Text.Trim();
                string CurrentEmail = txtCurrentEmail.Text.Trim();
                if (CurrentEmail.Equals(dsCus.Tables[0].Rows[0]["EmailID"].ToString()))
                {
                    if (EmailCrossCheck(Email))
                    {
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
                        strVerifyBody.Append("<br/>" + Name + "," + "<br/><br/>");
                        strVerifyBody.Append("Welcome to dscoverage.com<br/><br/>");
                        strVerifyBody.Append("You have sent request for changing your Email Address.<br/>");
                        strVerifyBody.Append("Please Confirm your new email address by clicking <a href='" + url + "Validate.aspx?" + Crypto.ArgumentEncrypt("veryid") + "=" + Crypto.Encrypt(Session["CustomerID"].ToString(), true) + "&" + Crypto.ArgumentEncrypt("your") + "=" + Crypto.Encrypt(Email, true) + "&" + Crypto.ArgumentEncrypt("change") + "=" + Crypto.Encrypt("email", true) + " ' target='_blank'> here</a><br/><br/>");
                        strVerifyBody.Append("If you are having trouble with the above link please copy and paste the following link into your browser:<br/><br/>");
                        strVerifyBody.Append("<span style='color:rgb(99,135,175);font-family: Tahoma;'>" + url + "Validate.aspx?" + Crypto.ArgumentEncrypt("veryid") + "=" + Crypto.Encrypt(Session["CustomerID"].ToString(), true) + "&" + Crypto.ArgumentEncrypt("your") + "=" + Crypto.Encrypt(Email, true) + "&" + Crypto.ArgumentEncrypt("change") + "=" + Crypto.Encrypt("email", true) + "</span><br/><br/>");
                        strVerifyBody.Append("Sincerely,<br/>");
                        strVerifyBody.Append("dscoverage.com<br/>");
                        strVerifyBody.Append("</tr></tbody></table>");

                        //footer
                        string footurl = url + "images/footer-b.jpg";
                        strVerifyBody.Append("<div style=" + c + "background: url('" + url + "images/footer-b.jpg') no-repeat scroll 0 0 transparent;color: #939393;font-size: 10px;height: 60px;line-height: 44px;overflow: hidden;padding: 0 20px;width: 760px;margin-top: 5px;" + c + ">" + "<p style='float: left;color: white;'>Copyright © " + DateTime.Now.Year.ToString() + " <a href='https://dscoverage.com' target='_blank' style='color:white;font-weight: bolder;'>dscoverage.com</a>, Inc. All Rights Reserved.</p></div>");
                        string Subject = ConfigurationManager.AppSettings["ChangeEmailSubject"].ToString();
                        bool Sent1 = CommonFunction.SendEmail(Email, strVerifyBody.ToString(), Subject);
                        lblEmailError.Visible = true;
                        lblEmailError.ForeColor = System.Drawing.Color.Green;
                        lblEmailError.Text = "A confirmation email has been sent to your New Email Address. Please follow the instructions in the New Email to complete the your request.";

                        txtConfirmEmail.Text = "";
                        txtCurrentEmail.Text = "";
                        txtNewEmail.Text = "";
                    }
                }
                else
                {
                    lblEmailError.Visible = true;
                    lblEmailError.ForeColor = System.Drawing.Color.Red;
                    lblEmailError.Text = "Please check your current Email ID.";
                }
            }
        }
    }
}