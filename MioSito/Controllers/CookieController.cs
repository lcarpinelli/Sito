using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MioSito.Controllers
{
    public class CookieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult WriteCookie(string cookiename, string cookievalue, bool IsPersistent  )
        {
            CookieOptions cookies = new CookieOptions();
            cookies.Expires = DateTime.Now.AddDays(1);
            if (IsPersistent)
            {
                Response.Cookies.Append(cookiename, cookievalue, cookies);

            }
            else
            {
                Response.Cookies.Append(cookiename, cookievalue);           
            }
            ViewBag.message = "Cookies add successfully";
            return View("Index");
        }
        public IActionResult ReadCookie()
        {
            ViewBag.cookievalue = Request.Cookies["username"].ToString(); ;

            return View();
        }
    }
}