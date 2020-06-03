using ExercicioPratico.Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExercicioPratico.Domain.Validations
{
    public class CategoriaValidation : AbstractValidator<Categoria>
    {
        public CategoriaValidation()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("Informe o Id da Categoria");

            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Informe o Nome da Categoria")
                .Length(3, 150).WithMessage("Nome deve ter de 3 à 150 caracteres.");

            RuleFor(c => c.Descricao)
                .NotEmpty().WithMessage("Informe a Descrição da Categoria")
                .Length(3, 200).WithMessage("Descrição deve ter de 3 à 200 caracteres.");
        }
    }
}
