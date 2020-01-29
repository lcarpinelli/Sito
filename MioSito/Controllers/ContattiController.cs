using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MioSito.Models;

namespace MioSito.Controllers
{
    public class ContattiController : Controller
    {
        public IActionResult Index()
        {
            Contatti Contatto= new Contatti();

            return View(Contatto);
        }
    }
}