using GymCenter.Core.Domain.Entities;

namespace GymCenter.Core.Domain.Abstract
{
    public interface IPackageRepository : IRepository<Package>
    {
        void Delete(int id);
    }
}
