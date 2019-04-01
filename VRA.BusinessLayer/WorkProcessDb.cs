﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRA.DataAccess;
using VRA.Dto;
using VRA.BusinessLayer.Converters;

namespace VRA.BusinessLayer
{
    class WorkProcessDb : IWorkProcess
    {
        private readonly IWorkDao workDao;
        public WorkProcessDb()
        {
            workDao = DaoFactory.GetWorkDao();
        }
        public void Add(WorkDto work)
        {
            workDao.Add(DtoConverter.Convert(work));
        }

        public void Delete(int id)
        {
            workDao.Delete(id);
        }

        public WorkDto Get(int id)
        {
            return DtoConverter.Convert(workDao.Get(id));
        }

        public IList<WorkDto> GetList()
        {
            return DtoConverter.Convert(workDao.GetAll());
        }

        public void Update(WorkDto work)
        {
            workDao.Update(DtoConverter.Convert(work));
        }
    }
}