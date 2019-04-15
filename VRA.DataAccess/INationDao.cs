using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRA.DataAccess.Entities;

namespace VRA.DataAccess
{
    public interface INationDao
    {
        IList<Nation> Load();
        Nation Get(int NationID);
        void Add(Nation nation);
        void Delete(int NationID);
    }
}
