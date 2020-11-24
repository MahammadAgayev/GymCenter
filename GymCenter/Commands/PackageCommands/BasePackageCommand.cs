using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymCenter.Managers;
using GymCenter.ViewModels;

namespace GymCenter.Commands.PackageCommands
{
    public abstract class BasePackageCommand : BaseCommand
    {
        protected PackagesViewModel _packageViewModel;

        protected PackageManager _pacakgeManager;

        public BasePackageCommand(PackagesViewModel viewModel, PackageManager packageManager)
        {
            _packageViewModel = viewModel;
            _pacakgeManager = packageManager;
        }


        //som eh
        protected void RefreshWindow()
        {
            int a = 6;
            _packageViewModel.PackageModels.Clear();

            var models = _pacakgeManager.GetModels();

            foreach (var model in models)
            {
                _packageViewModel.PackageModels.Add(model);
            }
        }
    }
}
