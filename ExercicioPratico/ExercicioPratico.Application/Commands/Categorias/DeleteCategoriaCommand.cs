using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExercicioPratico.Application.Commands.Categorias
{
    public class DeleteCategoriaCommand : IRequest
    {
        public string Id { get; set; }
    }
}
