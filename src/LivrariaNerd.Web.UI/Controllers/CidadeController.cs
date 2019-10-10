using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LivrariaNerd.Domain.Entities;
using LivrariaNerd.Infra.Data.Interface;
using System.Collections.Generic;

namespace e_commerce_ws.Controllers
{
    [Route("cidade")]
    public class CidadeController : Controller
    {
        private readonly ICidadeRepository _cidadeRepository;

        public CidadeController(ICidadeRepository cidadeRepository)
        {
            _cidadeRepository = cidadeRepository;
        }

        [HttpGet, Route("obtertodos")]
        public JsonResult ObterTodos(string busca)
        {
            if (busca == null) busca = "";

            var cidades = _cidadeRepository.ObterTodos(busca);
            return Json(cidades);
        }

        [HttpGet, Route("obtertodospeloestado")]
        public JsonResult ObterTodos(int id)
        {
            var cidades = _cidadeRepository.ObterTodosPeloEstado(id);
            return Json(cidades);
        }

        [HttpGet, Route("obterpeloid")]
        public ActionResult ObterPeloId(int id)
        {
            var cidade = _cidadeRepository.ObterPeloId(id);

            if (cidade == null)
                return NotFound();

            return Json(cidade);
        }

        [HttpPost, Route("adicionar")]
        public async Task<JsonResult> Adicionar(Cidade cidade)
        {
            int id = await _cidadeRepository.Adicionar(cidade);
            return Json(new { id });
        }

        [HttpPost, Route("alterar")]
        public JsonResult Alterar(Cidade cidade)
        {
            bool alterou = _cidadeRepository.Alterar(cidade);
            return Json(new { status = alterou });
        }

        [HttpGet, Route("apagar")]
        public JsonResult Apagar(int id)
        {
            bool apagou = _cidadeRepository.Apagar(id);
            return Json(new { status = apagou });
        }

        [HttpGet, Route("")]
        public ActionResult Index()
        {
            return View();
        }
    }
}