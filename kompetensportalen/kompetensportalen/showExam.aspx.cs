using kompetensportalen.classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
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
            {
                username = Request.QueryString["myparam"];
                LoadTest(username);
            }
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
                int countCorrectAnswers = 0; // Totalt antal rätt svar
                int etik = 0, produkt = 0, ekonomi = 0;
                int etikTot = 0, produktTot = 0, ekonomiTot = 0;
                
                HtmlGenericControl div = new HtmlGenericControl("div");
                div.InnerHtml = "<table Class=\"showExamTable\">";
                div.InnerHtml += "<tr><th>#</th><th>Fråga</th><th>Rätt svar</th><th>Ditt svar</th></tr>";

                foreach (var it in item.Kategori)
                {
                    div.InnerHtml += "<tr><td></td><td class=\"kategory\">Kategori: " + it.Kategorityp + "</td>";
                    div.InnerHtml += "<td colspan=\"2\" class=\"kategory\">frågor i kategori: " + it.Fråga.Count + "</td></tr>";

                    foreach (var kategori in it.Fråga)
                    {
                        div.InnerHtml += "<tr>";
                        div.InnerHtml += "<td>" + total + "</td>";
                        div.InnerHtml += "<td>" + kategori.Text + "</td>";
                        div.InnerHtml += "<td>" + kategori.RättSvar + "</td>";

                        if (kategori.RättSvar == kategori.MarkeratSvar)
                        {
                            div.InnerHtml += "<td class=\"tdcorrect\">";
                            countCorrectAnswers++;
                            if (it.Kategorityp == "Etik")
                                etik++;
                            if (it.Kategorityp == "Produkt")
                                produkt++;
                            if (it.Kategorityp == "Ekonomi")
                                ekonomi++;
                        }
                        else
                            div.InnerHtml += "<td class=\"tdfail\">";

                        div.InnerHtml += kategori.MarkeratSvar + "</td>";
                        div.InnerHtml += "</tr>";

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
                    }
                    
                }
                div.InnerHtml += "</table>";
                testresult.Controls.Add(div);

                HtmlGenericControl divTitle = new HtmlGenericControl("div");

                int totalpercent = countCorrectAnswers * 100 / total;
                int etikpercent = etik * 100 / etikTot;
                int produktpercent = produkt * 100 / produktTot;
                int ekonomipercent = ekonomi * 100 / ekonomiTot;

                bool succsess = false;
                string 

                // Test if test is successful
                if ((totalpercent >= 70 && etikpercent >= 60) || (totalpercent >= 70 && produktpercent >= 60) || (totalpercent >= 70 && ekonomipercent >= 60)
                    || (etikpercent >= 60 && produktpercent >= 60) || (etikpercent >= 60 && ekonomipercent >= 60) || (produktpercent >= 60 && ekonomipercent >= 60))
                {
                    succsess = true;

                }
                    

                if (succsess == true)
                    divTitle.InnerHtml += "<div class=\"label\">Grattis du har klarat provet.</div>";
                else
                    divTitle.InnerHtml += "<div class=\"label\">Du är tyvärr underkänd på provet.</div>";

                divTitle.InnerHtml += "<div class=\"label-sm\">Du har svarat på " + total + " frågot och svarade rätt på " + countCorrectAnswers + " frågor." + totalpercent + "%</div>";
                divTitle.InnerHtml += "<div class=\"label-sm\">I kategorin Etik svarade du rätt på " + etik + " frågor. " + etikpercent + " %</div>";
                divTitle.InnerHtml += "<div class=\"label-sm\">I kategorin Produkt svarade du rätt på " + produkt + " frågor. " + produktpercent + "%</div>";
                divTitle.InnerHtml += "<div class=\"label-sm\">I kategorin Ekonomi svarade du rätt på " + ekonomi + " frågor. " + ekonomipercent + "%</div>";

                testTitle.Controls.Add(divTitle);
                
            }                          
        }
    }
}