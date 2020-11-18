using GymCenter.Managers;
using GymCenter.ViewModels;
using GymCenter.Views.Windows;

namespace GymCenter.Commands.ServiceCommands
{
    public class OpenSaveServiceViewCommand : BaseCommand
    {
        private ServiceViewModel _serviceViewModel;

        private ServiceManager _serviceManager;

        public  OpenSaveServiceViewCommand(ServiceViewModel serviceViewModel, ServiceManager serviceManager)
        {
            _serviceViewModel = serviceViewModel;
            _serviceManager = serviceManager;
        }

        public override void Execute(object parameter)
        {
            var window = new SaveServiceWindow();

            var viewModel = new SaveServiceViewModel();
            
            window.DataContext = viewModel;

            viewModel.Window = window;

            window.ShowDialog();

            _serviceViewModel.ServiceModels.Clear();

            foreach (var model in _serviceManager.GetModels())
            {
                _serviceViewModel.ServiceModels.Add(model);
            }
        }
    }
}
