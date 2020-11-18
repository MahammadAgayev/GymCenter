using System;

using GymCenter.ViewModels;
using GymCenter.Views.Windows;

namespace GymCenter.Commands.ServiceCommands
{
    public class OpenEditServiceViewCommand : BaseCommand
    {
        private ServiceViewModel _serviceViewModel;

        public OpenEditServiceViewCommand(ServiceViewModel serviceViewModel)
        {
            _serviceViewModel = serviceViewModel;
        }

        public override void Execute(object parameter)
        {
            var window = new SaveServiceWindow();

            var viewModel = new SaveServiceViewModel();

            viewModel.Window = window;

            window.DataContext = viewModel;

            window.lblTitle.Content = "Edit Service";

            viewModel.ServiceModel = _serviceViewModel.SelectedServiceModel;

            window.ShowDialog();
        }
    }
}
