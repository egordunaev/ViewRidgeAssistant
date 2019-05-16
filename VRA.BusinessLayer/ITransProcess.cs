using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRA.Dto;

namespace VRA.BusinessLayer
{
    /// <summary>
    /// Декларация действий по работе с Транзакциями
    /// </summary>
    public interface ITransProcess
    {
        /// <summary>
        /// Возвращает список транзакций
        /// </summary>
        /// <returns></returns>
        IList<TransDto> GetList();
        /// <summary>
        /// Возвращает транзакцию по id
        /// </summary>
        /// <param name="id">Номер транзакции</param>
        /// <returns></returns>
        TransDto Get(int id);
        /// <summary>
        /// Добавить транзакцию
        /// </summary>
        /// <param name="trans">Транзакция</param>
        void Add(TransDto trans);
        /// <summary>
        /// Изменить транзакцию
        /// </summary>
        /// <param name="trans">Транзакция</param>
        void Update(TransDto trans);
        /// <summary>
        /// Удалить транзакцию
        /// </summary>
        /// <param name="id">Номер транзакции</param>
        void Delete(int id);
        /// <summary>
        /// Поиск транзакции по Клиенту
        /// </summary>
        /// <param name="CustomerName">Имя клиента</param>
        /// <returns></returns>
        IList<TransDto> SearchTransactionCustomer(string CustomerName);
        /// <summary>
        /// Поиск транзакции по Художнику
        /// </summary>
        /// <param name="ArtistName">Имя художника</param>
        /// <returns></returns>
        IList<TransDto> SearchTransactionArtist(string ArtistName);
        /// <summary>
        /// Поиск транзакции по Цене продажи
        /// </summary>
        /// <param name="SalesPrice">Цена продажи</param>
        /// <returns></returns>
        IList<TransDto> SearchTransactionSalesPrice(decimal SalesPrice);
        /// <summary>
        /// Поиск транзакции по дате продажи
        /// </summary>
        /// <param name="START_Purchase">Начало периода</param>
        /// <param name="STOP_Purchase">Конец периода</param>
        /// <returns></returns>
        IList<TransDto> SearchTransactionPurchase(string START_Purchase, string STOP_Purchase);
        /// <summary>
        /// Поиск транзакции по дате покупки
        /// </summary>
        /// <param name="START_Acquisition">Начало периода</param>
        /// <param name="STOP_Acquisition">Конец периода</param>
        /// <returns></returns>
        IList<TransDto> SearchTransactionAcquisition(string START_Acquisition, string STOP_Acquisition);
        //IList<TransDto> SearchTransaction(string CustomerName, string ArtistName, decimal SalesPrice, string START_Purchase, string STOP_Purchase, string START_Acquisition, string STOP_Acquisition);
    }
}
