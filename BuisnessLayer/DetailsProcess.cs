using System;
using System.Collections.Generic;
using System.Text;
using VRA.Dto;
using VRA.DataAccess;

namespace BuisnessLayer
{
    public class DetailsProcess : IDetailsProcess
    {
        private readonly IDetailsDao detailsDao;
        public DetailsProcess()
        {
            detailsDao = DaoFactory.GetDetailsDao();
        }
        public DetailsDto Get(int DetailsID)
        {
            return DtoConverter.Convert(detailsDao.Get(DetailsID));
        }
        public void Add(DetailsDto details)
        {
            detailsDao.Add(DtoConverter.Convert(details));
        }
        public void Update(DetailsDto details)
        {
            detailsDao.Update(DtoConverter.Convert(details));
        }
        public void Delete(int DetailsID)
        {
            detailsDao.Delete(DetailsID);
        }
        public IList<DetailsDto> GetList()
        {
            return DtoConverter.Convert(detailsDao.GetList());
        }
        public IList<DetailsDto> SearchDetail(string Name)
        {
            return DtoConverter.Convert(detailsDao.SearchDetail(Name));
        }
        public IList<DetailsDto> ExportDetails()
        {
            return DtoConverter.Convert(detailsDao.ExportDetails());
        }
    }
}
