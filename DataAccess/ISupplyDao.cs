using System;
using System.Collections.Generic;
using System.Text;
using VRA.DataAccess.Entities;

namespace VRA.DataAccess
{
    public interface ISupplyDao
    {
        public Supply Get(int SupplyID);
        public void Add(Supply supply);
        public void Update(Supply supply);
        public void Delete(int SupplyID);
        public IList<Supply> GetList();
    }
}
