using System;
using System.Collections.Generic;
using System.Text;
using VRA.Dto;
using VRA.DataAccess;

namespace BuisnessLayer
{
    public class SupplyProcess : ISupplyProcess
    {
        private readonly ISupplyDao supplyDao;
        public SupplyProcess()
        {
            supplyDao = DaoFactory.GetSupplyDao();
        }
        public SupplyDto Get(int SupplyID)
        {
            return DtoConverter.Convert(supplyDao.Get(SupplyID));
        }
        public void Add(SupplyDto supply)
        {
            supplyDao.Add(DtoConverter.Convert(supply));
        }
        public void Update(SupplyDto supply)
        {
            supplyDao.Update(DtoConverter.Convert(supply));
        }
        public void Delete(int SupplyID)
        {
            supplyDao.Delete(SupplyID);
        }
        public IList<SupplyDto> GetList()
        {
            return DtoConverter.Convert(supplyDao.GetList());
        }
        public IList<SupplyDto> ExportSupply()
        {
            return DtoConverter.Convert(supplyDao.ExportSupply());
        }
    }
}
