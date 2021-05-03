using System;
using System.Collections.Generic;
using System.Text;
using VRA.DataAccess.Entities;

namespace VRA.DataAccess
{
    public interface IHistoryPriceDao
    {
         public HistoryPrice Get(int HistoryID);
         public void Add(HistoryPrice historyPrice);
         public void Update(HistoryPrice historyPrice);
         public void Delete(int HistoryID);
         public IList<HistoryPrice> GetList();
    }
}
