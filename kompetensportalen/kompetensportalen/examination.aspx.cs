using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using kompetensportalen.classes;
using System.Web.UI.HtmlControls;

namespace kompetensportalen
{
    public partial class examination : System.Web.UI.Page
    {

        Postgre conn = new Postgre();
        Exam examina = new Exam();
        List<string> allAnswers = new List<string>();
        List<ListItem> answers;
        List<int> questionIDs = new List<int>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                questionIDs = examina.GetQuestionIDs();
                Session["test"] = questionIDs;           
            }
          
            int randomQuestion = RandomQuestionFromDB();
            Session["RandomQuestion"] = examina.GetQuestionFromDB(randomQuestion);
            question.InnerText = examina.GetQuestionFromDB(randomQuestion);
            allAnswers = examina.GetAnswersFromDB(randomQuestion);
            answers = new List<ListItem> { answer1, answer2, answer3, answer4 };

            if (randomQuestion > 0)
            for (int i = 0; i < 4; i++)
            {
                ListItem answerPos = RandomAnswerPosition();
                answerPos.Text = allAnswers[i];
            }

            
        }

        //public void test()
        //{
        //    Exam testar = new Exam();

        //    string path = Server.MapPath("/xml/prov.xml");
        //    XmlDocument doc = new XmlDocument();
        //    doc.Load(path);

        //    XmlNode hmm = doc.SelectSingleNode("/Prov/Kategori/Fråga[@ ID='p1']");

        //    string stringVariable = hmm.ToString();

        //    question.InnerText = hmm.FirstChild.InnerText;
        //}       
        
        public ListItem RandomAnswerPosition()
        {            
            Random random = new Random();
            int index = random.Next(answers.Count);
            ListItem answer = answers[index];
            answers.RemoveAt(index);
            return answer;
        }
        
        public int RandomQuestionFromDB()
        {
            var list = (List<int>)Session["test"];
            int id = 0;
            if (list.Count > 0)
            {
                Random random = new Random();
                int index = random.Next(list.Count);
                id = list[index];
                list.RemoveAt(index);
                
            }
            return id;
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(Server.MapPath("xml/prov.xml"));

            XmlNode nodeOne = doc.SelectSingleNode("//Prov");

            XmlDocument docTwo = new XmlDocument();
            docTwo.LoadXml("<Fråga>" + (string)Session["RandomQuestion"] + "<Svar>"+allAnswers[0]+"</Svar></Fråga>");

            XmlNode nodeTwo = doc.ImportNode(docTwo.FirstChild, true);
            nodeOne.AppendChild(nodeTwo);

            //XmlElement newElem = doc.CreateElement("Fråga");
            //newElem.InnerText = (string)Session["RandomQuestion"];
            //doc.DocumentElement.AppendChild(newElem);

            //XmlWriterSettings settings = new XmlWriterSettings();
            //settings.Indent = true;

            //XmlWriter writer = XmlWriter.Create(Server.MapPath("xml/prov.xml"), settings);
            doc.Save(Server.MapPath("xml/prov.xml"));
        }
    }
}