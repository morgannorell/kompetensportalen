using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
using System.Diagnostics;
using System.Data;

namespace kompetensportalen.classes
{
    public class Exam
    {
        

        public string question { get; set; }
        public int questionID { get; set; }
        public string answer { get; set; }
        public string selectedAnswer { get; set; }
        public string corrAnswerText { get; set; }
        public int answerID { get; set; }
        public bool correctAnswer { get; set; }
        public int correctAnswerID { get; set; }
        public string category { get; set; }

        public string GetQuestionFromDB(int question_id)
        {
            Postgre conn = new Postgre();
            
            string sql = "SELECT * FROM exam WHERE question_id=:question_id";

            try
            {
                conn._cmd = new NpgsqlCommand(sql, conn._conn);
                conn._cmd.Parameters.AddWithValue("question_id", question_id);
                conn._dr = conn._cmd.ExecuteReader();

                while(conn._dr.Read())
                {
                    question = conn._dr["question"] as string ?? "";
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
        public List<int> GetQuestionIDs(int examType)
        {
            Postgre conn = new Postgre();
            string sql = "";
            if (examType == 1)
            {
                sql = "select question_id from exam order by random() limit 25";
            }
            else if (examType == 2)
            {
                sql = "select question_id from exam order by random() limit 15";
            }
            
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

        public string GetCorrectAnswerTemp(int question)
        {
            Postgre conn = new Postgre();

            string sql = "select * from answers a where a.question = @question and a.correct = true";

            try
            {
                conn._cmd = new NpgsqlCommand(sql, conn._conn);
                conn._cmd.Parameters.AddWithValue("question", question);
                conn._dr = conn._cmd.ExecuteReader();

                while (conn._dr.Read())
                {
                    answer = conn._dr["answer"] as string ?? "";
                }
                return answer;
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

        public string GetCategory(int question_id)
        {
            Postgre conn = new Postgre();

            string sql = "select * from exam where question_id = @question_id";

            try
            {
                conn._cmd = new NpgsqlCommand(sql, conn._conn);
                conn._cmd.Parameters.AddWithValue("question_id", question_id);
                conn._dr = conn._cmd.ExecuteReader();

                while (conn._dr.Read())
                {
                    category = conn._dr["category"] as string ?? "";
                }
                return category;
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

        //public DataTable GetCorrectAnswer(string question)
        //{
        //    //Postgre db = new Postgre();
        //    //DataTable dt = new DataTable();

        //    //// Dictionary to send parameters in format key-value
        //    //Dictionary<string, string> myParams = new Dictionary<string, string>();

        //    //myParams.Add("@question_id", question);

        //    //// Sql query with parameters
        //    //string sql = "select * from exam e, answers a where e.correct_answer = a.answer_id and question_id = '@question'";

        //    //dt = db.Select(sql, myParams);

        //    //return dt;
        //}

        public bool xmlToDb(string username, string xml)
        {
            Postgre conn = new Postgre();

            string sql = "INSERT INTO examresult(username, xml) VALUES(@username, @xml)";

            try
            {
                conn._cmd = new NpgsqlCommand(sql, conn._conn);
                conn._cmd.Parameters.Add(new NpgsqlParameter("xml", xml));
                conn._cmd.Parameters.Add(new NpgsqlParameter("username", username));
                if (conn._cmd.ExecuteNonQuery() == 1)
                {
                    return true;
                }
                return false;
            }
            catch (NpgsqlException e)
            {
                Debug.Write(e);
                return false;
            }
        }

        public DataTable GetExam(string user)
        {
            Postgre db = new Postgre();
            DataTable dt = new DataTable();

            // Dictionary to send parameters in format key-value
            Dictionary<string, string> myParams = new Dictionary<string, string>();

            myParams.Add("@uname", user);

            string sql = "select * from examresult where username = @uname";
            
            dt = db.Select(sql, myParams);

            return dt;
        }
    }
}