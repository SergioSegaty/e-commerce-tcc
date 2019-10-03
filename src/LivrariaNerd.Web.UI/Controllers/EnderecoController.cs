using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LivrariaNerd.Domain.Entities;
using LivrariaNerd.Infra.Data.Interface;

namespace e_commerce_ws.Controllers
{
    [Route("endereco")]
    public class EnderecoController : Controller
    {
        private readonly IBaseRepositoryAsync<Endereco> _repository;

        public EnderecoController(IBaseRepositoryAsync<Endereco> repository)
        {
            this._repository = repository;
        }

        [HttpGet, Route("obtertodos")]
        public JsonResult ObterTodos()
        {
            var enderecos = _repository.ObterTodos();
            return Json(enderecos);
        }

        [HttpGet, Route("obterpeloid")]
        public ActionResult ObterPeloId(int id)
        {
            var endereco = _repository.ObterPeloId(id);

            if (endereco == null)
                return NotFound();

            return Json(endereco);
        }

        [HttpPost, Route("adicionar")]
        public async Task<JsonResult> Adicionar(Endereco endereco)
        {
            int id = await _repository.Adicionar(endereco);
            return Json(new { id });
        }

        [HttpPost, Route("alterar")]
        public JsonResult Alterar(Endereco endereco)
        {
            bool alterou = _repository.Alterar(endereco);
            return Json(new { status = alterou });
        }

        [HttpGet, Route("apagar")]
        public JsonResult Apagar(int id)
        {
            bool apagou = _repository.Apagar(id);
            return Json(new { status = apagou });
        }
    }
}