using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Insurance.Admin.UserControl
{
    public partial class ucAdminUploadedDocument : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Userdata"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                if (!IsPostBack)
                {                    
                    DocumentBind();
                }
            }           
        }
        public void DocumentBind()
        {
            DataSet Data = new DataSet();
            ManageUserSVC.ManageUserClient Client = new ManageUserSVC.ManageUserClient();
            Data = Client.GetDocumentinfo();
            lblDocument.Text = "";
            if (Data != null && Data.Tables[0].Rows.Count > 0)
            {
                grddocumentdata.Visible = true;
                grddocumentdata.DataSource = Data;
                grddocumentdata.DataBind();
                grddocumentdata.UseAccessibleHeader = true;
                grddocumentdata.HeaderRow.TableSection = TableRowSection.TableHeader;
                TableCellCollection cells = grddocumentdata.HeaderRow.Cells;
                //cells[0].Attributes.Add("data-class", "expand");
                //cells[2].Attributes.Add("data-hide", "phone,tablet");
                //cells[3].Attributes.Add("data-hide", "phone,tablet");
                //cells[4].Attributes.Add("data-hide", "phone,tablet");                                 
            }
            else
            {
                grddocumentdata.Visible = false;
                lblDocument.Text = "No Files Found!";
            }
        }
        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            int indexid = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;
            string ID = grddocumentdata.Rows[indexid].Cells[3].Text;
            string Filename = grddocumentdata.Rows[indexid].Cells[0].Text;

            ManageUserSVC.ManageUserClient Client = new ManageUserSVC.ManageUserClient();
            Client.DeleteDocument(Convert.ToInt32(ID));

            if (File.Exists(Request.PhysicalApplicationPath + "Downloads//" + Filename))
            {
                File.Delete(Request.PhysicalApplicationPath + "Downloads//" + Filename);
            }
            DocumentBind();
        }
        protected void grddocumentdata_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grddocumentdata.PageIndex = e.NewPageIndex;
            DocumentBind();
        }

        protected void btnUploadContract_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminContracts.aspx");
        }
    }
}