using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using kompetensportalen.classes;
using System.Data;

namespace kompetensportalen
{
    public partial class admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSendAdmCred_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string username = tbxAdminUsername.Text;
            string password = tbxAdminPassword.Text;

            User login = new User
            {
                Username = username,
                Password = password
            };

            dt = login.AdmLogin();

            if(dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    Session["login"] = "admin";
                    Response.Redirect("adminstart.aspx");
                }
                else
                {
                    error_login.InnerText = "Fel lösenord eller användarnamn.";
                }
            }
        }
    }
}