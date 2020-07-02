using ExercicioPratico.Application.Commands.Produtos;
using ExercicioPratico.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExercicioPratico.Application.Services
{
    public class ProdutoApplicationService : IProdutoApplicationService
    {
        private readonly IMediator mediator;

        public ProdutoApplicationService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public void Add(CreateProdutoCommand command)
        {
            mediator.Send(command);
        }

        public void Update(UpdateProdutoCommand command)
        {
            mediator.Send(command);
        }

        public void Remove(DeleteProdutoCommand command)
        {
            mediator.Send(command);
        }

        public void Dispose()
        {
            
        }
    }
}
