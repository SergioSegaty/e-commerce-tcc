using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LivrariaNerd.Domain.Entities;
using LivrariaNerd.Infra.Data.Interface;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;
using System;
using System.Text;
using System.Security.Claims;

namespace e_commerce_ws.Controllers
{
    /// <summary>
    /// Controller de Produto
    /// </summary>
    [Route("produto")]
    public class ProdutoController : Controller
    {
        private readonly IBaseRepositoryAsync<Produto> _repo;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IHostingEnvironment _env;
        private readonly string _nomePasta;
        private readonly string _caminho;

        /// <summary>
        /// Construtor do controller de Produto
        /// </summary>
        /// <param name="context"></param>
        /// <param name="produtoRepository"></param>
        public ProdutoController(IBaseRepositoryAsync<Produto> context, IProdutoRepository produtoRepository, IHostingEnvironment env, IHttpContextAccessor httpContextAccessor)
        {
            _repo = context;
            _produtoRepository = produtoRepository;
            _env = env;

            string wwwroot = env.WebRootPath;

            _nomePasta = "uploads";
            _nomePasta = Path.Combine(_nomePasta, "imagens");
            _caminho = Path.Combine(wwwroot, _nomePasta);

            if (!Directory.Exists(_caminho))
            {
                Directory.CreateDirectory(_caminho);
            }

            var claimsIdentity = (ClaimsIdentity)httpContextAccessor.HttpContext.User.Identity;
            var nome = claimsIdentity.FindFirst("FullName").Value;
            var idUsuario = claimsIdentity.FindFirst("Id").Value;

        }

        [HttpPost, Route("upload")]
        public IActionResult Upload(IFormFile file, int id)
        {
            var nomeArquivo = file.FileName;

            var produto = _repo.ObterPeloId(id);

            //Hash
            FileInfo fileInfo = new FileInfo(nomeArquivo);

            var crypt = new SHA256Managed();
            var hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(fileInfo.Name.Replace(fileInfo.Extension, "") + DateTime.Now));
            foreach (byte oByte in crypto)
            {
                hash.Append(oByte.ToString("x2"));
            }

            var caminhoArquivo = Path.Combine(_caminho, (hash + fileInfo.Extension).ToUpper());

            var caminhoWWWRoot = Path.Combine(_nomePasta, (hash + fileInfo.Extension).ToUpper());


            using (var stream = new FileStream(caminhoArquivo, FileMode.Create))
            {
                file.CopyTo(stream);
                //Add The Image to the product object
                produto.ImagemCaminhoCompleto = caminhoArquivo;
                produto.ImagemCaminhoWwwroot = caminhoWWWRoot;
                _repo.Alterar(produto);
            }

            return RedirectToAction("Index", "Produto");
        }

        /// <summary>
        /// Metodo que permite obter todos os Produtos
        /// </summary>
        /// <returns>Lista de Produtos em JSON</returns>
        [HttpGet, Route("obtertodos")]
        public JsonResult ObterTodos()
        {
            var produtos = _produtoRepository.ObterTodos();
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

        [HttpGet, Route("")]
        public ActionResult Index()
        {
            return View();
        }

    }
}