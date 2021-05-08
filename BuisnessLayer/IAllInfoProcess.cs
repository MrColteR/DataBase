using System;
using System.Collections.Generic;
using System.Text;
using VRA.Dto;

namespace BuisnessLayer
{
    public interface IAllInfoProcess
    {
        IList<AllInfoDto> GetList();
        IList<AllInfoDto> Info();
    }
}
