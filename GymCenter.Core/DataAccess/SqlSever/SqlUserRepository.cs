using GymCenter.Core.Domain.Abstract;
using GymCenter.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GymCenter.Core.DataAccess.SqlSever
{
    public class SqlUserRepository : SqlRepositoryBase<User>, IUserRepository
    {
        public SqlUserRepository(string connectionString) : base(connectionString)
        { }

        public override void Add(User entity)
        {
            throw new System.NotImplementedException();
        }

        public override User Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public override List<User> Get()
        {
            throw new System.NotImplementedException();
        }

        public User Get(string username)
        {
            using(var connection = SqlConnection)
            {
                //connection.Open();

                var cmd = new SqlCommand();

                cmd.Connection = connection;

                cmd.CommandText = "select * from Users where username = @username";

                cmd.Parameters.AddWithValue("username", username);

                var reader = cmd.ExecuteReader();

                if(reader.Read())
                {
                    var user = getUserFromReader(reader);

                    return user;
                }
                else
                {
                    return null;
                }
            }
        }

        public override void Update(User entity)
        {
            throw new System.NotImplementedException();
        }



        private User getUserFromReader(SqlDataReader reader)
        {
            var user = new User
            {
                Id = Convert.ToInt32(reader["Id"]),
                Username = reader["username"].ToString(),
                CreationDate = Convert.ToDateTime(reader["CreationDate"]),
                Email = reader["email"].ToString(),
                PasswordHash = reader["PasswordHash"].ToString(),
                PhoneNumber = reader["PhoneNumber"].ToString()
            };

            return user;
        }
    }
}
