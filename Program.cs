using System.Collections.Generic    ;
using Microsoft.EntityFrameworkCore;
using MyStudies.Data;
using MyStudies.Model;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=mystudies.db"));

var app = builder.Build();

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

app.MapPost("/subjects/", async (Subject subject ,AppDbContext database) =>
{
    database.Subjects.Add(subject);
    await database.SaveChangesAsync();

    string message = "O assunto foi criado com sucesso.";

    return Results.Created("/subjects",new
    {
        message,
        subject
    });
});


app.Run();
                                                                                                       