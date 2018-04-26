using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Insurance
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //disable button after click...
            string strProcessScript = "this.value='Processing...';this.disabled=true;";
            btn4AutoRize.Attributes.Add("onclick", strProcessScript + ClientScript.GetPostBackEventReference(btn4AutoRize, "").ToString());


            customerEnrollment.LabelError.Visible = false;
            if (!IsPostBack)
            {
                //MKP
                //coverageInformation.CoverageInformationDate.StartDate = DateTime.Now;

                if (Session["RenewBeforeOneMonthCoverageEndDate"] != null)
                {
                    coverageInformation.CoverageInformationDate.SelectedDate = (DateTime ?)Session["RenewBeforeOneMonthCoverageEndDate"];
                }
                else
                {
                    coverageInformation.CoverageInformationDate.SelectedDate = DateTime.Now.AddDays(1);
                }
                                
                coverageInformation.LabelCoverageDate.Text = "Your Coverage Date will start from " + coverageInformation.CoverageInformationDate.SelectedDate.Value.ToString("MM/dd/yyyy").Replace("-", "/") + ".";

                coverageInformation.CoverageDate.Text = coverageInformation.CoverageInformationDate.SelectedDate.Value.ToString("MM/dd/yyyy").Replace("-", "/");
                            

                multiViewRegistration.ActiveViewIndex = 0;
                OtherSVC.OtherClient client = new OtherSVC.OtherClient();
                DataSet ds = client.GetCompany_List();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    customerEnrollment.CompnyAffilation.DataSource = ds;
                    customerEnrollment.CompnyAffilation.DataTextField = "Description";
                    customerEnrollment.CompnyAffilation.DataValueField = "CompAffilationID";
                    customerEnrollment.CompnyAffilation.DataBind();
                    customerEnrollment.CompnyAffilation.Items.Insert(0, new ListItem("--Select--","select"));
                }

                string[] Month = new string[] { "Month", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12" };
                creditCardInformation.Month.DataSource = Month;
                creditCardInformation.Month.DataBind();
                //pre-select one for testing
                creditCardInformation.Month.SelectedIndex = 0;

                //populate year
                creditCardInformation.Year.Items.Add("Year");
                int Year = DateTime.Now.Year;
                for (int i = 0; i < 10; i++)
                {
                    creditCardInformation.Year.Items.Add((Year + i).ToString());
                }
                //pre-select one for testing
                creditCardInformation.Year.SelectedIndex = 0;
               
                string EmailAdd = "";
                #region coverage start
                if (Session["value"] != null && Session["pnl"] != null)
                {
                    int Value = Convert.ToInt32(Session["pnl"].ToString());
                    string str = Session["value"].ToString();
                    Guid CusID = Guid.Parse(Crypto.Decrypt(str, true));
                    ManageUserSVC.ManageUserClient Userinfo = new ManageUserSVC.ManageUserClient();
                    DataSet Data = new DataSet();
                    Data = Userinfo.GetCustomerInfo(CusID);

                    if (Request.QueryString[Crypto.ArgumentEncrypt("time")] != null && str != null)
                    {
                        string val = Crypto.Decrypt(Request.QueryString[Crypto.ArgumentEncrypt("time")].ToString(), true);
                        enrollDescription.LabelRenew.Visible = true;

                        if (val.ToLower().Equals("renew") && Data != null && Data.Tables[0].Rows.Count > 0)
                        {
                            ViewState["RenewCustomer"] = Data;
                            Session["RenewCustomer"] = Data;

                            ViewState["custID"] = Data.Tables[0].Rows[0]["Cust_ID"].ToString();
                            Session["CustomerID"] = Data.Tables[0].Rows[0]["Cust_ID"].ToString();
                            ViewState["EmailID"] = Data.Tables[0].Rows[0]["EmailID"].ToString();
                            EmailAdd = Data.Tables[0].Rows[0]["EmailID"].ToString();
                            Session["CustomerInfo"] = Data.Tables[0].Rows[0]["FirstName"].ToString() + " " + Data.Tables[0].Rows[0]["LastName"].ToString();                            
                            multiViewRegistration.ActiveViewIndex = 1;
                            PopulateCustomerInformation();
                            return;
                        }
                    }
                    if (Data.Tables[0].Rows[0]["Payment"].ToString() == "0.0000")
                    {
                        if (Value == 3 && Data != null && Data.Tables[0].Rows.Count > 0)
                        {
                            ViewState["custID"] = Data.Tables[0].Rows[0]["Cust_ID"].ToString();
                            Session["CustomerID"] = Data.Tables[0].Rows[0]["Cust_ID"].ToString();
                            ViewState["EmailID"] = Data.Tables[0].Rows[0]["EmailID"].ToString();
                            EmailAdd = Data.Tables[0].Rows[0]["EmailID"].ToString();
                            Session["CustomerInfo"] = Data.Tables[0].Rows[0]["FirstName"].ToString() + " " + Data.Tables[0].Rows[0]["LastName"].ToString();
                            multiViewRegistration.ActiveViewIndex = 2;
                        }
                    }
                    else if (Data.Tables[0].Rows[0]["Payment"].ToString() != "50.0000")
                    {                        
                        coverageInformation.LBL.Visible = true;
                        multiViewRegistration.ActiveViewIndex = 2;
                    }
                }

                #endregion

                #region Retry Payment

                if (Request.QueryString[Crypto.ArgumentEncrypt("retrypayment")] != null)
                {                    
                     multiViewRegistration.ActiveViewIndex = 3;
                    
                    creditCardInformation.LabelAmount.Text = System.Configuration.ConfigurationManager.AppSettings["Non-Membership"];
                    if (EmailAdd != "")
                    {
                        string Memres = CheckMember(EmailAdd);
                        if (Memres == "Y")
                            creditCardInformation.LabelAmount.Text = System.Configuration.ConfigurationManager.AppSettings["Membership"];
                        else
                            creditCardInformation.LabelAmount.Text = System.Configuration.ConfigurationManager.AppSettings["Non-Membership"];
                    }
                }

                #endregion
            }
        }
        private string CheckMember(string EmailID)
        {
            string read = string.Empty;
            try
            {
                
                WebClient client = new WebClient();
                Stream data = client.OpenRead(ConfigurationManager.AppSettings["memberurl"].ToString() + EmailID);
                //Stream data = client.OpenRead("http://www.independentdirectsellers.org/z28-verify-user.php?email=" + EmailID);
                StreamReader reader = new StreamReader(data);
                read = reader.ReadToEnd();
                data.Close();
                reader.Close();                
            }
            catch (Exception ex)
            {
               
            }
            return read;
           
        }   
        protected void btnCoverageInformation_Click(object sender, EventArgs e)
        {
            multiViewRegistration.ActiveViewIndex = 4;
        }

        protected void btnBeginEnrollmentViaProductControl_Click(object sender, EventArgs e)
        {
            multiViewRegistration.ActiveViewIndex = 0;
        }



        private void PopulateCustomerInformation()
        {
            if (ViewState["RenewCustomer"] != null)
            {
                DataSet Data = ViewState["RenewCustomer"] as DataSet;
                if (Data != null && Data.Tables[0].Rows.Count > 0)
                {
                    customerEnrollment.UserID.Text = Data.Tables[0].Rows[0]["PersonalID"].ToString();
                    customerEnrollment.FirstName.Text = Data.Tables[0].Rows[0]["FirstName"].ToString();
                    customerEnrollment.LastName.Text = Data.Tables[0].Rows[0]["LastName"].ToString();
                    customerEnrollment.CompanyName.Text = Data.Tables[0].Rows[0]["Company_Name"].ToString();
                    customerEnrollment.EmailID.Text = Data.Tables[0].Rows[0]["EmailID"].ToString();
                    customerEnrollment.Address.Text = Data.Tables[0].Rows[0]["Address"].ToString();
                    customerEnrollment.PhoneNo.Text = Data.Tables[0].Rows[0]["PhoneNo"].ToString();
                    customerEnrollment.City.Text = Data.Tables[0].Rows[0]["City"].ToString();
                    customerEnrollment.States.SelectedValue = Data.Tables[0].Rows[0]["State"].ToString();
                    customerEnrollment.ZipCode.Text = Data.Tables[0].Rows[0]["ZipCode"].ToString();
                    string sr = Data.Tables[0].Rows[0]["CompAffilationID"].ToString();
                    customerEnrollment.CompnyAffilation.SelectedValue = Data.Tables[0].Rows[0]["CompAffilationID"].ToString();
                    customerEnrollment.EmailID.Enabled = false;
                }
            }
        }



        protected void btnBeginEnrollment_Click(object sender, EventArgs e)
        {  
            multiViewRegistration.ActiveViewIndex = 1;
            this.Page.Form.DefaultButton = btn2Next.UniqueID;
        }


        protected void btn2Back_Click(object sender, EventArgs e)
        {
            multiViewRegistration.ActiveViewIndex = 0;
        }

        char c = '"';
        protected void btn2Next_Click(object sender, EventArgs e)
        {
            customerEnrollment.LabelError.Visible = false;
            ManageUserSVC.ManageUserClient client = new ManageUserSVC.ManageUserClient();
            ManageUserSVC.ManageUserCustomerData UserData = new ManageUserSVC.ManageUserCustomerData();
            ManageUserSVC.ManageUserCoverageData CoverData = new ManageUserSVC.ManageUserCoverageData();
            customerEnrollment.LabelError.Text = "";
            //lblSuccess.Text = "";
            if (customerEnrollment.IsValidate())
            {
                if (customerEnrollment.Agree.Checked)
                {
                    if (ViewState["RenewCustomer"] == null)
                    {
                        string Chk = client.CheckEmailID(customerEnrollment.EmailID.Text);
                        if (Chk.Equals("EXIST"))
                        {
                            customerEnrollment.LavelGoToLogin.Visible = true;
                            customerEnrollment.linkLogin.Visible = true;
                            customerEnrollment.LavelGoToLogin.Text = "This Email Id is Already Exists, Please click on link for login";
                        }
                        else
                        {
                            UserData.PersonalID = customerEnrollment.UserID.Text;
                            UserData.CustID = Guid.NewGuid();
                            ViewState["custID"] = UserData.CustID;
                            Session["CustomerID"] = UserData.CustID;

                            UserData.FirstName = customerEnrollment.FirstName.Text;
                            UserData.CompanyName = customerEnrollment.CompanyName.Text;
                            UserData.Address = customerEnrollment.Address.Text;
                            UserData.EmailID = customerEnrollment.EmailID.Text;
                            ViewState["EmailID"] = UserData.EmailID;
                            UserData.PhoneNo = customerEnrollment.PhoneNo.Text;
                            UserData.City = customerEnrollment.City.Text;
                            if (!customerEnrollment.States.SelectedItem.Text.Equals("--Select--"))
                            {
                                UserData.State = customerEnrollment.States.SelectedItem.Text;
                            }

                            UserData.ZipCode = customerEnrollment.ZipCode.Text;
                            UserData.Country = "US";
                            if (!customerEnrollment.CompnyAffilation.SelectedItem.Text.Equals("--Select--"))
                            {
                                UserData.CompanyAffilID = Guid.Parse(customerEnrollment.CompnyAffilation.SelectedItem.Value);
                            }
                            UserData.SignUpDate = DateTime.Now;
                            UserData.LastUpdated = DateTime.Now;
                            UserData.LastName = customerEnrollment.LastName.Text;

                            UserData.IsActivePolicy = false;
                            UserData.IsActive = true;
                            UserData.IsPropertyBuy = false;
                            UserData.InsuraceType = "";
                            UserData.Payment = 0;
                            UserData.YourID = GetID(customerEnrollment.LastName.Text, customerEnrollment.PhoneNo.Text);
                            UserData.ApplicationNo = DateTime.Now.Ticks.ToString("x").ToUpper();
                            UserData.SecurityCode = Guid.NewGuid().ToString().GetHashCode().ToString("x");
                            Session["Paswrd"] = UserData.SecurityCode;
                            UserData.VerifyEmail = false;
                            Session["CustomerInfo"] = UserData.FirstName + " " + UserData.LastName;
                            UserData.IsSecCodeSent = false;

                            string url = System.Configuration.ConfigurationManager.AppSettings["HostingPrefix"];


                            //Sending verify email...
                            //string VerifyString = url + "Validate.aspx?id=" + Guid.NewGuid().ToString();
                            StringBuilder strVerifyBody = new StringBuilder();
                            string headurl = url + "images/image.png";
                            //header
                            strVerifyBody.Append("<p>&nbsp;</p>");
                            strVerifyBody.Append("<div style=" + c + "margin-left: auto;height:500px;margin-right: auto;position: absolute;text-align: center;top: 0;width: 100%;z-index: 999;" + c + ">");
                            strVerifyBody.Append("<div style=" + c + "background: url('" + headurl + "') repeat-x scroll 0 0 transparent;height: 75px; width:798px;  position: relative;top: 0;z-index: 999;" + c + ">" + "<br/>");

                            //body
                            strVerifyBody.Append("<p>&nbsp;</p><table style='font-family: Tahoma;' border='0' cellpadding='0' cellspacing='0' width='600'><tbody><tr><td><table style='font-family: Tahoma;' border='0' cellpadding='0' cellspacing='0' width='600'>");
                            strVerifyBody.Append("<tbody><tr style='font-family: Tahoma; font-size: 15px; color: rgb(33, 33, 33); text-align: left; ' valign='top'><td style='padding:35px 20px;font-family: Tahoma;'>");

                            strVerifyBody.Append("<br/>" + UserData.FirstName + " " + UserData.LastName + "," + "<br/><br/>");
                            strVerifyBody.Append("Welcome to dscoverage.com</b><br/><br/>");
                            strVerifyBody.Append("Please verify your email address by clicking <a href='" + url + "Validate.aspx?" + Crypto.ArgumentEncrypt("veryid") + "=" + Crypto.Encrypt(UserData.CustID.ToString(), true) + "' target='dscoveragemain'> here</a><br/><br/>");
                            strVerifyBody.Append("Sincerely,<br/>");
                            strVerifyBody.Append("dscoverage.com<br/>");
                            strVerifyBody.Append("</tr></tbody></table>");
                            //footer
                            string footurl = url + "images/footer-b.jpg";
                            strVerifyBody.Append("<div style=" + c + "background: url('" + url + "images/footer-b.jpg') no-repeat scroll 0 0 transparent;color: #939393;font-size: 10px;height: 60px;line-height: 44px;overflow: hidden;padding: 0 20px;width: 760px;margin-top: 5px;" + c + ">" + "<p style='float: left;color: white;'>Copyright © " + DateTime.Now.Year.ToString() + " <a href='https://dscoverage.com' target='_blank' style='color:white;font-weight: bolder;'>dscoverage.com</a>, Inc. All Rights Reserved.</p></div>");
                            string Subject = ConfigurationManager.AppSettings["VerifyEmailSubject"].ToString();
                            bool Sent1 = CommonFunction.SendEmail(customerEnrollment.EmailID.Text.Trim(), strVerifyBody.ToString(), Subject);

                            if (Sent1)
                            {
                                client.InsertUser(UserData);
                                Response.Redirect("Validate.aspx?" + Crypto.ArgumentEncrypt("ressult") + "=" + Crypto.Encrypt("sucess", true));
                            }
                            else
                            {
                                Response.Redirect("Validate.aspx?" + Crypto.ArgumentEncrypt("ressult") + "=" + Crypto.Encrypt("fail", true));
                            }
                            //pnl2Custmrinfo.Visible = false;
                        }
                    }
                    if (ViewState["RenewCustomer"] != null)
                    {
                        DataSet Data = ViewState["RenewCustomer"] as DataSet;
                        if (Data != null && Data.Tables[0].Rows.Count > 0)
                        {
                            UserData.CustID = Guid.Parse(Data.Tables[0].Rows[0]["Cust_ID"].ToString());
                            Session["CustomerID"] = UserData.CustID;

                            UserData.PersonalID = customerEnrollment.UserID.Text;
                            UserData.FirstName = customerEnrollment.FirstName.Text;
                            UserData.CompanyName = customerEnrollment.CompanyName.Text;
                            UserData.Address = customerEnrollment.Address.Text;
                            UserData.EmailID = customerEnrollment.EmailID.Text;
                            UserData.PhoneNo = customerEnrollment.PhoneNo.Text;
                            UserData.City = customerEnrollment.City.Text;
                            if (!customerEnrollment.States.SelectedItem.Text.Equals("--Select--"))
                            {
                                UserData.State = customerEnrollment.States.SelectedItem.Text;
                            }

                            UserData.ZipCode = customerEnrollment.ZipCode.Text;
                            UserData.Country = "US";
                            if (!customerEnrollment.CompnyAffilation.SelectedItem.Text.Equals("--Select--"))
                            {
                                UserData.CompanyAffilID = Guid.Parse(customerEnrollment.CompnyAffilation.SelectedItem.Value);
                            }
                            UserData.SignUpDate = DateTime.Now;
                            UserData.LastUpdated = DateTime.Now;
                            UserData.LastName = customerEnrollment.LastName.Text;

                            UserData.IsActivePolicy = false;
                            UserData.IsActive = true;
                            UserData.IsPropertyBuy = false;
                            UserData.InsuraceType = "";
                            UserData.Payment = 0;
                            Session["CustomerInfo"] = UserData.FirstName + " " + UserData.LastName;


                            //Added By MKP
                            UserData.YourID = Data.Tables[0].Rows[0]["YID"] != null ? Convert.ToString(Data.Tables[0].Rows[0]["YID"]) : GetID(customerEnrollment.LastName.Text, customerEnrollment.PhoneNo.Text);
                            UserData.ApplicationNo = Data.Tables[0].Rows[0]["ApplicationNo"] != null ? Convert.ToString(Data.Tables[0].Rows[0]["ApplicationNo"]) :DateTime.Now.Ticks.ToString("x").ToUpper();
                            UserData.SecurityCode = Data.Tables[0].Rows[0]["SecurityCode"] != null ? Convert.ToString(Data.Tables[0].Rows[0]["SecurityCode"]) : Guid.NewGuid().ToString().GetHashCode().ToString("x");
                            UserData.VerifyEmail = true;
                            UserData.IsSecCodeSent = Data.Tables[0].Rows[0]["IsSecCodeSent"] != null ? Convert.ToBoolean(Data.Tables[0].Rows[0]["IsSecCodeSent"]) : false;
                            UserData.VerifyEmail = Data.Tables[0].Rows[0]["VerifyEmail"] != null ? Convert.ToBoolean(Data.Tables[0].Rows[0]["VerifyEmail"]) : false;
                            
                            //Code Commented By MKP 
                            //UserData.IsSecCodeSent = false;
                            //UserData.YourID = GetID(customerEnrollment.LastName.Text, customerEnrollment.PhoneNo.Text);
                            //UserData.ApplicationNo = DateTime.Now.Ticks.ToString("x").ToUpper();
                            //UserData.SecurityCode = Guid.NewGuid().ToString().GetHashCode().ToString("x");
                            //Session["Paswrd"] = UserData.SecurityCode;
                            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                            //Code Commented By MKP 

                            //string url = System.Configuration.ConfigurationManager.AppSettings["HostingPrefix"];
                            //StringBuilder strVerifyBody = new StringBuilder();

                            ////header
                            //strVerifyBody.Append("<p>&nbsp;</p>");
                            //strVerifyBody.Append("<div style=" + c + "margin-left: auto;height:500px;margin-right: auto;position: absolute;text-align: center;top: 0;width: 100%;z-index: 999;" + c + ">");
                            //strVerifyBody.Append("<div style=" + c + "background: url('" + url + "images/image.png') repeat-x scroll 0 0 transparent;height: 75px; width:798px;  position: relative;top: 0;z-index: 999;" + c + ">" + "<br/>");
                            //// strVerifyBody.Append("<span style=" + c + "margin-left:661px; background color:white;" + c + ">" + "Welcome" + " " + UserData.FirstName + UserData.LastName + " </span>");

                            ////body
                            //strVerifyBody.Append("<html><body><p>&nbsp;</p><table style='font-family: Tahoma;' border='0' cellpadding='0' cellspacing='0' width='600'><tbody><tr><td><table style='font-family: Tahoma;' border='0' cellpadding='0' cellspacing='0' width='600'>");
                            //strVerifyBody.Append("<tbody><tr style='font-family: Tahoma; font-size: 15px; color: rgb(33, 33, 33); text-align: left; ' valign='top'><td style='padding:35px 20px;font-family: Tahoma;'>");
                            //strVerifyBody.Append("<br/>" + UserData.FirstName + " " + UserData.LastName + "," + "<br/><br/>");
                            //strVerifyBody.Append("Welcome to dscoverage.com</b><br/><br/>");
                            //strVerifyBody.Append("Please verify your email address by clicking <a href='" + url + "Insurance/Validate.aspx?" + Crypto.ArgumentEncrypt("veryid") + "=" + Crypto.Encrypt(UserData.CustID.ToString(), true) + "' target='dscoveragemain'> here</a><br/><br/>");
                            //strVerifyBody.Append("Sincerely,<br/>");
                            //strVerifyBody.Append("dscoverage.com<br/>");
                            //strVerifyBody.Append("</tr></tbody></table>");
                            ////footer

                            //strVerifyBody.Append("<div style=" + c + "background: url('" + url + "images/footer-b.jpg') no-repeat scroll 0 0 transparent;color: #939393;font-size: 10px;height: 60px;line-height: 44px;overflow: hidden;padding: 0 20px;width: 760px;margin-top: 5px;" + c + ">" + "<p style='float: left;color: white;'>Copyright © " + DateTime.Now.Year.ToString() + " <a href='https://dscoverage.com' target='dscoveragemain' style='color:white;font-weight: bolder;'>dscoverage.com</a>, Inc. All Rights Reserved.</p></div>");
                            //string Subject = ConfigurationManager.AppSettings["VerifyEmailSubject"].ToString();
                            //bool Sent1 = CommonFunction.SendEmail(customerEnrollment.EmailID.Text.Trim(), strVerifyBody.ToString(), Subject);
                            //client.Update_VerificationStatus(UserData.CustID, false, false);
                            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                            
                            client.InsertUser(UserData);
                            //pnl2Custmrinfo.Visible = false;
                            //pnl3Coverage.Visible = true;
                            multiViewRegistration.ActiveViewIndex = 2;
                            if (!VerifyEmail(Guid.Parse(UserData.CustID.ToString())))
                            coverageInformation.LabelEmailValidate.Visible = true;
                            //Response.Redirect("Validate.aspx?" + Crypto.ArgumentEncrypt("renewaccnt") + "=" + Crypto.Encrypt("success", true));
                        }
                    }
                    this.Page.Form.DefaultButton = btn3Next.UniqueID;
                }
                else
                {
                    customerEnrollment.LavelAgreeError.Visible = true;
                    customerEnrollment.LavelAgreeError.Text = "Please Read Terms And Conditions.";
                }
            }
        }

        private string GetID(string LastName, string PhoneNo)
        {
            StringBuilder ID = new StringBuilder();
            if (LastName.Length > 3)
            {
                ID.Append(LastName.Substring(0, 3).ToUpper());
            }
            else
            {
                ID.Append(LastName.ToUpper());
            }
            ID.Append("-");

            if (PhoneNo.Length > 5)
            {
                ID.Append(PhoneNo.Substring(0, 5));
            }
            else
            {
                ID.Append(PhoneNo);
            }
            ID.Append("-");
            ID.Append((DateTime.Now.Day.ToString().Length <= 1 ? "0" + DateTime.Now.Day.ToString() : DateTime.Now.Day.ToString()) + (DateTime.Now.Month.ToString().Length <= 1 ? "0" + DateTime.Now.Month.ToString() : DateTime.Now.Month.ToString()));
            ID.Append("-");
            ID.Append(DateTime.Now.TimeOfDay.Ticks);

            return ID.ToString();
        }

        protected void btn3Back_Click(object sender, EventArgs e)
        {
            customerEnrollment.UserID.Text = "";
            customerEnrollment.FirstName.Text = "";
            customerEnrollment.LastName.Text = "";
            customerEnrollment.EmailID.Text = "";
            customerEnrollment.Address.Text = "";
            customerEnrollment.PhoneNo.Text = "";
            customerEnrollment.City.Text = "";
            customerEnrollment.States.SelectedIndex = 0;
            customerEnrollment.ZipCode.Text = "";
            customerEnrollment.LabelError.Text = "";
            customerEnrollment.CompnyAffilation.SelectedIndex = 0;
            Response.Redirect("~/Home.aspx");
        }
        
        protected void btn3Next_Click(object sender, EventArgs e)
        {
            coverageInformation.LabelEmailValidate.Visible = false;
            coverageInformation.LabelPayment.Visible = false;
            string EmailAdd = "";
            if (IsValidcoverage())
            {
                string Date = coverageInformation.CoverageDate.Text;
                ManageUserSVC.ManageUserCoverageData Coverage = new ManageUserSVC.ManageUserCoverageData();
                ManageUserSVC.ManageUserClient client = new ManageUserSVC.ManageUserClient();

                if (ViewState["RenewCustomer"] != null)
                {
                    DataSet Data = ViewState["RenewCustomer"] as DataSet;
                    if (Data != null && Data.Tables[0].Rows.Count > 0)
                    {
                        DataSet CovData = new DataSet();
                        Guid CustomerID = Guid.Parse(Data.Tables[0].Rows[0]["Cust_ID"].ToString());
                        if (VerifyEmail(CustomerID))
                        {
                            if (!coverageInformation.ThreeYearCheck.Checked && !coverageInformation.FiveYearCheck.Checked)
                            {
                                Coverage.CoverageID = Guid.NewGuid();
                                DateTime CoverageDate = DateTime.ParseExact(Date, "MM/dd/yyyy", System.Globalization.CultureInfo.GetCultureInfo("en-US"));
                                Coverage.CoverageDate = CoverageDate;
                                Coverage.CustID = Guid.Parse(Data.Tables[0].Rows[0]["Cust_ID"].ToString());
                                Coverage.yr3Loss = coverageInformation.ThreeYearCheck.Checked;
                                Coverage.yr5Loss = coverageInformation.FiveYearCheck.Checked;
                                Coverage.Status = "True";                               
                                Session["RenewCoverageInfo"] = Coverage;                               
                                multiViewRegistration.ActiveViewIndex = 3; 

                                this.Page.Form.DefaultButton = btn4AutoRize.UniqueID;
                            }
                            else
                            {
                                Response.Redirect("Reason.aspx");
                            }

                            DataSet ds = new DataSet();
                            ds = client.GetCustomerInfo(CustomerID);
                            if (ds != null && ds.Tables[0].Rows.Count > 0)
                            {
                                EmailAdd = ds.Tables[0].Rows[0]["EmailID"].ToString();
                            }
                        }
                        else
                        {
                            coverageInformation.LabelEmailValidate.Visible = true;
                            coverageInformation.LabelEmailValidate.Focus();
                        }
                    }
                }
                else
                {
                    if (VerifyEmail(Guid.Parse(ViewState["custID"].ToString())))
                    {
                        if (!coverageInformation.ThreeYearCheck.Checked && !coverageInformation.FiveYearCheck.Checked)
                        {
                            Coverage.CoverageID = Guid.NewGuid();
                            Session["CustomerID"] = ViewState["custID"].ToString();
                            Session["CustomerID"] = ViewState["custID"].ToString();
                            DateTime CoverageDate = DateTime.ParseExact(Date, "MM/dd/yyyy", System.Globalization.CultureInfo.GetCultureInfo("en-US"));
                            Coverage.CoverageDate = CoverageDate;
                            Coverage.CustID = Guid.Parse(ViewState["custID"].ToString());
                            Coverage.yr3Loss = coverageInformation.ThreeYearCheck.Checked;
                            Coverage.yr5Loss = coverageInformation.FiveYearCheck.Checked;
                            Coverage.Status = "True";
                            Session["CoverageInfo"] = Coverage;                            
                            //pnl3Coverage.Visible = false;
                            //pnl4Payment.Visible = true;
                            //pnlPropay.Visible = true;
                            multiViewRegistration.ActiveViewIndex = 3;
                        }
                        else
                        {
                            Response.Redirect("Reason.aspx");
                        }

                        DataSet ds = new DataSet();
                        ds = client.GetCustomerInfo(Guid.Parse(ViewState["custID"].ToString()));
                        if (ds != null && ds.Tables[0].Rows.Count > 0)
                        {
                            EmailAdd = ds.Tables[0].Rows[0]["EmailID"].ToString();
                        }
                    }
                    else
                    {
                        coverageInformation.LabelEmailValidate.Visible = true;
                        coverageInformation.LabelEmailValidate.Focus();
                    }
                }

                creditCardInformation.LabelAmount.Text = System.Configuration.ConfigurationManager.AppSettings["Non-Membership"];
                if (EmailAdd != "")
                {
                    string Memres = CheckMember(EmailAdd);
                    if (Memres == "Y")
                        creditCardInformation.LabelAmount.Text = System.Configuration.ConfigurationManager.AppSettings["Membership"];
                    else
                        creditCardInformation.LabelAmount.Text = System.Configuration.ConfigurationManager.AppSettings["Non-Membership"];
                }


            }


            this.Page.Form.DefaultButton = btn4AutoRize.UniqueID;
            Response.Cookies.Clear();
        }


        private bool VerifyEmail(Guid CusID)
        {
            bool verified = true;
            ManageUserSVC.ManageUserClient client = new ManageUserSVC.ManageUserClient();
            DataSet ds = new DataSet();
            ds = client.GetCustomerInfo(CusID);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["EmailID"].ToString() == "")
                {
                    verified = false;
                }
            }

            return verified;
        }

        private bool IsValidcoverage()
        {
            ManageUserSVC.ManageUserClient client = new ManageUserSVC.ManageUserClient();
            DataSet ds = new DataSet();
            ds = client.GetCustomerInfo(Guid.Parse(Session["CustomerID"].ToString()));
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["VerifyEmail"].ToString() == "")
                {
                    coverageInformation.LabelEmailValidate.Visible = true;
                    return false;
                }
            }

            return true;
        }

        private string ShowPayPalInfo(NameValueCollection RequestCollection)
        {
            string PayPalInfo = "";
            foreach (string key in RequestCollection.AllKeys)
            {
                PayPalInfo += "<br /><span class=\"bold-text\">" + key + ":</span> " + RequestCollection[key];
            }
            return PayPalInfo;
        }

        private NameValueCollection GetPayPalCollection(string payPalInfo)
        {
            NameValueCollection PayPalCollection = new System.Collections.Specialized.NameValueCollection();
            string[] ArrayReponses = payPalInfo.Split('&');

            for (int i = 0; i < ArrayReponses.Length; i++)
            {
                string[] Temp = ArrayReponses[i].Split('=');
                PayPalCollection.Add(Temp[0], Temp[1]);
            }
            return PayPalCollection;
        }

        protected void btn4AutoRize_Click(object sender, EventArgs e)
        {
            bool Completed = false;
            if ( creditCardInformation.Is4Valid())
            {
                string enterFunctionLogger = "Enter :: btn4AutoRize_Click";
                LogWritter.LogFileWrite(enterFunctionLogger);
                try
                {
                    if (ViewState["custID"] != null)
                        Session["CustomerID"] = ViewState["custID"].ToString();

                    ManageUserSVC.ManageUserClient Userinfo = new ManageUserSVC.ManageUserClient();
                    DataSet Data = new DataSet();
                    Data = Userinfo.GetCustomerInfo(Guid.Parse(Session["CustomerID"].ToString()));
                    if (Data != null && Data.Tables[0].Rows.Count > 0)
                    {
                        string EmailAdd = Data.Tables[0].Rows[0]["EmailID"].ToString();
                        if (EmailAdd.Trim().Equals(creditCardInformation.EmailID.Text.Trim()))
                        {
                            SPSServiceSVC.SPSServiceClient service = new SPSServiceSVC.SPSServiceClient();

                            SPSServiceSVC.ID identityinfo = new SPSServiceSVC.ID();
                            identityinfo.AuthenticationToken = ConfigurationManager.AppSettings["AuthenticationToken"].ToString();
                            identityinfo.BillerAccountId = ConfigurationManager.AppSettings["BillerID"].ToString();

                            SPSServiceSVC.TempTokenRequest tokn = new SPSServiceSVC.TempTokenRequest();
                            tokn.PayerInfo = new SPSServiceSVC.PayerInformation();
                            tokn.PayerInfo.Name = "Insurance";
                            tokn.Identification = identityinfo;
                            SPSServiceSVC.TempTokenResult toknres = service.GetTempToken(tokn);

                            SPSServiceSVC.Transaction trans = new SPSServiceSVC.Transaction();
                            trans.CurrencyCode = "USD";

                            double val = Convert.ToDouble(creditCardInformation.LabelAmount.Text);
                            double amount = val * 100;
                            trans.Amount = Convert.ToDouble(amount).ToString();
                            Session["Amount"] = trans.Amount;
                            trans.PayerAccountId = toknres.PayerId;

                            SPSServiceSVC.PaymentMethodAdd payadd = new SPSServiceSVC.PaymentMethodAdd();
                            payadd.AccountNumber = creditCardInformation.CardNumber.Text.Trim();          //credit card no.
                            payadd.Description = ConfigurationManager.AppSettings["AccountDescription"].ToString();
                            payadd.PayerAccountId = toknres.PayerId;
                            payadd.PaymentMethodType = creditCardInformation.CardType.SelectedValue.Trim();


                            SPSServiceSVC.CreatePaymentMethodResult paymethodres = service.CreatePaymentMethod(identityinfo, payadd);

                            SPSServiceSVC.PaymentInfoOverrides payereriditinfo = new SPSServiceSVC.PaymentInfoOverrides();
                            payereriditinfo.CreditCard = new SPSServiceSVC.CreditCardOverrides();
                            payereriditinfo.CreditCard.ExpirationDate = creditCardInformation.Month.SelectedItem.Text.Trim() + creditCardInformation.Year.SelectedItem.Text.Trim().Substring(2, 3 - 1);
                            payereriditinfo.CreditCard.Billing = new SPSServiceSVC.Billing();
                            payereriditinfo.CreditCard.Billing.City = creditCardInformation.City.Text.Trim();
                            payereriditinfo.CreditCard.Billing.Country = "US";
                            payereriditinfo.CreditCard.Billing.Email = creditCardInformation.EmailID.Text.Trim();
                            payereriditinfo.CreditCard.Billing.ZipCode = creditCardInformation.Zip.Text.Trim();
                            payereriditinfo.CreditCard.FullName = creditCardInformation.CardHolderFirstName.Text.Trim() + " " + creditCardInformation.CardHolderLastName.Text.Trim();


                            if (string.IsNullOrEmpty(paymethodres.PaymentMethodId))
                            {
                                string paymentMethodIdLogger = "Payment Not succed becuase of PaymentMethodId is null";
                                LogWritter.LogFileWrite(paymentMethodIdLogger);
                            }
                            SPSServiceSVC.TransactionResult MainRes = service.ProcessPaymentMethodTransaction(identityinfo, trans, Guid.Parse(paymethodres.PaymentMethodId), payereriditinfo);

                            SPSServiceSVC.Result delres = service.DeletePaymentMethod(identityinfo, toknres.PayerId, paymethodres.PaymentMethodId);

                            if (MainRes.RequestResult.ResultCode.Equals("00"))
                            {
                                Completed = true;
                                Response.Redirect("PaymentSucced.aspx?" + Crypto.ArgumentEncrypt("Resp") + "=" + Crypto.Encrypt("approved", true), false);
                            }
                            else
                            {
                                string resultCode = "Payment Not succed becuase of ResultCode :: " + MainRes.RequestResult.ResultCode;
                                LogWritter.LogFileWrite(resultCode);
                                Response.Redirect("PaymentSucced.aspx?" + Crypto.ArgumentEncrypt("Resp") + "=" + Crypto.Encrypt("notapproved", true), false);
                            }
                        }
                        else
                        {
                            creditCardInformation.LBL6.Visible = true;
                            creditCardInformation.LBL6.Text = "Your entered Email doesn't match to registered Email.";
                            creditCardInformation.LBL6.Style.Value = "margin-left:28px;";
                        }
                    }
                    string exitFunctionLogger = "Exit :: btn4AutoRize_Click";
                    LogWritter.LogFileWrite(exitFunctionLogger);

                    Response.Cookies.Clear();
                }
                catch (Exception ex)
                {
                    string errmessage = LogWritter.CreateErrorMessage(ex);
                    LogWritter.LogFileWrite(errmessage);
                    
                    if (!Completed)
                    {
                        Response.Redirect("PaymentSucced.aspx?" + Crypto.ArgumentEncrypt("Resp") + "=" + Crypto.Encrypt("notapproved", true), false);
                    }                    
                }
            }
        }

        protected void btn5Exit_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (Regex.IsMatch(args.Value, @"\d{5}-?(\d{4})?$"))
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void btn4Cancel_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }        
    }
}