using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Insurance.UserControl
{
    public partial class ucPopUpControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            vedioframe.Src = System.Configuration.ConfigurationManager.AppSettings["PopupUrlPath"];
        }

       
    }
}