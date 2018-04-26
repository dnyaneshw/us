using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Insurance.UserControl
{
    public partial class ucCertificateInformation : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CustomerID"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                //MKP
                //txtEventFrom_CalendarExtender.StartDate = DateTime.Now;
                //txtEventTo_CalendarExtender.StartDate = DateTime.Now.AddDays(1);
                if (Session["CustomerID"] != null)
                {
                    Guid ID = Guid.Parse(Session["CustomerID"].ToString());

                    using (ManageUserSVC.ManageUserClient client = new ManageUserSVC.ManageUserClient())
                    {
                        DataSet ds = new DataSet();
                        ds = client.GetCustomerInfo(ID);
                        if (ds != null && ds.Tables[0].Rows.Count > 0)
                        {
                            txtFirstName.Text = ds.Tables[0].Rows[0]["FirstName"].ToString();
                            txtLastName.Text = ds.Tables[0].Rows[0]["LastName"].ToString();
                            txtCompany.Text = ds.Tables[0].Rows[0]["Company_Name"].ToString();
                            txtEmailID.Text = ds.Tables[0].Rows[0]["EmailID"].ToString();
                            txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                            txtphoneNo.Text = ds.Tables[0].Rows[0]["PhoneNo"].ToString();
                            txtCity.Text = ds.Tables[0].Rows[0]["City"].ToString();
                            drpStates.SelectedItem.Text = ds.Tables[0].Rows[0]["State"].ToString();
                            txtZipCode.Text = ds.Tables[0].Rows[0]["ZipCode"].ToString();

                        }
                    }
                }
            }            
        }

        protected void cstmEventFrom_ServerValidate(object source, ServerValidateEventArgs args)
        {            
            DateTime dt = DateTime.ParseExact(txtEventFrom.Text, "MM/dd/yyyy", System.Globalization.CultureInfo.GetCultureInfo("en-US"));
            args.IsValid = (dt >= DateTime.Today) ? true : false;
        }
        protected void cstmEventTo_ServerValidate(object source, ServerValidateEventArgs args)
        {            
            DateTime dt = DateTime.ParseExact(txtEventTo.Text, "MM/dd/yyyy", System.Globalization.CultureInfo.GetCultureInfo("en-US"));
            args.IsValid = (dt >= DateTime.Today.AddDays(1)) ? true : false;
        }
        
        char c = '"';
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid && IsValidate()) 
            {                
                if (chkAgree.Checked)
                {
                    Response.Cookies.Clear();
                    ManageUserSVC.ManageUserClient Client = new ManageUserSVC.ManageUserClient();

                    DataSet Dscus = Client.GetCustomerInfo(Guid.Parse(Session["CustomerID"].ToString()));
                    if (Dscus != null && Dscus.Tables[0].Rows.Count > 0)
                    {
                        if (Dscus.Tables[0].Rows[0]["SecurityCode"].ToString().Equals(txtSecCode.Text) && Dscus.Tables[0].Rows[0]["EmailID"].ToString().Equals(txtEmailID.Text))
                        {
                            Guid CertyID = Guid.NewGuid();
                            String Encrypted = Crypto.Encrypt(CertyID.ToString(), true);
                            string CertyNo = "CE" + Guid.NewGuid().ToString().GetHashCode().ToString("x");

                            string url = System.Configuration.ConfigurationManager.AppSettings["HostingPrefix"];
                            StringBuilder strMailBody = new StringBuilder();
                            //header

                            strMailBody.Append("<p>&nbsp;</p>");
                            strMailBody.Append("<div style=" + c + "margin-left: auto;height:500px;margin-right: auto;position: absolute;text-align: center;top: 0;width: 100%;z-index: 999;" + c + ">");
                            strMailBody.Append("<div style=" + c + "background: url('" + url + "images/image.png') repeat-x scroll 0 0 transparent;height: 75px; width:798px;  position: relative;top: 0;z-index: 999;" + c + ">" + "<br/>");

                            //body
                            strMailBody.Append("<p>&nbsp;</p><table style='font-family: Tahoma;' border='0' cellpadding='0' cellspacing='0' width='600'><tbody><tr><td><table style='font-family: Tahoma;' border='0' cellpadding='0' cellspacing='0' width='600'>");
                            strMailBody.Append("<tbody><tr style='font-family: Tahoma; font-size: 15px; color: rgb(33, 33, 33); text-align: left; ' valign='top'><td style='padding:35px 20px'>");
                            strMailBody.Append(Dscus.Tables[0].Rows[0]["FirstName"].ToString() + " " + Dscus.Tables[0].Rows[0]["LastName"].ToString() + ",<br/><br/>");

                            strMailBody.Append("Your Certificate of Insurance has been generated.<br /><br />");
                            //strMailBody.Append("<b>" + "To view your Certificate of Insurance please click <a href='" + url + "iwed1eamrqqgvxybdda1ed4g.pdf?ching=" + Encrypted + "' target='_blank'>here</a><br /><br />");
                            strMailBody.Append("To view your Certificate of Insurance please click <a href='" + url + "ViewDoc.ashx?" + Crypto.ArgumentEncrypt("ching") + "=" + Encrypted + "&" + Crypto.ArgumentEncrypt("type") + "=" + Crypto.Encrypt("certy", true) + "' target='_blank'>here</a><br /><br />");
                            //strMailBody.Append("If you are having trouble with the above link please copy and paste the following link into your browser:<br /><br />");
                            //strMailBody.Append(url + "ViewDoc.ashx?" + Crypto.ArgumentEncrypt("ching") + "=" + Encrypted + "&" + Crypto.ArgumentEncrypt("type") + "=" + Crypto.Encrypt("certy",true) + "<br/><br/>");
                            strMailBody.Append("Sincerely,<br/>");
                            strMailBody.Append("dscoverage.com<br/>");

                            strMailBody.Append("</tr></tbody></table>");
                            //footer

                            strMailBody.Append("<div style=" + c + "background: url('" + url + "images/footer-b.jpg') no-repeat scroll 0 0 transparent;color: #939393;font-size: 10px;height: 60px;line-height: 44px;overflow: hidden;padding: 0 20px;width: 760px;margin-top: 5px;" + c + ">" + "<p style='float: left;color: white;'>Copyright © " + DateTime.Now.Year.ToString() + " <a href='https://dscoverage.com' target='_blank' style='color:white;font-weight: bolder;'>dscoverage.com</a>, Inc. All Rights Reserved.</p></div>");
                            DateTime Eventfrom = DateTime.ParseExact(txtEventFrom.Text, "MM/dd/yyyy", System.Globalization.CultureInfo.GetCultureInfo("en-US"));
                            DateTime Eventto = DateTime.ParseExact(txtEventTo.Text, "MM/dd/yyyy", System.Globalization.CultureInfo.GetCultureInfo("en-US"));
                            //DateTime Eventfrom = Convert.ToDateTime(txtEventFrom.Text);
                            //DateTime Eventto = Convert.ToDateTime(txtEventTo.Text);

                            Client.InsertCertificate(CertyID, DateTime.Now, CertyNo, Eventfrom, Eventto, txtAdditional.Text, txtHodrName.Text, txtHodrAddress.Text,
                                                       Guid.Parse(Session["CustomerID"].ToString()), null, chkWaiver.Checked);

                            byte[] buffer = dowload(url.Replace("https://", "http://") + "Certificate.aspx?" + Crypto.ArgumentEncrypt("ching") + "=" + Encrypted);

                            string Subject = ConfigurationManager.AppSettings["GenerateCerificate"].ToString();
                            bool Sent = CommonFunction.SendEmail(txtEmailID.Text.Trim(), strMailBody.ToString(), Subject);
                            Session["sent"] = Sent;
                            if (Sent)
                            {
                                //File.WriteAllBytes("D:\\Testssss.pdf", buffer);
                                Client.UpdateCertificate(CertyID, buffer);
                                Response.Redirect("Home.aspx?" + Crypto.ArgumentEncrypt("get") + "=" + Crypto.ArgumentEncrypt("yes"));
                            }

                        }
                        else
                        {
                            lblError.Text = "Invalid Email or Password! Please Enter valid Email Id and Password.";
                        }
                    }
                }
                else
                {
                    lblError.Text = "Please Read Terms And Conditions.";
                }
            }
        }

        protected byte[] dowload(string link)
        {
            object obj = new object();
            lock (obj)
            {
                string WkFilePath = Request.PhysicalApplicationPath + @"WkHtml\wkhtmltopdf.exe";
                //string EXEFileName = @"C:\Program Files\wkhtmltopdf\wkhtmltopdf.exe";

                string args = string.Format("\"{0}\" - ", link);
                var startInfo = new ProcessStartInfo(WkFilePath, args)
                {
                    UseShellExecute = false,
                    RedirectStandardOutput = true
                };

                var proc = new Process { StartInfo = startInfo };
                proc.Start();
                string output = proc.StandardOutput.ReadToEnd();
                byte[] buffer = proc.StandardOutput.CurrentEncoding.GetBytes(output);
                proc.WaitForExit();
                proc.Close();

                return buffer;
            }
        }

        public bool IsValidate()
        {
            string errorMessage = string.Empty;

            if (txtFirstName.Text == "")
            {
                errorMessage = "Please Enter First Name...\n";                
            }
            else if (txtLastName.Text == "")
            {
                errorMessage = "Please Enter Last Name.\n";                
            }
            else if (txtEmailID.Text == "")
            {
                errorMessage = "Please Enter Email.\n";               
            }
            else if (!Regex.IsMatch(txtEmailID.Text, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"))
            {
                errorMessage = "Please Enter Valid Email Address Format.\n";              
            }
            else if (txtAddress.Text == "")
            {
                errorMessage = "Please Enter Your Address.\n";                
            }
            else if (txtphoneNo.Text == "")
            {
                errorMessage = "Please Enter Your Contact No.\n";                
            }
            else if (txtCity.Text == "")
            {
                errorMessage = "Please Enter City.\n";                
            }
            else if (drpStates.SelectedItem.Text == "--Select--")
            {
                errorMessage = "Please Select State.\n";               
            }
            if (!Regex.IsMatch(txtZipCode.Text, @"\d{5}-?(\d{4})?$"))
            {
                errorMessage = "Please Enter Valid Zip Code Format.\n";                
            }
            else if (txtSecCode.Text == "")
            {
                errorMessage = "Please Enter Security Code.\n";                
            }
            else if (txtHodrName.Text == "")
            {
                errorMessage = "Please Enter Certificate Holder Name.\n";                
            }
            else if (txtHodrAddress.Text == "")
            {
                errorMessage = "Please Enter Certificate Holder Address.\n";                
            }
            else if (txtEventFrom.Text == "" || txtEventTo.Text == "")
            {
                errorMessage = "Please Select Event Start Date and End Date.\n";                
            }
            lblError.Text = errorMessage;
            return true;
        }
    }
}