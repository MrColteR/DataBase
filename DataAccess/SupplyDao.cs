using System;
using System.Collections.Generic;
using System.Text;
using VRA.DataAccess.Entities;
using System.Data.SqlClient;

namespace VRA.DataAccess
{
    public class SupplyDao : BaseDao, ISupplyDao
    {
        private static Supply CreateSupply(SqlDataReader reader)
        {
            Supply supply = new Supply();
            supply.SupplierID = reader.GetInt32(reader.GetOrdinal("SupplierID"));
            supply.SupplyID = reader.GetInt32(reader.GetOrdinal("SupplyID"));
            supply.Amount = reader.GetInt32(reader.GetOrdinal("Amount"));
            supply.Date = reader.GetDateTime(reader.GetOrdinal("Date"));

            return supply;
        }
        public Supply Get(int supplyID)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT [SupplierID], [SupplyID], [Amount], [Date] FROM [Supply] WHERE [SupplierID] = @SupplyID";
                    cmd.Parameters.AddWithValue("@SupplyID", supplyID);
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            return CreateSupply(dataReader);
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }
        public void Add(Supply supply)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO [Supply] ([Amount],[Date],[SupplierID]) VALUES (@Amount, @Date, @SupplierID)"; 
                    cmd.Parameters.AddWithValue("@Amount", supply.Amount);
                    cmd.Parameters.AddWithValue("@Date", supply.Date);
                    cmd.Parameters.AddWithValue("SupplierID", supply.SupplierID);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Update(Supply supply)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE [Supply] SET [Amount] = @Amount, [Date] = @Date WHERE [SupplyID] = @SupplyID";
                    cmd.Parameters.AddWithValue("@Amount", supply.Amount);
                    cmd.Parameters.AddWithValue("@Date", supply.Date);
                    cmd.Parameters.AddWithValue("@SupplyID", supply.SupplyID);
                    cmd.ExecuteNonQuery();
                }

            }
        }
        public void Delete(int supplyID)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Supply WHERE SupplyID = @SupplyID";
                    cmd.Parameters.AddWithValue("@SupplyID", supplyID);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public IList<Supply> GetList()
        {
            IList<Supply> supply = new List<Supply>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT[SupplyID], [SupplierID], [Amount], [Date] FROM[Supply]";
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            supply.Add(CreateSupply(dataReader));
                        }
                    }
                }
            }

            return supply;
        }
        public IList<Supply> ExportSupply()
        {
            IList<Supply> supply = new List<Supply>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT[SupplyID], [SupplierID], [Amount], [Date] FROM[Supply]";
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while(dataReader.Read())
                        {
                            supply.Add(CreateSupply(dataReader));
                        }
                    }
                }
            }

            return supply;
        }
    }
}
