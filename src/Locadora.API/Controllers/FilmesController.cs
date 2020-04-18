using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Locadora.Domain.Interfaces;
using Locadora.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Locadora.API.Controllers
{
    //https://localhost:44353/api/locadora/Usuarios

    [ApiController]
    [Route("api/locadora/[controller]")]
    public class FikmesController : Controller
    {


        private readonly IFilmeRepository _filmeRepository;

        public FikmesController(IFilmeRepository filmeRepository)
        {

            _filmeRepository = filmeRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Filme>> ObterTodos()
        {

            var usuario = await _filmeRepository.ObterTodos();



            return usuario;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Filme>> ObterPorId(Guid id)
        {
            var filme = await _filmeRepository.ObterPorId(id);

            if (filme == null) NotFound();


            return filme;
        }


        [HttpGet]
        public async Task<IEnumerable<Filme>> ObterFilmePorGeneroOuDataOuNome(string genero, DateTime? dataLançamento)
        {
            var filme = await _filmeRepository.ObterFilmePorGenero(genero,dataLançamento);
            
            if (filme == null) NotFound();


            return filme;
        }
        // POST: Usuario/Create
        [HttpPost]
        public ActionResult<Usuario> Create(Filme filme)
        {

            if (!ModelState.IsValid) return BadRequest();

            string resultado = _filmeRepository.adicionarAsync(filme).ToString();

            if (resultado == null) BadRequest();

            return Ok();
        }


        //https://localhost:44353/api/locadora/Usuarios/edit/5
        [HttpPut("{id:Guid}")]
        public ActionResult<Usuario> Edit(Guid id, Filme filme)
        {
            //if (id != usuario.Id) return BadRequest();

            var resultado = _filmeRepository.Atualizar(filme);

            if (resultado == null) BadRequest();

            return Ok(resultado);


        }


        //https://localhost:44353/api/locadora/Usuarios/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var filme = _filmeRepository.ObterPorId(id);
            if (filme == null) return NotFound();

            var result = _filmeRepository.Remover(id);

            if (result == null) return BadRequest();

            return Ok(filme);
        }
    }
}