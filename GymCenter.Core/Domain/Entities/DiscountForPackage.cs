using GymCenter.Core.Domain.Enums;
using System;
namespace GymCenter.Core.Domain.Entities
{
    public class DiscountForPackage : EntityBase
    {
        public decimal Amount { get; set; }
        public Unit Unit { get; set; }
        public Package Package { get; set; }
        public bool DiscountApplicable { get; set; }
    }
}
