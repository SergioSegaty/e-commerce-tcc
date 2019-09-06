using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using Repository.Interface;

namespace e_commerce_ws.Controllers
{
    /// <summary>
    /// Controller do Estoque
    /// </summary>
    [Route("estoque")]
    [ApiController]
    public class EstoqueController : Controller
    {
        private readonly IBaseRepositoryAsync<Estoque> _repository;

        /// <summary>
        /// Construtor do controller de Estoque
        /// </summary>
        /// <param name="repository"></param>
        public EstoqueController(IBaseRepositoryAsync<Estoque> repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// Metodo que permite obter todos os Estoques
        /// </summary>
        /// <returns>Lista de Estoques em JSON</returns>
        [HttpGet, Route("obtertodos")]
        public JsonResult ObterTodos()
        {
            var estoques = _repository.ObterTodos();
            return Json(estoques);
        }

        /// <summary>
        /// Obter um Estoque por Id
        /// </summary>
        /// <param name="id">Id do Estoque</param>
        /// <returns>Estoque em JSON</returns>
        [HttpGet, Route("obterpeloid")]
        public ActionResult ObterPeloId(int id)
        {
            var estoque = _repository.ObterPeloId(id);

            if (estoque == null)
                return NotFound();

            return Json(estoque);
        }

        /// <summary>
        /// Adicionar um novo Estoque
        /// </summary>
        /// <param name="estoque">Objeto Estoque</param>
        /// <returns>Id do Estoque registrado</returns>
        [HttpPost, Route("adicionar")]
        public async Task<JsonResult> Adicionar(Estoque estoque)
        {
            int id = await _repository.Adicionar(estoque);
            return Json(new { id });
        }

        /// <summary>
        /// Alterar um Estoque
        /// </summary>
        /// <param name="estoque">Objeto Estoque</param>
        /// <returns>Status se alterou com sucesso ou n�o o Estoque</returns>
        [HttpPost, Route("alterar")]
        public JsonResult Alterar(Estoque estoque)
        {
            bool alterou = _repository.Alterar(estoque);
            return Json(new { status = alterou });
        }

        /// <summary>
        /// Apagar um Estoque
        /// </summary>
        /// <param name="id">Id do Estoque</param>
        /// <returns>Status se apagou com sucesso ou n�o o Estoque</returns>
        [HttpGet, Route("apagar")]
        public JsonResult Apagar(int id)
        {
            bool apagou = _repository.Apagar(id);
            return Json(new { status = apagou });
        }
    }
}