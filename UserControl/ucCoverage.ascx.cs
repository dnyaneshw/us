using AjaxControlToolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Insurance.UserControl
{
    public partial class ucCoverage : System.Web.UI.UserControl
    {
        #region << Properties >>

        public CalendarExtender CoverageInformationDate
        {
            get { return txtCovrageDate_CalendarExtender; }
            set { txtCovrageDate_CalendarExtender = value; }
        }

        public Label LabelEmailValidate
        {
            get { return lblEmailValidate; }
            set { lblEmailValidate = value; }
        }
        public Label LabelPayment
        {
            get { return lblPayment; }
            set { lblPayment = value; }
        }
        public TextBox CoverageDate
        {
            get { return txtCovrageDate; }
            set { txtCovrageDate = value; }
        }
        public CheckBox FiveYearCheck
        {
            get { return chk5yrs; }
            set { chk5yrs = value; }
        }
        public CheckBox ThreeYearCheck
        {
            get { return chk3yrs; }
            set { chk3yrs = value; }
        }
        public Label LabelCoverageDate
        {
            get { return lblCoverageDate; }
            set { lblCoverageDate = value; }
        }
        public Label LBL
        {
            get { return lbl; }
            set { lbl = value; }
        }
        
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}