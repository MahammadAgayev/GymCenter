using System.IO;

namespace GymCenter.Managers
{
    public class Config
    {
        public string Database { get; set; }
        public string DbName { get; set; }
        public bool WindowsAuthentication { get; set; }
        public string DbUsername { get; set; }
        public string DbPassword { get; set; }
    }


    public class ConfigManager
    {
        private static string _configPath = @"C:\Users\magayev\Desktop\config.txt";

        private static Config _config;

        public ConfigManager()
        {
        }

        public void Save(Config config)
        {
            File.WriteAllText(_configPath, $"{config.Database},{config.DbName},{config.WindowsAuthentication},{config.DbUsername},{config.DbPassword}");
        }

        public static Config Get()
        {
            if(_config == null)
            {
                string config = File.ReadAllText(_configPath);

                var configs = config.Split(',');

                _config = new Config();

                _config.Database = configs[0];
                _config.DbName = configs[1];
                _config.WindowsAuthentication = bool.Parse(configs[2]);
                _config.DbUsername = configs[3];
                _config.DbPassword = configs[4];
            }

            return _config;
        }

        public static bool HasConfig()
        {
            return File.Exists(_configPath);
        }
    }
}
