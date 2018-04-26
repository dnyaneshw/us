using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Insurance.Admin
{
    public partial class AdminCompanyAffilation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Userdata"] != null)
            {                
                if (!IsPostBack)
                {
                    AffilationBind();                   
                }
            }
            else
            {
                Response.Redirect("~/Admin/Login.aspx");
            }
        }
        private void AffilationBind()
        {
            ManageUserSVC.ManageUserClient Client = new ManageUserSVC.ManageUserClient();
            DataSet Data = new DataSet();
            Data = Client.GetCompanyAffilations();            
                ddlCompanyAffil.DataSource = Data;
                ddlCompanyAffil.DataTextField = "Description";
                ddlCompanyAffil.DataValueField = "CompAffilationID";
                ddlCompanyAffil.DataBind();
                ddlCompanyAffil.Items.Insert(0, "--Select--");            
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            lblSuccess.Text = "";
            ManageUserSVC.ManageUserClient client = new ManageUserSVC.ManageUserClient();

            if (ViewState["CompanyName"] != null)
            {
                Guid ID = Guid.Parse(ddlCompanyAffil.SelectedItem.Value);
                client.AddUpdateCompany(ID, txtCompayAff.Text);
                txtCompayAff.Text = "";
                ViewState["CompanyName"] = null;
            }
            else
            {
                string Chk = client.CheckCmpny(txtCompayAff.Text);
                if (Chk.Equals("EXIST"))
                {

                    lblSuccess.Text = "This Company is Allready Exists";
                }
                else
                {
                    string Name = txtCompayAff.Text;

                    if (Name != "")
                    {
                        Guid NewID = Guid.NewGuid();
                        client.AddUpdateCompany(NewID, Name);
                        txtCompayAff.Text = "";
                    }
                    else
                    {
                        lblSuccess.Text = "Please Enter Company Name to Add";
                    }
                }
            }
            AffilationBind();
            pnlCompantyAffil.Visible = false;
        }

        protected void lnkAdd_Click(object sender, EventArgs e)
        {
            pnlCompantyAffil.Visible = true;
            txtCompayAff.Text = "";
            this.Page.Form.DefaultButton = btnAdd.UniqueID;
        }

        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            lblSuccess.Text = "";

            if (!ddlCompanyAffil.SelectedItem.Text.Equals("--Select--"))
            {
                pnlCompantyAffil.Visible = true;
                txtCompayAff.Text = ddlCompanyAffil.SelectedItem.Text;
                ViewState["CompanyName"] = txtCompayAff.Text;
                lblSuccess.Visible = false;
            }
            else
            {
                pnlCompantyAffil.Visible = false;
                lblSuccess.Text = "Please Select Company Name to Edit";
            }
            this.Page.Form.DefaultButton = btnAdd.UniqueID;
        }

        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            if (!ddlCompanyAffil.SelectedItem.Text.Equals("--Select--"))
            {
                Guid Val = Guid.Parse(ddlCompanyAffil.SelectedItem.Value);
                ManageUserSVC.ManageUserClient Client = new ManageUserSVC.ManageUserClient();
                Client.DeleteCompanyAffilation(Val);
                AffilationBind();
                lblSuccess.Visible = false;
            }
            else
            {
                pnlCompantyAffil.Visible = false;
                lblSuccess.Text = "Please Select Company Name to Delete";
            }
        }
    }
}