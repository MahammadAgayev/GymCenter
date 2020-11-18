using GymCenter.Core.Domain.Abstract;

namespace GymCenter.Core.Domain.Entities
{
    public abstract class EntityBase : IEntity
    {
        public int Id { get; set; }
    }
}
