using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PadawanStore.Domain.Identity;
using PadawanStore.Infra.Data.Interface;

namespace View.Controllers
{
    public class AuthController : Controller
    {
        private IUsuarioRepository repository;

        public AuthController(IUsuarioRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string login, string senha)
        {
            var usuario = repository.ValidarLogin(login, senha);
            if (usuario == null)
            {
                return RedirectToAction("Index");
            }
            HttpContext.Session.SetString("Usuario", JsonConvert.SerializeObject(usuario));
            return RedirectToAction("Index", "Home");
        }
    }
}