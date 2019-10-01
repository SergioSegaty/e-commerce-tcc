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
        private readonly IBaseRepositoryAsync<Usuario> _usuarioRepository;

        public EstatisticaController(IBaseRepositoryAsync<Pedido> pedidoRepository,
            IBaseRepositoryAsync<Usuario> usuarioRepository)
        {
            _pedidoRepository = pedidoRepository;
            _usuarioRepository = usuarioRepository;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult ObterQuantidadePedidos()
        {
            List<Pedido> todosOsPedidos = _pedidoRepository.ObterTodos();
            
            int quantidadeDePedidosDoMes = 0;
            foreach (var pedido in todosOsPedidos)
            {
                if(VerificarData(pedido.DataCriacao))
                {
                    quantidadeDePedidosDoMes += 1;
                }
            }
            return Json(quantidadeDePedidosDoMes);
        }

        public JsonResult ObterTotalRendimento()
        {
            List<Pedido> todosOsPedidos = _pedidoRepository.ObterTodos();

            decimal rendimentoTotal = 0;
            foreach (var pedido in todosOsPedidos)
            {
                if(VerificarData(pedido.DataCriacao) && pedido.StatusDoPedido == "Pago")
                {
                    rendimentoTotal += pedido.PrecoTotal;
                }
            }
            return Json(rendimentoTotal);
        }

        public bool VerificarData(DateTime dataCriacao)
        {
                DateTime dataAtual = DateTime.UtcNow;
                if(dataCriacao == null) return false;
                TimeSpan diferencaEm = dataCriacao - dataAtual;
                return dataCriacao.Year != dataAtual.Year ? false : diferencaEm.Days <= 31;
        }


    }
}