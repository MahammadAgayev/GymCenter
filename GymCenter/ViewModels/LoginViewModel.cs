using GymCenter.Commands.LoginCommands;
using GymCenter.Models.LoginModels;
using System.Windows;

namespace GymCenter.ViewModels
{
    public class LoginViewModel : BaseWindowViewModel
    {
        public LoginCommand Login { get; set; }

        public LoginViewModel()
        {
            Login = new LoginCommand(this);

            LoginModel = new LoginModel();
        }

        public LoginModel LoginModel { get; set; }


        private Visibility errorVisibility = Visibility.Collapsed;
        public Visibility ErrorVisibility
        {
            get => errorVisibility;
            set
            {
                errorVisibility = value;
                PropertyChange("ErrorVisibility");
            }
        }
    }
}
