using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Insurance.Admin.UserControl
{
    public partial class ucCustomerInformation : System.Web.UI.UserControl
    {

        public string CustomerName
        {
            get
            {
                return txtFirstName.Text + " " + txtLastName.Text;
            }
        }


        public string CustomerEmailID
        {
            get
            {
                return txtEmailID.Text;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.Form.DefaultButton = btnSave.UniqueID;
            if (Session["Userdata"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    AffilationBind();

                    if (Session["UserID"] != null)
                    {
                        Guid ID = Guid.Parse(Session["UserID"].ToString());
                        ManageUserSVC.ManageUserClient Client = new ManageUserSVC.ManageUserClient();
                        DataSet dsCus = new DataSet();
                        dsCus = Client.GetCustomerInfo(ID);
                        if (dsCus != null && dsCus.Tables[0].Rows.Count > 0)
                        {
                            txtFirstName.Text = dsCus.Tables[0].Rows[0]["FirstName"].ToString();
                            txtCompany.Text = dsCus.Tables[0].Rows[0]["Company_Name"].ToString();
                            txtLastName.Text = dsCus.Tables[0].Rows[0]["LastName"].ToString();
                            txtCustomerID.Text = dsCus.Tables[0].Rows[0]["YID"].ToString();
                            txtEmailID.Text = dsCus.Tables[0].Rows[0]["EmailID"].ToString();
                            txtAddress.Text = dsCus.Tables[0].Rows[0]["Address"].ToString();
                            txtCity.Text = dsCus.Tables[0].Rows[0]["City"].ToString();
                            drpStates.SelectedValue = dsCus.Tables[0].Rows[0]["State"].ToString();
                            txtZipCode.Text = dsCus.Tables[0].Rows[0]["ZipCode"].ToString();
                            txtCountry.Text = dsCus.Tables[0].Rows[0]["Country"].ToString();
                            txtphoneNo.Text = dsCus.Tables[0].Rows[0]["PhoneNo"].ToString();
                            drpCompnyAffil.SelectedValue = dsCus.Tables[0].Rows[0]["CompAffilationID"].ToString();
                            txtSecCode.Text = dsCus.Tables[0].Rows[0]["SecurityCode"].ToString();
                            txtApplicationNo.Text = dsCus.Tables[0].Rows[0]["ApplicationNo"].ToString();
                            chkIsActivePolicy.Checked = bool.Parse(dsCus.Tables[0].Rows[0]["IsActivePolicy"].ToString());
                            txtpersonalid.Text = dsCus.Tables[0].Rows[0]["PersonalID"].ToString();
                            chkIsActive.Checked = bool.Parse(dsCus.Tables[0].Rows[0]["IsActive"].ToString());
                            txtPayment.Text = dsCus.Tables[0].Rows[0]["Payment"].ToString();
                            txtSignup.Text = dsCus.Tables[0].Rows[0]["SignUp_Date"].ToString();
                            if (dsCus.Tables[0].Rows[0]["IsSecCodeSent"].ToString() != "")
                                chkIscedeSent.Checked = bool.Parse(dsCus.Tables[0].Rows[0]["IsSecCodeSent"].ToString());
                            if (dsCus.Tables[0].Rows[0]["VerifyEmail"].ToString() != "")
                                chkVerify.Checked = bool.Parse(dsCus.Tables[0].Rows[0]["VerifyEmail"].ToString());
                            Session["payment"] = txtPayment.Text;
                        }
                    }
                }
            }

        }


        public void AffilationBind()
        {
            ManageUserSVC.ManageUserClient Client = new ManageUserSVC.ManageUserClient();
            DataSet Data = new DataSet();
            Data = Client.GetCompanyAffilations();
            if (Data != null && Data.Tables[0].Rows.Count > 0)
            {
                drpCompnyAffil.DataSource = Data;
                drpCompnyAffil.DataTextField = "Description";
                drpCompnyAffil.DataValueField = "CompAffilationID";
                drpCompnyAffil.DataBind();
                drpCompnyAffil.Items.Insert(0, new ListItem("--Select--","Select"));
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Valid())
            {
                if (Session["UserID"] != null)
                {
                    ManageUserSVC.ManageUserClient Client = new ManageUserSVC.ManageUserClient();
                    ManageUserSVC.ManageUserCustomerData User = new ManageUserSVC.ManageUserCustomerData();

                    User.CustID = Guid.Parse(Session["UserID"].ToString());
                    User.Address = txtAddress.Text;
                    User.ApplicationNo = txtApplicationNo.Text;
                    User.City = txtCity.Text;
                    User.CompanyAffilID = Guid.Parse(drpCompnyAffil.SelectedItem.Value);
                    User.CompanyName = txtCompany.Text;
                    User.Country = txtCountry.Text;
                    User.EmailID = txtEmailID.Text;
                    User.FirstName = txtFirstName.Text;
                    User.IsActive = chkIsActive.Checked;
                    User.IsActivePolicy = chkIsActivePolicy.Checked;
                    User.LastName = txtLastName.Text;
                    User.LastUpdated = DateTime.Now;
                    User.PhoneNo = txtphoneNo.Text;
                    User.SecurityCode = txtSecCode.Text;
                    User.State = drpStates.SelectedItem.Text;
                    User.YourID = txtCustomerID.Text;
                    User.ZipCode = txtZipCode.Text;
                    User.SignUpDate = Convert.ToDateTime(txtSignup.Text);
                    User.Payment = decimal.Parse(txtPayment.Text);
                    User.IsSecCodeSent = chkIscedeSent.Checked;
                    User.VerifyEmail = chkVerify.Checked;
                    User.PersonalID = txtpersonalid.Text;
                    User.InsuraceType = "";
                    Client.InsertUser(User);
                    Response.Redirect("AdminCustomerList.aspx");
                }
            }
        }

        private bool Valid()
        {

            lblError.Text = "";
            if (txtFirstName.Text == "")
            {
                lblError.Text = "Please Enter First Name";
                return false;
            }
            else if (txtLastName.Text == "")
            {
                lblError.Text = "Please Enter Last Name.";
                return false;
            }
            else if (txtEmailID.Text == "")
            {
                lblError.Text = "Please Enter Email.";
                return false;
            }
            else if (!Regex.IsMatch(txtEmailID.Text, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"))
            {
                lblError.Text = "Please Enter Valid Email Address Format.";
                return false;
            }
            else if (txtAddress.Text == "")
            {
                lblError.Text = "Please Enter Your Address.";
                return false;
            }
            else if (txtCity.Text == "")
            {
                lblError.Text = "Please Enter City.";
                return false;
            }
            else if (drpStates.SelectedIndex == 0)
            {
                lblError.Text = "Please Enter State.";
                return false;
            }
            else if (txtZipCode.Text == "")
            {
                lblError.Text = "Please Enter Zip Code.";
                return false;
            }
            if (!Regex.IsMatch(txtZipCode.Text, @"\d{5}-?(\d{4})?$"))
            {
                lblError.Text = "Please Enter Valid Zip Code Format.";
                return false;
            }
            else if (drpCompnyAffil.SelectedItem.Text.Equals("--Select--"))
            {
                lblError.Text = "Please Select Company from List.";
                return false;
            }

            return true;
        }

        protected void btnEvidanceCertificate_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminCustomerEvidenceCertificate.aspx");
        }

    }
}