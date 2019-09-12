using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using Repository.Interface;

namespace e_commerce_ws.Controllers
{
    /// <summary>
    /// Controller de Estado
    /// </summary>
    [Route("estado")]
    public class EstadoController : Controller
    {
        private readonly IBaseRepositoryAsync<Estado> _repository;

        /// <summary>
        /// Construtor do controller de Estado
        /// </summary>
        /// <param name="repository"></param>
        public EstadoController(IBaseRepositoryAsync<Estado> repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// Metodo que permite obter todos os Estados
        /// </summary>
        /// <returns>Lista de Estados em JSON</returns>
        [HttpGet, Route("obtertodos")]
        public JsonResult ObterTodos()
        {
            var estados = _repository.ObterTodos();
            return Json(estados);
        }

        /// <summary>
        /// Obter um Estado pelo Id
        /// </summary>
        /// <param name="id">Id do Estado</param>
        /// <returns>Estado em JSON</returns>
        [HttpGet, Route("obterpeloid")]
        public ActionResult ObterPeloId(int id)
        {
            var estado = _repository.ObterPeloId(id);

            if (estado == null)
                return NotFound();

            return Json(estado);
        }

        /// <summary>
        /// Adicionar um novo Estado
        /// </summary>
        /// <param name="estado">Objeto Estado</param>
        /// <returns>Id do Estado registrado</returns>
        [HttpPost, Route("adicionar")]
        public async Task<JsonResult> Adicionar(Estado estado)
        {
            int id = await _repository.Adicionar(estado);
            return Json(new { id });
        }

        /// <summary>
        /// Alterar um Estado
        /// </summary>
        /// <param name="estado">Objeto Estado</param>
        /// <returns>Status se alterou com sucesso ou n�o o Estado</returns>
        [HttpPost, Route("alterar")]
        public JsonResult Alterar(Estado estado)
        {
            bool alterou = _repository.Alterar(estado);
            return Json(new { status = alterou });
        }

        /// <summary>
        /// Apagar um Estado
        /// </summary>
        /// <param name="id">Id do Estado</param>
        /// <returns>Status se apagou com sucesso ou n�o o Estado</returns>
        [HttpGet, Route("apagar")]
        public JsonResult Apagar(int id)
        {
            bool apagou = _repository.Apagar(id);
            return Json(new { status = apagou });
        }

        [HttpGet, Route("")]
        public ActionResult Index()
        {
            return View();
        }
    }
}