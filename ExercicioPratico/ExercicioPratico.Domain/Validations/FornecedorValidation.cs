using ExercicioPratico.Domain.Models;
using ExercicioPratico.Domain.Validations.Commons;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExercicioPratico.Domain.Validations
{
    public class FornecedorValidation : AbstractValidator<Fornecedor>
    {
        public FornecedorValidation()
        {
            RuleFor(f => f.Id)
                .NotEmpty().WithMessage("Informe o Id do Fornecedor.");

            RuleFor(f => f.Nome)
                .NotEmpty().WithMessage("Informe o Id do Fornecedor.")
                .Length(3, 150).WithMessage("O nome deve ter entre 3 e 150 caracteres.");

            RuleFor(f => f.RazaoSocial)
                .NotEmpty().WithMessage("Informe o Id do Fornecedor.")
                .Length(3, 200).WithMessage("A Razão Social deve ter entre 3 e 150 caracteres.");

            RuleFor(f => f.Cnpj)
                .NotEmpty().WithMessage("Informe o Id do Fornecedor.")
                .Length(14).WithMessage("O CNPJ deve ter 14 caracteres.")
                .Must(CnpjValidation.IsValid).WithMessage("CNPJ inválido.");

            RuleFor(f => f.Email)
                .NotEmpty().WithMessage("Informe o Id do Fornecedor.")
                .Length(3, 200).WithMessage("O email deve ter entre 3 e 200 caracteres.")
                .EmailAddress().WithMessage("Informe um e-mail válido.");

            RuleFor(f => f.Telefone)
                .NotEmpty().WithMessage("Informe o Id do Fornecedor.")
                .Length(3, 11).WithMessage("O telefone deve ter entre 3 e 11 caracteres.")
                .Must(TelefoneValidation.IsValid).WithMessage("Telefone inválido.");
        }
    }
}
