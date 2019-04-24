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
    class TransProcessDb :ITransProcess
    {
        private static ITransDao transDao = new TransDao();
        public TransProcessDb()
        {
            transDao = DaoFactory.GetTransDao();
        }
        public void Add(TransDto customer)
        {
            transDao.Add(DtoConverter.Convert(customer));
        }

        public void Delete(int id)
        {
            transDao.Delete(id);
        }

        public TransDto Get(int id)
        {
            return DtoConverter.Convert(transDao.Get(id));
        }

        public IList<TransDto> GetList()
        {
            return DtoConverter.Convert(DaoFactory.GetTransDao().Load());
        }

        public void Update(TransDto trans)
        {
            transDao.Update(DtoConverter.Convert(trans));
        }
    }
}
