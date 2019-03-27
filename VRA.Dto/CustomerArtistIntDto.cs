using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRA.Dto
{
    /// <summary>
    /// Интерес клиентов в конкретных художниках
    /// </summary>
    public class CustomerArtistIntDto
    {
        /// <summary>
        /// Номер художника
        /// </summary>
        public int ArtistID { get; set; }
        /// <summary>
        /// Номер клиента
        /// </summary>
        public int CustomerID { get; set; }
    }
}
