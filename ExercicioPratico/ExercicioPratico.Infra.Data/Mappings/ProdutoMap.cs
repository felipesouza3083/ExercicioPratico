using ExercicioPratico.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExercicioPratico.Infra.Data.Mappings
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(p => p.Preco)
                .IsRequired();

            builder.Property(p => p.Quantidade)
                .IsRequired();

            builder.Property(p => p.DataCompra)
                .IsRequired();

            builder.HasOne(p => p.Categoria)
                .WithMany(c => c.Produtos)
                .HasForeignKey(c => c.CategoriaId);

            builder.HasOne(p => p.Fornecedor)
                .WithMany(f => f.Produtos)
                .HasForeignKey(c => c.FornecedorId);
        }
    }
}
