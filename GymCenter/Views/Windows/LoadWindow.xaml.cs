using GymCenter.Core;
using GymCenter.Managers;
using GymCenter.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GymCenter.Views.Windows
{
    /// <summary>
    /// Interaction logic for LoadWindow.xaml
    /// </summary>
    public partial class LoadWindow : Window
    {
        public LoadWindow()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await Task.Delay(2000);

            if (ConfigManager.HasConfig())
            {
                var config = ConfigManager.Get();

                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

                builder.InitialCatalog = config.DbName;
                builder.DataSource = config.Database;
                builder.IntegratedSecurity = config.WindowsAuthentication;
                builder.Password = config.DbPassword;

                if(config.DbUsername != null)
                    builder.UserID = config.DbUsername;

                Kernel.ConnectionString = builder.ConnectionString;

                var loginViewModel = new LoginViewModel();

                var loginWindow = new LoginWindow();

                loginWindow.DataContext = loginViewModel;

                loginViewModel.Window = loginWindow;

                loginViewModel.Window.Show();

                this.Close();
            }
            else
            {
                var configurantionWindow = new ConfigurationWindow();

                var configurationViewModel = new ConfigurationViewModel();

                configurationViewModel.Window = configurantionWindow;

                configurantionWindow.DataContext = configurationViewModel;

                configurantionWindow.Show();

                this.Close();
            }
        }


        private string buildConnectionString()
        {
            


            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.InitialCatalog = "GymCenter";

            builder.DataSource = ".";
            builder.IntegratedSecurity = true;

            return builder.ConnectionString;
        }
    }
}
