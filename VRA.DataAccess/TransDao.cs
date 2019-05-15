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
    public class TransDao : BaseDao, ITransDao
    {
        private static IDictionary<int, Trans> Transactions;
        private IList<Trans> LoadInternal()
        {
            IList<Trans> transes = new List<Trans>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT DateAcquired, AcquisitionPrice,PurchaseDate,SalesPrice,AskingPrice, TransactionID,CustomerID,WorkID FROM TRANS";
                    cmd.CommandType = System.Data.CommandType.Text;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            transes.Add(LoadTrans(reader));
                        }
                    }
                }
            }
            return transes;
        }
        /// <summary>
        /// Получить определенную транзакцию
        /// </summary>
        /// <param name="id">Номер транзакции</param>
        /// <returns></returns>
        public Trans Get(int id)
        {
            if (Transactions == null)
                Load();
            return Transactions.ContainsKey(id) ? Transactions[id] : null;
        }
        /// <summary>
        /// Получить все транзакции
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
                    cmd.CommandText = "SELECT DateAcquired, AcquisitionPrice,PurchaseDate,SalesPrice,AskingPrice, TransactionID,CustomerID,WorkID FROM TRANS";
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
        /// Добавить новую транзакцию
        /// </summary>
        /// <param name="trans">транзакция</param>
        public void Add(Trans trans)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO TRANS(DateAcquired, AcquisitionPrice,PurchaseDate,SalesPrice,AskingPrice,CustomerID,WorkID)VALUES(@DateAcquired,  @AcquisitionPrice, @PurchaseDate, @SalesPrice, @AskingPrice, @CustomerID, @WorkID)";
                    
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
        /// Обновить информацию о транзакции
        /// </summary>
        /// <param name="trans">транзакция</param>
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
        /// Удалить транзакцию
        /// </summary>
        /// <param name="id">Номер транзакции</param>
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
        /// Загрузка транзакции
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
            trans.AcquisitionPrice = reader.GetDecimal(reader.GetOrdinal("AcquisitionPrice"));
            trans.SalesPrice = reader.GetDecimal(reader.GetOrdinal("SalesPrice"));
            trans.AskingPrice = reader.GetDecimal(reader.GetOrdinal("AskingPrice"));
            trans.DateAcquired = reader.GetDateTime(reader.GetOrdinal("DateAcquired"));
            trans.PurchaseDate = reader.GetDateTime(reader.GetOrdinal("PurchaseDate"));
            trans.WorkID = reader.GetInt32(reader.GetOrdinal("WorkID"));
            trans.CustomerID = reader.GetInt32(reader.GetOrdinal("CustomerID"));
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

        public IList<Trans> Load()
        {
            Transactions = new Dictionary<int, Trans>();
            var _transactions = LoadInternal();
            foreach(var trans in _transactions)
            {
                Transactions.Add(trans.TransactionID, trans);
            }
            return Transactions.Values.ToList();
        }
        public void Reset()
        {
            if (Transactions == null)
                return;
            Transactions.Clear();
        }
        /// <summary>
        /// Поиск транзакции
        /// </summary>
        /// <param name="CustomerName">Имя клиента</param>
        /// <param name="ArtistName">Имя художника</param>
        /// <param name="SalesPrice">Цена продажи</param>
        /// <param name="START_Purchase">Дата продажи С</param>
        /// <param name="STOP_Purchase">Дата продажи ПО</param>
        /// <param name="START_Acquisition">Дата покупки С</param>
        /// <param name="STOP_Acquisition">Дата покупки ПО</param>
        /// <returns></returns>
        public IList<Trans> SearchTransaction(string CustomerName, string ArtistName, decimal SalesPrice, string START_Purchase, string STOP_Purchase, string START_Acquisition, string STOP_Acquisition)
        {
            IList<Trans> trans =new List<Trans>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select T.TransactionID, C.CustomerID, W.WorkID, A.Name, T.DateAcquired, T.AcquisitionPrice, T.PurchaseDate, T.SalesPrice, T.AskingPrice FROM TRANS T JOIN CUSTOMER C on T.CustomerID=C.CustomerID JOIN WORK W on T.WorkID=W.WorkID JOIN ARTIST A on W.ArtistID=A.ArtistID WHERE C.Name like @CUSTOMERNAME AND A.Name like @ARTISTNAME AND T.SalesPrice like @SALESPRICE AND (T.PurchaseDate BETWEEN @STARTPURCHASE AND @STOPPURCHASE) AND (T.DateAcquired BETWEEN @STARTACQUISITION AND @STOPACQUISITION)";
                    cmd.Parameters.AddWithValue("@CUSTOMERNAME","%"+CustomerName+"%");
                    cmd.Parameters.AddWithValue("@ARTISTNAME", "%" + ArtistName + "%");
                    cmd.Parameters.AddWithValue("@SALESPRICE", "%" + SalesPrice + "%");
                    cmd.Parameters.AddWithValue("@STARTPURCHASE", START_Purchase);
                    cmd.Parameters.AddWithValue("@STOPPURCHASE", STOP_Purchase);
                    cmd.Parameters.AddWithValue("@STARTACQUISITION", START_Acquisition);
                    cmd.Parameters.AddWithValue("@STOPACQUISITION", STOP_Acquisition);
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
    }
}
