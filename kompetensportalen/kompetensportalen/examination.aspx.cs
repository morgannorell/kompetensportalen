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

        protected void Page_Load(object sender, EventArgs e)
        {
            answers = new List<ListItem> { answer1, answer2, answer3, answer4 };

            if (!IsPostBack)
            {
                questionIDs = examina.GetQuestionIDs();
                Session["questionIDs"] = questionIDs;

                qnbr.Visible = false;
                CheckBoxListAnswers.Visible = false;
                hr.Visible = false;
                btnNext.Visible = false;
                btnStart.Visible = true;
            }
            else
            {
                qnbr.Visible = true;
                CheckBoxListAnswers.Visible = true;
                hr.Visible = true;
                btnNext.Visible = true;
                btnStart.Visible = false;
            }                             
        }  

        public void Test()
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
                    Session["" + i + ""] = allAnswers[i];
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
            
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            Exam xam = new Exam();

            XmlDocument doc = new XmlDocument();
            doc.Load(Server.MapPath("xml/prov.xml"));

            XmlNode nodeOne = doc.SelectSingleNode("//Prov/Kategori[@ ID='ekonomi']");

            XmlDocument docTwo = new XmlDocument();
            docTwo.LoadXml("<Fråga>" + (string)Session["RandomQuestion"] + "<Svar>" + Session["0"] + "</Svar><Svar>" + Session["1"] + "</Svar><Svar>" + Session["2"] + "</Svar><Svar>" + Session["3"] + "</Svar><RättSvar>" + xam.GetCorrectAnswerTemp((int)Session["rqID"]) + "</RättSvar></Fråga>");

            XmlNode nodeTwo = doc.ImportNode(docTwo.FirstChild, true);
            nodeOne.AppendChild(nodeTwo);

            doc.Save(Server.MapPath("xml/prov.xml"));


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

            Test();

            //Response.Redirect(HttpContext.Current.Request.Path);
        }

        protected void btnStart_Click(object sender, EventArgs e)
        {
            Test();
        }
    }
}