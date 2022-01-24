using DisneyAPI.Entities;
using System;
using System.Collections.Generic;
using System.Data;

namespace DisneyAPI.Data
{
    public class GenderDao : IDao<Gender>
    {
        private SqlRepo sqlDao;

        public GenderDao()
        {
            sqlDao = SqlRepo.GetDao();
        }

        public bool Create(Gender objectToCreate)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Gender> GetAll(string commandText)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Gender> GetByFilter(string commandText, string param, object value)
        {
            DataTable dt = sqlDao.GetByFilter(commandText, param, value);
            List<Gender> lst = new List<Gender>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Gender g = new Gender();
                g.Id = Convert.ToInt32(dt.Rows[i][0]);
                g.Name = dt.Rows[i][1].ToString();
                lst.Add(g);
            }
            return lst;
        }

        public IEnumerable<Gender> GetByFilter(string commandText, Dictionary<string, object> parameters)
        {
            throw new NotImplementedException();
        }

        public void update(int id, Gender objectToUpdate)
        {
            throw new NotImplementedException();
        }

        public void update(Gender objectToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
