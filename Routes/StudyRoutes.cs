using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyStudies.Data;
using MyStudies.Model;

namespace MyStudies.Routes
{
    public static class StudyRoutes
    {
        public static void MapStudyRoutes(this WebApplication app)
        {
            app.MapPost("/studies", async (Study study, AppDbContext database) =>
            {
                database.Studies.Add(study);

                await database.SaveChangesAsync();

                string message = "O estudo foi criado com sucesso.";

                return Results.Created("/studies", new
                {
                    message,
                    study
                });
            });

        }
                
    }
}