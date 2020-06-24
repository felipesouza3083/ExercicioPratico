using ExercicioPratico.Domain.Models;
using ExercicioPratico.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExercicioPratico.Infra.Data.Context
{
    public class SqlContext: DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options):
            base(options)
        {

        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Usuario> Usuarios{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new FornecedorMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());

            modelBuilder.Entity<Fornecedor>(entity =>
            {
                entity.HasIndex(f => f.Cnpj).IsUnique();
            });

            modelBuilder.Entity<Usuario>(entity => 
            {
                entity.HasIndex(u => u.Email).IsUnique();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
