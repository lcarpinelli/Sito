using MioSito.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MioSito.Models.Services.Application
{
    public class ContattiService
    {
        public ContattiViewModel GetContatto()
        {
            ContattiViewModel Contatto = new ContattiViewModel
            {
                Nome = "Alessandro",
                Cognome = "Magno",
                Città = "Orvieto",
                Indirizzo = "Via Dell'Innovazione 2",
                Telefono = 33333,
                Immagine = "m.jpg"
            };
            return Contatto;
            
        }
    }
}
