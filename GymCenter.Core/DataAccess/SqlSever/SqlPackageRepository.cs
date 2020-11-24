using GymCenter.Core.Domain.Abstract;
using GymCenter.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GymCenter.Core.DataAccess.SqlSever
{
    public class SqlPackageRepository : SqlRepositoryBase<Package>, IPackageRepository
    {
        public SqlPackageRepository(string connectionString) : base(connectionString) { }

        public override void Add(Package entity)
        {
            using(var connection = SqlConnection)
            {
                string query = "insert into Packages output inserted.Id values(@Name, @Price, @ColorHASH)";

                var cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("Name", entity.Name);
                cmd.Parameters.AddWithValue("Price", entity.Price);
                cmd.Parameters.AddWithValue("ColorHASH", entity.ColorHASH);

                entity.Id = Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public override void Update(Package entity)
        {
            using(var connection = SqlConnection)
            {
                string query = "Update Packages set Name = @Name, Price = @Price, ColorHASH = @ColorHASH where Id = @Id";

                var cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("id", entity.Id);
                cmd.Parameters.AddWithValue("Name", entity.Name);
                cmd.Parameters.AddWithValue("Price", entity.Price);
                cmd.Parameters.AddWithValue("ColorHASH", entity.ColorHASH);

                cmd.ExecuteNonQuery();
            }
        }

        public override Package Get(int id)
        {
            using(var connection = SqlConnection)
            {
                var query = "select * from Packages where id = @id";

                var cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@Id", id);

                var reader = cmd.ExecuteReader();

                if(reader.Read())
                {
                    var package = GetFromReader(reader);

                    reader.Close();
                    cmd.Dispose();

                    package.Services = new List<Service>();

                    string innerQuery = @"SELECT * FROM dbo.PackageServices ps
                                   LEFT JOIN dbo.Services s ON ps.ServiceId = s.Id
                                   WHERE ps.PackageId = @packageId";

                    var innerCmd = new SqlCommand(innerQuery, connection);

                    innerCmd.Parameters.AddWithValue("packageId", package.Id);

                    var innerReader = innerCmd.ExecuteReader();

                    while(innerReader.Read())
                    {
                        package.Services.Add(GetServiceFromReader(innerReader));
                    }

                    return package;
                }
                else
                {
                    return null;
                }

            }
        }

        public override List<Package> Get()
        {
            using(var connection = SqlConnection)
            {
                var query = "select * from Packages";

                var cmd = new SqlCommand(query, connection);

                var reader = cmd.ExecuteReader();

                var packages = new List<Package>();

                while (reader.Read())
                {
                    var package = GetFromReader(reader);
                    packages.Add(package);
                }

                reader.Close();
                cmd.Dispose();

                foreach (var package in packages)
                {
                    package.Services = new List<Service>();

                    string innerQuery = @"SELECT * FROM dbo.PackageServices ps
                                   LEFT JOIN dbo.Services s ON ps.ServiceId = s.Id
                                   WHERE ps.PackageId = @packageId";

                    var innerCmd = new SqlCommand(innerQuery, connection);

                    innerCmd.Parameters.AddWithValue("packageId", package.Id);

                    var innerReader = innerCmd.ExecuteReader();

                    while (innerReader.Read())
                    {
                        package.Services.Add(GetServiceFromReader(innerReader));
                    }

                    innerReader.Close();
                    innerCmd.Dispose();
                }

                return packages;
            }
        }

        public void Delete(int id)
        {
            using(var con = SqlConnection)
            {
                var cmd = new SqlCommand("delete from packages where Id = @id", con);

                cmd.Parameters.AddWithValue("id", id);

                cmd.ExecuteNonQuery();
            }
        }


        private Package GetFromReader(SqlDataReader reader)
        {
            var pack = new Package
            {
                Id = Convert.ToInt32(reader["Id"]),
                ColorHASH = reader["ColorHASH"].ToString(),
                Name = reader["Name"].ToString(),
                Price = Convert.ToDecimal(reader["Price"])
            };

            return pack;
        }


        private Service GetServiceFromReader(SqlDataReader reader)
        {
            var service = new Service
            {
                Id = Convert.ToInt32(reader["ServiceId"]),
                Name = reader["Name"].ToString(),
                Price = Convert.ToDecimal(reader["Price"])
            };

            return service;
        }
    }
}
