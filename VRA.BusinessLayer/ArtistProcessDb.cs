using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRA.BusinessLayer;
using VRA.DataAccess;
using VRA.Dto;
using VRA.BusinessLayer.Converters;

namespace VRA.BusinessLayer
{
    class ArtistProcessDb : IArtistProcess
    {
        private static IArtistDao artistDao = new ArtistDao();
        private readonly IArtistDao _artistDao;
        public ArtistProcessDb()
        {
            //Получаем объект для работы с художниками в базе
            _artistDao = DaoFactory.GetArtistDao();
        }
        public IList<ArtistDto> GetList()
        {
            return DtoConverter.Convert(DaoFactory.GetArtistDao().Load());
        }
        public ArtistDto Get(int id)
        {
            return DtoConverter.Convert(_artistDao.Get(id));
        }
        public void Add(ArtistDto artist)
        {
            artistDao.Add(DtoConverter.Convert(artist));
        }
        public void Update(ArtistDto artist)
        {
            _artistDao.Update(DtoConverter.Convert(artist));
        }
        public void Delete(int id)
        {
            artistDao.Delete(id);
        }
    }
}
