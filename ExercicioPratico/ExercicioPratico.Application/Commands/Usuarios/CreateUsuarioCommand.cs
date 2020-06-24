using System;
using System.Collections.Generic;
using System.Text;

namespace ExercicioPratico.Application.Commands.Usuarios
{
    public class CreateUsuarioCommand
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
