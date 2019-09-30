using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LivrariaNerd.Domain.Identity;
using LivrariaNerd.Infra.Data.Interface;
using Microsoft.AspNetCore.Identity;

namespace View.Controllers
{
    [AllowAnonymous]
    [Route("auth")]
    public class AuthController : Controller
    {
        private readonly UserManager<Usuario> _userManager;
    
        private IUsuarioRepository usuarioRepository;
        private IBaseRepositoryAsync<Usuario> repository;

        public AuthController(IUsuarioRepository usuarioRepository, IBaseRepositoryAsync<Usuario> repository)
        {
            this.usuarioRepository = usuarioRepository;
            this.repository = repository;
          
            if(User != null)
            {
                var x = ((ClaimsIdentity)User.Identity);
            }
            //this._userManager = _userManager;
        }

        [HttpGet, Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet, Route("register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet, Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }

        [HttpPost, Route("login")]
        public async Task<IActionResult> Login(string login, string senha)
        {
            var usuario = usuarioRepository.ValidarLogin(login, senha);

            if (usuario == null)
                return RedirectToAction("Index");
           
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuario.Login),
                new Claim("FullName", usuario.NomeCompleto),
                new Claim("Id", usuario.Id.ToString()),
                new Claim(ClaimTypes.Role, "Administrator"),
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                //AllowRefresh = <bool>,
                // Refreshing the authentication session should be allowed.

                //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                // The time at which the authentication ticket expires. A 
                // value set here overrides the ExpireTimeSpan option of 
                // CookieAuthenticationOptions set with AddCookie.

                //IsPersistent = true,
                // Whether the authentication session is persisted across 
                // multiple requests. When used with cookies, controls
                // whether the cookie's lifetime is absolute (matching the
                // lifetime of the authentication ticket) or session-based.

                //IssuedUtc = <DateTimeOffset>,
                // The time at which the authentication ticket was issued.

                //RedirectUri = <string>
                // The full path or absolute URI to be used as an http 
                // redirect response value.
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost, Route("store")]
        public IActionResult Store(Usuario usuario)
        {
            var result = repository.Adicionar(usuario);
            return Json(new { id = result });
        }

        [HttpPost, Route("update")]
        public IActionResult Update(Usuario usuario)
        {
            var result = repository.Alterar(usuario);
            return Json(new { Alterou = result });
        }

        [HttpGet, Route("obtertodos")]
        public IActionResult ObterTodos()
        {
            var result = repository.ObterTodos();
            return Json(result);
        }


    }
}