using GymCenter.Core.Domain.Entities;

namespace GymCenter.Core.Domain.Abstract
{
    public interface IUserRepository : IRepository<User>
    {
        User Get(string username);
    }
}
