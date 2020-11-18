using System.Windows.Media;

namespace GymCenter.Models.PackageModels
{
    public class PackageModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ColorHASH { get; set; }

        public string Services { get; set; }
    }
}
