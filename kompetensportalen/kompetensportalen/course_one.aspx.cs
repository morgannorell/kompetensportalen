using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using kompetensportalen.classes;

namespace kompetensportalen
{
    public partial class course_one : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.SessionID == "admin" || Session.SessionID == "noadmin")
            {
                Response.Redirect("index.aspx");
            }
        }

        protected void btnStartExam_Click(object sender, EventArgs e)
        {
            Response.Redirect("examination.aspx");
        }

        protected void btnLastExam_Click(object sender, EventArgs e)
        {
            Response.Redirect("showExam.aspx?myparam=" + Session["username"]);
        }
    }
}