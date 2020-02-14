using MioSito.Models.Interface;
using MioSito.Models.Services.Infastructure;
using MioSito.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MioSito.Models.Services.Application
{
    public class AddCourse:IAddCourse
    {
        private readonly IDataBaseConnector db;
        public AddCourse(IDataBaseConnector dbConnector)
        {
            this.db = dbConnector;
        }

        public bool SetData(AddCourseViewModel addCourse)
        {          
            db.Insert(addCourse);
            return true;
        }
    }
}
