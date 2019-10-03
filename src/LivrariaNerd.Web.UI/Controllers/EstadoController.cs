using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LivrariaNerd.Domain.Entities;
using LivrariaNerd.Infra.Data.Interface;

namespace e_commerce_ws.Controllers
{
    [Route("estado")]
    public class EstadoController : Controller
    {
        private readonly IBaseRepositoryAsync<Estado> _repository;

        public EstadoController(IBaseRepositoryAsync<Estado> repository)
        {
            this._repository = repository;
        }

        [HttpGet, Route("obtertodos")]
        public JsonResult ObterTodos()
        {
            var estados = _repository.ObterTodos();
            return Json(estados);
        }

        [HttpGet, Route("obterpeloid")]
        public ActionResult ObterPeloId(int id)
        {
            var estado = _repository.ObterPeloId(id);

            if (estado == null)
                return NotFound();

            return Json(estado);
        }

        [HttpPost, Route("adicionar")]
        public async Task<JsonResult> Adicionar(Estado estado)
        {
            int id = await _repository.Adicionar(estado);
            return Json(new { id });
        }

        [HttpPost, Route("alterar")]
        public JsonResult Alterar(Estado estado)
        {
            bool alterou = _repository.Alterar(estado);
            return Json(new { status = alterou });
        }

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