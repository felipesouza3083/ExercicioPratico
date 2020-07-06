using ExercicioPratico.Application.Commands.Categorias;
using ExercicioPratico.Application.Interfaces;
using ExercicioPratico.Domain.DTOs;
using ExercicioPratico.Domain.Interfaces.Caching;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExercicioPratico.Application.Services
{
    public class CategoriaApplicationService : ICategoriaApplicationService
    {
        private readonly IMediator mediator;
        private readonly ICategoriaCaching categoriaCaching;

        public CategoriaApplicationService(IMediator mediator, ICategoriaCaching categoriaCaching)
        {
            this.mediator = mediator;
            this.categoriaCaching = categoriaCaching;
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

        public List<CategoriaDTO> GetAll()
        {
            return categoriaCaching.FindAll();
        }

        public CategoriaDTO GetById(string id)
        {
            return categoriaCaching.FindyById(Guid.Parse(id));
        }
    }
}
