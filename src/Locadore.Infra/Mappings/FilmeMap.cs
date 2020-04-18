using Locadora.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Locadora.Infra.Mappings
{
    class FilmeMap : IEntityTypeConfiguration<Filme>
    {
        public void Configure(EntityTypeBuilder<Filme> builder)
        {
            builder.HasKey(keyExpression: f => f.Id);

            builder.Property(f => f.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(f => f.Genero)
                  .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(f => f.DataLançamento)
                 .IsRequired()
               .HasColumnType("DateTime");

            builder.ToTable("Filme");



        }
    }
}
