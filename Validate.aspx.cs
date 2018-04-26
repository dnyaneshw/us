using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Insurance
{
    public partial class Validate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString[Crypto.ArgumentEncrypt("ressult")] != null)
            {
                string res = Crypto.Decrypt(Request.QueryString[Crypto.ArgumentEncrypt("ressult")].ToString(), true);
                if (res.Equals("sucess"))
                {
                    lblSuccess.Text = "Thank you for registering. A confirmation email has been sent to your registered email address. Please follow the instructions in the email to complete the registration process.";
                    Session.Clear();
                }
                else
                {
                    lblSuccess.Text = "Some error Occured while sending confirmation email to your registered email address. Please check your email address and try again.";
                    Session.Clear();
                }

            }
            if (Request.QueryString[Crypto.ArgumentEncrypt("repaswrd")] != null)
            {
                lblSuccess.Text = "Your current password has been sent to your registered Email Address. Please check Your Email.";
            }
            if (Request.QueryString[Crypto.ArgumentEncrypt("renewaccnt")] != null)
            {
                lblSuccess.Text = "Your Account is renewed successfully.";
            }

            if (Request.QueryString[Crypto.ArgumentEncrypt("change")] != null && Request.QueryString[Crypto.ArgumentEncrypt("your")] != null)
            {
                string NewEmailID = Crypto.Decrypt(Request.QueryString[Crypto.ArgumentEncrypt("your")].ToString(), true);
                Guid Userid = Guid.Parse(Crypto.Decrypt(Request.QueryString[Crypto.ArgumentEncrypt("veryid")].ToString(), true));
                ManageUserSVC.ManageUserClient Client = new ManageUserSVC.ManageUserClient();
                string url = System.Configuration.ConfigurationManager.AppSettings["HostingPrefix"];
                ManageUserSVC.ManageUserCustomerData User = new ManageUserSVC.ManageUserCustomerData();

                DataSet dsCus = Client.GetCustomerInfo(Userid);
                if (dsCus != null && dsCus.Tables[0].Rows.Count > 0)
                {
                    User.ApplicationNo = dsCus.Tables[0].Rows[0]["ApplicationNo"].ToString();
                    User.CompanyAffilID = Guid.Parse(dsCus.Tables[0].Rows[0]["CompAffilationID"].ToString());
                    User.Country = dsCus.Tables[0].Rows[0]["Country"].ToString();
                    User.SecurityCode = dsCus.Tables[0].Rows[0]["SecurityCode"].ToString();
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


                User.CustID = Userid;
                User.EmailID = NewEmailID;
                User.LastUpdated = DateTime.Now;
                Client.InsertUser(User);

                //Send Email to inform email ID changed...
                char c = '"';
                StringBuilder strMailBody = new StringBuilder();
                //header
                strMailBody.Append("<p>&nbsp;</p>");
                strMailBody.Append("<div style=" + c + "margin-left: auto;height:500px;margin-right: auto;position: absolute;text-align: center;top: 0;width: 100%;z-index: 999;" + c + ">");
                strMailBody.Append("<div style=" + c + "background: url('" + url + "images/image.png') repeat-x scroll 0 0 transparent;height: 75px; width:798px;  position: relative;top: 0;z-index: 999;" + c + ">" + "<br/>");


                //body
                strMailBody.Append("<p>&nbsp;</p><table style='font-family: Tahoma;' border='0' cellpadding='0' cellspacing='0' width='600'><tbody><tr><td><table style='font-family: Tahoma;' border='0' cellpadding='0' cellspacing='0' width='600'>");
                strMailBody.Append("<tbody><tr style='font-family: Tahoma; font-size: 15px; color: rgb(33, 33, 33); text-align: left; ' valign='top'><td style='padding:35px 20px;font-family: Tahoma;'>");
                strMailBody.Append("<br/>" + dsCus.Tables[0].Rows[0]["FirstName"].ToString() + "  " + dsCus.Tables[0].Rows[0]["LastName"].ToString() + "," + "<br /><br/>");
                strMailBody.Append("Your Email Address is changed.<br /><br/>");
                strMailBody.Append("Here is your Sign In information for your records:<br /><br/>");
                strMailBody.Append("Email: " + NewEmailID + "<br />");
                //strMailBody.Append("<b>" + "Secure Password: " + Dscus.Tables[0].Rows[0]["SecurityCode"].ToString() + "<br /><br/>");
                strMailBody.Append("To start using dscoverage.com please click <a href='" + url + "Login.aspx' target='_blank'>here</a> <br/><br/>");
                strMailBody.Append("If you are having trouble with the above link please copy and paste the following link into your browser:<br/><br/>");
                strMailBody.Append("<span style='color:rgb(99,135,175)'>" + url + "Login.aspx </span><br/><br/>");
                strMailBody.Append("Sincerely,<br/>");
                strMailBody.Append("dscoverage.com<br/>");
                strMailBody.Append("</tr></tbody></table><p>&nbsp;</p>");

                //footer
                strMailBody.Append("<div style=" + c + "background: url('" + url + "images/footer-b.jpg') no-repeat scroll 0 0 transparent;color: #939393;font-size: 10px;height: 60px;line-height: 44px;overflow: hidden;padding: 0 20px;width: 760px;margin-top: 5px;" + c + ">" + "<p style='float: left;color: white;'>Copyright © " + DateTime.Now.Year.ToString() + " <a href='https://dscoverage.com' target='_blank' style='color:white;font-weight: bolder;'>dscoverage.com</a>, Inc. All Rights Reserved.</p></div>");

                string Subject = ConfigurationManager.AppSettings["ConfirmEmailSubject"].ToString();
                bool Sent = CommonFunction.SendEmail(NewEmailID, strMailBody.ToString(), Subject);

                lblSuccess.Text = "Thank you for visiting our site.";
                lblsuccess1.Text = "You have successfully changed your Email Address. Please visit the Website";
                Session.Clear();

            }
            if (Request.QueryString[Crypto.ArgumentEncrypt("veryid")] != null && Request.QueryString[Crypto.ArgumentEncrypt("your")] == null)
            {
                Guid Userid = Guid.Parse(Crypto.Decrypt(Request.QueryString[Crypto.ArgumentEncrypt("veryid")].ToString(), true));
                ManageUserSVC.ManageUserClient Client = new ManageUserSVC.ManageUserClient();
                string url = System.Configuration.ConfigurationManager.AppSettings["HostingPrefix"];
                DataSet Dscus = Client.GetCustomerInfo(Userid);
                if (Dscus != null && Dscus.Tables[0].Rows.Count > 0)
                {
                    if (Dscus.Tables[0].Rows[0]["VerifyEmail"].ToString() == "" || !bool.Parse((Dscus.Tables[0].Rows[0]["VerifyEmail"].ToString())))
                    {
                        char c = '"';
                        //Sending Security code and information...
                        StringBuilder strMailBody = new StringBuilder();
                        //header
                        strMailBody.Append("<p>&nbsp;</p>");
                        strMailBody.Append("<div style=" + c + "margin-left: auto;height:500px;margin-right: auto;position: absolute;text-align: center;top: 0;width: 100%;z-index: 999;" + c + ">");
                        strMailBody.Append("<div style=" + c + "background: url('" + url + "images/image.png') repeat-x scroll 0 0 transparent;height: 75px; width:798px;  position: relative;top: 0;z-index: 999;" + c + ">" + "<br/>");


                        //body
                        strMailBody.Append("<p>&nbsp;</p><table style='font-family: Tahoma;' border='0' cellpadding='0' cellspacing='0' width='600'><tbody><tr><td><table style='font-family: Tahoma;' border='0' cellpadding='0' cellspacing='0' width='600'>");
                        strMailBody.Append("<tbody><tr style='font-family: Tahoma; font-size: 15px; color: rgb(33, 33, 33); text-align: left; ' valign='top'><td style='padding:35px 20px;font-family: Tahoma;'>");
                        strMailBody.Append("<br/>" + Dscus.Tables[0].Rows[0]["FirstName"].ToString() + "  " + Dscus.Tables[0].Rows[0]["LastName"].ToString() + "," + "<br /><br/>");
                        strMailBody.Append("Your registration is complete.<br /><br/>");
                        strMailBody.Append("Here is your Sign In information for your records:<br /><br/>");
                        strMailBody.Append("Email: " + Dscus.Tables[0].Rows[0]["EmailID"].ToString() + "<br />");
                        strMailBody.Append("Secure Password: " + Dscus.Tables[0].Rows[0]["SecurityCode"].ToString() + "<br /><br/>");
                        //strMailBody.Append("<b><span style='font-size:14px'>Your Application ID Is: " + Dscus.Tables[0].Rows[0]["ApplicationNo"].ToString() + "</span></b><br />");
                        //strMailBody.Append("<b><span style='font-size:14px'>Your User ID Is: " + Dscus.Tables[0].Rows[0]["YID"].ToString() + "</span></b><br />");
                        strMailBody.Append("To start using dscoverage.com please click <a href='" + url + "Login.aspx' target='_blank'>here</a> <br/><br/>");
                        strMailBody.Append("If you are having trouble with the above link please copy and paste the following link into your browser:<br/><br/>");
                        strMailBody.Append("<span style='color:rgb(99,135,175)'>" + url + "Login.aspx</span><br/><br/>");
                        strMailBody.Append("Sincerely,<br/>");
                        strMailBody.Append("dscoverage.com<br/>");
                        strMailBody.Append("</tr></tbody></table><p>&nbsp;</p>");

                        //footer
                        strMailBody.Append("<div style=" + c + "background: url('" + url + "images/footer-b.jpg') no-repeat scroll 0 0 transparent;color: #939393;font-size: 10px;height: 60px;line-height: 44px;overflow: hidden;padding: 0 20px;width: 760px;margin-top: 5px;" + c + ">" + "<p style='float: left;color: white;'>Copyright © " + DateTime.Now.Year.ToString() + " <a href='https://dscoverage.com' target='_blank' style='color:white;font-weight: bolder;'>dscoverage.com</a>, Inc. All Rights Reserved.</p></div>");

                        string Subject = ConfigurationManager.AppSettings["SendingSecCodeToUser"].ToString();
                        bool Sent = CommonFunction.SendEmail(Dscus.Tables[0].Rows[0]["EmailID"].ToString().Trim(), strMailBody.ToString(), Subject);
                        Client.Update_VerificationStatus(Userid, true, Sent);

                        lblSuccess.Text = "Thank you for verifying Email Address.";
                        lblsuccess1.Text = "You can now log into your account. Please check your email for your secure password.";
                    }
                    else
                    {
                        lblSuccess.Text = "You have verified your account already. Please visit on Website";
                    }
                }
            }
        }
    }
}