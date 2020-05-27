using System;
using System.Collections.Generic;
using System.Text;

namespace ExercicioPratico.Domain.Models
{
    public class Fornecedor
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public IList<Produto> Produtos { get; set; }

        public Fornecedor()
        {

        }

        public Fornecedor(Guid id, string nome, string razaoSocial, string cnpj, string email, string telefone)
        {
            Id = id;
            Nome = nome;
            RazaoSocial = razaoSocial;
            Cnpj = cnpj;
            Email = email;
            Telefone = telefone;
        }
    }
}
