using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRA.Dto;

namespace VRA.BusinessLayer
{
    public class TransProcess : ITransProcess
    {
        private static readonly IDictionary<int, TransDto> Transactions = new Dictionary<int, TransDto>();
        public void Add(TransDto trans)
        {
            int max = Transactions.Keys.Count == 0 ? 1 : Transactions.Keys.Max(p => p) + 1;
            trans.TransactionID = max;
            Transactions.Add(max, trans);
        }

        public void Delete(int id)
        {
            if (Transactions.ContainsKey(id))
                Transactions.Remove(id);
        }

        public TransDto Get(int id)
        {
            return Transactions.ContainsKey(id) ? Transactions[id] : null;
        }

        public IList<TransDto> GetList()
        {
            return new List<TransDto>(Transactions.Values);
        }

        public IList<TransDto> SearchTransactionAcquisition(string START_Acquisition, string STOP_Acquisition)
        {
            throw new NotImplementedException();
        }

        public IList<TransDto> SearchTransactionArtist(string ArtistName)
        {
            throw new NotImplementedException();
        }

        public IList<TransDto> SearchTransactionCustomer(string CustomerName)
        {
            throw new NotImplementedException();
        }

        public IList<TransDto> SearchTransactionPurchase(string START_Purchase, string STOP_Purchase)
        {
            throw new NotImplementedException();
        }

        public IList<TransDto> SearchTransactionSalesPrice(decimal SalesPrice)
        {
            throw new NotImplementedException();
        }

        public void Update(TransDto trans)
        {
            if (Transactions.ContainsKey(trans.TransactionID))
                Transactions[trans.TransactionID] = trans;
        }
    }
}
