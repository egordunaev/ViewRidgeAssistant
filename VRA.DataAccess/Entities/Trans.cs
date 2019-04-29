using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace VRA.DataAccess.Entities
{
    public class Trans
    {
        public DateTime DateAcquired;
        public decimal AcquisitionPrice;
        public DateTime PurchaseDate;
        public decimal SalesPrice;
        public decimal AskingPrice;
        public int TransactionID;
        public int? CustomerID;
        public int WorkID;
    }
}
