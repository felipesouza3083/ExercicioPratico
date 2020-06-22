using ExercicioPratico.Application.Commands.Categorias;
using ExercicioPratico.Application.Interfaces;
using ExercicioPratico.Domain.Interfaces.Services;
using ExercicioPratico.Domain.Models;
using ExercicioPratico.Domain.Validations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExercicioPratico.Application.Services
{
    public class CategoriaApplicationService : ICategoriaApplicationService
    {
        private readonly ICategoriaDomainService categoriaDomainService;

        public CategoriaApplicationService(ICategoriaDomainService categoriaDomainService)
        {
            this.categoriaDomainService = categoriaDomainService;
        }

        public void Add(CreateCategoriaCommand command)
        {
            var categoria = new Categoria 
            {
                Id = Guid.NewGuid(),
                Nome = command.Nome,
                Descricao = command.Descricao
            };
            var validation = new CategoriaValidation().Validate(categoria);
            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);

            categoriaDomainService.Add(categoria);
        }

        public void Update(UpdateCategoriaCommand command)
        {
            var categoria = categoriaDomainService.GetById(Guid.Parse(command.Id));

            if (categoria == null)
                throw new Exception("Categoria não encontrada.");

            categoria.Nome = command.Nome;
            categoria.Descricao = command.Descricao;

            var validation = new CategoriaValidation().Validate(categoria);
            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);
        }

        public void Remove(DeleteCategoriaCommand command)
        {
            var categoria = categoriaDomainService.GetById(Guid.Parse(command.Id));

            if (categoria == null)
                throw new Exception("Categoria não encontrada.");

            categoriaDomainService.Remove(categoria);
        }

        public void Dispose()
        {
            categoriaDomainService.Dispose();
        }
    }
}
