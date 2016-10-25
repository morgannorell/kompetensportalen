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

        Postgre conn = new Postgre();
        Exam examina = new Exam();
        List<string> tryout = new List<string>();
        List<ListItem> answers;
        List<int> questionIDs = new List<int>();

        protected void Page_Load(object sender, EventArgs e)
        {
            questionIDs = examina.GetQuestionIDs();
            int lala = RandomQuestionFromDB();
            question.InnerText = examina.GetQuestionFromDB(lala);
            tryout = examina.GetAnswersFromDB(lala);
            answers = new List<ListItem> { answer1, answer2, answer3, answer4 };
            

        for (int i = 0; i < 4; i++)
            {
                ListItem test = RandomAnswerPosition();
                test.Text = tryout[i];
            }
        }

        public void test()
        {
            Exam testar = new Exam();

            string path = Server.MapPath("/xml/prov.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            XmlNode hmm = doc.SelectSingleNode("/Prov/Kategori/Fråga[@ ID='p1']");

            string stringVariable = hmm.ToString();

            question.InnerText = hmm.FirstChild.InnerText;
        }       
        
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
            Random random = new Random();
            int index = random.Next(questionIDs.Count);
            int id = questionIDs[index];
            questionIDs.RemoveAt(index);
            return id;            
        } 
    }
}