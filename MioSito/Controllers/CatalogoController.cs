using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MioSito.Models;

namespace MioSito.Controllers
{
    public class CatalogoController : Controller
    {
        public IActionResult Index()
        {
            List<string> list = new List<string>() { "PRODOTTO 1","PRODOTTO 2", "PRODOTTO 3","PRODOTTO 4"};
            return View(list);
        }

        public IActionResult Cata()
        {
            return View();
        }


    }
}