using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyStudies.Data;
using MyStudies.Model;
using MyStudies.Model.DTOs.Request;
using MyStudies.Model.DTOs.Response;
using MyStudies.Model.Entities;

namespace MyStudies.Routes
{
    public static class StudyRoutes
    {
        public static void MapStudyRoutes(this WebApplication app)
        {
            app.MapGet("/studies", async (AppDbContext database) =>
            {
                var studies = await database.Studies.Include(s => s.Subjects).ToListAsync();

                return Results.Ok(studies);
            });

            app.MapGet("/studies/{id}", async (AppDbContext database, int id) =>
            {
                var study = await database.Studies
                .Include(s => s.Subjects)
                .FirstOrDefaultAsync(s => s.Id == id);

                return Results.Ok(study);
            });



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

                var studyResponse = new CreateStudyResponse(study);

                return Results.Created("/studies", new
                {
                    message,
                    studyResponse
                });
            });
            
            app.MapPut("/studies/{id}", async (AppDbContext database, int id, UpdateStudyRequest studyRequest) =>
            {
                var study = await database.Studies
                .Include(s => s.Subjects)
                .FirstOrDefaultAsync(s => s.Id == id);

                if (study == null)
                {
                    var errorMessage = "Não foi encontrado nenhum estudo com este id";

                    return Results.BadRequest(new
                    {
                        message = errorMessage
                    });
                }

                study.Content = studyRequest.Content;
                study.Title = studyRequest.Title;
                study.Description = studyRequest.Description;

                var subjectList = new List<Subject>();

                if (studyRequest.SubjectsIds != null && studyRequest.SubjectsIds.Length > 0)
                {
                    foreach (var subjectId in studyRequest.SubjectsIds)
                    {

                        var subject = await database.Subjects.FindAsync(subjectId);

                        if (subject != null)
                        {
                            subjectList.Add(subject);
                        }
                    }
                }

                study.Subjects = subjectList;

                await database.SaveChangesAsync();

                var message = "O estudo foi atualizado com sucesso.";

                var studyResponse = new UpdateStudyResponse(study);

                return Results.Ok(new
                {
                    message,
                    studyResponse
                });
            });

            app.MapDelete("/studies/{id}", async (AppDbContext database, int id) =>
            {
                var study = await database.Studies.FindAsync(id);

                if (study == null)
                {
                    var errorMessage = "Não foi encontrado nenhum estudo com este id";

                    return Results.BadRequest(new
                    {
                        message = errorMessage
                    });
                }

                database.Studies.Remove(study);

                await database.SaveChangesAsync();

                 var message = "O estudo foi removido com sucesso.";

                return Results.Ok(new
                {
                    message
                });
            });
        }
                
    }
}