using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRA.Dto;
using VRA.DataAccess;
using VRA.BusinessLayer.Converters;

namespace VRA.BusinessLayer
{
    class CustomerArtistIntDb : ICustomerArtistIntProcess
    {
        private readonly ICustomerArtistIntDao customerartistDao;
        public CustomerArtistIntDb()
        {
            customerartistDao = DaoFactory.GetCustomerArtistIntDao();
        }
        public void Add(CustomerArtistIntDto customerArtistInt)
        {
            customerartistDao.Add(DtoConverter.Convert(customerArtistInt));
        }

        public void Delete(int CustomerID, int ArtistID)
        {
            customerartistDao.Delete(ArtistID,CustomerID);
        }

        public CustomerArtistIntDto Get(int CustomerID, int ArtistID)
        {
            return DtoConverter.Convert(customerartistDao.Get(ArtistID,CustomerID));
        }

        public IList<CustomerArtistIntDto> GetList()
        {
            return DtoConverter.Convert(customerartistDao.GetAll());
        }

        public void Update(CustomerArtistIntDto customerartistInt)
        {
            customerartistDao.Update(DtoConverter.Convert(customerartistInt));
        }
    }
}
