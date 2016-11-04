using kompetensportalen.classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;

namespace kompetensportalen
{
    public partial class oldexam : System.Web.UI.Page
    {
        private string username;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["myparam"] != null)
                username = Request.QueryString["myparam"];
            //answer.InnerHtml = Request.QueryString["myparam"];

            LoadTest(username);
        }

        public void LoadTest(string username)
        {
            XmlDocument doc = new XmlDocument();
            DataTable dt = new DataTable();

            Exam ex = new Exam();

            dt = ex.GetExam(username);
            string xml = "";

            foreach (DataRow col in dt.Rows)
            {
                xml = col["xml"].ToString();
            }

            doc.LoadXml(xml);
            XmlNodeList xlist = doc.SelectNodes("Prov/Kategori");

            string test = "";

            foreach (XmlNode myNode in xlist)
            {
                test = myNode["Fråga"].InnerText;
            }

            xmlq.InnerHtml = test;

            
        }
    }
}