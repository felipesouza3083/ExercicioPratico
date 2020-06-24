using ExercicioPratico.Domain.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace ExercicioPratico.Domain.Interfaces.Services
{
    public interface IUsuarioDomainService:IBaseDomainService<Usuario>
    {
        Usuario Get(string email);
        Usuario Get(string email, string senha);
    }
}
