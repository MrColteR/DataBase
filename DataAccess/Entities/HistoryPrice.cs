using System;
using System.Collections.Generic;
using System.Text;

namespace VRA.DataAccess.Entities
{
    public class HistoryPrice
    {
        public int HistoryID;
        public int SupplierID;
        public int DetailsID;
        public int NewPrice;
        public DateTime DateOfChangePrice;
    }
}
