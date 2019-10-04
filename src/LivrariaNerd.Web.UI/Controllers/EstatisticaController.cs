using System;
using System.Collections.Generic;
using LivrariaNerd.Domain.Entities;
using LivrariaNerd.Domain.Identity;
using LivrariaNerd.Infra.Data.Interface;
using Microsoft.AspNetCore.Mvc;

namespace PadawanStore.Web.UI.Controllers
{
    public class EstatisticaController : Controller
    {
        private readonly IBaseRepositoryAsync<Pedido> _pedidoRepository;
        private readonly IBaseRepositoryAsync<Produto> _produtoRepository;
        private readonly IPedidoProdutoRepository _ppRepository;
        private readonly IBaseRepositoryAsync<Usuario> _usuarioRepository;

        public EstatisticaController(IBaseRepositoryAsync<Pedido> pedidoRepository,
            IBaseRepositoryAsync<Usuario> usuarioRepository,
            IPedidoProdutoRepository ppRepository,
            IBaseRepositoryAsync<Produto> produtoRepository
            )
        {
            _pedidoRepository = pedidoRepository;
            _usuarioRepository = usuarioRepository;
            _ppRepository = ppRepository;
            _produtoRepository = produtoRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ObterQuantidadePedidos()
        {
            List<Pedido> todosOsPedidos = _pedidoRepository.ObterTodos();

            int quantidadeDePedidosDoMes = 0;
            foreach (var pedido in todosOsPedidos)
            {
                if (VerificarData(pedido.DataCriacao))
                {
                    quantidadeDePedidosDoMes += 1;
                }
            }
            return Json(new { quantidade = quantidadeDePedidosDoMes });
        }

        [HttpGet]
        public JsonResult ObterTotalRendimento()
        {
            List<Pedido> todosOsPedidos = _pedidoRepository.ObterTodos();
            decimal rendimentoTotal = 0;
            foreach (var pedido in todosOsPedidos)
            {
                if (VerificarData(pedido.DataCriacao) && pedido.StatusDoPedido == "PAGO")
                {
                    rendimentoTotal += pedido.PrecoTotal;
                }
            }
            return Json(new { total = rendimentoTotal });
        }

        [HttpGet]
        public JsonResult ObterTotalProduto()
        {
            List<Produto> produtos = _produtoRepository.ObterTodos();

            int quantidadeProduto = 0;
            foreach (var produto in produtos)
            {
                if (VerificarData(produto.DataCriacao))
                {
                    quantidadeProduto++;
                }
            }
            return Json(new { quantidade = quantidadeProduto });
        }

        [HttpGet]
        public JsonResult ObterQuantidadeUsuario()
        {
            List<Usuario> usuarios = _usuarioRepository.ObterTodos();

            int quantidadeUsuario = 0;
            foreach (var usuario in usuarios)
            {
                if (VerificarData(usuario.DataCriacao))
                {
                    quantidadeUsuario++;
                }
            }
            return Json(new { quantidade = quantidadeUsuario });
        }

        [HttpGet]
        public JsonResult ObterPedidoRecente()
        {
            List<PedidoProduto> pps = _ppRepository.ObterTudo();

            List<object> ppsFiltrado = new List<object>();
            foreach (var pp in pps)
            {
                if (VerificarData(pp.Pedido.DataCriacao))
                {
                    ppsFiltrado.Add
                    (
                        new
                        {
                            Imagem = pp.Produto.ImagemCaminhoWwwroot,
                            NomeProduto = pp.Produto.Nome,
                            ClienteNome = pp.Pedido.Usuario.NomeCompleto,
                            DataCompra = pp.Pedido.DataCriacao,
                            Status = pp.Pedido.StatusDoPedido.ToUpper(),
                            Codigo = pp.Pedido.Id
                        }
                    );
                }
            }
            return Json(ppsFiltrado);
        }

        bool VerificarData(DateTime dataCriacao)
        {
            DateTime dataAtual = DateTime.UtcNow;
            TimeSpan diferencaEm = dataCriacao - dataAtual;
            return dataCriacao.Year != dataAtual.Year ? false : diferencaEm.Days <= 31;
        }
    }
}