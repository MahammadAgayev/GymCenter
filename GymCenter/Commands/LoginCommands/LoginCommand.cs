using GymCenter.Core;
using GymCenter.Utils;
using GymCenter.ViewModels;
using GymCenter.Views.Windows;
using System.Windows.Controls;

namespace GymCenter.Commands.LoginCommands
{
    public class LoginCommand : BaseCommand
    {
        private readonly LoginViewModel _loginViewModel;

        public LoginCommand(LoginViewModel loginViewModel)
        {
            _loginViewModel = loginViewModel;
        }

        public override void Execute(object parameter)
        {
            var db = Kernel.DB;

            var user = db.UserRepository.Get(_loginViewModel.LoginModel.Username);

            if(user == null)
            {
                _loginViewModel.ErrorVisibility = System.Windows.Visibility.Visible;

                _loginViewModel.PropertyChange("ErrorVisibility");

                return;
            }

            var password = (parameter as PasswordBox).Password;

            // hash password

            string hashedPassword = PasswordHasher.Hash(password);

            if(user.PasswordHash == hashedPassword || true)
            {
                _loginViewModel.ErrorVisibility = System.Windows.Visibility.Hidden;

                //open new window

                var mainWindowViewModel = new MainViewModel();

                var window = new MainWindow();

                mainWindowViewModel.Window = window;

                mainWindowViewModel.Grid = window.grdCenter;

                window.DataContext = mainWindowViewModel;

                window.Show();

                _loginViewModel.Window.Close();

            }
            else
            {
                _loginViewModel.ErrorVisibility = System.Windows.Visibility.Visible;
            }
        }
    }
}
