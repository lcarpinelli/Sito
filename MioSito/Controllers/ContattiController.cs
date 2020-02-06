using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MioSito.Models.Interface;
using MioSito.Models.Services.Application;

namespace MioSito.Controllers
{
    
    public class ContattiController : Controller
    {
        private readonly IContattiService _contattiService;

        public ContattiController(IContattiService contattiService)
        {
            this._contattiService = contattiService;
        }
        public IActionResult Index()
        {
            var contatto = _contattiService.GetContatto();
            return View(contatto);
        }
    }
}