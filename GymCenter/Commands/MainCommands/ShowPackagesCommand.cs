using GymCenter.Managers;
using GymCenter.ViewModels;
using GymCenter.Views.UserControls;

namespace GymCenter.Commands.MainCommands
{
    public class ShowPackagesCommand : BaseCommand
    {
        private MainViewModel _mainViewModel;

        private PackageManager _packageManager;

        public ShowPackagesCommand(MainViewModel mainViewModel, PackageManager packageManager)
        {
            _mainViewModel = mainViewModel;
            _packageManager = packageManager;
        }

        public override void Execute(object parameter)
        {
            var userControl = new PackagesUserControl();

            var viewModel = new PackagesViewModel();

            viewModel.PackageModels = _packageManager.GetModels();

            userControl.DataContext = viewModel;

            _mainViewModel.Grid.Children.Clear();

            _mainViewModel.Grid.Children.Add(userControl);
        }
    }
}
