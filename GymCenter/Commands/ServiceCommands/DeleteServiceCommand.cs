using System.Windows;
using GymCenter.Core;
using GymCenter.ViewModels;

namespace GymCenter.Commands.ServiceCommands
{
    public class DeleteServiceCommand : BaseCommand
    {
        private ServiceViewModel _serviceViewModel;

        public DeleteServiceCommand(ServiceViewModel viewModel) 
        {
            _serviceViewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            var db = Kernel.DB;

            var selectedService = _serviceViewModel.SelectedServiceModel;

            var packages = db.PackageRepository.Get();

            bool canDelete = true;

            foreach (var pkg in packages)
            {
                foreach (var svc in pkg.Services)
                {
                    if(svc.Id ==  selectedService.Id)
                    {
                        canDelete = false;
                    }
                }
            }

            if(canDelete)
            {
                db.ServiceRepository.Delete(selectedService.Id);
                _serviceViewModel.ServiceModels.Remove(selectedService);
            }
            else
            {
                Warning("Cannot delete service because it's used by package.");
            }
        }
    }
}
