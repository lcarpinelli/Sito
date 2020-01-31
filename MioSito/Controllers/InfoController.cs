using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MioSito.Models;


namespace MioSito.Controllers
{
    public class InfoController : Controller
    {
        public IActionResult Index(Info i)
        {
            return View(i);
        }

        public IActionResult Pass(Info i)
        {
            
            return View(i);
        }
    }
}
