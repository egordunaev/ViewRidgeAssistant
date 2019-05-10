using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRA.Dto;

namespace VRA.BusinessLayer
{
    public class CustomerProcess : ICustomerProcess
    {
        private static readonly IDictionary<int, CustomerDto> Customers = new Dictionary<int, CustomerDto>();
        public void Add(CustomerDto customer)
        {
            int max = Customers.Keys.Count == 0 ? 1 : Customers.Keys.Max(p => p) + 1;
            customer.CustomerID = max;
            Customers.Add(max, customer);
        }

        public void Delete(int id)
        {
            if (Customers.ContainsKey(id))
                Customers.Remove(id);
        }

        public CustomerDto Get(int id)
        {
            return Customers.ContainsKey(id) ? Customers[id] : null;
        }

        public IList<CustomerDto> GetList()
        {
            return new List<CustomerDto>(Customers.Values);
        }

        public IList<CustomerDto> SearchCustomer(string Name, string Email)
        {
            throw new NotImplementedException();
        }

        public void Update(CustomerDto customer)
        {
            if (Customers.ContainsKey(customer.CustomerID.Value))
                Customers[customer.CustomerID.Value] = customer;
        }
    }
}
