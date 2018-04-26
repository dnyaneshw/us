using Insurance.ManageUserSVC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Insurance
{
    public partial class Certificate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString[Crypto.ArgumentEncrypt("ching")] != null)
            {
                ManageUserSVC.ManageUserClient Cl = new ManageUserSVC.ManageUserClient();
                Guid CertyID = Guid.Parse(Crypto.Decrypt(Request.QueryString[Crypto.ArgumentEncrypt("ching")].ToString(), true));
                //Get info From CertyID...
                List<usp_GetCertificateByIDResult> ds = new List<usp_GetCertificateByIDResult>();
                ds = Cl.GetCertificateInfoByCertyID(CertyID);
                if (ds != null && ds.Count > 0)
                {
                    //Assign Values...
                    Guid CustomerID = ds.ToList()[0].Cust_ID;

                    DataSet dsCus = new DataSet();
                    dsCus = Cl.GetCustomerInfo(CustomerID);
                    if (dsCus != null && dsCus.Tables[0].Rows.Count > 0)
                    {
                        string InsuredDetail = dsCus.Tables[0].Rows[0]["FirstName"].ToString() + " " + dsCus.Tables[0].Rows[0]["LastName"].ToString() + "\n\r" +
                                            dsCus.Tables[0].Rows[0]["Address"].ToString() + ", " + dsCus.Tables[0].Rows[0]["City"].ToString() + ", " +
                                            dsCus.Tables[0].Rows[0]["State"].ToString() + ", " + dsCus.Tables[0].Rows[0]["ZipCode"].ToString() + ".";



                        lblDate.Text = ds.ToList()[0].CertiDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                        lblInsuredDetails.Text = InsuredDetail;
                        lblCertificateNo.Text = ds.ToList()[0].CretiNo.ToUpper();
                        lblCertyNo.Text = ds.ToList()[0].CretiNo.ToUpper();
                        lblCertyNopage2.Text = ds.ToList()[0].CretiNo.ToUpper();
                        lblEffectDate.Text = ds.ToList()[0].CertiDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);

                        if (ds.ToList()[0].AdditionalLang != "")
                        {
                            chkAddInsur.Visible = false;
                            imgAddInsur.Visible = true;
                        }
                        if (bool.Parse(ds.ToList()[0].Waiver.ToString()))
                        {
                            chkSubgrtion.Visible = false;
                            imgSubgrtion.Visible = true;
                        }

                        dsCus = new DataSet();
                        dsCus = Cl.CreateEvedenceInfoByCusID(CustomerID);
                        if (dsCus != null && dsCus.Tables[0].Rows.Count > 0)
                        {
                            DateTime CovStartDate = Convert.ToDateTime(dsCus.Tables[0].Rows[0]["CoverDate"].ToString());
                            DateTime CovEndDate = CovStartDate.AddMonths(12);
                            lblPolicyStartDate.Text = CovStartDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                            lblPolicyEndDate.Text = CovEndDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                        }

                        lblCertiHolderDetails.Text = ds.ToList()[0].HoldrName.ToString() + "\n\r " +
                                                        ds.ToList()[0].HoldrAdd.ToString();

                        lbl2nameInsured.Text = InsuredDetail;
                        lbl2nameInsured0.Text = InsuredDetail;
                        //lblAdditionalinsuredpage3.Text = InsuredDetail;
                        lblEventFrom.Text = ds.ToList()[0].EventFrom.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                        lblEventTo.Text = ds.ToList()[0].EventTo.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);

                        lblAdditionallang.Text = ds.ToList()[0].AdditionalLang;

                        if (ds.ToList()[0].Data.Bytes.Length != 0)
                        {
                            Byte[] bytee = ds.ToList()[0].Data.Bytes;
                            download(bytee);
                        }
                    }
                }
            }
        }


        private void download(Byte[] bytes)
        {

            string sPathToSaveFileTo = Request.PhysicalApplicationPath + "iwed1eamrqqgvxybdda1ed4g.pdf";
            using (System.IO.FileStream fs = new System.IO.FileStream(sPathToSaveFileTo, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite))
            {
                // use a binary writer to write the bytes to disk
                using (System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs))
                {
                    bw.Write(bytes);
                    bw.Close();
                }
            }

            string path = sPathToSaveFileTo;
            WebClient client = new WebClient();
            Byte[] buffer = client.DownloadData(path);

            if (buffer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", buffer.Length.ToString());
                Response.BinaryWrite(buffer);
            }
        }

        protected void lnkDownload_Click(object sender, EventArgs e)
        {
            object obj = new object();
            lock (obj)
            {
                string WkFilePath = Request.PhysicalApplicationPath + @"WkHtml\wkhtmltopdf.exe";
                //string EXEFileName = @"C:\Program Files\wkhtmltopdf\wkhtmltopdf.exe";
                string args = string.Format("\"{0}\" - ", Request.Url.AbsoluteUri);

                var startInfo = new ProcessStartInfo(WkFilePath, args)
                {
                    UseShellExecute = false,
                    RedirectStandardOutput = true
                };
                var proc = new Process { StartInfo = startInfo };
                proc.Start();
                string output = proc.StandardOutput.ReadToEnd();
                byte[] buffer = proc.StandardOutput.CurrentEncoding.GetBytes(output);
                proc.WaitForExit();
                proc.Close();

                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=Evedence.pdf");
                Response.BinaryWrite(buffer);
                Response.End();
            }
        }
    }
}