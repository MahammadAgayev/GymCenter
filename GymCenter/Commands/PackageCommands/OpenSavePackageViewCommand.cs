using GymCenter.Core;
using GymCenter.Managers;
using GymCenter.Models.PackageModels;
using GymCenter.ViewModels;
using GymCenter.Views.Windows;
using System.Collections.Generic;

namespace GymCenter.Commands.PackageCommands
{
    public class OpenSavePackageViewCommand : BaseOpenPackageCommand
    {
        public OpenSavePackageViewCommand(PackagesViewModel viewModel, PackageManager packageManager) : base(viewModel, packageManager)
        {
        }

        public override void Execute(object parameter)
        {
            var window = new SavePackageWindow();

            var viewModel = new SavePackageViewModel();

            viewModel.PackageModel = new Models.PackageModels.SavePackageModel();

            viewModel.PackageModel.Services = new List<Models.PackageModels.ServiceListViewModel>();

            var services = Kernel.DB.ServiceRepository.Get();

            foreach (var service in services)
            {
                var model = new ServiceListViewModel()
                {
                    Id = service.Id,
                    IsSelected = false,
                    Name = service.Name
                };

                viewModel.PackageModel.Services.Add(model);
            }

            window.DataContext = viewModel;

            viewModel.Window = window;

            window.ShowDialog();

            RefreshWindow();
        }
    }
}
