using System;
using System.Collections.Generic;
using System.Text;
using VRA.Dto;

namespace BuisnessLayer
{
    public interface IDetailsProcess
    {
        DetailsDto Get(int DetailsID);
        void Add(DetailsDto details);
        void Update(DetailsDto details);
        void Delete(int DetailsID);
        IList<DetailsDto> GetList();
        IList<DetailsDto> SearchDetail(string Name);
    }
}
