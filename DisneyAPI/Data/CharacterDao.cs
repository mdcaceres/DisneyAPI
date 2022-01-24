using DisneyAPI.Entities;
using System;
using System.Collections.Generic;
using System.Data;

namespace DisneyAPI.Data
{
    public class CharacterDao : IDao<Character>
    {
        private SqlRepo sqlDao;

        public CharacterDao()
        {
            sqlDao = SqlRepo.GetDao();
        }
        public IEnumerable<Character> GetByFilter(string commandText, Dictionary<string, object> parameters)
        {
            DataTable dt = sqlDao.GetByFilter(commandText,parameters);
            List<Character> lst = new List<Character>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Character c = new Character();
                c.Id = Convert.ToInt32(dt.Rows[i][0]);
                c.Name = dt.Rows[i][1].ToString();
                c.Age = Convert.ToInt32(dt.Rows[i][2]);
                c.Weight = Convert.ToDecimal(dt.Rows[i][3]);
                c.Story = dt.Rows[i][4].ToString();
                c.ImgUrl = dt.Rows[i][5].ToString();

                lst.Add(c);
            }
            return lst;
        }

        public IEnumerable<Character> GetByFilter(string commandText, string param, object value)
        {
            DataTable dt = sqlDao.GetByFilter(commandText, param, value);
            List<Character> lst = new List<Character>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Character c = new Character();
                c.Id = Convert.ToInt32(dt.Rows[i][0]);
                c.Name = dt.Rows[i][1].ToString();
                c.Age = Convert.ToInt32(dt.Rows[i][2]);
                c.Weight = Convert.ToDecimal(dt.Rows[i][3]);
                c.Story = dt.Rows[i][4].ToString();
                c.ImgUrl = dt.Rows[i][5].ToString();

                lst.Add(c);
            }
            return lst;
        }

        public IEnumerable<Character> GetAll(string commandText)
        {
            DataTable dt = sqlDao.GetAll(commandText);
            List<Character> lst = new List<Character>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Character c = new Character();
                c.Id = Convert.ToInt32(dt.Rows[i][0]);
                c.Name = dt.Rows[i][1].ToString();
                c.Age = Convert.ToInt32(dt.Rows[i][2]);
                c.Weight = Convert.ToDecimal(dt.Rows[i][3]);
                c.Story = dt.Rows[i][4].ToString();
                c.ImgUrl = dt.Rows[i][5].ToString();
                lst.Add(c);
            }
            return lst;
        }

        public bool Create(Character character)
        {
            bool flag = false;
            try
            {
                sqlDao.OpenConn();

                sqlDao.Command = sqlDao.Conn.CreateCommand();
                sqlDao.Command.CommandType = CommandType.StoredProcedure;
                sqlDao.Command.CommandText = "sp_createCharacter";

                sqlDao.Command.Parameters.AddWithValue("@name", character.Name);
                sqlDao.Command.Parameters.AddWithValue("@age", character.Age);
                sqlDao.Command.Parameters.AddWithValue("@weight", character.Weight);
                sqlDao.Command.Parameters.AddWithValue("@story", character.Story);
                sqlDao.Command.Parameters.AddWithValue("@imgUrl", character.ImgUrl);

                int affRow = sqlDao.Command.ExecuteNonQuery();

                if (affRow > 0) { flag = true;}
                return flag;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlDao.CloseConn();
            }
        }

        public bool update(int id, Character objectToUpdate)
        {
            throw new NotImplementedException();
        }

        void IDao<Character>.update(int id, Character objectToUpdate)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            try
            {
                sqlDao.OpenConn();
                sqlDao.Command = sqlDao.Conn.CreateCommand();
                sqlDao.Command.CommandType = CommandType.StoredProcedure;
                sqlDao.Command.CommandText = "sp_DeleteCharacter";
                sqlDao.Command.Parameters.AddWithValue("@id", id);
                sqlDao.Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { sqlDao.CloseConn(); }
        }

        public void update(Character objectToUpdate)
        {
            try
            {
                sqlDao.OpenConn();
                sqlDao.Command = sqlDao.Conn.CreateCommand();
                sqlDao.Command.CommandType = CommandType.StoredProcedure;
                sqlDao.Command.CommandText = "sp_UpdateCharacter";
                sqlDao.Command.Parameters.AddWithValue("@id", objectToUpdate.Id);
                sqlDao.Command.Parameters.AddWithValue("@name", objectToUpdate.Name);
                sqlDao.Command.Parameters.AddWithValue("@age", objectToUpdate.Age);
                sqlDao.Command.Parameters.AddWithValue("@weight", objectToUpdate.Weight);
                sqlDao.Command.Parameters.AddWithValue("@story", objectToUpdate.Story);
                sqlDao.Command.Parameters.AddWithValue("@imgurl", objectToUpdate.ImgUrl);
                sqlDao.Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlDao.CloseConn();
            }
        }
    }
}
