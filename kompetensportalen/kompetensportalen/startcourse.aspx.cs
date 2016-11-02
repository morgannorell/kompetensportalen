using kompetensportalen.classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace kompetensportalen
{
    public partial class startcourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string username = tbxUsername.Text;
            string password = tbxPassword.Text;

            User login = new User
            {
                Username = username,
                Password = password
            };

            dt = login.CourseLogin();

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    Session["login"] = "noadmin";
                    Session["username"] = username;
                    Response.Redirect("course_one.aspx");
                }
                else
                {
                    error_login.InnerText = "Fel lösenord eller användarnamn.";
                }
            }
        }
    }
}