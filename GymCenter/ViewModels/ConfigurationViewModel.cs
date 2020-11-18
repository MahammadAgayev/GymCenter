using System.Windows.Input;
using GymCenter.Commands.ConfigurationCommands;

namespace GymCenter.ViewModels
{
    public class ConfigurationViewModel : BaseWindowViewModel
    {
        public ConfigurationViewModel()
        {
            Save = new SaveCommand(this);
        }

        public ICommand Save { get; set; }

        public string Database { get; set; }
        public string DbName { get; set; }
        public bool WindowsAuthentication { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
    }
}
