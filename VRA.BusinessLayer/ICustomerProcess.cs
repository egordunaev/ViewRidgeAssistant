using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRA.Dto;

namespace VRA.BusinessLayer
{
    /// <summary>
    /// Декларация действий по работе с таблицей Клиентов
    /// </summary>
    public interface ICustomerProcess
    {
        /// <summary>
        /// Возвращает список клиентов
        /// </summary>
        /// <returns></returns>
        IList<CustomerDto> GetList();
        /// <summary>
        /// Возвращает клиента по id
        /// </summary>
        /// <param name="id">Номер клиента</param>
        /// <returns></returns>
        CustomerDto Get(int id);
        /// <summary>
        /// Добавить клиента
        /// </summary>
        /// <param name="customer">клиент</param>
        void Add(CustomerDto customer);
        /// <summary>
        /// Изменить клиента
        /// </summary>
        /// <param name="customer">клиент</param>
        void Update(CustomerDto customer);
        /// <summary>
        /// Удалить клиента
        /// </summary>
        /// <param name="id">Номер клиента</param>
        void Delete(int id);
        IList<CustomerDto> SearchCustomer(string Name, string Email);

    }
}
