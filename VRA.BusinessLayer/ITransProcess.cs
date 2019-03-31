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
    }
}
