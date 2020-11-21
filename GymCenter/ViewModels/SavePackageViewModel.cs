using System.Windows.Input;
using GymCenter.Commands.PackageCommands;
using GymCenter.Models.PackageModels;

namespace GymCenter.ViewModels
{
    public class SavePackageViewModel : BaseWindowViewModel
    {
        public SavePackageViewModel()
        {
            SavePackage = new SavePackageCommand(this);
        }

        public ICommand SavePackage { get; set; }

        public SavePackageModel PackageModel { get; set; }
    }
}
