using ExercicioPratico.Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ExercicioPratico.Domain.Validations
{
    public class ProdutoValidation:AbstractValidator<Produto>
    {
        public ProdutoValidation()
        {
            RuleFor(p => p.Id)
               .NotEmpty().WithMessage("Informe o Id do Produto.");

            RuleFor(p => p.Nome)
               .NotEmpty().WithMessage("Informe o Nome do Produto.")
               .Length(3, 150).WithMessage("Nome deve ter entre 3 e 150 caracteres");

            RuleFor(p => p.Preco)
               .NotEmpty().WithMessage("Informe o Preço do Produto.");

            RuleFor(p => p.Quantidade)
               .NotEmpty().WithMessage("Informe a Quantidade do Produto.");

            RuleFor(p => p.DataCompra)
               .NotEmpty().WithMessage("Informe a Data de Compra do Produto.");

            RuleFor(p => p.CategoriaId)
               .NotEmpty().WithMessage("Informe a Categoria do Produto.");

            RuleFor(p => p.FornecedorId)
               .NotEmpty().WithMessage("Informe o Fornecedor do Produto.");
        }
    }
}
