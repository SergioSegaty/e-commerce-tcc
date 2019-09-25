using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LivrariaNerd.Domain.Entities;
using LivrariaNerd.Infra.Data.Interface;

namespace e_commerce_ws.Controllers
{
    /// <summary>
    /// Controller de Endereco
    /// </summary>
    [Route("endereco")]
    public class EnderecoController : Controller
    {
        private readonly IBaseRepositoryAsync<Endereco> _repository;

        /// <summary>
        /// Construtor do controller de endereco
        /// </summary>
        /// <param name="repository"></param>
        public EnderecoController(IBaseRepositoryAsync<Endereco> repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// Metodo que permite obter todos os Enderecos
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("obtertodos")]
        public JsonResult ObterTodos()
        {
            var enderecos = _repository.ObterTodos();
            return Json(enderecos);
        }

        /// <summary>
        /// Obter um Endereco pelo Id
        /// </summary>
        /// <param name="id">Id do Endereco</param>
        /// <returns>Endereco em JSON</returns>
        [HttpGet, Route("obterpeloid")]
        public ActionResult ObterPeloId(int id)
        {
            var endereco = _repository.ObterPeloId(id);

            if (endereco == null)
                return NotFound();

            return Json(endereco);
        }

        /// <summary>
        /// Adicionar um novo Endereco
        /// </summary>
        /// <param name="endereco">Objeto Endereco</param>
        /// <returns>Id do Endereco registrado</returns>
        [HttpPost, Route("adicionar")]
        public async Task<JsonResult> Adicionar(Endereco endereco)
        {
            int id = await _repository.Adicionar(endereco);
            return Json(new { id });
        }

        /// <summary>
        /// Alterar um Endereco
        /// </summary>
        /// <param name="endereco">Objeto Endereco</param>
        /// <returns>Status se alterou com sucesso ou n�o o Endereco</returns>
        [HttpPost, Route("alterar")]
        public JsonResult Alterar(Endereco endereco)
        {
            bool alterou = _repository.Alterar(endereco);
            return Json(new { status = alterou });
        }

        /// <summary>
        /// Apagar um Endereco
        /// </summary>
        /// <param name="id">Id do Endereco</param>
        /// <returns>Status se apagou com sucesso ou n�o o Endereco</returns>
        [HttpGet, Route("apagar")]
        public JsonResult Apagar(int id)
        {
            bool apagou = _repository.Apagar(id);
            return Json(new { status = apagou });
        }
    }
}