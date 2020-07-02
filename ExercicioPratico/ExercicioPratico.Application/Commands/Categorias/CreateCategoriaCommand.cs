using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExercicioPratico.Application.Commands.Categorias
{
    public class CreateCategoriaCommand : IRequest
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
