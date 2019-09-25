using Microsoft.AspNetCore.Mvc;
using LivrariaNerd.Domain.Entities;
using LivrariaNerd.Infra.Data.Interface;

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