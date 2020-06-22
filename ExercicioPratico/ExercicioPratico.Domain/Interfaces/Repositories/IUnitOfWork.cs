using System;
using System.Collections.Generic;
using System.Text;

namespace ExercicioPratico.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        #region Escopo de Transações

        void BeginTransaction();
        void Commit();
        void Rollback();

        #endregion

        #region Repositórios

        IProdutoRepository ProdutoRepository { get; }
        IFornecedorRepository FornecedorRepository { get; }
        ICategoriaRepository CategoriaRepository { get; }

        #endregion
    }
}
