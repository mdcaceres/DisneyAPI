using DisneyAPI.Data;
using DisneyAPI.Entities;

namespace DisneyAPI.Abstract_Factory
{
    public abstract class AbstractFactory
    {
        public abstract IDao<Character> CreateCharacterDao();
        public abstract IDao<Movie> CreateMovieDao();
        public abstract IDao<Gender> CreateGenderDao();
    }
}
