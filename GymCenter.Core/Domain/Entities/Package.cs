using System.Collections.Generic;

namespace GymCenter.Core.Domain.Entities
{
    public class Package : EntityBase
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public string ColorHASH { get; set; }

        public List<Service> Services { get; set; }
    }
}
