using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RevNetwork
{
    public partial class error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void LbtBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.QueryString["aspxerrorpath"]);
        }
    }
}