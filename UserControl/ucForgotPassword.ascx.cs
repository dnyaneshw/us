using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Insurance.UserControl
{
    public partial class ucForgotPassword : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!IsPostBack)
            {
                if (Session["CustomerID"] != null)
                {
                    Response.Redirect("Home.aspx");
                }
                string s = lblPopError.ClientID;
                txtForgotEmail.Attributes.Add("onKeyDown", "makefalse('" + lblPopError.ClientID + "')");                
            }
        }

        protected void btnForgotPass_Click(object sender, EventArgs e)
        {            
                char c = '"';
                string EmailID = txtForgotEmail.Text.Trim();
                ManageUserSVC.ManageUserClient manage = new ManageUserSVC.ManageUserClient();
                DataSet dsCust = new DataSet();
                dsCust = manage.GetCustomerInfoByEmailID(EmailID);
                if (dsCust != null && dsCust.Tables[0].Rows.Count > 0)
                {
                    string Password = dsCust.Tables[0].Rows[0]["SecurityCode"].ToString();
                    string url = System.Configuration.ConfigurationManager.AppSettings["HostingPrefix"];

                    StringBuilder strMailBody = new StringBuilder();

                    //header
                    strMailBody.Append("<p>&nbsp;</p>");
                    strMailBody.Append("<div style=" + c + "margin-left: auto;height:500px;margin-right: auto;position: absolute;text-align: center;top: 0;width: 100%;z-index: 999;" + c + ">");
                    strMailBody.Append("<div style=" + c + "background: url('" + url + "images/image.png') repeat-x scroll 0 0 transparent;height: 75px; width:798px;  position: relative;top: 0;z-index: 999;" + c + ">" + "<br/>");


                    //body
                    strMailBody.Append("<p>&nbsp;</p><table style='font-family: Tahoma;' border='0' cellpadding='0' cellspacing='0' width='600'><tbody><tr><td><table style='font-family: Tahoma;' border='0' cellpadding='0' cellspacing='0' width='600'>");
                    strMailBody.Append("<tbody><tr style='font-family: Tahoma; font-size: 15px; color: rgb(33, 33, 33); text-align: left; ' valign='top'><td style='padding:35px 20px;font-family: Tahoma;'>");
                    strMailBody.Append("<br/>" + dsCust.Tables[0].Rows[0]["FirstName"].ToString() + " " + dsCust.Tables[0].Rows[0]["LastName"].ToString() + ",<br/><br/>");
                    strMailBody.Append("As requested your Sign In information is as follows:<br/><br/>");
                    strMailBody.Append("Email: " + dsCust.Tables[0].Rows[0]["EmailID"].ToString() + "<br />");
                    strMailBody.Append("Secure Password: " + dsCust.Tables[0].Rows[0]["SecurityCode"].ToString() + "<br /><br/>");
                    strMailBody.Append("Sincerely,<br/>");
                    strMailBody.Append("dscoverage.com<br/>");
                    strMailBody.Append("</tr></tbody></table><p>&nbsp;</p>");
                    
                    //footer

                    strMailBody.Append("<div style=" + c + "background: url('" + url + "images/footer-b.jpg') no-repeat scroll 0 0 transparent;color: #939393;font-size: 10px;height: 60px;line-height: 44px;overflow: hidden;padding: 0 20px;width: 760px;margin-top: 5px;" + c + ">" + "<p style='float: left;color: white;'>Copyright © " + DateTime.Now.Year.ToString() + " <a href='https://dscoverage.com' target='_blank' style='color:white;font-weight: bolder;'>dscoverage.com</a>, Inc. All Rights Reserved.</p></div>");
                    string Subject = ConfigurationManager.AppSettings["GetPassword"].ToString();
                    bool Sent = CommonFunction.SendEmail(EmailID, strMailBody.ToString(), Subject);
                    if (Sent == true)
                    {
                        Response.Redirect("Validate.aspx?" + Crypto.ArgumentEncrypt("repaswrd") + "=" + Crypto.Encrypt("sucess", true));
                    }
                    txtForgotEmail.Text = "";
                }
                else
                {                    
                    lblPopError.Text = "This Email ID doesn't Exist.";
                }
            
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}