using GymCenter.Core.Domain.Abstract;
using GymCenter.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GymCenter.Core.DataAccess.SqlSever
{
    public class SqlServiceRepository : SqlRepositoryBase<Service>, IServiceRepository
    {
        public SqlServiceRepository(string connectionString) : base(connectionString) { }

        public override void Add(Service entity)
        {
            using(var connection = SqlConnection)
            {
                //connection.Open();

                string query = "Insert into Services output INSERTED.ID values(@Name,@Price)";

                var cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("Name", entity.Name);

                cmd.Parameters.AddWithValue("Price", entity.Price);

                entity.Id = Convert.ToInt32(cmd.ExecuteScalar());
            }
        }


        public override void Update(Service entity)
        {
            using(var connection = SqlConnection)
            {
               // connection.Open();

                string query = "Update Services set Name = @Name, Price= @Price where Id = @Id";

                var cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("Name", entity.Name);
                cmd.Parameters.AddWithValue("Price", entity.Price);
                cmd.Parameters.AddWithValue("Id", entity.Id);

                cmd.ExecuteNonQuery();
            }
        }

        public override Service Get(int id)
        {
            using(var connection = SqlConnection)
            {
                string query = "Select * from Services where id = @id";

                var cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("id", id);

                var reader = cmd.ExecuteReader();

                if(reader.Read())
                {
                    return GetFromReader(reader);
                }
                else
                {
                    return null;
                }
            }
        }

        public override List<Service> Get()
        {
            using(var connection = SqlConnection)
            {
                var cmd = new SqlCommand("select * from Services", connection);

                var reader = cmd.ExecuteReader();

                var services = new List<Service>();

                while(reader.Read())
                {
                    services.Add(GetFromReader(reader));
                }

                return services;
            }
        }

        public void Delete(int id)
        {
            using(var con = SqlConnection)
            {
                var cmd = new SqlCommand("delete from services where id = @id", con);

                cmd.Parameters.AddWithValue("id", id);

                cmd.ExecuteNonQuery();
            }
        }


        private Service GetFromReader(SqlDataReader reader)
        {
            var service = new Service
            {
                Id = Convert.ToInt32(reader["Id"]),
                Name = reader["Name"].ToString(),
                Price = Convert.ToDecimal(reader["Price"])
            };

            return service;
        }
    }
}
