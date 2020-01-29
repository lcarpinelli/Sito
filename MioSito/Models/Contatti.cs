using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MioSito.Models
{
    public class Contatti
    {
        public string Nome { get; set; } = "Alessandro";
        public string Cognome { get; set; } = "Magno";
        public string Indirizzo { get; set; } = "Via...";
        public string Città { get; set; } = "Babilonia";
        public int Telefono { get; set; } = 3333;
        public string Immagine { get; set; } = "~/wwwroot/m.jpg";

    }
}
