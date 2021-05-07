using System;
using System.Collections.Generic;
using System.Text;
using VRA.Dto;

namespace BuisnessLayer
{
    public interface ISupplyProcess
    {
        SupplyDto Get(int SupplyID);
        void Add(SupplyDto supply);
        void Update(SupplyDto supply);
        void Delete(int SupplyID);
        IList<SupplyDto> GetList();
        IList<SupplyDto> ExportSupply();
    }
}
