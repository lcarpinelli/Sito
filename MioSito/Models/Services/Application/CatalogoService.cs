using MioSito.Models.Interface;
using MioSito.Models.Services.Infastructure;
using MioSito.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MioSito.Models.Services.Application.CatalogoService
{
    public class CatalogoService:ICatalogoService
    {
        private readonly IDataBaseConnector db;
        public CatalogoService(IDataBaseConnector dbConnector)
        {
            this.db = dbConnector;
        }

        public List<CatalogoViewModel> GetCatalogo()
        {
            string query = $"SELECT Id, Title, ImagePath, Author, Rating, FullPrice_Amount, FullPrice_Currency, CurrentPrice_Currency, CurrentPrice_Amount FROM Courses";
            DataSet dataSet = db.Query(query);
            DataTable dataTable = dataSet.Tables[0];
            List<CatalogoViewModel> catalogoList = new List<CatalogoViewModel>();
            foreach (DataRow catalogoRow in dataTable.Rows)
            {
                CatalogoViewModel CatalogoViewModel = CatalogoViewModel.FromDbToView(catalogoRow);
                catalogoList.Add(CatalogoViewModel);
            }
            return catalogoList; 
        }

        public CatalogoViewModel GetDettagli(string id)
        {
            string query = $"SELECT Id, Title, ImagePath, Author, Rating, FullPrice_Amount, FullPrice_Currency, CurrentPrice_Currency, CurrentPrice_Amount FROM Courses WHERE Id={id}";
            DataSet dataSet = db.Query(query);
            DataTable dataTable = dataSet.Tables[0];
            CatalogoViewModel dettaglio = new CatalogoViewModel();
            foreach(DataRow riga in dataTable.Rows)
            {
                dettaglio = CatalogoViewModel.FromDbToView(riga);
            }

            return dettaglio;
        }
    }
}
