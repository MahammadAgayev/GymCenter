using GymCenter.ViewModels;

namespace GymCenter.Commands.ServiceCommands
{
    public abstract class BaseServiceCommand : BaseCommand
    {
        protected SaveServiceViewModel _saveServiceViewModel;

        public BaseServiceCommand(SaveServiceViewModel viewModel)
        {
            _saveServiceViewModel = viewModel;
        }
    }
}
