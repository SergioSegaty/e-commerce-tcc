using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PadawanStore.Domain.Entities;
using PadawanStore.Infra.Data.Interface;

namespace e_commerce_ws.Controllers
{

    /// <summary>
    /// Controller de Categoria
    /// </summary>
    [Route("categoria/")]
    public class CategoriaController : Controller
    {
        private readonly IBaseRepositoryAsync<Categoria> _repository;

        /// <summary>
        /// Construtor do controller de Categoria
        /// </summary>
        /// <param name="repository"></param>
        public CategoriaController(IBaseRepositoryAsync<Categoria> repository)
        {
            this._repository = repository;
        }

        [HttpGet, Route("")]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Metodo que permite obter todas as Categorias
        /// </summary>
        /// <returns>Lista de Cidades em um JSON</returns>
        [HttpGet, Route("obtertodos")]
        public JsonResult ObterTodos()
        {
            var categorias = _repository.ObterTodos();
            return Json(categorias);
        }

        /// <summary>
        /// Obter uma Categoria pelo Id
        /// </summary>
        /// <param name="id">Id da Categoria</param>
        /// <returns>Categoria em JSON</returns>
        [HttpGet, Route("obterpeloid")]
        public ActionResult ObterPeloId(int id)
        {
            var categoria = _repository.ObterPeloId(id);

            if (categoria == null)
                return NotFound();

            return Json(categoria);
        }

        /// <summary>
        /// Adicionar uma nova Categoria
        /// </summary>
        /// <param name="categoria">Objeto Categoria</param>
        /// <returns>Id da Categoria registrada</returns>
        [HttpPost, Route("adicionar")]
        public async Task<JsonResult> Adicionar(Categoria categoria)
        {
            int id = await _repository.Adicionar(categoria);
            return Json(new { id = id });
        }

        /// <summary>
        /// Alterar uma Categoria
        /// </summary>
        /// <param name="categoria">Objeto Categoria</param>
        /// <returns>Status se alterou com sucesso ou nao a categoria</returns>
        [HttpPost,Route("alterar")]
        public JsonResult Alterar(Categoria categoria)
        {
            bool alterou = _repository.Alterar(categoria);
            return Json(new { status = alterou });
        }

        /// <summary>
        /// Apagar uma Categoria
        /// </summary>
        /// <param name="id">Id da Categoria</param>
        /// <returns>Status se apagou com sucesso ou nao a categoria</returns>
        [HttpGet,Route("apagar")]
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