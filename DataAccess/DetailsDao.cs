using System;
using System.Collections.Generic;
using System.Text;
using VRA.DataAccess.Entities;
using System.Data.SqlClient;

namespace VRA.DataAccess
{
    class DetailsDao : BaseDao, IDetailsDao
    {
        private static Details CreateDetails(SqlDataReader reader)
        {
            Details details = new Details();
            details.DetailsID = reader.GetInt32(reader.GetOrdinal("DetailsID"));
            details.Article = reader.GetInt32(reader.GetOrdinal("Article"));
            details.Price = reader.GetInt32(reader.GetOrdinal("Price"));
            details.Note = reader.GetString(reader.GetOrdinal("Note"));
            details.Name = reader.GetString(reader.GetOrdinal("Name"));

            return details;
        }
        public Details Get(int DetailsID)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT [DetailsID], [Article], [Price], [Note], [Name] FROM [Details] WHERE [DetailsID] = @DetailsID";
                    cmd.Parameters.AddWithValue("@DetailsID", DetailsID);
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            return CreateDetails(dataReader);
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }
        public void Add(Details details)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO [Details] ([Article],[Price],[Note],[Name]) VALUES (@Article, @Price, @Note, @Name)";
                    cmd.Parameters.AddWithValue("@Article", details.Article);
                    cmd.Parameters.AddWithValue("@Price", details.Price);
                    cmd.Parameters.AddWithValue("@Note", details.Note);
                    cmd.Parameters.AddWithValue("@Name", details.Name);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Update(Details details)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE [Details] SET [Article] = @Article, [Price] = @Price,[Note] = @Note, [Name] = @Name WHERE [DetailsID] = @DetailsID";
                    cmd.Parameters.AddWithValue("@Article", details.Article);
                    cmd.Parameters.AddWithValue("@Price", details.Price);
                    cmd.Parameters.AddWithValue("@Note", details.Note);
                    cmd.Parameters.AddWithValue("@Name", details.Name);
                    cmd.Parameters.AddWithValue("@DetailsID", details.DetailsID);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Delete(int DetailsID)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Details WHERE DetailsID = @DetailsID";
                    cmd.Parameters.AddWithValue("@DetailsID", DetailsID);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public IList<Details> GetList()
        {
            IList<Details> details = new List<Details>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT[DetailsID], [Article], [Price], [Note], [Name] FROM[Details]";
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            details.Add(CreateDetails(dataReader));
                        }
                    }
                }
            }

            return details;
        }
        public IList<Details> SearchDetail(string Name)
        {
            IList<Details> details = new List<Details>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT [DetailsID], [Article], [Price], [Note], [Name] FROM [Details]";
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        { 
                            if(dataReader.GetString(dataReader.GetOrdinal("Name")).ToLower().Contains(Name.ToLower()))
                            {
                                details.Add(CreateDetails(dataReader));
                            }
                        }
                    }
                }
            }

            return details;
        }
        public IList<Details> ExportDetails()
        {
            IList<Details> details = new List<Details>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT[DetailsID], [Article], [Price], [Note], [Name] FROM[Details]";
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            details.Add(CreateDetails(dataReader));
                        }
                    }
                }
            }

            return details;
        }
    }
}
