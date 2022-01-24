
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DisneyAPI.Data
{
    public class SqlRepo
    {
        private static SqlRepo instance;
        public SqlConnection Conn { get; set; }
        public SqlCommand Command { get; set; }
        private string strConnection;

        private SqlRepo()
        {
            //Change the string connection
            strConnection = @"Data Source=localhost;Initial Catalog=DisneyAPIDb;Integrated Security=True";
            Conn = new SqlConnection(strConnection);
        }

        public static SqlRepo GetDao()
        {
            if (instance == null)
                instance = new SqlRepo();
            return instance;
        }

        internal void OpenConn()
        {
            if (Conn.State.Equals(ConnectionState.Closed))
                Conn.Open();
        }

        internal void CloseConn()
        {
            if (Conn.State.Equals(ConnectionState.Open))
                Conn.Close();
        }

        public DataTable GetAll(string commandText)
        {
            DataTable dt = new DataTable();
            OpenConn();
            Command = Conn.CreateCommand();
            Command.CommandText = commandText;
            Command.CommandType = CommandType.StoredProcedure;
            dt.Load(Command.ExecuteReader());
            CloseConn();
            return dt;
        }
        public DataTable GetByFilter(string commandText, Dictionary<string, object> parameters)
        {
            DataTable dt = new DataTable();
            OpenConn();
            Command = new SqlCommand();
            Command.Connection = Conn;
            Command.CommandText = commandText;
            Command.CommandType = CommandType.StoredProcedure;
            foreach (KeyValuePair<string, object> param in parameters)
            {

                SqlParameter parameter = new SqlParameter(param.Key, param.Value);
                parameter.IsNullable = true;
                Command.Parameters.Add(parameter);
            }
            dt.Load(Command.ExecuteReader());
            CloseConn();
            return dt;
        }

        public DataTable GetByFilter(string commandText, string param ,object value)
        {
            DataTable dt = new DataTable();
            OpenConn();
            Command = new SqlCommand();
            Command.Connection = Conn;
            Command.CommandText = commandText;
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.AddWithValue(param, value);
            dt.Load(Command.ExecuteReader());
            CloseConn();
            return dt;
        }

        public bool create(object objectoToCreate)
        {
            throw new System.NotImplementedException();
        }
    }
}
