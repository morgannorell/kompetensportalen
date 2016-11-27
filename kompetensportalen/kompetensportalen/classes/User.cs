using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Npgsql;
using System.Diagnostics;

namespace kompetensportalen.classes
{
    public class User
    {
        // Properties
        public int userid { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public DataTable GetUserList()
        {
            Postgre db = new Postgre();
            DataTable dt = new DataTable();

            string sql = "SELECT * FROM person WHERE isadmin = false";
            dt = db.Select(sql);

            return dt;
        }
        public DataTable CourseLogin()
        {
            Postgre db = new Postgre();
            DataTable dt = new DataTable();

            // Dictionary to send parameters in format key-value
            Dictionary<string, string> myParams = new Dictionary<string, string>();

            myParams.Add("@username", Username);
            myParams.Add("@password", Password);

            // Sql query with parameters
            string sql = "SELECT * FROM person " +
                "WHERE username = @username AND " +
                "password = @password AND " +
                "isadmin = false";


            dt = db.Select(sql, myParams);

            return dt;
        }

        public DataTable AdmLogin()
        {
            Postgre db = new Postgre();
            DataTable dt = new DataTable();

            Dictionary<string, string> myParams = new Dictionary<string, string>();

            myParams.Add("@username", Username);
            myParams.Add("@password", Password);            

            // Sql query with parameters
            string sql = "SELECT * FROM person " +
                "WHERE username = @username AND " +
                "password = @password AND " +
                "isadmin = true";


            dt = db.Select(sql ,myParams);

            return dt;
        }

        public bool GetLicenseApproved(string username)
        {
            Postgre conn = new Postgre();

            string sql = "select * from person where username = @username";
            bool approved = false;

            try
            {
                conn._cmd = new NpgsqlCommand(sql, conn._conn);
                conn._cmd.Parameters.AddWithValue("username", username);
                conn._dr = conn._cmd.ExecuteReader();

                while (conn._dr.Read())
                {
                    approved = conn._dr["licensed"] as bool? ?? default(bool);
                }
                return approved;
            }
            catch (Exception e)
            {
                Debug.Write(e);
                return false;
            }
            finally
            {
                conn.CloseConnection();
            }
        }

        public bool updateLicense(string username, bool licensed)
        {
            Postgre conn = new Postgre();

            string sql = "UPDATE person SET licensed = @licensed WHERE username = @username";

            try
            {
                conn._cmd = new NpgsqlCommand(sql, conn._conn);
                conn._cmd.Parameters.Add(new NpgsqlParameter("licensed", licensed));
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



    }
}