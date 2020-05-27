using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Linq;

namespace ExercicioPratico.Domain.Models
{
    public class Produto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataCompra { get; set; }
        public Guid CategoriaId { get; set; }
        public Guid FornecedorId { get; set; }

        public Categoria Categoria { get; set; }
        public Fornecedor Fornecedor { get; set; }

        public Produto()
        {

        }

        public Produto(Guid id, string nome, decimal preco, int quantidade, DateTime dataCompra, Guid categoriaId, Guid fornecedorId)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
            Quantidade = quantidade;
            DataCompra = dataCompra;
            CategoriaId = categoriaId;
            FornecedorId = fornecedorId;
        }
    }
}
