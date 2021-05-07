using System;
using System.Collections.Generic;
using System.Text;
using VRA.Dto;
using VRA.DataAccess;

namespace BuisnessLayer
{
    public class DetailInDeliveryProcess : IDetailInDeliveryProcess
    {
        private readonly IDetailInDeliveryDao detailInDeliveryDao;
        public DetailInDeliveryProcess()
        {
            detailInDeliveryDao = DaoFactory.GetDetailInDeliveryDao();
        }
        public DetailInDeliveryDto Get(int Number)
        {
            return DtoConverter.Convert(detailInDeliveryDao.Get(Number));
        }
        public IList<DetailInDeliveryDto> GetList()
        {
            return DtoConverter.Convert(detailInDeliveryDao.GetList());
        }
        public IList<DetailInDeliveryDto> ExportDetailInDelivery()
        {
            return DtoConverter.Convert(detailInDeliveryDao.ExportDetailInDelivery());
        }
    }
}
