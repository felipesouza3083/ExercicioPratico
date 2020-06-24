using System;
using System.Collections.Generic;
using System.Text;

namespace ExercicioPratico.Domain.Interfaces.Cryptography
{
    public interface IMD5service
    {
        string Encrypt(string value);
    }
}
