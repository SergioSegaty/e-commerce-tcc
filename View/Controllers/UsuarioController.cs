using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using Repository.Interface;

namespace e_commerce_ws.Controllers
{
    /// <summary>
    /// Controller de Usuario
    /// </summary>
    [Route("usuario")]
    public class UsuarioController : Controller
    {
        private readonly IBaseRepositoryAsync<Usuario> _repository;

        /// <summary>
        /// Construtor do controller de Usuario
        /// </summary>
        /// <param name="repository"></param>
        public UsuarioController(IBaseRepositoryAsync<Usuario> repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// Metodo que permite obter todos os Usuarios
        /// </summary>
        /// <returns>List de Usuarios em JSON</returns>
        [HttpGet, Route("obtertodos")]
        public JsonResult ObterTodos()
        {
            var usuarios = _repository.ObterTodos();
            return Json(usuarios);
        }

        /// <summary>
        /// Obter um Usuario pelo Id
        /// </summary>
        /// <param name="id">Id do Usuario</param>
        /// <returns>Usuario em JSON</returns>
        [HttpGet, Route("obterpeloid")]
        public ActionResult ObterPeloId(int id)
        {
            var usuario = _repository.ObterPeloId(id);

            if (usuario == null)
                return NotFound();

            return Json(usuario);
        }

        /// <summary>
        /// Adicionar um novo Usuario
        /// </summary>
        /// <param name="usuario">Objeto Usuario</param>
        /// <returns>Id do Usuario registrado</returns>
        [HttpPost, Route("adicionar")]
        public async Task<JsonResult> Adicionar(Usuario usuario)
        {
            int id = await _repository.Adicionar(usuario);
            return Json(new { id });
        }

        /// <summary>
        /// Alterar um Usuario
        /// </summary>
        /// <param name="usuario">Objeto Usuario</param>
        /// <returns>Status se alterou com sucesso ou n�o o Usuario</returns>
        [HttpPost, Route("alterar")]
        public JsonResult Alterar(Usuario usuario)
        {
            return Json(new { status = _repository.Alterar(usuario) });
        }

        /// <summary>
        /// Apagar um Usuario
        /// </summary>
        /// <param name="id">Id do Usuario</param>
        /// <returns>Status se alterou com sucesso ou n�o o Usuario</returns>
        [HttpGet, Route("apagar")]
        public JsonResult Apagar(int id)
        {
            bool apagou = _repository.Apagar(id);
            return Json(new {status = apagou});
        }
    }
}