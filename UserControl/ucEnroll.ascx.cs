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
    public partial class ucEnroll : System.Web.UI.UserControl
    {

        #region << Properties >>



        public LinkButton linkLogin
        {
            get { return lnkLogin; }
            set { lnkLogin = value; }
        }

        public Label LavelGoToLogin
        {
            get { return lblGoToLogin; }
            set { lblGoToLogin = value; }
        }


        public Label LavelAgreeError
        {
            get { return lblAgreeError; }
            set { lblAgreeError = value; }
        }
        

             public Label LabelError
        {
            get { return lblError; }
            set { lblError = value; }
        }

        public TextBox FirstName
        {
            get { return txtFirstName; }
            set { txtFirstName = value; }
        }
        public TextBox LastName
        {
            get { return txtLastName; }
            set { txtLastName = value; }
        }

        public TextBox CompanyName
        {
            get { return txtCompany; }
            set { txtCompany = value; }
        }

        public TextBox EmailID
        {
            get { return txtEmailID; }
            set { txtEmailID = value; }
        }

        public TextBox ConfirmEmailID
        {
            get { return txtConfirmEmailID; }
            set { txtConfirmEmailID = value; }
        }

        public TextBox Address
        {
            get { return txtAddress; }
            set { txtAddress = value; }
        }

        public TextBox PhoneNo
        {
            get { return txtphoneNo; }
            set { txtphoneNo = value; }
        }

        public TextBox City
        {
            get { return txtCity; }
            set { txtCity = value; }
        }
        public DropDownList States
        {
            get { return drpStates; }
            set { drpStates = value; }
        }
        public TextBox ZipCode
        {
            get { return txtZipCode; }
            set { txtZipCode = value; }
        }
        public DropDownList CompnyAffilation
        {
            get { return drpCompnyAffil; }
            set { drpCompnyAffil = value; }
        }

        public TextBox UserID
        {
            get { return txtuserid; }
            set { txtuserid = value; }
        }
        public CheckBox Agree
        {
            get { return chkAgree; }
            set { chkAgree = value; }
        }
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {            
        }

        public bool IsValidate()
        {
            lblError.Visible = false;
            Lblcmpny.Visible = false;
            lbl1.Visible = false;
            lblState.Visible = false;
            if (txtFirstName.Text == "")
            {
                lblError.Visible = true;
                lblError.Text = "Please Enter First Name....";

                return false;
            }
            else if (txtLastName.Text == "")
            {
                lblError.Visible = true;
                lblError.Text = "Please Enter Last Name.";
                return false;
            }

            else if (txtuserid.Text == "")
            {
                lblError.Visible = true;
                lblError.Text = "Please Enter Userid.";
                return false;
            }

            else if (txtEmailID.Text == "")
            {
                lblError.Visible = true;
                lblError.Text = "Please Enter Email.";
                return false;
            }

            else if (txtAddress.Text == "")
            {
                lblError.Visible = true;
                lblError.Text = "Please Enter Your Address.";
                return false;
            }
            else if (txtphoneNo.Text == "")
            {
                lblError.Visible = true;
                lblError.Text = "Please Enter Your Contact No.";
                return false;
            }

            else if (txtCity.Text == "")
            {
                lblError.Visible = true;
                lblError.Text = "Please Enter City.";
                return false;
            }
            else if (drpStates.SelectedItem.Text.Equals("--Select--"))
            {
                lblState.Visible = true;
                lblState.Text = "Please Select State from List.";
                return false;
            }

            if (txtZipCode.Text == "")
            {
                lblError.Visible = true;
                lblError.Text = "Please Enter Zip Code.";
                return false;
            }
            if (!Regex.IsMatch(txtZipCode.Text, @"\d{5}-?(\d{4})?$"))
            {
                lbl1.Visible = true;
                RequiredFieldValidator25.Style.Value = "display:none;";
                lbl1.Text = "Enter Valid Zip Code Format.";
                return false;
            }
            else if (drpCompnyAffil.SelectedItem.Text.Equals("--Select--"))
            {
                Lblcmpny.Visible = true;
                Lblcmpny.Text = "Select Company from List.";
                return false;
            }

            return true;
        }
    }
}