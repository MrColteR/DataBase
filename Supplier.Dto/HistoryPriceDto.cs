using System;
using System.Collections.Generic;
using System.Text;

namespace VRA.Dto
{
    public class HistoryPriceDto
    {
        public int HistoryID { get; set; }
        public int SupplierID { get; set; }
        public int DetailsID { get; set; }
        public int NewPrice { get; set; }
        public DateTime DateOfChangePrice { get; set; }
    }
}
