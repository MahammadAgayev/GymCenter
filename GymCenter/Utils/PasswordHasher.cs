using System.Security.Cryptography;
using System.Text;

namespace GymCenter.Utils
{
    public static class PasswordHasher
    {
        public static string Hash(string data)
        {
            using(var hasher = new SHA256CryptoServiceProvider())
            {
                byte[] dataBuffer = Encoding.UTF8.GetBytes(data);
                byte[] hashedDataBuffer = hasher.ComputeHash(dataBuffer);

                var stBuilder = new StringBuilder();

                foreach (var item in hashedDataBuffer)
                {
                    stBuilder.Append(item.ToString("x2"));
                }

                return stBuilder.ToString();
            }
        }
    }
}
