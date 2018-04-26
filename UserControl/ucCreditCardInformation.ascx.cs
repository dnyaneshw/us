using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Insurance.UserControl
{
    public partial class ucCreditCardInformation : System.Web.UI.UserControl
    {
        public Label LBL6
        {
            get { return lbl6; }
            set { lbl6 = value; }
        }

        public Label LabelAmount
        {
            get { return lblAmount; }
            set { lblAmount = value; }
        }

        public DropDownList CardType
        {
            get { return ddlCardType; }
            set { ddlCardType = value; }
        }

        public TextBox CardNumber
        {
            get { return txtCardNo; }
            set { txtCardNo = value; }
        }

        public TextBox CardHolderFirstName
        {
            get { return txtCardFirstName; }
            set { txtCardFirstName = value; }
        }
        public TextBox CardHolderLastName
        {
            get { return txtCardLastName; }
            set { txtCardLastName = value; }
        }
        public DropDownList Month
        {
            get { return ddlMonth; }
            set { ddlMonth = value; }
        }
        public DropDownList Year
        {
            get { return ddlYear; }
            set { ddlYear = value; }
        }
        public TextBox City
        {
            get { return txtPCity; }
            set { txtPCity = value; }
        }
        public TextBox Zip
        {
            get { return txtPZip; }
            set { txtPZip = value; }
        }
        public TextBox EmailID
        {
            get { return txtPEmail; }
            set { txtPEmail = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        public bool Is4Valid()
        {
            lblError1.Visible = false;
            lbl2.Visible = false;
            lbl3.Visible = false;
            lbl4.Visible = false;
            lbl5.Visible = false;
            lbl6.Visible = false;
            if (ddlCardType.SelectedItem.Text.Equals("--Select--"))
            {
                lbl4.Visible = true;
                lbl4.Text = "Select Card Type from List.";
                return false;
            }
            if (txtCardNo.Text == "")
            {
                lblError1.Text = "Please enter Card Number";
                return false;
            }
            else
            {
                if (ddlCardType.SelectedItem.Text == "MasterCard")
                {
                    if (txtCardNo.Text.Length != 16)
                    {
                        lblcheck.Text = "Please enter 16 digit number";
                        return false;
                    }

                }
                else if (ddlCardType.SelectedItem.Text == "Visa")
                {
                    if (txtCardNo.Text.Length != 16)
                    {
                        lblcheck.Text = "Please enter 16 digit number";
                        return false;
                    }

                }
                else if (ddlCardType.SelectedItem.Text == "American Express")
                {
                    if (txtCardNo.Text.Length != 15)
                    {
                        lblcheck.Text = "Please enter 15 digit number";
                        return false;
                    }

                }
                else if (ddlCardType.SelectedItem.Text == "Diners Club/Carte Blanche")
                {
                    if (txtCardNo.Text.Length != 14)
                    {
                        lblcheck.Text = "Please enter 14 digit number";
                        return false;
                    }

                }
                else if (ddlCardType.SelectedItem.Text == "Second Visa")
                {
                    if (txtCardNo.Text.Length != 13)
                    {
                        lblcheck.Text = "Please enter 13 digit number";
                        return false;
                    }
                }
                else if (ddlCardType.SelectedItem.Text == "Discover")
                {
                    if (txtCardNo.Text.Length != 16)
                    {
                        lblcheck.Text = "Please enter 16 digit number";
                        return false;
                    }
                }
                else if (ddlCardType.SelectedItem.Text == "JCB")
                {
                    if (txtCardNo.Text.Length != 16)
                    {
                        lblcheck.Text = "Please enter 16 digit number";
                        return false;
                    }
                }

            }
            if (txtCardFirstName.Text == "" || txtCardLastName.Text == "")
            {
                lbl3.Visible = true;
                lbl3.Text = "Please Enter Name On Card.";
                return false;
            }
            else if (ddlMonth.SelectedItem.Text.Equals("Month") || ddlYear.SelectedItem.Text.Equals("Year"))
            {
                lbl5.Visible = true;
                lbl5.Text = "Please Select Month and Year from List.";
                return false;
            }
            if (txtPZip.Text.Length > 5)
            {
                lbl2.Visible = true;
                RequiredFieldValidator19.Style.Value = "display:none;";
                lbl2.Text = "Please Enter Valid Zip Code Format.";
                return false;
            }
            return true;
        }



    }
}