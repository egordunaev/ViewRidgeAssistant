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
    public class CustomerArtistIntDao : ICustomerArtistIntDao
    {
        /// <summary>
        /// Получить id клиента и художника
        /// </summary>
        /// <param name="ArtistID">Artist id</param>
        /// <returns></returns>
        public CustomerArtistInt Get(int ArtistID, int CustomerID)
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
                    cmd.CommandText = "SELECT CustomerID, ArtistID FROM CUSTOMER_ARTIST_INT WHERE ArtistID = @ArtistID AND CustomerID=@CustomerID";
                    //Добавляем значение параметра
                    cmd.Parameters.AddWithValue("@ArtistID", ArtistID);
                    cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
                    //Открываем SqlDataReader для чтения полученных в результате
                    //выполнения запроса данных
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        //Если есть запись, то работаем с ней
                        if (dataReader.Read())
                        {
                            return !dataReader.Read() ? null : LoadCustomerArtistInt(dataReader);
                        }
                        return null;
                    }
                }
            }
        }
        /// <summary>
        /// Получить все id.
        /// </summary>
        /// <returns></returns>
        public IList<CustomerArtistInt> GetAll()
        {
            IList<CustomerArtistInt> customerArtistInts = new List<CustomerArtistInt>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT CustomerID, ArtistID FROM CUSTOMER_ARTIST_INT";
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            customerArtistInts.Add(LoadCustomerArtistInt(dataReader));
                        }
                    }
                }
            }
            return customerArtistInts;

        }
        /// <summary>
        /// Добавить новый id
        /// </summary>
        /// <param name="customerArtistInt">id</param>
        public void Add(CustomerArtistInt customerArtistInt)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO CUSTOMER_ARTIST_INT(CustomerID,ArtistID)VALUES(@CustomerID, @ArtistID)";
                    cmd.Parameters.AddWithValue("@CustomerID", customerArtistInt.CustomerID);
                    cmd.Parameters.AddWithValue("@ArtistID", customerArtistInt.ArtistID);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// Обновить информацию о id
        /// </summary>
        /// <param name="customerArtistInt">id</param>
        public void Update(CustomerArtistInt customerArtistInt)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE CUSTOMER_ARTIST_INT SET CustomerID = @CustomerID,ArtistID=@ArtistID WHERE ArtistID = @ID";
                    cmd.Parameters.AddWithValue("@CustomerID", customerArtistInt.CustomerID);
                    cmd.Parameters.AddWithValue("@ArtistID", customerArtistInt.ArtistID);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// Удалить id
        /// </summary>
        /// <param name="ArtistID">Artist id</param>
        /// <param name="CustomerID">Customer id</param>
        public void Delete(int ArtistID, int CustomerID)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM CUSTOMER_ARTIST_INT WHERE ArtistID = @ArtistID AND CustomerID=@CustomerID";
                    cmd.Parameters.AddWithValue("@ArtistID", ArtistID);
                    cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
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
        /// Загрузка id 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static CustomerArtistInt LoadCustomerArtistInt(SqlDataReader reader)
        {
            //Создаём пустой объект
            CustomerArtistInt customerArtistInt = new CustomerArtistInt();
            //Заполняем поля объекта в соответствии с названиями полей результирующего
            // набора данных
            customerArtistInt.ArtistID = reader.GetInt32(reader.GetOrdinal("ArtistID"));
            customerArtistInt.CustomerID = reader.GetInt32(reader.GetOrdinal("CustomerID"));
            return customerArtistInt;
        }
    }
}
