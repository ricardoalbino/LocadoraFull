using Locadora.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Domain.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {


        Usuario Autenticar(string email, string password);


    }
}
