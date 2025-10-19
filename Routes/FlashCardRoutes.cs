using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyStudies.Data;
using MyStudies.Model.Entities;

namespace MyStudies.Routes
{
    public static class FlashCardRoutes
    {
        public static void MapFlashCardRoutes(this WebApplication app)
        {
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
        }
    }
}