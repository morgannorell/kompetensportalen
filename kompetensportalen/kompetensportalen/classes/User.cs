﻿using System;
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

        public DataTable Login()
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
    }
}