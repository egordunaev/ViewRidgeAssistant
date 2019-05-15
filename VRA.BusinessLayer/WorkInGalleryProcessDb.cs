using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRA.Dto;
using VRA.BusinessLayer.Converters;
using VRA.DataAccess;

namespace VRA.BusinessLayer
{
    public class WorkInGalleryProcessDb : IWorkInGalleryProcess
    {
        private readonly IWorkInGalleryDao workInGalleryDao;
        public WorkInGalleryProcessDb()
        {
            workInGalleryDao = DaoFactory.GetWorkInGalleryDao();
        }
        public IList<WorkInGalleryDto> GetList()
        {
            return DtoConverter.Convert(DaoFactory.GetWorkInGalleryDao().GetAll());
        }
    }
}
