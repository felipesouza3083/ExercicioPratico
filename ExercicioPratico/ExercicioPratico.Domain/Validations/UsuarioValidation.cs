using ExercicioPratico.Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExercicioPratico.Domain.Validations
{
    public class UsuarioValidation:AbstractValidator<Usuario>
    {
        public UsuarioValidation()
        {
            RuleFor(u => u.Id)
                .NotEmpty().WithMessage("Informe o ID do Usuário");

            RuleFor(u => u.Nome).
                NotEmpty().WithMessage("Nome do usuário obrigatório.").
                Length(6, 150).WithMessage("Nome deve ter de 6 a 150 caracteres."); 
            
            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("Email do usuário obrigatório.")
                .EmailAddress().WithMessage("Endereço de email inválido."); 
            
            RuleFor(u => u.Senha)
                .NotEmpty().WithMessage("Senha do usuário obrigatório.")
                .Length(6, 20).WithMessage("Senha deve ter de 6 a 20 caracteres.");

            RuleFor(u => u.DataCriacao)
                .NotEmpty().WithMessage("Informe a data de criação.");
        }
    }
}
