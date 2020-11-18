using System.Windows.Controls;
using System.Windows.Input;
using GymCenter.Commands;
using GymCenter.Commands.MainCommands;

namespace GymCenter.ViewModels
{
    public class MainViewModel : BaseWindowViewModel
    {
        public MainViewModel()
        {
            ShowPackages = new ShowPackagesCommand(this);
            ShowServices = new ShowServiceCommand(this, new Managers.ServiceManager());
        }

        public BaseCommand ShowPackages { get; set; }

        public BaseCommand ShowServices { get; set; }

        public Grid Grid;
    }
}
