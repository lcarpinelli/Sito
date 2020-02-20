using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MioSito.Models.Interface;
using MioSito.Models.ViewModels;

namespace MioSito.Controllers
{
    public class AddCourseController : Controller
    {
        private readonly IAddCourse _addcourse;

        public AddCourseController(IAddCourse addcourse)
        {
            this._addcourse = addcourse;
        }
        public IActionResult Index()
        {

            return View();
        }
        public IActionResult Save([FromForm]AddCourseViewModel course)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }
            bool addCourse = _addcourse.SetData(course);
            this.ModelState.Clear();
            if (addCourse == true)
            {
                ViewBag.PopupMessage = "request_saved";
                return View("Index");
            }
            else
            {
                ViewBag.PopupMessage = "request_failed";
                return View("Index");
            }
        }
    }
}