using System.Security.Cryptography;
using System.Text;
using API.Services.Abstractions;

namespace API.Services
{
    public class Md5HashingService : IHashingService
    {
        public string ComputeHash(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2")); // Format as lowercase hexadecimal
                }
                return builder.ToString();
            }
        }
    }
}
