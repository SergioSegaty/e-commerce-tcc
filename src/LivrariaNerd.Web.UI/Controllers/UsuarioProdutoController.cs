using Microsoft.AspNetCore.Mvc;
using LivrariaNerd.Domain.Entities;
using LivrariaNerd.Infra.Data.Interface;
using System.Collections.Generic;

namespace PadawanStore.Web.UI.Controllers
{
    [Route("loja")]
    public class UsuarioProdutoController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IBaseRepositoryAsync<Produto> _repository;

        public UsuarioProdutoController(IBaseRepositoryAsync<Produto> repository, IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
            _repository = repository;
        }

        [HttpGet, Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet, Route("obtertodos")]
        public JsonResult ObterTodos()
        {
            string busca = "";
            var produtos = _produtoRepository.ObterTodos(busca);
            return Json(produtos);
        }

        [HttpGet, Route("obtertodosprodutosusuarios")]
        public JsonResult ObterTodosProdutosUsuarios()
        {
            string busca = "";
            var produtos = _produtoRepository.ObterTodos(busca);

            var result = new List<object>();

            foreach (var produto in produtos)
            {
                result.Add(
                    new
                    {
                        Codigo = produto.Id,
                        ValorDoProduto = produto.Preco,
                        NomeProduto = produto.Nome,
                        NomeCategoriaProduto = produto.Categoria.Nome,
                        ImagemDoProduto = produto.ImagemCaminhoCompleto
                    });
            }

            return Json(result);
        }

        [HttpGet, Route("produtos")]
        public IActionResult Produtos()
        {
            return View();
        }

        [HttpGet, Route("obtertodosbusca")]
        public IActionResult ObterTodosBusca(string busca)
        {
            if (busca == null)
                busca = "";
            var produtos = _produtoRepository.ObterTodosBusca(busca);
            return Json(produtos);
        }

        [HttpGet, Route("obtertodosbuscaecategoria")]
        public IActionResult ObterTodosBuscaECategoria(string busca, int id)
        {
            if (busca == null)
                busca = "";
            var produtos = _produtoRepository.ObterTodosBuscaECategoria(busca, id);
            return Json(produtos);
        }

        [HttpGet, Route("produto")]
        public IActionResult Produto(int id)
        {
            var produto = _produtoRepository.ObterPeloId(id);
            ViewData["Produto"] = produto;

            return View();
        }

    }
}