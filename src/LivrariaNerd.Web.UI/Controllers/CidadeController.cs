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
        private readonly IBaseRepositoryAsync<Cidade> _repository;
        private readonly ICidadeRepository _cidadeRepository;

        public CidadeController(IBaseRepositoryAsync<Cidade> repository, ICidadeRepository cidadeRepository)
        {
            _repository = repository;
            _cidadeRepository = cidadeRepository;
        }

        [HttpGet, Route("obtertodos")]
        public JsonResult ObterTodos()
        {
            var cidades = _cidadeRepository.ObterTodos();
            return Json(cidades);
        }

        [HttpGet, Route("obtertodosbusca")]
        public JsonResult ObterTodosBusca(string busca)
        {
            if (busca == null)
                busca = "";
            var cidades = _repository.ObterTodos();

            var resultado = new List<object>();

            //Como é generics tem q fazer gambiarra
            foreach (var cidade in cidades)
            {
                if (cidade.Nome.ToUpper().Contains(busca.ToUpper()) || cidade.Estado.Sigla.ToUpper().Contains(busca.ToUpper()))
                    resultado.Add(cidade);
            }

            return Json(resultado);
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
            int id = await _repository.Adicionar(cidade);
            return Json(new { id });
        }

        [HttpPost, Route("alterar")]
        public JsonResult Alterar(Cidade cidade)
        {
            bool alterou = _repository.Alterar(cidade);
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