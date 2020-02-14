using MioSito.Controllers;
using MioSito.Models.ViewModels;
using System.Data;

namespace MioSito.Models.Services.Infastructure
{
    public interface IDataBaseConnector
    {
        public DataSet Query(string query);
        public bool Insert(AddCourseViewModel course);
    }
}