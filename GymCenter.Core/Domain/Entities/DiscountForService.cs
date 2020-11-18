using GymCenter.Core.Domain.Enums;

namespace GymCenter.Core.Domain.Entities
{
    public class DiscountForService : EntityBase
    {
        public decimal Amount { get; set; }
        public Unit Unit { get; set; }
        public Service Service { get; set; }
        public bool DiscountApplicable { get; set; }
    }
}
