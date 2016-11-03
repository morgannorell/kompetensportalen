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

        public DataTable Select(string sql, Dictionary<string, string> myParams)
        {
            DataTable myTable = new DataTable();           
            try
            {
                _cmd = new NpgsqlCommand(sql, _conn);
                foreach (KeyValuePair<string, string> entry in myParams)
                {
                    _cmd.Parameters.AddWithValue(entry.Key, entry.Value);
                }

                _dr = _cmd.ExecuteReader();
                myTable.Load(_dr);

                return myTable;
            }
            catch (NpgsqlException ex)
            {
                Debug.Write(ex);
                throw;
            }
            finally
            {
                CloseConnection();
            }
        }

        // Select without parameters
        public DataTable Select(string sql)
        {
            DataTable myTable = new DataTable();
            try
            {
                _cmd = new NpgsqlCommand(sql, _conn);
                _dr = _cmd.ExecuteReader();
                myTable.Load(_dr);

                return myTable;
            }
            catch (NpgsqlException ex)
            {
                Debug.Write(ex);
                throw;
            }
            finally
            {
                _conn.Close();
            }
        }

        public void SetParameter(string parametername, string parametervalue)
        {
            new NpgsqlParameter(parametername, parametervalue);
        }
    }
}