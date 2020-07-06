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

        public Task<Unit> Handle(CreateFornecedorCommand request, CancellationToken cancellationToken)
        {
            var fornecedor = new Fornecedor
            {
                Id = Guid.NewGuid(),
                Nome = request.Nome,
                Cnpj = request.Cnpj,
                Email = request.Email,
                RazaoSocial = request.RazaoSocial,
                Telefone = request.Telefone
            };

            var validation = new FornecedorValidation().Validate(fornecedor);
            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);

            fornecedorDomainService.Add(fornecedor);

            mediator.Publish(new FornecedorNotification
            {
                Fornecedor = fornecedor,
                Action = ActionNotification.Criar
            });

            return Task.FromResult(new Unit());
        }

        public Task<Unit> Handle(UpdateFornecedorCommand request, CancellationToken cancellationToken)
        {
            var fornecedor = fornecedorDomainService.GetById(Guid.Parse(request.Id));

            if (fornecedor == null)
                throw new Exception("Fornecedor não encontrado.");

            fornecedor.Nome = request.Nome;
            fornecedor.Cnpj = request.Cnpj;
            fornecedor.Email = request.Email;
            fornecedor.RazaoSocial = request.RazaoSocial;
            fornecedor.Telefone = request.Telefone;

            var validation = new FornecedorValidation().Validate(fornecedor);
            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);

            fornecedorDomainService.Update(fornecedor);

            mediator.Publish(new FornecedorNotification
            {
                Fornecedor = fornecedor,
                Action = ActionNotification.Atualizar
            });

            return Task.FromResult(new Unit());
        }

        public Task<Unit> Handle(DeleteFornecedorCommand request, CancellationToken cancellationToken)
        {
            var fornecedor = fornecedorDomainService.GetById(Guid.Parse(request.Id));

            if (fornecedor == null)
                throw new Exception("Fornecedor não encontrado.");

            fornecedorDomainService.Remove(fornecedor);

            mediator.Publish(new FornecedorNotification
            {
                Fornecedor = fornecedor,
                Action = ActionNotification.Excluir
            });

            return Task.FromResult(new Unit());
        }

        public void Dispose()
        {
            fornecedorDomainService.Dispose();
        }
    }
}
