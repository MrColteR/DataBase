using System;
using System.Collections.Generic;
using System.Text;
using VRA.Dto;
using VRA.DataAccess;

namespace BuisnessLayer
{
    public class AllInfoProcess : IAllInfoProcess
    {
        private readonly IAllInfoDao allInfoDao;
        public AllInfoProcess()
        {
            allInfoDao = DaoFactory.GetAllInfo();
        }
        public IList<AllInfoDto> GetList()
        {
            return DtoConverter.Convert(allInfoDao.GetList());
        }
        public IList<AllInfoDto> Info()
        {
            return DtoConverter.Convert(allInfoDao.Info());
        }
    }
}
