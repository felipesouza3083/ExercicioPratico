using ExercicioPratico.Application.Commands.Categorias;
using ExercicioPratico.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExercicioPratico.Application.Services
{
    public class CategoriaApplicationService : ICategoriaApplicationService
    {
        private readonly IMediator mediator;

        public CategoriaApplicationService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public void Add(CreateCategoriaCommand command)
        {
            mediator.Send(command);
        }

        public void Update(UpdateCategoriaCommand command)
        {
            mediator.Send(command);
        }

        public void Remove(DeleteCategoriaCommand command)
        {
            mediator.Send(command);
        }

        public void Dispose()
        {
            
        }
    }
}
