using System;
using System.Collections.Generic;
using VRA.Dto;

namespace BuisnessLayer
{
    public interface ISupplierProcess
    {
        SupplierDto Get(int SupplierID);
        void Add(SupplierDto supplier);
        void Update(SupplierDto supplier);
        void Delete(int SupplierID);
        IList<SupplierDto> GetList();
        IList<SupplierDto> SearchSupplier(string Name);
    }
}
