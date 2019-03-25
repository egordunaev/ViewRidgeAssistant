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
        private readonly IArtistDao _artistDao;
        public ArtistProcessDb()
        {
            //Получаем объект для работы с художниками в базе
            _artistDao = DaoFactory.GetArtistDao();
        }
        public IList<ArtistDto> GetList()
        {
            return DtoConverter.Convert(_artistDao.GetAll());
        }
        public ArtistDto Get(int id)
        {
            return DtoConverter.Convert(_artistDao.Get(id));
        }
        public void Add(ArtistDto artist)
        {
            _artistDao.Add(DtoConverter.Convert(artist));
        }
        public void Update(ArtistDto artist)
        {
            _artistDao.Update(DtoConverter.Convert(artist));
        }
        public void Delete(int id)
        {
            _artistDao.Delete(id);
        }
    }
}
