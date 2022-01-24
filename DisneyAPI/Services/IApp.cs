using DisneyAPI.Entities;
using System.Collections.Generic;

namespace DisneyAPI.Services
{
    public interface IApp
    {
        IEnumerable<Character> ListAllCharacters();
        IEnumerable<Character> FilterCharacter(Dictionary<string, object> parameters);
        IEnumerable<Character> GetCharactersByMovie(object value);
        IEnumerable<Movie> ListAllMovies();
        IEnumerable<Movie> FilterMovies(Dictionary<string, object> parameters);
        IEnumerable<Movie> GetMoviesByCharacter(object value);
        IEnumerable<Gender> GetMovieGenders(object value); 
        bool CreateMovie(Movie movie); 
        bool CreateCharacter(Character character);
        void UpdateMovie(int id,Movie movie);
        void UpdateCharacter(Character c);
        void DeleteMovie(int id);
        void DeleteCharacter(int id);

    }
}
