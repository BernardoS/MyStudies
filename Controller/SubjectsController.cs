using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyStudies.Data;
using MyStudies.Model;


namespace MyStudies.Controller
{
    public class SubjectsController
    {
        
        public static void MapSubjectRoutes(WebApplication app)
        {
            app.MapGet("/subjects", (AppDbContext database) =>
            {
                return database.Subjects.ToList();
            });
        }
    }
}