using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MioSito.Models;
using MioSito.Models.Interface;
using MioSito.Models.Services.Application;
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

        public async Task<IActionResult> IndexAsync()
        {
            var catalogoService = await _catalogoService.GetCoursesAsync();
            
            return View(catalogoService);
        }


        public async Task<IActionResult> CataAsync(int id)
        {

            var catalogoService = await _catalogoService.GetCourseAsync(id);

            return View(catalogoService);
        }


    }
}