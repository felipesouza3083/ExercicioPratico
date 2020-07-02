using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExercicioPratico.Application.Commands.Fornecedores
{
    public class DeleteFornecedorCommand : IRequest
    {
        public string Id { get; set; }
    }
}
