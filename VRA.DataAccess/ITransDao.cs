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
    }
}
