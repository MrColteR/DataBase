using System;
using System.Collections.Generic;
using System.Text;
using VRA.DataAccess.Entities;
using System.Data.SqlClient;

namespace VRA.DataAccess
{
    public class HistoryPriceDao : BaseDao, IHistoryPriceDao
    {
        private static HistoryPrice CreateHistoryPrice(SqlDataReader reader)
        {
            HistoryPrice historyPrice = new HistoryPrice();
            historyPrice.HistoryID = reader.GetInt32(reader.GetOrdinal("HistoryID"));
            historyPrice.SupplierID = reader.GetInt32(reader.GetOrdinal("SupplierID"));
            historyPrice.DetailsID = reader.GetInt32(reader.GetOrdinal("DetailsID"));
            historyPrice.NewPrice = reader.GetInt32(reader.GetOrdinal("NewPrice"));
            historyPrice.DateOfChangePrice = reader.GetDateTime(reader.GetOrdinal("DateOfChangePrice"));

            return historyPrice;
        }
        public HistoryPrice Get(int HistoryID)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT [HistoryID], [SupplierID], [DetailsID], [NewPrice], [DateOfChangePrice] FROM [HistoryPrice] WHERE [HistoryID] = @HistoryID";
                    cmd.Parameters.AddWithValue("@HistoryID", HistoryID);
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            return CreateHistoryPrice(dataReader);
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }
        public void Add(HistoryPrice historyPrice)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO [HistoryPrice] ([DateOfChangePrice],[NewPrice],[SupplierID],[DetailsID]) VALUES (@DateOfChangePrice, @NewPrice, @SupplierID,  @DetailsID)";
                    cmd.Parameters.AddWithValue("@DateOfChangePrice", historyPrice.DateOfChangePrice);
                    cmd.Parameters.AddWithValue("@NewPrice", historyPrice.NewPrice);
                    cmd.Parameters.AddWithValue("@SupplierID", historyPrice.SupplierID);
                    cmd.Parameters.AddWithValue("@DetailsID", historyPrice.DetailsID);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Update(HistoryPrice historyPrice)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE [HistoryPrice] SET [DateOfChangePrice] = @DateOfChangePrice, [NewPrice] = @NewPrice,[SupplierID] = @SupplierID, [DetailsID] = @DetailsID WHERE [HistoryID] = @HistoryID";
                    cmd.Parameters.AddWithValue("@DateOfChangePrice", historyPrice.DateOfChangePrice);
                    cmd.Parameters.AddWithValue("@NewPrice", historyPrice.NewPrice);
                    cmd.Parameters.AddWithValue("@SupplierID", historyPrice.SupplierID);
                    cmd.Parameters.AddWithValue("@DetailsID", historyPrice.DetailsID);
                    cmd.Parameters.AddWithValue("@HistoryID", historyPrice.HistoryID);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Delete(int HistoryID)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM HistoryPrice WHERE HistoryID = @HistoryID";
                    cmd.Parameters.AddWithValue("@HistoryID", HistoryID);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public IList<HistoryPrice> GetList()
        {
            IList<HistoryPrice> historyPrice = new List<HistoryPrice>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT[HistoryID], [DateOfChangePrice], [NewPrice], [SupplierID], [DetailsID] FROM[HistoryPrice]";
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            historyPrice.Add(CreateHistoryPrice(dataReader));
                        }
                    }
                }
            }

            return historyPrice;
        }
    }
}
