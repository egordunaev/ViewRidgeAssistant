using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRA.Dto
{
    public class WorkInGalleryDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Copy { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? AskingPrice { get; set; }
    }
}
