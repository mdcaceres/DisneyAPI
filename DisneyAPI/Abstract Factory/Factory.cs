using DisneyAPI.Data;
using DisneyAPI.Entities;

namespace DisneyAPI.Abstract_Factory
{
    public class Factory : AbstractFactory
    {
        public override IDao<Character> CreateCharacterDao()
        {
            return new CharacterDao();
        }

        public override IDao<Movie> CreateMovieDao()
        {
            return new MoviesDao();
        }

        public override IDao<Gender> CreateGenderDao()
        {
            return new GenderDao();
        }
    }
}
