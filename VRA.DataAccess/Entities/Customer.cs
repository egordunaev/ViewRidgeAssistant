using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace VRA.DataAccess.Entities
{
    public class Customer
    {
        public int? CustomerID;
        public string Email;
        public string Name;
        public string AreaCode;
        public string HouseNumber;
        public string Street;
        public string City;
        public string Region;
        public string ZipPostalCode;
        public string Country;
        public string PhoneNumber;
    }
}
