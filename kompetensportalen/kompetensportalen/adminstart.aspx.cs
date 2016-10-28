using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace kompetensportalen
{
    public partial class adminstart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            myDiv.InnerHtml = "From code behind. Din session är: " + Session["login"] + " " + Session.SessionID;
        }
    }
}