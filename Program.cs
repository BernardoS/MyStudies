using System.Collections.Generic    ;
using Microsoft.EntityFrameworkCore;
using MyStudies.Data;
using MyStudies.Model;
using MyStudies.Routes;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=mystudies.db"));

var app = builder.Build();

app.MapSubjectRoutes();

app.Run();
                                                                                                       