using System;
using System.Collections.Generic;
using System.Text;

namespace BuisnessLayer
{
    public class ProcessFactory
    {
        public static ISupplierProcess GetSupplierProcess()
        {
            return new SupplierProcess();
        }
        public static ISupplyProcess GetSupplyProcess()
        {
            return new SupplyProcess();
        }
        public static IDetailsProcess GetDetailsProcess()
        {
            return new DetailsProcess();
        }
        public static IHistoryPriceProcess GetHistoryPriceProcess()
        {
            return new HistoryPriceProcess();
        }
        public static IDetailInDeliveryProcess GetDetailInDeliveryProcess()
        {
            return new DetailInDeliveryProcess();
        }
        public static IAllInfoProcess GetAllInfoProcess()
        {
            return new AllInfoProcess();
        }
    }
}
