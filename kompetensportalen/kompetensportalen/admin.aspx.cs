using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using kompetensportalen.classes;

namespace kompetensportalen
{
    public partial class admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSendAdmCred_Click(object sender, EventArgs e)
        {
            string username = tbxAdminUsername.Text;
            string password = tbxAdminPassword.Text;

            Person admlogin = new Person
            {
                Username = username,
                Password = password
            };

            admlogin.Login();          
        }
    }
}