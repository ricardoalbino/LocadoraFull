using Locadora.Domain.Interfaces;
using Locadora.Domain.Models;
using Locadora.Domain.Validations;
using System;
using System.Threading.Tasks;

namespace Locadora.Domain.Services
{
    public class UsuarioService : BaseService, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository, INotificador notificador)
            :base(notificador)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task Adicionar(Usuario usuario)
        {
            //Aqui são  validadas  todas  as  regras de  negocio
            //  Começando pela principal a Entidade

            // ! se  não for  um validator e  uma  entidade  return
            if (!ExecutarValidacao(new UsuarioValidation(), usuario)) return; //nao  prosseguir
            //pode validar  endereço  do usuario na mesma  tarefa.

            await _usuarioRepository.adicionarAsync(usuario);

            //* Se houver muita validação envolvendo if  - separe isso em  um metodo
        }

        public async Task Atualizar(Usuario usuario)
        {
            if (!ExecutarValidacao(new UsuarioValidation(), usuario)) return;

            if (_usuarioRepository.ObterPorId(usuario.Id) == null) return; 

            await _usuarioRepository.Atualizar(usuario);
        }


        public async Task Remover(Guid Id)
        {
            if (_usuarioRepository.ObterPorId(Id) == null) return;
            if (_usuarioRepository.ObterPorId(Id).Result.Nome == null) return;

            await _usuarioRepository.Remover(Id);
        }


        public void Dispose()
        {
            _usuarioRepository.Dispose();
        }
    }
}
