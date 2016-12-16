using kompetensportalen.classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace kompetensportalen
{
    public partial class adminstart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            User login = new User();
            dt = login.GetUserList();

            foreach (DataRow row in dt.Rows)
            {
                HtmlGenericControl div = new HtmlGenericControl("div class=\"mylist\"" + 
                    " id=\"" + row["username"].ToString() + "\"" + " runat=\"server\"");
                div.InnerHtml = "<a class=\"showp\" href=\"showExam.aspx?myparam=" + row["username"].ToString() + "\">" + row["firstname"].ToString() + " " + row["lastname"].ToString() + "</a>";
                userlist.Controls.Add(div);
            }           
        }

        protected void btnShowTest_Click(object sender, EventArgs e)
        {

        }
    }
}