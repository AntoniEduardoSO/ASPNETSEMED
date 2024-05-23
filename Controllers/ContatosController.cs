using Microsoft.AspNetCore.Mvc;
using ASPNETSEMED.Models;
using ASPNETSEMED.Repositorio;

namespace ASPNETSEMED.Controllers
{
    public class ContatosController : Controller
    {
        private readonly IAnydeskRepositorio _anydeskRepositorio;

        public ContatosController(IAnydeskRepositorio anydeskRepositorio)
        {
            _anydeskRepositorio = anydeskRepositorio;
        }

        public IActionResult Index()
        {
            List<AnydeskModel> anydesks = _anydeskRepositorio.ListaAnydesk();
            return View(anydesks);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(string id)
        {
            try
            {
                AnydeskModel anydesk = _anydeskRepositorio.ListarPorId(id);
                return View(anydesk);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


        public IActionResult ApagarConfirmacao(string id)
        {
            try
            {
                AnydeskModel anydesk = _anydeskRepositorio.ListarPorId(id);
                return View(anydesk);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        public IActionResult Apagar(string id)
        {
            _anydeskRepositorio.Apagar(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Criar(AnydeskModel anydesk)
        {
            _anydeskRepositorio.Adicionar(anydesk);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Alterar(AnydeskModel anydesk)
        {
            _anydeskRepositorio.Atualizar(anydesk);
            return RedirectToAction("Index");
        }
    }
}
