using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ASPNETSEMED.Models;
using ASPNETSEMED.Repositorio;

namespace ASPNETSEMED.Controllers;

public class AlooController : Controller
{
    private readonly IAlooRepositorio _alooRepositorio;

    public AlooController(IAlooRepositorio alooRepositorio)
    {
        _alooRepositorio = alooRepositorio;
    }
    public IActionResult Index()
    {

        _alooRepositorio.ListarPorConnectionNotFound();
        List<AlooModel> aloos = _alooRepositorio.ListaAloo();

        return View(aloos);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

   
}
