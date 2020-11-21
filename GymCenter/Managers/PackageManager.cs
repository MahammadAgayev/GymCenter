using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using GymCenter.Core;
using GymCenter.Models.PackageModels;

namespace GymCenter.Managers
{
    public class PackageManager
    {
        public ObservableCollection<PackageModel> GetModels()
        {
            var models = new ObservableCollection<Models.PackageModels.PackageModel>();

            var dbPackages = Kernel.DB.PackageRepository.Get();

            foreach (var pkg in dbPackages)
            {
                var model = new PackageModel
                {
                    Id = pkg.Id,
                    Name = pkg.Name,
                    Price = pkg.Price,
                    ColorHASH = pkg.ColorHASH,
                    Services = string.Join(",", pkg.Services.Select(x => x.Name))
                };

                models.Add(model);
            }

            return models;
        }
    }
}
