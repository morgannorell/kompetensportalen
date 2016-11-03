using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using kompetensportalen.classes;

namespace kompetensportalen
{
    public partial class examDone : System.Web.UI.Page
    {
        XmlDocument doc = new XmlDocument();
        Correct corr = new Correct();
        Exam xam = new Exam();

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["username"] = "niso";
            XmlDocument doc = corr.DbToXml((string)Session["username"]);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string path = Server.MapPath("xml/done.xml");

            XmlTextReader reader = new XmlTextReader(path);
            XmlNode node = doc.ReadNode(reader);
            List<string> questions = new List<string>();

            foreach (XmlNode childNode in node.ChildNodes)
            {
                int id = Convert.ToInt32(childNode.Attributes["id"].Value);
                string question = xam.GetQuestionFromDB(id);

                if (question == childNode.Value)
                {
                    Label1.Text = "Test";
                }
            }
        }
    }
}