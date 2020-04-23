using Locadora.Domain.Interfaces;
using Locadora.Domain.Models;
using Locadora.Infra.Context;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
namespace Locadora.App.Controllers
{

    //CONSUMINDO  API EM CORE
    public class UsuariosController : Controller
    {
        private readonly DataContext _context;
        private readonly IUsuarioRepository _usuarioRepository;
        

        public UsuariosController(IUsuarioRepository usuarioRepository, DataContext context)
        {
            _context = context;
            _usuarioRepository = usuarioRepository;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {

            List<Usuario> usuarioList = new List<Usuario>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44378/api/locadora/Usuarios"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    usuarioList = JsonConvert.DeserializeObject<List<Usuario>>(apiResponse);
                }
            }
            return View(usuarioList);
        }



        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<dynamic> Create(Usuario usuario)
        {

            Usuario _usuario = new Usuario();

            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:44378/api/locadora/Usuarios", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    _usuario = JsonConvert.DeserializeObject<dynamic>(apiResponse);
                }
            }

            if (_usuario == null) View(_usuario);

            return RedirectToAction("Index");
            ;
        }

        // GET: Usuarios/Edit/5
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {

            Usuario _usuario = new Usuario();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44378/api/locadora/Usuarios/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _usuario = JsonConvert.DeserializeObject<Usuario>(apiResponse);
                }
            }

            return View(_usuario);
        }


        [HttpPost]
        public async Task<IActionResult> EditForm(Usuario usuario)
        {
            Usuario _usuario = new Usuario();

            if (usuario.Id == null) return NotFound();

            if (!ModelState.IsValid) return View(usuario);

            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PutAsync("https://localhost:44378/api/locadora/Usuarios/" + usuario.Id, content))
                {

                    if (!response.IsSuccessStatusCode) return View(usuario);

                }
            }

            return RedirectToAction("Index");
        }

        // GET: Usuarios/Delete/5
        //[HttpGet("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {

            Usuario _usuario = new Usuario();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44378/api/locadora/Usuarios/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _usuario = JsonConvert.DeserializeObject<Usuario>(apiResponse);
                }
            }

            return View(_usuario);
        }

        // POST: https://localhost:44353/api/locadora/Usuarios/5

        [HttpPost]
        public async Task<IActionResult> Delete(Usuario usuario)
        {

            if (usuario.Id == null) return NotFound();


            using (var httpClient = new HttpClient())
            {
                // StringContent content = new StringContent(JsonConvert.SerializeObject(id), Encoding.UTF8, "application/json");
                using (var response = await httpClient.DeleteAsync("https://localhost:44378/api/locadora/Usuarios/" + usuario.Id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("Index");
        }
    }
}
