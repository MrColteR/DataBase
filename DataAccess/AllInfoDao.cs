using System;
using System.Collections.Generic;
using System.Text;
using VRA.DataAccess.Entities;
using System.Data.SqlClient;

namespace VRA.DataAccess
{
    public class AllInfoDao : BaseDao, IAllInfoDao
    {
        private static AllInfo CreateInfo(SqlDataReader reader)
        {
            AllInfo allInfo = new AllInfo();
            allInfo.Name = reader.GetString(reader.GetOrdinal("Name"));
            allInfo.Address = reader.GetString(reader.GetOrdinal("Address"));
            allInfo.Phone = reader.GetString(reader.GetOrdinal("Phone"));
            allInfo.Amount = reader.GetInt32(reader.GetOrdinal("Amount"));
            allInfo.Date = reader.GetDateTime(reader.GetOrdinal("Date"));

            return allInfo;
        }
        public IList<AllInfo> GetList()
        {
            IList<AllInfo> allInfo = new List<AllInfo>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Supplier.Name, Supplier.Address, Supplier.Phone, Supply.Amount, Supply.Date FROM Supplier INNER JOIN Supply ON Supplier.SupplierID = Supply.SupplierID";
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            allInfo.Add(CreateInfo(dataReader));
                        }
                    }
                }
            }

            return allInfo;
        }
        public IList<AllInfo> Info()
        {
            IList<AllInfo> info = new List<AllInfo>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Supplier.Name, Supplier.Address, Supplier.Phone, Supply.Amount, Supply.Date FROM Supplier INNER JOIN Supply ON Supplier.SupplierID = Supply.SupplierID";
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            info.Add(CreateInfo(dataReader));
                        }
                    }
                }
            }

            return info;
        }
    }
}
