using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyStudies.Data;
using MyStudies.Model;

namespace MyStudies.Routes
{
    public static class SubjectRoutes
    {
        public static void MapSubjectRoutes(this WebApplication app)
        {

            app.MapGet("/subjects", async (AppDbContext database) =>
            {
                var subjects = await database.Subjects.ToListAsync();

                return subjects;
            });

            app.MapGet("/subjects/{id}", async (int id, AppDbContext database) =>
            {
                var subject = await database.Subjects.FindAsync(id);

                return subject is not null ? Results.Ok(subject) : Results.NoContent();
            });

            app.MapPost("/subjects", async (Subject subject, AppDbContext database) =>
            {
                database.Subjects.Add(subject);

                await database.SaveChangesAsync();

                string message = "O assunto foi criado com sucesso.";

                return Results.Created("/subjects", new
                {
                    message,
                    subject
                });
            });

            app.MapPut("/subjects/{id}", async (int id, Subject updatedSubject, AppDbContext database) =>
            {
                var subject = await database.Subjects.FindAsync(id);

                if (subject == null)
                {
                    var errorMessage = "Não foi encontrado nenhum assunto com este id";

                    return Results.BadRequest(new
                    {
                        message = errorMessage
                    });
                }

                updatedSubject.Id = id;

                subject = updatedSubject;

                await database.SaveChangesAsync();

                var message = "O assunto foi atualizado com sucesso.";

                return Results.Ok(new
                {
                    message,
                    subject
                });
            });

            app.MapDelete("/subjects/{id}", async (int id, AppDbContext database) =>
            {
                var subject = await database.Subjects.FindAsync(id);

                if (subject == null)
                {
                    var errorMessage = "Não foi encontrado nenhum assunto com este id";

                    return Results.BadRequest(new
                    {
                        message = errorMessage
                    });
                }

                database.Subjects.Remove(subject);

                await database.SaveChangesAsync();

                var message = "O assunto foi removido com sucesso.";

                return Results.Ok(new
                {
                    message
                });
            });

        }
    }
}