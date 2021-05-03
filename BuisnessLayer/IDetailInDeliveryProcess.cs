using System;
using System.Collections.Generic;
using System.Text;
using VRA.Dto;

namespace BuisnessLayer
{
    public interface IDetailInDeliveryProcess
    {
        DetailInDeliveryDto Get(int Number);
        IList<DetailInDeliveryDto> GetList();
    }
}
