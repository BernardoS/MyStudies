using System.Collections.Generic    ;
using Microsoft.EntityFrameworkCore;
using MyStudies.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=mystudies.db"));

var app = builder.Build();

app.MapGet("/subjects", async (AppDbContext database) =>
{
    var subjects = await database.Subjects.ToListAsync();

    return subjects;
});




app.Run();
                                                                                                       