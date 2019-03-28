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
    public class TransDao : ITransDao
    {
        /// <summary>
        /// Получить определенного художника
        /// </summary>
        /// <param name="id">Номер художника</param>
        /// <returns></returns>
        public Trans Get(int id)
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
                    cmd.CommandText = "SELECT TransactionID, DateAcquired, AcquisitionPrice,PurchaseDate,SalesPrice,AskingPrice,CustomerID,WorkID FROM TRANS WHERE TransactionID = @id";
                    //Добавляем значение параметра
                    cmd.Parameters.AddWithValue("@id", id);
                    //Открываем SqlDataReader для чтения полученных в результате
                    //выполнения запроса данных
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        //Если есть запись, то работаем с ней
                        if (dataReader.Read())
                        {
                            return !dataReader.Read() ? null : LoadTrans(dataReader);
                        }
                        return null;
                    }
                }
            }
        }
        /// <summary>
        /// Получить всех художников.
        /// </summary>
        /// <returns></returns>
        public IList<Trans> GetAll()
        {
            IList<Trans> trans = new List<Trans>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT TransactionID, DateAcquired, AcquisitionPrice,PurchaseDate,SalesPrice,AskingPrice, CustomerID,WorkID FROM TRANS";
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            trans.Add(LoadTrans(dataReader));
                        }
                    }
                }
            }
            return trans;

        }
        /// <summary>
        /// Добавить нового художника
        /// </summary>
        /// <param name="trans">Художник</param>
        public void Add(Trans trans)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO TRANS(TransactionID, DateAcquired, AcquisitionPrice,PurchaseDate,SalesPrice,AskingPrice,CustomerID,WorkID)VALUES(@TransactionID, @DateAcquired,  @AcquisitionPrice, @PurchaseDate, @SalesPrice, @AskingPrice, @CustomerID, @WorkID)";
                    cmd.Parameters.AddWithValue("@TransactionID", trans.TransactionID);
                    cmd.Parameters.AddWithValue("@DateAcquired", trans.DateAcquired);
                    cmd.Parameters.AddWithValue("@AcquisitionPrice", trans.AcquisitionPrice);
                    cmd.Parameters.AddWithValue("@PurchaseDate", trans.PurchaseDate);
                    cmd.Parameters.AddWithValue("@SalesPrice", trans.SalesPrice);
                    cmd.Parameters.AddWithValue("@AskingPrice", trans.AskingPrice);
                    cmd.Parameters.AddWithValue("@CustomerID", trans.CustomerID);
                    cmd.Parameters.AddWithValue("@WorkID", trans.WorkID);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// Обновить информацию о художнике
        /// </summary>
        /// <param name="trans">Художник</param>
        public void Update(Trans trans)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE TRANS SET  DateAcquired=@DateAcquired, AcquisitionPrice=@AcquisitionPrice,PurchaseDate=@PurchaseDate,SalesPrice=@SalesPrice,AskingPrice=@AskingPrice,CustomerID=@CustomerID,WorkID=@WorkID WHERE TransactionID = @ID";
                    cmd.Parameters.AddWithValue("@ID", trans.TransactionID);
                    cmd.Parameters.AddWithValue("@DateAcquired", trans.DateAcquired);
                    cmd.Parameters.AddWithValue("@AcquisitionPrice", trans.AcquisitionPrice);
                    cmd.Parameters.AddWithValue("@PurchaseDate", trans.PurchaseDate);
                    cmd.Parameters.AddWithValue("@SalesPrice", trans.SalesPrice);
                    cmd.Parameters.AddWithValue("@AskingPrice", trans.AskingPrice);
                    cmd.Parameters.AddWithValue("@CustomerID", trans.CustomerID);
                    cmd.Parameters.AddWithValue("@WorkID", trans.WorkID);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// Удалить художника
        /// </summary>
        /// <param name="id">Номер художника</param>
        public void Delete(int id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM TRANS WHERE TransactionID = @ID";
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
        /// Загрузка художника
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static Trans LoadTrans(SqlDataReader reader)
        {
            //Создаём пустой объект
            Trans trans = new Trans();
            //Заполняем поля объекта в соответствии с названиями полей результирующего
            // набора данных
            trans.TransactionID = reader.GetInt32(reader.GetOrdinal("TransactionID"));
            
                // добавить столбцы таблицы TRANS!!!
            /*artist.ArtistId = reader.GetInt32(reader.GetOrdinal("ArtistID"));
            artist.BirthYear = Convert.ToInt32(reader["BirthYear"]);
            
            object decease = reader["DeceaseYear"];
            if (decease != DBNull.Value)
                artist.DeceaseYear = Convert.ToInt32(decease);
            artist.Name = reader.GetString(reader.GetOrdinal("Name"));
            artist.Nationality = reader.GetString(reader.GetOrdinal("Nationality"));
            */
            return trans;
        }
    }
}
