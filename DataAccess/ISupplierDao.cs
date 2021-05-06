using System;
using System.Collections.Generic;
using System.Text;
using VRA.DataAccess.Entities;

namespace VRA.DataAccess
{
    public interface ISupplierDao
    {
        public Supplier Get(int SupplierID);
        public void Add(Supplier supplier);
        public void Update(Supplier supplier);
        public void Delete(int SupplierID);
        public IList<Supplier> GetList();
        public IList<Supplier> SearchSupplier(string Name);
        public IList<Supplier> ExportSupplier();
    }
}
