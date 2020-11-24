using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymCenter.Utils
{
    public static class LogHelper
    {
        private const string filepath = @"\logs\log.txt";

        public static void Log(string message)
        {
            if(!Directory.Exists(@"\logs"))
            {
                Directory.CreateDirectory(@"\logs");
            }

            using(var writer = new StreamWriter(filepath))
            {
                writer.WriteLine(message);
            }
        }
    }
}
