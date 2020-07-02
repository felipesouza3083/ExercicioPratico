using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExercicioPratico.Application.Commands.Produtos
{
    public class DeleteProdutoCommand : IRequest
    {
        public string Id { get; set; }
    }
}
