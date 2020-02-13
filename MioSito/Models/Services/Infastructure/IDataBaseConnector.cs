using System.Data;

namespace MioSito.Models.Services.Infastructure
{
    public interface IDataBaseConnector
    {
        public DataSet Query(string query);
    }
}