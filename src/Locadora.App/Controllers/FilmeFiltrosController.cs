using Locadora.Domain.Interfaces;
using Locadora.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Locadora.App.Controllers
{
    public class FilmeFiltrosController : Controller
    {

        private readonly IFilmeRepository _filmeRepository;
        private readonly IUsuarioRepository _usuarioRepository;
       
    

        public FilmeFiltrosController(IFilmeRepository filmeRepository, IUsuarioRepository usuarioRepositor)
        {

            _filmeRepository = filmeRepository;
            _usuarioRepository = usuarioRepositor;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string genero, DateTime? dataLancamento)
        {
           
            if (genero == null || (genero.Equals("Escolha um Genêro")))
            {
               
                using (var httpClient = new HttpClient())
                {
                    List<Filme> _filmeList = new List<Filme>();

                    using (var response = await httpClient.GetAsync("https://localhost:44353/api/locadora/Filmes"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        _filmeList = JsonConvert.DeserializeObject<List<Filme>>(apiResponse);

                        ViewBag.ListarFilmes = _filmeList;

                    }
                }
            }
            else if(genero != null)
            {
                using (var httpClient = new HttpClient())
                {
                    var _dataLancamento = DateTime.Now.ToString("yyyy-MM-dd 00:00");

                    List<Filme> _filmeList = new List<Filme>();
                    using (var response = await httpClient.GetAsync("https://localhost:44353/api/locadora/Filmes/GetPor/" + genero + "/"  + _dataLancamento))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        _filmeList = JsonConvert.DeserializeObject<List<Filme>>(apiResponse);

                        ViewBag.ListarFilmes = _filmeList;

                    }
                }
            }
            else
            {
                using (var httpClient = new HttpClient())
                {
                    List<Filme> _filmeList = new List<Filme>();
                    using (var response = await httpClient.GetAsync("https://localhost:44353/api/locadora/Filmes/GetPor/" + genero + "/" + dataLancamento))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        _filmeList = JsonConvert.DeserializeObject<List<Filme>>(apiResponse);

                        ViewBag.ListarFilmes = _filmeList;

                    }
                }
            }
            return View();    
        }
    }
}