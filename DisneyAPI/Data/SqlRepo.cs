
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Transactions;

namespace DisneyAPI.Data
{
    public class SqlRepo : IDao<object>
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

        internal async Task OpenConnAsync()
        {
            if (Conn.State.Equals(ConnectionState.Closed))
                Conn.Open();
        }

        internal async Task CloseConnAsync()
        {
            if (Conn.State.Equals(ConnectionState.Open))
                Conn.Close();
        }


        public async Task<IEnumerable<object>> GetAllAsync(string commandText)
        {
            DataTable dt = new DataTable();
            try
            {
                await OpenConnAsync();
                Command = Conn.CreateCommand();
                Command.CommandText = commandText;
                Command.CommandType = CommandType.StoredProcedure;
                dt.Load(await Command.ExecuteReaderAsync());
                return dt.AsEnumerable();
            }
            catch (SqlException ex) { throw ex; }
            finally { await CloseConnAsync(); }
        }

        public async Task<IEnumerable<object>> GetByFilterAsync(string commandText, Dictionary<string, object> parameters)
        {
            DataTable dt = new DataTable();
            try
            {
                await OpenConnAsync();
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
                dt.Load(await Command.ExecuteReaderAsync());
                return dt.AsEnumerable();

            }
            catch (SqlException ex) { throw ex; }
            finally { await CloseConnAsync(); }
        }

        public async Task<IEnumerable<object>> GetByFilterAsync(string commandText, string param, object value)
        {
            DataTable dt = new DataTable();
            try
            {
                await OpenConnAsync();
                Command = new SqlCommand();
                Command.Connection = Conn;
                Command.CommandText = commandText;
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue(param, value);
                dt.Load(await Command.ExecuteReaderAsync());
                return dt.AsEnumerable();
            }
            catch (SqlException ex) { throw ex; }
            finally { await CloseConnAsync(); }
        }
        public async Task<bool> CreateAsync(string commandText, Dictionary<string, object> commandParameters)
        {
            bool flag = false;
            try
            {
                await OpenConnAsync();
                Command = Conn.CreateCommand();
                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandText = commandText;

                foreach (KeyValuePair<string, object> param in commandParameters) 
                {
                    Command.Parameters.AddWithValue(param.Key, param.Value);   
                }

                int affRow = await Command.ExecuteNonQueryAsync();

                if (affRow > 0) 
                    flag = true;
                return flag;
            }
            catch (SqlException ex) { throw ex; }
            finally { await CloseConnAsync(); }
        }

        public async Task<bool> CreateWithTransactAsync(SqlTransaction transc)
        {
            bool flag = false;
            try
            {
                transc.Commit();
                flag = true;
                return flag;
            }
            catch (SqlException ex) { throw ex; transc.Rollback();}
            finally { await CloseConnAsync(); }
        }

        public async Task<bool> UpdateAsync(string commandText, Dictionary<string, object> commandParameters)
        {
            return await CreateAsync(commandText, commandParameters);
        }

        public async Task<bool> DeleteAsync(string CommandText, object id)
        {
            bool flag = false;
            try
            {
                await OpenConnAsync();
                Command = Conn.CreateCommand();
                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandText = CommandText;

                Command.Parameters.AddWithValue("@id", id); 

                int affRow = await Command.ExecuteNonQueryAsync();

                if (affRow > 0)
                    flag = true;
                return flag;
            }
            catch (SqlException ex) { throw ex; }
            finally { await CloseConnAsync(); }
        }

        public Task<bool> CreateAsync(object entity)
        {
            throw new NotImplementedException();
        }
    }

        
        //bool flag = false;
        //try
        //{
        //    await OpenConnAsync(); 

        //   

        //    Command.Parameters.AddWithValue("@name", objectTocreate.Name);
        //    Command.Parameters.AddWithValue("@age", objectTocreate.Age);
        //    Command.Parameters.AddWithValue("@weight", objectTocreate.Weight);
        //    Command.Parameters.AddWithValue("@story", objectTocreate.Story);
        //    Command.Parameters.AddWithValue("@imgUrl", objectTocreate.ImgUrl);

        //    int affRow = sqlDao.Command.ExecuteNonQuery();

        //    if (affRow > 0) { flag = true; }
        //    return flag;
        //}
        //catch (Exception ex)
        //{
        //    throw ex;
        //}
        //finally
        //{
        //    sqlDao.CloseConnAsync();
        //}

        //public Task updateAsync(object objectToUpdate)
        //{
        //    throw new System.NotImplementedException();
        //}

        //public Task DeleteAsync(int id)
        //{
        //    throw new System.NotImplementedException();
        //}
        //public DataTable GetByFilter(string commandText, Dictionary<string, object> parameters)
        //{
        //    DataTable dt = new DataTable();
        //    OpenConn();
        //    Command = new SqlCommand();
        //    Command.Connection = Conn;
        //    Command.CommandText = commandText;
        //    Command.CommandType = CommandType.StoredProcedure;
        //    foreach (KeyValuePair<string, object> param in parameters)
        //    {

        //        SqlParameter parameter = new SqlParameter(param.Key, param.Value);
        //        parameter.IsNullable = true;
        //        Command.Parameters.Add(parameter);
        //    }
        //    dt.Load(Command.ExecuteReader());
        //    CloseConn();
        //    return dt;
        //}

        //public DataTable GetByFilter(string commandText, string param ,object value)
        //{
        //    DataTable dt = new DataTable();
        //    OpenConn();
        //    Command = new SqlCommand();
        //    Command.Connection = Conn;
        //    Command.CommandText = commandText;
        //    Command.CommandType = CommandType.StoredProcedure;
        //    Command.Parameters.AddWithValue(param, value);
        //    dt.Load(Command.ExecuteReader());
        //    CloseConn();
        //    return dt;
        //}

        //public bool create(object objectoToCreate)
        //{
        //    throw new System.NotImplementedException();
        //}
    //}
}
