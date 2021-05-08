using System;
using System.Collections.Generic;
using System.Text;

namespace VRA.DataAccess
{
    public class DaoFactory
    {
        public static ISupplierDao GetSupplierDao()
        {
            return new SupplierDao();
        }
        public static ISupplyDao GetSupplyDao()
        {
            return new SupplyDao();
        }

        public static IDetailsDao GetDetailsDao()
        {
            return new DetailsDao();
        }
        public static IHistoryPriceDao GetHistoryPriceDao()
        {
            return new HistoryPriceDao();
        }
        public static IDetailInDeliveryDao GetDetailInDeliveryDao()
        {
            return new DetailInDeliveryDao();
        }
        public static IAllInfoDao GetAllInfo()
        {
            return new AllInfoDao();
        }
    }
}
