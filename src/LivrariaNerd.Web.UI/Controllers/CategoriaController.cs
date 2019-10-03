using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LivrariaNerd.Domain.Entities;
using LivrariaNerd.Infra.Data.Interface;

namespace e_commerce_ws.Controllers
{
    [Route("categoria/")]
    public class CategoriaController : Controller
    {
        private readonly IBaseRepositoryAsync<Categoria> _repository;

        public CategoriaController(IBaseRepositoryAsync<Categoria> repository)
        {
            this._repository = repository;
        }

        [HttpGet, Route("")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet, Route("obtertodos")]
        public JsonResult ObterTodos()
        {
            var categorias = _repository.ObterTodos();
            return Json(categorias);
        }

        [HttpGet, Route("obterpeloid")]
        public ActionResult ObterPeloId(int id)
        {
            var categoria = _repository.ObterPeloId(id);

            if (categoria == null)
                return NotFound();

            return Json(categoria);
        }

        [HttpPost, Route("adicionar")]
        public async Task<JsonResult> Adicionar(Categoria categoria)
        {
            int id = await _repository.Adicionar(categoria);
            return Json(new { id = id });
        }

        [HttpPost, Route("alterar")]
        public JsonResult Alterar(Categoria categoria)
        {
            bool alterou = _repository.Alterar(categoria);
            return Json(new { status = alterou });
        }

        [HttpGet, Route("apagar")]
        public JsonResult Apagar(int id)
        {
            bool apagou = _repository.Apagar(id);
            return Json(new { status = apagou });
        }


        [HttpGet, Route("select2")]
        public JsonResult Select2(string term = "")
        {
            term = term == null ? "" : term;

            var registros = _repository.ObterTodos();

            registros = registros.Where(x => x.Nome.Contains(term)).ToList();
            var categoriasSelect2 = new List<object>();

            foreach (var categoria in registros)
            {
                categoriasSelect2.Add(new
                {
                    id = categoria.Id,
                    text = categoria.Nome
                });
            }

            return Json(new { results = categoriasSelect2 });
        }
    }
}