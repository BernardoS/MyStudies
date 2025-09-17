using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () =>
{
    List<string> usuarios = new List<string>
    {
        "Bernardo",
        "Larissa"
    };

    return usuarios;
});

app.MapPost("/", (string nome) =>
{
    return Results.Ok($"Retornando o nome enviado via parâmetro:{nome}");
});

app.Run();
                                                                                                       