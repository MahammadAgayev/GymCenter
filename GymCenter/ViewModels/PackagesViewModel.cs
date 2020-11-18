using System.Collections.ObjectModel;
using System.Windows.Media;
using GymCenter.Core;
using GymCenter.Models.PackageModels;

namespace GymCenter.ViewModels
{
    public class PackagesViewModel : BaseViewModel
    {
        public ObservableCollection<PackageModel> PackageModels { get; set; }

        public PackagesViewModel()
        {
        }

        public PackageModel SelectedPackage { get; set; }
    }
}
