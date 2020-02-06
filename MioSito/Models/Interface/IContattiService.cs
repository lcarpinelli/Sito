using MioSito.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MioSito.Models.Interface
{
   public interface IContattiService
    {
        public ContattiViewModel GetContatto();
    }
}
