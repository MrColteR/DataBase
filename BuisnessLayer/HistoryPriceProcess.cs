using System;
using System.Collections.Generic;
using System.Text;
using VRA.Dto;
using VRA.DataAccess;

namespace BuisnessLayer
{
    public class HistoryPriceProcess : IHistoryPriceProcess
    {
        private readonly IHistoryPriceDao historyPriceDao;
        public HistoryPriceProcess()
        {
            historyPriceDao = DaoFactory.GetHistoryPriceDao();
        }
        public HistoryPriceDto Get(int HistoryID)
        {
            return DtoConverter.Convert(historyPriceDao.Get(HistoryID));
        }
        public void Add(HistoryPriceDto historyPrice)
        {
            historyPriceDao.Add(DtoConverter.Convert(historyPrice));
        }
        public void Update(HistoryPriceDto historyPrice)
        {
            historyPriceDao.Update(DtoConverter.Convert(historyPrice));
        }
        public void Delete(int HistoryID)
        {
            historyPriceDao.Delete(HistoryID);
        }
        public IList<HistoryPriceDto> GetList()
        {
            return DtoConverter.Convert(historyPriceDao.GetList());
        }
    }
}
