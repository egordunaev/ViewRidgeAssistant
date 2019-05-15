using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRA.BusinessLayer
{
    public interface IReportGenerator
    {
        void fillExcelTableByType(IEnumerable<object> grid, string status, FileInfo xlsxFile);
        string genHtmlWorksInGallery(string rep);
    }
}
