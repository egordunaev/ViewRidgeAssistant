using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRA.Dto;

namespace VRA.BusinessLayer
{
    /// <summary>
    /// Декларация действий над Национальностями
    /// </summary>
    public interface INationProcess
    {
        /// <summary>
        /// Возвращает национальности
        /// </summary>
        /// <returns></returns>
        IList<NationDto> GetList();
        /// <summary>
        /// Добавляет национальность
        /// </summary>
        /// <param name="nation">Национальность</param>
        void Add(NationDto nation);
        /// <summary>
        /// Удаляет национальность 
        /// </summary>
        /// <param name="NationID">Номер национальности</param>
        void Delete(int NationID);
    }
}
