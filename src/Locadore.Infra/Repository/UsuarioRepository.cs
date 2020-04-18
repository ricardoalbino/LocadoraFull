using Locadora.Domain.Interfaces;
using Locadora.Domain.Models;
using Locadora.Infra.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Infra.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
       
        public UsuarioRepository(DataContext dataContext) : base(dataContext)
        {

        }

        public Task<Usuario> ObterFilmePorDataDeLancamento(DateTime data)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> ObterFilmePorGenero(string genero)
        {
            throw new NotImplementedException();
        }
    }
}
