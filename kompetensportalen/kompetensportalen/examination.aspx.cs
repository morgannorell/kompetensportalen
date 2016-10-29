using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using kompetensportalen.classes;
using System.Web.UI.HtmlControls;
using System.Data;

namespace kompetensportalen
{
    public partial class examination : System.Web.UI.Page
    {

        Postgre conn = new Postgre();
        Exam examina = new Exam();
        List<string> allAnswers = new List<string>();
        List<ListItem> answers;
        List<int> questionIDs = new List<int>();
        private Boolean IsPageRefresh = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            answers = new List<ListItem> { answer1, answer2, answer3, answer4 };

            if (!IsPostBack)
            {
                questionIDs = examina.GetQuestionIDs();
                Session["questionIDs"] = questionIDs;
                int randomQuestion = RandomQuestionFromDB();
                question.InnerText = examina.GetQuestionFromDB(randomQuestion);
                allAnswers = examina.GetAnswersFromDB(randomQuestion);

                if (randomQuestion > 0)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        ListItem answerPos = RandomAnswerPosition();
                        answerPos.Text = allAnswers[i];
                    }
                }
            }
            else
            {
                int randomQuestion = RandomQuestionFromDB();
                Session["rqID"] = randomQuestion;
                Session["RandomQuestion"] = examina.GetQuestionFromDB(randomQuestion);
                question.InnerText = examina.GetQuestionFromDB(randomQuestion);
                allAnswers = examina.GetAnswersFromDB(randomQuestion);

                if (randomQuestion > 0)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        ListItem answerPos = RandomAnswerPosition();
                        answerPos.Text = allAnswers[i];
                    }
                }
            }

                    

            
                      
        }  
        
        //METHODS
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
            var list = (List<int>)Session["questionIDs"];
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

        //EVENTS
        protected void btnNext_Load(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Server.MapPath("xml/prov.xml"));

            XmlNode nodeOne = doc.SelectSingleNode("//Prov/Kategori[@ ID='ekonomi']");

            XmlDocument docTwo = new XmlDocument();
            docTwo.LoadXml("<Fråga>" + (string)Session["RandomQuestion"] + "<Svar>" + allAnswers[0] + "</Svar><Svar>" + allAnswers[1] + "</Svar><Svar>" + allAnswers[2] + "</Svar><Svar>" + allAnswers[3] + "</Svar></Fråga>");

            XmlNode nodeTwo = doc.ImportNode(docTwo.FirstChild, true);
            nodeOne.AppendChild(nodeTwo);

            doc.Save(Server.MapPath("xml/prov.xml"));
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            //Hitta rätt svarselement och ange ett attribut som indikerar att det är rätt svar.
            Exam xam = new Exam();

            foreach (ListItem item in CheckBoxListAnswers.Items)
            {
                if (item.Selected == true && item.Text == xam.GetCorrectAnswerTemp((int)Session["rqID"]))
                {
                    error_login.InnerText = "Rätt svar!";
                    break;
                }
                else
                {
                    error_login.InnerText = "Fel svar!";
                }
            }

            CheckBoxListAnswers.ClearSelection();
        }


    }
}