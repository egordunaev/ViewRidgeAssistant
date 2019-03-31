using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRA.Dto
{
    /// <summary>
    /// Транзакция
    /// </summary>
    public class TransDto
    {
        /// <summary>
        /// Дата приобретения картины
        /// </summary>
        public DateTime DateAcquired { get; set; }
        /// <summary>
        /// Цена покупки
        /// </summary>
        public decimal AcquisitionPrice { get; set; }
        /// <summary>
        /// Дата покупки картины
        /// </summary>
        public DateTime PurchaseDate { get; set; }
        /// <summary>
        /// Цена покупки картины
        /// </summary>
        public decimal SalesPrice { get; set; }
        /// <summary>
        /// Цена картины
        /// </summary>
        public decimal AskingPrice { get; set; }
        /// <summary>
        /// Номер транзакции
        /// </summary>
        public int TransactionID { get; set; }
        /// <summary>
        /// Номер клиента
        /// </summary>
        public int CustomerID { get; set; }
        /// <summary>
        /// Номер работы художника
        /// </summary>
        public int WorkID { get; set; }
    }
}
