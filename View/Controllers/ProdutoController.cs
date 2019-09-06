using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using Repository.Interface;

namespace e_commerce_ws.Controllers
{
    /// <summary>
    /// Controller de Produto
    /// </summary>
    [Route("produto")]
    [ApiController]
    public class ProdutoController : Controller
    {
        private readonly IBaseRepositoryAsync<Produto> _repo;
        private readonly IProdutoRepository _produtoRepository;
    
        /// <summary>
        /// Construtor do controller de Produto
        /// </summary>
        /// <param name="context"></param>
        /// <param name="produtoRepository"></param>
        public ProdutoController(IBaseRepositoryAsync<Produto> context, IProdutoRepository produtoRepository)
        {
            _repo = context;
            _produtoRepository = produtoRepository;
        }

        /// <summary>
        /// Metodo que permite obter todos os Produtos
        /// </summary>
        /// <returns>Lista de Produtos em JSON</returns>
        [HttpGet, Route("obtertodos")]
        public JsonResult ObterTodos()
        {
            var produtos = _repo.ObterTodos();
            return Json(produtos);
        }

        /// <summary>
        /// Metodo que permite obter todos os Produtos que possuem a mesma Categoria
        /// </summary>
        /// <param name="id">Id de uma Categoria</param>
        /// <returns>Lista de Produtos em um JSON</returns>
        [HttpGet, Route("obtertodospelacategoria")]
        public JsonResult ObterTodos(int id)
        {
            var cidades = _produtoRepository.ObterTodosPelaCategoria(id);
            return Json(cidades);
        }

        /// <summary>
        /// Obter um Produto pelo Id
        /// </summary>
        /// <param name="id">Id do Produto</param>
        /// <returns>Produto em JSON</returns>
        [HttpGet, Route("obterpeloid")]
        public ActionResult ObterPeloId(int id)
        {
            var produto = _produtoRepository.ObterPeloId(id);

            if (produto == null)
            {
                return NotFound();
            }

            return Json(produto);
        }

        /// <summary>
        /// Adicionar um novo Produto
        /// </summary>
        /// <param name="produto">Objeto Produto</param>
        /// <returns>Id do Produto registrado</returns>
        [HttpPost, Route("adicionar")]
        public async Task<JsonResult> Adicionar(Produto produto)
        {
            int id = await _repo.Adicionar(produto);
            return Json(new { id = id });
        }

        /// <summary>
        /// Alterar um Produto
        /// </summary>
        /// <param name="produto">Objeto Produto</param>
        /// <returns>Status se alterou com sucesso ou n�o o Produto</returns>
        [HttpPost, Route("alterar")]
        public JsonResult Alterar(Produto produto)
        {
            bool alterou = _repo.Alterar(produto);
            return Json(new { status = alterou });
        }

        /// <summary>
        /// Apagar um Produto
        /// </summary>
        /// <param name="id">Id do Produto</param>
        /// <returns>Status se apagou com sucesso ou n�o o Protudo</returns>
        [HttpGet, Route("apagar")]
        public JsonResult Apagar(int id)
        {
            bool apagou = _repo.Apagar(id);
            return Json(new { status = apagou });
        }
    }
}