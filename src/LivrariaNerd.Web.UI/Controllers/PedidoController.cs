using System;
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
        private readonly IBaseRepositoryAsync<Pedido> _pedidoRepositoryAsync;
        private readonly IPedidoProdutoRepository _pedidoProdutoRepository;
        private readonly IBaseRepositoryAsync<PedidoProduto> _pedidoProdutoAsyncRepository;


        public PedidoController(IHttpContextAccessor context, IBaseRepositoryAsync<Pedido> pedidoRepositoryAsync, IPedidoProdutoRepository pedidoProdutoRepository, IBaseRepositoryAsync<PedidoProduto> pedidoProdutoAsyncRepository)
        {
            _context = context;
            _pedidoRepositoryAsync = pedidoRepositoryAsync;
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
            var idUsuario = Convert.ToInt32(claimsIdentity.FindFirst("Id").Value);

            var pedidosUsuario = _pedidoProdutoRepository.ObterTodosPeloIdUsuario(idUsuario);
            if (pedidosUsuario != null)
            {
                if (pedidosUsuario.Count != 0)
                {
                    for (int i = 0; i < pedidosUsuario.Count; i++)
                    {
                        if (pedidosUsuario[i].Produto.Id == produto.Id)
                        {
                            var auxPedidoProduto = pedidosUsuario[i];

                            auxPedidoProduto.Quantidade++;

                            auxPedidoProduto.PrecoTotal = auxPedidoProduto.Quantidade * auxPedidoProduto.PrecoUnidade;
                            auxPedidoProduto.Pedido.PrecoTotal = auxPedidoProduto.PrecoTotal;

                            var resultado = _pedidoProdutoAsyncRepository.Alterar(auxPedidoProduto);
                            return Json(resultado);
                        }
                    }
                }
            }

            var IdPedido = await _pedidoRepositoryAsync.Adicionar(new Pedido()
            {
                IdUsuario = idUsuario
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
            return Json(result);
        }

        [HttpPost, Route("removerdocarrinho")]
        public IActionResult RemoverDoCarrinho(int id)
        {
            var result = _pedidoProdutoAsyncRepository.Apagar(id);
            return Json(result);
        }

        [HttpGet, Route("obtertodospedidospeloidusuario")]
        public IActionResult ObterTodosPedidosPeloIdUsuario()
        {
            var claimsIdentity = (ClaimsIdentity)_context.HttpContext.User.Identity;
            var idUsuario = Convert.ToInt32(claimsIdentity.FindFirst("Id").Value);

            var pedidosProduto = _pedidoProdutoRepository.ObterTodosPeloIdUsuario(idUsuario);
            return Json(pedidosProduto);
        }

        [HttpGet, Route("obterpeloid")]
        public IActionResult ObterPeloId(int id)
        {
            return Json(_pedidoProdutoRepository.ObterPeloId(id));
        }

        [HttpPost, Route("modificarquantidade")]
        public IActionResult ModificarQuantidade(PedidoProduto pedidoProduto)
        {
            var claimsIdentity = (ClaimsIdentity)_context.HttpContext.User.Identity;
            var idUsuario = Convert.ToInt32(claimsIdentity.FindFirst("Id").Value);

            var pedidosUsuario = _pedidoProdutoRepository.ObterTodosPeloIdUsuario(idUsuario);
            if (pedidoProduto != null)
            {
                var result = _pedidoProdutoAsyncRepository.Alterar(pedidoProduto);
                return Json(result);
            }
            else
            {
                return Json(false);
            }
        }
    }
}