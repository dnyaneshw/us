using Insurance.ManageUserSVC;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Insurance
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (Session["CustomerID"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            Session["value"] = Crypto.Encrypt(Session["CustomerID"].ToString(), true);
            Session["pnl"] = "3";
            ManageUserSVC.ManageUserClient Cl = new ManageUserSVC.ManageUserClient();
            Guid CustID = Guid.Parse(Session["CustomerID"].ToString());
            if (!IsPostBack)
            {
                DataSet dsCus = new DataSet();
               

                //Guid CusID = Guid.Parse(Crypto.Decrypt(Request.QueryString["GeneKey"].ToString(), true));
                Guid CusID = Guid.Parse(Session["CustomerID"].ToString());
                ManageUserSVC.ManageUserClient Userinfo = new ManageUserSVC.ManageUserClient();
                DataSet Data = new DataSet();
                Data = Userinfo.GetCustomerInfo(CusID);


                ViewState["CustomerID"] = CustID;
                dsCus = new DataSet();
                dsCus = Cl.CreateEvedenceInfoByCusID(CustID);

                if (dsCus != null && dsCus.Tables[0].Rows.Count > 0)
                {
                    DateTime CoverageDate;
                    DateTime EndDate = DateTime.Now;

                    if (dsCus.Tables[0].Rows[0]["CoverDate"].ToString() != "")
                    {
                        CoverageDate = Convert.ToDateTime(dsCus.Tables[0].Rows[0]["CoverDate"].ToString());
                        EndDate = CoverageDate.AddMonths(12);
                        Session["TEMPCoverageEndDate"] = EndDate;
                        if (DateTime.Now < EndDate)
                        {
                            if (Session["tryRenewAccount"] != null)
                            {
                                lblRemain.Text = (EndDate - DateTime.Now).Days.ToString();
                                Renewnote.Visible = true;
                                Session["tryRenewAccount"] = null;
                                Main.Visible = false;
                                return;
                            }
                            Main.Visible = true;
                            int numberOfDayRemaining = (EndDate - DateTime.Now).Days;
                            if(numberOfDayRemaining <= 30 )
                            {
                                string thirtyDayPrior = string.Format("Your Account is about to Expire in {0} days ", numberOfDayRemaining);
                                lblMessageOneMonthAdvance.Text = thirtyDayPrior;
                                pnlRenewBeforeOneMonth.Visible = true;
                            }
                            
                            imgCerty.Visible = true;
                            imgCerty.Style.Value = "padding-top:15px";
                            Label1.Visible = true;
                            Imageevedence.Visible = false;
                            Label2.Visible = false;                            
                        }
                        else
                        {                           
                            Label2.Visible = false;
                            lblWarn.Text = "Your Account is Expired. Thanks for using our service. You need to Renew your Account.";
                            lblWarn.Visible = true;
                            Main.Visible = false;
                            Renewspan.Visible = true;

                            List<usp_GetEvedenceResult> ListEvedences = new List<usp_GetEvedenceResult>();
                            ListEvedences = Cl.GetEvedenceInfoByCusID(CustID);
                            if (ListEvedences != null && ListEvedences.Count > 0)
                            {
                                foreach (usp_GetEvedenceResult item in ListEvedences)
                                {
                                    if (item.IsActive.Value)
                                    {
                                        Cl.Update_Evidence(CustID, DateTime.Now, false, item.EvidenceID, true);
                                        Cl.Update_Payment(CustID, 1, false);
                                    }
                                }
                            }
                        }
                    }
                    else if (Data.Tables[0].Rows[0]["Payment"].ToString() == "0.0000")
                    {
                        //Covarage set first time
                        Imageevedence.Visible = true;
                        Label2.Visible = true;
                        imgCerty.Visible = false;
                        Label1.Visible = false;
                    }
                }
                else                
                    {
                        //Covarage set first time
                        Imageevedence.Visible = true;
                        Label2.Visible = true;
                        imgCerty.Visible = false;
                        Label1.Visible = false;
                    }
                

                
            }
            BindCertificates(CustID, Cl);
            BindEvedences(CustID, Cl);
        }

        public void BindEvedences(Guid CustID, ManageUserClient Cl)
        {
            List<usp_GetEvedenceResult> ListEvedences = new List<usp_GetEvedenceResult>();
            ListEvedences = Cl.GetEvedenceInfoByCusID(CustID);

            if (ListEvedences != null && ListEvedences.Count > 0)
            {
                DataSet ds = ConvertToTable.GenericToDataTable.ToDataTable(ListEvedences);
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    DataColumn col = new DataColumn("Active");
                    if (!ds.Tables[0].Columns.Contains("Active"))
                        ds.Tables[0].Columns.Add(col);


                    string isactive = item.ItemArray[4].ToString();
                    if (isactive == "True")
                    {
                        item["Active"] = "Yes";
                        ds.AcceptChanges();
                    }
                    else
                    {
                        item["Active"] = "No";
                        ds.AcceptChanges();
                    }
                }

                grdEvedence.DataSource = ds;
                grdEvedence.DataBind();
                grdEvedence.UseAccessibleHeader = true;
                grdEvedence.HeaderRow.TableSection = TableRowSection.TableHeader;
                TableCellCollection cells = grdEvedence.HeaderRow.Cells;
                cells[0].Attributes.Add("data-class", "expand");
                cells[2].Attributes.Add("data-hide", "phone,tablet");
                //cells[3].Attributes.Add("data-hide", "phone,tablet");
                //cells[4].Attributes.Add("data-hide", "phone,tablet");
                //cells[5].Attributes.Add("data-hide", "phone,tablet");   
                lblEve.Visible = false;

            }
            else
            {
                lblEve.Visible = true;
                lblEve.Text = "No Evidence";
            }
        }

        public void BindCertificates(Guid CustID, ManageUserSVC.ManageUserClient Cl)
        {
            List<usp_GetCertificatesByCustomerIDResult> ListCertificates = new List<usp_GetCertificatesByCustomerIDResult>();
            ListCertificates = Cl.GetCertificateInfoByCustomerID(CustID);            
            if (ListCertificates != null && ListCertificates.Count > 0)
            {
                grdCertificate.DataSource = ListCertificates;
                grdCertificate.DataBind();
                grdCertificate.UseAccessibleHeader = true;
                grdCertificate.HeaderRow.TableSection = TableRowSection.TableHeader;
                TableCellCollection cells = grdCertificate.HeaderRow.Cells;
                cells[0].Attributes.Add("data-class", "expand");
                //cells[2].Attributes.Add("data-hide", "phone,tablet");
                cells[3].Attributes.Add("data-hide", "phone,tablet");
                //cells[4].Attributes.Add("data-hide", "phone,tablet");
                //cells[5].Attributes.Add("data-hide", "phone,tablet");   
                lblCerty.Visible = false;
            }
            else
            {                
                lblCerty.Visible = true;
                lblCerty.Text = "No Certificates";
            }
        }

        string url = System.Configuration.ConfigurationManager.AppSettings["HostingPrefix"];

        protected void Imageevedence_Click(object sender, EventArgs e)
        {
            Imageevedence.Visible = false;
            Session["value"] = Crypto.Encrypt(Session["CustomerID"].ToString(), true);
            Session["pnl"] = "3";            
            Response.Redirect("Register.aspx");
        }

        protected void lnkView_Click(object sender, EventArgs e)
        {
            int indexid = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;
            string ID = grdCertificate.Rows[indexid].Cells[3].Text;
            string script = "window.open('" + url + "View.aspx?" + Crypto.ArgumentEncrypt("id") + "=" + Crypto.Encrypt(ID, true) + "&" + Crypto.ArgumentEncrypt("type") + "=" + Crypto.Encrypt("certy", true) + "', 'dscoverageview', 'fullscreen=yes,location=center,resizable=yes');";

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "open", script, true);
        }

        protected void lnkDownload_Click(object sender, EventArgs e)
        {
            int indexid = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;
            string ID1 = grdCertificate.Rows[indexid].Cells[3].Text;           
            using (ManageUserSVC.ManageUserClient Client = new ManageUserClient())
            {
                List<usp_GetCertificateByIDResult> ListCertificates = new List<usp_GetCertificateByIDResult>();
                ListCertificates = Client.GetCertificateInfoByCertyID(Guid.Parse(ID1));

                if (ListCertificates != null && ListCertificates.Count > 0)
                {
                    Byte[] bytee = ListCertificates.ToList()[0].Data.Bytes;

                    if (bytee != null)
                    {
                        Response.Clear();
                        MemoryStream ms = new MemoryStream(bytee);
                        Response.ContentType = "application/pdf";
                        Response.AppendHeader("Content-Disposition", "attachment; filename=Certificate_" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + ListCertificates.ToList()[0].CretiNo.ToString() + ".pdf");
                        Response.AppendHeader("Expires", "Sun, 17 Dec 1989 07:30:00 GMT");
                        Response.Buffer = true;
                        ms.WriteTo(Response.OutputStream);
                        Response.End();
                    }
                }
            }
        }

        protected void lnkEView_Click(object sender, EventArgs e)
        {
            int indexid = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;
            string ID = grdEvedence.Rows[indexid].Cells[0].Text;
            string script = "window.open('" + url + "View.aspx?" + Crypto.ArgumentEncrypt("id") + "=" + Crypto.Encrypt(Session["CustomerID"].ToString(), true) + "&" + Crypto.ArgumentEncrypt("type") + "=" + Crypto.Encrypt("eve", true) + "', 'MyScript', 'fullscreen=yes,location=center,resizable=yes');";
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "open", script, true);
        }

        protected void lnkEDownload_Click(object sender, EventArgs e)
        {
            int indexid = ((GridViewRow)((LinkButton)sender).Parent.Parent).RowIndex;
            string ID = grdEvedence.Rows[indexid].Cells[0].Text;
            using (ManageUserSVC.ManageUserClient Client = new ManageUserClient())
            {
                List<usp_GetEvedenceDataByEVEIDResult> ListEvedences = new List<usp_GetEvedenceDataByEVEIDResult>();
                ListEvedences = Client.GetEvedenceInfoByEvedenceID(Guid.Parse(ID));

                if (ListEvedences != null && ListEvedences.Count > 0)
                {
                    Byte[] bytee = ListEvedences.ToList()[0].Data.Bytes;

                    if (bytee != null)
                    {
                        Response.Clear();
                        MemoryStream ms = new MemoryStream(bytee);
                        Response.ContentType = "application/pdf";
                        Response.AppendHeader("Content-Disposition", "attachment; filename=Evidence_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf");
                        Response.AppendHeader("Expires", "Sun, 17 Dec 1989 07:30:00 GMT");
                        Response.Buffer = true;
                        ms.WriteTo(Response.OutputStream);
                        Response.End();
                    }
                }
            }
        }

        protected void grdCertificate_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdCertificate.PageIndex = e.NewPageIndex;
            ManageUserClient Client = new ManageUserClient();
            BindCertificates(Guid.Parse(ViewState["CustomerID"].ToString()), Client);
        }

        protected void grdEvedence_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdEvedence.PageIndex = e.NewPageIndex;
            ManageUserClient Client = new ManageUserClient();
            BindEvedences(Guid.Parse(ViewState["CustomerID"].ToString()), Client);
        }

        protected void lnkRenew_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx?" + Crypto.ArgumentEncrypt("time") + "=" + Crypto.Encrypt("renew", true));
        }
        protected void lnkRenewBeforeOneMonth_Click(object sender, EventArgs e)
        {

            Session["RenewBeforeOneMonthCoverageEndDate"] = Session["TEMPCoverageEndDate"];
            Response.Redirect("Register.aspx?" + Crypto.ArgumentEncrypt("time") + "=" + Crypto.Encrypt("renew", true));
        }
               
        
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            Session["tryRenewAccount"] = null;
            Response.Redirect("Home.aspx");
        }
    }
}