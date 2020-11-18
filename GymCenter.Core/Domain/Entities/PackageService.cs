namespace GymCenter.Core.Domain.Entities
{
    public class PackageService : EntityBase
    {
        public Package Package { get; set; }
        public Service Service { get; set; }
    }
}
