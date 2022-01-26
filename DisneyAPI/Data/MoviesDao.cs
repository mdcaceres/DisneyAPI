using DisneyAPI.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DisneyAPI.Data
{
    public class MoviesDao : IDao<Movie>
    {
        private SqlRepo sqlDao;
        private List<Movie> lst;
        SqlTransaction transact = null;
        public MoviesDao()
        {
            sqlDao = SqlRepo.GetDao();
            lst = new List<Movie>();
        }

        public async Task CreateCharactersAndGenders(int id,List<Character> characters, List<Gender> genders, SqlTransaction transact) 
        {
            foreach (Character c in characters)
            {
                sqlDao.Command.Parameters.Clear();
                sqlDao.Command.CommandText = "sp_addCharactersToMovie";
                sqlDao.Command.CommandType = CommandType.StoredProcedure;
                sqlDao.Command.Transaction = transact;
                sqlDao.Command.Parameters.AddWithValue("@idMovie", id);
                sqlDao.Command.Parameters.AddWithValue("@idCharacter", c.Id);
                await sqlDao.Command.ExecuteNonQueryAsync();
            }
            foreach (Gender g in genders)
            {
                sqlDao.Command.Parameters.Clear();
                sqlDao.Command.CommandText = "sp_addMovieGenders";
                sqlDao.Command.CommandType = CommandType.StoredProcedure;
                sqlDao.Command.Transaction = transact;
                sqlDao.Command.Parameters.AddWithValue("@idMovie", id);
                sqlDao.Command.Parameters.AddWithValue("@idGender", g.Id);
                await sqlDao.Command.ExecuteNonQueryAsync();
            }
        }

        public async Task<bool> CreateAsync(Movie entity)
        {
            SqlTransaction transact = null;
            bool flag = false;
            try
            {
                sqlDao.Conn.Open();
                transact = sqlDao.Conn.BeginTransaction();
                sqlDao.Command = sqlDao.Conn.CreateCommand();
                sqlDao.Command.CommandType = CommandType.StoredProcedure;
                sqlDao.Command.CommandText = "sp_createMovie";
                sqlDao.Command.Transaction = transact;

                sqlDao.Command.Parameters.AddWithValue("@title", entity.Title);
                sqlDao.Command.Parameters.AddWithValue("@date", entity.Date);
                sqlDao.Command.Parameters.AddWithValue("@rating", entity.Rating);
                sqlDao.Command.Parameters.AddWithValue("@url", entity.ImgUrl);


                SqlParameter param = new SqlParameter();
                param.ParameterName = "@idMovie";
                param.SqlDbType = SqlDbType.Int;
                param.Direction = ParameterDirection.Output;
                sqlDao.Command.Parameters.Add(param);
                await sqlDao.Command.ExecuteNonQueryAsync();
                int idMovie = (int)param.Value;

                await CreateCharactersAndGenders(idMovie, entity.Characters, entity.Genders, transact); 
                if(await sqlDao.CreateWithTransactAsync(transact)) flag = true; 
                return flag;
            }
            catch (Exception ex) { throw ex;}
        }

        public async Task<bool> CreateAsync(string commandText, Dictionary<string, object> parameters)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(string CommandText, object id)
        {
            return await sqlDao.DeleteAsync(CommandText, id);
        }

        public async Task<IEnumerable<Movie>> GetAllAsync(string commandText)
        {
            var data = await sqlDao.GetAllAsync(commandText);
            foreach (DataRow dt in data) 
            {
                Movie movie = new Movie();
                movie.Id = Convert.ToInt32(dt[0]); 
                movie.Title = dt[1].ToString();
                movie.Date = Convert.ToDateTime(dt[2]);
                movie.Rating = Convert.ToInt32(dt[3]);
                movie.ImgUrl = dt[4].ToString();
                lst.Add(movie);
            }
            return lst;
        }

        public async Task<IEnumerable<Movie>> GetByFilterAsync(string commandText, Dictionary<string, object> parameters)
        {
            var data = await sqlDao.GetByFilterAsync(commandText,parameters);
            foreach (DataRow dt in data)
            {
                Movie movie = new Movie();
                movie.Id = Convert.ToInt32(dt[0]);
                movie.Title = dt[1].ToString();
                movie.Date = Convert.ToDateTime(dt[2]);
                movie.Rating = Convert.ToInt32(dt[3]);
                movie.ImgUrl = dt[4].ToString();
                lst.Add(movie);
            }
            return lst;
        }

        public async Task<IEnumerable<Movie>> GetByFilterAsync(string commandText, string param, object value)
        {
            var data = await sqlDao.GetByFilterAsync(commandText, param, value);
            foreach (DataRow dt in data)
            {
                Movie movie = new Movie();
                movie.Id = Convert.ToInt32(dt[0]);
                movie.Title = dt[1].ToString();
                movie.Rating = Convert.ToInt32(dt[2]);
                movie.Date = Convert.ToDateTime(dt[3]);
                movie.ImgUrl = dt[4].ToString();
                lst.Add(movie);
            }
            return lst;
        }

        public async Task<bool> UpdateAsync(string commandText, Dictionary<string, object> parameters)
        {
            return await sqlDao.UpdateAsync(commandText, parameters);
        }
    }
}
