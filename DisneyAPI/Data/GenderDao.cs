using DisneyAPI.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DisneyAPI.Data
{
    public class GenderDao : IDao<Gender>
    {
        private SqlRepo sqlDao;
        List<Gender> genders;

    public GenderDao()
    {
        sqlDao = SqlRepo.GetDao();
        genders = new List<Gender>();
    }

        public Task<bool> CreateAsync(string commandText, Dictionary<string, object> parameters)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateAsync(SqlTransaction transc, string commandText, Dictionary<string, object> parameters)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateAsync(Gender entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateAsync(SqlTransaction transc)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(string CommandText, object id)
        {
            throw new NotImplementedException();
        }

        async public Task<IEnumerable<Gender>> GetAllAsync(string commandText)
        {
            var data = await sqlDao.GetAllAsync(commandText);
            foreach (DataRow row in data) 
            {
                genders.Add(new Gender(Convert.ToInt32(row[0]),row[1].ToString())); 
            }
            return genders; 
        }

        public Task<IEnumerable<Gender>> GetByFilterAsync(string commandText, Dictionary<string, object> parameters)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Gender>> GetByFilterAsync(string commandText, string param, object value)
        {
            var data = await sqlDao.GetByFilterAsync(commandText, param, value);
            foreach (DataRow row in data)
            {
                genders.Add(new Gender(Convert.ToInt32(row[0]), row[1].ToString()));
            }
            return genders;
        }

        public Task<bool> UpdateAsync(string commandText, Dictionary<string, object> parameters)
        {
            throw new NotImplementedException();
        }

        //    public bool Create(Gender objectToCreate)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public void Delete(int id)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public IEnumerable<Gender> GetAll(string commandText)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public IEnumerable<Gender> GetByFilter(string commandText, string param, object value)
        //    {
        //        DataTable dt = sqlDao.GetByFilter(commandText, param, value);
        //        List<Gender> lst = new List<Gender>();
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            Gender g = new Gender();
        //            g.Id = Convert.ToInt32(dt.Rows[i][0]);
        //            g.Name = dt.Rows[i][1].ToString();
        //            lst.Add(g);
        //        }
        //        return lst;
        //    }

        //    public IEnumerable<Gender> GetByFilter(string commandText, Dictionary<string, object> parameters)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public void update(int id, Gender objectToUpdate)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public void update(Gender objectToUpdate)
        //    {
        //        throw new NotImplementedException();
        //    }
    }
}
