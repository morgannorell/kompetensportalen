using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using kompetensportalen.classes;

namespace kompetensportalen
{
    public partial class laboratorium : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            postgre conn = new postgre();

            conn.test(TextBox1.Text);

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}