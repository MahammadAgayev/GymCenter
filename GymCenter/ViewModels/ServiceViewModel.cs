using System.Collections.ObjectModel;
using System.Windows.Input;
using GymCenter.Commands;
using GymCenter.Commands.MainCommands;
using GymCenter.Commands.ServiceCommands;
using GymCenter.Models.ServiceModels;

namespace GymCenter.ViewModels
{
    public class ServiceViewModel : BaseViewModel
    {
        public ObservableCollection<ServiceModel> ServiceModels { get; set; }

        public ServiceViewModel()
        {
            OpenSaveService = new OpenSaveServiceViewCommand(this, new Managers.ServiceManager());
            DeleteService = new DeleteServiceCommand(this);
            OpenEditService = new OpenEditServiceViewCommand(this);
        }

        public ICommand OpenSaveService { get; set; }
        public ICommand DeleteService { get; set; }
        public ICommand OpenEditService { get; set; }

        public ServiceModel SelectedServiceModel { get; set; } 
    }
}
