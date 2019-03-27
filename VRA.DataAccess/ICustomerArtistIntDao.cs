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
        /// Получить 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CustomerArtistInt Get(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IList<CustomerArtistInt> GetAll();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerArtistInt"></param>
        void Add(CustomerArtistInt customerArtistInt);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerArtistInt"></param>
        void Update(CustomerArtistInt customerArtistInt);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);
    }
}
