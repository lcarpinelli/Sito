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
        
        [Required, StringLength(30), Display(Name = "Title")] 
        public string Title { get; set; }
        [Required, StringLength(30), Display(Name = "Title")] 
        public string Author { get; set; }
        public double Rating { get; set; }
        public string ValutaFullPrice { get; set; }
        public string ValutaCurrentPrice { get; set; }
        public double CurrentPrice { get; set; }
        public double FullPrice { get; set; }
        
    }

}

