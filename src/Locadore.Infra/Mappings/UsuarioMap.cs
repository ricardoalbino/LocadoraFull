using Locadora.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Infra.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(keyExpression: u => u.Id);

            builder.Property(u => u.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(u => u.Password)
               .IsRequired()
               .HasColumnType("varchar(100)");

            /*1 : 1 Usuario TEM N  Locacao*/
            //builder.HasMany(navigationExpression: u => u.Locacao)
            //   .WithOne(navigationExpression: l => l.Usuario)

            //   /*CHAVE ESTRANGEIRA  DO Usuario NA  TABELA Locacao*/
            //   .HasForeignKey(l => l.UsuarioID);




            ///*1 : 1 Usuario TEM N  Locacao*/
            //builder.HasMany(navigationExpression: u => u.Filmes)
            //   .WithOne(navigationExpression: f => f.Usuario)

            //   /*CHAVE ESTRANGEIRA  DO Usuario NA  TABELA Locacao*/
            //   .HasForeignKey(f => f.UsuarioID);


            builder.ToTable("Usuario");
        }
    }
}
