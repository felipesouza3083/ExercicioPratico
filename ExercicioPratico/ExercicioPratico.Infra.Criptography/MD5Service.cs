using ExercicioPratico.Domain.Interfaces.Cryptography;
using System;
using System.Security.Cryptography;
using System.Text;

namespace ExercicioPratico.Infra.Criptography
{
    public class MD5Service : IMD5service
    {
        public string Encrypt(string value)
        {
            var hash = new MD5CryptoServiceProvider()
                            .ComputeHash(Encoding.UTF8.GetBytes(value));

            var result = new StringBuilder();

            foreach (var item in hash)
            { //x2 -> Hexadecimal
                result.Append(item.ToString("x2"));
            }

            return result.ToString();
        }
    }
}
