using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyStudies.Data;
using MyStudies.Model.Entities;

namespace MyStudies.Routes
{
    public static class FlashCardRoutes
    {
        public static void MapFlashCardRoutes(this WebApplication app)
        {
            app.MapGet("/flash-cards", async (AppDbContext database) =>
            {
                var flashCards = await database.FlashCards.ToListAsync();

                return Results.Ok(new
                {
                    flashCards
                });

            });

            app.MapGet("/flash-cards/{id}", async (AppDbContext database, int id) =>
            {
                var flashCard = await database.FlashCards.FindAsync(id);

                return Results.Ok(new
                {
                    flashCard
                });

            });
            
            app.MapGet("/flash-cards/study/{id}", async (AppDbContext database, int id) =>
            {
                var flashCardsByStudy = database.FlashCards
                .Where(f => f.StudyId == id)
                .ToList();
 
                return Results.Ok(flashCardsByStudy);
                
            });


            app.MapPost("/flash-cards", async (AppDbContext database, FlashCard card) =>
            {

                if (card.StudyId == 0)
                {
                    var errorMessage = "Não é possível salvar um card sem id do estudo";

                    return Results.BadRequest(new
                    {
                        message = errorMessage
                    });
                }

                var associatedStudy = await database.Studies.FindAsync(card.StudyId);

                if (associatedStudy == null)
                {
                    var errorMessage = "Não foi possível localizar um estudo com o id enviado.";

                    return Results.BadRequest(new
                    {
                        message = errorMessage
                    });
                }

                card.CreatedAt = DateTime.Now;
                card.UpdatedAt = DateTime.Now;

                database.FlashCards.Add(card);

                await database.SaveChangesAsync();

                string message = "O flash card foi criado com sucesso.";

                return Results.Created("/flash-cards", new
                {
                    message,
                    card
                });

            });

            app.MapPut("/flash-cards/{id}", async (AppDbContext database,int id, FlashCard updatedCard) =>
            {
                var flashCard = await database.FlashCards.FindAsync(id);

                if (flashCard == null)
                {
                    var errorMessage = "Não foi encontrado nenhum card com este id";

                    return Results.BadRequest(new
                    {
                        message = errorMessage
                    });
                }

                flashCard.Question = updatedCard.Question;
                flashCard.Answer = updatedCard.Answer;
                flashCard.UpdatedAt = DateTime.Now;

                await database.SaveChangesAsync();

                var message = "O card foi atualizado com sucesso.";

                return Results.Ok(new
                {
                    message,
                    card = flashCard
                });
            });
        }
    }
}