using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRA.DataAccess;
using VRA.Dto;
using VRA.BusinessLayer.Converters;

namespace VRA.BusinessLayer
{
    class CustomerProcessDb : ICustomerProcess
    {
        private static ICustomerDao customerDao = new CustomerDao();
        //private readonly ICustomerDao customerDao;
        public CustomerProcessDb()
        {
            customerDao = DaoFactory.GetCustomerDao();
        }
        public void Add(CustomerDto customer)
        {
            customerDao.Add(DtoConverter.Convert(customer));
        }

        public void Delete(int id)
        {
            customerDao.Delete(id);
        }

        public CustomerDto Get(int id)
        {
            return DtoConverter.Convert(customerDao.Get(id));
        }

        public IList<CustomerDto> GetList()
        {
            return DtoConverter.Convert(DaoFactory.GetCustomerDao().Load());
        }

        public void Update(CustomerDto customer)
        {
            customerDao.Update(DtoConverter.Convert(customer));
        }
    }
}
