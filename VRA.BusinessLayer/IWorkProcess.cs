using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRA.Dto;

namespace VRA.BusinessLayer
{
    /// <summary>
    /// Декларация действий по работе с Работами художников
    /// </summary>
    public interface IWorkProcess
    {
        /// <summary>
        /// Возвращает список работ художников
        /// </summary>
        /// <returns></returns>
        IList<WorkDto> GetList();
        /// <summary>
        /// Возвращает работу художника
        /// </summary>
        /// <param name="id">Номер работы</param>
        /// <returns></returns>
        WorkDto Get(int id);
        /// <summary>
        /// Добавить работу художника
        /// </summary>
        /// <param name="work">Работа художника</param>
        void Add(WorkDto work);
        /// <summary>
        /// Изменить работу художника
        /// </summary>
        /// <param name="work">Работа художника</param>
        void Update(WorkDto work);
        /// <summary>
        /// Удалить работу художника
        /// </summary>
        /// <param name="id">Номер работы</param>
        void Delete(int id);
        //IList<WorkDto> GetList();
    }
}
