using DisneyAPI.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DisneyAPI.Data
{
    public class CharacterDao : IDao<Character>
    {
        private SqlRepo sqlDao;
        private List<Character> lst;

        public CharacterDao()
        {
            sqlDao = SqlRepo.GetDao();
            lst = new List<Character>();
        }

        async public Task<bool> CreateAsync(string command, Dictionary<string, object> parameters)
        {
            return await sqlDao.CreateAsync(command,parameters);
        }

        public Task<bool> CreateAsync(SqlTransaction transc, string commandText, Dictionary<string, object> parameters)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateAsync(Character entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateAsync(SqlTransaction transc)
        {
            throw new NotImplementedException();
        }

        async public Task<bool> DeleteAsync(string CommandText, object id)
        {
            return await sqlDao.DeleteAsync(CommandText, id);
        }

        async public Task<IEnumerable<Character>> GetAllAsync(string commandText)
        {
            var data = await sqlDao.GetAllAsync(commandText);

            foreach (DataRow dt in data) 
            {
                Character character = new Character();
                character.Id = Convert.ToInt32(dt[0]);
                character.Name = dt[1].ToString();
                character.Age = Convert.ToInt32(dt[2]);
                character.Weight = Convert.ToInt32(dt[3]);
                character.Story = dt[4].ToString();
                character.ImgUrl = dt[5].ToString();
                lst.Add(character);
            }    
            return lst;
        }

        async public Task<IEnumerable<Character>> GetByFilterAsync(string commandText, Dictionary<string, object> parameters)
        {
            var data = await sqlDao.GetByFilterAsync(commandText, parameters);
            foreach (DataRow dt in data)
            {
                Character character = new Character();
                character.Id = Convert.ToInt32(dt[0]);
                character.Name = dt[1].ToString();
                character.Age = Convert.ToInt32(dt[2]);
                character.Weight = Convert.ToInt32(dt[3]);
                character.Story = dt[4].ToString();
                character.ImgUrl = dt[5].ToString();
                lst.Add(character);
            }
            return lst;
        }

        async public Task<IEnumerable<Character>> GetByFilterAsync(string commandText, string param, object value)
        {
            var data = await sqlDao.GetByFilterAsync(commandText, param, value);
            foreach (DataRow dt in data)
            {
                Character character = new Character();
                character.Id = Convert.ToInt32(dt[0]);
                character.Name = dt[1].ToString();
                character.Age = Convert.ToInt32(dt[2]);
                character.Weight = Convert.ToInt32(dt[3]);
                character.Story = dt[4].ToString();
                character.ImgUrl = dt[5].ToString();
                lst.Add(character);
            }
            return lst;
        }

        async public Task<bool> UpdateAsync(string commandText, Dictionary<string, object> parameters)
        {
            return await sqlDao.UpdateAsync(commandText, parameters);
        }
    }
}
