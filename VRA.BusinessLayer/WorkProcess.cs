using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRA.Dto;

namespace VRA.BusinessLayer
{
    public class WorkProcess : IWorkProcess
    {
        private static readonly IDictionary<int, WorkDto> Works = new Dictionary<int, WorkDto>();
        public IList<WorkDto> GetList()
        {
            return new List<WorkDto>(Works.Values);
        }

        public WorkDto Get(int id)
        {
            return Works.ContainsKey(id) ? Works[id] : null;
        }

        public void Add(WorkDto work)
        {
            int max = Works.Keys.Count == 0 ? 1 : Works.Keys.Max(p => p) + 1;
            work.WorkID = max;
            Works.Add(max, work);
        }

        public void Update(WorkDto work)
        {
            if (Works.ContainsKey(work.WorkID))
                Works[work.WorkID] = work;
        }

        public void Delete(int id)
        {
            if (Works.ContainsKey(id))
                Works.Remove(id);
        }

        public IList<WorkDto> GetListInGallery()
        {
            throw new NotImplementedException();
        }
    }
}
