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
        public double AcquisitionPrice;
        public DateTime PurchaseDate;
        public double SalesPrice;
        public double AskingPrice;
        public int TransactionID;
        public int CustomerID;
        public int WorkID;
    }
}
