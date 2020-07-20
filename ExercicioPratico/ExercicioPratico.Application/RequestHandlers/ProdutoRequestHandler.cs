using AutoMapper;
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
    public class ProdutoRequestHandler :
        IRequestHandler<CreateProdutoCommand>,
        IRequestHandler<UpdateProdutoCommand>,
        IRequestHandler<DeleteProdutoCommand>,
        IDisposable
    {
        private readonly IMediator mediator;
        private readonly IProdutoDomainService produtoDomainService;
        private readonly IMapper mapper;

        public ProdutoRequestHandler(IMediator mediator, IProdutoDomainService produtoDomainService, IMapper mapper)
        {
            this.mediator = mediator;
            this.produtoDomainService = produtoDomainService;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(CreateProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = mapper.Map<Produto>(request);

            var validation = new ProdutoValidation().Validate(produto);
            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);

            produtoDomainService.Add(produto);

            await mediator.Publish(new ProdutoNotification
            {
                Produto = produto,
                Action = ActionNotification.Criar
            });

            return Unit.Value;
        }

        public async Task<Unit> Handle(UpdateProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = mapper.Map<Produto>(request);

            var validation = new ProdutoValidation().Validate(produto);
            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);

            produtoDomainService.Update(produto);

            await mediator.Publish(new ProdutoNotification
            {
                Produto = produto,
                Action = ActionNotification.Atualizar
            });

            return Unit.Value;
        }

        public async Task<Unit> Handle(DeleteProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = mapper.Map<Produto>(request);

            if (produto == null)
                throw new Exception("Produto não encontrado.");

            produtoDomainService.Remove(produto);

            await mediator.Publish(new ProdutoNotification
            {
                Produto = produto,
                Action = ActionNotification.Excluir
            });

            return Unit.Value;
        }

        public void Dispose()
        {
            produtoDomainService.Dispose();
        }
    }
}
