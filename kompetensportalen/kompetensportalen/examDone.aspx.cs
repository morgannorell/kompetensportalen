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
            //XmlDocument doc = corr.DbToXml((string)Session["username"]);
            //doc.Save(Server.MapPath("xml/done.xml"));
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            XmlDocument doc = corr.DbToXml((string)Session["username"]);
            doc.Save(Server.MapPath("xml/done.xml"));

            XmlNodeList questions = doc.SelectNodes("/Prov/Kategori/Fråga");

            TableRow tr = null;
            int i = 1;

            foreach (XmlNode n in questions)
            {
                tr = new TableRow();

                //Exam xam = new Exam();
                //xam.question = n["Fråga"].InnerText;
                //xam.selectedAnswer = n["Markeratsvar"].InnerText;
                //xam.corrAnswerText = n["RättSvar"].InnerText;

                TableCell questionNumber = new TableCell();
                TableCell question = new TableCell();
                TableCell correctAnswer = new TableCell();
                TableCell selectedAnswer = new TableCell();

                
                questionNumber.Text = i++.ToString();
                question.Text = n["Text"].InnerText;
                selectedAnswer.Text = n["Markeratsvar"].InnerText;
                correctAnswer.Text = n["RättSvar"].InnerText;

                if (selectedAnswer.Text == correctAnswer.Text)
                {
                    selectedAnswer.BackColor = System.Drawing.Color.Green;
                }
                else
                {
                    selectedAnswer.BackColor = System.Drawing.Color.Red;
                }

                tr.Cells.Add(questionNumber);
                tr.Cells.Add(question);
                tr.Cells.Add(correctAnswer);
                tr.Cells.Add(selectedAnswer);
                

                ExamTable.Rows.Add(tr);
            }
            

            //XmlTextReader reader = new XmlTextReader(path);
            //XmlNode node = doc.ReadNode(reader);
            //List<string> questions = new List<string>();

            //foreach (XmlNode childNode in node.ChildNodes)
            //{
            //    int id = Convert.ToInt32(childNode.Attributes["id"].Value);
            //    string question = xam.GetQuestionFromDB(id);

            //    if (question == childNode.Value)
            //    {
            //        Label1.Text = "Test";
            //    }
            //}
        }
    }
}