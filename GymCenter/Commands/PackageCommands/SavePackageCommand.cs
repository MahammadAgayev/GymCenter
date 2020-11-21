using System.Collections.Generic;
using GymCenter.Core;
using GymCenter.Core.Domain.Entities;
using GymCenter.Models.PackageModels;
using GymCenter.ViewModels;

namespace GymCenter.Commands.PackageCommands
{
    public class SavePackageCommand : BaseCommand
    {
        private SavePackageViewModel _savePacakgeViewModel;

        public SavePackageCommand(SavePackageViewModel savePackageViewModel)
        {
            _savePacakgeViewModel = savePackageViewModel;
        }

        public override void Execute(object parameter)
        {
            var model = _savePacakgeViewModel.PackageModel;

            var package = new Package
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price,
                ColorHASH = model.ColorHASH
            };

            if (package.Id == 0)
                AddToDb(package, model);
            else
                Update(package, model);

            _savePacakgeViewModel.Window.Close();
        }


        private void AddToDb(Package package, SavePackageModel model)
        {
            foreach (var serviceModel in model.Services)
            {
                if (serviceModel.IsSelected)
                {
                    var service = new Service
                    {
                        Id = serviceModel.Id,
                        Name = serviceModel.Name
                    };

                    var packageService = new PackageService
                    {
                        Package = package,
                        Service = service
                    };

                    Kernel.DB.PackageServiceRepository.Add(packageService);
                }
            }

            Kernel.DB.PackageRepository.Add(package);
        }

        private void Update(Package package, SavePackageModel model)
        {
            var currentPackage = Kernel.DB.PackageRepository.Get(package.Id);

            //foreach (var serviceModel in model.Services)
            //{
            //    bool isNewService = true;

            //    foreach(var srv in currentPackage.Services)
            //    {
            //        if(srv.Id == serviceModel.Id)
            //        {
            //            if(!serviceModel.IsSelected)
            //            {
            //                Kernel.DB.PackageServiceRepository.Delete(new PackageService
            //                {
            //                    Package = package,
            //                    Service = new Service { Id = srv.Id }
            //                });
            //            }

            //            isNewService = serviceModel.IsSelected;
            //        }
            //    }

            //    if(isNewService)
            //    {
            //        Kernel.DB.PackageServiceRepository.Add(new PackageService
            //        {
            //            Package = package,
            //            Service = new Service { Id = serviceModel.Id }
            //        });
            //    }
            //}

            foreach(var srv in currentPackage.Services)
            {
                Kernel.DB.PackageServiceRepository.Delete(new PackageService { Package = package, Service = srv });
            }

            foreach(var serviceModel in model.Services)
            {
                if(serviceModel.IsSelected)
                   Kernel.DB.PackageServiceRepository.Add(new PackageService { Package = package, Service = new Service { Id = serviceModel.Id } });
            }

            Kernel.DB.PackageRepository.Update(package);
        }

        // Eger servisin Id-si current lerin icinde varsa
        // Eger servisin id-si currentlerde var indi yoxdusa silirem
        // Eger servisin id-si currentlerde yoxdu indi varsa elave edirem
    }
}
