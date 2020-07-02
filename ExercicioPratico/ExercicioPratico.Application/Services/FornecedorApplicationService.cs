using ExercicioPratico.Application.Commands.Fornecedores;
using ExercicioPratico.Application.Interfaces;
using ExercicioPratico.Domain.Interfaces.Services;
using ExercicioPratico.Domain.Models;
using ExercicioPratico.Domain.Validations;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExercicioPratico.Application.Services
{
    public class FornecedorApplicationService : IFornecedorApplicationService
    {
        private readonly IMediator mediator;

        public FornecedorApplicationService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public void Add(CreateFornecedorCommand command)
        {
            mediator.Send(command);
        }

        public void Update(UpdateFornecedorCommand command)
        {
            mediator.Send(command);
        }

        public void Delete(DeleteFornecedorCommand command)
        {
            mediator.Send(command);
        }

        public void Dispose()
        {
            
        }
    }
}
