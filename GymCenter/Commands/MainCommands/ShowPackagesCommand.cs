using System;
using GymCenter.ViewModels;
using GymCenter.Views.UserControls;
using System.Collections.ObjectModel;
using GymCenter.Core;
using GymCenter.Models.PackageModels;
using System.Linq;

namespace GymCenter.Commands.MainCommands
{
    public class ShowPackagesCommand : BaseCommand
    {
        public MainViewModel _mainViewModel;

        public ShowPackagesCommand(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public override void Execute(object parameter)
        {
            var userControl = new PackagesUserControl();

            var viewModel = new PackagesViewModel();

            viewModel.PackageModels = new ObservableCollection<Models.PackageModels.PackageModel>();

            var dbPackages = Kernel.DB.PackageRepository.Get();

            foreach (var pkg in dbPackages)
            {
                var model = new PackageModel
                {
                    Name = pkg.Name,
                    Price = pkg.Price,
                    ColorHASH = pkg.ColorHASH,
                    Services = string.Join(",", pkg.Services.Select(x => x.Name))
                };

                viewModel.PackageModels.Add(model);
            }

            userControl.DataContext = viewModel;

            _mainViewModel.Grid.Children.Clear();

            _mainViewModel.Grid.Children.Add(userControl);
        }
    }
}
