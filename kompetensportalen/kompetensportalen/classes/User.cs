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

        public void Login()
        {
            string sql = "SELECT * FROM user WHERE username = str AND isadmin = true";
            DataTable dt = new DataTable();

            Postgre ps = new Postgre();
        }
    }
}