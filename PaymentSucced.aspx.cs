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
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Insurance
{
    public partial class PaymentSucced : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["tx"] != null)
                {
                    GetPayPalResponce();
                }

                else if (Request.QueryString[Crypto.ArgumentEncrypt("Resp")] != null)
                {
                    string Status = Crypto.Decrypt(Request.QueryString[Crypto.ArgumentEncrypt("Resp")].ToString(), true);
                    Session["status"] = Status;
                    if (Status.Equals("approved"))
                    {
                        Guid CustID = Guid.Parse(Session["CustomerID"].ToString());
                        ViewState["CurrentCustomer"] = CustID;
                        Session["CustomerID"] = CustID;
                        ManageUserSVC.ManageUserClient Client = new ManageUserSVC.ManageUserClient();
                        ManageUserSVC.ManageUserCoverageData Coverage = new ManageUserCoverageData();
                        
                        if (Session["RenewCoverageInfo"] != null)
                        {
                            Coverage = (ManageUserSVC.ManageUserCoverageData)Session["RenewCoverageInfo"];
                        }
                        else
                        {
                            Coverage = (ManageUserSVC.ManageUserCoverageData)Session["CoverageInfo"];                            
                        }

                        Client.InsertCoverageData(Coverage);
                        bool Propertybuy = false; ;
                       
                        Client.Update_Payment(CustID, decimal.Parse(Session["Amount"].ToString()), Propertybuy);
                        lblMessage.Text = "Thank you! Your payment was successful!";

                        string Local = System.Configuration.ConfigurationManager.AppSettings["HostingPrefix"];
                        dowload(Local.Replace("https://", "http://") + "ProofEvidence.aspx?" + Crypto.ArgumentEncrypt("sss") + "=" + Crypto.Encrypt(CustID.ToString(), true), Coverage);
                        idspan.Visible = true;
                        SendEmailForProofOfEvidnce(Client, CustID, Local);
                    }
                    else if (Status.Equals("notapproved"))
                    {
                        // mess.Visible = false;

                        lblMessage.Text = "Your payment was not processed successfully. Please ensure your payment details are correct.Click" +
                            " <a id='lnkAccount' runat='server' href='Register.aspx?" + Crypto.ArgumentEncrypt("retrypayment") + "=" + Crypto.Encrypt("1", true) + "' style='cursor:pointer;color:black;text-decoration: underline;'>here</a> " +
                            "to retry payment.";
                    }
                }
            }
        }



        

        private void GetPayPalResponce()
        {
            string authToken, txToken, query, strResponse, Key, Val, status;
            authToken = WebConfigurationManager.AppSettings["PDTToken"];
            //read in txn token from querystring
            txToken = Request.QueryString.Get("tx");
            query = string.Format("cmd=_notify-synch&tx={0}&at={1}", txToken, authToken);

            // Create the request back
            string url = "https://www.sandbox.paypal.com/cgi-bin/webscr";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);

            // Set values for the request back
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = query.Length;

            // Write the request back IPN strings
            StreamWriter stOut = new StreamWriter(req.GetRequestStream(), System.Text.Encoding.ASCII);
            stOut.Write(query);
            stOut.Close();

            StreamReader stIn = new StreamReader(req.GetResponse().GetResponseStream());
            strResponse = stIn.ReadToEnd();

            if (strResponse.Contains("\n"))
            {
                strResponse = strResponse.Replace("\n", " ");
            }

            status = strResponse.Substring(0, strResponse.IndexOf(" "));

            if (status != "FAIL")
            {
                Guid CustID = Guid.Parse(Session["CustomerID"].ToString());
                ManageUserSVC.ManageUserClient Client = new ManageUserSVC.ManageUserClient();
                ManageUserSVC.ManageUserCoverageData Coverage = new ManageUserCoverageData();

                if (Session["RenewCoverageInfo"] != null)
                {
                    Coverage = (ManageUserSVC.ManageUserCoverageData)Session["RenewCoverageInfo"];
                }
                else
                {
                    Coverage = (ManageUserSVC.ManageUserCoverageData)Session["CoverageInfo"];
                }

                Client.InsertCoverageData(Coverage);
                bool Propertybuy = false; ;
               
                Client.Update_Payment(CustID, decimal.Parse(Session["Amount"].ToString()), Propertybuy);

                if (Session["RenewCoverageInfo"] != null)
                {
                    lblMessage.Text = "Payment Successful! Your Account is Renewed Successfully!";
                    //todo sendmail for renew success
                }
                else
                {
                    string baseurl = System.Configuration.ConfigurationManager.AppSettings["HostingPrefix"];
                    lblMessage.Text = "Thank you! Your payment was successful.";
                    
                    idspan.Visible = true;
                    
                }

                string Local = System.Configuration.ConfigurationManager.AppSettings["HostingPrefix"];
                dowload(Local.Replace("https://", "http://") + "ProofEvidence.aspx?" + Crypto.ArgumentEncrypt("sss") + "=" + Crypto.Encrypt(CustID.ToString(), true), Coverage);

                SendEmailForProofOfEvidnce(Client, CustID, Local);
            }
            else
            {
                lblMessage.Text = "Some Error Occured while processing, Please try again By login into Site.!";
            }
        }
        char c = '"';
        private void SendEmailForProofOfEvidnce(ManageUserSVC.ManageUserClient Client, Guid CustID, string Local)
        {
            DataSet dsCus = new DataSet();
            dsCus = Client.GetCustomerInfo(CustID);
            StringBuilder strMailBody = new StringBuilder();
            string url = System.Configuration.ConfigurationManager.AppSettings["HostingPrefix"];

            if (Session["RenewCoverageInfo"] != null)
            {
                lblMessage.Text = "Payment Successful! Your Account is Renewed Successfully!";
                string renewSubject = ConfigurationManager.AppSettings["SendingRenewMail"].ToString();
                ManageUserSVC.ManageUserCoverageData Coverage = new ManageUserSVC.ManageUserCoverageData();
                Coverage = Session["RenewCoverageInfo"] as ManageUserCoverageData;
                string mailtemplate = File.ReadAllText(Server.MapPath(@"~/EmailTemplate/RenewMailTemplate.html"));
                mailtemplate = mailtemplate.Replace("[FullName]", dsCus.Tables[0].Rows[0]["FirstName"].ToString() + " " + dsCus.Tables[0].Rows[0]["LastName"].ToString());
                mailtemplate = mailtemplate.Replace("[URL]", url);
                mailtemplate = mailtemplate.Replace("[CoverageDate]", Coverage.CoverageDate.ToShortDateString());
                CommonFunction.SendEmail(dsCus.Tables[0].Rows[0]["EmailID"].ToString().Trim(), mailtemplate, renewSubject);                
            }

           
            //header
            strMailBody.Append("<p>&nbsp;</p>");
            strMailBody.Append("<div style=" + c + "margin-left: auto;height:500px;margin-right: auto;position: absolute;text-align: center;top: 0;width: 100%;z-index: 999;" + c + ">");
            strMailBody.Append("<div style=" + c + "background: url('" + url + "images/image.png') repeat-x scroll 0 0 transparent;height: 75px; width:798px;  position: relative;top: 0;z-index: 999;" + c + ">" + "<br/>");


            //body
            strMailBody.Append("<p>&nbsp;</p><table style='font-family: Tahoma;' border='0' cellpadding='0' cellspacing='0' width='600'><tbody><tr><td><table style='font-family: Tahoma;' border='0' cellpadding='0' cellspacing='0' width='600'>");
            strMailBody.Append("<tbody><tr style='font-family: Tahoma; font-size: 15px; color: rgb(33, 33, 33); text-align: left; ' valign='top'><td style='padding:35px 20px;font-family: Tahoma;'>");
            strMailBody.Append("<br/>" + dsCus.Tables[0].Rows[0]["FirstName"].ToString() + " " + dsCus.Tables[0].Rows[0]["LastName"].ToString() + "," + "<br /><br />");
            strMailBody.Append("Your Evidence of Coverage has been generated.<br /><br />");
           
            strMailBody.Append("To view your Evidence of Coverage please click <a href='" + url + "ViewDoc.ashx?" + Crypto.ArgumentEncrypt("ching") + "=" + Crypto.Encrypt(CustID.ToString(), true) + "&" + Crypto.ArgumentEncrypt("type") + "=" + Crypto.Encrypt("eve", true) + "' target='dscoverageview'>here</a><br/><br/>");
            
            strMailBody.Append("Sincerely,<br/>");
            strMailBody.Append("dscoverage.com<br/>");
            strMailBody.Append("</tr></tbody></table>");
            //footer

            strMailBody.Append("<div style=" + c + "background: url('" + url + "images/footer-b.jpg') no-repeat scroll 0 0 transparent;color: #939393;font-size: 10px;height: 60px;line-height: 44px;overflow: hidden;padding: 0 20px;width: 760px;margin-top: 5px;" + c + ">" + "<p style='float: left;color: white;'>Copyright © " + DateTime.Now.Year.ToString() + " <a href='https://dscoverage.com' target='_blank' style='color:white;font-weight: bolder;'>dscoverage.com</a>, Inc. All Rights Reserved.</p></div>");
            

            string pSubject = ConfigurationManager.AppSettings["SendingProofOfEvedence"].ToString();
            CommonFunction.SendEmail(dsCus.Tables[0].Rows[0]["EmailID"].ToString().Trim(), strMailBody.ToString(), pSubject);

            List<usp_GetEvedenceResult> DsCus = new List<usp_GetEvedenceResult>();            
            DsCus = Client.GetEvedenceInfoByCusID(CustID);

            if (DsCus != null && DsCus.Count > 0)
            { 
                //MKP
                //Guid EVEID = Guid.Parse(DsCus.ToList()[0].EvidenceID.ToString());
                foreach (usp_GetEvedenceResult item in DsCus)
                {
                    if (item.IsActive == true)
                    {
                        Guid EVEID = Guid.Parse(item.EvidenceID.ToString());
                        bool Updated = Client.Update_Evidence(CustID, DateTime.Now, true, EVEID, true);
                    }
                }
            }
        }


        protected void dowload(string link, ManageUserSVC.ManageUserCoverageData Coverage)
        {
            object obj = new object();
            lock (obj)
            {
                string WkFilePath = Request.PhysicalApplicationPath + @"WkHtml\wkhtmltopdf.exe";
                //string EXEFileName = @"C:\Program Files\wkhtmltopdf\wkhtmltopdf.exe";

                string args = string.Format("\"{0}\" - ", link);
                args += "-O Landscape";
                args += " -L 30";
                var startInfo = new ProcessStartInfo(WkFilePath, args)
                {
                    UseShellExecute = false,
                    RedirectStandardOutput = true
                };
                using (ManageUserSVC.ManageUserClient Cl = new ManageUserSVC.ManageUserClient())
                {
                    var proc = new Process { StartInfo = startInfo };
                    proc.Start();
                    string output = proc.StandardOutput.ReadToEnd();
                    byte[] buffer = proc.StandardOutput.CurrentEncoding.GetBytes(output);
                    proc.WaitForExit();
                    proc.Close();

                    bool Valid = StoreinDB(buffer, Cl, Coverage);
                }
            }
        }

        private bool StoreinDB(byte[] buffer, ManageUserSVC.ManageUserClient client, ManageUserSVC.ManageUserCoverageData Coverage)
        {
            bool Valid = true;
            List<usp_GetEvedenceResult> DsCus = new List<usp_GetEvedenceResult>();            
            DsCus = client.GetEvedenceInfoByCusID(Guid.Parse(Session["CustomerID"].ToString()));

            if (DsCus != null && DsCus.Count > 0)
            {
                foreach (usp_GetEvedenceResult item in DsCus)
                {
                    if (item.IsActive.Value)
                    {
                        client.Update_Evidence(Guid.Parse(Session["CustomerID"].ToString()), DateTime.Now, false, item.EvidenceID, true);
                    }
                }
            }

            if (DsCus != null && DsCus.Count > 0)
            {
                
                {
                    //Delete Evedence, need to renew account.
                    //client.Delete_Evidence(Guid.Parse(Session["CustomerID"].ToString()));

                    //Insert Newely generated Evedence after renew...
                    client.InsertEvedence(Guid.NewGuid(), Coverage.CoverageDate,
                                         Guid.Parse(Session["CustomerID"].ToString()), DateTime.Now, true, true, buffer);
                }
            }
            else
            {
                //Inserted New Evedence.
                client.InsertEvedence(Guid.NewGuid(), Coverage.CoverageDate,
                                         Guid.Parse(Session["CustomerID"].ToString()), DateTime.Now, true, true, buffer);
            }

            return Valid;
        }

        protected void lnkEve_Click(object sender, EventArgs e)
        {
            Session["CustomerID"] = ViewState["CurrentCustomer"];
            Guid CustID = Guid.Parse(Session["CustomerID"].ToString());

            using (ManageUserSVC.ManageUserClient Client = new ManageUserClient())
            {
                List<usp_GetEvedenceResult> ListEvedences = new List<usp_GetEvedenceResult>();
                ListEvedences = Client.GetEvedenceInfoByCusID(CustID);

                if (ListEvedences != null && ListEvedences.Count > 0)
                {
                    foreach (usp_GetEvedenceResult item in ListEvedences)
                    {
                        if (item.IsActive.Value)
                        {
                            string url = System.Configuration.ConfigurationManager.AppSettings["HostingPrefix"];
                            string script = "window.open('" + url + "View.aspx?" + Crypto.ArgumentEncrypt("id") + "=" + Crypto.Encrypt(CustID.ToString(), true) + "&" + Crypto.ArgumentEncrypt("type") + "=" + Crypto.Encrypt("eve", true) + "', 'MyScript', 'fullscreen=yes,location=center,resizable=yes');";
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "open", script, true);
                        }
                    }
                }
            }
        }
    }
}