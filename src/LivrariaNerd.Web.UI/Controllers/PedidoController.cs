using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LivrariaNerd.Domain.Entities;
using LivrariaNerd.Infra.Data.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LivrariaNerd.Web.UI.Controllers
{
    [Route("pedido")]
    public class PedidoController : Controller
    {
        private readonly IHttpContextAccessor _context;
        private readonly IBaseRepositoryAsync<Pedido> _pedidoRepository;
        private readonly IPedidoProdutoRepository _pedidoProdutoRepository;
        private readonly IBaseRepositoryAsync<PedidoProduto> _pedidoProdutoAsyncRepository;


        public PedidoController(IHttpContextAccessor context, IBaseRepositoryAsync<Pedido> pedidoRepository, IPedidoProdutoRepository pedidoProdutoRepository, IBaseRepositoryAsync<PedidoProduto> pedidoProdutoAsyncRepository)
        {
            _context = context;
            _pedidoRepository = pedidoRepository;
            _pedidoProdutoRepository = pedidoProdutoRepository;
            _pedidoProdutoAsyncRepository = pedidoProdutoAsyncRepository;
        }

        [HttpGet, Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost, Route("adicionaraocarrinho")]
        public async Task<IActionResult> AdicionarAoCarrinho(Produto produto)
        {
            var claimsIdentity = (ClaimsIdentity)_context.HttpContext.User.Identity;
            var idUsuario = claimsIdentity.FindFirst("Id").Value;

            var IdPedido = await _pedidoRepository.Adicionar(new Pedido()
            {
                IdUsuario = Convert.ToInt32(idUsuario)
            });

            var idPedidoProduto = await _pedidoProdutoAsyncRepository.Adicionar(new PedidoProduto()
            {
                IdPedido = IdPedido,
                IdProduto = produto.Id,
                Quantidade = 1,
                PrecoUnidade = produto.Preco,
                PrecoTotal = produto.Preco // ou 1 * produto.Preco, sendo 1 a quantidade.
            });

            var result = idPedidoProduto != 0 ? true : false; // se for diferente de 0 true, caso contrario false ( resultado de deu certo ou nao )
            return Json(new { result });
        }

        [HttpGet, Route("obtertodospedidospeloidusuario")]
        public IActionResult ObterTodosPedidosPeloIdUsuario()
        {
            var claimsIdentity = (ClaimsIdentity)_context.HttpContext.User.Identity;
            var idUsuario = Convert.ToInt32(claimsIdentity.FindFirst("Id").Value);

            var pedidosProduto = _pedidoProdutoRepository.ObterTodosPeloIdUsuario(idUsuario);
            return Json(new { pedidosProduto });
        }
    }
}