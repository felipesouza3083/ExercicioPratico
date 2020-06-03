using System;
using System.Collections.Generic;
using System.Text;

namespace ExercicioPratico.Domain.Models
{
    public class Categoria
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public Categoria()
        {

        }

        public Categoria(Guid id, string nome, string descricao)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
        }

        #region Produtos

        public List<Produto> Produtos { get; set; }

        #endregion
    }
}
