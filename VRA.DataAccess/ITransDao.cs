using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRA.DataAccess.Entities;
using System.Configuration;

namespace VRA.DataAccess
{
    /// <summary>
    /// Интерфейс транзакций
    /// </summary>
    public interface ITransDao
    {
        /// <summary>
        /// Получить транзакцию по id
        /// </summary>
        /// <param name=«id»>id транзакции</param>
        /// <returns>транзакция</returns>
        Trans Get(int id);
        /// <summary>
        /// Получить список всех транзакций в базе
        /// </summary>
        /// <returns>список всех транзакций в базе</returns>
        IList<Trans> GetAll();
        /// <summary>
        /// Добавить транзакцию в базу
        /// </summary>
        /// <param name="transaction">Новая транзакция</param>
        void Add(Trans transaction);
        /// <summary>
        /// Обновить транзакцию
        /// </summary>
        /// <param name=«transaction»>обновленная транзакция</param>
        void Update(Trans transaction);
        /// <summary>
        /// Удалить транзакцию
        /// </summary>
        /// <param name=«id»>id удаляемой транзакции</param>
        void Delete(int id);
        IList<Trans> Load();
        /// <summary>
        /// Поиск транзакции по Клиенту
        /// </summary>
        /// <param name="CustomerName">Имя клиента</param>
        /// <returns></returns>
        IList<Trans> SearchTransactionCustomer(string CustomerName);
        /// <summary>
        /// Поиск транзакции по Художнику
        /// </summary>
        /// <param name="ArtistName">Имя художника</param>
        /// <returns></returns>
        IList<Trans> SearchTransactionArtist(string ArtistName);
        /// <summary>
        /// Поиск транзакции по Цене продажи
        /// </summary>
        /// <param name="SalesPrice">Цена продажи</param>
        /// <returns></returns>
        IList<Trans> SearchTransactionSalesPrice(decimal SalesPrice);
        /// <summary>
        /// Поиск транзакции по дате продажи
        /// </summary>
        /// <param name="START_Purchase">Начало периода</param>
        /// <param name="STOP_Purchase">Конец периода</param>
        /// <returns></returns>
        IList<Trans> SearchTransactionPurchase(string START_Purchase, string STOP_Purchase);
        /// <summary>
        /// Поиск транзакции по дате покупки
        /// </summary>
        /// <param name="START_Acquisition">Начало периода</param>
        /// <param name="STOP_Acquisition">Конец периода</param>
        /// <returns></returns>
        IList<Trans> SearchTransactionAcquisition(string START_Acquisition, string STOP_Acquisition);




    }
}
