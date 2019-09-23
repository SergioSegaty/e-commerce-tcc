using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PadawanStore.Domain.Entities;
using PadawanStore.Infra.Data.Interface;

namespace e_commerce_ws.Controllers
{
    /// <summary>
    /// Controller de Cidade
    /// </summary>
    [Route("cidade")]
    public class CidadeController : Controller
    {
        private readonly IBaseRepositoryAsync<Cidade> _repository;
        private readonly ICidadeRepository _cidadeRepository;

        /// <summary>
        /// Construtor do controller de Cidade
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="cidadeRepository"></param>
        public CidadeController(IBaseRepositoryAsync<Cidade> repository, ICidadeRepository cidadeRepository)
        {
            _repository = repository;
            _cidadeRepository = cidadeRepository;
        }

        /// <summary>
        /// Metodo que permite obter todas as Cidades
        /// </summary>
        /// <returns>Lista de Cidades em um JSON</returns>
        [HttpGet, Route("obtertodos")]
        public JsonResult ObterTodos()
        {
            var cidades = _cidadeRepository.ObterTodos();
            return Json(cidades);
        }

        /// <summary>
        /// Metodo que permite obter todas as Cidades que possuem o mesmo estado
        /// </summary>
        /// <param name="id">Id de um Estado</param>
        /// <returns>Lista de Cidades em um JSON</returns>
        [HttpGet, Route("obtertodospeloestado")]
        public JsonResult ObterTodos(int id)
        {
            var cidades = _cidadeRepository.ObterTodosPeloEstado(id);
            return Json(cidades);
        }

        /// <summary>
        /// Obter uma Cidade pelo Id
        /// </summary>
        /// <param name="id">Id da Cidade</param>
        /// <returns>Cidade em JSON</returns>
        [HttpGet, Route("obterpeloid")]
        public ActionResult ObterPeloId(int id)
        {
            var cidade = _cidadeRepository.ObterPeloId(id);

            if (cidade == null)
                return NotFound();

            return Json(cidade);
        }

        /// <summary>
        /// Adicionar uma nova Cidade
        /// </summary>
        /// <param name="cidade">Objeto Cidade</param>
        /// <returns>Id da Cidade registrada</returns>
        [HttpPost, Route("adicionar")]
        public async Task<JsonResult> Adicionar(Cidade cidade)
        {
            int id = await _repository.Adicionar(cidade);
            return Json(new { id });
        }

        /// <summary>
        /// Alterar uma Cidade
        /// </summary>
        /// <param name="cidade">Objeto Cidade</param>
        /// <returns>Status se alterou com sucesso ou n�o a Cidade</returns>
        [HttpPost, Route("alterar")]
        public JsonResult Alterar(Cidade cidade)
        {
            bool alterou = _repository.Alterar(cidade);
            return Json(new { status = alterou });
        }

        /// <summary>
        /// Apagar uma Cidade
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status se apagou com sucesso ou n�o a Cidade</returns>
        [HttpGet, Route("apagar")]
        public JsonResult Apagar(int id)
        {
            bool apagou = _repository.Apagar(id);
            return Json(new { status = apagou });
        }

        [HttpGet, Route("")]
        public ActionResult Index()
        {
            return View();
        }
    }
}