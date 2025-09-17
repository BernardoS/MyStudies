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

app.MapPut("/usuarios/{id}", (int id, string novoNome) =>
{
    return Results.Ok($"Dado {id} atualizado com sucesso para {novoNome}");
});

app.MapPatch("/usuarios/{id}", (int id, string campo, string valor) =>
{
    return Results.Ok($"Dado {id} teve o campo {campo} atualizado para {valor}");
});

app.MapPatch("/usuarios/{id}", (int id) =>
{
    return Results.Ok($"Dado {id} foi removido com sucesso");
});

app.Run();
                                                                                                       