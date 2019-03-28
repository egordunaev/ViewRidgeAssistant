using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRA.DataAccess.Entities;
using System.Data.SqlClient;
using System.Configuration;

namespace VRA.DataAccess
{
    public class WorkDao :IWorkDao
    {
        /// <summary>
        /// Получить определенную работу
        /// </summary>
        /// <param name="id">Номер работы</param>
        /// <returns></returns>
        public Work Get(int id)
        {
            //Получаем объект подключения к базе
            using (var conn = GetConnection())
            {
                //Открываем соединение
                conn.Open();
                //Создаем sql команду
                using (var cmd = conn.CreateCommand())
                {
                    //Задаём текст команды
                    cmd.CommandText = "SELECT WorkID, Title, Copy, Description, ArtistID FROM WORK WHERE WorkID = @id";
                    //Добавляем значение параметра
                    cmd.Parameters.AddWithValue("@id", id);
                    //Открываем SqlDataReader для чтения полученных в результате
                    //выполнения запроса данных
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        //Если есть запись, то работаем с ней
                        if (dataReader.Read())
                        {
                            return !dataReader.Read() ? null : LoadWork(dataReader);
                        }
                        return null;
                    }
                }
            }
        }
        /// <summary>
        /// Получить все работы
        /// </summary>
        /// <returns></returns>
        public IList<Work> GetAll()
        {
            IList<Work> works = new List<Work>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT WorkID, Title, Copy, Description, ArtistID FROM WORK";
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            works.Add(LoadWork(dataReader));
                        }
                    }
                }
            }
            return works;

        }
        /// <summary>
        /// Добавить новую работу
        /// </summary>
        /// <param name="work">Работа</param>
        public void Add(Work work)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO WORK(Title, Copy, Description, ArtistID)VALUES(@Title, @Copy, @Description, @ArtistID)";
                    cmd.Parameters.AddWithValue("@Title", work.Title);
                    cmd.Parameters.AddWithValue("@Copy", work.Copy);
                    cmd.Parameters.AddWithValue("@Description", work.Description);
                    cmd.Parameters.AddWithValue("@ArtistID", work.ArtistID);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// Обновить информацию о работе
        /// </summary>
        /// <param name="work">Работа</param>
        public void Update(Work work)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE WORK SET Title=@Title, Copy=@Copy, Description=@Description, ArtistID=@ArtistID WHERE WorkID = @ID";
                    cmd.Parameters.AddWithValue("@ID", work.WorkID);
                    cmd.Parameters.AddWithValue("@Title", work.Title);
                    cmd.Parameters.AddWithValue("@Copy", work.Copy);
                    cmd.Parameters.AddWithValue("@Description", work.Description);
                    cmd.Parameters.AddWithValue("@ArtistID", work.ArtistID);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// Удалить работу
        /// </summary>
        /// <param name="id">Номер работы</param>
        public void Delete(int id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM WORK WHERE WorkID = @ID";
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// Возвращает строку подключения к базе
        /// </summary>
        /// <returns></returns>
        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["vradb"].ConnectionString;
        }
        /// <summary>
        /// Возвращает объект подключения к базе
        /// </summary>
        /// <returns></returns>
        private static SqlConnection GetConnection()
        {
            return new SqlConnection(GetConnectionString());
        }
        /// <summary>
        /// Загрузка работы
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static Work LoadWork(SqlDataReader reader)
        {
            //Создаём пустой объект
            Work work = new Work();
            //Заполняем поля объекта в соответствии с названиями полей результирующего
            // набора данных
            work.WorkID = reader.GetInt32(reader.GetOrdinal("WorkID"));
            work.ArtistID = reader.GetInt32(reader.GetOrdinal("ArtistID"));
            work.Title = reader.GetString(reader.GetOrdinal("Title"));
            work.Copy = reader.GetString(reader.GetOrdinal("Copy"));
            work.Description = reader.GetString(reader.GetOrdinal("Description"));
            
            return work;
        }
    }
}
