using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace kompetensportalen.classes
{
    public class User
    {
        // Properties
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public DataTable Login(string user, string pwd)
        {
            Postgre db = new Postgre();
            DataTable dt = new DataTable();
            

            string sql = "SELECT * FROM user WHERE username = admmono AND isadmin = true";
            dt = db.Select(sql);

            return dt;
        }
    }
}