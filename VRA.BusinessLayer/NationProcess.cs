using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRA.BusinessLayer.Converters;
using VRA.Dto;
using VRA.DataAccess;

namespace VRA.BusinessLayer
{
    public class NationProcess : INationProcess
    {
        private static INationDao NatDao = new NationDao();
        public void Add(NationDto nation)
        {
            NatDao.Add(DtoConverter.Convert(nation));
        }

        public void Delete(int NationID)
        {
            NatDao.Delete(NationID);
        }

        public IList<NationDto> GetList()
        {
            return DtoConverter.Convert(DaoFactory.GetNationDao().Load());
        }
    }
}
