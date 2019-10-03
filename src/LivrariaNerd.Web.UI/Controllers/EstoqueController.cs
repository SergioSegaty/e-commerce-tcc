using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LivrariaNerd.Domain.Entities;
using LivrariaNerd.Infra.Data.Interface;

namespace e_commerce_ws.Controllers
{
    [Route("estoque")]
    public class EstoqueController : Controller
    {
        private readonly IBaseRepositoryAsync<Estoque> _repository;
        private readonly IEstoqueRepository _estoqueRepository;

        public EstoqueController(IBaseRepositoryAsync<Estoque> repository, IEstoqueRepository estoqueRepository)
        {
            this._repository = repository;
            _estoqueRepository = estoqueRepository;
        }

        [HttpGet, Route("")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet, Route("obtertodos")]
        public JsonResult ObterTodos(string status)
        {
            var estoques = _estoqueRepository.ObterTodos(status);
            return Json(estoques);
        }

        [HttpGet, Route("obterpeloid")]
        public ActionResult ObterPeloId(int id)
        {
            var estoque = _estoqueRepository.ObterPeloId(id);

            if (estoque == null)
                return NotFound();

            return Json(estoque);
        }

        [HttpPost, Route("adicionar")]
        public async Task<JsonResult> Adicionar(Estoque estoque)
        {
            int id = await _repository.Adicionar(estoque);
            return Json(new { id });
        }

        [HttpPost, Route("alterar")]
        public JsonResult Alterar(Estoque estoque)
        {
            bool alterou = _repository.Alterar(estoque);
            return Json(new { status = alterou });
        }

        [HttpGet, Route("apagar")]
        public JsonResult Apagar(int id)
        {
            bool apagou = _repository.Apagar(id);
            return Json(new { status = apagou });
        }

        [HttpGet, Route("obtertodosfootable")]
        public JsonResult ObterTodosFootable(string status)
        {
            var estoques = _estoqueRepository.ObterTodos(status);

            var result = new List<object>();

            foreach (var estoque in estoques)
            {
                result.Add(
                    new
                    {
                        id = estoque.Id,
                        nomeProduto = estoque.Produto.Nome,
                        quantidade = estoque.Quantidade,
                        status = estoque.Status
                    });
            }

            return Json(result);
        }
    }
}