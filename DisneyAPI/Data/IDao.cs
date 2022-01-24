using System;
using System.Collections.Generic;

namespace DisneyAPI.Data
{
    public interface IDao<T>
    {
        IEnumerable<T> GetAll(string commandText);
        IEnumerable<T> GetByFilter(string commandText, Dictionary<string, Object> parameters);
        IEnumerable<T> GetByFilter(string commandText, string param, object value);
        bool Create(T objectToCreate); 
        void update(int id,T objectToUpdate);
        void update(T objectToUpdate);
        void Delete(int id);
    }
}
