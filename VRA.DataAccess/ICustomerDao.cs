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
    /// Описание действий класса Клиент
    /// </summary>
    public interface ICustomerDao
    {
        /// <summary>
        /// Получить клиента по id
        /// </summary>
        /// <param name="id">Номер клиента</param>
        /// <returns></returns>
        Customer Get(int id);
        /// <summary>
        /// Получить список всех клиентов в базе
        /// </summary>
        /// <returns>Список всех клиентов в базе</returns>
        IList<Customer> GetAll();
        /// <summary>
        /// Добавить клиента в базу
        /// </summary>
        /// <param name="customer">Клиент</param>
        void Add(Customer customer);
        /// <summary>
        /// Обновить запись о клиенте
        /// </summary>
        /// <param name="customer">Клиент</param>
        void Update(Customer customer);
        /// <summary>
        /// Удалить клиента из базы
        /// </summary>
        /// <param name="id">Номер клиента</param>
        void Delete(int id);
        IList<Customer> Load();
    }
}
