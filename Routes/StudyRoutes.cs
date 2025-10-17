using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyStudies.Data;
using MyStudies.Model;
using MyStudies.Model.Request;

namespace MyStudies.Routes
{
    public static class StudyRoutes
    {
        public static void MapStudyRoutes(this WebApplication app)
        {
            app.MapPost("/studies", async (AppDbContext database, CreateStudyRequest studyRequest) =>
            {
                var study = new Study()
                {
                    Description = studyRequest.Description,
                    Content = studyRequest.Content,
                    Title = studyRequest.Title,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Subjects = new List<Subject>()
                };

                if (studyRequest.SubjectsIds != null && studyRequest.SubjectsIds.Length > 0)
                {
                    foreach (var subjectId in studyRequest.SubjectsIds)
                    {
                        var subject = await database.Subjects.FindAsync(subjectId);

                        if (subject != null)
                        {
                            study.Subjects.Add(subject);
                        }
                    }
                }

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