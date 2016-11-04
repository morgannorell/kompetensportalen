using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using kompetensportalen.classes;
using Npgsql;
using System.Diagnostics;

namespace kompetensportalen.classes
{
    public class Correct
    {
        public XmlDocument DbToXml(string username)
        {
            XmlDocument doc = new XmlDocument();
            Postgre conn = new Postgre();

            string sql = "SELECT * FROM examresult WHERE username=:username";

            try
            {
                conn._cmd = new NpgsqlCommand(sql, conn._conn);
                conn._cmd.Parameters.AddWithValue("username", username);
                conn._dr = conn._cmd.ExecuteReader();

                while (conn._dr.Read())
                {
                    doc.LoadXml(conn._dr["xml"].ToString());
                }
                return doc;
            }
            catch (NpgsqlException e)
            {
                Debug.Write(e);
                return null;
            }
            finally
            {
                conn.CloseConnection();
            }
        }
    }
}