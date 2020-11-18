namespace GymCenter.Core.Domain.Abstract
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IPackageRepository PackageRepository { get; }
        IServiceRepository ServiceRepository { get; }
        IPackageServiceRepository PackageServiceRepository { get; }
        IDiscountForPackageRepository DiscountForPackageRepository { get; }
        IDiscountForServiceRepository DiscountForServiceRepository { get; }
    }
}
