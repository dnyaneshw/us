using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Insurance.UserControl
{
    public partial class ucEnrollDescription : System.Web.UI.UserControl
    {
        public Label LabelRenew
        {
            get { return lblRenew; }
            set { lblRenew = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}