using System;
using System.Collections.Generic;
using System.Text;
using VRA.DataAccess.Entities;
using System.Data.SqlClient;

namespace VRA.DataAccess
{
    public class DetailInDeliveryDao : BaseDao, IDetailInDeliveryDao
    {
        private static DetailInDelivery CreateDetailInDelivery(SqlDataReader reader)
        {
            DetailInDelivery detailInDelivery = new DetailInDelivery();
            detailInDelivery.Number = reader.GetInt32(reader.GetOrdinal("Number"));
            detailInDelivery.SupplyID = reader.GetInt32(reader.GetOrdinal("SupplyID"));
            detailInDelivery.HistoryID = reader.GetInt32(reader.GetOrdinal("HistoryID"));
            detailInDelivery.DetailID = reader.GetInt32(reader.GetOrdinal("DetailsID"));

            return detailInDelivery;
        }
        public DetailInDelivery Get(int Number)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT [Number],[SupplyID],[HistoryID],[DetailsID] FROM [DetailInDelivery] WHERE [Number] = @Number";
                    cmd.Parameters.AddWithValue("@Number", Number);
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            return CreateDetailInDelivery(dataReader);
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }
        public IList<DetailInDelivery> GetList()
        {
            IList<DetailInDelivery> detailInDelivery = new List<DetailInDelivery>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT [Number],[SupplyID],[HistoryID],[DetailsID] FROM [DetailInDelivery]";
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            detailInDelivery.Add(CreateDetailInDelivery(dataReader));
                        }
                    }
                }
            }

            return detailInDelivery;
        }
        public IList<DetailInDelivery> ExportDetailInDelivery()
        {
            IList<DetailInDelivery> detailInDeliveries = new List<DetailInDelivery>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT [Number],[SupplyID],[HistoryID],[DetailsID] FROM [DetailInDelivery]";
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            detailInDeliveries.Add(CreateDetailInDelivery(dataReader));
                        }
                    }
                }
            }

            return detailInDeliveries;
        }
    }
}
