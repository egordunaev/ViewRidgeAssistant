using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace VRA.DataAccess.Entities
{
    public class Artist
    {
        public int ArtistId;
        public string Name;
        public int BirthYear;
        public int? DeceaseYear;
        public string Nationality;
    }
}
