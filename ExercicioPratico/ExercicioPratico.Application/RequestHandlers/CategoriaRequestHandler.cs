using ExercicioPratico.Application.Commands.Categorias;
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
    public class CategoriaRequestHandler : 
        IRequestHandler<CreateCategoriaCommand>,
        IRequestHandler<UpdateCategoriaCommand>,
        IRequestHandler<DeleteCategoriaCommand>,
        IDisposable
    {
        private readonly IMediator mediator;
        private readonly ICategoriaDomainService categoriaDomainService;

        public CategoriaRequestHandler(IMediator mediator, ICategoriaDomainService categoriaDomainService)
        {
            this.mediator = mediator;
            this.categoriaDomainService = categoriaDomainService;
        }

        public Task<Unit> Handle(CreateCategoriaCommand request, CancellationToken cancellationToken)
        {
            var categoria = new Categoria
            {
                Id = Guid.NewGuid(),
                Nome = request.Nome,
                Descricao = request.Descricao
            };
            var validation = new CategoriaValidation().Validate(categoria);
            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);

            categoriaDomainService.Add(categoria);

            mediator.Publish(new CategoriaNotification
            {
                Categoria = categoria,
                Action = ActionNotification.Criar
            });

            return Task.FromResult(new Unit());
        }

        public Task<Unit> Handle(UpdateCategoriaCommand request, CancellationToken cancellationToken)
        {
            var categoria = categoriaDomainService.GetById(Guid.Parse(request.Id));

            if (categoria == null)
                throw new Exception("Categoria não encontrada.");

            categoria.Nome = request.Nome;
            categoria.Descricao = request.Descricao;

            var validation = new CategoriaValidation().Validate(categoria);
            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);

            categoriaDomainService.Update(categoria);

            mediator.Publish(new CategoriaNotification
            {
                Categoria = categoria,
                Action = ActionNotification.Atualizar
            });

            return Task.FromResult(new Unit());
        }

        public Task<Unit> Handle(DeleteCategoriaCommand request, CancellationToken cancellationToken)
        {
            var categoria = categoriaDomainService.GetById(Guid.Parse(request.Id));

            if (categoria == null)
                throw new Exception("Categoria não encontrada.");

            categoriaDomainService.Remove(categoria);

            mediator.Publish(new CategoriaNotification
            {
                Categoria = categoria,
                Action = ActionNotification.Excluir
            });

            return Task.FromResult(new Unit());
        }

        public void Dispose()
        {
            categoriaDomainService.Dispose();
        }
    }
}
