using ExercicioPratico.Application.Commands.Produtos;
using ExercicioPratico.Application.Interfaces;
using ExercicioPratico.Domain.DTOs;
using ExercicioPratico.Domain.Interfaces.Caching;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioPratico.Application.Services
{
    public class ProdutoApplicationService : IProdutoApplicationService
    {
        private readonly IMediator mediator;
        private readonly IProdutoCaching produtoCaching;

        public ProdutoApplicationService(IMediator mediator, IProdutoCaching produtoCaching)
        {
            this.mediator = mediator;
            this.produtoCaching = produtoCaching;
        }

        public async Task Add(CreateProdutoCommand command)
        {
            await mediator.Send(command);
        }

        public async Task Update(UpdateProdutoCommand command)
        {
            await mediator.Send(command);
        }

        public async Task Remove(DeleteProdutoCommand command)
        {
            await mediator.Send(command);
        }

        public List<ProdutoDTO> GetAll()
        {
            return produtoCaching.FindAll();
        }

        public ProdutoDTO GetById(string id)
        {
            return produtoCaching.FindyById(Guid.Parse(id));
        }
    }
}
