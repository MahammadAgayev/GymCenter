using GymCenter.Core.Domain.Abstract;

namespace GymCenter.Core.DataAccess.SqlSever
{
    public class SqlUnitWork : IUnitOfWork
    {
        private readonly string _connectionString;

        public SqlUnitWork(string connectionString)
        {
            _connectionString = connectionString;
        }


        public IUserRepository UserRepository => new SqlUserRepository(_connectionString);

        public IPackageRepository PackageRepository => new SqlPackageRepository(_connectionString);

        public IServiceRepository ServiceRepository => new SqlServiceRepository(_connectionString);

        public IPackageServiceRepository PackageServiceRepository => new SqlPackageServiceRepository(_connectionString);

        public IDiscountForPackageRepository DiscountForPackageRepository => throw new System.NotImplementedException();

        public IDiscountForServiceRepository DiscountForServiceRepository => throw new System.NotImplementedException();
    }
}
