using DisneyAPI.Abstract_Factory;
using DisneyAPI.Data;
using DisneyAPI.Entities;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DisneyAPI.Services
{
    public class CharactersService : IApp<Character>
    {
        public IDao<Character> CharacterDao { get; set; }

        public CharactersService(AbstractFactory factory)
        {
            CharacterDao = factory.CreateCharacterDao();
        }

        public async Task<IEnumerable<Character>> GetAllAsync()
        {
           return await CharacterDao.GetAllAsync("SP_GetCharacters");
        }

        public async Task<IEnumerable<Character>> FilterAsync(Dictionary<string, object> parameters)
        {
            return await CharacterDao.GetByFilterAsync("SP_FilterCharacter", parameters);
        }

        public async Task<IEnumerable<Character>> GetByValueAsync(string key,object value)
        {
            return await CharacterDao.GetByFilterAsync("SP_FilterCharacter",key,value); 
        }

        public async Task<IEnumerable<Character>> GetByMovieIdAsync(object value)
        {
            return await CharacterDao.GetByFilterAsync("SP_CharactersByMovie", "@idMovie", value);
        }

        public async Task<bool> CreateAsync(Character character)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("name", character.Name);
            parameters.Add("age", character.Age);
            parameters.Add("weight", character.Weight);
            parameters.Add("story", character.Story);
            parameters.Add("imgUrl", character.ImgUrl);
            return await CharacterDao.CreateAsync("sp_createCharacter",parameters); 
        }

        public async Task<bool> UpdateAsync(Character character)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("id",character.Id);
            parameters.Add("name", character.Name);
            parameters.Add("age", character.Age);
            parameters.Add("weight", character.Weight);
            parameters.Add("story", character.Story);
            parameters.Add("imgUrl", character.ImgUrl);
            return await CharacterDao.UpdateAsync("sp_UpdateCharacter", parameters); 
        }

        public async Task DeleteAsync(object id)
        {
           await CharacterDao.DeleteAsync("sp_DeleteCharacter", id); 
        }

        //public Task<IEnumerable<Character>> ListAllCharactersAsync() 
        //{
        //    IEnumerable<Character> lst = CharacterDao.GetAllAsync("SP_GetCharacters");
        //    return lst;
        //}

        //public Task<IEnumerable<Character>> FilterCharacterAsync(Dictionary<string, object> parameters)
        //{
        //    IEnumerable<Character> lst = CharacterDao.GetByFilterAsync("SP_FilterCharacter", parameters);
        //    return lst;
        //}

        //public Task<IEnumerable<Movie>> ListAllMoviesAsync()
        //{
        //    IEnumerable<Movie> lst = MovieDao.GetAllAsync("SP_GetMovies");
        //    return lst; 
        //}

        //public Task<IEnumerable<Movie>> GetMoviesByCharacterAsync(object value)
        //{
        //    IEnumerable<Movie> lst = MovieDao.GetByFilterAsync("SP_MoviesByCharacter","@id",value);
        //    return lst;
        //}

        //public Task<IEnumerable<Character>> GetCharactersByMovieAsync(object value)
        //{
        //    IEnumerable<Character> lst = CharacterDao.GetByFilterAsync("SP_CharactersByMovie", "@idMovie", value);
        //    return lst;
        //}

        //public Task<IEnumerable<Movie>> FilterMoviesAsync(Dictionary<string, object> parameters)
        //{
        //    IEnumerable<Movie> lst = MovieDao.GetByFilterAsync("SP_FilterMovies", parameters);
        //    return lst;
        //}

        //public Task<bool> CreateMovieAsync(Movie movie) 
        //{
        //   await MovieDao.CreateAsync(movie); 
        //}

        //public Task UpdateMovieAsync(int id, Movie movie)
        //{
        //    MovieDao.update(id, movie);
        //}

        //public Task DeleteMovieAsync(int id)
        //{
        //    MovieDao.DeleteAsync(id);
        //}

        //public Task CreateCharacterAsync(Character character)
        //{
        //    return CharacterDao.CreateAsync(character);
        //}

        //public Task UpdateCharacterAsync(Character c)
        //{
        //    CharacterDao.updateAsync(c); 
        //}

        //public Task DeleteCharacterAsync(int id)
        //{
        //    CharacterDao.DeleteAsync(id);
        //}

        //public Task<IEnumerable<Gender>> GetMovieGendersAsync(object value)
        //{
        //    IEnumerable<Gender> lst = GenderDao.GetByFilterAsync("SP_getMovieGenders", "@idMovie", value);
        //    return lst;
        //}
    }
}
