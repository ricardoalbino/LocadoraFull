using Locadora.Domain.Interfaces;
using Locadora.Infra.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Locadora.App.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Registrar()
        {
            return View();
        }

        public IActionResult Logar(string email, string password)
        {
            var result = _usuarioRepository.Autenticar(email, password);

            //if (result == null) return null;

            TempData["Logado"] = email;
            return RedirectToAction("Index", "Home");
        }

    }
}