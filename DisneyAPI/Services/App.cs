using DisneyAPI.Abstract_Factory;
using DisneyAPI.Data;
using DisneyAPI.Entities;
using System.Collections.Generic;
using System.Data;

namespace DisneyAPI.Services
{
    public class App : IApp
    {
        public IDao<Character> CharacterDao { get; set; }
        public IDao<Movie> MovieDao { get; set; }
        public IDao<Gender> GenderDao { get; set; }

        public App(AbstractFactory factory)
        {
            CharacterDao = factory.CreateCharacterDao();
            MovieDao = factory.CreateMovieDao();
            GenderDao = factory.CreateGenderDao();
        }

        public IEnumerable<Character> ListAllCharacters() 
        {
            IEnumerable<Character> lst = CharacterDao.GetAll("SP_GetCharacters");
            return lst;
        }

        public IEnumerable<Character> FilterCharacter(Dictionary<string, object> parameters)
        {
            IEnumerable<Character> lst = CharacterDao.GetByFilter("SP_FilterCharacter", parameters);
            return lst;
        }

        public IEnumerable<Movie> ListAllMovies()
        {
            IEnumerable<Movie> lst = MovieDao.GetAll("SP_GetMovies");
            return lst; 
        }

        public IEnumerable<Movie> GetMoviesByCharacter(object value)
        {
            IEnumerable<Movie> lst = MovieDao.GetByFilter("SP_MoviesByCharacter","@id",value);
            return lst;
        }

        public IEnumerable<Character> GetCharactersByMovie(object value)
        {
            IEnumerable<Character> lst = CharacterDao.GetByFilter("SP_CharactersByMovie", "@idMovie", value);
            return lst;
        }

        public IEnumerable<Movie> FilterMovies(Dictionary<string, object> parameters)
        {
            IEnumerable<Movie> lst = MovieDao.GetByFilter("SP_FilterMovies", parameters);
            return lst;
        }

        public bool CreateMovie(Movie movie) 
        {
            return MovieDao.Create(movie); 
        }

        public void UpdateMovie(int id, Movie movie)
        {
            MovieDao.update(id, movie);
        }

        public void DeleteMovie(int id)
        {
            MovieDao.Delete(id);
        }

        public bool CreateCharacter(Character character)
        {
            return CharacterDao.Create(character);
        }

        public void UpdateCharacter(Character c)
        {
            CharacterDao.update(c); 
        }

        public void DeleteCharacter(int id)
        {
            CharacterDao.Delete(id);
        }

        public IEnumerable<Gender> GetMovieGenders(object value)
        {
            IEnumerable<Gender> lst = GenderDao.GetByFilter("SP_getMovieGenders", "@idMovie", value);
            return lst;
        }
    }
}
