using MioSito.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MioSito.Models.Interface
{
    public interface ICatalogoService
    {
        public List<CatalogoViewModel> GetCatalogo();
        public CatalogoViewModel GetDettagli(string id);
        public Task<List<CatalogoViewModel>> GetCoursesAsync();
        public Task<CatalogoViewModel> GetCourseAsync(int id);
    }
}
