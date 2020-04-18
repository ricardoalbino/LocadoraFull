using Locadora.Domain.Interfaces;
using Locadora.Domain.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locadora.API.Controllers
{

    //https://localhost:44353/api/locadora/Usuarios
    [ApiController]
    [Route("api/locadora/[controller]")]
    public class UsuariosController : Controller
    {


        private readonly IUsuarioRepository _usuarioRepository;

        public UsuariosController(IUsuarioRepository usuarioRepository)
        {

            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Usuario>> ObterTodos()
        {

            var usuario = await _usuarioRepository.ObterTodos();



            return usuario;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Usuario>> ObterPorId(Guid id)
        {
            var usuario = await _usuarioRepository.ObterPorId(id);

            if (usuario == null) NotFound();


            return usuario;
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult<Usuario> Create(Usuario usuario)
        {

            if (!ModelState.IsValid) return BadRequest();

            string resultado = _usuarioRepository.adicionarAsync(usuario).ToString();

            if (resultado == null) BadRequest();

            return Ok();
        }


        //https://localhost:44353/api/locadora/Usuarios/edit/5
        [HttpPut("{id:Guid}")]
        public ActionResult<Usuario> Edit(Guid id,Usuario usuario)
        {
            //if (id != usuario.Id) return BadRequest();

            var resultado = _usuarioRepository.Atualizar(usuario);

            if (resultado == null) BadRequest();

            return Ok(resultado);


        }


        //https://localhost:44353/api/locadora/Usuarios/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var usuario = _usuarioRepository.ObterPorId(id);
            if (usuario == null) return NotFound();

            var result = _usuarioRepository.Remover(id);

            if (result == null) return BadRequest();

            return Ok(usuario);
        }
    }
}