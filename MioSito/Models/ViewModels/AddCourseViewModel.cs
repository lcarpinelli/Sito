using MioSito.Models.ValueTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MioSito.Models.ViewModels
{
    public class AddCourseViewModel
    {
        
        [Required, StringLength(30), Display(Name = "Title")] public string Title { get; set; }
        [StringLength(1000), Display(Name = "Description")] public string Description { get; set; }
        [StringLength(30), Display(Name = "ImagePath")] public string ImagePath { get; set; }
        [Required, StringLength(30), Display(Name = "Author")] public string Author { get; set; }
        [EmailAddress, Display(Name = "Email")] public string Email { get; set; }
        [Required, Display(Name = "Rating"), Range(0.1, 5.0)] public double Rating { get; set; }
        public string ValutaFullPrice { get; set; }
        public string ValutaCurrentPrice { get; set; }
        [Required, Display(Name = "CurrentPrice"), Range(00.01, 9999.99)] public double CurrentPrice { get; set; }
        [Required, Display(Name = "FullPrice"), Range(00.01, 9999.99)] public double FullPrice { get; set; }
        
    }

}

