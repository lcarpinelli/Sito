using Bogus.DataSets;
using Store.Models.ValueTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

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
        public string Valuta { get; set; }

        internal static CatalogoViewModel FromDbToView(DataRow catalogoRow)
        {
            var catalogoViewModel = new CatalogoViewModel
            {
                Id = Convert.ToInt32(catalogoRow["Id"]),
                Title = Convert.ToString(catalogoRow["Title"]),
                ImagePath = Convert.ToString(catalogoRow["ImagePath"]),
                Author = Convert.ToString(catalogoRow["Author"]),
                Rating = Convert.ToDouble(catalogoRow["Rating"]),
                Valuta = Convert.ToString(catalogoRow["CurrentPrice_Currency"]),
                CurrentPrice = new Money(Convert.ToDecimal(catalogoRow["CurrentPrice_Amount"])),
            };
            return catalogoViewModel;

        }
    }
}
