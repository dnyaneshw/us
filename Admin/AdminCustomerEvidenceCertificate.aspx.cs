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
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Insurance.Admin
{
    public partial class AdminCustomerEvidenceCertificate : System.Web.UI.Page
    {
        DataSet dsCus = new DataSet();
        string url = System.Configuration.ConfigurationManager.AppSettings["HostingPrefix"];
        char c = '"';


        public string CustomerName
        {
            get
            {
                string fullName = string.Empty;
                if (ViewState["CustomerInformamtion"]!=null)
                {
                    DataSet dsCustomerInformamtion = new DataSet();
                    dsCustomerInformamtion = (DataSet)ViewState["CustomerInformamtion"];
                    string firstName = dsCustomerInformamtion.Tables[0].Rows[0]["FirstName"] != null ? dsCustomerInformamtion.Tables[0].Rows[0]["FirstName"].ToString() : string.Empty;
                    string lastName = dsCustomerInformamtion.Tables[0].Rows[0]["LastName"] != null ? dsCustomerInformamtion.Tables[0].Rows[0]["LastName"].ToString() : string.Empty;
                    fullName =  firstName +" " + lastName;
                }
                return fullName;
            }
        }
        
        public string CustomerEmailID
        {
            get
            {
                string customerEmailId = string.Empty;
                if (ViewState["CustomerInformamtion"] != null)
                {
                    DataSet dsCustomerInformamtion = new DataSet();
                    dsCustomerInformamtion = (DataSet)ViewState["CustomerInformamtion"];
                    customerEmailId = dsCustomerInformamtion.Tables[0].Rows[0]["EmailID"] != null ? dsCustomerInformamtion.Tables[0].Rows[0]["EmailID"].ToString() : string.Empty;
                }
                return customerEmailId;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Userdata"] == null)
            {
                Response.Redirect("~/Admin/Login.aspx");
            }
            else
            {
                ManageUserSVC.ManageUserClient Client = new ManageUserSVC.ManageUserClient();
                if (Session["UserID"] != null)
                {                    
                    Guid ID = Guid.Parse(Session["UserID"].ToString());
                    ViewState["CustomerID"] = ID;
                    BindCertificates(ID, Client);
                    BindEvedences(Guid.Parse(ID.ToString()), Client);
                }
                if (!IsPostBack)
                {                    
                    if (Session["UserID"] != null)
                    {
                        Guid ID = Guid.Parse(Session["UserID"].ToString());
                        dsCus = Client.GetCustomerInfo(ID);
                        ViewState["CustomerInformamtion"] = dsCus;                        
                    }
                }
            }
        }

        public void BindEvedences(Guid CustID, ManageUserClient Cl)
        {
            List<usp_GetEvedenceResult> ListEvedences = new List<usp_GetEvedenceResult>();
            ListEvedences = Cl.GetEvedenceInfoByCusID(CustID);

            if (ListEvedences != null && ListEvedences.Count > 0)
            {
                DataSet ds = ConvertToTable.GenericToDataTable.ToDataTable(ListEvedences);
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    DataColumn col = new DataColumn("Active");
                    if (!ds.Tables[0].Columns.Contains("Active"))
                    {
                        ds.Tables[0].Columns.Add(col);
                    }

                    string isactive = item.ItemArray[4].ToString();
                    if (isactive == "True")
                    {
                        item["Active"] = "Yes";
                        ds.AcceptChanges();
                    }
                    else
                    {
                        item["Active"] = "No";
                        ds.AcceptChanges();
                    }
                }
                grdEvedence.DataSource = ds;
                grdEvedence.DataBind();
                grdEvedence.UseAccessibleHeader = true;
                grdEvedence.HeaderRow.TableSection = TableRowSection.TableHeader;
                TableCellCollection cells = grdEvedence.HeaderRow.Cells;
                cells[0].Attributes.Add("data-class", "expand");
                cells[2].Attributes.Add("data-hide", "phone,tablet");
                cells[3].Attributes.Add("data-hide", "phone,tablet");
                //cells[4].Attributes.Add("data-hide", "phone,tablet");
                //cells[5].Attributes.Add("data-hide", "phone,tablet");
                //cells[6].Attributes.Add("data-hide", "phone,tablet");
                lblEve.Visible = false;
            }

            else
            {
                lblEve.Visible = true;
                lblEve.Text = "No Evidences are Generated.";
            }
        }

        public void BindCertificates(Guid CustID, ManageUserSVC.ManageUserClient Cl)
        {
            List<usp_GetCertificatesByCustomerIDResult> ListCertificates = new List<usp_GetCertificatesByCustomerIDResult>();
            ListCertificates = Cl.GetCertificateInfoByCustomerID(CustID);

            if (ListCertificates != null && ListCertificates.Count > 0)
            {
                grdCertificate.DataSource = ListCertificates;
                grdCertificate.DataBind();
                grdCertificate.UseAccessibleHeader = true;
                grdCertificate.HeaderRow.TableSection = TableRowSection.TableHeader;
                TableCellCollection cells = grdCertificate.HeaderRow.Cells;
                cells[0].Attributes.Add("data-class", "expand");
                cells[2].Attributes.Add("data-hide", "phone,tablet");
                cells[3].Attributes.Add("data-hide", "phone,tablet");
                //cells[4].Attributes.Add("data-hide", "phone,tablet");
                //cells[5].Attributes.Add("data-hide", "phone,tablet");
                //cells[6].Attributes.Add("data-hide", "phone,tablet"); 

            }
            else
            {

                lblCerty.Visible = true;
                lblCerty.Text = "No Certificates are Generated.";
            }
        }

        protected void grdCertificate_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            lblCerty.Visible = false;
            lblEve.Visible = false;
            grdCertificate.PageIndex = e.NewPageIndex;
            ManageUserSVC.ManageUserClient Client = new ManageUserSVC.ManageUserClient();
            BindCertificates(Guid.Parse(ViewState["CustomerID"].ToString()), Client);
        }

        protected void grdEvedence_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            lblCerty.Visible = false;
            lblEve.Visible = false;
            grdEvedence.PageIndex = e.NewPageIndex;
            ManageUserSVC.ManageUserClient Client = new ManageUserSVC.ManageUserClient();
            BindEvedences(Guid.Parse(ViewState["CustomerID"].ToString()), Client);
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            lblCerty.Visible = false;
            lblEve.Visible = false;
            Response.Redirect("Edit.aspx");
        }

        protected void lnkSend_Click(object sender, EventArgs e)
        {
            lblCerty.Visible = false;
            lblEve.Visible = false;
            int indexid = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;
            string ID = grdCertificate.Rows[indexid].Cells[0].Text;

            String Encrypted = Crypto.Encrypt(ID.ToString(), true);

            string url = System.Configuration.ConfigurationManager.AppSettings["HostingPrefix"];
            StringBuilder strMailBody = new StringBuilder();
            //header
            strMailBody.Append("<p>&nbsp;</p>");
            strMailBody.Append("<div style=" + c + "margin-left: auto;height:500px;margin-right: auto;position: absolute;text-align: center;top: 0;width: 100%;z-index: 999;" + c + ">");
            strMailBody.Append("<div style=" + c + "background: url('" + url + "images/image.png') repeat-x scroll 0 0 transparent;height: 75px; width:798px;  position: relative;top: 0;z-index: 999;" + c + ">" + "<br/>");

            //body
            strMailBody.Append("<p>&nbsp;</p><table style='font-family: Tahoma;' border='0' cellpadding='0' cellspacing='0' width='600'><tbody><tr><td><table style='font-family: Tahoma;' border='0' cellpadding='0' cellspacing='0' width='600'>");
            strMailBody.Append("<tbody><tr style='font-family: Tahoma; font-size: 15px; color: rgb(33, 33, 33); text-align: left; ' valign='top'><td style='padding:35px 20px;font-family: Tahoma;'>");

            strMailBody.Append(CustomerName + "," + "<br/><br/>");

            strMailBody.Append("Your Certificate of Insurance has been generated.<br /><br />");
            strMailBody.Append("To view your Certificate of Insurance please click <a href='" + url + "~/ViewDoc.ashx?" + Crypto.ArgumentEncrypt("ching") + "=" + Encrypted + "&" + Crypto.ArgumentEncrypt("type") + "=" + Crypto.Encrypt("certy", true) + "' target='_blank'>here</a><br /><br />");
            strMailBody.Append("If you are having trouble with the above link please copy and paste the following link into your browser:<br /><br />");
            strMailBody.Append(url + "ViewDoc.ashx?" + Crypto.ArgumentEncrypt("ching") + "=" + Encrypted + "&" + Crypto.ArgumentEncrypt("type") + "=" + Crypto.Encrypt("certy", true) + " <br/><br/>");
            strMailBody.Append("Sincerely,<br/>");
            strMailBody.Append("dscoverage.com<br/>");

            strMailBody.Append("</tr></tbody></table>");
            //footer

            strMailBody.Append("<div style=" + c + "background: url('" + url + "images/footer-b.jpg') no-repeat scroll 0 0 transparent;color: #939393;font-size: 10px;height: 60px;line-height: 44px;overflow: hidden;padding: 0 20px;width: 760px;margin-top: 5px;" + c + ">" + "<p style='float: left;color: white;'>Copyright © " + DateTime.Now.Year.ToString() + " <a href='https://dscoverage.com' target='_blank' style='color:white;font-weight: bolder;'>dscoverage.com</a>, Inc. All Rights Reserved.</p></div>");
            string Subject = ConfigurationManager.AppSettings["AdminCertificateOnRequest"].ToString();

            bool Sent = CommonFunction.SendEmail(CustomerEmailID, strMailBody.ToString(), Subject);
            if (Sent)
            {
                lblCerty.Visible = true;
                lblCerty.Text = "Certificate is Sent Successfully !";
            }
        }

        protected void lnkDownload_Click(object sender, EventArgs e)
        {
            lblCerty.Visible = false;
            lblEve.Visible = false;
            int indexid = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;
            string ID = grdCertificate.Rows[indexid].Cells[0].Text;

            using (ManageUserSVC.ManageUserClient Client = new ManageUserClient())
            {
                List<usp_GetCertificateByIDResult> ListCertificates = new List<usp_GetCertificateByIDResult>();
                ListCertificates = Client.GetCertificateInfoByCertyID(Guid.Parse(ID));

                if (ListCertificates != null && ListCertificates.Count > 0)
                {
                    Byte[] bytee = ListCertificates.ToList()[0].Data.Bytes;

                    if (bytee != null)
                    {
                        Response.Clear();
                        MemoryStream ms = new MemoryStream(bytee);
                        Response.ContentType = "application/pdf";
                        Response.AppendHeader("Content-Disposition", "attachment; filename=Certificate_" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + ListCertificates.ToList()[0].CretiNo.ToString() + ".pdf");
                        Response.Buffer = true;
                        ms.WriteTo(Response.OutputStream);
                        Response.End();
                    }
                }
            }
        }

        protected void lnkView_Click(object sender, EventArgs e)
        {
            lblCerty.Visible = false;
            lblEve.Visible = false;
            int indexid = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;
            string ID = grdCertificate.Rows[indexid].Cells[0].Text;

            string script = "window.open('" + url + "View.aspx?" + Crypto.ArgumentEncrypt("id") + "=" + Crypto.Encrypt(ID, true) + "&" + Crypto.ArgumentEncrypt("type") + "=" + Crypto.Encrypt("certy", true) + "', 'MyScript', 'fullscreen=yes,location=center,resizable=yes');";

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "open", script, true);
        }

        protected void lnkEView_Click(object sender, EventArgs e)
        {
            lblCerty.Visible = false;
            lblEve.Visible = false;
            int indexid = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;
            string ID = grdEvedence.Rows[indexid].Cells[0].Text;

            string script = "window.open('" + url + "View.aspx?" + Crypto.ArgumentEncrypt("id") + "=" + Crypto.Encrypt(Session["UserID"].ToString(), true) + "&" + Crypto.ArgumentEncrypt("type") + "=" + Crypto.Encrypt("eve", true) + "', 'MyScript', 'fullscreen=yes,location=center,resizable=yes');";

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "open", script, true);
        }

        protected void lnkEDownload_Click(object sender, EventArgs e)
        {
            lblCerty.Visible = false;
            lblEve.Visible = false;

            int indexid = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;
            string ID = grdEvedence.Rows[indexid].Cells[0].Text;

            using (ManageUserSVC.ManageUserClient Client = new ManageUserClient())
            {
                List<usp_GetEvedenceDataByEVEIDResult> ListEvedences = new List<usp_GetEvedenceDataByEVEIDResult>();
                ListEvedences = Client.GetEvedenceInfoByEvedenceID(Guid.Parse(ID));

                if (ListEvedences != null && ListEvedences.Count > 0)
                {
                    Byte[] bytee = ListEvedences.ToList()[0].Data.Bytes;

                    if (bytee != null)
                    {
                        Response.Clear();
                        MemoryStream ms = new MemoryStream(bytee);
                        Response.ContentType = "application/pdf";
                        Response.AppendHeader("Content-Disposition", "attachment; filename=Evidence_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf");
                        Response.Buffer = true;
                        ms.WriteTo(Response.OutputStream);
                        Response.End();
                    }
                }
            }
        }

        protected void lnkESend_Click(object sender, EventArgs e)
        {
            lblCerty.Visible = false;
            lblEve.Visible = false;
            int indexid = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;
            string ID = grdEvedence.Rows[indexid].Cells[0].Text;

            String Encrypted = Crypto.Encrypt(Session["UserID"].ToString(), true);

            string url = System.Configuration.ConfigurationManager.AppSettings["HostingPrefix"];
            StringBuilder strMailBody = new StringBuilder();

            strMailBody = new StringBuilder();

            //header
            strMailBody.Append("<p>&nbsp;</p>");
            strMailBody.Append("<div style=" + c + "margin-left: auto;height:500px;margin-right: auto;position: absolute;text-align: center;top: 0;width: 100%;z-index: 999;" + c + ">");
            strMailBody.Append("<div style=" + c + "background: url('" + url + "images/image.png') repeat-x scroll 0 0 transparent;height: 75px; width:798px;  position: relative;top: 0;z-index: 999;" + c + ">" + "<br/>");



            //body
            strMailBody.Append("<p>&nbsp;</p><table style='font-family: Tahoma;' border='0' cellpadding='0' cellspacing='0' width='600'><tbody><tr><td><table style='font-family: Tahoma;' border='0' cellpadding='0' cellspacing='0' width='600'>");
            strMailBody.Append("<tbody><tr style='font-family: Tahoma; font-size: 14px; color: rgb(33, 33, 33); text-align: left; ' valign='top'><td style='padding:10px 35px;font-family: Tahoma;'>");

            strMailBody.Append(CustomerName + "," + "<br /><br />");
            strMailBody.Append("Your Evidence of Coverage has been generated.<br /><br />");
            //strMailBody.Append("<b>" + "To view your Evidence of Coverage please click <a href='" + url + "dye4msvukbxdao3ernwlwixm.pdf?sss=" + Crypto.Encrypt(ViewState["CustomerID"].ToString(), true) + "&firsttime=true' target='_blank'>here</a><br/><br/>");
            strMailBody.Append("To view your Evidence of Coverage please click <a href='" + url + "ViewDoc.ashx?" + Crypto.ArgumentEncrypt("ching") + "=" + Crypto.Encrypt(ViewState["CustomerID"].ToString(), true) + "&" + Crypto.ArgumentEncrypt("type") + "=" + Crypto.Encrypt("eve", true) + "' target='_blank'>here</a><br/><br/>");
            strMailBody.Append("If you are having trouble with the above link please copy and paste the following link into your browser:<br/><br/>");
            strMailBody.Append(url + "ViewDoc.ashx?" + Crypto.ArgumentEncrypt("ching") + "=" + Encrypted + "&" + Crypto.ArgumentEncrypt("type") + "=" + Crypto.Encrypt("eve", true) + "<br/><br/>");
            strMailBody.Append("Sincerely,<br/>");
            strMailBody.Append("dscoverage.com<br/>");
            strMailBody.Append("</tr></tbody></table>");
            //footer

            strMailBody.Append("<div style=" + c + "background: url('" + url + "images/footer-b.jpg') no-repeat scroll 0 0 transparent;color: #939393;font-size: 10px;height: 60px;line-height: 44px;overflow: hidden;padding: 0 20px;width: 760px;margin-top: 5px;" + c + ">" + "<p style='float: left;color: white;'>Copyright © " + DateTime.Now.Year.ToString() + " <a href='https://dscoverage.com' target='_blank' style='color:white;font-weight: bolder;'>dscoverage.com</a>, Inc. All Rights Reserved.</p></div>");
            //char c = '"';
            //string LogoPath = c + url + "Admin/Images/Capture.PNG" + c;
            //string alt = c + "Logo" + c;
            //strMailBody.Append(@"<img src=" + LogoPath + " alt=" + alt + " />");

            string Subject = ConfigurationManager.AppSettings["AdminProofOfEvedence"].ToString();

            bool Sent = CommonFunction.SendEmail(CustomerEmailID, strMailBody.ToString(), Subject);
            if (Sent)
            {
                lblEve.Visible = true;
                lblEve.Text = "Proof Of Evidence is Sent Successfully !";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            lblCerty.Visible = false;
            lblEve.Visible = false;
            Guid CustID = Guid.Parse(Session["UserID"].ToString());
            ManageUserSVC.ManageUserClient Cl = new ManageUserSVC.ManageUserClient();
            DataSet dsCus = new DataSet();
            dsCus = Cl.GetCustomerInfo(CustID);
            bool isactive = false;
            decimal payment = 0;
            string email = "";


            if (dsCus != null && dsCus.Tables[0].Rows.Count > 0)
            {
                payment = Convert.ToDecimal(dsCus.Tables[0].Rows[0]["Payment"].ToString());
                email = dsCus.Tables[0].Rows[0]["EmailID"].ToString();
                string emailvarify = Convert.ToString(dsCus.Tables[0].Rows[0]["VerifyEmail"].ToString());
                isactive = Convert.ToBoolean(dsCus.Tables[0].Rows[0]["IsActivePolicy"].ToString());

                ManageUserSVC.ManageUserCustomerData User = new ManageUserSVC.ManageUserCustomerData();
                if (emailvarify != "")
                {
                    if (isactive == true)
                    {
                        DataSet dsCus2 = new DataSet();
                        dsCus2 = Cl.GetCoveragebyCustomerId(CustID);
                        ManageUserSVC.ManageUserCoverageData Coverage = new ManageUserSVC.ManageUserCoverageData();
                        if (dsCus2 != null && dsCus2.Tables[0].Rows.Count > 0)
                        {
                            DateTime Coverdate = Convert.ToDateTime(dsCus2.Tables[0].Rows[0]["CoverDate"].ToString());
                            string fiveyrs = Convert.ToString(dsCus2.Tables[0].Rows[0]["_5YrClaim"].ToString());
                            string threeyrs = Convert.ToString(dsCus2.Tables[0].Rows[0]["_3YrLoss"].ToString());
                            string custid = Convert.ToString(dsCus2.Tables[0].Rows[0]["Cust_ID"].ToString());
                            string insurance = Convert.ToString(dsCus2.Tables[0].Rows[0]["InsuranceType"].ToString());


                            DataSet CovData = new DataSet();
                            CovData = Cl.CreateEvedenceInfoByCusID(CustID);
                            if (CovData != null && CovData.Tables[0].Rows.Count > 0)
                            {
                                Coverage.CoverageID = Guid.Parse(CovData.Tables[0].Rows[0]["CoverID"].ToString());
                            }
                            else
                            {
                                Coverage.CoverageID = Guid.NewGuid();
                            }
                            Coverage.CoverageDate = Coverdate;
                            Coverage.CustID = Guid.Parse(dsCus2.Tables[0].Rows[0]["Cust_ID"].ToString());
                            Session["CustomerIDForAdmin"] = CustID;
                            Coverage.yr3Loss = Convert.ToBoolean(threeyrs);
                            Coverage.yr5Loss = Convert.ToBoolean(fiveyrs);
                            Coverage.Status = "True";
                            Session["CoverageInfo"] = Coverage;
                        }
                        if (Session["CoverageInfo"] != null)
                        {
                            if (payment == 0)
                            {
                                if (email != "")
                                {
                                    string Memres = CheckMember(email);
                                    if (Memres == "Y")
                                        User.Payment = Convert.ToDecimal(System.Configuration.ConfigurationManager.AppSettings["Membership"]);
                                    else
                                        User.Payment = Convert.ToDecimal(System.Configuration.ConfigurationManager.AppSettings["Non-Membership"]);
                                }

                                decimal pay = User.Payment * 100;
                                bool property = false;
                                Cl.Update_Payment(CustID, pay, property);
                            }

                            if (Chkmail.Checked == true)
                            {

                                ManageUserSVC.ManageUserCoverageData Coverage2 = (ManageUserSVC.ManageUserCoverageData)Session["CoverageInfo"];
                                Cl.InsertCoverageData(Coverage2);
                                string Local = System.Configuration.ConfigurationManager.AppSettings["HostingPrefix"];
                                dowload(Local.Replace("https://", "http://") + "ProofEvidence.aspx?" + Crypto.ArgumentEncrypt("sss") + "=" + Crypto.Encrypt(CustID.ToString(), true), Coverage2);
                                SendEmailForProofOfEvidnce(Cl, CustID, Local);
                                BindEvedences(CustID, Cl);
                                lblEve.Visible = true;
                                lblEve.Text = "Evidence Regenerated Successfully";
                            }
                            else
                            {
                                ManageUserSVC.ManageUserCoverageData Coverage2 = (ManageUserSVC.ManageUserCoverageData)Session["CoverageInfo"];
                                Cl.InsertCoverageData(Coverage2);
                                string Local = System.Configuration.ConfigurationManager.AppSettings["HostingPrefix"];
                                dowload(Local.Replace("https://", "http://") + "ProofEvidence.aspx?" + Crypto.ArgumentEncrypt("sss") + "=" + Crypto.Encrypt(CustID.ToString(), true), Coverage2);
                                BindEvedences(CustID, Cl);
                                lblEve.Visible = true;
                                lblEve.Text = "Evidence Regenerated Successfully";
                            }
                        }
                        else
                        {
                            lblEve.Visible = true;
                            lblEve.Text = "Coverage Data is not present!";
                        }
                    }
                    else
                    {
                        BindEvedences(CustID, Cl);
                        lblEve.Visible = true;
                        lblEve.Text = "Policy is not active,Please activate the policy!";                        
                    }

                }
                else
                {
                    lblEve.Visible = true;
                    lblEve.Text = "Email Address is not verified!";
                }
            }
        }

        private void SendEmailForProofOfEvidnce(ManageUserSVC.ManageUserClient Client, Guid CustID, string Local)
        {
            lblCerty.Visible = false;
            lblEve.Visible = false;
            DataSet dsCus = new DataSet();
            dsCus = Client.GetCustomerInfo(CustID);

            StringBuilder strMailBody = new StringBuilder();

            string url = System.Configuration.ConfigurationManager.AppSettings["HostingPrefix"];
            //header
            strMailBody.Append("<p>&nbsp;</p>");
            strMailBody.Append("<div style=" + c + "margin-left: auto;height:500px;margin-right: auto;position: absolute;text-align: center;top: 0;width: 100%;z-index: 999;" + c + ">");
            strMailBody.Append("<div style=" + c + "background: url('" + url + "images/image.png') repeat-x scroll 0 0 transparent;height: 75px; width:798px;  position: relative;top: 0;z-index: 999;" + c + ">" + "<br/>");

            strMailBody.Append("<p>&nbsp;</p><table style='font-family: Tahoma;' border='0' cellpadding='0' cellspacing='0' width='600'><tbody><tr><td><table style='font-family: Tahoma;' border='0' cellpadding='0' cellspacing='0' width='600'>");
            strMailBody.Append("<tbody><tr style='font-family: Tahoma; font-size: 15px; color: rgb(33, 33, 33); text-align: left; ' valign='top'><td style='padding:35px 20px;font-family: Tahoma;'>");
            strMailBody.Append("<br/>" + dsCus.Tables[0].Rows[0]["FirstName"].ToString() + " " + dsCus.Tables[0].Rows[0]["LastName"].ToString() + "," + "<br /><br />");
            strMailBody.Append("Your Evidence of Coverage has been generated.<br /><br />");
            strMailBody.Append("To view your Evidence of Coverage please click <a href='" + url + "ViewDoc.ashx?" + Crypto.ArgumentEncrypt("ching") + "=" + Crypto.Encrypt(CustID.ToString(), true) + "&" + Crypto.ArgumentEncrypt("type") + "=" + Crypto.Encrypt("eve", true) + "' target='dscoverageview'>here</a><br/><br/>");
            strMailBody.Append("Sincerely,<br/>");
            strMailBody.Append("dscoverage.com<br/>");
            strMailBody.Append("</tr></tbody></table>");
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
                    if (item.IsActive==true)
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
            DsCus = client.GetEvedenceInfoByCusID(Guid.Parse(Session["CustomerIDForAdmin"].ToString()));

            if (DsCus != null && DsCus.Count > 0)
            {
                foreach (usp_GetEvedenceResult item in DsCus)
                {
                    if (item.IsActive.Value)
                    {
                        client.Update_Evidence(Guid.Parse(Session["CustomerIDForAdmin"].ToString()), DateTime.Now, false, item.EvidenceID, true);
                    }
                }
            }

            if (DsCus != null && DsCus.Count > 0)
            {

                //client.Delete_Evidence(Guid.Parse(Session["CustomerIDForAdmin"].ToString()));

                //Insert Newely generated Evedence after renew...
                client.InsertEvedence(Guid.NewGuid(), DateTime.Now,
                                     Guid.Parse(Session["CustomerIDForAdmin"].ToString()), DateTime.Now, true, true, buffer);
            }
            else
            {
                //Inserted New Evedence.
                client.InsertEvedence(Guid.NewGuid(), DateTime.Now,
                                         Guid.Parse(Session["CustomerIDForAdmin"].ToString()), DateTime.Now, true, true, buffer);
            }

            return Valid;
        }

        private string CheckMember(string EmailID)
        {
            WebClient client = new WebClient();

            Stream data = client.OpenRead(ConfigurationManager.AppSettings["memberurl"].ToString() + EmailID);
            //Stream data = client.OpenRead("http://www.independentdirectsellers.org/z28-verify-user.php?email=" + EmailID);
            StreamReader reader = new StreamReader(data);
            string read = reader.ReadToEnd();
            data.Close();
            reader.Close();
            return read;
        }
    }
}