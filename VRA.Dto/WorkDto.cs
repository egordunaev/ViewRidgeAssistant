using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRA.Dto
{
    /// <summary>
    /// Работа художника
    /// </summary>
    public class WorkDto
    {
        /// <summary>
        /// Название картины
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Копия картины
        /// </summary>
        public string Copy { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Номер картины 
        /// </summary>
        public int WorkID { get; set; }
        /// <summary>
        /// Номер художника
        /// </summary>
        public int ArtistID { get; set; }
    }
}
