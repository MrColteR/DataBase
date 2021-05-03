using System;
using System.Collections.Generic;
using System.Text;

namespace VRA.Dto
{
    public class DetailsDto
    {
        public int DetailsID { get; set; }
        public int Article { get; set; }
        public int Price { get; set; }
        public string Note { get; set; }
        public string Name { get; set; }
    }
}
