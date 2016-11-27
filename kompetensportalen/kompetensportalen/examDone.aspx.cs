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
            XmlDocument doc = corr.DbToXml((string)Session["username"]);
            //doc.Save(Server.MapPath("xml/done.xml"));

            XmlNodeList questions = doc.SelectNodes("/Prov/Kategori/Fråga");

            TableRow tr = null;
            int i = 1;
            int countCorrectAnswers = 0;

            foreach (XmlNode n in questions)
            {
                tr = new TableRow();

                TableCell questionNumber = new TableCell();
                TableCell question = new TableCell();
                TableCell correctAnswer = new TableCell();
                TableCell selectedAnswer = new TableCell();


                questionNumber.Text = i++.ToString();
                questionNumber.BackColor = System.Drawing.Color.FromName("#BDBDBD");
                question.Text = n["Text"].InnerText;
                question.BackColor = System.Drawing.Color.FromName("#BDBDBD");
                selectedAnswer.Text = n["Markeratsvar"].InnerText;
                correctAnswer.Text = n["RättSvar"].InnerText;
                correctAnswer.BackColor = System.Drawing.Color.FromName("#BDBDBD");

                if (selectedAnswer.Text == correctAnswer.Text)
                {
                    selectedAnswer.BackColor = System.Drawing.Color.FromName("#62983c");
                    selectedAnswer.ForeColor = System.Drawing.Color.FromName("#ffffff");
                    countCorrectAnswers++;
                }
                else
                {
                    selectedAnswer.BackColor = System.Drawing.Color.FromName("#F44336");
                    selectedAnswer.ForeColor = System.Drawing.Color.FromName("#ffffff");
                }

                tr.Cells.Add(questionNumber);
                tr.Cells.Add(question);
                tr.Cells.Add(correctAnswer);
                tr.Cells.Add(selectedAnswer);

                if (countCorrectAnswers >= ((i-1)*0.7))
                {
                    Label1.Text = "Du har svarat rätt på " + countCorrectAnswers.ToString() + " av " + (i - 1).ToString() + " frågor. Du är godkänd!";
                    User pass = new User();
                    pass.updateLicense((string)Session["Username"], true);
                }               
                else
                {
                    Label1.ForeColor = System.Drawing.Color.FromName("#F44336");
                    Label1.Text = "Du har svarat rätt på " + countCorrectAnswers.ToString() + " av " + (i - 1).ToString() + " frågor. Du är tyvärr underkänd!";
                    User fail = new User();
                    fail.updateLicense((string)Session["Username"], false);
                }
                ExamTable.Rows.Add(tr);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }
}