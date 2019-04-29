using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRA.Dto;

namespace VRA.BusinessLayer
{
    public class CustomerArtistIntProcess : ICustomerArtistIntProcess
    {
        private static readonly IDictionary<int, CustomerArtistIntDto> CustomerArtistInts = new Dictionary<int, CustomerArtistIntDto>();
        public void Add(CustomerArtistIntDto customerArtistInt)
        {
            int max = CustomerArtistInts.Keys.Count == 0 ? 1 : CustomerArtistInts.Keys.Max(p => p) + 1;
            customerArtistInt.Customer.CustomerID = max;
            CustomerArtistInts.Add(max, customerArtistInt);
        }

        public void Delete(int CustomerID, int ArtistID)
        {
            if (CustomerArtistInts.ContainsKey(CustomerID) && CustomerArtistInts.ContainsKey(ArtistID))
            {
                CustomerArtistInts.Remove(CustomerID);
                CustomerArtistInts.Remove(ArtistID);
            }
        }

        public CustomerArtistIntDto Get(int CustomerID, int ArtistID)
        {
            return CustomerArtistInts.ContainsKey(CustomerID) ? CustomerArtistInts[CustomerID] : null;
        }

        public IList<CustomerArtistIntDto> GetList()
        {
            return new List<CustomerArtistIntDto>(CustomerArtistInts.Values);
        }

        public void Update(CustomerArtistIntDto customerArtistInt)
        {
            if (CustomerArtistInts.ContainsKey(customerArtistInt.Customer.CustomerID.Value) && CustomerArtistInts.ContainsKey(customerArtistInt.Artist.Id))
                CustomerArtistInts[customerArtistInt.Customer.CustomerID.Value] = customerArtistInt;
        }
    }
}
