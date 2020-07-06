using ExercicioPratico.Application.Commands.Produtos;
using ExercicioPratico.Application.Notifications;
using ExercicioPratico.Domain.Interfaces.Services;
using ExercicioPratico.Domain.Models;
using ExercicioPratico.Domain.Validations;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExercicioPratico.Application.RequestHandlers
{
    public class ProdutoRequestHandler:
        IRequestHandler<CreateProdutoCommand>,
        IRequestHandler<UpdateProdutoCommand>,
        IRequestHandler<DeleteProdutoCommand>,
        IDisposable
    {
        private readonly IMediator mediator;
        private readonly IProdutoDomainService produtoDomainService;

        public ProdutoRequestHandler(IMediator mediator, IProdutoDomainService produtoDomainService)
        {
            this.mediator = mediator;
            this.produtoDomainService = produtoDomainService;
        }

        public Task<Unit> Handle(CreateProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = new Produto
            {
                Id = Guid.NewGuid(),
                Nome = request.Nome,
                Preco = request.Preco,
                DataCompra = request.DataCompra,
                Quantidade = request.Quantidade,
                CategoriaId = Guid.Parse(request.CategoriaId),
                FornecedorId = Guid.Parse(request.FornecedorId)
            };

            var validation = new ProdutoValidation().Validate(produto);
            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);

            produtoDomainService.Add(produto);

            mediator.Publish(new ProdutoNotification
            {
                Produto = produto,
                Action = ActionNotification.Criar
            });

            return Task.FromResult(new Unit());
        }

        public Task<Unit> Handle(UpdateProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = produtoDomainService.GetById(Guid.Parse(request.Id));

            produto.Nome = request.Nome;
            produto.Preco = request.Preco;
            produto.DataCompra = request.DataCompra;
            produto.Quantidade = request.Quantidade;
            produto.CategoriaId = Guid.Parse(request.CategoriaId);
            produto.FornecedorId = Guid.Parse(request.FornecedorId);

            var validation = new ProdutoValidation().Validate(produto);
            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);

            produtoDomainService.Update(produto);

            mediator.Publish(new ProdutoNotification
            {
                Produto = produto,
                Action = ActionNotification.Atualizar
            });

            return Task.FromResult(new Unit());
        }

        public Task<Unit> Handle(DeleteProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = produtoDomainService.GetById(Guid.Parse(request.Id));

            if (produto == null)
                throw new Exception("Produto não encontrado.");

            produtoDomainService.Remove(produto);

            mediator.Publish(new ProdutoNotification
            {
                Produto = produto,
                Action = ActionNotification.Excluir
            });

            return Task.FromResult(new Unit());
        }

        public void Dispose()
        {
            produtoDomainService.Dispose();
        }
    }
}
