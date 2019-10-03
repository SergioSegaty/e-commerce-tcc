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
            IPedidoProdutoRepository ppRepository)
        {
            _pedidoRepository = pedidoRepository;
            _usuarioRepository = usuarioRepository;
            _ppRepository = ppRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ObterQuantidadePedidos()
        {
            Pedido pedido1 = new Pedido();
            Pedido pedido2 = new Pedido();
            pedido1.DataCriacao = DateTime.Now;
            pedido2.DataCriacao = DateTime.Now;
            List<Pedido> todosOsPedidos = new List<Pedido>();
            todosOsPedidos.Add(pedido1);
            todosOsPedidos.Add(pedido2);


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
            List<Pedido> todosOsPedidos = new List<Pedido>();
            Pedido pedido1 = new Pedido();
            pedido1.DataCriacao = DateTime.Now;
            pedido1.StatusDoPedido = "PAGO";
            pedido1.PrecoTotal = Convert.ToDecimal(50.25);

            Pedido pedido2 = new Pedido();
            pedido2.DataCriacao = DateTime.Now;
            pedido2.StatusDoPedido = "PAGO";
            pedido2.PrecoTotal = Convert.ToDecimal(50.33);

            todosOsPedidos.Add(pedido1);
            todosOsPedidos.Add(pedido2);

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
            List<Produto> produtos = new List<Produto>();

            Produto produto1 = new Produto();
            produto1.DataCriacao = DateTime.Now;

            Produto produto2 = new Produto();
            produto2.DataCriacao = DateTime.Now;

            produtos.Add(produto1);
            produtos.Add(produto2);

            List<Produto> produtosFiltrados = new List<Produto>();
            foreach (var produto in produtos)
            {
                if (VerificarData(produto.DataCriacao))
                {
                    produtosFiltrados.Add(produto);
                }
            }
            return Json(new { quantidade = produtosFiltrados.Count });
        }

        [HttpGet]
        public JsonResult ObterQuantidadeUsuario()
        {
            List<Usuario> usuarios = new List<Usuario>();

            Usuario usuario1 = new Usuario();
            usuario1.DataCriacao = DateTime.Now;

            Usuario usuario2 = new Usuario();
            usuario2.DataCriacao = DateTime.Now;

            usuarios.Add(usuario1);
            usuarios.Add(usuario2);

            List<Usuario> usuariosFiltrados = new List<Usuario>();
            foreach (var usuario in usuarios)
            {
                if (VerificarData(usuario.DataCriacao))
                {
                    usuariosFiltrados.Add(usuario);
                }
            }
            return Json(new { quantidade = usuariosFiltrados.Count });
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
            if (dataCriacao == null) return false;
            TimeSpan diferencaEm = dataCriacao - dataAtual;
            return dataCriacao.Year != dataAtual.Year ? false : diferencaEm.Days <= 31;
        }
    }
}