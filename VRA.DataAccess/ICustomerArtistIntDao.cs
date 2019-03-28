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
    /// Работа интересов клиентов в художниках
    /// </summary>
    public interface ICustomerArtistIntDao
    {
        /// <summary>
        /// Получить интерес
        /// </summary>
        /// <param name="ArtistID">номер художника</param>
        /// <param name="CustomerID">номер клиента</param>
        /// <returns></returns>
        CustomerArtistInt Get(int ArtistID,int CustomerID);
        /// <summary>
        /// Получить все интересы
        /// </summary>
        /// <returns></returns>
        IList<CustomerArtistInt> GetAll();
        /// <summary>
        /// Добавить интерес
        /// </summary>
        /// <param name="customerArtistInt"></param>
        void Add(CustomerArtistInt customerArtistInt);
        /// <summary>
        /// Обновить интерес
        /// </summary>
        /// <param name="customerArtistInt"></param>
        void Update(CustomerArtistInt customerArtistInt);
        /// <summary>
        /// Удалить интерес
        /// </summary>
        /// <param name="ArtistID">Artist id</param>
        /// <param name="CustomerID">Customer id</param>
        void Delete(int ArtistID,int CustomerID);
    }
}
