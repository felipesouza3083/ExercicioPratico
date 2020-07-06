using ExercicioPratico.Application.Commands.Produtos;
using ExercicioPratico.Application.Interfaces;
using ExercicioPratico.Domain.DTOs;
using ExercicioPratico.Domain.Interfaces.Caching;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

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
