using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using kompetensportalen.classes;
using System.Web.UI.HtmlControls;
using System.Xml.Serialization;
using System.IO;
using System.Data;

namespace kompetensportalen
{
    public partial class examDone : System.Web.UI.Page
    {
        XmlDocument doc = new XmlDocument();
        Correct corr = new Correct();
        Exam xam = new Exam();

        protected void Page_Load(object sender, EventArgs e)
        {

            LoadTest((string)Session["username"]);

            //    XmlDocument doc = corr.DbToXml((string)Session["username"]);
            //    //doc.Save(Server.MapPath("xml/done.xml"));

            //    XmlNodeList questions = doc.SelectNodes("/Prov/Kategori/Fråga");

            //    TableRow tr = null;
            //    int i = 1;
            //    int countCorrectAnswers = 0;

            //    foreach (XmlNode n in questions)
            //    {
            //        tr = new TableRow();

            //        TableCell questionNumber = new TableCell();
            //        TableCell question = new TableCell();
            //        TableCell correctAnswer = new TableCell();
            //        TableCell selectedAnswer = new TableCell();


            //        questionNumber.Text = i++.ToString();
            //        questionNumber.BackColor = System.Drawing.Color.FromName("#BDBDBD");
            //        question.Text = n["Text"].InnerText;
            //        question.BackColor = System.Drawing.Color.FromName("#BDBDBD");
            //        selectedAnswer.Text = n["Markeratsvar"].InnerText;
            //        correctAnswer.Text = n["RättSvar"].InnerText;
            //        correctAnswer.BackColor = System.Drawing.Color.FromName("#BDBDBD");

            //        if (selectedAnswer.Text == correctAnswer.Text)
            //        {
            //            selectedAnswer.BackColor = System.Drawing.Color.FromName("#62983c");
            //            selectedAnswer.ForeColor = System.Drawing.Color.FromName("#ffffff");
            //            countCorrectAnswers++;
            //        }
            //        else
            //        {
            //            selectedAnswer.BackColor = System.Drawing.Color.FromName("#F44336");
            //            selectedAnswer.ForeColor = System.Drawing.Color.FromName("#ffffff");
            //        }

            //        tr.Cells.Add(questionNumber);
            //        tr.Cells.Add(question);
            //        tr.Cells.Add(correctAnswer);
            //        tr.Cells.Add(selectedAnswer);

            //        if (countCorrectAnswers >= ((i-1)*0.7))
            //        {
            //            Label1.Text = "Du har svarat rätt på " + countCorrectAnswers.ToString() + " av " + (i - 1).ToString() + " frågor. Du är godkänd!";
            //            User pass = new User();
            //            pass.updateLicense((string)Session["Username"], true);
            //        }               
            //        else
            //        {
            //            Label1.ForeColor = System.Drawing.Color.FromName("#F44336");
            //            Label1.Text = "Du har svarat rätt på " + countCorrectAnswers.ToString() + " av " + (i - 1).ToString() + " frågor. Du är tyvärr underkänd!";
            //            User fail = new User();
            //            fail.updateLicense((string)Session["Username"], false);
            //        }
            //        ExamTable.Rows.Add(tr);
            //    }
        }

            protected void Button1_Click(object sender, EventArgs e)
            {
                Response.Redirect("index.aspx");
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
                TableRow tr = null;
                TableRow tr2 = null;
                int total = 1;
                int countCorrectAnswers = 0; // Totalt antal rätt svar
                int etik = 0, produkt = 0, ekonomi = 0;
                int etikTot = 0, produktTot = 0, ekonomiTot = 0;

                //HtmlGenericControl div = new HtmlGenericControl("div");
                //div.InnerHtml = "<table Class=\"showExamTable\">";
                //div.InnerHtml += "<tr><th>#</th><th>Fråga</th><th>Rätt svar</th><th>Ditt svar</th></tr>";

                foreach (var it in item.Kategori)
                {
                    tr2 = new TableRow();

                    TableCell empt = new TableCell();
                    TableCell kat = new TableCell();
                    TableCell katnr = new TableCell();

                    kat.Font.Bold = true;
                    katnr.Font.Bold = true;

                    kat.Text = "Kategori: " + it.Kategorityp + "";
                    katnr.Text = "Frågor i kategori: " + it.Fråga.Count + "";
                    katnr.ColumnSpan = 2;
                    //div.InnerHtml += "<tr><td></td><td class=\"kategory\">Kategori: " + it.Kategorityp + "</td>";
                    //div.InnerHtml += "<td colspan=\"2\" class=\"kategory\">frågor i kategori: " + it.Fråga.Count + "</td></tr>";

                    tr2.Cells.Add(empt);
                    tr2.Cells.Add(kat);
                    tr2.Cells.Add(katnr);

                    ExamTable.Rows.Add(tr2);

                    foreach (var kategori in it.Fråga)
                    {
                        tr = new TableRow();

                        TableCell questionNumber = new TableCell();
                        TableCell question = new TableCell();
                        TableCell correctAnswer = new TableCell();
                        TableCell selectedAnswer = new TableCell();

                        questionNumber.Text = total.ToString();
                        question.Text = kategori.Text;
                        correctAnswer.Text = kategori.RättSvar;
                        selectedAnswer.Text = kategori.MarkeratSvar;


                        //div.InnerHtml += "<tr>";
                        //div.InnerHtml += "<td>" + total + "</td>";
                        //div.InnerHtml += "<td>" + kategori.Text + "</td>";
                        //div.InnerHtml += "<td>" + kategori.RättSvar + "</td>";

                        if (kategori.RättSvar == kategori.MarkeratSvar)
                        {
                            selectedAnswer.BackColor = System.Drawing.Color.FromName("#62983c");
                            selectedAnswer.ForeColor = System.Drawing.Color.FromName("#ffffff");
                            //div.InnerHtml += "<td class=\"tdcorrect\">";
                            countCorrectAnswers++;
                            if (it.Kategorityp == "Etik")
                                etik++;
                            if (it.Kategorityp == "Produkt")
                                produkt++;
                            if (it.Kategorityp == "Ekonomi")
                                ekonomi++;
                        }
                        else
                        {
                            selectedAnswer.BackColor = System.Drawing.Color.FromName("#F44336");
                            selectedAnswer.ForeColor = System.Drawing.Color.FromName("#ffffff");
                        }
                        //    div.InnerHtml += "<td class=\"tdfail\">";

                        //div.InnerHtml += kategori.MarkeratSvar + "</td>";
                        //div.InnerHtml += "</tr>";

                        if (it.Kategorityp == "Etik")
                            etikTot++;
                        if (it.Kategorityp == "Produkt")
                            produktTot++;
                        if (it.Kategorityp == "Ekonomi")
                            ekonomiTot++;

                        total++;

                        //if (countCorrectAnswers >= ((i - 1) * 0.7))
                        //{
                        //    Label1.Text = "Du har svarat rätt på " + countCorrectAnswers.ToString() + " av " + (i - 1).ToString() + " frågor. Du är godkänd!";
                        //}
                        //else
                        //{
                        //    Label1.ForeColor = System.Drawing.Color.FromName("#F44336");
                        //    Label1.Text = "Du har svarat rätt på " + countCorrectAnswers.ToString() + " av " + (i - 1).ToString() + " frågor. Du är tyvärr underkänd!";
                        //}
                        //showExamTable.Rows.Add(tr);

                        tr.Cells.Add(questionNumber);
                        tr.Cells.Add(question);
                        tr.Cells.Add(correctAnswer);
                        tr.Cells.Add(selectedAnswer);

                        ExamTable.Rows.Add(tr);
                    }

                }
                //div.InnerHtml += "</table>";
                //testresult.Controls.Add(div);

                //HtmlGenericControl divTitle = new HtmlGenericControl("div");

                int totalpercent = countCorrectAnswers * 100 / total;
                int etikpercent = etik * 100 / etikTot;
                int produktpercent = produkt * 100 / produktTot;
                int ekonomipercent = ekonomi * 100 / ekonomiTot;

                bool succsess = false;
                ////string 

                // Test if test is successful
                if (totalpercent >= 70 && etikpercent >= 60 && produktpercent >= 60 && ekonomipercent >= 60)
                {
                    succsess = true;
                }

                if (succsess == true)
                {
                    Label1.Text = "Du har svarat rätt på " + countCorrectAnswers.ToString() + " av " + (total - 1).ToString() + " frågor. Du är  godkänd!";
                    Label2.Text = "Etik: " + etik + " av " + etikTot + ", " + etikpercent + "%.";
                    Label3.Text = "Produkt: " + produkt + " av " + produktTot + ", " + produktpercent + "%.";
                    Label4.Text = "Ekonomi: " + ekonomi + " av " + ekonomiTot + ", " + ekonomipercent + "%.";

                    User pass = new User();
                    pass.updateLicense((string)Session["username"], true);
                }
                else
                {
                    Label1.ForeColor = System.Drawing.Color.FromName("#F44336");
                    Label2.ForeColor = System.Drawing.Color.FromName("#F44336");
                    Label3.ForeColor = System.Drawing.Color.FromName("#F44336");
                    Label4.ForeColor = System.Drawing.Color.FromName("#F44336");

                    Label1.Text = "Du har svarat rätt på " + countCorrectAnswers.ToString() + " av " + (total - 1).ToString() + " frågor. Du är underkänd!";
                    Label2.Text = "Etik: " + etik + " av " + etikTot + ", " + etikpercent + "%.";
                    Label3.Text = "Produkt: " + produkt + " av " + produktTot + ", " + produktpercent + "%.";
                    Label4.Text = "Ekonomi: " + ekonomi + " av " + ekonomiTot + ", " + ekonomipercent + "%.";

                    User fail = new User();
                    fail.updateLicense((string)Session["username"], false);
                }

                //if (succsess == true)
                //    divTitle.InnerHtml += "<div class=\"label\">Grattis du har klarat provet.</div>";
                //else
                //    divTitle.InnerHtml += "<div class=\"label\">Du är tyvärr underkänd på provet.</div>";

                //divTitle.InnerHtml += "<div class=\"label-sm\">Du har svarat på " + total + " frågot och svarade rätt på " + countCorrectAnswers + " frågor." + totalpercent + "%</div>";
                //divTitle.InnerHtml += "<div class=\"label-sm\">I kategorin Etik svarade du rätt på " + etik + " frågor. " + etikpercent + " %</div>";
                //divTitle.InnerHtml += "<div class=\"label-sm\">I kategorin Produkt svarade du rätt på " + produkt + " frågor. " + produktpercent + "%</div>";
                //divTitle.InnerHtml += "<div class=\"label-sm\">I kategorin Ekonomi svarade du rätt på " + ekonomi + " frågor. " + ekonomipercent + "%</div>";

                //testTitle.Controls.Add(divTitle);

            }

        }
    }
}