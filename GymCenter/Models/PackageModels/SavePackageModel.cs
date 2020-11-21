using System.Collections.Generic;
using GymCenter.Models.ServiceModels;

namespace GymCenter.Models.PackageModels
{
    public class SavePackageModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ColorHASH { get; set; }
        public List<ServiceListViewModel> Services { get; set; }
    }

    public class ServiceListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsSelected { get; set; }
    }
}
