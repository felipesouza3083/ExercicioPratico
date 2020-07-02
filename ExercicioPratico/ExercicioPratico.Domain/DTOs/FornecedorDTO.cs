using System;
using System.Collections.Generic;
using System.Text;

namespace ExercicioPratico.Domain.DTOs
{
    public class FornecedorDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}
