using DisneyAPI.Abstract_Factory;
using DisneyAPI.Data;
using DisneyAPI.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DisneyAPI.Services
{
    public class GendersService : IApp<Gender>
    {
        public IDao<Gender> GenderDao { get; set; }

        public GendersService(AbstractFactory factory)
        {
            GenderDao = factory.CreateGenderDao();
        }

        public async Task<IEnumerable<Gender>> GetByMovieIdAsync(object value)
        {
            return await GenderDao.GetByFilterAsync("SP_getMovieGenders", "@idMovie", value); 
        }
        public Task<bool> CreateAsync(Gender entity)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(object id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Gender>> FilterAsync(Dictionary<string, object> parameters)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Gender>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Gender>> GetByValueAsync(string key, object value)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateAsync(Gender entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
