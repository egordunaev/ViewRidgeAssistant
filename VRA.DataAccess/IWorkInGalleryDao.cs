using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRA.DataAccess.Entities;
using System.Configuration;

namespace VRA.DataAccess
{
    public interface IWorkInGalleryDao
    {
        IList<WorkInGallery> GetAll();
    }
}
