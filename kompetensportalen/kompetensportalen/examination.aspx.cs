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
using System.Xml.Linq;

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
                User user = new classes.User();

                bool whichQuestions = user.GetLicenseApproved((string)Session["username"]);
                if (whichQuestions == true )
                {
                    int getExam = 1;
                    questionIDs = examina.GetQuestionIDs(getExam);
                    Session["questionIDs"] = questionIDs;
                }
                else
                {
                    int getExam = 2;
                    questionIDs = examina.GetQuestionIDs(getExam);
                    Session["questionIDs"] = questionIDs;
                }

                qnbr.Visible = false;
                CheckBoxListAnswers.Visible = false;
                hr.Visible = false;
                btnNext.Visible = false;
                btnStart.Visible = true;
                H1.Visible = true;
                text.Visible = true;
            }
            else
            {
                qnbr.Visible = true;
                CheckBoxListAnswers.Visible = true;
                hr.Visible = true;
                btnNext.Visible = true;
                btnStart.Visible = false;
                H1.Visible = false;
                text.Visible = false;
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
        static int questionCounter = 0;
        //EVENTS
        protected void btnNext_Click(object sender, EventArgs e)
        {
            Exam xam = new Exam();
            string selectedAnswer = "";
            int countNoSelections = 0;
            int countToManySelected = 0;
            bool correctAmountSelected = false;
            questionCounter++;

            ScriptManager.RegisterStartupScript(this, GetType(), "Resume", "resumeCountdown()", true);

            XmlDocument doc = new XmlDocument();
            doc.Load(Server.MapPath("xml/prov.xml"));

            XmlNode nodeOne = doc.SelectSingleNode("//Prov/Kategori[@ id='"+xam.GetCategory((int)Session["rqID"])+"']");

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

            XElement question = new XElement("Fråga");
            XElement ans1 = new XElement("Svar");
            question.SetAttributeValue("id", questionCounter.ToString());
            question.SetValue((string)Session["RandomQuestion"]);
            question.SetElementValue("SvarEtt", Session["0"]);
            question.SetElementValue("SvarTvå", Session["1"]);
            question.SetElementValue("SvarTre", Session["2"]);
            question.SetElementValue("SvarFyra", Session["3"]);
            question.SetElementValue("RättSvar", xam.GetCorrectAnswerTemp((int)Session["rqID"]));
            question.SetElementValue("Markeratsvar", selectedAnswer);

            XmlDocument docTwo = new XmlDocument();
            docTwo.LoadXml(""+question+"");

            XmlNode nodeTwo = doc.ImportNode(docTwo.FirstChild, true);
            nodeOne.AppendChild(nodeTwo);

            doc.Save(Server.MapPath("xml/prov.xml"));

            User user = new classes.User();

            var list = (List<int>)Session["questionIDs"];
            if (list.Count == 0)
            {
                string xmlstring = doc.OuterXml;
                string uname = (string)Session["username"];
                xam.xmlToDb(uname, xmlstring);

                doc.DocumentElement.RemoveAll();

                XDeclaration dec = new XDeclaration("1.0", "utf-8", "no");
                XElement etik = new XElement("Kategori");
                XElement produkt = new XElement("Kategori");
                XElement ekonomi = new XElement("Kategori");

                etik.SetAttributeValue("id", "Etik");
                produkt.SetAttributeValue("id", "Produkt");
                ekonomi.SetAttributeValue("id", "Ekonomi");

                doc.LoadXml(""+dec+" <Prov>" + etik + " "+produkt+" "+ekonomi+"</Prov>");

                doc.Save(Server.MapPath("xml/prov.xml"));

                questionCounter = 0;

                Response.Redirect("examDone.aspx");
            }

            CheckBoxListAnswers.ClearSelection();

            GetNewQuestionAndAnswers();

            category.InnerText = "Kategori: " + xam.GetCategory((int)Session["rqID"]) + "";
        }


        protected void btnStart_Click(object sender, EventArgs e)
        {
            Exam xam = new Exam();
            GetNewQuestionAndAnswers();
            ScriptManager.RegisterStartupScript(this, GetType(), "Start", "startCountdown()", true);
            category.InnerText = "Kategori: " + xam.GetCategory((int)Session["rqID"]) + "";
        }

        
    }
}