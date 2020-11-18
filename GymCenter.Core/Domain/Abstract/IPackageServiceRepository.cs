using GymCenter.Core.Domain.Entities;

using System.Collections.Generic;

namespace GymCenter.Core.Domain.Abstract
{
    public interface IPackageServiceRepository : IRepository<PackageService>
    {
        List<PackageService> GetByPackageId(int packageId);
        List<PackageService> GetByServiceId(int serviceId);
    }
}
