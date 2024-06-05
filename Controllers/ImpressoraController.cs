using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ASPNETSEMED.Repositorio;
using ASPNETSEMED.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace ASPNETSEMED.Controllers;

public class ImpressoraController(IImpressoraRepositorio impressoraRepositorio) : Controller
{
    private readonly IImpressoraRepositorio _impressoraRepositorio = impressoraRepositorio;

    public IActionResult Index()
    {
        List<ImpressoraModel> impressoras = _impressoraRepositorio.ListaImpressora();
        

        return View(impressoras);
    }

    public IActionResult Criar()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Api()
    {
        List<ImpressoraModel> impressoras = _impressoraRepositorio.ListaImpressora();

        
        string json = JsonConvert.SerializeObject(impressoras, new JsonSerializerSettings {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            Formatting = Formatting.Indented,
            NullValueHandling = NullValueHandling.Ignore
        });

        
            
        return Content(json);
    }
}
