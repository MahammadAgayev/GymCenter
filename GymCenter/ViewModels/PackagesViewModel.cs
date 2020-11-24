using System.Collections.ObjectModel;
using System.Windows.Input;
using GymCenter.Commands.PackageCommands;
using GymCenter.Models.PackageModels;

namespace GymCenter.ViewModels
{
    public class PackagesViewModel : BaseViewModel
    {
        public ObservableCollection<PackageModel> PackageModels { get; set; }

        public PackagesViewModel()
        {
            OpenSavePackage = new OpenSavePackageViewCommand(this, new Managers.PackageManager());
            OpenEditPackage = new OpenEditPackageViewCommand(this, new Managers.PackageManager());
            DeletePackage = new DeletePackageCommand(this, new Managers.PackageManager());
        }

        public ICommand OpenSavePackage { get; set; }
        public ICommand OpenEditPackage { get; set; }
        public ICommand DeletePackage { get; set; }

        public PackageModel SelectedPackage { get; set; }
    }
}
