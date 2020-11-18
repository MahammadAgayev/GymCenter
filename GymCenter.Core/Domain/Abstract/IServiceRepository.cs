using GymCenter.Core.Domain.Entities;

namespace GymCenter.Core.Domain.Abstract
{
    public interface IServiceRepository : IRepository<Service>
    {
        void Delete(int id);
    }
}
