using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Insurance.UserControl
{
    public partial class ucProfile : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AffilationBind();
                Guid ID = Guid.Parse(Session["CustomerID"].ToString());
                DataSet dsCus = new DataSet();
                ManageUserSVC.ManageUserClient Client = new ManageUserSVC.ManageUserClient();
                dsCus = Client.GetCustomerInfo(ID);
                ViewState["CustomerData"] = dsCus;  
                if (dsCus != null && dsCus.Tables[0].Rows.Count > 0)
                {
                    txtFname.Text = dsCus.Tables[0].Rows[0]["FirstName"].ToString();
                    txtLname.Text = dsCus.Tables[0].Rows[0]["LastName"].ToString();
                    txtCompany.Text = dsCus.Tables[0].Rows[0]["Company_Name"].ToString();
                    txtEmailID.Text = dsCus.Tables[0].Rows[0]["EmailID"].ToString();
                    txtAddress.Text = dsCus.Tables[0].Rows[0]["Address"].ToString();
                    txtCity.Text = dsCus.Tables[0].Rows[0]["City"].ToString();
                    drpStates.SelectedValue = dsCus.Tables[0].Rows[0]["State"].ToString();
                    ddlCompanyAffil.SelectedValue = dsCus.Tables[0].Rows[0]["CompAffilationID"].ToString();
                    txtZipCode.Text = dsCus.Tables[0].Rows[0]["ZipCode"].ToString();
                    txtPhone.Text = dsCus.Tables[0].Rows[0]["PhoneNo"].ToString();
                    txtPersonalID.Text = dsCus.Tables[0].Rows[0]["PersonalID"].ToString();
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
                ddlCompanyAffil.DataSource = Data;
                ddlCompanyAffil.DataTextField = "Description";
                ddlCompanyAffil.DataValueField = "CompAffilationID";
                ddlCompanyAffil.DataBind();
                ddlCompanyAffil.Items.Insert(0, "--Select--");
            }
        }
        private bool IsValidate()
        {
            lblStaterror.Visible = false;
            lbl1.Visible = false;
            lblError.Visible = false;

            if (txtAddress.Text == "")
            {
                lblError.Visible = true;
                lblError.Text = "Please Enter Address";
                return false;
            }
            else if (txtCity.Text == "")
            {
                lblError.Visible = true;
                lblError.Text = "Please Enter City";
                return false;
            }
            else if (drpStates.SelectedItem.Text.Equals("--Select--"))
            {
                lblStaterror.Visible = true;
                lblStaterror.Text = "Please Select State from List.";
                return false;
            }
            else if (txtZipCode.Text == "")
            {
                lblError.Visible = true;
                lblError.Text = "Please Enter Zip Code";
                return false;
            }
            else if (!Regex.IsMatch(txtZipCode.Text, @"\d{5}-?(\d{4})?$"))
            {
                lbl1.Visible = true;
                lbl1.Text = "Please Enter Valid Zip Code..";
                return false;
            }
            else if (txtPhone.Text == "")
            {
                lblError.Visible = true;
                lblError.Text = "Please Enter Phone Number";
                return false;
            }
            else if (!Regex.IsMatch(txtPhone.Text, @"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"))
            {
                lblError.Visible = true;
                lblError.Text = "Please Enter Valid Phone Number";
                return false;
            }
            return true;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (IsValidate())
            {
                ManageUserSVC.ManageUserClient Client = new ManageUserSVC.ManageUserClient();
                ManageUserSVC.ManageUserCustomerData User = new ManageUserSVC.ManageUserCustomerData();

                DataSet dsCus = ViewState["CustomerData"] as DataSet;
                if (dsCus != null && dsCus.Tables[0].Rows.Count > 0)
                {
                    User.CompanyName = dsCus.Tables[0].Rows[0]["Company_Name"].ToString();
                    User.PersonalID = dsCus.Tables[0].Rows[0]["PersonalID"].ToString();
                    User.FirstName = dsCus.Tables[0].Rows[0]["FirstName"].ToString();
                    User.LastName = dsCus.Tables[0].Rows[0]["LastName"].ToString();
                    User.ApplicationNo = dsCus.Tables[0].Rows[0]["ApplicationNo"].ToString();
                    User.CompanyAffilID = Guid.Parse(dsCus.Tables[0].Rows[0]["CompAffilationID"].ToString());
                    User.Country = dsCus.Tables[0].Rows[0]["Country"].ToString();
                    User.EmailID = dsCus.Tables[0].Rows[0]["EmailID"].ToString();
                    User.IsActive = Convert.ToBoolean(dsCus.Tables[0].Rows[0]["IsActive"].ToString());
                    User.IsActivePolicy = Convert.ToBoolean(dsCus.Tables[0].Rows[0]["IsActivePolicy"].ToString());
                    User.SecurityCode = dsCus.Tables[0].Rows[0]["SecurityCode"].ToString();
                    User.YourID = dsCus.Tables[0].Rows[0]["YID"].ToString();
                    User.ZipCode = dsCus.Tables[0].Rows[0]["ZipCode"].ToString();
                    User.SignUpDate = Convert.ToDateTime(dsCus.Tables[0].Rows[0]["SignUp_Date"].ToString());
                    User.Payment = decimal.Parse(dsCus.Tables[0].Rows[0]["Payment"].ToString());
                    User.IsSecCodeSent = Convert.ToBoolean(dsCus.Tables[0].Rows[0]["IsSecCodeSent"].ToString());
                    User.VerifyEmail = Convert.ToBoolean(dsCus.Tables[0].Rows[0]["VerifyEmail"].ToString());
                }

                User.CustID = Guid.Parse(Session["CustomerID"].ToString());
                User.Address = txtAddress.Text;
                User.City = txtCity.Text;
                User.LastUpdated = DateTime.Now;
                User.PhoneNo = txtPhone.Text;
                User.ZipCode = txtZipCode.Text;
                User.State = drpStates.SelectedItem.Text;
                Client.InsertUser(User);
                lblError.Visible = true;
                lblError.ForeColor = System.Drawing.Color.Green;
                lblError.Text = "Your profile has been successfully changed";
            }
        }
    }
}