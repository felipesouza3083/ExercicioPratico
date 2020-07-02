using System;
using System.Collections.Generic;
using System.Text;

namespace ExercicioPratico.Domain.DTOs
{
    public class ProdutoDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataCompra { get; set; }

        #region Relacionamentos

        public CategoriaDTO Categoria { get; set; }
        public FornecedorDTO Fornecedor { get; set; }

        #endregion
    }
}
