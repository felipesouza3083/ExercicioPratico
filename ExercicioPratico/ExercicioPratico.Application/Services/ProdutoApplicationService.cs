using ExercicioPratico.Application.Commands.Produtos;
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
    public class ProdutoApplicationService : IProdutoApplicationService
    {
        private readonly IProdutoDomainService produtoDomainService;

        public ProdutoApplicationService(IProdutoDomainService produtoDomainService)
        {
            this.produtoDomainService = produtoDomainService;
        }

        public void Add(CreateProdutoCommand command)
        {
            var produto = new Produto
            {
                Id = Guid.NewGuid(),
                Nome = command.Nome,
                Preco = command.Preco,
                DataCompra = command.DataCompra,
                Quantidade = command.Quantidade,
                CategoriaId = Guid.Parse(command.CategoriaId),
                FornecedorId = Guid.Parse(command.FornecedorId)
            };

            var validation = new ProdutoValidation().Validate(produto);
            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);

            produtoDomainService.Add(produto);
        }

        public void Update(UpdateProdutoCommand command)
        {
            var produto = produtoDomainService.GetById(Guid.Parse(command.Id));

            produto.Nome = command.Nome;
            produto.Preco = command.Preco;
            produto.DataCompra = command.DataCompra;
            produto.Quantidade = command.Quantidade;
            produto.CategoriaId = Guid.Parse(command.CategoriaId);
            produto.FornecedorId = Guid.Parse(command.FornecedorId);

            var validation = new ProdutoValidation().Validate(produto);
            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);

            produtoDomainService.Update(produto);
        }

        public void Remove(DeleteProdutoCommand command)
        {
            var produto = produtoDomainService.GetById(Guid.Parse(command.Id));

            if (produto == null)
                throw new Exception("Produto não encontrado.");

            produtoDomainService.Remove(produto);
        }

        public void Dispose()
        {
            produtoDomainService.Dispose();
        }
    }
}
