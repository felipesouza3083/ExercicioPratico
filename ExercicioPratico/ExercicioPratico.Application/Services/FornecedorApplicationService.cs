using ExercicioPratico.Application.Commands.Fornecedores;
using ExercicioPratico.Application.Interfaces;
using ExercicioPratico.Domain.DTOs;
using ExercicioPratico.Domain.Interfaces.Caching;
using ExercicioPratico.Domain.Interfaces.Services;
using ExercicioPratico.Domain.Models;
using ExercicioPratico.Domain.Validations;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioPratico.Application.Services
{
    public class FornecedorApplicationService : IFornecedorApplicationService
    {
        private readonly IMediator mediator;
        private readonly IFornecedorCaching fornecedorCaching;

        public FornecedorApplicationService(IMediator mediator, IFornecedorCaching fornecedorCaching)
        {
            this.mediator = mediator;
            this.fornecedorCaching = fornecedorCaching;
        }

        public async Task Add(CreateFornecedorCommand command)
        {
            await mediator.Send(command);
        }

        public async Task Update(UpdateFornecedorCommand command)
        {
            await mediator.Send(command);
        }

        public async Task Delete(DeleteFornecedorCommand command)
        {
            await mediator.Send(command);
        }

        public List<FornecedorDTO> GetAll()
        {
            return fornecedorCaching.FindAll();
        }

        public FornecedorDTO GetById(string id)
        {
            return fornecedorCaching.FindyById(Guid.Parse(id));
        }
    }
}
