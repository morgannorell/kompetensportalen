using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
using System.Configuration;
using System.Data;
using System.Diagnostics;

namespace kompetensportalen.classes
{
    public class Postgre
    {
        public NpgsqlCommand _cmd;
        public NpgsqlDataReader _dr;
        public NpgsqlConnection _conn;
        public NpgsqlDataAdapter _adapt;

        public Postgre()
        {
            _adapt = new NpgsqlDataAdapter();
            _conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["kp"].ConnectionString);
            _conn.Open();
        }

        public void OpenConnection()
        {
            if (_conn.State == ConnectionState.Closed)
            {
                _conn.Open();
            }
        }

        public void CloseConnection()
        {
            if (_conn.State == ConnectionState.Open)
            {
                _conn.Close();
            }
        }

        public NpgsqlDataReader PostgresDataReader(string sql)
        {
            try
            {
                _cmd = new NpgsqlCommand(sql, _conn);
                _dr = _cmd.ExecuteReader();
                return _dr;
            }
            catch (NpgsqlException ex)
            {
                Debug.Write(ex);
                return null;
            }
        }
    }
}