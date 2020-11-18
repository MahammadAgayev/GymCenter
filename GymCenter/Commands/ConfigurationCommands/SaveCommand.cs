using System.Data.SqlClient;
using System.Windows.Controls;
using GymCenter.Core;
using GymCenter.Managers;
using GymCenter.ViewModels;
using GymCenter.Views.Windows;

namespace GymCenter.Commands.ConfigurationCommands
{
    public class SaveCommand : BaseCommand
    {
        private ConfigurationViewModel _configurationViewModel;

        private ConfigManager _configManager;

        public SaveCommand(ConfigurationViewModel viewModel)
        {
            _configurationViewModel = viewModel;

            _configManager = new ConfigManager();
        }


        public override void Execute(object parameter)
        {
            var config = new Config();

            config.Database = _configurationViewModel.Database;
            config.DbPassword = _configurationViewModel.Password;
            config.DbName = _configurationViewModel.DbName;
            config.DbUsername = _configurationViewModel.Username;
            config.WindowsAuthentication = _configurationViewModel.WindowsAuthentication;

            _configManager.Save(config);

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.InitialCatalog = config.DbName;
            builder.DataSource = config.Database;
            builder.IntegratedSecurity = config.WindowsAuthentication;
            builder.Password = (parameter as PasswordBox).Password;

            if(config.DbUsername != null)
                builder.UserID = config.DbUsername;

            Kernel.ConnectionString = builder.ConnectionString;

            var loginViewModel = new LoginViewModel();

            var loginWindow = new LoginWindow();

            loginWindow.DataContext = loginViewModel;

            loginViewModel.Window = loginWindow;

            loginViewModel.Window.Show();

            _configurationViewModel.Window.Close();
        }
    }
}
