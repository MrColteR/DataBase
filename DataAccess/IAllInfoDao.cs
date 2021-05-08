using System;
using System.Collections.Generic;
using System.Text;
using VRA.DataAccess.Entities;

namespace VRA.DataAccess
{
    public interface IAllInfoDao
    {
        public IList<AllInfo> GetList();
        public IList<AllInfo> Info();
    }
}
