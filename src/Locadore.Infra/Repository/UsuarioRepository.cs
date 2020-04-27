using Locadora.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Locadora.Domain.Models;
using Locadora.Infra.Context;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
namespace Locadora.Infra.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
       
        public UsuarioRepository(DataContext dataContext) : base(dataContext)
        {

        }

        public Usuario Autenticar(string email, string password)
        {
            Usuario usuario = _dataContext.Usuarios.AsNoTracking()
           .Where(u => u.email == email && u.Password == password).FirstOrDefault();

            return usuario;
        }
    }
}
