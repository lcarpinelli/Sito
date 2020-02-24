using MioSito.Models.ValueTypes;
using MioSito.Models.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MioSito.Models.Entities;


namespace MioSito.Models.ViewModels
{
    public class CatalogoViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public string Author { get; set; }
        public double Rating { get; set; }
        public Money CurrentPrice { get; set; }
        public Money FullPrice { get; set; }
        public string Description { get; set; }
        public List<LessonViewModel> Lessons { get; set; }
        
        public TimeSpan TotalCourseDuration
        {
            get => TimeSpan.FromSeconds(Lessons?.Sum(l => l.Duration.TotalSeconds) ?? 0);
        }

        #region
        internal static CatalogoViewModel FromDbToView(DataRow catalogoRow)
        {
            var catalogoViewModel = new CatalogoViewModel
            {
                Id = Convert.ToInt32(catalogoRow["Id"]),
                Title = Convert.ToString(catalogoRow["Title"]),
                ImagePath = Convert.ToString(catalogoRow["ImagePath"]),
                Author = Convert.ToString(catalogoRow["Author"]),
                Rating = Convert.ToDouble(catalogoRow["Rating"]),
                FullPrice = new Money(
                    Enum.Parse<Currency>(Convert.ToString(catalogoRow["FullPrice_Currency"])),
                    Convert.ToDecimal(catalogoRow["FullPrice_Amount"])),
               CurrentPrice = new Money(
                    Enum.Parse<Currency>(Convert.ToString(catalogoRow["CurrentPrice_Currency"])),
                    Convert.ToDecimal(catalogoRow["CurrentPrice_Amount"])),
            };
            return catalogoViewModel;
        }
        #endregion

        public static new CatalogoViewModel FromEntity(Courses course)
        {
            return new CatalogoViewModel
            {
                Id = course.Id,
                Title = course.Title,
                Description = course.Description,
                Author = course.Author,
                ImagePath = course.ImagePath,
                Rating = course.Rating,
                CurrentPrice = course.CurrentPrice,
                FullPrice = course.FullPrice,
                Lessons = course.Lessons
                .Select(lesson => LessonViewModel.FromEntity(lesson))
                .ToList()
            };
        }
    }
}
