using Insurance.ManageUserSVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Insurance
{
    public partial class View : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = string.Empty;
            string type = string.Empty;
            Byte[] pdf = null;
            
            try
            {
                id = Crypto.Decrypt(Request.QueryString[Crypto.ArgumentEncrypt("id")].ToString(), true);

            }
            catch (Exception)
            {
                Response.Redirect("ErrorPage.aspx", true);
            }

            try
            {
                type = Crypto.Decrypt(Request.QueryString[Crypto.ArgumentEncrypt("type")].ToString(), true);


            }
            catch (Exception)
            {
                Response.Redirect("ErrorPage.aspx", true);
            }

            using (ManageUserSVC.ManageUserClient Client = new ManageUserClient())
            {

                switch (type)
                {
                    case "certy":
                        List<usp_GetCertificateByIDResult> ListCertificates = new List<usp_GetCertificateByIDResult>();
                        ListCertificates = Client.GetCertificateInfoByCertyID(Guid.Parse(id));
                        if (ListCertificates != null && ListCertificates.Count > 0)
                        {
                            pdf = ListCertificates.ToList()[0].Data.Bytes;
                        }
                        break;
                    case "eve":
                        List<usp_GetEvedenceResult> ListEvedences = new List<usp_GetEvedenceResult>();
                        ListEvedences = Client.GetEvedenceInfoByCusID(Guid.Parse(id));
                        if (ListEvedences != null && ListEvedences.Count > 0)
                        {
                            pdf = ListEvedences.ToList()[0].Data.Bytes;
                        }
                        break;


                    default:
                        Response.Redirect("ErrorPage.aspx", true);
                        break;
                }
            }

            if (pdf != null)
            {
                Response.ClearContent();
                Response.ClearHeaders();
                Response.AddHeader("cache-control", "private");
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "inline; filename=testfile.pdf");
                Response.AddHeader("content-length", Convert.ToString(pdf.Length));
                Response.AppendHeader("accept-ranges", "none");
                Response.BinaryWrite(pdf);
                Response.Flush();
                Response.End();
            }
            else
                Response.Redirect("ErrorPage.aspx", true);
        }
    }
}