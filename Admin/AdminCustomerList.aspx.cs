using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Insurance.Admin
{
    public partial class AdminCustomerList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.Form.DefaultButton = btnSearch.UniqueID;
            if (Session["Userdata"] != null)
            {
                if (!IsPostBack)
                {
                    txtSearch.Enabled = false;
                    btnSearch.Enabled = false;
                    lblsrcerror.Text = "";
                    if (ddlSearchBy.SelectedItem.Text.Equals("All Users"))
                        CustomerBind();
                }
            }
            else
            {
                Response.Redirect("~/Admin/Login.aspx");
            }
            
        }
        private void CustomerBind()
        {
            DataSet Data = new DataSet();
            ManageUserSVC.ManageUserClient Client = new ManageUserSVC.ManageUserClient();
            Data = Client.GetAllCustomers();

            //MKP Solved existing issue when grid have one customer than it deleted it is not automaic refresh the grid
            //if (Data != null && Data.Tables[0].Rows.Count > 0)
            {
                grdCustomers.DataSource = Data;
                grdCustomers.DataBind();
                grdCustomers.UseAccessibleHeader = true;
                grdCustomers.HeaderRow.TableSection = TableRowSection.TableHeader;
                TableCellCollection cells = grdCustomers.HeaderRow.Cells;
                cells[0].Attributes.Add("data-class", "expand");
                //cells[2].Attributes.Add("data-hide", "phone,tablet");
                cells[3].Attributes.Add("data-hide", "phone,tablet");
                cells[4].Attributes.Add("data-hide", "phone,tablet");
                //cells[5].Attributes.Add("data-hide", "phone,tablet");
                //cells[6].Attributes.Add("data-hide", "phone,tablet");
            }
        }

        protected void grdCustomers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdCustomers.PageIndex = e.NewPageIndex;
            CustomerBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ManageUserSVC.ManageUserClient Client = new ManageUserSVC.ManageUserClient();
            DataSet Data = new DataSet();
            lblsrcerror.Text = "";
            lblgrd.Text = "";
            if (txtSerchDate.Visible == false)
            {
                if (txtSearch.Text != "")
                {
                    if (ddlSearchBy.SelectedItem.Text.Equals("All Users"))
                        CustomerBind();

                    if (ddlSearchBy.SelectedItem.Text.Equals("Application Number"))
                    {
                        Data = Client.SearchCustomers(txtSearch.Text, "", "", "", null);
                    }

                    if (ddlSearchBy.SelectedItem.Text.Equals("Name"))
                    {
                        Data = Client.SearchCustomers("", txtSearch.Text, "", "", null);
                    }

                    if (ddlSearchBy.SelectedItem.Text.Equals("Email-ID"))
                    {
                        Data = Client.SearchCustomers("", "", txtSearch.Text, "", null);
                    }

                    if (ddlSearchBy.SelectedItem.Text.Equals("User ID"))
                    {
                        Data = Client.SearchCustomers("", "", "", txtSearch.Text, null);
                    }


                    if (Data != null && Data.Tables.Count > 0 && Data.Tables[0].Rows.Count > 0)
                    {
                        grdCustomers.Visible = true;
                        grdCustomers.DataSource = Data;
                        grdCustomers.DataBind();
                    }
                    else
                    {
                        grdCustomers.Visible = false;
                        lblgrd.Text = "No Data Found";
                    }
                }
                else
                {
                    lblsrcerror.Text = "Please Enter Search Text.";
                }
            }
            else
            {
                if (ddlSearchBy.SelectedItem.Text.Equals("Coverage Start Date"))
                {
                    if (txtSerchDate.Text != "")
                    {
                        DateTime strDate = DateTime.ParseExact(
                              txtSerchDate.Text,
                               "mm-dd-yyyy",
                               System.Globalization.CultureInfo.InvariantCulture);
                        Data = Client.SearchCustomers("", "", "", "", strDate);


                        if (Data != null && Data.Tables.Count > 0 && Data.Tables[0].Rows.Count > 0)
                        {
                            grdCustomers.Visible = true;
                            grdCustomers.DataSource = Data;
                            grdCustomers.DataBind();
                        }
                        else
                        {
                            grdCustomers.Visible = false;
                            lblgrd.Text = "No Data Found";
                        }
                    }
                    else
                    {
                        lblsrcerror.Text = "Please Select Date.";
                    }
                }
            }
        }

        protected void ddlSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSearchBy.SelectedIndex == 0)
            {
                lblgrd.Text = "";
                txtSearch.Enabled = false;
                btnSearch.Enabled = false;
                grdCustomers.Visible = true;
                CustomerBind();
            }
            else
            {
                btnSearch.Enabled = true;
                txtSearch.Enabled = true;
            }

            if (ddlSearchBy.SelectedItem.Text.Equals("Coverage Start Date"))
            {
                txtSearch.Visible = false;
                txtSerchDate.Visible = true;
            }
            else
            {
                txtSearch.Visible = true;
                txtSerchDate.Visible = false;
            }
        }

        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            int indexid = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;
            string ID = grdCustomers.Rows[indexid].Cells[4].Text;
            Session["UserID"] = ID;
            Response.Redirect("~/Admin/AdminCustomerInformation.aspx");
        }
        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            int indexid = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;
            string ID = grdCustomers.Rows[indexid].Cells[4].Text;

            ManageUserSVC.ManageUserClient Client = new ManageUserSVC.ManageUserClient();
            Client.DeleteCustomer(Guid.Parse(ID));
            CustomerBind();
        }
    }
}