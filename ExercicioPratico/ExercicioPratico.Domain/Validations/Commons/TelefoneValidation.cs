using System;
using System.Collections.Generic;
using System.Text;

namespace ExercicioPratico.Domain.Validations.Commons
{
    public class TelefoneValidation
    {
        public static bool IsValid(string telefone)
        {
            return telefone.Length >= 10;
        }
    }
}
