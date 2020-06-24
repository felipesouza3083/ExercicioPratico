using ExercicioPratico.Domain.Interfaces.Repositories;
using ExercicioPratico.Infra.Data.Context;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExercicioPratico.Infra.Data.Repositories
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly SqlContext context;

        private IDbContextTransaction transaction;

        public UnitOfWork(SqlContext context)
        {
            this.context = context;
        }

        public void BeginTransaction()
        {
            transaction = context.Database.BeginTransaction();
        }

        public void Commit()
        {
            transaction.Commit();
        }

        public void Rollback()
        {
            transaction.Rollback();
        }

        public IProdutoRepository ProdutoRepository => new ProdutoRepository(context);

        public IFornecedorRepository FornecedorRepository => new FornecedorRepository(context);

        public ICategoriaRepository CategoriaRepository => new CategoriaRepository(context);

        public IUsuarioRepository UsuarioRepository => new UsuarioRepository(context);

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
