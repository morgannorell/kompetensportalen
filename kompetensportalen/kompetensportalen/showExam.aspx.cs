using kompetensportalen.classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;

namespace kompetensportalen
{
    public partial class showExam : System.Web.UI.Page
    {
        public string username;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["myparam"] != null)
                username = Request.QueryString["myparam"];

            LoadTest(username);
        }

        public void LoadTest(string username)
        {
            DataTable dt = new DataTable();
            Exam ex = new Exam();
            dt = ex.GetExam(username);

            string xml = "";

            foreach (DataRow col in dt.Rows)
            {
                xml = col["xml"].ToString();
            }

            XmlSerializer ser = new XmlSerializer(typeof(ReadTest));
            using (var reader = new StringReader(xml))
            {
                ReadTest item = (ReadTest)ser.Deserialize(reader);
                int total = 0;
                TableRow tr = null;

                string kat = "";
                int i = 1;
                int countCorrectAnswers = 0;

                foreach (var it in item.Kategori)
                {
                    //kat = it.Kategorityp;
                    //Console.WriteLine("Antal frågor: {0}", it.Fråga.Count);
                    //total += it.Fråga.Count;
                    //Console.WriteLine();
                    foreach (var kategori in it.Fråga)
                    {
                        //Console.WriteLine("Frågeid: {0}", kategori.Frågaid);
                        //Console.WriteLine("Text:");
                        //Console.WriteLine(kategori.Text);
                        //Console.WriteLine();


                        tr = new TableRow();

                        TableCell questionNumber = new TableCell();
                        TableCell question = new TableCell();
                        TableCell correctAnswer = new TableCell();
                        TableCell selectedAnswer = new TableCell();


                        questionNumber.Text = i++.ToString();
                        questionNumber.BackColor = System.Drawing.Color.FromName("#BDBDBD");
                        question.Text = kategori.Text;
                        question.BackColor = System.Drawing.Color.FromName("#BDBDBD");
                        selectedAnswer.Text = kategori.MarkeratSvar;
                        correctAnswer.Text = kategori.RättSvar;
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

                        if (countCorrectAnswers >= ((i - 1) * 0.7))
                        {
                            Label1.Text = "Du har svarat rätt på " + countCorrectAnswers.ToString() + " av " + (i - 1).ToString() + " frågor. Du är godkänd!";
                        }
                        else
                        {
                            Label1.ForeColor = System.Drawing.Color.FromName("#F44336");
                            Label1.Text = "Du har svarat rätt på " + countCorrectAnswers.ToString() + " av " + (i - 1).ToString() + " frågor. Du är tyvärr underkänd!";
                        }
                        showExamTable.Rows.Add(tr);
                    }
                }
                //xmlq.InnerHtml = kat;
            }
                

            
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminstart.aspx");
        }
    }
}