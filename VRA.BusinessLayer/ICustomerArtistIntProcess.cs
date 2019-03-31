using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRA.Dto;

namespace VRA.BusinessLayer
{
    /// <summary>
    /// Декларация действий по работе с интересом клиентов в художниках
    /// </summary>
    public interface ICustomerArtistIntProcess
    {
        /// <summary>
        /// Возвращает список Клиентов и художников
        /// </summary>
        /// <returns></returns>
        IList<CustomerArtistIntDto> GetList();
        /// <summary>
        /// Возвращает клиентов и художников
        /// </summary>
        /// <param name="CustomerID">Номер клиента</param>
        /// <param name="ArtistID">Номер художника</param>
        /// <returns></returns>
        CustomerArtistIntDto Get(int CustomerID, int ArtistID);
        /// <summary>
        /// Добавить интерес клиента в художнике
        /// </summary>
        /// <param name="customerArtistInt"></param>
        void Add(CustomerArtistIntDto customerArtistInt);
        /// <summary>
        /// Изменить интерес клиента в художнике
        /// </summary>
        /// <param name="customerArtistInt"></param>
        void Update(CustomerArtistIntDto customerArtistInt);
        /// <summary>
        /// Удалить интерес клиента в художнике
        /// </summary>
        /// <param name="CustomerID">Номер клиента</param>
        /// <param name="ArtistID">Номер художника</param>
        void Delete(int CustomerID, int ArtistID);
    }
}
