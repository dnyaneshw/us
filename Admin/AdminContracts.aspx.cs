using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Insurance.Admin
{
    public partial class AdminContracts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Userdata"] != null)
            {
                lblerror.Visible = false;
            }
            else
            {
                Response.Redirect("~/Admin/Login.aspx");
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/AdminContractsList.aspx");
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            lblerror.Visible = false;

            if (txtdocument.Text == "")
            {
                lblerror.Visible = true;
                lblerror.Text = "Please Enter The Document Name";

            }
            if (this.FileUpload1.HasFile)
            {
                string path = Server.MapPath("\\Downloads\\");
                string sPathToSaveFileTo = Request.PhysicalApplicationPath + "\\Downloads\\";
                string extension = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);

                if (extension == ".pdf" || extension == ".docx" || extension == ".doc")
                {
                    FileUpload1.SaveAs(sPathToSaveFileTo + this.FileUpload1.FileName);
                }
                ManageUserSVC.ManageUserClient Userinfo = new ManageUserSVC.ManageUserClient();
                DataSet Data = new DataSet();
                ManageUserSVC.ManageUserDocumentdata User = new ManageUserSVC.ManageUserDocumentdata();

                User.DocumentName = FileUpload1.FileName;
                User.DocumentPath = path + this.FileUpload1.FileName;
                User.CreatedDate = System.DateTime.Now;
                User.MainDocument = txtdocument.Text;
                Userinfo.InsertDocumentinfo(User);
                lblerror.Visible = false;
                txtdocument.Text = "";
                Response.Redirect("AdminContractsList.aspx");
            }
        }
    }
}