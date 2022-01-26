using DisneyAPI.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DisneyAPI.Services
{
    public interface IApp<T>
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<IEnumerable<T>> FilterAsync(Dictionary<string, object> parameters);
        public Task<IEnumerable<T>> GetByValueAsync(string key,object value);
        //public Task<IEnumerable<Movie>> ListAllMoviesAsync();
        //public Task<IEnumerable<Movie>> FilterMoviesAsync(Dictionary<string, object> parameters);
        //public Task<IEnumerable<Movie>> GetMoviesByCharacterAsync(object value);
        //public Task<IEnumerable<Gender>> GetMovieGendersAsync(object value); 
        //public Task<bool> CreateMovieAsync(Movie movie); 
        public Task<bool> CreateAsync(T entity);
        //public Task UpdateMovieAsync(int id,Movie movie);
        public Task<bool> UpdateAsync(T entity);
        //public Task DeleteMovieAsync(int id);
        public Task DeleteAsync(object id);

    }
}
