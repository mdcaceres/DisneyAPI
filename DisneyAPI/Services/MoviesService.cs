using DisneyAPI.Abstract_Factory;
using DisneyAPI.Data;
using DisneyAPI.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DisneyAPI.Services
{
    public class MoviesService : IApp<Movie>
    {
        public IDao<Movie> MovieDao { get; set; }

        public MoviesService(AbstractFactory factory)
        {
            MovieDao = factory.CreateMovieDao();
        }

        public async Task<bool> CreateAsync(Movie entity)
        {
            return await MovieDao.CreateAsync(entity); 
        }

        public async Task DeleteAsync(object id)
        {
            await MovieDao.DeleteAsync("sp_DeleteMovie", id);
        }

        public async Task<IEnumerable<Movie>> FilterAsync(Dictionary<string, object> parameters)
        {
            return await MovieDao.GetByFilterAsync("SP_FilterMovies", parameters); 
        }

        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            return await MovieDao.GetAllAsync("SP_GetMovies"); 
        }

        public async Task<bool> UpdateAsync(Movie entity)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@idMovie", entity.Id);
            parameters.Add("@title", entity.Title);
            parameters.Add("@date", entity.Date);
            parameters.Add("@rating", entity.Rating);
            parameters.Add("@url", entity.ImgUrl);
            return await MovieDao.UpdateAsync("sp_UpdateMovie", parameters); 
        }


        public async Task<IEnumerable<Movie>> GetByCharacterIdAsync(object value)
        {
           return await MovieDao.GetByFilterAsync("SP_MoviesByCharacter", "@id", value); 
        }

        public Task<IEnumerable<Movie>> GetByValueAsync(string key, object value)
        {
            throw new System.NotImplementedException();
        }
    }
}
