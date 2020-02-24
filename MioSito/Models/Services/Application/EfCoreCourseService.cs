using Microsoft.EntityFrameworkCore;
using MioSito.Models.Interface;
using MioSito.Models.Services.Infrastructure;
using MioSito.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MioSito.Models.Services.Application
{
    public class EfCoreCourseService:ICatalogoService

    {
        private readonly MyCourseDbContext dbContext;
        public EfCoreCourseService(MyCourseDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<CatalogoViewModel>> GetCoursesAsync()
        {
            IQueryable<CatalogoViewModel> queryLinq = dbContext.Courses
            .AsNoTracking()
            .Select(course => CatalogoViewModel.FromEntity(course)); 

            List<CatalogoViewModel> courses = await queryLinq.ToListAsync(); 
                return courses;
        }


        public async Task<CatalogoViewModel> GetCourseAsync(int id)
        {
            IQueryable<CatalogoViewModel> queryLinq = dbContext.Courses
            .AsNoTracking() 
            .Include(course => course.Lessons)
            .Where(course => course.Id == id)
            .Select(course => CatalogoViewModel.FromEntity(course)); 
            CatalogoViewModel viewModel = await queryLinq.SingleAsync();
            
            return viewModel;
        }

        public CatalogoViewModel GetDettagli(string id)
        {
            throw new NotImplementedException();
        }
        public List<CatalogoViewModel> GetCatalogo()
        {
            throw new NotImplementedException();
        }

    }
}
