using System;
using System.Collections.Generic;
using System.Text;
using VRA.DataAccess.Entities;

namespace VRA.DataAccess
{
    public interface IDetailInDeliveryDao
    {
        public DetailInDelivery Get(int Number);
        public IList<DetailInDelivery> GetList();
        public IList<DetailInDelivery> ExportDetailInDelivery();
    }
}
