using Locadora.Domain.Interfaces;
using Locadora.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Locadora.Domain.Services
{
    public class FilmeService : BaseService, IFilmeService
    {


        private readonly IFilmeRepository _filmeRepository;

        public FilmeService(IFilmeRepository filmeRepository, INotificador notificador) : base(notificador)
        {
            _filmeRepository = filmeRepository;
        }

        public Task Adicionar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

      
        public Task Remover(Guid Id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
