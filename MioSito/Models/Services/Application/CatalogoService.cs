using MioSito.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MioSito.Models.Services.Application.CatalogoService
{
    public class CatalogoService:ICatalogoService
    {
        public List<string> GetList()
        {
            List<string> list = new List<string>() { "PRODOTTO 1", "PRODOTTO 2", "PRODOTTO 3", "PRODOTTO 4" };
            return list;
        }
        
    }
}
