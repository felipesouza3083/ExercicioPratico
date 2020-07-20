using AutoMapper;
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
        private readonly IMapper mapper;

        public CategoriaRequestHandler(IMediator mediator, ICategoriaDomainService categoriaDomainService, IMapper mapper)
        {
            this.mediator = mediator;
            this.categoriaDomainService = categoriaDomainService;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(CreateCategoriaCommand request, CancellationToken cancellationToken)
        {
            var categoria = mapper.Map<Categoria>(request);

            var validation = new CategoriaValidation().Validate(categoria);
            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);

            categoriaDomainService.Add(categoria);

            await mediator.Publish(new CategoriaNotification
            {
                Categoria = categoria,
                Action = ActionNotification.Criar
            });

            return Unit.Value;
        }

        public async Task<Unit> Handle(UpdateCategoriaCommand request, CancellationToken cancellationToken)
        {
            var categoria = mapper.Map<Categoria>(request);

            var validation = new CategoriaValidation().Validate(categoria);
            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);

            categoriaDomainService.Update(categoria);

            await mediator.Publish(new CategoriaNotification
            {
                Categoria = categoria,
                Action = ActionNotification.Atualizar
            });

            return Unit.Value;
        }

        public async Task<Unit> Handle(DeleteCategoriaCommand request, CancellationToken cancellationToken)
        {
            var categoria = mapper.Map<Categoria>(request); 

            if (categoria == null)
                throw new Exception("Categoria não encontrada.");

            categoriaDomainService.Remove(categoria);

            await mediator.Publish(new CategoriaNotification
            {
                Categoria = categoria,
                Action = ActionNotification.Excluir
            });

            return Unit.Value;
        }

        public void Dispose()
        {
            categoriaDomainService.Dispose();
        }
    }
}
