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
            var produtos = _produtoRepository.ObterTodos();
            return Json(produtos);
        }

        [HttpGet, Route("obtertodosprodutosusuarios")]
        public JsonResult ObterTodosProdutosUsuarios()
        {
            var produtos = _produtoRepository.ObterTodos();

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
    }
}