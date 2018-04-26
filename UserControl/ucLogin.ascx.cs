using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Insurance;
namespace Insurance.UserControl
{
    public partial class ucLogin : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.Form.DefaultButton = btnLogin.UniqueID;
            if (!IsPostBack)
            {
                if (Session["CustomerID"] != null)
                {
                    Response.Redirect("Home.aspx");
                }
                if (Request.Cookies["UserName"] != null)
                {
                    txtUsername.Text = Request.Cookies["UserName"].Value;
                }
            }
        }


        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string EmailId = txtUsername.Text.Trim();
            Session["EmailId"] = EmailId;
            string Password = txtSecuCode.Text.Trim();
            DataSet dsCustData = new DataSet();
            ManageUserSVC.ManageUserClient Client = new ManageUserSVC.ManageUserClient();
            dsCustData = Client.LoginCustomer(EmailId.Trim(), Password.Trim());

            Response.Cookies["UserName"].Value = txtUsername.Text.Trim();
            Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(30);
            
            if (dsCustData != null && dsCustData.Tables[0].Rows.Count > 0)
            {
                bool IsActivePolicy = Convert.ToBoolean(dsCustData.Tables[0].Rows[0]["IsActivePolicy"].ToString());
                decimal Pay = Convert.ToDecimal(dsCustData.Tables[0].Rows[0]["Payment"].ToString());
                Session["payment"] = Pay;
                string CusID = Crypto.Encrypt(dsCustData.Tables[0].Rows[0]["Cust_ID"].ToString(), true);
                Session["CustomerID"] = dsCustData.Tables[0].Rows[0]["Cust_ID"].ToString();
                Session["EmailID"] = dsCustData.Tables[0].Rows[0]["EmailID"].ToString();

                string firstname = Crypto.Encrypt(dsCustData.Tables[0].Rows[0]["FirstName"].ToString(), true);
                Session["Firstname"] = dsCustData.Tables[0].Rows[0]["FirstName"].ToString();
                string paswrd = Crypto.Encrypt(dsCustData.Tables[0].Rows[0]["SecurityCode"].ToString(), true);
                Session["Paswrd"] = dsCustData.Tables[0].Rows[0]["SecurityCode"].ToString();

                if (Session["GenerateCertificateFromDefaultPage"] != null)
                {
                    ManageUserSVC.ManageUserClient Cl = new ManageUserSVC.ManageUserClient();
                    Guid CustID = Guid.Parse(Session["CustomerID"].ToString());
                    DataSet dsCus = Cl.CreateEvedenceInfoByCusID(CustID);

                    DateTime CoverageDate;
                    DateTime EndDate = DateTime.Now;
                    if (dsCus != null && dsCus.Tables[0].Rows.Count > 0)
                    {
                        if (dsCus.Tables[0].Rows[0]["CoverDate"].ToString() != "")
                        {
                            CoverageDate = Convert.ToDateTime(dsCus.Tables[0].Rows[0]["CoverDate"].ToString());
                            EndDate = CoverageDate.AddMonths(12);
                            int numberOfDayRemaining = (EndDate - DateTime.Now).Days;
                            if (numberOfDayRemaining <= 0)
                            {
                                Response.Redirect("Home.aspx", true);
                            }
                        }
                    }
                    

                    if (dsCus != null && dsCus.Tables[0].Rows.Count > 0)
                    {
                        Session["GenerateCertificateFromDefaultPage"] = null;
                        Response.Redirect("FillCertiInfo.aspx");
                    }
                    else
                    {
                        Session["GenerateCertificateFromDefaultPage"] = null;
                        Session["pnl"] = "3";
                        Session["value"] = Crypto.Encrypt(Session["CustomerID"].ToString(), true);
                        Response.Redirect("Register.aspx");
                    }

                }
                else
                {
                    Response.Redirect("Home.aspx", true);
                }
            }
            else
            {
                lblError.Text = "Unfortunately we could not match the email address you entered with information in our database!";
            }
        }

        protected void lnkForgetPass_Click(object sender, EventArgs e)
        {
            Response.Redirect("ForgotPassword.aspx");
        }
    }
}