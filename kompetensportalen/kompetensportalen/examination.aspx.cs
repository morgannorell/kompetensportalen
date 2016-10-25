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
    public partial class examination : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            test();
        }

        public void test()
        {
            Exam testar = new Exam();

            string path = Server.MapPath("/xml/prov.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            XmlNode hmm = doc.SelectSingleNode("/Prov/Kategori/Fråga[@ ID='p1']");

            string stringVariable = hmm.ToString();

            question.InnerText = hmm.InnerText;
        }
    }
}