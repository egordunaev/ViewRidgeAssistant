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
    /// Интерфейс работ художников
    /// </summary>
    public interface IWorkDao
    {
        /// <summary>
        /// Получить работу художника по id
        /// </summary>
        /// <param name="id">Номер работы</param>
        /// <returns>Работа художника</returns>
        Work Get(int id);
        /// <summary>
        /// Получить все работы художников
        /// </summary>
        /// <returns></returns>
        IList<Work> GetAll();
        /// <summary>
        /// Добавить новую работу
        /// </summary>
        /// <param name="work">Работа</param>
        void Add(Work work);
        /// <summary>
        /// Обновить работу художника
        /// </summary>
        /// <param name="work">работа</param>
        void Update(Work work);
        /// <summary>
        /// Удалить работу художника
        /// </summary>
        /// <param name="id">номер работы</param>
        void Delete(int id);
        IList<Work> Load();
        IEnumerable<Work> GetInGallery();
    }
}
