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
        Timer timerExam;
        int counter = 1800;

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

                List<int> remainingQuestions = new List<int>();
                remainingQuestions = (List<int>)Session["questionIDs"];

                if (remainingQuestions.Count <= 0)
                {
                    //System.Threading.Thread.Sleep(10000);
                    Response.Redirect("examDone.aspx");
                    //Response.Write("<script>alert('Du har svarat på samtliga frågor!');</script>");
                }
            }                             
        }



        //METHODS
        public void GetNewQuestionAndAnswers()
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
        protected void btnNext_Click(object sender, EventArgs e)
        {
            Exam xam = new Exam();
            string selectedAnswer = "";
            int countNoSelections = 0;
            int countToManySelected = 0;
            bool correctAmountSelected = false;

            XmlDocument doc = new XmlDocument();
            doc.Load(Server.MapPath("xml/prov.xml"));

            XmlNode nodeOne = doc.SelectSingleNode("//Prov/Kategori[@ ID='ekonomi']");

            foreach (ListItem item in CheckBoxListAnswers.Items)
            {
                if(item.Selected == true)
                {
                    countToManySelected++;
                    if (countToManySelected > 1)
                    {
                        Response.Write("<script>alert('Du har markerat för många svar! Markera endast ett svar, tack.');</script>");
                        return;
                    }
                    else
                    {
                        correctAmountSelected = item.Selected;
                    }
                }
            }

            foreach (ListItem item in CheckBoxListAnswers.Items)
            {
                countNoSelections++;

                if (correctAmountSelected == true && item.Text == xam.GetCorrectAnswerTemp((int)Session["rqID"]))
                {
                    selectedAnswer = item.Text;
                    break;
                }
                else if (correctAmountSelected == true && item.Text != xam.GetCorrectAnswerTemp((int)Session["rqID"]))
                {
                    selectedAnswer = item.Text;
                    break;
                }
                else if (countNoSelections >= 4)
                {
                    Response.Write("<script>alert('Markera ett svar!');</script>");
                    return;
                }
            }

            XmlDocument docTwo = new XmlDocument();
            docTwo.LoadXml("<Fråga>" + (string)Session["RandomQuestion"] + "<Svar>" + Session["0"] + "</Svar><Svar>" + Session["1"] + "</Svar><Svar>" + Session["2"] + "</Svar><Svar>" + Session["3"] + "</Svar><RättSvar>" + xam.GetCorrectAnswerTemp((int)Session["rqID"]) + "</RättSvar><MarkeratSvar>"+selectedAnswer+"</MarkeratSvar></Fråga>");

            XmlNode nodeTwo = doc.ImportNode(docTwo.FirstChild, true);
            nodeOne.AppendChild(nodeTwo);

            doc.Save(Server.MapPath("xml/prov.xml"));

            CheckBoxListAnswers.ClearSelection();

            GetNewQuestionAndAnswers();
        }


        protected void btnStart_Click(object sender, EventArgs e)
        {
            GetNewQuestionAndAnswers();
        }

        
    }
}