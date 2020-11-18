using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var selectedService = _serviceViewModel.SelectedServiceModel;
            Kernel.DB.ServiceRepository.Delete(selectedService.Id);

            _serviceViewModel.ServiceModels.Remove(selectedService);
        }
    }
}
