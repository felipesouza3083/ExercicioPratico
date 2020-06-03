using ExercicioPratico.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExercicioPratico.Infra.Data.Mappings
{
    public class FornecedorMap : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Nome)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(f => f.RazaoSocial)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(f => f.Cnpj)
                .HasMaxLength(14)
                .IsRequired();

            builder.Property(f => f.Email)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(f => f.Telefone)
                .HasMaxLength(11)
                .IsRequired();
        }
    }
}
