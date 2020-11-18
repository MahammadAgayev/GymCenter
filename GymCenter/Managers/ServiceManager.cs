using System.Collections.ObjectModel;

using GymCenter.Core;
using GymCenter.Models.ServiceModels;

namespace GymCenter.Managers
{
    public class ServiceManager
    {
        public ObservableCollection<ServiceModel> GetModels()
        {
            var services = Kernel.DB.ServiceRepository.Get();

            var serviceModels = new ObservableCollection<ServiceModel>();

            foreach (var service in services)
            {
                var model = new ServiceModel
                {
                    Id = service.Id,
                    Name = service.Name,
                    Price = service.Price
                };

                serviceModels.Add(model);
            }

            return serviceModels;
        }
    }
}
