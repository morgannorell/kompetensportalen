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

        public string GetQuestionFromDB(int question_id)
        {
            Postgre conn = new Postgre();
            
            string sql = "SELECT * FROM exam WHERE question_id=:question_id";
            string question = null;

            try
            {
                conn._cmd = new NpgsqlCommand(sql, conn._conn);
                conn._cmd.Parameters.AddWithValue("question_id", question_id);
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
            finally
            {
                conn.CloseConnection();
            }
            
        }

        public List<string> GetAnswersFromDB(int question)
        {
            Postgre conn = new Postgre();

            string sql = "SELECT * FROM answers WHERE question=:question";
            List<string> answers = new List<string>();
            string answer = null;

            try
            {
                conn._cmd = new NpgsqlCommand(sql, conn._conn);
                conn._cmd.Parameters.AddWithValue("question", question); 
                conn._dr = conn._cmd.ExecuteReader();

                while(conn._dr.Read())
                {
                    answer = conn._dr["answer"] as string ?? "";
                    answers.Add(answer);
                }
                return answers;
            }
            catch (Exception e)
            {
                Debug.Write(e);
                throw;
            }
            finally
            {
                conn.CloseConnection();
            }
            
        }

        /// <summary>
        /// Method to get all question IDs.
        /// </summary>
        /// <returns>List of all Question IDs</returns>
        public List<int> GetQuestionIDs()
        {
            Postgre conn = new Postgre();

            string sql = "SELECT question_id FROM exam";
            List<int> ids = new List<int>();
            int id = 0;

            try
            {
                conn._cmd = new NpgsqlCommand(sql, conn._conn);
                conn._dr = conn._cmd.ExecuteReader();

                while (conn._dr.Read())
                {
                    id = conn._dr["question_id"] as int? ?? default(int);
                    ids.Add(id);
                }
                return ids;
            }
            catch (Exception e)
            {
                Debug.Write(e);
                throw;
            }
            finally
            {
                conn.CloseConnection();
            }            
        }
    }
}