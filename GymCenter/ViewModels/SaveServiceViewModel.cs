using System.Windows.Input;
using GymCenter.Commands.ServiceCommands;
using GymCenter.Models.ServiceModels;

namespace GymCenter.ViewModels
{
    public class SaveServiceViewModel : BaseWindowViewModel
    {
        public SaveServiceViewModel()
        {
            SaveService = new SaveServiceCommand(this);

            ServiceModel = new ServiceModel();
        }

        public ICommand SaveService { get; set; }

        public ServiceModel ServiceModel { get; set; }
    }
}
