using GymCenter.Core.DataAccess.SqlSever;
using GymCenter.Core.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymCenter.Core
{
    public static class Kernel
    {

        private static string _connectionString;
        public static string ConnectionString 
        {
            set
            {
                if(_connectionString == null)
                {
                    _connectionString = value;
                }
                else
                {
                    throw new InvalidOperationException("Connection string can be set only once");
                }
            }
        }


        private static IUnitOfWork _db;
        public static IUnitOfWork DB
        {
            get
            {
                if(_connectionString == null)
                {
                    throw new InvalidOperationException("Please set connection string before creating DB");
                }

                if(_db == null)
                {
                    _db = new SqlUnitWork(_connectionString);
                }

                return _db;
            }
        }
    }
}
