using System.Collections.Generic;

using GymCenter.Core;
using GymCenter.Managers;
using GymCenter.Models.PackageModels;
using GymCenter.ViewModels;
using GymCenter.Views.Windows;

namespace GymCenter.Commands.PackageCommands
{
    public class OpenEditPackageViewCommand : BaseOpenPackageCommand
    {
        public OpenEditPackageViewCommand(PackagesViewModel packagesViewModel, PackageManager packageManager) 
            : base(packagesViewModel, packageManager)  
        {
        }

        public override void Execute(object parameter)
        {
            var selectedModel = _packageViewModel.SelectedPackage;

            var window = new SavePackageWindow();

            var viewModel = new SavePackageViewModel();

            viewModel.PackageModel = new SavePackageModel()
            {
                Id = selectedModel.Id,
                Name = selectedModel.Name,
                Price = selectedModel.Price,
                ColorHASH = selectedModel.ColorHASH
            };

            viewModel.PackageModel.Services = new List<Models.PackageModels.ServiceListViewModel>();

            var services = Kernel.DB.ServiceRepository.Get();

            var packageServices = Kernel.DB.PackageServiceRepository.GetByPackageId(selectedModel.Id);

            foreach (var service in services)
            {
                var model = new ServiceListViewModel()
                {
                    Id = service.Id,
                    IsSelected = false,
                    Name = service.Name
                };

                foreach (var pkgService in packageServices)
                {
                    if(pkgService.Service.Id == service.Id)
                    {
                        model.IsSelected = true;
                    }
                }

                viewModel.PackageModel.Services.Add(model);
            }

            viewModel.Window = window;

            window.DataContext = viewModel;

            window.lblTitle.Content = "Edit Package";

            window.ShowDialog();

            RefreshWindow();
        }
    }
}
