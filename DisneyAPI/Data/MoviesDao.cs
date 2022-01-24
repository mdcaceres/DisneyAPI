using DisneyAPI.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DisneyAPI.Data
{
    public class MoviesDao : IDao<Movie>
    {
        private SqlRepo sqlDao;

        public MoviesDao()
        {
            sqlDao = SqlRepo.GetDao();
        }

        public IEnumerable<Movie> GetAll(string commandText)
        {
            DataTable dt = sqlDao.GetAll(commandText);
            List<Movie> lst = new List<Movie>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Movie m = new Movie();
                m.Id = Convert.ToInt32(dt.Rows[i][0]);
                m.Title = dt.Rows[i][1].ToString();
                m.Date = Convert.ToDateTime(dt.Rows[i][2]);
                m.Rating = Convert.ToInt32(dt.Rows[i][3]);
                //m.IdGender = Convert.ToInt32(dt.Rows[i][4]);
                m.ImgUrl = dt.Rows[i][4].ToString();
                lst.Add(m);
            }
            return lst;
        }

        public IEnumerable<Movie> GetByFilter(string commandText, Dictionary<string, object> parameters)
        {
            DataTable dt = sqlDao.GetByFilter(commandText, parameters);
            List<Movie> lst = new List<Movie>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Movie m = new Movie();
                m.Id = Convert.ToInt32(dt.Rows[i][0]);
                m.Title = dt.Rows[i][1].ToString();
                m.Date = Convert.ToDateTime(dt.Rows[i][2]);
                m.Rating = Convert.ToInt32(dt.Rows[i][3]);
                //m.IdGender = Convert.ToInt32(dt.Rows[i][4]);
                m.ImgUrl = dt.Rows[i][4].ToString();
                lst.Add(m);
            }
            return lst;
        }

        public IEnumerable<Movie> GetByFilter(string commandText, string param, object value)
        {
            DataTable dt = sqlDao.GetByFilter(commandText,param,value);
            List<Movie> lst = new List<Movie>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Movie m = new Movie();
                m.Id = Convert.ToInt32(dt.Rows[i][0]);
                m.Title = dt.Rows[i][1].ToString();
                m.ImgUrl = dt.Rows[i][2].ToString();
                lst.Add(m);
            }
            return lst;
        }

        public bool Create(Movie movie) 
        {
            SqlTransaction transact = null;
            bool flag = false;
            try
            {
                sqlDao.OpenConn();

                transact = sqlDao.Conn.BeginTransaction(); 
                sqlDao.Command = sqlDao.Conn.CreateCommand();
                sqlDao.Command.CommandType = CommandType.StoredProcedure;
                sqlDao.Command.CommandText = "sp_createMovie";
                sqlDao.Command.Transaction = transact;

                sqlDao.Command.Parameters.AddWithValue("@title", movie.Title);
                sqlDao.Command.Parameters.AddWithValue("@date", movie.Date);
                sqlDao.Command.Parameters.AddWithValue("@rating", movie.Rating);
                sqlDao.Command.Parameters.AddWithValue("@url", movie.ImgUrl);

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@idMovie";
                param.SqlDbType = SqlDbType.Int;
                param.Direction = ParameterDirection.Output;
                sqlDao.Command.Parameters.Add(param);

                sqlDao.Command.ExecuteNonQuery();

                int idMovie = (int)param.Value;

                movie.Id = idMovie;

               // ------insert Characters------ -
                foreach (Character c in movie.Characters)
                {
                    sqlDao.Command.Parameters.Clear();
                    sqlDao.Command.CommandText = "sp_addCharactersToMovie";
                    sqlDao.Command.CommandType = CommandType.StoredProcedure;
                    sqlDao.Command.Transaction = transact;
                    sqlDao.Command.Parameters.AddWithValue("@idMovie", movie.Id);
                    sqlDao.Command.Parameters.AddWithValue("@idCharacter", c.Id);
                    sqlDao.Command.ExecuteNonQuery();
                }
                // ------insert Genders------ -
                foreach (Gender g in movie.Genders)
                {
                    sqlDao.Command.Parameters.Clear();
                    sqlDao.Command.CommandText = "sp_addMovieGenders";
                    sqlDao.Command.CommandType = CommandType.StoredProcedure;
                    sqlDao.Command.Transaction = transact;
                    sqlDao.Command.Parameters.AddWithValue("@idMovie", movie.Id);
                    sqlDao.Command.Parameters.AddWithValue("@idGender", g.Id);
                    sqlDao.Command.ExecuteNonQuery();
                }
                transact.Commit();
                flag = true;
                return flag;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlDao.CloseConn();
            }
        }

        public void update(int id, Movie objectToUpdate)
        {
            try
            {
                sqlDao.OpenConn();
                sqlDao.Command = sqlDao.Conn.CreateCommand();
                sqlDao.Command.CommandType = CommandType.StoredProcedure;
                sqlDao.Command.CommandText = "sp_UpdateMovie";
                sqlDao.Command.Parameters.AddWithValue("@idMovie", id);
                sqlDao.Command.Parameters.AddWithValue("@title", objectToUpdate.Title);
                sqlDao.Command.Parameters.AddWithValue("@date", objectToUpdate.Date);
                sqlDao.Command.Parameters.AddWithValue("@rating", objectToUpdate.Rating);
                sqlDao.Command.Parameters.AddWithValue("@url", objectToUpdate.ImgUrl);
                sqlDao.Command.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlDao.CloseConn();
            }
        }

        public void Delete(int id)
        {
            try
            {
                sqlDao.OpenConn();
                sqlDao.Command = sqlDao.Conn.CreateCommand();
                sqlDao.Command.CommandType = CommandType.StoredProcedure;
                sqlDao.Command.CommandText = "sp_DeleteMovie";
                sqlDao.Command.Parameters.AddWithValue("@id", id);
                sqlDao.Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex; 
            }
            finally { sqlDao.CloseConn(); }
        }

        public void update(Movie objectToUpdate)
        {
            try
            {
                sqlDao.OpenConn();
                sqlDao.Command = sqlDao.Conn.CreateCommand();
                sqlDao.Command.CommandType = CommandType.StoredProcedure;
                sqlDao.Command.CommandText = "sp_UpdateMovie";
                sqlDao.Command.Parameters.AddWithValue("@idMovie", objectToUpdate.Id);
                sqlDao.Command.Parameters.AddWithValue("@title", objectToUpdate.Title);
                sqlDao.Command.Parameters.AddWithValue("@date", objectToUpdate.Date);
                sqlDao.Command.Parameters.AddWithValue("@rating", objectToUpdate.Rating);
                sqlDao.Command.Parameters.AddWithValue("@url", objectToUpdate.ImgUrl);
                //sqlDao.Command.Parameters.AddWithValue("@gender", objectToUpdate.IdGender);
                sqlDao.Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlDao.CloseConn();
            }
        }
    }
}
