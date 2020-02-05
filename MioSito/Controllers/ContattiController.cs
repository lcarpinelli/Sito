using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MioSito.Models.Services.Application;

namespace MioSito.Controllers
{
    public class ContattiController : Controller
    {
        public IActionResult Index(ContattiService contatto)
        {
            return View(contatto);
        }
    }
}