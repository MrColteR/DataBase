using System;
using System.Collections.Generic;
using System.Text;
using VRA.DataAccess.Entities;
using System.Data.SqlClient;


namespace VRA.DataAccess
{
    public class SupplierDao : BaseDao, ISupplierDao 
    {
        
        private static Supplier CreateSupplier(SqlDataReader reader)
        {
            Supplier supplier = new Supplier();
            supplier.SupplierID = reader.GetInt32(reader.GetOrdinal("SupplierID"));
            supplier.Name = reader.GetString(reader.GetOrdinal("Name"));
            supplier.Phone = reader.GetString(reader.GetOrdinal("Phone"));
            supplier.Address = reader.GetString(reader.GetOrdinal("Address"));

            return supplier;
        }
        public Supplier Get(int supplierID)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT [SupplierID], [Name], [Address], [Phone] FROM [Supplier] WHERE [SupplierID] = @SupplierID";
                    cmd.Parameters.AddWithValue("@SupplierID", supplierID);
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            return CreateSupplier(dataReader);
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }
        public void Add(Supplier supplier)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO [Supplier] ([Name],[Address],[Phone]) VALUES (@Name, @Address, @Phone)";
                    cmd.Parameters.AddWithValue("@Name", supplier.Name);
                    cmd.Parameters.AddWithValue("@Address", supplier.Address);
                    cmd.Parameters.AddWithValue("@Phone", supplier.Phone);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Update(Supplier supplier)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE [Supplier] SET [Name] = @Name, [Address] = @Address,[Phone] = @Phone WHERE [SupplierID] = @SupplierID";
                    cmd.Parameters.AddWithValue("@Name", supplier.Name);
                    cmd.Parameters.AddWithValue("@Address", supplier.Address);
                    cmd.Parameters.AddWithValue("@Phone", supplier.Phone);
                    cmd.Parameters.AddWithValue("@SupplierID", supplier.SupplierID);
                    cmd.ExecuteNonQuery();
                }

            }
        }
        public void Delete(int supplierID)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Supplier WHERE SupplierID = @SupplierID";
                    cmd.Parameters.AddWithValue("@SupplierID", supplierID);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public IList<Supplier> GetList()
        {
            //SELECT[SupplierID], [Name], [Address], [Phone] FROM[Supplier] WHERE[Supplier ID]
            IList<Supplier> supplier = new List<Supplier>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT[SupplierID], [Name], [Address], [Phone] FROM[Supplier]";
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            supplier.Add(CreateSupplier(dataReader));
                        }
                    }
                }
            }

            return supplier;
        }
        public IList<Supplier> SearchSupplier(string Name)
        {
            IList<Supplier> supplier = new List<Supplier>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT [SupplierID], [Name], [Address], [Phone] FROM [Supplier] ";
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            if (dataReader.GetString(dataReader.GetOrdinal("Name")).ToLower().Contains(Name.ToLower()))
                                supplier.Add(CreateSupplier(dataReader));
                        }
                    }
                }
            }

            return supplier;
        }

        public IList<Supplier> ExportSupplier()
        {
            IList<Supplier> supplier = new List<Supplier>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT [SupplierID], [Name], [Address], [Phone] FROM [Supplier] ";
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            supplier.Add(CreateSupplier(dataReader));
                        }
                    }
                }
            }

            return supplier;
        }
    }
}
