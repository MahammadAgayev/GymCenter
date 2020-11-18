using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymCenter.Core;
using GymCenter.Managers;
using GymCenter.Models.ServiceModels;
using GymCenter.ViewModels;
using GymCenter.Views.UserControls;

namespace GymCenter.Commands.MainCommands
{
    public class ShowServiceCommand : BaseCommand
    {
        private MainViewModel _mainViewModel;

        private ServiceManager _serviceManager;

        public ShowServiceCommand(MainViewModel viewModel, ServiceManager serviceManager)
        {
            _mainViewModel = viewModel;
            _serviceManager = serviceManager;
        }

        public override void Execute(object parameter)
        {         
            var serviceViewModel = new ServiceViewModel();

            serviceViewModel.ServiceModels = _serviceManager.GetModels();

            var userControl = new ServicesUserControl();

            userControl.DataContext = serviceViewModel;

            _mainViewModel.Grid.Children.Clear();

            _mainViewModel.Grid.Children.Add(userControl);
        }
    }
}
