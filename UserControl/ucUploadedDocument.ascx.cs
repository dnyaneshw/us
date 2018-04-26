using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Insurance.UserControl
{
    public partial class ucUploadedDocument : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DocumentBind();
        }

        private void DocumentBind()
        {
            DataSet Data = new DataSet();
            ManageUserSVC.ManageUserClient Client = new ManageUserSVC.ManageUserClient();
            Data = Client.GetDocumentinfo();

            if (Data != null && Data.Tables[0].Rows.Count > 0)
            {
                grddocument.DataSource = Data;
                grddocument.DataBind();
                grddocument.UseAccessibleHeader = true;
                grddocument.HeaderRow.TableSection = TableRowSection.TableHeader;
                TableCellCollection cells = grddocument.HeaderRow.Cells;
                cells[0].Attributes.Add("data-class", "expand");
                cells[2].Attributes.Add("data-hide", "phone,tablet");
                cells[3].Attributes.Add("data-hide", "phone,tablet");
                cells[4].Attributes.Add("data-hide", "phone,tablet");
                cells[5].Attributes.Add("data-hide", "phone,tablet");
                //cells[6].Attributes.Add("data-hide", "phone,tablet");
                //cells[7].Attributes.Add("data-hide", "phone,tablet");                
            }
        }

        protected void grddocument_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grddocument.PageIndex = e.NewPageIndex;
        }

        protected void lnkView_Click(object sender, EventArgs e)
        {

            int fileindex = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;
            string path = grddocument.Rows[fileindex].Cells[0].Text;
            string url = System.Configuration.ConfigurationManager.AppSettings["HostingPrefix"];
            WebClient client = new WebClient();
            Byte[] buffer = client.DownloadData(url + "Downloads/" + path);

            if (buffer != null)
            {

                Response.ContentType = "application/pdf";

                Response.AddHeader("content-length", buffer.Length.ToString());
                Response.BinaryWrite(buffer);
            }            
        }



        protected void lnkdownload_Click(object sender, EventArgs e)
        {
            int fileindex = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;
            string path = grddocument.Rows[fileindex].Cells[0].Text;
            string url = System.Configuration.ConfigurationManager.AppSettings["HostingPrefix"];
            WebClient client = new WebClient();
            Byte[] buffer = client.DownloadData(url + "Downloads/" + path);

            if (buffer != null)
            {
                string name = System.IO.Path.GetFileName(path);
                string extension = System.IO.Path.GetExtension(path);
                if (extension == ".docx" || extension == ".doc")
                {
                    Response.ContentType = "application/msword;name=name";
                }
                else
                {
                    Response.ContentType = "Application/pdf";
                }
                Response.AddHeader("Content-Disposition", "attachment; filename=" + name);
                Response.AddHeader("content-length", buffer.Length.ToString());
                Response.BinaryWrite(buffer);
            }
        }
    }
}