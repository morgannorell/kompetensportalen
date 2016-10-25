using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
using System.Diagnostics;

namespace kompetensportalen.classes
{
    public class Exam
    {
        

        public string question { get; set; }
        public string answer { get; set; }

        public string GetQuestionFromDB()
        {
            Postgre conn = new Postgre();
            
            string sql = "SELECT * FROM exam WHERE id=1";
            string question = null;

            try
            {
                conn._cmd = new NpgsqlCommand(sql, conn._conn);
                conn._dr = conn._cmd.ExecuteReader();

                while(conn._dr.Read())
                {
                    string quest = conn._dr["question"].ToString();
                    question = quest;
                }
                return question;
            }
            catch (NpgsqlException e)
            {
                Debug.Write(e);
                throw;
            }
            conn.CloseConnection();
        }
    }
}