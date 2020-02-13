using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MioSito.Models;
using MioSito.Models.Interface;
using MioSito.Models.Services.Application;
using MioSito.Models.Services.Application.CatalogoService;
using MioSito.Models.ViewModels;

namespace MioSito.Controllers
{
    public class CatalogoController : Controller
    {
        private readonly ICatalogoService _catalogoService;

        public CatalogoController(ICatalogoService catalogoService)
        {
            this._catalogoService = catalogoService;
        }

        public IActionResult Index()
        {
            var catalogoService = _catalogoService.GetCatalogo();
            
            return View(catalogoService);
        }


        public IActionResult Cata(string id)
        {

            var catalogoService = _catalogoService.GetDettagli(id);

            return View(catalogoService);
        }


    }
}