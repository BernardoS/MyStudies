using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MyStudies.Data;
using MyStudies.Model;
using MyStudies.Routes;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=mystudies.db"));

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapSubjectRoutes();
app.MapStudyRoutes();

app.Run();
