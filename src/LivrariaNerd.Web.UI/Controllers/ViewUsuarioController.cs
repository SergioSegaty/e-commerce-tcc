using Microsoft.AspNetCore.Mvc;
using LivrariaNerd.Domain.Entities;
using LivrariaNerd.Domain.Identity;
using LivrariaNerd.Infra.Data.Interface;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;
using System;
using System.Text;
using System.Security.Claims;

namespace PadawanStore.Web.UI.Controllers
{
    [Route("usuario")]
    public class ViewUsuarioController : Controller
    {
        private readonly IBaseRepositoryAsync<Usuario> _repo;
        private readonly IUsuarioRepository _userRepository;
        private readonly IHostingEnvironment _env;
        private readonly string _nomePasta;
        private readonly string _caminho;
        private readonly int idUsuarioAtivo;
        private readonly IEnderecoRepository _endRepository;
        private readonly IHttpContextAccessor _context;

        public ViewUsuarioController(IBaseRepositoryAsync<Usuario> context, IUsuarioRepository usuarioRepository, IHostingEnvironment environment, IHttpContextAccessor httpContextAccessor, IEnderecoRepository enderecoRepository)
        {
            _repo = context;
            _userRepository = usuarioRepository;
            _env = environment;
            _endRepository = enderecoRepository;
            _context = httpContextAccessor;

            string wwwroot = environment.WebRootPath;

            _nomePasta = "uploads";
            _nomePasta = Path.Combine(_nomePasta, "profile-pictures");
            _caminho = Path.Combine(wwwroot, _nomePasta);

            if (!Directory.Exists(_caminho))
            {
                Directory.CreateDirectory(_caminho);
            }

            var claimsIdentity = (ClaimsIdentity)httpContextAccessor.HttpContext.User.Identity;
            idUsuarioAtivo = Convert.ToInt32(claimsIdentity.FindFirst("Id").Value);
        }


        //[HttpPost, Route("upload")]
        //public IActionResult Upload(IFormFile file)
        //{
        //    var nomeArquivo = file.FileName;
        //    var usuario = _repo.ObterPeloId(idUsuarioAtivo);



        //    // Hash 
        //    FileInfo fileInfo = new FileInfo(nomeArquivo);
        //    var crypt = new SHA256Managed();
        //    var hash = new StringBuilder();
        //    byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(fileInfo.Name.Replace(fileInfo.Extension, "") + DateTime.Now));
        //    foreach (byte oByte in crypto)
        //    {
        //        hash.Append(oByte.ToString("2x"));
        //    }

        //    var caminhoArquivo = Path.Combine(_caminho, (hash + fileInfo.Extension).ToUpper());

        //    var caminhoRoot = Path.Combine(_nomePasta, (hash + fileInfo.Extension).ToUpper());

        //    using (var stream = new FileStream(caminhoArquivo, FileMode.Create))
        //    {
        //        file.CopyTo(stream);
        //        // Adicionar a imagem dentro do Usuario
        //        usuario.CaminhoImagem = caminhoArquivo;
        //        usuario.ShortcutImagem = caminhoRoot;
        //        _repo.Alterar(usuario);

        //        return RedirectToAction("Index");
                    
        //    }
        //}

        [HttpGet, Route("obterenderecousuario")]
        public ActionResult ObterEnderecoUsuario()
        {
            var claimsIdentity = (ClaimsIdentity)_context.HttpContext.User.Identity;
            var idUsuario = Convert.ToInt32(claimsIdentity.FindFirst("Id").Value);

            var enderecoAtivo = _endRepository.ObterTodosPeloUsuario(idUsuario);

            if (enderecoAtivo == null)
            {
                return NotFound();
            }
            return Json(enderecoAtivo);
        }

        [HttpGet, Route("obterusuarioativo")]
        public ActionResult obterUsuarioAtivo()
        {
            var usuario = _repo.ObterPeloId(idUsuarioAtivo);


            return Json(usuario);
        }

        [HttpGet, Route("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}