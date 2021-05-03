using System;
using System.Collections.Generic;
using System.Text;
using VRA.Dto;
using VRA.DataAccess;

namespace BuisnessLayer
{
    public class SupplierProcess : ISupplierProcess
    {
        private readonly ISupplierDao supplierDao;
        public SupplierProcess()
        {
            supplierDao = DaoFactory.GetSupplierDao();
        }
        public SupplierDto Get(int SupplierID)
        {
            return DtoConverter.Convert(supplierDao.Get(SupplierID));
        }
        public void Add(SupplierDto supplier)
        {
            supplierDao.Add(DtoConverter.Convert(supplier));
        }
        public void Update(SupplierDto supplier)
        {
            supplierDao.Update(DtoConverter.Convert(supplier));
        }
        public void Delete(int SupplierID)
        {
            supplierDao.Delete(SupplierID);
        }
        public IList<SupplierDto> GetList()
        {
            return DtoConverter.Convert(supplierDao.GetList());
        }
        public IList<SupplierDto> SearchSupplier(string Name)
        {
            return DtoConverter.Convert(supplierDao.SearchSupplier(Name));
        }
    }
}
