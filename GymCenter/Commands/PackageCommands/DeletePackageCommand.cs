using GymCenter.Core;
using GymCenter.ViewModels;
using GymCenter.Core.Domain.Entities;
using GymCenter.Managers;

namespace GymCenter.Commands.PackageCommands
{
    public class DeletePackageCommand : BasePackageCommand
    {
        public DeletePackageCommand(PackagesViewModel viewModel, PackageManager packageManager) : base(viewModel, packageManager)
        {
        }

        public override void Execute(object parameter)
        {
            var selected = _packageViewModel.SelectedPackage;

            var db = Kernel.DB;

            var packageServices = db.PackageServiceRepository.GetByPackageId(selected.Id);

            foreach (var packageService in packageServices)
            {
                db.PackageServiceRepository.Delete(packageService);
            }

            db.PackageRepository.Delete(selected.Id);

            RefreshWindow();           
        }
    }
}
