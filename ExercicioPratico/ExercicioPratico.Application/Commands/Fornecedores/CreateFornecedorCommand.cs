using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExercicioPratico.Application.Commands.Fornecedores
{
    public class CreateFornecedorCommand : IRequest
    {
        public string Nome { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}
