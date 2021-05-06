using System;
using System.Collections.Generic;
using System.Text;
using VRA.DataAccess.Entities;

namespace VRA.DataAccess
{
    public interface IDetailsDao
    {
        public Details Get(int DetailsID);
        public void Add(Details details);
        public void Update(Details details);
        public void Delete(int DetailsID);
        public IList<Details> GetList();
        public IList<Details> SearchDetail(string Name);
    }
}
