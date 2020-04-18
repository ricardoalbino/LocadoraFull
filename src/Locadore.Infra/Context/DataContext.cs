using Locadora.Domain.Models;
using Locadora.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Infra.Context
{
    public class DataContext : DbContext
    {

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Filme> Filmes { get; set; }
  
       
       
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);

            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new FilmeMap());
       
        }

    }
   
}
