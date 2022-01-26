using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Transactions;

namespace DisneyAPI.Data
{
    public interface IDao<T>
    {
        public Task<IEnumerable<T>> GetAllAsync(string commandText);
        public Task<IEnumerable<T>> GetByFilterAsync(string commandText, Dictionary<string, Object> parameters);
        public Task<IEnumerable<T>> GetByFilterAsync(string commandText, string param, object value);
        public Task<bool> CreateAsync(string commandText,Dictionary<string, object> parameters);
        public Task<bool> CreateAsync(T entity);
        //public Task<bool> CreateAsync(SqlTransaction transc);

        public Task<bool> UpdateAsync(string commandText, Dictionary<string, object> parameters);
        //Task updateAsync(T objectToUpdate);
        Task<bool> DeleteAsync(string CommandText, object id);
    }
}
