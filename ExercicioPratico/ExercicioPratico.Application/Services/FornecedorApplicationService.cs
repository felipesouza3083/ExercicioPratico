using ExercicioPratico.Application.Commands.Fornecedores;
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
    public class FornecedorApplicationService : IFornecedorApplicationService
    {
        private readonly IFornecedorDomainService fornecedorDomainService;

        public FornecedorApplicationService(IFornecedorDomainService fornecedorDomainService)
        {
            this.fornecedorDomainService = fornecedorDomainService;
        }

        public void Add(CreateFornecedorCommand command)
        {
            var fornecedor = new Fornecedor
            {
                Id = Guid.NewGuid(),
                Nome = command.Nome,
                Cnpj = command.Cnpj,
                Email = command.Email,
                RazaoSocial = command.RazaoSocial,
                Telefone = command.Telefone
            };

            var validation = new FornecedorValidation().Validate(fornecedor);
            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);

            fornecedorDomainService.Add(fornecedor);
        }

        public void Update(UpdateFornecedorCommand command)
        {
            var fornecedor = fornecedorDomainService.GetById(Guid.Parse(command.Id));

            if (fornecedor == null)
                throw new Exception("Fornecedor não encontrado.");

            fornecedor.Nome = command.Nome;
            fornecedor.Cnpj = command.Cnpj;
            fornecedor.Email = command.Email;
            fornecedor.RazaoSocial = command.RazaoSocial;
            fornecedor.Telefone = command.Telefone;

            var validation = new FornecedorValidation().Validate(fornecedor);
            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);

            fornecedorDomainService.Update(fornecedor);
        }

        public void Delete(DeleteFornecedorCommand command)
        {
            var fornecedor = fornecedorDomainService.GetById(Guid.Parse(command.Id));

            if (fornecedor == null)
                throw new Exception("Fornecedor não encontrado.");

            fornecedorDomainService.Remove(fornecedor);
        }

        public void Dispose()
        {
            fornecedorDomainService.Dispose();
        }
    }
}
