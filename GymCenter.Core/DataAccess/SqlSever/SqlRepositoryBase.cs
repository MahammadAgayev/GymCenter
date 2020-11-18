using GymCenter.Core.Domain.Abstract;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GymCenter.Core.DataAccess.SqlSever
{
    public abstract class SqlRepositoryBase <T> : IRepository<T>
    {
        private readonly string _connectionString;

        public SqlRepositoryBase(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SqlConnection SqlConnection
        {
            get
            {
                var connection =  new SqlConnection(_connectionString);

                connection.Open();

                return connection;
            }
        }


        public abstract void Add(T entity);

        public abstract T Get(int id);

        public abstract List<T> Get();

        public abstract void Update(T entity);
    }
}
