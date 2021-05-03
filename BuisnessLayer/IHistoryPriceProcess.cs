using System;
using System.Collections.Generic;
using System.Text;
using VRA.Dto;

namespace BuisnessLayer
{
    public interface IHistoryPriceProcess
    {
        HistoryPriceDto Get(int HistoryID);
        void Add(HistoryPriceDto historyPrice);
        void Update(HistoryPriceDto historyPrice);
        void Delete(int HistoryID);
        IList<HistoryPriceDto> GetList();
    }
}
