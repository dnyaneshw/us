using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class ProofEvidence : System.Web.UI.Page
    {
        System.Timers.Timer tim = new System.Timers.Timer();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString[Crypto.ArgumentEncrypt("sss")] != null)
            {
                if (!IsPostBack)
                {
                    //tim.Elapsed += new ElapsedEventHandler(Timer1_Tick);
                    //tim.Interval = 8000;
                    //tim.Start();
                    ManageUserSVC.ManageUserClient Cl = new ManageUserSVC.ManageUserClient();

                    DataSet dsCus = new DataSet();
                    Guid CustID = Guid.Parse(Crypto.Decrypt(Request.QueryString[Crypto.ArgumentEncrypt("sss")].ToString(), true));
                    ViewState["ID"] = CustID;

                    dsCus = Cl.CreateEvedenceInfoByCusID(CustID);
                    if (dsCus != null && dsCus.Tables[0].Rows.Count > 0)
                    {
                        if (dsCus.Tables[0].Rows[0]["CoverDate"].ToString() != "" || dsCus.Tables[0].Rows[0]["CoverDate"].ToString() != Convert.ToDateTime("1/1/1753 12:00:00").ToString())
                        {
                            Guid EvedenceID = Guid.NewGuid();
                            lblnameaddress.Text = dsCus.Tables[0].Rows[0]["Name"].ToString() + "," +
                                                   dsCus.Tables[0].Rows[0]["Address"].ToString() + " " +
                                                   dsCus.Tables[0].Rows[0]["City"].ToString() + ", " +
                                                   dsCus.Tables[0].Rows[0]["State"].ToString() + ", " +
                                                   dsCus.Tables[0].Rows[0]["ZipCode"].ToString() + ", " +
                                                   dsCus.Tables[0].Rows[0]["Country"].ToString();

                            DateTime CoverageDate = Convert.ToDateTime(dsCus.Tables[0].Rows[0]["CoverDate"].ToString());
                            lblCoverageDate.Text = CoverageDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                            lbl12Month.Text = CoverageDate.AddMonths(12).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                            lblEvedenceNo.Text = EvedenceID.ToString().ToUpper();
                            //lblcipx.Text = "CompanyPilicyNo.(Fixed)";
                            //if (dsCus.Tables[0].Rows[0]["IsProprtyBuy"].ToString().Equals("True"))
                            //{
                            //    ChkProperty.Checked = true;
                            //}

                            ViewState["CusID"] = CustID;
                            ViewState["EvedenceID"] = EvedenceID;
                            ViewState["CoverageDate"] = CoverageDate;
                        }
                    }


                    //List<usp_GetEvedenceResult> ds = new List<usp_GetEvedenceResult>();
                    //ds = Cl.GetEvedenceInfoByCusID(CustID);
                    //if (ds != null && ds.Count > 0)
                    //{
                    //    Byte[] bytee = ds.ToList()[0].Data.Bytes;
                    //    download(bytee);
                    //}
                    //else
                    {
                        if (Request.QueryString["firsttime"] != null)
                        {
                            tblEvedence.Visible = false;
                            lblSuccess.Text = "Please Either verify your Account on Email Address or Your Account is Expired. Please Make sure that Your have done Payment.";
                        }
                    }
                }
            }
        }

        private void download(Byte[] bytes)
        {

            string sPathToSaveFileTo = Request.PhysicalApplicationPath + "dye4msvukbxdao3ernwlwixm.pdf";
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



        #region Tried for Evedence..

        void Back_DoWork(object sender, DoWorkEventArgs e)
        {
            LoadTimer();
            //tim.Elapsed += new ElapsedEventHandler(Timer1_Tick);
            //tim.Interval = 5000;
            //tim.Start();
        }

        bool Valid = false;
        public void LoadTimer()
        {
            object obj = new object();
            lock (obj)
            {
                //string WkFilePath = Request.PhysicalApplicationPath + @"WkHtml\wkhtmltopdf.exe";
                //string EXEFileName = @"C:\Program Files\wkhtmltopdf\wkhtmltopdf.exe";
                string url = System.Configuration.ConfigurationManager.AppSettings["HostingPrefix"];
                //string args = string.Format("\"{0}\" - ", url + "ProofEvidence.aspx?" + this.Page.ClientQueryString.ToString());
                string args = string.Format("\"{0}\" - ", Request.Url.AbsoluteUri);
                var startInfo = new ProcessStartInfo("wkhtmltopdf.exe", args)
                {
                    UseShellExecute = false,
                    RedirectStandardOutput = true
                };
                using (ManageUserSVC.ManageUserClient Cl = new ManageUserSVC.ManageUserClient())
                {
                    if (!Valid)
                    {
                        var proc = new Process { StartInfo = startInfo };
                        proc.Start();
                        string output = proc.StandardOutput.ReadToEnd();
                        byte[] buffer = proc.StandardOutput.CurrentEncoding.GetBytes(output);
                        proc.WaitForExit();
                        proc.Close();
                        Valid = StoreinDB(buffer, Cl);


                        if (Valid)
                        {
                            Response.ContentType = "application/pdf";
                            Response.AddHeader("content-disposition", "attachment;filename=Evedence.pdf");
                            Response.BinaryWrite(buffer);
                            Response.End();
                        }
                        else
                        {
                            tblEvedence.Visible = false;
                            //lnkDownload.Visible = false;
                            lblSuccess.Text = "Your Account get expired, Please Renew your Account.";
                        }
                    }
                }
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
                using (ManageUserSVC.ManageUserClient Cl = new ManageUserSVC.ManageUserClient())
                {
                    var proc = new Process { StartInfo = startInfo };
                    proc.Start();
                    string output = proc.StandardOutput.ReadToEnd();
                    byte[] buffer = proc.StandardOutput.CurrentEncoding.GetBytes(output);
                    proc.WaitForExit();
                    proc.Close();

                    bool Valid = StoreinDB(buffer, Cl);
                    if (Valid)
                    {
                        Response.ContentType = "application/pdf";
                        Response.AddHeader("content-disposition", "attachment;filename=Evedence.pdf");
                        Response.BinaryWrite(buffer);
                        Response.End();
                    }
                    else
                    {
                        tblEvedence.Visible = false;
                        //lnkDownload.Visible = false;
                        lblSuccess.Text = "Your Account get expired, Please Renew your Account.";
                    }
                }
            }
        }

        private bool StoreinDB(byte[] buffer, ManageUserSVC.ManageUserClient client)
        {
            bool Valid = true;
            DataSet DsCus = new DataSet();
            //DsCus = client.GetEvedenceInfoByCusID(Guid.Parse(ViewState["ID"].ToString()));
            if (DsCus != null && DsCus.Tables[0].Rows.Count > 0)
            {
                bool ActveEve = false;
                Guid EVEID = new Guid();
                foreach (DataRow item in DsCus.Tables[0].Rows)
                {
                    if (item["IsActive"].ToString().Equals("True"))
                    {
                        EVEID = Guid.Parse(item["EvedenceID"].ToString());
                        ActveEve = true;
                        break;
                    }
                }

                if (ActveEve)
                {
                    DateTime EvedenceDate = Convert.ToDateTime(DsCus.Tables[0].Rows[0]["EvideDate"].ToString());
                    if (EvedenceDate < DateTime.Now && DateTime.Now < EvedenceDate.AddMonths(12))
                    {
                        //Updated LastUpdated Date and IsActive only...
                        client.Update_Evidence(Guid.Parse(ViewState["CusID"].ToString()), DateTime.Now, true, EVEID, false);
                    }
                    else
                    {
                        //Updated IsActive field, Evedence is not valid now, need to renew account.
                        client.Update_Evidence(Guid.Parse(ViewState["CusID"].ToString()), DateTime.Now, false, EVEID, false);
                        Valid = false;
                    }
                }
                else
                {
                    // If Account get renewd, then again insert new evedence information without affecting older records.
                    client.InsertEvedence(Guid.Parse(ViewState["EvedenceID"].ToString()), Convert.ToDateTime(ViewState["CoverageDate"].ToString()),
                                         Guid.Parse(ViewState["CusID"].ToString()), DateTime.Now, true, true, buffer);
                }
            }
            else
            {
                //Inserted New Evedence.
                client.InsertEvedence(Guid.Parse(ViewState["EvedenceID"].ToString()), Convert.ToDateTime(ViewState["CoverageDate"].ToString()),
                                         Guid.Parse(ViewState["CusID"].ToString()), DateTime.Now, true, true, buffer);
            }

            return Valid;
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            tim.Stop();
            tim.Dispose();
            string script = "window.location.reload(true);";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "open", script, true);
            LoadTimer();
        }

        #endregion
    }
}