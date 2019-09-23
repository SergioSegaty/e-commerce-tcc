using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PadawanStore.Domain.Entities;
using PadawanStore.Infra.Data.Interface;

namespace PadawanStore.Web.UI.Controllers
{
    [Route("carrinhousuario")]
    public class CarrinhoUsuarioController : Controller
    {
        private readonly IBaseRepositoryAsync<Produto> _repository;

        public CarrinhoUsuarioController(IBaseRepositoryAsync<Produto> rep)
        {
            _repository = rep;
        }


        [HttpGet, Route("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}