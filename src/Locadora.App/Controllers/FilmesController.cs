using Locadora.Domain.Interfaces;
using Locadora.Domain.Models;
using Locadora.Infra.Context;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Locadora.App.Controllers
{
    public class FilmesController : Controller
    {
        private readonly DataContext _context;
        private readonly IFilmeRepository _filmeRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public FilmesController(IFilmeRepository filmeRepository, IUsuarioRepository usuarioRepositor)
        {

            _filmeRepository = filmeRepository;
            _usuarioRepository = usuarioRepositor;
        }

        // GET: Filmes
        
        public async Task<IActionResult> Index()
        {
            return View(await _filmeRepository.ObterTodos());
        }


        // GET: Filmes/Create
        public  IActionResult Create()
        {

            //var FilmeDeUsuario = await _filmeRepository.ObterFilmeComUsuario();

            //return View(FilmeDeUsuario);

            return View();
        }

  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Filme filme)
        {
            //filme = await PopularUsuarios(filme);

            if (!ModelState.IsValid) return View(filme);

        
            await _filmeRepository.adicionarAsync(filme);


            return RedirectToAction("Index");
        }

        // GET: Filmes/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var filme = await _filmeRepository.ObterPorId(id);

            if (filme == null)
            {
                return NotFound();
            }
            return View(filme);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id,  Filme filme)
        {
            if (id != filme.Id) return NotFound();

            if (!ModelState.IsValid) return View(filme);

            await _filmeRepository.Atualizar(filme);

           // ViewData["UsuarioID"] = new SelectList(_context.Usuarios, "Id", "Nome", filme.UsuarioID);
            return RedirectToAction("Index");
        }

        // GET: Filmes/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var filme = await _filmeRepository.ObterPorId(id);

            if (filme == null)
            {
                return NotFound();
            }
            return View(filme);
        }

        // POST: Filmes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var filme = await _filmeRepository.ObterPorId(id);

            if (filme == null) return NotFound();

            await _filmeRepository.Remover(id);

            return RedirectToAction("Index");
        }

    }
}














//public async Task<Filme> PopularUsuarios(Filme filme)
//{
//      filme = await _filmeRepository.ObterFilmeComUsuario();

//    return filme;

//}
