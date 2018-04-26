using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NativeExcel;

namespace Insurance.Admin
{
    public partial class AdminReport : System.Web.UI.Page
    {
        public DateTime dtfrom;
        public DateTime dtto;
        protected void Page_Load(object sender, EventArgs e)
        {           
            if (Session["Userdata"] != null)
            {
                this.Page.Form.DefaultButton = btnSubmit.UniqueID;
            }
            else
                Response.Redirect("~/Admin/Login.aspx");            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                string FileName = Request.PhysicalApplicationPath + "Report.xls";
                if (File.Exists(FileName))
                {
                    File.Delete(FileName);
                }
                CreateWorkbook(FileName);
                string url = System.Configuration.ConfigurationManager.AppSettings["HostingPrefix"];
                Response.Redirect(url + "Report.xls");
            }
        }

        public bool Validate()
        {
            lblError.Text = "";
            if (txtfrom.Text == "" && txtto.Text == "")
            {
                lblError.Text = "Please Select Start Date and End Date.";
                return false;
            }

            return true;
        }

        public void CreateWorkbook(string FileName)
        {
            //Create workbook
            IWorkbook book = NativeExcel.Factory.CreateWorkbook();



            //Add sheet
            IWorksheet sheet = book.Worksheets.Add();

            sheet.Name = "John Parks Insurance Report";

            sheet.PageSetup.CenterHeader = "MONTH 2014";



            //Add header
            IRange range = sheet.Range["A1:X1"];
            range.Font.Name = "Calibri";
            range.Font.Size = 12;
            range.Font.Bold = true;
            range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = XlVAlign.xlVAlignCenter;


            sheet.Cells.Font.Name = "Calibri";
            sheet.Cells.Font.Size = 12;

            sheet.Cells[1, 1].Value = "Name";
            sheet.Cells[1, 2].Value = "Address";
            sheet.Cells[1, 3].Value = "City";
            sheet.Cells[1, 4].Value = "State";
            sheet.Cells[1, 5].Value = "Zip";
            sheet.Cells[1, 6].Value = "Email";
            sheet.Cells[1, 7].Value = "Evidence Number";
            sheet.Cells[1, 8].Value = "Enrollment date";
            sheet.Cells[1, 9].Value = "Company Affiliation";
            sheet.Cells[1, 10].Value = "Company ID";
            sheet.Cells[1, 11].Value = "Payment ($)";
            sheet.Cells[1, 12].Value = "JAPCO ($)";
            sheet.Cells[1, 13].Value = "Gross Prem ($)";
            sheet.Cells[1, 14].Value = "Comm ($)";
            sheet.Cells[1, 15].Value = "Payable ($)";
            sheet.Cells[1, 16].Value = "Tax ($)";
            sheet.Cells[1, 17].Value = "Payable with Tax ($)";
            sheet.Cells[1, 18].Value = "Slush ($)";
            sheet.Cells[1, 19].Value = "Slush-Fee ($)";
            sheet.Cells[1, 20].Value = "IDS Payable ($)";
            //New Code
            sheet.Cells[1, 21].Value = "AD&D ($)";
            sheet.Cells[1, 22].Value = "ADD COMM ($)";
            sheet.Cells[1, 23].Value = "AD&D NET PAYABLE ($)";
            sheet.Cells[1, 24].Value = "NET Payable IDS ($)";

            //sheet.Cells[10, 7].Value = "COMM ($)";
            //sheet.Cells[10, 8].Value = "PAYABLE ($)";
            //sheet.Cells[10, 9].Value = "SLUSH ($)";
            //sheet.Cells[10, 10].Value = "PROPAY ($)";
            //sheet.Cells[10, 11].Value = "PROPAY ($)";

            sheet.Cells["A1:X1"].Borders.Color = System.Drawing.Color.Black;
            sheet.Cells["A1:X1"].Borders.LineStyle = XlLineStyle.xlContinuous;
            sheet.Cells["A1:X1"].Interior.Color = System.Drawing.Color.FromArgb(192, 192, 192);


            DataSet dsReportData = new DataSet();
            ManageUserSVC.ManageUserClient Client = new ManageUserSVC.ManageUserClient();

            DateTime dtFrom = DateTime.ParseExact(txtfrom.Text, "MM/dd/yyyy", System.Globalization.CultureInfo.GetCultureInfo("en-US"));
            DateTime dtTo = DateTime.ParseExact(txtto.Text, "MM/dd/yyyy", System.Globalization.CultureInfo.GetCultureInfo("en-US"));

            dsReportData = Client.GetReport_Data(dtFrom, dtTo);


            //John Parks Insurance Report

            double JOHNPARKINSURANCE = Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["JOHNPARKINSURANCE"].ToString());

            double TAX = Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["TAX"].ToString());

            double ADND = Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["ADND"].ToString());

            double ADDCOMM = Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["ADDCOMM"].ToString());

            if (dsReportData != null && dsReportData.Tables[0].Rows.Count > 0)
            {
                sheet.Cells["H2:H" + dsReportData.Tables[0].Rows.Count + 2].NumberFormat = "#,##0.00";

                for (int i = 0; i < dsReportData.Tables[0].Rows.Count; i++)
                {
                    for (int j = 1; j <= dsReportData.Tables[0].Columns.Count - 1; j++)
                    {
                        sheet.Cells[i + 2, j].Value = dsReportData.Tables[0].Rows[i][j - 1].ToString();

                        sheet.Cells[i + 2, 11].Value = Convert.ToDouble(Convert.ToString(dsReportData.Tables[0].Rows[i]["Payment"]));
                        double calc;
                        calc = Convert.ToDouble(sheet.Cells[i + 2, 11].Value) / 100;

                        sheet.Cells[i + 2, 11].Value = calc;
                        sheet.Cells[i + 2, 11].Font.Bold = true;


                        sheet.Cells[i + 2, 12].Value = JOHNPARKINSURANCE;

                        sheet.Cells[i + 2, 13].Value = "=L2-6.00";

                        sheet.Cells[i + 2, 14].Value = "=(M2)*0.12";

                        sheet.Cells[i + 2, 15].Value = "=(M2)-N2";

                        sheet.Cells[i + 2, 16].Value = TAX;

                        sheet.Cells[i + 2, 17].Value = "=O2+P2";

                        sheet.Cells[i + 2, 18].Value = "=6-P2";

                        //change 
                        sheet.Cells[i + 2, 19].Value = "=R2-2.34";

                        sheet.Cells[i + 2, 20].Value = "=K2-L2";

                        sheet.Cells[i + 2, 21].Value = ADND;

                        sheet.Cells[i + 2, 22].Value = ADDCOMM;

                        sheet.Cells[i + 2, 23].Value = "=U2-V2";

                        sheet.Cells[i + 2, 24].Value = "=T2-U2";
                    }
                }

                int row = dsReportData.Tables[0].Rows.Count + 2;
                sheet.Cells[dsReportData.Tables[0].Rows.Count + 5, 1].Value = "Total";
                sheet.Cells[dsReportData.Tables[0].Rows.Count + 5, 1].Font.Bold = true;

                sheet.Cells[dsReportData.Tables[0].Rows.Count + 5, 11].Formula = "=SUM(K2:K" + row + ")";
                sheet.Cells[dsReportData.Tables[0].Rows.Count + 5, 11].Font.Bold = true;

                sheet.Cells[dsReportData.Tables[0].Rows.Count + 5, 12].Formula = "=SUM(L2:L" + row + ")";
                sheet.Cells[dsReportData.Tables[0].Rows.Count + 5, 12].Font.Bold = true;

                sheet.Cells[dsReportData.Tables[0].Rows.Count + 5, 13].Formula = "=SUM(M2:M" + row + ")";
                sheet.Cells[dsReportData.Tables[0].Rows.Count + 5, 13].Font.Bold = true;


                sheet.Cells[dsReportData.Tables[0].Rows.Count + 5, 14].Formula = "=SUM(N2:N" + row + ")";
                double KTotal = Convert.ToDouble(sheet.Cells[dsReportData.Tables[0].Rows.Count + 5, 14].Value);
                sheet.Cells[dsReportData.Tables[0].Rows.Count + 5, 14].Font.Bold = true;
                sheet.Cells[dsReportData.Tables[0].Rows.Count + 5, 14].Borders.Color = System.Drawing.Color.Black;
                sheet.Cells[dsReportData.Tables[0].Rows.Count + 5, 14].Borders.LineStyle = XlLineStyle.xlContinuous;
                sheet.Cells[dsReportData.Tables[0].Rows.Count + 5, 14].Interior.Color = System.Drawing.Color.FromArgb(255, 128, 128);

                sheet.Cells[dsReportData.Tables[0].Rows.Count + 5, 15].Formula = "=SUM(O2:O" + row + ")";
                sheet.Cells[dsReportData.Tables[0].Rows.Count + 5, 15].Font.Bold = true;

                sheet.Cells[dsReportData.Tables[0].Rows.Count + 5, 16].Formula = "=SUM(P2:P" + row + ")";
                sheet.Cells[dsReportData.Tables[0].Rows.Count + 5, 16].Font.Bold = true;

                sheet.Cells[dsReportData.Tables[0].Rows.Count + 5, 17].Formula = "=SUM(Q2:Q" + row + ")";
                double PayTaxTotal = Convert.ToDouble(sheet.Cells[dsReportData.Tables[0].Rows.Count + 5, 17].Value);
                sheet.Cells[dsReportData.Tables[0].Rows.Count + 5, 17].Font.Bold = true;
                sheet.Cells[dsReportData.Tables[0].Rows.Count + 5, 17].Borders.Color = System.Drawing.Color.Black;
                sheet.Cells[dsReportData.Tables[0].Rows.Count + 5, 17].Borders.LineStyle = XlLineStyle.xlContinuous;
                sheet.Cells[dsReportData.Tables[0].Rows.Count + 5, 17].Interior.Color = System.Drawing.Color.FromArgb(255, 255, 0);

                sheet.Cells[dsReportData.Tables[0].Rows.Count + 5, 18].Formula = "=SUM(R2:R" + row + ")";
                sheet.Cells[dsReportData.Tables[0].Rows.Count + 5, 18].Font.Bold = true;

                sheet.Cells[dsReportData.Tables[0].Rows.Count + 5, 19].Formula = "=SUM(S2:S" + row + ")";
                sheet.Cells[dsReportData.Tables[0].Rows.Count + 5, 19].Font.Bold = true;
                sheet.Cells[dsReportData.Tables[0].Rows.Count + 5, 19].Borders.Color = System.Drawing.Color.Black;
                sheet.Cells[dsReportData.Tables[0].Rows.Count + 5, 19].Borders.LineStyle = XlLineStyle.xlContinuous;
                sheet.Cells[dsReportData.Tables[0].Rows.Count + 5, 19].Interior.Color = System.Drawing.Color.FromArgb(204, 204, 255);

                sheet.Cells[dsReportData.Tables[0].Rows.Count + 5, 20].Formula = "=SUM(T2:T" + row + ")";
                sheet.Cells[dsReportData.Tables[0].Rows.Count + 5, 20].Font.Bold = true;

                sheet.Cells[dsReportData.Tables[0].Rows.Count + 5, 21].Formula = "=SUM(U2:U" + row + ")";
                sheet.Cells[dsReportData.Tables[0].Rows.Count + 5, 21].Font.Bold = true;

                sheet.Cells[dsReportData.Tables[0].Rows.Count + 5, 22].Formula = "=SUM(V2:V" + row + ")";
                double STotal = Convert.ToDouble(sheet.Cells[dsReportData.Tables[0].Rows.Count + 5, 22].Value);
                sheet.Cells[dsReportData.Tables[0].Rows.Count + 5, 22].Font.Bold = true;
                sheet.Cells[dsReportData.Tables[0].Rows.Count + 5, 22].Borders.Color = System.Drawing.Color.Black;
                sheet.Cells[dsReportData.Tables[0].Rows.Count + 5, 22].Borders.LineStyle = XlLineStyle.xlContinuous;
                sheet.Cells[dsReportData.Tables[0].Rows.Count + 5, 22].Interior.Color = System.Drawing.Color.FromArgb(255, 128, 128);

                sheet.Cells[dsReportData.Tables[0].Rows.Count + 5, 23].Formula = "=SUM(W2:W" + row + ")";
                double ADNetPayTotal = Convert.ToDouble(sheet.Cells[dsReportData.Tables[0].Rows.Count + 5, 23].Value);
                sheet.Cells[dsReportData.Tables[0].Rows.Count + 5, 23].Font.Bold = true;
                sheet.Cells[dsReportData.Tables[0].Rows.Count + 5, 23].Borders.Color = System.Drawing.Color.Black;
                sheet.Cells[dsReportData.Tables[0].Rows.Count + 5, 23].Borders.LineStyle = XlLineStyle.xlContinuous;
                sheet.Cells[dsReportData.Tables[0].Rows.Count + 5, 23].Interior.Color = System.Drawing.Color.FromArgb(255, 255, 0);

                sheet.Cells[dsReportData.Tables[0].Rows.Count + 5, 24].Formula = "=SUM(X2:X" + row + ")";
                double NetPayIDSTotal = Convert.ToDouble(sheet.Cells[dsReportData.Tables[0].Rows.Count + 5, 24].Value);
                sheet.Cells[dsReportData.Tables[0].Rows.Count + 5, 24].Font.Bold = true;
                sheet.Cells[dsReportData.Tables[0].Rows.Count + 5, 24].Borders.Color = System.Drawing.Color.Black;
                sheet.Cells[dsReportData.Tables[0].Rows.Count + 5, 24].Borders.LineStyle = XlLineStyle.xlContinuous;
                sheet.Cells[dsReportData.Tables[0].Rows.Count + 5, 24].Interior.Color = System.Drawing.Color.FromArgb(255, 255, 0);

                sheet.Cells[dsReportData.Tables[0].Rows.Count + 9, 10].Formula = "COMM ($)";
                sheet.Cells[dsReportData.Tables[0].Rows.Count + 9, 10].Font.Bold = true;

                sheet.Cells[dsReportData.Tables[0].Rows.Count + 10, 10].Formula = KTotal + STotal;
                double CommTotal = Convert.ToDouble(sheet.Cells[dsReportData.Tables[0].Rows.Count + 10, 10].Value);
                sheet.Cells[dsReportData.Tables[0].Rows.Count + 10, 10].Font.Bold = true;
                sheet.Cells[dsReportData.Tables[0].Rows.Count + 10, 10].Borders.Color = System.Drawing.Color.Black;
                sheet.Cells[dsReportData.Tables[0].Rows.Count + 10, 10].Borders.LineStyle = XlLineStyle.xlContinuous;
                sheet.Cells[dsReportData.Tables[0].Rows.Count + 10, 10].Interior.Color = System.Drawing.Color.FromArgb(255, 128, 128);

                sheet.Cells[dsReportData.Tables[0].Rows.Count + 9, 11].Formula = "PAYABLE ($)";
                sheet.Cells[dsReportData.Tables[0].Rows.Count + 9, 11].Font.Bold = true;

                sheet.Cells[dsReportData.Tables[0].Rows.Count + 10, 11].Formula = PayTaxTotal + ADNetPayTotal + NetPayIDSTotal;
                double PayablesTotal = Convert.ToDouble(sheet.Cells[dsReportData.Tables[0].Rows.Count + 10, 11].Value);
                sheet.Cells[dsReportData.Tables[0].Rows.Count + 10, 11].Font.Bold = true;
                sheet.Cells[dsReportData.Tables[0].Rows.Count + 10, 11].Borders.Color = System.Drawing.Color.Black;
                sheet.Cells[dsReportData.Tables[0].Rows.Count + 10, 11].Borders.LineStyle = XlLineStyle.xlContinuous;
                sheet.Cells[dsReportData.Tables[0].Rows.Count + 10, 11].Interior.Color = System.Drawing.Color.FromArgb(255, 255, 0);

                sheet.Cells[dsReportData.Tables[0].Rows.Count + 9, 12].Formula = "SLUSH ($)";
                sheet.Cells[dsReportData.Tables[0].Rows.Count + 9, 12].Font.Bold = true;

                sheet.Cells[dsReportData.Tables[0].Rows.Count + 10, 12].Formula = "=SUM(S2:S" + row + ")";
                double SlushTotal = Convert.ToDouble(sheet.Cells[dsReportData.Tables[0].Rows.Count + 10, 12].Value);
                sheet.Cells[dsReportData.Tables[0].Rows.Count + 10, 12].Font.Bold = true;
                sheet.Cells[dsReportData.Tables[0].Rows.Count + 10, 12].Borders.Color = System.Drawing.Color.Black;
                sheet.Cells[dsReportData.Tables[0].Rows.Count + 10, 12].Borders.LineStyle = XlLineStyle.xlContinuous;
                sheet.Cells[dsReportData.Tables[0].Rows.Count + 10, 12].Interior.Color = System.Drawing.Color.FromArgb(204, 204, 255);

                sheet.Cells[dsReportData.Tables[0].Rows.Count + 9, 13].Formula = "PROPAY ($)";
                sheet.Cells[dsReportData.Tables[0].Rows.Count + 9, 13].Font.Bold = true;

                sheet.Cells[dsReportData.Tables[0].Rows.Count + 10, 13].Formula = "=SUM(2.34*6)";
                double PropayTotal = Convert.ToDouble(sheet.Cells[dsReportData.Tables[0].Rows.Count + 10, 13].Value);
                sheet.Cells[dsReportData.Tables[0].Rows.Count + 10, 13].Font.Bold = true;
                sheet.Cells[dsReportData.Tables[0].Rows.Count + 10, 13].Borders.Color = System.Drawing.Color.Black;
                sheet.Cells[dsReportData.Tables[0].Rows.Count + 10, 13].Borders.LineStyle = XlLineStyle.xlContinuous;
                sheet.Cells[dsReportData.Tables[0].Rows.Count + 10, 13].Interior.Color = System.Drawing.Color.FromArgb(255, 204, 0);

                sheet.Cells[dsReportData.Tables[0].Rows.Count + 9, 14].Formula = "B & W ($)";
                sheet.Cells[dsReportData.Tables[0].Rows.Count + 9, 14].Font.Bold = true;

                sheet.Cells[dsReportData.Tables[0].Rows.Count + 10, 14].Formula = PayTaxTotal + ADNetPayTotal;
                sheet.Cells[dsReportData.Tables[0].Rows.Count + 10, 14].Font.Bold = true;

                sheet.Cells[dsReportData.Tables[0].Rows.Count + 12, 13].Formula = CommTotal + PayablesTotal + SlushTotal + PropayTotal;
                sheet.Cells[dsReportData.Tables[0].Rows.Count + 12, 13].Font.Bold = true;

                sheet.Cells.Autofit();
                book.SaveAs(FileName);

                //Attain Report Sheet
                string POLICYNUMBER = "CIP116614";

                sheet = book.Worksheets.Add();
                sheet.Name = "Attain Report";
                sheet.PageSetup.CenterHeader = "APRIL 2014 BURNS & WILCOX PAYABLE";

                //Add header
                range = sheet.Range["A1:L1"];
                range.Font.Name = "Calibri";
                range.Font.Size = 12;
                range.Font.Bold = true;
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                range.VerticalAlignment = XlVAlign.xlVAlignCenter;
                sheet.Cells.Font.Name = "Calibri";
                sheet.Cells.Font.Size = 12;

                sheet.Cells[1, 1].Value = "Policy Number";
                sheet.Cells[1, 2].Value = "Name";
                sheet.Cells[1, 3].Value = "Address";
                sheet.Cells[1, 4].Value = "City";
                sheet.Cells[1, 5].Value = "State";
                sheet.Cells[1, 6].Value = "Zip";
                sheet.Cells[1, 7].Value = "Email";
                sheet.Cells[1, 8].Value = "Evidence Number";
                sheet.Cells[1, 9].Value = "Enrollment date";
                sheet.Cells[1, 10].Value = "Company Affiliation";
                sheet.Cells[1, 11].Value = "Payable with Tax ($)";
                sheet.Cells[1, 12].Value = "AD&D NET PAYABLE ($)";

                sheet.Cells["A1:L1"].Borders.Color = System.Drawing.Color.Black;
                sheet.Cells["A1:L1"].Borders.LineStyle = XlLineStyle.xlContinuous;
                sheet.Cells["A1:L1"].Interior.Color = System.Drawing.Color.FromArgb(192, 192, 192);

                for (int i = 1; i <= dsReportData.Tables[0].Rows.Count; i++)
                {
                    sheet.Cells[i + 1, 1].Value = POLICYNUMBER;

                    sheet.Cells[i + 1, 2].Value = "='John Parks Insurance Report'!A" + (i + 1);

                    sheet.Cells[i + 1, 3].Value = "='John Parks Insurance Report'!B" + (i + 1);

                    sheet.Cells[i + 1, 4].Value = "='John Parks Insurance Report'!C" + (i + 1);

                    sheet.Cells[i + 1, 5].Value = "='John Parks Insurance Report'!D" + (i + 1);

                    sheet.Cells[i + 1, 6].Value = "='John Parks Insurance Report'!E" + (i + 1);

                    sheet.Cells[i + 1, 7].Value = "='John Parks Insurance Report'!F" + (i + 1);

                    sheet.Cells[i + 1, 8].Value = "='John Parks Insurance Report'!G" + (i + 1);

                    sheet.Cells[i + 1, 9].Value = "='John Parks Insurance Report'!H" + (i + 1);

                    sheet.Cells[i + 1, 10].Value = "='John Parks Insurance Report'!I" + (i + 1);

                    sheet.Cells[i + 1, 11].Value = "='John Parks Insurance Report'!Q" + (i + 1);

                    sheet.Cells[i + 1, 12].Value = "='John Parks Insurance Report'!W" + (i + 1);
                }
            }
            int row2 = dsReportData.Tables[0].Rows.Count + 2;
            sheet.Cells[dsReportData.Tables[0].Rows.Count + 5, 1].Value = "Total";
            sheet.Cells[dsReportData.Tables[0].Rows.Count + 5, 1].Font.Bold = true;

            sheet.Cells[dsReportData.Tables[0].Rows.Count + 5, 11].Formula = "=SUM(K2:K" + row2 + ")";
            double PayWithTaxTotal = Convert.ToDouble(sheet.Cells[dsReportData.Tables[0].Rows.Count + 5, 11].Value);
            sheet.Cells[dsReportData.Tables[0].Rows.Count + 5, 11].Font.Bold = true;

            sheet.Cells[dsReportData.Tables[0].Rows.Count + 5, 12].Formula = "=SUM(L2:L" + row2 + ")";
            double ADDNetPayTotal = Convert.ToDouble(sheet.Cells[dsReportData.Tables[0].Rows.Count + 5, 12].Value);
            sheet.Cells[dsReportData.Tables[0].Rows.Count + 5, 12].Font.Bold = true;

            sheet.Cells[dsReportData.Tables[0].Rows.Count + 7, 11].Value = "Total";
            sheet.Cells[dsReportData.Tables[0].Rows.Count + 7, 11].Font.Bold = true;

            sheet.Cells[dsReportData.Tables[0].Rows.Count + 7, 12].Value = PayWithTaxTotal + ADDNetPayTotal;
            sheet.Cells[dsReportData.Tables[0].Rows.Count + 7, 12].Font.Bold = true;

            sheet.Cells.Autofit();
            book.SaveAs(FileName);


            //IDS Payble Report
            //string POLICYNUMBER = "CIP116614";

            sheet = book.Worksheets.Add();
            sheet.Name = "IDS Payable Report";
            sheet.PageSetup.CenterHeader = "MONTH 2014 IDS PAYABLE";


            //Add header
            range = sheet.Range["A1:J1"];
            range.Font.Name = "Calibri";
            range.Font.Size = 12;
            range.Font.Bold = true;
            range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = XlVAlign.xlVAlignCenter;
            sheet.Cells.Font.Name = "Calibri";
            sheet.Cells.Font.Size = 12;

            sheet.Cells[1, 1].Value = "Name";
            sheet.Cells[1, 2].Value = "Address";
            sheet.Cells[1, 3].Value = "City";
            sheet.Cells[1, 4].Value = "State";
            sheet.Cells[1, 5].Value = "Zip";
            sheet.Cells[1, 6].Value = "Email";
            sheet.Cells[1, 7].Value = "Evidence Number";
            sheet.Cells[1, 8].Value = "Enrollment date";
            sheet.Cells[1, 9].Value = "Company Affiliation";
            sheet.Cells[1, 10].Value = "NET Payable IDS ($)";

            sheet.Cells["A1:J1"].Borders.Color = System.Drawing.Color.Black;
            sheet.Cells["A1:J1"].Borders.LineStyle = XlLineStyle.xlContinuous;
            sheet.Cells["A1:J1"].Interior.Color = System.Drawing.Color.FromArgb(192, 192, 192);



            for (int i = 1; i <= dsReportData.Tables[0].Rows.Count; i++)
            {
                sheet.Cells[i + 1, 1].Value = "='John Parks Insurance Report'!A" + (i + 1);

                sheet.Cells[i + 1, 2].Value = "='John Parks Insurance Report'!B" + (i + 1);

                sheet.Cells[i + 1, 3].Value = "='John Parks Insurance Report'!C" + (i + 1);

                sheet.Cells[i + 1, 4].Value = "='John Parks Insurance Report'!D" + (i + 1);

                sheet.Cells[i + 1, 5].Value = "='John Parks Insurance Report'!E" + (i + 1);

                sheet.Cells[i + 1, 6].Value = "='John Parks Insurance Report'!F" + (i + 1);

                sheet.Cells[i + 1, 7].Value = "='John Parks Insurance Report'!G" + (i + 1);

                sheet.Cells[i + 1, 8].Value = "='John Parks Insurance Report'!H" + (i + 1);

                sheet.Cells[i + 1, 9].Value = "='John Parks Insurance Report'!I" + (i + 1);

                sheet.Cells[i + 1, 10].Value = "='John Parks Insurance Report'!X" + (i + 1);


            }

            int row1 = dsReportData.Tables[0].Rows.Count + 2;
            sheet.Cells[dsReportData.Tables[0].Rows.Count + 5, 1].Value = "Total";
            sheet.Cells[dsReportData.Tables[0].Rows.Count + 5, 1].Font.Bold = true;

            sheet.Cells[dsReportData.Tables[0].Rows.Count + 5, 10].Formula = "=SUM(J2:J" + row1 + ")";
            sheet.Cells[dsReportData.Tables[0].Rows.Count + 5, 10].Font.Bold = true;

            sheet.Cells.Autofit();
            book.SaveAs(FileName);
        }
    }
}