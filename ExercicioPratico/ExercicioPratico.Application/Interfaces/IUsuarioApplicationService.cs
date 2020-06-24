using ExercicioPratico.Application.Commands.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExercicioPratico.Application.Interfaces
{
    public interface IUsuarioApplicationService : IDisposable
    {
        void Add(CreateUsuarioCommand command);
        string Authenticate(AuthenticateUsuarioCommand command);
    }
}
