using MioSito.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MioSito.Models.Interface
{
    public interface IAddCourse
    {
        public bool SetData(AddCourseViewModel addCourse);
    }
}
