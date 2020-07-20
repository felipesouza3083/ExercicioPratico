using AutoMapper;
using ExercicioPratico.Application.Commands.Fornecedores;
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
    public class FornecedorRequestHandler :
        IRequestHandler<CreateFornecedorCommand>,
        IRequestHandler<UpdateFornecedorCommand>,
        IRequestHandler<DeleteFornecedorCommand>,
        IDisposable
    {
        private readonly IMediator mediator;
        private readonly IFornecedorDomainService fornecedorDomainService;
        private readonly IMapper mapper;

        public FornecedorRequestHandler(IMediator mediator, IFornecedorDomainService fornecedorDomainService, IMapper mapper)
        {
            this.mediator = mediator;
            this.fornecedorDomainService = fornecedorDomainService;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(CreateFornecedorCommand request, CancellationToken cancellationToken)
        {
            var fornecedor = mapper.Map<Fornecedor>(request);

            var validation = new FornecedorValidation().Validate(fornecedor);
            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);

            fornecedorDomainService.Add(fornecedor);

            await mediator.Publish(new FornecedorNotification
            {
                Fornecedor = fornecedor,
                Action = ActionNotification.Criar
            });

            return Unit.Value;
        }

        public async Task<Unit> Handle(UpdateFornecedorCommand request, CancellationToken cancellationToken)
        {
            var fornecedor = mapper.Map<Fornecedor>(request); 

            if (fornecedor == null)
                throw new Exception("Fornecedor não encontrado.");

            var validation = new FornecedorValidation().Validate(fornecedor);
            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);

            fornecedorDomainService.Update(fornecedor);

            await mediator.Publish(new FornecedorNotification
            {
                Fornecedor = fornecedor,
                Action = ActionNotification.Atualizar
            });

            return Unit.Value;
        }

        public async Task<Unit> Handle(DeleteFornecedorCommand request, CancellationToken cancellationToken)
        {
            var fornecedor = mapper.Map<Fornecedor>(request); 

            if (fornecedor == null)
                throw new Exception("Fornecedor não encontrado.");

            fornecedorDomainService.Remove(fornecedor);

            await mediator.Publish(new FornecedorNotification
            {
                Fornecedor = fornecedor,
                Action = ActionNotification.Excluir
            });

            return Unit.Value;
        }

        public void Dispose()
        {
            fornecedorDomainService.Dispose();
        }
    }
}
